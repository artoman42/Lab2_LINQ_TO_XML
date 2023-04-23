using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL
{
    public interface IXMLClassWriters
    {
        public void AuthorsWrite(string FileName, int amount);
        public void BooksWrite(string FileName, int amount);
        public void ClientsWrite(string FileName, int amount);
        public void Co_AuthorWrite(string FileName, int amount);
        public void GenresWrite(string FileName, int amount);
        public void SubscriptionsWrite(string FileName, int amount);

    }
}
