using Challenge4_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var outingRepo = new OutingRepository();
            var ui = new ProgramUI(outingRepo);
            ui.Start();
        }
    }
}