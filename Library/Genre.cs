using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.enums;

namespace Library
{
    public class Genre:Object<Genre>
    {
        public Genres pGenre { get; set; }

        public override string ToString()
        {
            return pGenre.ToString();
        }
    }
}
