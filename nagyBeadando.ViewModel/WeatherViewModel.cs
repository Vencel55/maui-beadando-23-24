using GyorsHir.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.ViewModel
{
    public class WeatherViewModel : BindingSource
    {
        #region Prop
        public double temp_c { get; set; }
        public int is_day { get; set; }
        public double wind_kph { get; set; }
        public string wind_dir { get; set; }
        public double precip_mm { get; set; }
        public int? humidity { get; set; }
        public int? cloud { get; set; }
        public double? feelslike_c { get; set; }
        public double? vis_km { get; set; }
        public double? uv { get; set; }

        //public DelegateCommand SelectCommand { get; private set; }
        #endregion

        #region Ctors
        public WeatherViewModel(Model.DTO.weatherCurrentResult weatherCurrentResult)
        {
            temp_c = weatherCurrentResult.temp_c;
            is_day = weatherCurrentResult.is_day;
            wind_kph = weatherCurrentResult.wind_kph;
            wind_dir = weatherCurrentResult.wind_dir;
            precip_mm  = weatherCurrentResult.precip_mm;
            humidity = weatherCurrentResult?.humidity;
            cloud = weatherCurrentResult?.cloud;
            feelslike_c = weatherCurrentResult?.feelslike_c;
            vis_km = weatherCurrentResult?.vis_km;
            uv = weatherCurrentResult?.uv;

            //SelectCommand = filterCommand;
        }
        #endregion
    }
}
