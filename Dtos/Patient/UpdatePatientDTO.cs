using clinic_management_dotnet.Dtos.Address;

namespace clinic_management_dotnet.Dtos.Patient
{
    public class UpdatePatientDTO
    {
        public string? Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }
        public UpdateAddressDTO? Address { get; set; }
    }
}
