using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Repository
{
    public interface IOutingRepo
    {
        // They 'd like to see a display for the combined cost for all outings.
        decimal CostForAllOutings();


        // They 'd like to see a display of outing costs by type.
        IEnumerable<Outing> OutingCostByType();


        //Add individual outings to a list(don't need to worry about delete yet)
        bool CreateOuting(Outing outingToAdd);


        //Display a list of all outings.
        IEnumerable<Outing> ShowOutings();

        //Count
        int NumberOfOutings();
    }
}
