using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.Model.DTO
{
    public class formulaRaceResults
    {
        public string? Number { get; set; }
        public string? Position { get; set; }
        public string? Points { get; set; }
        public formulaDriver? Driver { get; set; }
        public formulaConstructor? Constructor { get; set; }
        public string? Grid { get; set; }
        public formulaRaceResultTime? Time { get; set; }
    }
}
