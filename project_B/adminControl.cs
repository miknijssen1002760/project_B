using System;

namespace project_B
{
    internal class Program
    {
        public class planeType
        {
            public string name = "";
            public string type = "";
            public Dictionary<string, int> seats = new Dictionary<string, int>();
            public int seatsEco = 0;
            public int seatsFirstClass = 0;
            public int seatsPremium = 0;
            public int seatsTotal = seatsEco + seatsFirstClass + seatsPremium;

        }
    }
        static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
