using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Tariffs
    {
        [Key]
        public int TariffId { get; set; }
        
        [ForeignKey("RefTariffTypes")]
        public int TariffTypeCode { get; set; }
        public string TariffName { get; set; }
        public string TariffRate { get; set; }
        public string Otherdetails { get; set; }
        public RefTariffTypes RefTariffTypes { get; set; }
        public ICollection<BillDetailLines> BillDetailLines { get; set; }
    }
}
