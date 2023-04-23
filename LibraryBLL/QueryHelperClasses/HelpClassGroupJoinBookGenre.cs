using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.enums;
using Library;
namespace LibraryBLL.QeuryHelperClasses
{
    public class HelpClassGroupJoinBookGenre
    {
        public Genres Genre { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
