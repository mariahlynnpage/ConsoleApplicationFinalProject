using Challenge3_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_ConsoleUI
{
    class ProgramUI
    {
        private readonly IBadgeRepo _repo;

        public ProgramUI(IBadgeRepo repo)
        {
            _repo = repo;
        }

        public void Run()
        {
            SeedContentList();

            RunMenu();
        }

        private bool _isRunning = true;

        private readonly BadgeRepository _repo1 = new BadgeRepository();


        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo Badge System.\n" +
                            "What would you like to do?:\n" +
                            "1. Add a badge\n" +
                            "2. Edit a badge's door access\n" +
                            "3. List all badges\n" +
                            "4. Delete all door access from a badge\n" +
                            "5. Exit\n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    AddABadge();
                    break;
                case "2":
                    UpdateDoorAccess();
                    break;
                case "3":
                    ListAllBadges(_repo.ShowBadgeList());
                    break;
                case "4":
                    DeleteDoorAccess();
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                    GetMenuSelection();
                    return;
            }

        }


        private void AddABadge()
        {
            Console.Clear();
            Console.WriteLine("Please enter a Badge ID Number ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Badge User's Name ");
            string badgeName = Console.ReadLine();

            Console.WriteLine("Please enter a door you want this badge to have access to ");
            List<string> doorName = new List<string>();

            bool _isActive = true;

            while (_isActive)
            {
                if (doorName.Count > 0)
                {
                    Console.WriteLine("Would you like to add another door? (Y/N)");

                    string userInput = Console.ReadLine();



                    if (userInput != "N")
                    {
                        Console.WriteLine("Enter door name");
                        string door = Console.ReadLine();
                        doorName.Add(door);
                    }
                    else
                    {
                        _isActive = false;
                    }
                }
                else
                {
                    string door = Console.ReadLine();
                    doorName.Add(door);
                }
            }

            Badge badge = new Badge(badgeID, doorName, badgeName);

            _repo.CreateNewBadge(badge);
            Console.WriteLine("Badge Added!");
            Console.ReadLine();
            PressAnyKeyToReturnToMainMenu();
        }


        private Badge GetBadgeFromUser()
        {
            Console.WriteLine("Please enter a Badge ID Number ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Badge User's Name ");
            string badgeName = Console.ReadLine();

            Console.WriteLine("Please enter a door you want this badge to have access to ");
            List<string> doorName = new List<string>();

            return new Badge(badgeID, doorName, badgeName);
        }

        private void UpdateDoorAccess()
        {
            Console.Clear();
            Console.WriteLine("Please enter a Badge ID Number ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please name a door you would like this badge to have access to: ");
            List<string> doorName = new List<string>();

            bool _isActive = true;

            while (_isActive)
            {
                if (doorName.Count > 0)
                {
                    Console.WriteLine("Would you like to add another door? (Y/N)");

                    string userInput = Console.ReadLine();



                    if (userInput != "N")
                    {
                        Console.WriteLine("Enter door name");
                        string door = Console.ReadLine();
                        doorName.Add(door);
                    }
                    else
                    {
                        _isActive = false;
                    }
                }
                else
                {
                    string door = Console.ReadLine();
                    doorName.Add(door);
                }
            }

            _repo.UpdateDoors(badgeID, doorName);

            Console.WriteLine("Badge updated with doors listed!");
            Console.ReadLine();
            PressAnyKeyToReturnToMainMenu();
        }

        private void DeleteDoorAccess() 
        {
            Console.Clear();
            Console.WriteLine("Please enter a Badge ID Number you would like to remove all door access from: ");
            int badgeID = int.Parse(Console.ReadLine());


            List<string> doorName = new List<string>();


            bool _isActive = true;

            while (_isActive)
            {
                if (doorName.Count > 0)
                {
                    Console.WriteLine("Would you like to add another door? (Y/N)");

                    string userInput = Console.ReadLine();



                    if (userInput != "N")
                    {
                        Console.WriteLine("Enter door name");
                        string doorUpdate = Console.ReadLine();
                        doorName.Count();
                    }
                    else
                    {
                        _isActive = false;
                    }
                }
                else
                {
                    string doorUpdate = Console.ReadLine();
                    doorName.Count();
                    _isActive = false;
                }
            }

            _repo.UpdateDoors(badgeID, doorName);

            Console.WriteLine("Door access removed!");
            Console.ReadLine();
            PressAnyKeyToReturnToMainMenu();
        }

        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        public void ListAllBadges(IEnumerable<Badge> badges)
        {
            foreach (Badge badge in badges)
            {
                Console.WriteLine("Badge ID number: " + badge.BadgeID);
                Console.WriteLine("Name of badge holder: " + badge.BadgeName);
                Console.WriteLine("This badge has access to: ");
                foreach (string door in badge.DoorName)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine();
            }
            Console.ReadLine();

        }

        private void SeedContentList()
        {
            Badge badge1 = new Badge(1, new List<string>() { "A1", "A2", "A3" }, "John");
            Badge badge2 = new Badge(2, new List<string>() { "B1", "B2", "B3" }, "Tim");

            _repo.CreateNewBadge(badge1);
            _repo.CreateNewBadge(badge2);
        }
    }
}