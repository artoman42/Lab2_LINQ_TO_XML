using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Linq;
namespace LibraryDAL
{
    public class XSDValidation : IXSDValidation
    {
        private readonly DALConfiguration _config;
        private readonly IXClassDoc _xClassDoc;
        private string path;
        private XmlSchemaSet _schemaSet = new XmlSchemaSet();
        public XmlSchemaSet schemaSet
        {
            get { return _schemaSet; }
        }
        public XSDValidation(IOptions<DALConfiguration> config, IXClassDoc xClassDoc)
        {
            _config = config.Value;
            path = _config.XSDSchemesFolder;
            string[] fileNames = Directory.GetFiles(path, "*.xsd");
            if (fileNames.Count() != 0)
            {
                foreach (string file in fileNames)
                {
                    _schemaSet.Add(null, file);
                }
            }
            else
            {
                Console.WriteLine("Bad files!");
            }
            _xClassDoc = xClassDoc;
        }
        public void MyValidationEventHandler(object o, ValidationEventArgs vea)
        {
            //TODO string plus change
           
            throw (new XmlSchemaValidationException(vea.Message));
        }
        public bool MakeValidation( string fileName)
        {
            try
            {
                XDocument xDocument = new XDocument(); 
                xDocument = _xClassDoc.GetXDoc(fileName);
                xDocument.Validate(schemaSet, MyValidationEventHandler);
                return true;
            }
            catch (XmlSchemaValidationException ex)
            {
                Console.WriteLine("Exception:   {0}", ex.Message);
                Console.WriteLine("Validation failed.");
                return false;
            }
        }
    }
}
