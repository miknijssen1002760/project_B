using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1.Controllers
{
    internal class Flights
    {
        private List<Flight> _flights;
        string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"Data/flights.json"));


        public Flights()
        {
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);

            _flights = JsonSerializer.Deserialize<List<Flight>>(json);
        }
    }
}
