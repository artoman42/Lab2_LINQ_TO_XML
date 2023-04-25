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
        private readonly IXSDValidation _xSDValidation;
        private string path;
        public XClassDoc(IOptions<DALConfiguration> config, IXSDValidation xSDValidation)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;
            _xSDValidation = xSDValidation;
        }

        public XDocument GetXDoc<T>()
        {
            XDocument doc = XDocument.Load(path + typeof(T).Name + "s.xml");
            if (_xSDValidation.MakeValidation(typeof(T).Name + "s.xml"))
            return doc;
            else
            {
                return new XDocument();
            }
        }

    }
}
