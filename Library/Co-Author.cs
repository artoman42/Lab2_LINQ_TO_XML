using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Co_Author:Object<Co_Author>
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public override string ToString()
        {
            return $"{BookId} {AuthorId}";
        }
    }
}
