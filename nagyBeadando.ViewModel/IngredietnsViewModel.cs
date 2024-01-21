using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.ViewModel
{
    public class IngredietnsViewModel
    {
        public string? Aisle { get; set; }
        public string? Original { get; set; }

        public IngredietnsViewModel(Model.DTO.GastronomyIngredients ingredients)
        {
            Aisle = ingredients.Aisle;
            Original = ingredients.Original;
        }
    }
}
