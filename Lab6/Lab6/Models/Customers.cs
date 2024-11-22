using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CommercialOrDomestic { get; set; }
        public string OtherCustomerDetails { get; set; }
        public ICollection<CustomerPhoneNumbers> CustomerPhoneNumbers { get; set; }
        public ICollection<CustomerAddresses> CustomerAddresses { get; set; }
    }
}
