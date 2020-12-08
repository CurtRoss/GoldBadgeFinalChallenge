using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgeRepository
{
    public class Badge
    {
        private static int count = 12345;
        public int BadgeNumber { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badge()
        {
            count = count + 10000;
            BadgeNumber = count;
        }

        public Badge(List<string> doorNames)
        {
            count = count + 10000;
            BadgeNumber = count;
            DoorNames = doorNames;
        }
    }

}
