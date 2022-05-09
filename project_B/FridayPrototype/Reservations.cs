using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.FridayPrototype
{
    static class Reservations
    {

        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Insert Reservations here\n");
            Console.WriteLine("Press x to return to menu");

            var KeyPressed = Console.ReadKey(true);
            switch (KeyPressed.KeyChar)
            {
                case 'x':
                    Program.FlightMenu();
                    break;
                case 'X':
                    Program.FlightMenu();
                    break;
            }
        }

    }
}
