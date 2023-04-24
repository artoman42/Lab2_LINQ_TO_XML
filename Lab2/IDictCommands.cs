using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUIL
{
    public interface IDictCommands
    {
        public void Load();
        public void Invoke(string s, string[] param);
    }
}
