using clinic_management_dotnet.Dtos.Address;

namespace clinic_management_dotnet.Dtos.Patient
{
    public class CreatePatientDTO
    {
        public required string Name { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string Cpf { get; set; }
        public required string Phone { get; set; }
        public required CreateAddressDTO Address { get; set; }
    }
}
