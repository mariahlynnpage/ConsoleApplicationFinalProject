using Challenge4_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_ConsoleUI
{
    class ProgramUI
    {
        private readonly IOutingRepo _repo;
        public ProgramUI(IOutingRepo repo)
        {
            _repo = repo;
        }
        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                PrintMenu();
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        var outingToAdd = GetOutingFromUser();
                        bool createRes = _repo.CreateOuting(outingToAdd);
                        if (createRes)
                        {
                            Console.WriteLine("Your outing has been added.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your outing could not be created.");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        PrintEvents(_repo.ShowOutings());
                        Console.WriteLine("Click any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        ShowOutingPriceByType();
                        Console.WriteLine("Click any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        PrintCostForAllOutings(_repo.CostForAllOutings());
                        Console.WriteLine("Click any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid, please try again.");
                        break;
                }
            }
        }
        private void PrintMenu()
        {
            Console.WriteLine("Welcome to the event list:\n" +
                "1. Create Outing\n" +
                "2. See all outings\n" +
                "3. See outing cost by type\n" +
                "4. See cost for all outings\n" +
                "5. Exit menu.");
        }
        private Outing GetOutingFromUser()
        {
            // number of people
            Console.WriteLine("How many people will be going to this event?");
            int numberOfPeople = int.Parse(Console.ReadLine());
            // date of event
            Console.WriteLine("What date did this occur?");
            DateTime date = DateTime.Parse(Console.ReadLine());
            // cost per person
            Console.WriteLine("What is the cost per person of this event?");
            decimal costPerPerson = decimal.Parse(Console.ReadLine());
            // total cost for the event
            Console.WriteLine("What is the total company cost for this event?");
            decimal totalCost = decimal.Parse(Console.ReadLine());
            // type of outing
            Console.WriteLine("What type of event was this?");
            int enumCounter = 1;
            foreach (var type in Enum.GetNames(typeof(EventType)))
            {
                Console.WriteLine($"{enumCounter}: {type}");
                enumCounter++;
            }
            int enumValue = int.Parse(Console.ReadLine());
            EventType typeOfEvent = (EventType)enumValue;
            return new Outing(numberOfPeople, date, costPerPerson, new Event(typeOfEvent));
        }
        private void PrintEvents(IEnumerable<Outing> outings)
        {
            foreach (Outing outing in outings)
            {
                Console.WriteLine("Number Of People: " + outing.NumberOfPeople);
                Console.WriteLine("Date: " + outing.Date);
                Console.WriteLine("Cost Per Person: " + outing.CostPerPerson.ToString("C"));
                Console.WriteLine("Total company cost for the event: " + outing.TotalCost.ToString("C"));
                Console.WriteLine("Type of Event: " + outing.Events.TypeOfEvent.ToString());
            }
        }

        private void ShowOutingPriceByType()
        {
            Console.WriteLine("Welcome to the total price by event list:\n" +
                            "1. Golf = $2000.00 per outing\n" +
                            "2. Bowling = $3000.00 per outing\n" +
                            "3. Amusement Park = $4000.00 per outing \n" +
                            "4. Concert = $5000.00 per outing\n" +
                            "5. Exit menu.");
        }

        private void PrintCostForAllOutings(decimal cost)
        {
            Console.WriteLine("This is the cost of all outings: " + cost.ToString("C"));    // C is for currency        //D for date 

        }
    }
}