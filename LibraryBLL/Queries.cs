using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
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
            string name = typeof(Client).GetProperties().FirstOrDefault(x => x.Name.ToString() == "FullName")
                .Name.ToString();
            string id = typeof(Client).BaseType.GetProperties()[0].Name.ToString();
            // TODO id to method
            var l =  from c in _xmlClassDoc.GetXDoc("Clients.xml").Descendants("Client")
                   from s in _xmlClassDoc.GetXDoc("Subscriptions.xml").Descendants("Subscription")
                   where int.Parse(c.Element(id).Value) == int.Parse(s.Element("ClientId").Value)
                   select new HelpClassInnerJoinClientSubscription
                   {
                       Name = c.Element(name).Value,
                       DateOfIssue = DateTime.Parse(s.Element("DateOfIssue").Value),
                       ExpectedReturnDate = DateTime.Parse(s.Element("ExpectedReturnDate").Value)
                       
                   };
            //if (l.Count() == 0) return null;
            return l;
        }
    }
}
