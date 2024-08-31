namespace clinic_management_dotnet.Dtos.HealthPlan
{
    public class CreateHealthPlanDTO
    {
        public required string Name { get; set; }
        public required string Coverage { get; set; }
    }
}
