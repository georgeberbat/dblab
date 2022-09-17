using PhoneApp.Models;

namespace PhoneApp.ViewModel
{
    public class SearchVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
