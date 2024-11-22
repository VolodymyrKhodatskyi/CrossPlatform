using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefCustomerNumberTypes
    {
        [Key]
        public int CustomerNumberTypeCode { get; set; }
        public string NumberTypeDescription { get; set; }
        public ICollection<CustomerPhoneNumbers> CustomerPhoneNumbers { get; set; }
    }
}
