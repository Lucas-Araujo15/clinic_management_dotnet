using clinic_management_dotnet.Models;

namespace clinic_management_dotnet.Dtos.Address
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string AddressNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public AddressDTO(AddressModel model)
        {
            Street = model.Street;
            AddressNumber = model.AddressNumber;
            Neighborhood = model.Neighborhood;
            City = model.City;
            State = model.State;
            PostalCode = model.PostalCode;
        }

        public AddressDTO() { }
    }
}
