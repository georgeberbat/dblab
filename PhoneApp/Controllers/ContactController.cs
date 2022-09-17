using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;
using PhoneApp.Services;

namespace PhoneApp.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly HRContext db;
        private readonly IContactService _contactService;

        public ContactController(HRContext context, IContactService contactService)
        {
            db = context;
            _contactService = contactService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await db.Contacts.ToListAsync();
            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await db.Contacts.Include(x => x.Phone).Include(x => x.ContactTag).SingleOrDefaultAsync(x => x.Id == id);
            return Ok(contact);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            if (contact.Id == 0)
            {
                await _contactService.AddContact(contact);
            }
            else
            {
                await _contactService.UpdateContact(contact);
            }

            await _contactService.UpdateContactTags(contact);
            return Ok(contact.Id);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var contact = db.Contacts.Where(x => x.Id == id).SingleOrDefault();
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return Ok();
        }
    }
}
