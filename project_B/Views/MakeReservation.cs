using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Views
{
    static class MakeReservation
    {

        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("insert reservation here\n");
            Console.WriteLine("Press x to return to menu");

            var KeyPressed = Console.ReadKey(true);
            switch (KeyPressed.KeyChar)
            {
                case 'x':
                    Program.MainMenu();
                    break;
                case 'X':
                    Program.MainMenu();
                    break;
            }
        }
    }
}
