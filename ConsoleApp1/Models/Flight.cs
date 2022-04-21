using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Controllers
{
    internal class Flight
    {
        [JsonPropertyName("StandaartPrijs")]
        public int StandaartPrijs { get; set; }

        [JsonPropertyName("boekingsKosten")]
        public int BoekingsKosten { get; set; }

        [JsonPropertyName("luchthavenBelasting")]
        public int LuchthavenBelasting { get; set; }

        [JsonPropertyName("eersteKlas")]
        public int EersteKlas { get; set; }

        [JsonPropertyName("toeslagStoelen")]
        public int ToeslagStoelen { get; set; }

        [JsonPropertyName("extraBaggage")]
        public int ExtraBaggage { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }


    }
}
 