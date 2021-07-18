using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Repository
{
    public class CafeMenuRepo : ICafeMenuRepo
    {
        private readonly List<MenuItem> _menuItem = new List<MenuItem>();
        public bool CreateMenuItem(MenuItem itemToAdd)
        {
            int startingCount = _menuItem.Count();
            _menuItem.Add(itemToAdd);
            bool wasAdded = _menuItem.Count() > startingCount;
            return wasAdded;
        }

        public bool DeleteItem(MenuItem itemToDelete)
        {
            int startingCount = _menuItem.Count();
            _menuItem.Remove(itemToDelete);
            bool wasDeleted = _menuItem.Count() <= startingCount;
            return wasDeleted;

        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuItem;
        }

        public MenuItem MenuItemNumber(int mealNumber)
        {

            foreach (MenuItem menuItem in _menuItem)
            {
                if (menuItem.MealNumber == mealNumber)
                    return menuItem;
            }

            return null;
        }

        public int NumberOfItems()
        {
            int count = 0;

            foreach (MenuItem item in _menuItem)
            {
                count++;
            }

            return count;
        }
    }
}

