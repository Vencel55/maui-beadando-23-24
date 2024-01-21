namespace nagyBeadando.ViewModel
{
    public class FormulaRaceViewModel
    {
        public string? Number { get; set; }
        public string? Position { get; set; }
        public string? Points { get; set; }
        public string? Grid { get; set; }
        public string? DriverId { get; set; }
        public string? DriverCode { get; set; }
        public string? Time { get; set; }

        public string? Firstrow => $"Position:{Position}, Driver: {Number} {DriverId}({DriverCode}), Points: +{Points}";
        public string? Secondrow => $"Started from:{Grid}, Time:{Time}";

        public FormulaRaceViewModel(Model.DTO.formulaRaceResults results)
        {
            Number = results.Number;
            Position = results.Position;
            Points = results.Points;
            Grid = results.Grid;
            if(results.Driver != null)
            {
                DriverId = results.Driver.DriverId;
                DriverCode = results.Driver.Code;
            }
            try
            {
                if (results.Time != null && results.Time.Time != null)
                {
                    Time = results.Time.Time;
                }
                else
                {
                    Time = "DNF";
                }
            }
            catch
            {
                Time = "DNF";
            }

        }
    }
}
