using ConsoleApp1.Controllers;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Flights flightController = new Flights();

            int vluchtduur = 130;
            int standaardPrijs = 1 * vluchtduur;
            int boekingskosten = 5;
            int luchthavenBelasting = 10;
            double eersteKlas = 3 * vluchtduur;
            double toeslagStoelen = 1.50 * vluchtduur; //stoelen eerste rij, laatste rij en rijen nooduitgang 
            int extraBaggage = 25; //per koffer





            string[] bestemmingen = { "Barcelona", "Rome", "Mallorca" };
            Console.WriteLine("Hello World!");
            Console.WriteLine("Wil je de beschikbare ticketopties zien? (y/n)");
            string userResponse = Console.ReadLine();
            if (userResponse == "y")
            {
                Console.WriteLine($"Beschikbare vluchten: \n");
                for (int i = 0; i < bestemmingen.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] " + bestemmingen[i]);
                }
                Console.WriteLine("Kies uw bestemming: \n");
                string userResponse1 = Console.ReadLine();
                if (userResponse1 == "1")
                {
                    vluchtduur = 130;
                    standaardPrijs = vluchtduur * 1;
                    eersteKlas = 3 * vluchtduur;

                    Console.WriteLine($"Beschikbare vluchten voor Barcelona: \nStandaartprijs voor deze vlucht: {standaardPrijs + boekingskosten + luchthavenBelasting} euro. " +
                        $"\nEerste klas: {eersteKlas + boekingskosten + luchthavenBelasting} euro. \n");
                    Console.WriteLine("Wilt u de prijsopbouw zien?");
                }
                else if (userResponse1 == "2")
                {
                    vluchtduur = 130;
                    standaardPrijs = 1 * vluchtduur;
                    eersteKlas = 3 * vluchtduur;
                    Console.WriteLine($"Beschikbare vluchten voor Rome: \nStandaartprijs voor deze vlucht: {standaardPrijs + boekingskosten + luchthavenBelasting} euro. " +
                        $"\nEerste klas: {eersteKlas + boekingskosten + luchthavenBelasting} euro. \n");
                }
                else if (userResponse1 == "3")
                {
                    vluchtduur = 145;
                    standaardPrijs = vluchtduur * 1;
                    eersteKlas = vluchtduur * 3;
                    Console.WriteLine($"Beschikbare vluchten voor Mallorca: \nStandaartprijs voor deze vlucht: {standaardPrijs + boekingskosten + luchthavenBelasting} euro. " +
                        $"\nEerste klas: {eersteKlas + boekingskosten + luchthavenBelasting} euro. \n");
                }



            }
        }
    }
}
