using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CustomerPhoneNumbers
    {
        [Key]
        public int CustomerPhoneNumber { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        [ForeignKey("RefCustomerNumberTypes")]
        public int CustomerNumberTypeCode { get; set; }
        public DateTime HeldFromDate { get; set; }
        public DateTime HeldToDate { get; set; }
        public string OtherDetails { get; set; }
        public Customers Customers { get; set; }
        public RefCustomerNumberTypes RefCustomerNumberTypes { get; set; }
        public ICollection<BillHeaders> BillHeaders { get; set; }
        public ICollection<CustomerPhoneCalls> CustomerPhoneCalls { get; set; }
    }
}
