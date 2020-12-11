using System.Collections.Generic;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class Author
    {
        public IEnumerable<Contact> ContactsTyped => Contacts.OfType<Contact>();
    }
}