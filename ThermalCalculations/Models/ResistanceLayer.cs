namespace ThermalCalculations.Models
{
    public class ResistanceLayer : Layer
    {
        // R [(m^2K)/W]
        public decimal Resistance { get; set; }

        // Sd [m]
        public decimal VapourPermeability { get; set; }
    }
}
