using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Services;

public class ContactService : IContactService
{
    private readonly HRContext _context;

    public ContactService(HRContext context)
    {
        _context = context;
    }

    public async Task AddContact(Contact contactDto)
    {
        _context.Contacts.Add(contactDto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContact(Contact contact)
    {
        var exContact = _context.Contacts.SingleOrDefault(x => x.Id == contact.Id);
        var existingPhones = await _context.Phones
            .AsQueryable()
            .Where(x => x.ContactId == contact.Id)
            .ToArrayAsync();
        
        var phonesToDelete = existingPhones.Except(exContact.Phone).ToArray();
        _context.Phones.RemoveRange(phonesToDelete);
        
        exContact!.FirstName = contact.FirstName;
        exContact.LastName = contact.LastName;
        exContact.City = contact.City;
        exContact.Street = contact.Street;
        exContact.Email = contact.Email;
        exContact.Phone = contact.Phone;
        _context.Contacts.Update(exContact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContactTags(Contact contact)
    {
        foreach (var tag in contact.ContactTag)
        {
            if (!_context.ContactTags.Any(x => x.ContactId == contact.Id && x.TagId == tag.TagId))
            {
                _context.ContactTags.Add(tag);
            }
        }
        
        await _context.SaveChangesAsync();
    }
}