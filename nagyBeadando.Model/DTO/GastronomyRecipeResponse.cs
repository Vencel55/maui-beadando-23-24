using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando.Model.DTO
{
    public class GastronomyRecipeResponse
    {
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public bool VeryHealthy { get; set; }
        public bool Sustainable { get; set; }
        public List<GastronomyIngredients>? ExtendedIngredients { get; set; }
        public string? Instructions { get; set; }
    }
}
