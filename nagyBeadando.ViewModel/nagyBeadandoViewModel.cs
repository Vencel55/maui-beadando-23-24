using GyorsHir.ViewModel;
using nagyBeadando.Model.DTO;
using System.Collections.ObjectModel;

namespace nagyBeadando.ViewModel
{
    public class nagyBeadandoViewModel : BindingSource
    {
        #region Fields
        private Model.nagyBeadandoModel _model;

        private LocationViewModel _weatherLocation;
        private WeatherViewModel _weather;
        private AstronomyViewModel _astronomy;
        private FomulaSeasonsViewModel _selectedSeason;
        private FormulaScheduleViewModel _selectedRace;
        private GastronomySearchViewModel _selectedRecipe;
        private GastronomyRecipeViewModel _recipe;
        #endregion

        #region Properties
        public LocationViewModel WeatherLocation {
            get => _weatherLocation;
            private set
            {
                if (value != _weatherLocation)
                {
                    _weatherLocation = value;
                    OnPropertyChanged();
                }
            } 
        }
        public WeatherViewModel Weather {
            get => _weather;
            private set
            {
                if (value != _weather)
                {
                    _weather = value;
                    OnPropertyChanged();
                }
            }
        }
        public AstronomyViewModel Astronomy
        {
            get => _astronomy;
            private set
            {
                if (value != _astronomy)
                {
                    _astronomy = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<FomulaSeasonsViewModel> Seasons { get; set; } = new ObservableCollection<FomulaSeasonsViewModel>();
        public FomulaSeasonsViewModel SelectedSeason {
            get => _selectedSeason;
            private set
            {
                if (value != _selectedSeason)
                {
                    _selectedSeason = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<FormulaScheduleViewModel> Races { get; set; } = new ObservableCollection<FormulaScheduleViewModel>();
        public FormulaScheduleViewModel SelectedRace
        {
            get => _selectedRace;
            private set
            {
                if (value != _selectedRace)
                {
                    _selectedRace = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<FormulaRaceViewModel> RaceResult { get; set; } = new ObservableCollection<FormulaRaceViewModel>();
        public ObservableCollection<GastronomySearchViewModel> GastronomySearchResult { get; set; } = new ObservableCollection<GastronomySearchViewModel>();
        public GastronomySearchViewModel SelectedRecipe
        {
            get => _selectedRecipe;
            private set
            {
                if (value != _selectedRecipe)
                {
                    _selectedRecipe = value;
                    OnPropertyChanged();
                }
            }
        }
        public GastronomyRecipeViewModel GastronomyRecipeResult
        {
            get => _recipe;
            private set
            {
                if (value != _recipe)
                {
                    _recipe = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<IngredietnsViewModel> Ingredients { get; set; } = new ObservableCollection<IngredietnsViewModel>();
        public string CityFilter { get; set; }
        public string QuerryFilter { get; set; }
        public string DietFilter { get; set; }
        public string CuisineFilter { get; set; }
        public string IntolerancesFilter { get; set; }
        public string IncludeIngredientsFilter { get; set; }
        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand FormulaCommand { get; private set; }
        public DelegateCommand WeatherCommand { get; set; }
        public DelegateCommand SpotifyCommand { get; set; }
        public DelegateCommand GastronomyCommand { get; set; }
        public DelegateCommand GastronomySearchCommand { get; set; }
        #endregion

        #region Events
        public event EventHandler? WeatherLoaded;
        public event EventHandler? FormulaLoaded;
        public event EventHandler? SpotifyLoaded;
        public event EventHandler? GastronomyLoaded;
        public event EventHandler? SeasonSelected;
        public event EventHandler? RaceSelected;
        public event EventHandler? RecipeSelected;
        #endregion

        #region Ctors

        public nagyBeadandoViewModel(Model.nagyBeadandoModel model)
        {
            _model = model ?? throw new ArgumentNullException("model");

            _model.GetWeatherResultsLoaded += _model_GetResultsLoaded;
            _model.GetFormulaSeasonResultLoaded += _model_GetFormulaSeasonResultLoaded;
            _model.GetFormulaSchedulResultLoaded += _model_GetFormulaSchedulResultLoaded;
            _model.GetFormulaRaceResultLoaded += _model_getFormulaResultLoaded;
            _model.GetGastronomySearchResultsLoaded += _model_GetGastronomySearchResultsLoaded;
            _model.GetGastronomyRecipeResultsLoaded += _model_GetGastronomyRecipeResultsLoaded;

            SearchCommand = new DelegateCommand(Command_Search);
            FormulaCommand = new DelegateCommand(Command_Formula);
            SpotifyCommand = new DelegateCommand(Command_Spotify);
            GastronomyCommand = new DelegateCommand(Command_Gastronomy);
            WeatherCommand = new DelegateCommand(Command_Weather);

            GastronomySearchCommand = new DelegateCommand(GetGastronomySearch);
        }
        #endregion

        #region Model event handlers
        private void _model_GetResultsLoaded(object? sender, EventArgs e)
        {
            if (_model.GetResultWeather != null && _model.GetResultLocation != null && _model.GetAstronomyResult != null)
            {
                WeatherLocation = new LocationViewModel(_model.GetResultLocation);
                Weather = new WeatherViewModel(_model.GetResultWeather);
                Astronomy = new AstronomyViewModel(_model.GetAstronomyResult);
            }
        }
        private void _model_GetFormulaSeasonResultLoaded(object? sender, EventArgs e)
        {
            if(_model.GetFormulaResult != null)
            {
                foreach(Model.DTO.formulaSeasonResult result in _model.GetFormulaResult)
                {
                    Seasons.Add(new FomulaSeasonsViewModel(result, new DelegateCommand(Command_SelectSeason)));
                }
            }
        }
        private void _model_GetFormulaSchedulResultLoaded(object? sender, EventArgs e)
        {
            if(_model.GetFormulaScheduleResult != null)
            {
                foreach (Model.DTO.formulaScheduleResult result in _model.GetFormulaScheduleResult)
                {
                    Races.Add(new FormulaScheduleViewModel(result,new DelegateCommand(Command_SelectRace)));
                }
            }
        }
        private void _model_getFormulaResultLoaded(object? sender, EventArgs e)
        {
            if (_model.GetFormulaRaceResult != null) 
            {
                foreach (Model.DTO.formulaRaceResults result in _model.GetFormulaRaceResult)
                {
                    RaceResult.Add(new FormulaRaceViewModel(result));
                }
            }
        }
        private void _model_GetGastronomySearchResultsLoaded(object? sender, EventArgs e)
        {
            if(_model.GetGastronomySearchResults != null)
            {
                foreach (GastronomySearchResult result in _model.GetGastronomySearchResults)
                {
                    GastronomySearchResult.Add(new GastronomySearchViewModel(result,new DelegateCommand(Command_SelectRecipe)));
                }
            }
            
        }
        private void _model_GetGastronomyRecipeResultsLoaded(object? sender, EventArgs e)
        {
            if(_model.GetGastronomyRecipeResult != null)
            {
                GastronomyRecipeResult = new GastronomyRecipeViewModel(_model.GetGastronomyRecipeResult);
                if(_model.GetGastronomyRecipeResult.ExtendedIngredients is not null)
                {
                    foreach (GastronomyIngredients item in _model.GetGastronomyRecipeResult.ExtendedIngredients)
                    {
                        Ingredients.Add(new IngredietnsViewModel(item));
                    }
                }
            }
        }
        #endregion

        #region Commands
        private async void Command_Search(object? param)
        {
            await _model.GetWeatherCurrent(CityFilter);
            await _model.GetAstronomy(CityFilter);
        }
        private async void FormulaSeason()
        {
            Seasons.Clear();
            await _model.GetFormulaSeasons();
        }
        private async void FormulaSchedule()
        {
            Races.Clear();
            await _model.GetFormulaSchedule(SelectedSeason.Season);
        }
        private async void FormulaRace()
        {
            RaceResult.Clear();
            await _model.GetFormulaRace(SelectedSeason.Season, SelectedRace.Round);
        }
        private async void GetGastronomyRecipe()
        {
            Ingredients.Clear();
            await _model.GetGastronomyRecipe(SelectedRecipe.Id);
        }
        private async void GetGastronomySearch(object? param)
        {
            GastronomySearchResult.Clear();
            await _model.GetGastronomySearch(QuerryFilter, CuisineFilter, DietFilter, IntolerancesFilter, IncludeIngredientsFilter);
        }
        private void Command_SelectSeason(object? param)
        {
            if (param != null && param is FomulaSeasonsViewModel selectedSeason)
            {
                SelectedSeason = selectedSeason;
                OnSelectedSeason();
                FormulaSchedule();
            }
        }
        private void Command_SelectRace(object? param)
        {
            if (param != null && param is FormulaScheduleViewModel selectedRace)
            {
                SelectedRace = selectedRace;
                OnSelectedRace();
                FormulaRace();
            }
        }
        private void Command_SelectRecipe(object? param)
        {
            if(param != null && param is GastronomySearchViewModel selectRecipe)
            {
                SelectedRecipe = selectRecipe;
                GetGastronomyRecipe();
                OnSelectedRecipe();
  
            }
        }
        private void Command_Formula(object? param)
        {
            FormulaSeason();
            OnFormulaLoaded();
        }
        private void Command_Weather(object? param)
        {
            OnWeatherLoaded();
        }
        private void Command_Spotify(object? param)
        {
            OnSpotifyLoaded();
        }
        private void Command_Gastronomy(object? param)
        {
            OnGastronomyLoaded();
        }
        #endregion

        #region private method
        private void OnWeatherLoaded() => WeatherLoaded?.Invoke(this, EventArgs.Empty);
        private void OnFormulaLoaded() => FormulaLoaded?.Invoke(this, EventArgs.Empty);
        private void OnSpotifyLoaded() => SpotifyLoaded?.Invoke(this, EventArgs.Empty);
        private void OnGastronomyLoaded() => GastronomyLoaded?.Invoke(this, EventArgs.Empty);
        private void OnSelectedSeason() => SeasonSelected?.Invoke(this, EventArgs.Empty);
        private void OnSelectedRace() => RaceSelected?.Invoke(this, EventArgs.Empty);
        private void OnSelectedRecipe() => RecipeSelected?.Invoke(this, EventArgs.Empty);
        #endregion
    }
}
