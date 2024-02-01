using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunRace
{
    public class Runner
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Birth { get; set; }
    }
    public class Race
    {
        public int id { get; set; }
        public string Place { get; set; }
        public int Distance { get; set; }
        public DateOnly Date { get; set; }
    }
}