namespace clinic_management_dotnet.Dtos.PatientHealthPlan
{
    public class CreatePatientHealthPlanDTO
    {
        public required int PatientId { get; set; }
        public required int HealthPlanId { get; set; }
    }
}
