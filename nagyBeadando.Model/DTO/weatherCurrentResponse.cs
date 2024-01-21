using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.Model.DTO
{
    public class weatherCurrentResponse
    {
        public weatherCurrentLocation Location { get; set; }
        public weatherCurrentResult Current { get; set; }
    }
}
