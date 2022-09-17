using System.ComponentModel.DataAnnotations.Schema;
using PhoneApp.Dtos;

namespace PhoneApp.Models;

[Table("Phones")]
public class Phone
{
    public int Id { get; set; }
    public string Value { get; set; }
    public PhoneType PhoneType { get; set; }
    public int ContactId { get; set; }
    [ForeignKey("ContactId")]
    public Contact Contact { get; set; }
}