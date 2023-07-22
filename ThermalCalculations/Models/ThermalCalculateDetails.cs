namespace ThermalCalculations.Models
{
    public class ThermalCalculateDetails
    {
        public Location Location { get; set; }

        public Project Project { get; set; }

        public List<Layer> PartitionSystem { get; set; }

        // Rsi [(m^2K)/W]
        public decimal InternalHeatResisatnce { get; set; }

        // Rse [(m^2K)/W]
        public decimal ExternalHeatResisatnce { get; set; }


    }
}
