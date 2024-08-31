using clinic_management_dotnet.Dtos.Patient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_PATIENT")]
    [Index(nameof(Cpf), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    public class PatientModel
    {
        [Key]
        [Column("id_patient")]
        public int Id { get; set; }

        [Column("ds_name")]
        public string Name { get; set; }

        [Column("dt_birth")]
        public DateOnly DateOfBirth { get; set; }

        [Column("nr_cpf")]
        public string Cpf { get; set; }

        [Column("nr_phone")]
        public string Phone { get; set; }

        [ForeignKey("id_address")]
        public AddressModel Address { get; set; }

        public ICollection<PatientHealthPlanModel>? PatientHealthPlans { get; set;}

        public PatientModel(CreatePatientDTO dto)
        {
            Name = dto.Name;
            DateOfBirth = dto.DateOfBirth;
            Cpf = dto.Cpf;
            Phone = dto.Phone;
            Address = new AddressModel(dto.Address);
        }

        public PatientModel() { }

        public void UpdateInformation(UpdatePatientDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                Name = dto.Name;
            }

            if (dto.DateOfBirth != null)
            {
                DateOfBirth = (DateOnly) dto.DateOfBirth;
            }

            if (!string.IsNullOrWhiteSpace(dto.Cpf))
            {
                Cpf = dto.Cpf;
            }

            if (!string.IsNullOrWhiteSpace(dto.Phone))
            {
                Phone = dto.Phone;
            }

            if (dto.Address != null)
            {
                Address.UpdateInformation(dto.Address);
            }
        }
    }
}
