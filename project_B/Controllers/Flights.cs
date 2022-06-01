using project_B.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace project_B.Controllers
{
    public class Flights
    {
        private List<Flight> _flights;
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"Data/flights.json"));

        public Flights()
        {
            Load();
        }

        public void Load()
        {
            //Console.WriteLine(path);
            string json = File.ReadAllText(path);

            _flights = JsonSerializer.Deserialize<List<Flight>>(json);

        }

        public void Write()
        {
            string json = JsonSerializer.Serialize(_flights);
            File.WriteAllText(path, json);
        }

        public void UpdateList(Flight acc)
        {
            int index = _flights.FindIndex(s => s.Id == acc.Id);

            if (index != -1)
            {
                _flights[index] = acc;
            }
            else
            {
                _flights.Add(acc);
            }
            Write();

        }

        public Flight getId(int id)
        {
            return _flights.Find(i => i.Id == id);
        }

        public int getLastID()
        {
            Flight last = _flights[_flights.Count - 1];
            return last.Id;
        }

        public List<Flight> GetFlights(string filter)
        {
            List<Flight> flights = new List<Flight>();

            foreach(Flight i in _flights) 
            {
                if(i.Destination == filter) 
                {
                    flights.Add(i);
                }
            }
            return flights;
        }

        public void listAll()
        {
            Console.WriteLine("ID\tDatum\tBestemming\t\tVertrekplaats\tVluchtduur");
            foreach (Flight flight in _flights)
            {
                if (flight.Active == true)
                {
                    Console.WriteLine($"{flight.PlaneID}\t{flight.Date}\t{flight.Destination}\t\t{flight.DeparturePlace}\t{flight.Duration}");
                }
            }
            Console.WriteLine("");
        }
    }
}