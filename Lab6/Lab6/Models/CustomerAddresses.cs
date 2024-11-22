using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CustomerAddresses
    {
        [Key]
        public int CustomerAddressId { get; set; }

        [ForeignKey("Addresses")]
        public int AddressId { get; set; }
        [ForeignKey("RefAddressTypes")]
        public int AddressTypeCode { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public DateTime DateAddressFrom { get; set; }
        public DateTime DateAddressTo { get; set; }
        public Customers Customers { get; set; }
        public RefAddressTypes RefAddressTypes { get; set; }
        public Addresses Addresses { get; set; }
    }
}
