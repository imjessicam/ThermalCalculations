using Microsoft.AspNetCore.Mvc;
using ThermalCalculations.Models;

namespace ThermalCalculations.Controllers
{
    [ApiController]
    [Route("thermal/analysis")]
    public class ThermalAnalysisController : Controller
    {
        [HttpPost]
        [Route("calculate")]

        public IActionResult Calculate([FromBody] ThermalCalculateDetails model)
        {
            return Ok(model);
        }

        [HttpPost]
        [Route("calculate/resistance")]

        public IActionResult CalculateResistance([FromBody] ThermalCalculateDetails model)
        {
            var result = new TotalThermalResistanceResult();

            result.Location = model.Location;
            result.Project = model.Project;
            result.PartitionLayerResistance = new List<ResistanceLayer>();


            foreach (var layer in model.PartitionSystem)
            {
                var resistanceLayer = new ResistanceLayer();

                resistanceLayer.Name = layer.Name;
                resistanceLayer.ThicknessInMeters = layer.ThicknessInMeters;
                resistanceLayer.ThermalConductivity = layer.ThermalConductivity;
                resistanceLayer.DiffusionResistance = layer.DiffusionResistance;
                resistanceLayer.Resistance = layer.ThicknessInMeters / layer.ThermalConductivity;
                resistanceLayer.VapourPermeability = layer.ThicknessInMeters * layer.DiffusionResistance;

                result.PartitionLayerResistance.Add(resistanceLayer);
            }


            result.TotalResistance = result.PartitionLayerResistance.Select(x => x.Resistance).Sum() 
                + model.InternalHeatResisatnce 
                + model.ExternalHeatResisatnce;

            // value based of location
            const decimal MaxHeatTransferCoefficient = 0.2M;

            result.HeatTransferCoefficient = 1.0M / result.TotalResistance;
            result.IsPartitionSystemCorrect = result.HeatTransferCoefficient <= MaxHeatTransferCoefficient;

            return Ok(result);
        }
    }
}
