using System;

namespace AirlineFood
{
    internal class Program
    {
        public static void addPlane()
        {
            Console.WriteLine("Voeg Vliegtuig toe aan Systeem:");
            Console.WriteLine("Naam: ");
            string? name = Console.ReadLine();

            Console.WriteLine("\nLayout: (RowNumber + SeatLetter : vb. 1A 1B 1C 1D 2A 2B...)");
            string? layoutStr = Console.ReadLine();
            string[][] layout = strToLayout(layoutStr);

            int ID = genID();
            Console.WriteLine("\n" + $"ID assigned: {ID}");

            addPlaneToFile(name, ID, layout);

        }
        public static string[][] strToLayout(string layoutStr)
        {
            string[][] StrSPlit = new string[3][];//COnvert string to string[][]
            return StrSPlit;
        }
        public static int genID()
        {
            int current = 0;//get last ID
            return current + 1;
        }
        public static void delPlane()
        {

        }
        public static void addPlaneToFile(string name, int planeID, string[][] layout)
        {
            Console.WriteLine("\n" + $"Name: {name}, PlaneID: {planeID}, Layout: {layout}");
        }
        public static void delPlaneToFile(int planeID)
        {

        }
        public static void changePlaneName(int planeID, string name)
        {

        }
        public static void changePlaneLayout(int planeID, string[][] layout)
        {

        }

        public static string chooseOption()
        {
            Console.WriteLine("\nVoer in Getal: ");
            string? chosen = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");

            if (chosen == null) {chosen = "0";}
            return chosen;
        }
        public static string chooseMainOption()
        {
            Console.WriteLine("\nWat wil je beheren?:");
            Console.WriteLine("\t1. Vliegtuigen");
            Console.WriteLine("\t2. members");
            Console.WriteLine("\t3. Vluchten");
            
            string chosen = chooseOption();
            return chosen;
        }
        public static void choosePlaneOption()
        {
            Console.WriteLine("\nKies Optie: (getal)");
            Console.WriteLine("\t1. Voeg vliegtuig toe");
            Console.WriteLine("\t2. Verwijder Vliegtuig ");

            string chosen = chooseOption();

            if (chosen == "1") {
                addPlane();
            } else if (chosen == "2") {
                delPlane();
            } else {
                Console.WriteLine("Verkeerde Input");
            }
        }
        public static void Main(String[] args)
        {
            string chosenMain = chooseMainOption();

            if (chosenMain == "1") {
                choosePlaneOption();
            } else if (chosenMain == "2") {
                //tbm
            } else if (chosenMain == "3") {
                //tbm
            } else {
                Console.WriteLine("Verkeerde Input");
            }
        }
    }
}
