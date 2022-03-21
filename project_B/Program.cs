using project_B.Models;

namespace project_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flights flight = new Flights();
            Flight user = flight.getId(2);
            user.planeID = 7;
            user.writeToFile();
        }
    }
}
