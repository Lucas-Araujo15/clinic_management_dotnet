using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_PATIENT_HEALTH_PLAN")]
    public class PatientHealthPlanModel
    {
        [Key]
        [Column("id_patient_health_plan")]
        public int Id { get; set; }

        [ForeignKey("id_patient")]
        public required PatientModel Patient { get; set; }

        [ForeignKey("id_health_plan")]
        public required HealthPlanModel HealthPlan { get; set; }

        [Column("dt_accession")]
        public required DateTime AccessionDate { get; set; }

    }
}
