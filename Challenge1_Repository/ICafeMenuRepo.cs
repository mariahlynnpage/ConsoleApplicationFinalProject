using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Repository
{
    public interface ICafeMenuRepo
    {
        bool CreateMenuItem(MenuItem itemToAdd);
        List<MenuItem> GetMenuItems();
        MenuItem MenuItemNumber(int mealNumber);
        bool DeleteItem(MenuItem itemToDelete);
        int NumberOfItems();
    }
}
