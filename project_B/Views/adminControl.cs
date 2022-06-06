using System;
using project_B.Controllers;
using project_B.Models;
using project_B.Views;

namespace project_B.Views
{
    public class AdminControl
    {

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

        public static void listAllPlanes()
        {
            Console.Clear();

            listPlanes();
            Console.WriteLine("Druk ENTER om terug te gaan");
            Console.ReadLine();
            choosePlaneOption();
        }

        public static void addPlane()
        {
            Console.Clear();

            Console.WriteLine("Voeg Vliegtuig toe aan Systeem:");
            Console.WriteLine("Naam: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nLayout A of B?: ");
            string layout = Console.ReadLine();

            int ID = genIDPlanes();
            Console.WriteLine("\n" + $"ID assigned: {ID}");

            addPlaneToFile(name, ID, layout);

            choosePlaneOption();
        }
        public static void delPlane()
        {
            Console.Clear();

            planes planes = new planes();
            listPlanes();
            Console.WriteLine("Welk vliegtuig wil je verwijderen?");
            int chosen = chooseOptionInt();
            plane planeT = planes.getId(chosen);
            Console.WriteLine($"Weet je zeker dat je {planeT.Name} wilt verwijderen?(j/n)");
            string ynOpt = Console.ReadLine().ToLower();
            if (ynOpt == "j")
            {
                delPlaneToFile(chosen);
            }

            choosePlaneOption();
        }
        public static void changePlaneName()
        {
            Console.Clear();

            planes planes = new planes();
            listPlanes();
            Console.WriteLine("Welk vliegtuigs naam wil je veranderen?");
            int chosen = chooseOptionInt();
            plane planeT = planes.getId(chosen);
            Console.WriteLine($"Naar wat wil je de naam veranderen van {planeT.Name}");
            string nameChange = Console.ReadLine();
            changePlaneNameToFile(chosen, nameChange);

            choosePlaneOption();
        }
        public static void changePlaneLayout()
        {
            Console.Clear();

            planes planes = new planes();
            listPlanes();
            Console.WriteLine("Welk vliegtuigs layout wil je veranderen?");
            int chosen = chooseOptionInt();
            plane planeT = planes.getId(chosen);
            Console.WriteLine($"Naar wat wil je de layout veranderen van {planeT.Name} (A of B)");
            string layoutChange = Console.ReadLine();
            changePlaneLayoutToFile(chosen, layoutChange);

            choosePlaneOption();
        }

        public static void changePlaneLayoutToFile(int planeID, string layout)
        {
            planes planes = new planes();
            plane chPlane = planes.getId(planeID);
            chPlane.Layout = layout;
            chPlane.writeToFile();
        }

        public static void addPlaneToFile(string name, int planeID, string layout)
        {
            plane newPlane = new plane();
            newPlane.Name = name;
            newPlane.PlaneID = planeID;
            newPlane.Layout = layout;
            newPlane.Available = true;
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

        #endregion
        #region ModUser

        public static void listUsers()
        {
            Users users = new Users();
            users.listAll();
        }

        public static void listAllUsers()
        {
            Console.Clear();

            listUsers();
            Console.WriteLine("Druk ENTER om terug te gaan");
            Console.ReadLine();
            chooseUserOption();
        }

        public static void addUser()
        {
            Console.Clear();

            Console.WriteLine("Voeg User toe aan Systeem:");
            Console.WriteLine("Email: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Wachtwoord: ");
            string passWord = Console.ReadLine();

            Console.WriteLine("Voornaam: ");
            string fName = Console.ReadLine();

            Console.WriteLine("Achternaam: ");
            string lName = Console.ReadLine();

            Console.WriteLine("Geboortedag: ");
            string bDay = Console.ReadLine();

            Console.WriteLine("Telefoonnummer: ");
            string telNumber = Console.ReadLine();

            Users users = new Users();

            User user = users.Create(userName, passWord, fName, lName, bDay, telNumber);
            if (user != null)
            {
                Console.WriteLine($"Succesvol {user.UserName} aangemaakt");
            }
            else 
            { 
                Console.WriteLine("\nVekeerde email");
                Console.WriteLine("Druk ENTER om terug te gaan"); Console.ReadLine(); 
            }

            chooseUserOption();
        }
        public static void delUser()
        {
            Console.Clear();

            Users users = new Users();
            listUsers();
            Console.WriteLine("Welke user wil je verwijderen?(Vul in Email)");
            string chosen = Console.ReadLine();
            User user = users.FindUser(chosen);
            Console.WriteLine($"Weet je zeker dat je {user.UserName} wilt verwijderen?(j/n)");
            string ynOpt = Console.ReadLine().ToLower();
            if (ynOpt == "j")
            {
                users.remove(user, users);
            }

            chooseUserOption();
        }

        #endregion
        #region ModFLights

        public static void listFlights()
        {
            Flights flights = new Flights();
            flights.listAll();
        }

        public static void listAllFlights()
        {
            Console.Clear();

            listFlights();
            Console.WriteLine("Druk ENTER om terug te gaan");
            Console.ReadLine();
            chooseFlightOption();
        }

        public static int genIDFlights()
        {
            Flights flights = new Flights();
            int current = flights.getLastID();
            return current + 1;
        }
        public static void addFlight()
        {
            Console.Clear();

            Console.WriteLine("Voeg Vlucht toe aan Systeem:");
            Console.WriteLine("Welk vliegtuig is gekoppeld aan de vlucht?");
            listPlanes();
            int flightID = chooseOptionInt();

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

            chooseFlightOption();
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
            Console.Clear();

            Flights flights = new Flights();
            listFlights();
            Console.WriteLine("Welke vlucht wil je verwijderen?");
            int chosen = chooseOptionInt();
            Flight flightT = flights.getId(chosen);
            Console.WriteLine($"Weet je zeker dat je {flightT.Id} wilt verwijderen?(j/n)");
            string ynOpt = Console.ReadLine().ToLower();
            if (ynOpt == "j")
            {
                deleteFlightToFile(chosen);
            }

            chooseFlightOption();
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
            Console.Clear();

            //what flight do you want to change
            //display all flights
            //display selected flight
            //what do you want to change?
            //gotofunction

            chooseFlightOption();
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
            string[] PlaneOptions = { "Toon vliegtuigen", "Vliegtuig Toevoegen", "Vliegtuig Verwijderen", "Vliegtuig naam wijzigen", "Wijzig layout", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Plane Options===", PlaneOptions);

            switch (CurrentSelection)
            {
                case 0:
                    listAllPlanes();
                    break;

                case 1:
                    addPlane();
                    break;

                case 2:
                    delPlane();
                    break;

                case 3:
                    changePlaneName();
                    break;

                case 4:
                    changePlaneLayout();
                    break;

                case 5:
                    adminOptions();
                    break;

                case 6:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void chooseUserOption()
        {
            string[] UserOptions = { "Toon gebruikers", "Voeg gebruiker toe", "Verwijder Gebruiker", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===GebruikerBeheer===", UserOptions);

            switch (CurrentSelection)
            {
                case 0:
                    listAllUsers();
                    break;

                case 1:
                    addUser();
                    break;

                case 2:
                    delUser();
                    break;

                case 3:
                    adminOptions();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
      
        public static void chooseFlightOption()
        {
            string[] FlightOptions = { "Toon vluchten", "Vlucht Toevoegen", "Vlucht Verwijderen", "Vlucht Bijwerken", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Flight Options===", FlightOptions);

            switch (CurrentSelection)
            {
                case 0:
                    listAllFlights();
                    break;

                case 1:
                    addFlight();
                    break;

                case 2:
                    deleteFlight();
                    break;

                case 3:
                    editFlight();
                    break;

                case 4:
                    adminOptions();
                    break;

                case 5:
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