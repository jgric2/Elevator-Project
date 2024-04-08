using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Basic_Elevator.Elevator
{
    public class Elevator
    {
        #region Fields and properties
        // Declaring variables for the maximum weight, speed, floor height, total distance travelled and total 
        private double _maxWeight = 725;
        private double _speed = 1.1;
        private double _floorHeight = 3;
        private double _totalDistanceTravelledMeters = 0;
        private int _totalTripsTaken = 0;
        private Direction _direction = Direction.None; //Elevator Direction
        private bool _showSimulation;

        private List<Person> _peopleOnElevator = new List<Person>();  // List to hold all the people currently in the elevator and at current floor
        private int _currentFloor = 0;  // Current floor elevator is on
        private List<Person> _peopleWaiting = new List<Person>();
        public bool ElevatorRunning = false; // Indicator of whether the elevator is running
       
        // Simulation variables
        public int SimulationSpeed = 100;
        public int TotalFloors;

        // UI elements for the elevator car and shaft
        public Panel Car { get; set; }
        public Panel Shaft { get; set; }

        public Doors DoorStatus = Doors.Closed; // Status of the elevator doors
        private SoundPlayer _player = new SoundPlayer(); // Sound player for elevator ding sound
        #endregion

        #region Events
        // Events for logging messages and changing elevator state
        public event Action<ListViewItem> MessageLogged;
        public event Action<ElevatorEvent> ElevatorEventAction;
        #endregion

        #region Constructor
        // Constructor method for elevator, initializing all essential properties
        public Elevator(int totalFloors, double elevatorSpeed, double maxWeight, double floorHeightMeters, int simulationSpeed, Panel car = null, Panel shaft = null)
        {
            TotalFloors = totalFloors;
            _speed = elevatorSpeed;
            _maxWeight = maxWeight;
            _floorHeight = floorHeightMeters;
            SimulationSpeed = simulationSpeed;
            Car = car;
            Shaft = shaft;

            // Deciding whether to show the elevator simulation
            if (Car == null || Shaft == null)
                _showSimulation = false;
            else
                _showSimulation = true;

            // Setting the sound player stream to a resource file
            string resourcePath = "Basic_Elevator.Resources.elevator-ding.wav";
            _player.Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
        }
        #endregion

        #region Public Methods
        // This method starts the elevator system
        public async Task StartElevator(Queue<Person> peopleQueue)
        {
            _peopleWaiting.AddRange(peopleQueue);

            if (ElevatorRunning)
                return;

            // Logging all elevators requests
            foreach (var person in peopleQueue)
                Log(TimeSpan.FromSeconds(0), person.Name, $"with weight {person.Weight} Kg requested the elevator from floor {person.CurrentFloor}", Color.Green);


            // Fill the elevator if there are people on the current floor within weight limit
            await TryPickupPeopleAsync();

            while (_peopleWaiting.Count > 0 || _peopleOnElevator.Count > 0)
            {
                ElevatorRunning = true;

                if (_peopleOnElevator.Any())
                    await TryPeopleGetOffAsync();

                await TryPickupPeopleAsync();

                // If no more passengers to drop off, move elevator to lowest remaining pickup floor   
                if (_peopleOnElevator.Count == 0 && _peopleWaiting.Count > 0)
                    await MoveToFloor(_peopleWaiting.Min(x => x.CurrentFloor));
            }

            //Elevator has finished tasks
            ElevatorRunning = false;
            _direction = Direction.None;
            ElevatorEvent();
        }
        public List<Person> GetPeopleOnElevator() => _peopleOnElevator;
       
        public List<Person> GetPeopleWaiting() => _peopleWaiting;
        // This method gets the current floor based on the Y-position of the Elevator car
        public int GetCurrentFloorByCarYPos()
        {
            // Calculate the height of a floor in pixels
            int floorHeight = Shaft.Height / TotalFloors;

            // Calculate the floor based on the car's distance from the shaft bottom
            int floor = (int)Math.Floor((double)(Shaft.Height - Car.Bottom) / floorHeight);

            return floor;
        }
        #endregion

        #region Private Methods
        // This method gets the final position of the Elevator car
        private int GetFinalCarPosition(int floor)
        {
            int shaftHeight = Shaft.Height;
            int carHeight = Car.Height;

            int returnHeight = shaftHeight - carHeight;

            returnHeight -= carHeight * floor;

            return returnHeight;
        }

        //This method allows people to disembark from the elevator
        private async Task TryPeopleGetOffAsync()
        {
            var peopleAbove = _peopleOnElevator.Where(x => x.TargetFloor > _currentFloor);
            var peopleBelow = _peopleOnElevator.Where(x => x.TargetFloor < _currentFloor);
            Person nextPerson = null;

            if (_direction == Direction.None)
            {
                // initially, set the direction based on the closest person
                var closestPerson = _peopleOnElevator.OrderBy(x => Math.Abs(x.TargetFloor - _currentFloor)).First();
                _direction = closestPerson.TargetFloor > _currentFloor ? Direction.Up : Direction.Down;
            }

            if (_direction == Direction.Up)
                nextPerson = GetNextPerson(peopleAbove, peopleBelow, _direction);
            else // Current direction is Down
                nextPerson = GetNextPerson(peopleAbove, peopleBelow, _direction);

            if (nextPerson == null)
            {
                // If there's nowhere to go, halt the elevator
                _direction = Direction.None;
            }
            else
            {
                // Move to the decided direction
                await MoveToFloor(nextPerson.TargetFloor);

                // Perform the work of dropping off or picking up people
                var peopleGettingOff = _peopleOnElevator.Where(x => x.TargetFloor == _currentFloor).ToArray();

                await CreateLogMessageAsync(peopleGettingOff);

                _peopleOnElevator = _peopleOnElevator.Except(peopleGettingOff).ToList();
            }
        }

        private Person GetNextPerson(IEnumerable<Person> primary, IEnumerable<Person> secondary, Direction direction)
        {
            Person nextPerson = null;

            if (primary.Any())
            {
                nextPerson = primary.OrderBy(x => x.TargetFloor).First();
            }
            else if (secondary.Any())
            {
                _direction = direction == Direction.Up ? Direction.Down : Direction.Up;
                nextPerson = secondary.OrderByDescending(x => x.TargetFloor).First();
            }

            return nextPerson;
        }

        // This method makes the elevator pick up people
        private async Task TryPickupPeopleAsync()
        {
            var peopleAtThisFloor = _peopleWaiting.Where(x => x.CurrentFloor == _currentFloor).ToArray();
            List<Person> overloadedList = new List<Person>();
            bool peopleEntered = false;
            foreach (var person in peopleAtThisFloor)
            {
                //Bounds checks
                CheckPersonIsNotTooHeavyForElevatorSystem(person);
                CheckDestinationFloorExists(person);

                if (person.Weight + _peopleOnElevator.Sum(y => y.Weight) <= _maxWeight)
                {
                    _peopleOnElevator.Add(person);
                    _peopleWaiting.Remove(person);
                    Log(TimeSpan.FromSeconds(0), person.Name, $"with weight {person.Weight} Kg boarded the elevator at the floor {person.CurrentFloor} Going to floor {person.TargetFloor}", Color.Green);
                    peopleEntered = true;
                }
                else
                {
                    overloadedList.Add(person);
                }
            }

            if (peopleEntered)
                await ElevatorDoorsAsync();

            if (overloadedList.Count == 1)
            {
                Log(TimeSpan.FromSeconds(0), overloadedList[0].Name, $"with weight {overloadedList[0].Weight} Kg had to wait due to elevator's weight limit at floor {_currentFloor}", Color.OrangeRed);
            }
            else if (overloadedList.Count > 1)
            {
                string people = string.Join(", ", overloadedList.Select(p => p.Name));
                double weightTotal = overloadedList.Sum(p => p.Weight);
                Log(TimeSpan.FromSeconds(0), people, $"with combined weight {weightTotal} Kg had to wait due to elevator's weight limit at floor {_currentFloor}", Color.OrangeRed);
            }

        }

        private void CheckDestinationFloorExists(Person person)
        {
            if (person.TargetFloor > TotalFloors)
            {
                //Invalid floor
                _peopleWaiting.Remove(person);
                Log(TimeSpan.FromSeconds(0), person.Name, $"with weight {person.Weight} Kg boarded the elevator at the floor {person.CurrentFloor} and tried to go to {person.TargetFloor}, But it doesn't exist, so {person.Name} left the building.", Color.DarkRed);
            }
        }

        private void CheckPersonIsNotTooHeavyForElevatorSystem(Person person)
        {
            if (person.Weight > _maxWeight)
            {
                //Person is simply too heavy to use lift, has to be helicoptered out of building
                _peopleWaiting.Remove(person);
                Log(TimeSpan.FromSeconds(0), person.Name, $"with weight {person.Weight} Kg was too heavy for the elevator so {person.Name} left the building.", Color.DarkRed);
            }
        }

        // This method operates the elevator doors
        private async Task ElevatorDoorsAsync()
        {
            DoorStatus = Doors.Open;
            _player.Play();
            ElevatorEvent();
            await Task.Delay(1000);
            DoorStatus = Doors.Closed;
            ElevatorEvent();
        }

        // This method creates a log message when people get off elevator
        private async Task<string> CreateLogMessageAsync(Person[] peopleGettingOff)
        {
            if (peopleGettingOff.Length == 1)
            {
                string message = $"{peopleGettingOff[0].Name} with weight {peopleGettingOff[0].Weight} Kg disembarked at floor {_currentFloor}";
                Log(TimeSpan.FromSeconds(0), peopleGettingOff[0].Name, $"with weight {peopleGettingOff[0].Weight} Kg disembarked at floor {_currentFloor}", Color.DarkGreen);

                await ElevatorDoorsAsync();

                return message;
            }
            else if (peopleGettingOff.Length > 1)
            {
                string people = string.Join(", ", peopleGettingOff.Select(p => p.Name));
                double weightTotal = peopleGettingOff.Sum(p => p.Weight);

                string message = $"{peopleGettingOff.Length} people ({people}) with combined weight {weightTotal} Kg disembarked at floor {_currentFloor}";

                Log(TimeSpan.FromSeconds(0), people, $"with combined weight {weightTotal} Kg disembarked at floor {_currentFloor}", Color.DarkGreen);
                await ElevatorDoorsAsync();

                return message;
            }
            return "";
        }

        // This method moves the elevator to a specific floor
        private async Task MoveToFloor(int floor)
        {
            _direction = GetDirectionElevator(floor);
          
            var distance = Math.Abs(floor - _currentFloor) * _floorHeight;
            _totalDistanceTravelledMeters += distance;
            var time = distance / _speed;

            if (_showSimulation)
            {
                await SimulationUIProcessAsync(time, floor);
                ElevatorEvent();
            }
            else
            {
                await Task.Delay((int)time * (1001 - SimulationSpeed)); // simulating the time it would take to go to the specified floor
            }

            Log(TimeSpan.FromSeconds((int)time), "Movement", $"Moved total distance of {distance}m.", Color.Orange);
            _totalTripsTaken++;

            _currentFloor = floor;
            ElevatorEvent();
        }

        private Direction GetDirectionElevator(int floor)
        {
            if (floor > _currentFloor)
                return Direction.Up;
            else if (floor < _currentFloor)
                return Direction.Down;
            else
                return Direction.None;
        }

        private async Task SimulationUIProcessAsync(double time, int floor)
        {
            var simulationSpeedScale = 1 + ((double)SimulationSpeed - 1) / 5;
            var timeMilliseconds = (time * 1000) / simulationSpeedScale;

            //var timeMilliseconds = (time * 1000) / ((double)SimulationSpeed / 100);
            var finalPosition = GetFinalCarPosition(floor);
            var distanceToTravel = Math.Abs(finalPosition - Car.Location.Y);
            var speedPixelsPerMilliseconds = Math.Max((double)distanceToTravel / timeMilliseconds, 0.5);

            if (floor > _currentFloor)
                _direction = Direction.Up;
            else if (floor < _currentFloor)
                _direction = Direction.Down;
            else
                _direction = Direction.None;

            ElevatorEvent();
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;

            double accumulatedChange = 0;
            timer.Tick += (s, e) =>
            {
                accumulatedChange += speedPixelsPerMilliseconds;
                int integerChange = (int)accumulatedChange;

                if (_direction == Direction.Up)
                {
                    if (Car.Location.Y - integerChange <= finalPosition)
                    {
                        Car.Location = new System.Drawing.Point(Car.Location.X, finalPosition);
                        timer.Stop();
                        tcs.SetResult(true);
                    }
                    else
                    {
                        Car.Location = new System.Drawing.Point(Car.Location.X, Car.Location.Y - integerChange);
                    }
                    accumulatedChange -= integerChange;
                    var testFloor = GetCurrentFloorByCarYPos();
                    if (testFloor != _currentFloor)
                    {
                        _currentFloor = testFloor;
                        ElevatorEvent();
                    }
                }
                else
                {
                    if (Car.Location.Y + integerChange >= finalPosition)
                    {
                        Car.Location = new System.Drawing.Point(Car.Location.X, finalPosition);
                        timer.Stop();
                        tcs.SetResult(true);
                    }
                    else
                    {
                        Car.Location = new System.Drawing.Point(Car.Location.X, Car.Location.Y + integerChange);
                    }
                    accumulatedChange -= integerChange;
                    var testFloor = GetCurrentFloorByCarYPos();
                    if (testFloor != _currentFloor)
                    {
                        _currentFloor = testFloor;
                        ElevatorEvent();
                    }
                }
            };
            timer.Start();

            // Wait for the timer to finish.
            await tcs.Task;
        }

        private void ElevatorEvent()
        {
            ElevatorEvent elevatorEvent = new ElevatorEvent();
            elevatorEvent.ElevatorWeight = _peopleOnElevator.Sum(y => y.Weight);
            elevatorEvent.PeopleInElevator = _peopleOnElevator;
            elevatorEvent.PeopleWaiting = _peopleWaiting;
            elevatorEvent.CurrentFloor = _currentFloor;
            elevatorEvent.CurrentDirection = _direction;
            elevatorEvent.DoorStatus = DoorStatus;
            ElevatorEventAction?.Invoke(elevatorEvent);
        }

        private void Log(TimeSpan duration, string persons, string description, Color backColor)
        {
            string durationStr = "";
            if (duration != TimeSpan.Zero)
                durationStr = duration.ToString();

            ListViewItem item = new ListViewItem(durationStr);
            item.SubItems.Add(persons);
            item.SubItems.Add(description);

            item.BackColor = backColor;

            MessageLogged?.Invoke(item);

            ElevatorEvent();
        }
        #endregion
    }
}