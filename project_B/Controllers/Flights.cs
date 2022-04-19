using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace project_B
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
            Flight[] flights = new Flight[5];
            int index = 0;
            foreach(Flight i in _flights) {
                if(i.Destination == dest) {
                    flights[index] = i;
                    index++;
                }
            }
            if(index != 0) {
                for(int i = 0; i < flights.Length; i++) {
                    if (flights[i] != null) {
                        Console.WriteLine($"{flights[i].Date}, {flights[i].Duration} min, {flights[i].DeparturePlace}");
                    }
                }
            } else {
                Console.WriteLine("Geen vlucht gevonden");
            }
        }
    }
}