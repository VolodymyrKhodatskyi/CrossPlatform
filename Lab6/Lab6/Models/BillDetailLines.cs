using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class BillDetailLines
    {
        [Key]
        public int BillDetailLineId { get; set; }

        [ForeignKey("BillHeaders")]
        public int BillHeaderId { get; set; }
        [ForeignKey("CustomerPhoneCalls")]
        public int PhoneCallId { get; set; }
        [ForeignKey("Tariffs")]
        public int TariffId { get; set; }
        public int CallDuration { get; set; }
        public int CallCost { get; set; }
        public Tariffs Tariffs { get; set; }
        public BillHeaders BillHeaders { get; set; }
        public CustomerPhoneCalls CustomerPhoneCalls { get; set; }

    }
}
