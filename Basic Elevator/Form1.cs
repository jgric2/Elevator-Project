using Basic_Elevator.Elevator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Basic_Elevator
{
    public partial class Form1 : Form
    {
        private Elevator.Elevator _elevator;
        delegate void LogDelegate(ListViewItem Lvi);
        delegate void ElevatorEventDelegate(ElevatorEvent Lvi);

        //UI
        int totalFloors = 8;
        int floorHeightPanel;

        public Form1()
        {
            InitializeComponent();
            RecalculateSizeUI();

             _elevator = new Elevator.Elevator(totalFloors, 1.1, 725, 3.3, 100, panelElevatorCar, panelLiftShaft);
            _elevator.MessageLogged += Log;
            _elevator.ElevatorEventAction += ElevatorEvent;
        }

        private void RecalculateSizeUI()
        {
            panelFloors.Controls.Clear();
            floorHeightPanel = panelFloors.Height / totalFloors;
            int lastHeight = 0;
            for (int i = 0; i < totalFloors; i++)
            {
                Label panel = new Label();
                panel.Height = floorHeightPanel;
                panel.Width = panelFloors.Width;
                panel.Location = new Point(0, panelFloors.Height - lastHeight - panel.Height);
                panel.BackColor = Color.DodgerBlue;
                panel.BorderStyle = BorderStyle.FixedSingle;
                lastHeight += panel.Height;
                panel.Text = $"Floor {i}: ";
                panelFloors.Controls.Add(panel);
            }

            panelElevatorCar.Height = floorHeightPanel;
        }

        private void WriteTextSafely(ListViewItem Lvi)
        {
            if (listViewLog.InvokeRequired)
            {
                var d = new LogDelegate(WriteTextSafely);
                listViewLog.Invoke(d, new object[] { Lvi });
            }
            else
                listViewLog.Items.Add(Lvi);
            
            listViewLog.EnsureVisible(listViewLog.Items.Count - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Queue<Person> peopleQueue = new Queue<Person>();
            Random rnd = new Random();
            for (int i = 0; i < (int)numericUpDownPeopleToSimulate.Value; i++)
            {
                int currentFloor = rnd.Next(0,8);
                int destinationFloor = rnd.Next(0, 8);
                while (currentFloor == destinationFloor)
                    destinationFloor = rnd.Next(0, 8);
                
                Person person1 = new Person(rnd.Next(65,110), currentFloor, destinationFloor);
                peopleQueue.Enqueue(person1);
            }
            await _elevator.StartElevator(peopleQueue);
        }

        public void Log(ListViewItem message)
        {
            WriteTextSafely(message);
        }

        public void ElevatorEvent(ElevatorEvent message)
        {
            this.Invoke((MethodInvoker)delegate // Use Invoke to update the UI thread
            {
                labelLiftWeight.Text = $"Lift weight kg: {message.ElevatorWeight}";
                labelPeopleInLift.Text = $"People in lift: {message.PeopleInElevator.Count}";
                labelPeopleWaiting.Text = $"People Waiting: {message.PeopleWaiting.Count}";
                labelLiftCurrentFloor.Text = $"Current Floor: {message.CurrentFloor}";
                labelCurrentDirection.Text = $"Current Direction: {message.CurrentDirection}";


                for (int i = 0; i < panelFloors.Controls.Count; i++)
                {
                    string present = "";
                    var currentFloor = message.PeopleWaiting.Where(x => x.CurrentFloor == i);
                    foreach (var person in currentFloor)
                    {
                        present+= $"{person.Name}: {person.Weight} kg" + Environment.NewLine;
                    }
                    panelFloors.Controls[i].Text = present;
                }


                if(message.DoorStatus == Doors.Open)         
                    panelElevatorCar.BackgroundImage = Properties.Resources.ElevatorOpen1;      
                else if (message.DoorStatus == Doors.Closed)
                    panelElevatorCar.BackgroundImage = Properties.Resources.ElevatorClosed1;

                switch (message.CurrentDirection)
                {
                    case Direction.Down:
                        labelCurrentDirection.ForeColor = Color.OrangeRed;
                        break;
                    case Direction.Up:
                        labelCurrentDirection.ForeColor = Color.Green;
                        break;
                    case Direction.None:
                        labelCurrentDirection.ForeColor = Color.Black;
                        break;

                }
       
                var adding = new ListViewItem[message.PeopleInElevator.Count];
                for (int i = 0; i < adding.Length; i++)
                {
                    var person = message.PeopleInElevator[i];
                    ListViewItem item = new ListViewItem(person.Name);
                    item.SubItems.Add(person.Weight.ToString());
                    item.SubItems.Add(person.TargetFloor.ToString());
                    if (person.TargetFloor < message.CurrentFloor)
                    {
                        item.ForeColor = Color.OrangeRed;
                        item.SubItems.Add("Down");
                    }
                    else
                    {
                        item.ForeColor = Color.Green;
                        item.SubItems.Add("Up");
                    }
                    adding[i] = item;
                }

                listViewPeopleInLift.BeginUpdate();
                listViewPeopleInLift.Items.Clear();
                listViewPeopleInLift.Items.AddRange(adding);
                listViewPeopleInLift.EndUpdate();

                adding = new ListViewItem[_elevator.TotalFloors];
                for (int i = 0; i < adding.Length; i++)
                {
                    adding[i] = new ListViewItem($"Floor {i}");

                    var valid = message.PeopleWaiting.Where (x => x.CurrentFloor == i).ToArray();
                    adding[i].SubItems.Add(valid.Length.ToString());
                    adding[i].SubItems.Add(valid.Sum(x => x.Weight).ToString() + "kg");
                }

                listViewWaiting.BeginUpdate();
                listViewWaiting.Items.Clear();
                listViewWaiting.Items.AddRange(adding);
                listViewWaiting.EndUpdate();
            });
        }

        private void trackBarSimulationSpeed_Scroll(object sender, EventArgs e)
        {
            _elevator.SimulationSpeed = trackBarSimulationSpeed.Value;//1001-trackBarSimulationSpeed.Value;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panelFloors_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RecalculateSizeUI();
        }

        private void checkBoxMute_CheckedChanged(object sender, EventArgs e)
        {
            _elevator.Mute = checkBoxMute.Checked;
        }
    }
}
