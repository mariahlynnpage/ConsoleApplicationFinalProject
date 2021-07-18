using Challenge1_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_ConsoleUI
{
    class ProgramUI
    {
        public readonly ICafeMenuRepo _repo = new CafeMenuRepo();
        public ProgramUI(ICafeMenuRepo repo)
        {
            _repo = repo;
        }

        public ProgramUI(CafeMenuRepo cafeMenuRepo)
        {
        }

        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                PrintMenu();
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        Console.Clear();
                        GetMenuItems(_repo.GetMenuItems());
                        Console.WriteLine("Click any key to continue.");
                        Console.ReadKey();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            }
        }
        public void CreateMenuItem()
        {
            MenuItem itemToAdd = new MenuItem();
            Console.Clear();
            GetItemFromUser(itemToAdd);

            bool createItem = _repo.CreateMenuItem(itemToAdd);
            if (createItem)
            {
                Console.WriteLine("Menu item added.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your item couldn't be added.");
                Console.ReadKey();
            }

        }

        public void DeleteItem()
        {
            Console.WriteLine("What menu number would you like to delete?");
            int userInput = Convert.ToInt32(Console.ReadLine());
            MenuItem itemToDelete = _repo.MenuItemNumber(userInput);

            bool removeItem = _repo.DeleteItem(itemToDelete);
            if (removeItem)
            {
                Console.WriteLine("Removed your item!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Couldn't remove your item :(");
                Console.ReadKey();
            }
        }
        public void PrintMenu()
        {
            Console.WriteLine("Welcome to Komodo Cafe, what would you like to do?\n" +
                "1. Create Menu Item\n" +
                "2. Look at Menu Items\n" +
                "3. Remove a Menu Item\n" +
                "4. Exit");
        }
        public MenuItem GetItemFromUser(MenuItem item)
        {
            //Meal number
            Console.WriteLine("What menu number would you like to add?");
            item.MealNumber = int.Parse(Console.ReadLine());
            //Meal name
            Console.WriteLine("What is the name of the menu item you would like to add?");
            item.MenuItemName = Console.ReadLine();
            //Description
            Console.WriteLine("What is the description of the item you would like to add?");
            item.Description = Console.ReadLine();
            //Ingrediants
            Console.WriteLine("What ingrediants is the item made of that you would like to add?");
            item.Ingrediants = Console.ReadLine();
            //Price
            Console.WriteLine("What is the price of the menu item that you would like to add?");
            item.Price = int.Parse(Console.ReadLine());
            //Product
            Console.WriteLine("What is the product that you would like to add?");
            int enumCounter = 1;
            foreach (var type in Enum.GetNames(typeof(ProductType)))
            {
                Console.WriteLine($"{enumCounter}: {type}");
                enumCounter++;
            }
            int enumValue = int.Parse(Console.ReadLine());
            item.Product = (ProductType)enumValue;

            return item;

        }
        public void GetMenuItems(IEnumerable<MenuItem> menuItems)
        {

            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine("ID: " + menuItem.MealNumber);
                Console.WriteLine("Name: " + menuItem.MenuItemName);
                Console.WriteLine("Description: " + menuItem.Description);
                Console.WriteLine("Ingrediants: " + menuItem.Ingrediants);
                Console.WriteLine("Price: " + menuItem.Price.ToString("C"));
                Console.WriteLine("Product: " + menuItem.Product.ToString());
            }
            Console.WriteLine();
        }
    }
}

