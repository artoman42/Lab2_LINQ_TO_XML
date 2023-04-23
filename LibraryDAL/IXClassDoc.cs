using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryDAL
{
    public interface IXClassDoc
    {
        public XDocument GetXDoc(string FileName);

    }


}
