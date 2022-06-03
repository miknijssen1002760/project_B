using System;
using project_B.Controllers;
using project_B.Models;
using project_B.Views;

namespace project_B.Views
{
    public class AdminControl
    {
        public static string[][] strToLayout(string layoutStr)
        {
            string[][] StrSPlit = new string[3][];//Convert string to string[][]
            return StrSPlit;
        }

        #region ModPlanes
        public static int genIDPlanes()
        {
            planes planes = new planes();
            int current = planes.getLastID();
            return current + 1;
        }

        public static void listPlanes()
        {
            planes planes = new planes();
            planes.listAll();
        }
        public static void addPlane()
        {
            Console.WriteLine("Voeg Vliegtuig toe aan Systeem:");
            Console.WriteLine("Naam: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nLayout: (RowNumber + SeatLetter : vb. 1A 1B 1C 1D 2A 2B...)");
            string layoutStr = Console.ReadLine();
            string[][] layout = strToLayout(layoutStr);

            int ID = genIDPlanes();
            Console.WriteLine("\n" + $"ID assigned: {ID}");

            addPlaneToFile(name, ID, layout);
        }
        public static void delPlane()
        {
            planes planes = new planes();
            listPlanes();
            Console.WriteLine("Welk vliegtuig wil je verwijderen?");
            int chosen = chooseOptionInt();
            plane planeT = planes.getId(chosen);
            Console.WriteLine($"Weet je zeker dat je {planeT.Name} wilt verwijderen?");
            string ynOpt = Console.ReadLine().ToLower();
            if (ynOpt == "y")
            {
                delPlaneToFile(chosen);
            }
            else
            {
                Console.WriteLine("Verkeerde Input");
            }
        }
        public static void changePlaneName()
        {
            planes planes = new planes();
            listPlanes();
            Console.WriteLine("Welk vliegtuigs naam wil je veranderen?");
            int chosen = chooseOptionInt();
            plane planeT = planes.getId(chosen);
            Console.WriteLine($"Naar wat wil je de naam veranderen van {planeT.Name}");
            string nameChange = Console.ReadLine();
            changePlaneNameToFile(chosen, nameChange);
        }
        public static void changePlaneLayout()
        {

        }
        public static void addPlaneToFile(string name, int planeID, string[][] layout)
        {
            plane newPlane = new plane();
            newPlane.Name = name;
            newPlane.PlaneID = planeID;
            newPlane.Layout = layout;
            newPlane.writeToFile();

        }
        public static void delPlaneToFile(int planeID)
        {
            planes planes = new planes();
            plane delPlane = planes.getId(planeID);
            delPlane.Available = false;
            delPlane.writeToFile();
        }
        public static void changePlaneNameToFile(int planeID, string name)
        {
            planes planes = new planes();
            plane chPlane = planes.getId(planeID);
            chPlane.Name = name;
            chPlane.writeToFile();
        }
        public static void changePlaneLayoutToFile(int planeID, string[][] layout)
        {

        }
        #endregion
        #region ModFLights

        public static void listFlights()
        {
            Flights flights = new Flights();
            flights.listAll();
        }

        public static int genIDFlights()
        {
            Flights flights = new Flights();
            int current = flights.getLastID();
            return current + 1;
        }
        public static void addFlight()
        {
            Console.WriteLine("Voeg Vlucht toe aan Systeem:");
            Console.WriteLine("Welk vliegtuig is gekoppeld aan de vlucht?");
            listFlights();
            int flightID = genIDFlights();

            Console.WriteLine("Datum vlucht (dd/mm/YYYY): ");
            string date = Console.ReadLine();

            Console.WriteLine("Vluchtduur (min): ");
            int duration = chooseOptionInt();

            Console.WriteLine("Bestemming: ");
            string destination = Console.ReadLine();

            Console.WriteLine("Vertrekplaats: ");
            string departure = Console.ReadLine();

            int ID = genIDFlights();
            Console.WriteLine("\n" + $"ID assigned: {ID}");

            addFlightToFile(ID, flightID, date, duration, destination, departure);
        }

        public static void addFlightToFile(int ID, int planeID, string date, int duration, string destination, string departure)
        {
            Flight newFlight = new Flight();
            newFlight.Id = ID;
            newFlight.PlaneID = planeID;
            newFlight.Date = date;
            newFlight.Duration = duration;
            newFlight.Destination = destination;
            newFlight.DeparturePlace = departure;
            newFlight.Active = true;
            newFlight.writeToFile();
        }

        public static void deleteFlight()
        {
            Flights flights = new Flights();
            listFlights();
            Console.WriteLine("Welke vlucht wil je verwijderen?");
            int chosen = chooseOptionInt();
            Flight flightT = flights.getId(chosen);
            Console.WriteLine($"Weet je zeker dat je {flightT.Id} wilt verwijderen?");
            string ynOpt = Console.ReadLine().ToLower();
            if (ynOpt == "y")
            {
                deleteFlightToFile(chosen);
            }
            else
            {
                Console.WriteLine("Verkeerde Input");
            }
        }

        public static void deleteFlightToFile(int flightID)
        {
            Flights flights = new Flights();
            Flight delFlight = flights.getId(flightID);
            delFlight.Active = false;
            delFlight.writeToFile();
        }

        public static void editFlight()
        {
            //what flight do you want to change
            //display all flights
            //display selected flight
            //what do you want to change?
            //gotofunction
        }

        public static void editFlightToFile()
        {

        }
        #endregion


        public static string chooseOption()
        {
            Console.Write("\nVoer in Getal: ");
            string chosen = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");

            if (chosen == null) { chosen = "0"; }
            return chosen;
        }
        public static int chooseOptionInt()
        {
            string chosenStr = chooseOption();
            int chosen = Int16.Parse(chosenStr);
            return chosen;
        }
        
        public static void choosePlaneOption()
        {
            string[] PlaneOptions = { "Vliegtuig Toevoegen", "Vliegtuig Verwijderen", "Vliegtuig naam wijzigen", "Wijzig layout", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Plane Options===", PlaneOptions);

            switch (CurrentSelection)
            {
                case 0:
                    addPlane();
                    break;

                case 1:
                    delPlane();
                    break;

                case 2:
                    changePlaneName();
                    break;

                case 3:
                    changePlaneLayout();
                    break;

                case 4:
                    adminOptions();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void chooseUserOption()
        {
            Console.WriteLine("====GebruikerBeheer====");
            Console.WriteLine("\t1. Voeg gebruiker toe");
            Console.WriteLine("\t2. Verwijder gebruiker");
            

            string chosen = chooseOption();

            if (chosen == "1")
            {
                //tbm
            }
            else if (chosen == "2")
            {
                //tbm
            }

            else
            {
                Console.WriteLine("Verkeerde Input");
            }
        }
        public static void chooseFlightOption()
        {
            string[] FlightOptions = { "Vlucht Toevoegen", "Vlucht Verwijderen", "Vlucht Bijwerken", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Flight Options===", FlightOptions);

            switch (CurrentSelection)
            {
                case 0:
                    addFlight();
                    break;

                case 1:
                    deleteFlight();
                    break;

                case 2:
                    editFlight();
                    break;

                case 3:
                    adminOptions();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
            }

        }

        public static void adminOptions()
        {
            string[] AdminOptions = { "Vliegtuig Options", "User Options", "Vlucht Options", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Admin Options===", AdminOptions);

            switch (CurrentSelection)
            {
                case 0:
                    choosePlaneOption();
                    break;

                case 1:
                    chooseUserOption();
                    break;

                case 2:
                    chooseFlightOption();
                    break;

                case 3:
                    project_B.MainMenu();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}