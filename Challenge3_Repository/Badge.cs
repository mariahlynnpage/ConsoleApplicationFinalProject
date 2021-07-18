using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repository
{
    public class Badge
    {
        public Badge(int badgeID, List<string> doorName, string badgeName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
            BadgeName = badgeName;
        }

        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }
        public string BadgeName { get; set; }


    }
}
