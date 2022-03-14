using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace project_B.Models
{
    internal class Accounts
    {
        private List<Accounts> _accounts;
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"Data/account.json"));

        public Accounts() { Load(); }

        public void Load() { string json = File.ReadAllText(path); _accounts = JsonSerializer.Deserialize<List<Accounts>>(json); }

        public void Write() {
            string json = JsonSerializer.Serialize(_accounts);
            File.WriteAllText(path, json);
        }

        public void UpdateList(Accounts acc)
        {
            int index = _accounts.FindIndex(s => s.id == acc.id);

            if (index != -1)
            {
                _accounts[index] = acc;
            }
            else
            {
                _accounts.Add(acc);
            }
            Write();

        }

        public Accounts getId(int id)
        {
            return _accounts.Find(i => i.id == id);
        }
    }
}



