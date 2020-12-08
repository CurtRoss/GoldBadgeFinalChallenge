using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgeRepository
{
    public class Door
    {
        public string DoorName { get; set; }

        public Door() { }

        public Door(string doorName)
        {
            DoorName = doorName;
        }

    }
}
