using clinic_management_dotnet.Dtos.Address;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_ADDRESS")]
    public class AddressModel
    {
        [Key]
        [Column("id_address")]
        public int Id { get; set; }

        [Column("nm_street")]
        public string Street { get; set; }

        [Column("nr_address")]
        public string AddressNumber { get; set; }

        [Column("ds_neighborhood")]
        public string Neighborhood { get; set; }

        [Column("ds_city")]
        public string City { get; set; }

        [Column("ds_state")]
        public string State { get; set; }

        [Column("nr_postal_code")]
        public string PostalCode { get; set; }

        public AddressModel(CreateAddressDTO dto)
        {
            Street = dto.Street;
            AddressNumber = dto.AddressNumber;
            Neighborhood = dto.Neighborhood;
            City = dto.City;
            State = dto.State;
            PostalCode = dto.PostalCode;
        }

        public AddressModel() { }

        public void UpdateInformation(UpdateAddressDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Street))
            {
                Street = dto.Street;
            }

            if (!string.IsNullOrWhiteSpace(dto.AddressNumber))
            {
                AddressNumber = dto.AddressNumber;
            }

            if (!string.IsNullOrWhiteSpace(dto.Neighborhood))
            {
                Neighborhood = dto.Neighborhood;
            }

            if (!string.IsNullOrWhiteSpace(dto.City))
            {
                City = dto.City;
            }

            if (!string.IsNullOrWhiteSpace(dto.State))
            {
                State = dto.State;
            }

            if (!string.IsNullOrWhiteSpace(dto.PostalCode))
            {
                PostalCode = dto.PostalCode;
            }
        }
    }
}
