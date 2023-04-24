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
        private readonly IXSDValidation _xSDValidation;
        private string path;
        public XMLCLassDeserializer(IOptions<DALConfiguration> config, IXSDValidation xSDValidation)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;
            _xSDValidation = xSDValidation;
        }
        public IEnumerable<Author> AuthorDeserialize(string FileName)
        {
                List<Author> Authors = new List<Author>();
                XmlRootAttribute xmlRoot = new XmlRootAttribute();
                xmlRoot.ElementName = "Authors";
                XmlSerializer serializer = new XmlSerializer(typeof(List<Author>), xmlRoot);
                using (FileStream fs = new FileStream(path + FileName, FileMode.Open))
                {
                    Authors = serializer.Deserialize(fs) as List<Author>;
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
                Books = serializer.Deserialize(fs) as List<Book>;
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
                Clients = serializer.Deserialize(fs) as List<Client>;
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
                Co_Authors = serializer.Deserialize(fs) as List<Co_Author>;
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
                Genres = serializer.Deserialize(fs) as List<Genre>;
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
                Subscriptions = serializer.Deserialize(fs) as List<Subscription>;
            }
            return Subscriptions;
        }
    }
}
