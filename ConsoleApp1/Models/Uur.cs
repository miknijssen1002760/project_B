﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Uur
    {
        [JsonPropertyName("rij")]
        public int Rij { get; set; }

        [JsonPropertyName("vluchtUur")]
        public string VluchtUur { get; set; }
    }
}