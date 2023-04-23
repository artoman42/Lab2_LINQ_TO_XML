using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
namespace LibraryBLL.QeuryHelperClasses
{
    public class BookQualityComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book b1, Book b2)
        {
            return b1.Name!.CompareTo(b2.Name) == 0;
        }
        public int GetHashCode(Book b)
        {
            return b.Name.GetHashCode();
        }
    }
}
