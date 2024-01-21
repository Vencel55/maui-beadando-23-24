using GyorsHir.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.ViewModel
{
    public class GastronomySearchViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }

        public DelegateCommand SelectCommand { get; set; }

        public GastronomySearchViewModel(Model.DTO.GastronomySearchResult result,DelegateCommand command)
        {
            Id = result.Id;
            Title = result.Title;
            Image = result.Image;
            SelectCommand = command;
        }
    }
}
