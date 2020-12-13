using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgeRepository
{
    public class BadgeRepository
    {
        //Create Dictionary to hold existing badges
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        //Badge Create
        public void AddBadgeToDictionary(int badgeNumber, Badge badge)
        {
            _badgeDictionary.Add(badgeNumber, badge);
        }

        //Badge Read
        public Dictionary<int, Badge> GetDictionary()
        {
            return _badgeDictionary;
        }

        //Badge Update
        public bool UpdateBadge(int badgeNumber, Badge newBadge)
        {
            //find badge by badge number
            Badge originalBadge = GetBadgeByBadgeNumber(badgeNumber);

            //update the Badge information
            if(originalBadge != null)
            {
                originalBadge.DoorNames = newBadge.DoorNames;
                return true;
            }
            return false;
        }

        //Badge Delete
        public bool DeleteBadgeByBadgeNumber(int badgeNumber)
        {
            Badge badgeToDelete = GetBadgeByBadgeNumber(badgeNumber);
            if(badgeToDelete == null)
            {
                return false;
            }
            int initialCount = _badgeDictionary.Count;
            _badgeDictionary.Remove(badgeNumber);

            if(initialCount > _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper Method
        public Badge GetBadgeByBadgeNumber(int badgeNumber)
        {
            
            bool isTrue = _badgeDictionary.TryGetValue(badgeNumber, out Badge thisBadge);
            if (isTrue)
            {
            return thisBadge;
            }
            return null;
        }
    }
}
