using clinic_management_dotnet.Models;

namespace clinic_management_dotnet.Dtos.HealthPlan
{
    public class HealthPlanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlanCode { get; set; }
        public string Coverage { get; set; }

        public HealthPlanDTO(HealthPlanModel model)
        {
            Id = model.Id;
            Name = model.Name;
            PlanCode = model.PlanCode;
            Coverage = model.Coverage;
        }

        public HealthPlanDTO() { }
    }
}
