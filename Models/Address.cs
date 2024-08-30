using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinic_management_dotnet.Models
{
    [Table("T_CM_ADDRESS")]
    public class Address
    {
        [Key]
        [Column("id_address")]
        public int Id { get; set; }

        [Column("nm_street")]
        public required string Street { get; set; }

        [Column("nr_address")]
        public required string AddressNumber { get; set; }

        [Column("ds_neighborhood")]
        public required string Neighborhood { get; set; }

        [Column("ds_city")]
        public required string City { get; set; }

        [Column("ds_state")]
        public required string State { get; set; }

        [Column("nr_postal_code")]
        public required string PostalCode { get; set; }
    }
}
