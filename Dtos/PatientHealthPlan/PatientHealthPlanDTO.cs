using clinic_management_dotnet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using clinic_management_dotnet.Dtos.Patient;
using clinic_management_dotnet.Dtos.HealthPlan;

namespace clinic_management_dotnet.Dtos.PatientHealthPlan
{
    public class PatientHealthPlanDTO
    {
        public int Id { get; set; }
        public PatientDTO Patient { get; set; }
        public HealthPlanDTO HealthPlan { get; set; }
        public DateTime AccessionDate { get; set; }

        public PatientHealthPlanDTO(PatientHealthPlanModel model)
        {
            Id = model.Id;
            Patient = new PatientDTO(model.Patient);
            HealthPlan = new HealthPlanDTO(model.HealthPlan);
            AccessionDate = model.AccessionDate;
        }

        public PatientHealthPlanDTO() { }
    }
}
