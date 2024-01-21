using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.Model.DTO
{
    public class formulaScheduleResult
    {
        public string? Season { get; set; }
        public string? Round { get; set; }
        public string? RaceName { get; set; }
        public string? Date { get; set; }
        public formulaRaceResults? Results { get; set; }
    }
}
