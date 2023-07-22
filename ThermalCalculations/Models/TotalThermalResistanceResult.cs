namespace ThermalCalculations.Models
{
    public class TotalThermalResistanceResult
    {
        public Location Location { get; set; }

        public Project Project { get; set; }

        public List<ResistanceLayer> PartitionLayerResistance { get; set; }  
        
        public decimal TotalResistance { get; set; }

        public decimal HeatTransferCoefficient { get; set; }

        public bool IsPartitionSystemCorrect { get; set; }
    }
}
