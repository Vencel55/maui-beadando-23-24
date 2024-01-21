using nagyBeadando.Model.DTO;

namespace nagyBeadando.ViewModel
{
    public class GastronomyRecipeViewModel
    {
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public bool VeryHealthy { get; set; }
        public bool Sustainable { get; set; }
        public List<GastronomyIngredients>? ExtendedIngredients { get; set; }
        public string? Instructions { get; set; }

        public string VegetarianLabel => Vegetarian ? "Yes" : "No";
        public string VeganLabel => Vegan ? "Yes" : "No";
        public string GlutenFreeLabel => GlutenFree ? "Yes" : "No";
        public string DairyFreeLabel => DairyFree ? "Yes" : "No";
        public string VeryHealthyLabel => VeryHealthy ? "Yes" : "No";
        public string SustainableLabel => Sustainable ? "Yes" : "No";

        public GastronomyRecipeViewModel(GastronomyRecipeResponse response)
        {
            Vegetarian = response.Vegetarian;
            Vegan = response.Vegan;
            GlutenFree = response.GlutenFree;
            DairyFree = response.DairyFree;
            VeryHealthy = response.VeryHealthy;
            Sustainable = response.Sustainable;
            ExtendedIngredients = response.ExtendedIngredients;
            Instructions = response.Instructions;
        }
    }
}
