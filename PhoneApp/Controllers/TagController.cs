using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly HRContext _db;

        public TagController(HRContext db)
        {
            _db = db;
        }

        [HttpGet("contactId/{contactId}")]
        public IActionResult Get(int contactId)
        {
            var contact = _db.Contacts.Where(x => x.Id == contactId).Include(x => x.ContactTag).ThenInclude(x => x.Tag).SingleOrDefault();
            var tags = contact.ContactTag.Select(x=> new Tag { Id = x.TagId, Value = x.Tag.Value}).ToList();
            return Ok(tags);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactTags = _db.ContactTags.Where(x => x.TagId == id).ToList();
            _db.ContactTags.RemoveRange(contactTags);
            var tagToDelete = _db.Tags.SingleOrDefault(x => x.Id == id); 
            _db.Tags.Remove(tagToDelete);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _db.Tags.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Tag model)
        {
            if (string.IsNullOrEmpty(model.Value)) return Ok();
            if (_db.Tags.Any(x => x.Value.ToLower() == model.Value)) return Ok();
            _db.Tags.Add(model);
            _db.SaveChanges();
            return Ok();
        }
    }
}
