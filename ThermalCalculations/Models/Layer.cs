namespace ThermalCalculations.Models
{
    public class Layer
    {
        public string Name { get; set; }

        // d [ m ] - parameter
        public decimal ThicknessInMeters { get; set; }

        // lambda [ W/mK ] - parameter
        public decimal ThermalConductivity { get; set; }

        // mi [ - ]
        public decimal DiffusionResistance { get; set; }

    }
}
