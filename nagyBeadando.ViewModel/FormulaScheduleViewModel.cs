using GyorsHir.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.ViewModel
{
    public class FormulaScheduleViewModel : BindingSource
    {
        public string? Season { get; set; }
        public string? Round { get; set; }
        public string? RaceName { get; set; }
        public string? Date { get; set; }

        public string? Text => $"Season:{Season}, Round:{Round}";
        public string? Details => $"{RaceName}, {Date}";
        public DelegateCommand? SelectCommand { get; set; }

        public FormulaScheduleViewModel(Model.DTO.formulaScheduleResult result, DelegateCommand command)
        {
            Season = result.Season;
            Round = result.Round;
            RaceName = result.RaceName;
            Date = result.Date;
            SelectCommand = command;
        }
    }
}
