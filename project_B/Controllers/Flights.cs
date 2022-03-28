using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace project_B
{
    internal class Flights
    {
        private List<Flight> _flights;
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"Data/flights.json"));

        public Flights()
        {
            Load();
        }

        public void Load()
        {
            Console.WriteLine(path);
            string json = File.ReadAllText(path);

            _flights= JsonSerializer.Deserialize<List<Flight>>(json);
        }

        public void Write()
        {
            string json = JsonSerializer.Serialize(_flights);
            //Console.WriteLine(json);
            File.WriteAllText(path, json);
            Console.WriteLine("write done");
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

        public void displayFlights(string dest)
        {
            Flight dis = _flights.Find(i => i.Destination == dest);
            if(dis != null)
            {
                Console.WriteLine($"{dis.Date}, {dis.Duration}, {dis.DeparturePlace}");
            }
            else
            {
                Console.WriteLine("no flights found");
            }
        }
    }
}