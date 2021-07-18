using Challenge3_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var badgeRepo = new BadgeRepository();
            var ui = new ProgramUI(badgeRepo);
            ui.Run();
        }
    }
}

