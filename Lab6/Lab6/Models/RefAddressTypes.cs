using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefAddressTypes
    {
        [Key]
        public int AddressTypeCode { get; set; }
        public string AddressTypeDescription { get; set; }
        public ICollection<CustomerAddresses> CustomerAddresses { get; set; }

    }
}
