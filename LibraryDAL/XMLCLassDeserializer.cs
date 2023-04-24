using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Library;
using Microsoft.Extensions.Options;

namespace LibraryDAL
{
    public class XMLCLassDeserializer : IXMLClassDeserializer
    {
        private readonly DALConfiguration _config;
        private string path;
        public XMLCLassDeserializer(IOptions<DALConfiguration> config)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;

        }
        public IEnumerable<Author> AuthorDeserialize(string FileName)
        {
            List<Author> Authors = new List<Author>();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Authors";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Author>),xmlRoot);
            using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
            {
                Authors = (List<Author>)serializer.Deserialize(fs);
                //serializer.Deserialize(fs) as List<Author>;
            }
            return Authors;
        }

        public IEnumerable<Book> BookDeserialize(string FileName)
        {
            List<Book> Books = new List<Book>();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Books";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), xmlRoot);
            using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
            {
                Books = (List<Book>)serializer.Deserialize(fs);
            }
            return Books;
        }

        public IEnumerable<Client> ClientDeserialize(string FileName)
        {
            List<Client> Clients = new List<Client>();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Clients";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>), xmlRoot);
            using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
            {
                Clients = (List<Client>)serializer.Deserialize(fs);
            }
            return Clients;
        }
        public IEnumerable<Co_Author> Co_AuthorDeserialize(string FileName)
        {
            List<Co_Author> Co_Authors = new List<Co_Author>();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Сo_Authors";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Co_Author>), xmlRoot);
            using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
            {
                Co_Authors = (List<Co_Author>)serializer.Deserialize(fs);
            }
            return Co_Authors;
        }

        public IEnumerable<Genre> GenreDeserialize(string FileName)
        {
            List<Genre> Genres = new List<Genre>();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Genres";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Genre>), xmlRoot);
            using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
            {
                Genres = (List<Genre>)serializer.Deserialize(fs);
            }
            return Genres;
        }
        public IEnumerable<Subscription> SubscriptionDeserialize(string FileName)
        {
            List<Subscription> Subscriptions = new List<Subscription>();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "Subscriptions";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Subscription>), xmlRoot);
            using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
            {
                Subscriptions = (List<Subscription>)serializer.Deserialize(fs);
            }
            return Subscriptions;
        }
    }
}
