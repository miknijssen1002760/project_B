using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class Vliegtuig
    {
        public string Plane { get; set; }
        public string vluchtNum { get; set; }
        public List<Koltuk> stoelen { get; set; }
    }
}
