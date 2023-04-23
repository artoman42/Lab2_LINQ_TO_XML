using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryDAL
{
    public  class XClassDoc : IXClassDoc
    {
        public string path = "D:\\KPI\\.NET\\Lab2\\Library\\XMLDocs\\";

        public XDocument GetXDoc(string FileName)
        {
            XDocument doc = XDocument.Load(path + FileName);
            return doc;
        }

    }
}
