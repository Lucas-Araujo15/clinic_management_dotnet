namespace clinic_management_dotnet.Dtos.Address
{
    public class CreateAddressDTO
    {
        public required string Street { get; set; }
        public required string AddressNumber { get; set; }
        public required string Neighborhood { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
    }
}
