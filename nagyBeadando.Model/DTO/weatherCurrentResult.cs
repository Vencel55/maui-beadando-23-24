using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.Model.DTO
{
    public class weatherCurrentResult
    {
        public double temp_c { get; set; }
        public int is_day { get; set; }
        public double wind_kph { get; set; }
        public string wind_dir { get; set; }
        public double precip_mm { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public double feelslike_c { get; set; }
        public double vis_km { get; set; }
        public double uv { get; set; }
    }
}
