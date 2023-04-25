using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Options;

namespace LibraryDAL
{
    public  class XClassDoc : IXClassDoc
    {
        private readonly DALConfiguration _config;
        private string path;
        public XClassDoc(IOptions<DALConfiguration> config)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;
        }

        public XDocument GetXDoc<T>()
        {
            
            return XDocument.Load(path + typeof(T).Name + "s.xml");
            
        }

    }
}
