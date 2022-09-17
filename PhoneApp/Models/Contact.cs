using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApp.Models
{
    [Table("Contact")]
    public class Contact
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Street { get; set; }
        
        public string City { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public virtual IEnumerable<Phone> Phone { get; set; }
        public virtual IEnumerable<ContactTag> ContactTag { get; set; }
    }
}
