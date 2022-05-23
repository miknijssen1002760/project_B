using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Controllers
{
    public class Flight
    {
        [JsonPropertyName("rij")]
        public int Rij { get; set; }

        [JsonPropertyName("datum")]
        public string Datum { get; set; }

        [JsonPropertyName("dag")]
        public string Dag { get; set; }

        [JsonPropertyName("vluchtNum")]
        public string VluchtNum { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("uren")]
        public List<Uur> Uren { get; set; }


    }
}
 