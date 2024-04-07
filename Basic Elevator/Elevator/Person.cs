

namespace Basic_Elevator.Elevator
{
    public class Person
    {
        public Person(double weight, int currentFloor, int targetFloor)
        {
            Weight = weight;
            Name = NameGenerator.GetName();
            CurrentFloor = currentFloor;
            TargetFloor = targetFloor;
        }

        public string Name { get; }
        public double Weight { get; }
        public int CurrentFloor { get; }
        public int TargetFloor { get; }
    }
}
