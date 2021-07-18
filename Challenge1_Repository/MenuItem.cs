using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Repository
{
    public enum ProductType { Sandwich = 1, Soup, Salad, Breakfast, Smoothie }
    public class MenuItem
    {
        public MenuItem()
        {
        }

        public MenuItem(int mealNumber, string menuItemName, string description, string ingrediants, int price, ProductType product)
        {
            MealNumber = mealNumber;
            MenuItemName = menuItemName;
            Description = description;
            Ingrediants = ingrediants;
            Price = price;
            Product = product;
        }

        public int MealNumber { get; set; }
        public string MenuItemName { get; set; }
        public string Description { get; set; }
        public string Ingrediants { get; set; }
        public int Price { get; set; }
        public ProductType Product { get; set; }
    }
}