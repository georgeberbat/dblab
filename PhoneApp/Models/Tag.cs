using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApp.Models
{
    [Table("Tag")]
    public class Tag : BaseModel
    {
        public int Id { get; set; }
        public virtual IEnumerable<ContactTag> ContactTag { get; set; }
    }
}
