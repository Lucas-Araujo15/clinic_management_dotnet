using clinic_management_dotnet.Dtos.Patient;
using clinic_management_dotnet.Models;

namespace clinic_management_dotnet.Dtos.PatientHealthPlan
{
    public class PatientsOfAHealthPlanDTO
    {
        public int Id { get; set; }

        public PatientDTO Patient { get; set; }

        public DateTime AccessionDate { get; set; }

        public PatientsOfAHealthPlanDTO(PatientHealthPlanModel model)
        {
            Id = model.Id;
            AccessionDate = model.AccessionDate;
            Patient = new PatientDTO(model.Patient);
        }

        public PatientsOfAHealthPlanDTO() { }
    }
}
