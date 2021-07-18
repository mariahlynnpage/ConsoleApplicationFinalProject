using Challenge1_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var cafeMenuRepo = new CafeMenuRepo();
            var ui = new ProgramUI(cafeMenuRepo);
            ui.Start();
        }
    }
}
