using project_B.FridayPrototype;
using System;

namespace project_B
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("====account====");
            Console.WriteLine("\r1. Sign in");
            Console.WriteLine("\r2. register");
            Console.WriteLine("\r3. Reserverming maken");
            Console.Write("\nChoose an option: ");

            bool valid = false;
            while (valid == false)
            {
                valid = true;
                switch (Console.ReadLine())
                {
                    case "1":

                        Registeren.Show();
                        break;

                    case "2":
                        Login.Show();

                        break;

                    default:
                        valid = false;
                        Console.Write("This is not a valid option please try again: ");
                        break;
                }
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("====menu====");
            Console.WriteLine("1. beschikbare vluchten");
            Console.WriteLine("2. vlucht boeken");
            Console.WriteLine("3. geboekte vluchten");
            Console.Write("\nChoose an option: ");

            int input = int.Parse(Console.ReadLine());

            valid = false;
            while (valid == false)
            {
                valid = true;
                switch (Console.ReadLine())
                {
                    case "1":
                        valid = false;
                        Console.WriteLine("insert beschikbare vluchten\n");
                        break;

                    case "2":
                        valid = false;
                        MakeReservation.Show();
                        break;

                    case "3":
                        valid = false;
                        Console.WriteLine("insert geboekte vluchten");
                        break;

                    default:
                        Console.WriteLine("This is not a valid option please try again: ");
                        break;

                }
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            Console.Clear();

        }
    }