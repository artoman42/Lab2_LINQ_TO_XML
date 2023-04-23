using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public interface IXMLClassDeserializer
    {
        public IEnumerable<Author> AuthorDeserialize(string FileName);
        public IEnumerable<Book> BookDeserialize(string FileName);
        public IEnumerable<Client> ClientDeserialize(string FileName);
        public IEnumerable<Co_Author> Co_AuthorDeserialize(string FileName);
        public IEnumerable<Genre> GenreDeserialize(string FileName);
        public IEnumerable<Subscription> SubscriptionDeserialize(string FileName);

    }
}
