using project_B.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace project_B.Controllers
{
    public class FlightService
    {
        public List<Flight> GetFlights()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"Data/flights.json"));

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<Flight>>(json);
        }


        public Vliegtuig GetVliegtuig(string vluchtNummer)
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"data/vliegtuig.json"));

            string json = File.ReadAllText(path);

            var ucakBilgileri = JsonSerializer.Deserialize<List<Vliegtuig>>(json);

            return ucakBilgileri.Where(x => x.vluchtNum == vluchtNummer).FirstOrDefault();
        }
    }
}