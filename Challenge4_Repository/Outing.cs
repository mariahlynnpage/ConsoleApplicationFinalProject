using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Repository
{
    public class Outing
    {

        public Outing()
        {
        }

        public Outing(int numberOfPeople, DateTime date, decimal costPerPerson, Event events)
        {
            NumberOfPeople = numberOfPeople;
            Date = date;
            CostPerPerson = costPerPerson;
            Events = events;
        }

        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCost
        {
            get
            {
                return (CostPerPerson * NumberOfPeople) + Events.GetPricePerOuting;
            }
        }

        public decimal CostPerPerson { get; set; }
        public Event Events { get; set; }
    }
}
