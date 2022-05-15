using project_B.FridayPrototype;
using System;

namespace project_B
{
    public class Program
    {

        public static void Main(string[] args)
        {
            HomeScreen();
            FlightMenu();

        }

        public static int MultipleChoice(bool canCancel, string CurrentMenu, params string[] options)
        {
            const int startX = 0;
            const int startY = 1;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;
            int currentSelection = 0;

            ConsoleKey key;
            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                Console.Write(CurrentMenu);

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }

                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }

        public static void HomeScreen()
        {
            string[] LoginMenu = { "Login", "Register", "Exit" };
            int CurrentSelection = MultipleChoice(true, "===Account===", LoginMenu);
            
            switch (CurrentSelection)
            {
                case 0:
                    Login.Show();
                    break;
                case 1:
                    Registreren.Show();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;


            }
        }
        public static void FlightMenu()
        {
            string[] FlightMenu = { "Beschikbare vluchten", "Vlucht Boeken", "Geboekte Vluchten", "Exit" };
            int CurrentSelection = MultipleChoice(true, "===Menu===", FlightMenu);

            switch (CurrentSelection)
            {
                case 0:
                    AvailableFlights.Show();
                    break;

                case 1:
                    MakeReservation.Show();
                    break;

                case 2:
                    Reservations.Show();
                    break;

                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}