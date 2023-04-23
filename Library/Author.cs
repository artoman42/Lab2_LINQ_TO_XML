using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Author:Object<Author>
    {
        public string Name { get; set; }

        
        public override string ToString()
        {
            return $"{Id} {Name} ";
        }
    }
}
