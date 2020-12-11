using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EventsRepo
{
    public class EventsRepository
    {
        public readonly List<Events> _allEventsList = new List<Events>();

        //Create
        public void AddEventToList(Events events)
        {
            _allEventsList.Add(events);
        }


        //Read
        public List<Events> GetEventList()
        {
            return _allEventsList;
        }
    }
}
