using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class CustomerPhoneCalls
    {
        [Key]
        public int PhoneCallId { get; set; }

        [ForeignKey("CustomerPhoneNumbers")]
        public int CustomerPhoneNumber { get; set; }
        [ForeignKey("RefNumberCalledTypes")]
        public int NumberCalledTypeCode { get; set; }
        public int NumberCalled { get; set; }
        public DateTime CallStartDatetime { get; set; }
        public DateTime CallEndDatetime { get; set; }
        public string OtherDetails { get; set; }
        public ICollection<BillDetailLines> BillDetailLines { get; set; }
        public RefNumberCalledTypes RefNumberCalledTypes { get; set; }
        public CustomerPhoneNumbers CustomerPhoneNumbers { get; set; }
    }
}
