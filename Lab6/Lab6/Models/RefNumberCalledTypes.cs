using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefNumberCalledTypes
    {
        [Key]
        public int NumberCalledTypeCode { get; set; }
        public string NumberCalledTypeDescription { get; set; }
        public ICollection<CustomerPhoneCalls> CustomerPhoneCalls { get; set; }
    }
}
