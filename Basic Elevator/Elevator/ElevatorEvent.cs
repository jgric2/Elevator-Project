using System;
using System.Collections.Generic;

namespace Basic_Elevator.Elevator
{
    public struct ElevatorEvent
    {
        public double ElevatorWeight { get; set; }
        public List<Person> PeopleInElevator { get; set; }
        public List<Person> PeopleWaiting { get; set; }
        public Direction CurrentDirection { get; set; } 
        public int CurrentFloor {  get; set; } 
        public Doors DoorStatus { get; set; }   

    }
}
