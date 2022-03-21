using System;

namespace project_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====account====");
            Console.WriteLine("\r1. Sign in");
            Console.WriteLine("\r2. register");
            Console.Write("\nChoose an option: ");

            bool run = true;
            while (run == true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        run = false;
                        Console.WriteLine("dummy sign in text\n");
                        break;

                    case "2":
                        run = false;
                        Console.WriteLine("dummy register text\n");
                        break;

                    default:
                        Console.Write("This is not a valid option please try again: ");
                        break;
                }
            }
            Console.ReadLine(); 
            Console.Clear();
            Console.WriteLine("====menu====");
            Console.WriteLine("1. beschikbare vluchten");
            Console.WriteLine("2. vlucht boeken");
            Console.WriteLine("3. geboekte vluchten");
            Console.Write("\nChoose an option: ");

            run = true;
            while (run == true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        run = false;
                        Console.WriteLine("insert beschikbare vluchten\n");
                        break;

                    case "2":
                        run = false;
                        Console.WriteLine("insert vlucht boeken\n");
                        break;

                    case "3":
                        run = false;
                        Console.WriteLine("insert geboekte vluchten");
                        break;

                    default:
                        Console.WriteLine("This is not a valid option please try again: ");
                        break;

                }
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
