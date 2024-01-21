using GyorsHir.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.ViewModel
{
    public class AstronomyViewModel : BindingSource
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
        public string Moon_phase { get; set; }
        public int Moon_illumination { get; set; }

        public AstronomyViewModel(Model.DTO.astronomyResult astronomy)
        {
            Sunrise = astronomy.sunrise;
            Sunset = astronomy.sunset;
            Moonrise = astronomy.moonrise;
            Moonset = astronomy.moonset;
            Moon_phase = astronomy.moon_phase;
            Moon_illumination = astronomy.moon_illumination;
        }
    }
}
