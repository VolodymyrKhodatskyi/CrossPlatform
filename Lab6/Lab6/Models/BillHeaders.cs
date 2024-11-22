using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class BillHeaders
    {
        [Key]
        public int BillHeaderId { get; set; }

        [ForeignKey("CustomerPhoneNumbers")]
        public int CustomerPhoneNumber { get; set; }
        public DateTime BillIssuedDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public int OriginalAmountDue { get; set; }
        public int AmountOutstanding { get; set; }
        public ICollection<BillDetailLines> BillDetailLines { get; set; }
        public CustomerPhoneNumbers CustomerPhoneNumbers { get; set; }
    }
}
