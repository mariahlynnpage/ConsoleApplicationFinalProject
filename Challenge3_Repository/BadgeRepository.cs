using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repository
{
    public class BadgeRepository : IBadgeRepo
    {
        public static readonly Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();
        public static readonly List<Badge> _badges = new List<Badge>();
        //public readonly 


        public bool CreateNewBadge(Badge badgeToAdd)         //create a new badge
        {
            _badges.Add(badgeToAdd);

            if (_badges.Contains(badgeToAdd))
            {
                return true;
            }

            return false;
        }


        public Badge UpdateDoors(int badgeID, List<string> doorName)             //update doors on an existing badge.
        {
            Badge badgeInfo = getBadgeByID(badgeID);

            badgeInfo.DoorName = doorName;

            return badgeInfo;
        }

        public bool DeleteDoorsFromBadge(int badgeID)    //delete all doors from an existing badge.
        {
            int startingCount = _badgeDirectory.Count();
            _badgeDirectory.Remove(badgeID);
            bool wasDeleted = _badgeDirectory.Count() <= startingCount;
            return wasDeleted;
        }

        public List<Badge> ShowBadgeList()          //show a list with all badge numbers and door access
        {
            List<Badge> listOfBadges = _badges;
            return listOfBadges;
        }

        public Badge getBadgeByID(int badgeID)
        {
            foreach (Badge badge in _badges)
            {
                if (badgeID == badge.BadgeID)
                {
                    return badge;
                }
            }

            return null;
        }

        public int NumberOfBadges()
        {
            int count = 0;

            foreach (Badge badge in _badges)
            {
                count++;
            }

            return count;
        }
    }

}