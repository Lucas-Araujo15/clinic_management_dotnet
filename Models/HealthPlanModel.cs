using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_HEALTH_PLAN")]
    public class HealthPlanModel
    {
        [Key]
        [Column("id_health_plan")]
        public int Id { get; set; }

        [Column("ds_name")]
        public required string Name { get; set; }

        [Column("cod_plan")]
        public required string PlanCode { get; set; }

        [Column("ds_coverage")]
        public required string Coverage { get; set; }

        public required ICollection<PatientHealthPlanModel> PatientHealthPlans { get; set; }
    }
}
