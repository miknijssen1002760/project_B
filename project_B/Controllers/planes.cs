﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace project_B.Models
{
    internal class planes
    {
        private List<plane> _planes;
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"Data/plane.json"));

        public planes()
        {
            Load();
        }

        public void Load()
        {
            Console.WriteLine(path);
            string json = File.ReadAllText(path);

            _planes = JsonSerializer.Deserialize<List<plane>>(json);
        }

        public void Write()
        {
            string json = JsonSerializer.Serialize(_planes);
            //Console.WriteLine(json);
            File.WriteAllText(path, json);
            Console.WriteLine("write done");
        }

        public void UpdateList(plane pln)
        {
            int index = _planes.FindIndex(s => s.PlaneID == pln.PlaneID);

            if (index != -1)
            {
                _planes[index] = pln;
            }
            else
            {
                _planes.Add(pln);
            }
            Write();

        }

        public plane getId(int id)
        {
            return _planes.Find(i => i.PlaneID == id);
        }
    }
}
