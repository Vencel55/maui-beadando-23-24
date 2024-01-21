using GyorsHir.ViewModel;

namespace nagyBeadando.ViewModel
{
    public class FomulaSeasonsViewModel : BindingSource
    {
        public string Season { get; set; }

        public DelegateCommand SelectCommand { get; set; }

        public FomulaSeasonsViewModel(Model.DTO.formulaSeasonResult result, DelegateCommand selectCommand)
        {
            Season = result.Season;
            SelectCommand = selectCommand;
        }
    }
}
