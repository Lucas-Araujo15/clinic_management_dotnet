using clinic_management_dotnet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using clinic_management_dotnet.Dtos.HealthPlan;

namespace clinic_management_dotnet.Dtos.PatientHealthPlan
{
    public class HealthPlansOfAPatientDTO
    {
        public int Id { get; set; }

        public HealthPlanDTO HealthPlan { get; set; }

        public DateTime AccessionDate { get; set; }

        public HealthPlansOfAPatientDTO(PatientHealthPlanModel model)
        {
            Id = model.Id;
            AccessionDate = model.AccessionDate;
            HealthPlan = new HealthPlanDTO(model.HealthPlan);
        }

        public HealthPlansOfAPatientDTO() { }
    }
}
