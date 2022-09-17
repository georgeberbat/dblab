using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApp.Models
{
    [Table("ContactTag")]
    public class ContactTag
    {
        public int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }
        public int TagId { get; set; }
        public Tag  Tag { get; set; }
    }
}
