using clinic_management_dotnet.Dtos.HealthPlan;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_HEALTH_PLAN")]
    [Index(nameof(PlanCode), IsUnique = true)]
    public class HealthPlanModel
    {
        [Key]
        [Column("id_health_plan")]
        public int Id { get; set; }

        [Column("ds_name")]
        public string Name { get; set; }

        [Column("cod_plan")]
        public string PlanCode { get; set; }

        [Column("ds_coverage")]
        public string Coverage { get; set; }

        public ICollection<PatientHealthPlanModel>? PatientHealthPlans { get; set; }

        public HealthPlanModel(CreateHealthPlanDTO dto)
        {
            Name = dto.Name;
            PlanCode = Guid.NewGuid().ToString();
            Coverage = dto.Coverage;
        }

        public HealthPlanModel() { }

        public void UpdateInformation(UpdateHealthPlanDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                Name = dto.Name;
            }

            if (!string.IsNullOrWhiteSpace(dto.Coverage))
            {
                Coverage = dto.Coverage;
            }
        }
    }
}
