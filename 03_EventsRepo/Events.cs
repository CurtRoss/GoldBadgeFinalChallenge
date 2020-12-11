using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EventsRepo
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Events
    {
        public EventType EventType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost { get; set; }
    
        public Events() { }

        //Calculates Total Cost if you have number of attendees and cost per person
        public Events(EventType typeOfEvent, int numberOfAttendees, DateTime dateOfEvent, double costPerPerson)
        {
            EventType = typeOfEvent;
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            TotalCost = numberOfAttendees*costPerPerson;
        }
        //public Events(EventType typeOfEvent, int numberOfAttendees, DateTime dateOfEvent, float totalCost)
        //{
            //EventType = typeOfEvent;
            //NumberOfAttendees = numberOfAttendees;
            //DateOfEvent = dateOfEvent;
            //CostPerPerson = totalCost / numberOfAttendees;
            //TotalCost = totalCost;
        //}
    }

}
