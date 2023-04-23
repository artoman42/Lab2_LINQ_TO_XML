using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBLL.QeuryHelperClasses;
using LibraryDAL;
namespace LibraryBLL
{

    public class Queries : IQueries
    {
        private readonly IXClassDoc _xmlClassDoc;
        public Queries(IXClassDoc xmlClassDoc)
        {
            _xmlClassDoc = xmlClassDoc;
        }
        public IEnumerable<HelpClassInnerJoinClientSubscription> GetInnerJoin()
        {
            //name id
            return from c in _xmlClassDoc.GetXDoc("Clients.xml").Descendants("Сlient")
                   from s in _xmlClassDoc.GetXDoc("Subsctiptions.xml").Descendants("Subsctiprion")
                   where int.Parse(c.Element("Id").Value) == int.Parse(s.Element("ClientId").Value)
                   select new HelpClassInnerJoinClientSubscription
                   {
                       Name = c.Element("FullName").Value,
                       DateOfIssue = DateTime.Parse(s.Element("DateOfIssue").Value),
                       ExpectedReturnDate = DateTime.Parse(s.Element("ExpectedReturnDate").Value)
                       
                   };

        }
    }
}
