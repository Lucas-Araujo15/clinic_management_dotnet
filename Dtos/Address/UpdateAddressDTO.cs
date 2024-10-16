﻿namespace clinic_management_dotnet.Dtos.Address
{
    public class UpdateAddressDTO
    {
        public string? Street { get; set; }
        public string? AddressNumber { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
}
