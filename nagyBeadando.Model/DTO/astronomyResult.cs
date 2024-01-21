using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.Model.DTO
{
    public class astronomyResult
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public int moon_illumination { get; set; }
    }
}
