using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Repository
{
    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
    public class Event
    {
        public Event(EventType typeOfEvent)
        {
            TypeOfEvent = typeOfEvent;
        }

        public decimal GetPricePerOuting
        {
            get
            {
                switch (TypeOfEvent)
                {
                    case EventType.Golf:
                        return 2000.00m;
                    case EventType.Bowling:
                        return 3000.00m;
                    case EventType.AmusementPark:
                        return 4000.00m;
                    case EventType.Concert:
                        return 5000.00m;
                    default:
                        return 0.00m;
                }
            }
        }
        public EventType TypeOfEvent { get; set; }
    }
}
