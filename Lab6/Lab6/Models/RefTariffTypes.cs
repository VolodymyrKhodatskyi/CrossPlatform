using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefTariffTypes
    {
        [Key]
        public int TariffTypeCode { get; set; }
        public string TariffTypeDescription { get; set; }
        public ICollection<Tariffs> Tariffs { get; set; }
    }
}
