using Program.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string GEKOZEN_BESTEMMING = "";
            Flight GEKOZEN_DATUM = new Flight();
            int AANTAL_PERS = 0;
            string GEKOZEN_TIJD = "";

            // Flights flightController = new Flights();

            int vluchtduur = 130;
            int standaardPRijs = 1 * vluchtduur;
            int boekingskosten = 5;
            int luchthavenBelasting = 10;
            double eersteKlas = 3 * vluchtduur;
            double toeslagStoelen = 1.50 * vluchtduur; //stoelen eerste Rij, laatste Rij en Rijen nooduitgang 
            //int extraBaggage = 25; //per koffer




        selectCountry:
            Console.Clear();
            var landen = new string[] { "New York", "Tokyo", "Germany" };
            for (int i = 0; i < landen.Length; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + landen[i]);
            }
            string countryId = Console.ReadLine();

            GEKOZEN_BESTEMMING = landen[Convert.ToInt32(countryId) - 1];
            Console.Clear();
            Console.WriteLine($"Gekozen land " + GEKOZEN_BESTEMMING + " \n");


            FlightService flightService = new FlightService();

            var List = flightService.GetFlights();


        selectFlight:
            Console.Clear();
            Console.WriteLine($"De volgende dagen zijn beschikbaar \n");

            foreach (var flight in List)
            {
                Console.WriteLine("[" + flight.Rij + "] " + flight.Datum + " " + flight.Dag);
            }


            Console.Write("[b] Ga een stap terug \n");
            Console.Write("Voer hier een van de bovenstaande opties in:");
            string flightResponse = Console.ReadLine();

            if (flightResponse == "b")
            {
                goto selectCountry;
            }


            if (List.Any(x => x.Rij == Convert.ToInt32(flightResponse)) == false)
            {
                Console.WriteLine("No flight");
                goto selectFlight;
            }
            else
            {

                Console.Clear();
                Console.WriteLine($"Gekozen land " + GEKOZEN_BESTEMMING + " \n");
                GEKOZEN_DATUM = List.FirstOrDefault(x => x.Rij == Convert.ToInt32(flightResponse));
                Console.Write("Gekozen vlucht " + GEKOZEN_DATUM.Datum);

                Console.WriteLine($"Alles beschikbare tijden \n");

                foreach (var Uur in GEKOZEN_DATUM.Uren)
                {
                    Console.WriteLine("[" + Uur.Rij + "] " + Uur.VluchtUur);
                }
                Console.Write("[b] Ga een stap terug)");
                Console.Write("Voer hier een van de bovenstaande opties in:");
                string gekozenUur = Console.ReadLine();

                if (gekozenUur == "b")
                {
                    Console.Clear();
                    goto selectFlight;
                }

                GEKOZEN_TIJD = GEKOZEN_DATUM.Uren.FirstOrDefault(x => x.Rij == Convert.ToInt32(gekozenUur)).VluchtUur;

            aantalPersKies:
                Console.Clear();
                Console.WriteLine($"Gekozen land " + GEKOZEN_BESTEMMING);
                GEKOZEN_DATUM = List.FirstOrDefault(x => x.Rij == Convert.ToInt32(flightResponse));
                Console.WriteLine("Gekozen vlucht " + GEKOZEN_DATUM.Datum);
                Console.WriteLine("Gekozen tijd " + GEKOZEN_TIJD);
                Console.WriteLine("Aantal personen " + AANTAL_PERS);


                Console.Write("Met hoeveel mensen was u van plan te komen? ([b] Ga een stap terug):");
                string aantalPers = Console.ReadLine();
                if (aantalPers == "b")
                {
                    Console.Clear();
                    goto selectFlight;
                }



                AANTAL_PERS = Convert.ToInt32(aantalPers);

                var vliegtuigInfo = flightService.GetVliegtuig(GEKOZEN_DATUM.VluchtNum);
                var stoelRijNum = vliegtuigInfo.stoelen.GroupBy(x => x.stoelRij).ToList();



            kiesStoel:
                Console.WriteLine(@"       /                                          \");
                Console.WriteLine(@"      /                                            \");
                Console.WriteLine(@"     /                                              \");
                Console.WriteLine(@"    /      ---------------     ---------------       \");
                Console.WriteLine(@"   /     /                |    |               \      \");
                Console.WriteLine(@"  /     /                 |    |                \      \");
                Console.WriteLine(@" /      ------------------     ------------------       \");
                Console.WriteLine(@"|                                                       |");
                Console.WriteLine(@"");

                foreach (var Rij in stoelRijNum)
                {
                    var stoelen = vliegtuigInfo.stoelen.Where(x => x.stoelRij == Rij.Key).ToList();

                    string stoel1 = "";
                    string stoel2 = "";

                    stoel1 += "";
                    foreach (var stoel in stoelen)
                    {
                        string klasseText = "";
                        switch (stoel.klasse)
                        {
                            case 1:
                                klasseText = "STD";
                                break;
                            case 2:
                                klasseText = "EXT";
                                break;
                            case 3:
                                klasseText = "FCL";
                                break;
                        }

                        if (stoel.stoelRij > 9)
                        {
                            stoel1 += " |" + stoel.stoelRij + stoel.stoelNum + "|";
                        }
                        else
                        {
                            stoel1 += " |" + stoel.stoelRij + stoel.stoelNum + " |";
                        }
                        stoel2 += " |" + klasseText + "|";
                    }

                    Console.WriteLine(stoel1);
                    Console.WriteLine(stoel2);
                    Console.WriteLine("");
                    Console.WriteLine("");


                }

                Console.WriteLine(@"[b] Ga een stap terug");


                Console.Write("Kies uw stoel:");


                List<string> gekozenstoel = new List<string>();

                int hvlgekozenstoel = 1;
            kiesStoelVoorRest:

                string stoelantw = Console.ReadLine();

                if (stoelantw == "b")
                {
                    Console.Clear();
                    goto aantalPersKies;
                }


                gekozenstoel.Add(stoelantw);

                if (hvlgekozenstoel != AANTAL_PERS)
                {
                    hvlgekozenstoel++;
                    goto kiesStoelVoorRest;
                }



                int extraBaggage = 0;
            extraBaggageToegevoegd:
                Console.Clear();
                Console.WriteLine($"Gekozen land " + GEKOZEN_BESTEMMING);
                Console.WriteLine("Gekozen vlucht " + GEKOZEN_DATUM.Datum);
                Console.WriteLine("Gekozen uur " + GEKOZEN_TIJD);
                Console.WriteLine("Aantal personen " + AANTAL_PERS);

                string gekozenStoelNaam = "";
                foreach (var stoel in gekozenstoel)
                {
                    gekozenStoelNaam += " (" + stoel.ToUpper() + ") ";
                }
                Console.WriteLine("stoelen " + gekozenStoelNaam);
                Console.WriteLine();

                double totaalPrijs = 0;

                totaalPrijs += extraBaggage * 25;

                foreach (var kt in gekozenstoel)
                {
                    char lastCharacter = kt[kt.Length - 1];

                    string stoelRij = kt.Remove(kt.Length - 1);

                    string stoelLetter = lastCharacter.ToString().ToUpper();

                    var stoelklassesi = vliegtuigInfo.stoelen.FirstOrDefault(x => x.stoelRij == Convert.ToInt32(stoelRij) && x.stoelNum == stoelLetter).klasse;


                    double prijs = 0;

                    string klasseText = "";
                    switch (stoelklassesi)
                    {
                        case 1:
                            klasseText = "STD";
                            prijs = GEKOZEN_DATUM.Duration * 1;
                            break;
                        case 2:
                            klasseText = "EXT";
                            prijs = GEKOZEN_DATUM.Duration * 1.5;
                            break;
                        case 3:
                            klasseText = "FCL";
                            prijs = GEKOZEN_DATUM.Duration * 3;
                            break;
                    }

                    totaalPrijs += prijs;

                    Console.WriteLine("stoel = ( " + kt.ToUpper() + " )      klasse: " + klasseText + "    Prijs:" + prijs);

                }


                for (int i = 0; i < extraBaggage; i++)
                {
                    Console.WriteLine("Extra baggage                       Prijs:25");
                }


                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Totaalprijs                               " + totaalPrijs);




                Console.WriteLine(@"[1] Haal extra baggage");
                Console.WriteLine(@"[b] Ga een stap terug");

                string prijsAntwoord = Console.ReadLine();


                if (prijsAntwoord == "b")
                {
                    Console.Clear();
                    gekozenstoel.Clear();
                    goto kiesStoel;
                }


                if (prijsAntwoord == "1")
                {
                    totaalPrijs = totaalPrijs + 25;
                    extraBaggage++;
                    goto extraBaggageToegevoegd;
                }


            }


























            //if (userResponse1 == "1")
            //{
            //    vluchtduur = 130;
            //    standaardPRijs = vluchtduur * 1;
            //    eersteKlas = 3 * vluchtduur;

            //    Console.WriteLine($"Beschikbare vluchten voor Barcelona: \nStandaartpRijs voor deze vlucht: {standaardPRijs + boekingskosten + luchthavenBelasting} euro. " +
            //        $"\nEerste klas: {eersteKlas + boekingskosten + luchthavenBelasting} euro. \n");
            //    Console.WriteLine("Wilt u de pRijsopbouw zien?");
            //}
            //else if (userResponse1 == "2")
            //{
            //    vluchtduur = 130;
            //    standaardPRijs = 1 * vluchtduur;
            //    eersteKlas = 3 * vluchtduur;
            //    Console.WriteLine($"Beschikbare vluchten voor Rome: \nStandaartpRijs voor deze vlucht: {standaardPRijs + boekingskosten + luchthavenBelasting} euro. " +
            //        $"\nEerste klas: {eersteKlas + boekingskosten + luchthavenBelasting} euro. \n");
            //}
            //else if (userResponse1 == "3")
            //{
            //    vluchtduur = 145;
            //    standaardPRijs = vluchtduur * 1;
            //    eersteKlas = vluchtduur * 3;
            //    Console.WriteLine($"Beschikbare vluchten voor Mallorca: \nStandaartpRijs voor deze vlucht: {standaardPRijs + boekingskosten + luchthavenBelasting} euro. " +
            //        $"\nEerste klas: {eersteKlas + boekingskosten + luchthavenBelasting} euro. \n");
            //}



        }
    }
}
