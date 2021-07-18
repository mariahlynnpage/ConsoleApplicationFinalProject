using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Repository
{
    public class OutingRepository : IOutingRepo
    {
        private readonly List<Outing> _outings = new List<Outing>();


        public decimal CostForAllOutings()
        {
            decimal CostForOutings = 0;

            foreach (Outing outing in _outings)
            {
                CostForOutings += outing.TotalCost;
            }
            return CostForOutings;
        }

        public bool CreateOuting(Outing outingToAdd)
        {
            _outings.Add(outingToAdd);

            if (_outings.Contains(outingToAdd))
            {
                return true;
            }
            return false;
        }

        public int NumberOfOutings()
        {
            int count = 0;

            foreach (Outing outing in _outings)
            {
                count++;
            }
            return count;
        }

        public IEnumerable<Outing> OutingCostByType()
        {
            return _outings;
        }

        public IEnumerable<Outing> ShowOutings()
        {
            return _outings;
        }
    }
}
