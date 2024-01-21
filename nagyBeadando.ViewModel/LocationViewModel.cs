namespace nagyBeadando.ViewModel
{
    public class LocationViewModel : BindingSource
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public LocationViewModel(Model.DTO.weatherCurrentLocation location)
        {
            Name = location.Name;
            Region = location.Region;
            Country = location.Country;
        }
    }

}
