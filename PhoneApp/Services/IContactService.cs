using PhoneApp.Models;

namespace PhoneApp.Services;

public interface IContactService
{
    Task AddContact(Contact contactDto);
    Task UpdateContact(Contact contact);
    Task UpdateContactTags(Contact contact);
}