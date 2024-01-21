using Newtonsoft.Json;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nagyBeadando.Model
{
    public class nagyBeadandoModel
    {
        #region Properties
        public DTO.weatherCurrentResult? GetResultWeather { get; private set; }
        public DTO.weatherCurrentLocation? GetResultLocation { get; private set; }
        public DTO.astronomyResult? GetAstronomyResult { get; set; }
        public IEnumerable<DTO.formulaSeasonResult>? GetFormulaResult { get; set; }
        public IEnumerable<DTO.formulaScheduleResult>? GetFormulaScheduleResult {  get; set; }
        public IEnumerable<DTO.formulaRaceResults>? GetFormulaRaceResult {  get; set; }
        public IEnumerable<DTO.GastronomySearchResult>? GetGastronomySearchResults {  get; set; }
        public DTO.GastronomyRecipeResponse? GetGastronomyRecipeResult { get; set; }
        #endregion

        #region Events
        public event EventHandler? GetWeatherResultsLoaded;
        public event EventHandler? GetFormulaSeasonResultLoaded;
        public event EventHandler? GetFormulaSchedulResultLoaded;
        public event EventHandler? GetFormulaRaceResultLoaded;
        public event EventHandler? GetGastronomySearchResultsLoaded;
        public event EventHandler? GetGastronomyRecipeResultsLoaded;
        #endregion

        #region Public Methods
        public async Task GetWeatherCurrent(string city)
        {
            if (!string.IsNullOrWhiteSpace(city))
            {
                Uri uri = new($"http://api.weatherapi.com/v1/current.json?key=efd9007bb3bc495e8c2171152232612&q={city}&aqi=no");
                using (HttpClient client = new())
                {
                    using HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        DTO.weatherCurrentResponse? getResponse = JsonConvert.DeserializeObject<DTO.weatherCurrentResponse>(await response.Content.ReadAsStringAsync());

                        if (getResponse != null && getResponse.Location != null && getResponse.Current != null)
                        {
                            GetResultWeather = getResponse.Current;
                            GetResultLocation = getResponse.Location;
                        }
                    }
                }
            }
        }
        public async Task GetAstronomy(string city)
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            int day = DateTime.Today.Day;

            if (!string.IsNullOrWhiteSpace(city))
            {
                Uri uri = new($"http://api.weatherapi.com/v1/astronomy.json?key=efd9007bb3bc495e8c2171152232612&q={city}&dt={year}-0{month}-0{day}");
                using (HttpClient client = new())
                {
                    using HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        DTO.astronomyResponse? getResponse = JsonConvert.DeserializeObject<DTO.astronomyResponse>(await response.Content.ReadAsStringAsync());

                        if (getResponse != null && getResponse.Astronomy != null)
                        {
                            GetAstronomyResult = getResponse.Astronomy.Astro;
                            GetWeatherResultsLoaded?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }
        public async Task GetFormulaSeasons()
        {
            Uri uri = new($"https://ergast.com/api/f1/seasons.json?limit=75");
            using (HttpClient client = new())
            {
                using HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DTO.formulaSeasonResponse? getResponse = JsonConvert.DeserializeObject<DTO.formulaSeasonResponse>(await response.Content.ReadAsStringAsync());

                    if (getResponse != null && getResponse.MRData != null && getResponse.MRData.SeasonTable != null && getResponse.MRData.SeasonTable.Seasons != null)
                    {
                        GetFormulaResult = getResponse.MRData.SeasonTable.Seasons;
                        GetFormulaSeasonResultLoaded?.Invoke(this, EventArgs.Empty);    
                    }
                }
            }
        }
        public async Task GetFormulaSchedule(string date)
        {
            Uri uri = new($"https://ergast.com/api/f1/{date}.json?limit=30");
            using (HttpClient client = new())
            {
                using HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DTO.formulaSeasonResponse? getResponse = JsonConvert.DeserializeObject<DTO.formulaSeasonResponse>(await response.Content.ReadAsStringAsync());
                    if (getResponse != null && getResponse.MRData != null && getResponse.MRData.RaceTable != null && getResponse.MRData.RaceTable.Races != null)
                    {
                        GetFormulaScheduleResult = getResponse.MRData.RaceTable.Races;
                        GetFormulaSchedulResultLoaded?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }
        public async Task GetFormulaRace(string date,string race)
        {
            Uri uri = new($"https://ergast.com/api/f1/{date}/{race}/results.json");
            using (HttpClient client = new())
            {
                using HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DTO.formulaRaceResponse? getResponse = JsonConvert.DeserializeObject<DTO.formulaRaceResponse>(await response.Content.ReadAsStringAsync());
                    if (getResponse != null && getResponse.MRData != null && getResponse.MRData.RaceTable != null && getResponse.MRData.RaceTable.Races != null)
                    {
                        foreach (var item in getResponse.MRData.RaceTable.Races)
                        {
                            GetFormulaRaceResult = item.Results;
                        }
                        GetFormulaRaceResultLoaded?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }
        public async Task GetGastronomySearch(string query,string cuisine,string diet,string intolerances,string includeIngredients)
        {
            Uri uri = new($"https://api.spoonacular.com/recipes/complexSearch?query={query}&cuisine={cuisine}&diet={diet}&intolerances={intolerances}&includeIngredients={includeIngredients}&apiKey=02414cd447ac484ea8bf00bc35e5cb1c");
            using (HttpClient client = new())
            {
                using HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DTO.GastronomySearchRespone? getResponse = JsonConvert.DeserializeObject<DTO.GastronomySearchRespone>(await response.Content.ReadAsStringAsync());
                    if (getResponse != null && getResponse.Results !=null)
                    {
                        GetGastronomySearchResults = getResponse.Results;
                        GetGastronomySearchResultsLoaded?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }
        public async Task GetGastronomyRecipe(int id)
        {
            Uri uri = new($"https://api.spoonacular.com/recipes/{id}/information?includeNutrition=false&apiKey=02414cd447ac484ea8bf00bc35e5cb1c");
            using (HttpClient client = new())
            {
                using HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DTO.GastronomyRecipeResponse? getResponse = JsonConvert.DeserializeObject<DTO.GastronomyRecipeResponse>(await response.Content.ReadAsStringAsync());
                    if (getResponse != null)
                    {
                        GetGastronomyRecipeResult = getResponse;
                        GetGastronomyRecipeResultsLoaded?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }
        #endregion
    }
}
