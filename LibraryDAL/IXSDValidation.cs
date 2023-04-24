using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace LibraryDAL
{
    public interface IXSDValidation
    {
        public XmlSchemaSet schemaSet { get; }
        public void MyValidationEventHandler(object o, ValidationEventArgs vea);
        public bool MakeValidation(string fileName);

    }
}
