using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repository
{
    public interface IBadgeRepo
    {
        bool CreateNewBadge(Badge badge);

        Badge UpdateDoors(int badgeID, List<string> doorName);

        bool DeleteDoorsFromBadge(int badgeID);

        List<Badge> ShowBadgeList();

        Badge getBadgeByID(int badgeID);

        int NumberOfBadges();

    }
}