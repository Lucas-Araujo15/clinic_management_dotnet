using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_PATIENT")]
    public class Patient
    {
        [Key]
        [Column("id_patient")]
        public int Id { get; set; }

        [Column("ds_name")]
        public required string Name { get; set; }

        [Column("dt_birth")]
        public required DateOnly DateOfBirth { get; set; }

        [Column("nr_cpf")]
        public required string Cpf { get; set; }

        [Column("nr_phone")]
        public required string Phone { get; set; }

        [ForeignKey("id_address")]
        public required Address Address { get; set; }

        [ForeignKey("id_health_plan")]
        public required HealthPlan HealthPlan { get; set; }
    }
}
