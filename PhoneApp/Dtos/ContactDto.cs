using PhoneApp.Models;

namespace PhoneApp.Dtos;

public class ContactDto
{
    public int Id { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public string Street { get; set; }
        
    public string City { get; set; }

    public string Phone { get; set; }
        
    public string Email { get; set; }
    public ContactTag ContactTag { get; set; }
}