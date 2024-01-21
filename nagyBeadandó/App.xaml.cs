using nagyBeadando.Model;
using nagyBeadando.ViewModel;

namespace nagyBeadandó
{
    public partial class App : Application
    {
        private NavigationPage _rootPage;
        private nagyBeadandoModel _model;
        private nagyBeadandoViewModel _viewModel;
        public App()
        {
            InitializeComponent();
            _model = new nagyBeadandoModel();
            _viewModel = new nagyBeadandoViewModel(_model);
            _viewModel.FormulaLoaded += _viewModel_FormulaLoaded;
            _viewModel.WeatherLoaded += _viewModel_WeatherLoaded;
            _viewModel.SpotifyLoaded += _viewModel_SpotifyLoaded;
            _viewModel.GastronomyLoaded += _viewModel_GastronomyLoaded;
            _viewModel.SeasonSelected += _viewModel_SeasonSelected;
            _viewModel.RaceSelected += _viewModel_RaceSelected;
            _viewModel.RecipeSelected += _viewModel_RecipeSelected;

            _rootPage = new NavigationPage(new MainPage())
            {
                BindingContext = _viewModel
            };
            MainPage = _rootPage;
        }
        #region ViewModel Event
        private async void _viewModel_FormulaLoaded(object sender, EventArgs e)
        {
            if (_rootPage.CurrentPage is not FormulaPage)
            {
                await _rootPage.Navigation.PushAsync(new FormulaPage());
            }
        }
        private async void _viewModel_GastronomyLoaded(object sender, EventArgs e)
        {
            if (_rootPage.CurrentPage is not GastronomyPage)
            {
                await _rootPage.Navigation.PushAsync(new GastronomyPage());
            }
        }
        private async void _viewModel_SpotifyLoaded(object sender, EventArgs e)
        {
            if (_rootPage.CurrentPage is not SpotifyPage)
            {
                await _rootPage.Navigation.PushAsync(new SpotifyPage());
            }
        }
        private async void _viewModel_WeatherLoaded(object sender, EventArgs e)
        {
            if (!(_rootPage.CurrentPage is MainPage))
            {
                return;
            }
            await _rootPage.Navigation.PushAsync(new MainPage());
        }
        private async void _viewModel_SeasonSelected(object sender, EventArgs e)
        {
            if (_rootPage.CurrentPage is not FormulaSchedulePage)
            {
                await _rootPage.Navigation.PushAsync(new FormulaSchedulePage());
            }
            
        }
        private async void _viewModel_RaceSelected(object sender, EventArgs e)
        {
            if (_rootPage.CurrentPage is not FormulaRacePage)
            {
                await _rootPage.Navigation.PushAsync(new FormulaRacePage());
            }
        }
        private async void _viewModel_RecipeSelected(object sender, EventArgs e)
        {
            if (_rootPage.CurrentPage is not GastronomyRecipePage)
            {
                await _rootPage.Navigation.PushAsync(new GastronomyRecipePage());
            }
        }
        #endregion
    }
}
