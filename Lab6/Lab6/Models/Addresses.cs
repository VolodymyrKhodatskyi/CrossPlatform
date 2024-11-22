using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public int ZipPostcode { get; set; }
        public string StateProvinceCountry { get; set; }
        public string Country { get; set; }
        public string OtherDetails { get; set; }
        public ICollection<CustomerAddresses> CustomerAddresses { get; set; }
    }
}
