using clinic_management_dotnet.Dtos.Address;
using clinic_management_dotnet.Models;
using System.ComponentModel.DataAnnotations;

namespace clinic_management_dotnet.Dtos.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public AddressDTO Address { get; set; }

        public PatientDTO(PatientModel model)
        {
            Id = model.Id;
            Name = model.Name;
            DateOfBirth = model.DateOfBirth;
            Cpf = model.Cpf;
            Phone = model.Phone;
            Address = new AddressDTO(model.Address);
        }
    }
}
