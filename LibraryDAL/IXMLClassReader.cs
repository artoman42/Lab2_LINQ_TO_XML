using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public interface IXMLClassReader
    {
        public IEnumerable<Author> AuthorReader(string FileName);
        public IEnumerable<Book> BookReader(string FileName);
        public IEnumerable<Client> ClientReader(string FileName);
        public IEnumerable<Co_Author> Co_AuthorReader(string FileName);
        public IEnumerable<Genre> GenreReader(string FileName);
        public IEnumerable<Subscription> SubscriptionReader(string FileName);

    }
}
