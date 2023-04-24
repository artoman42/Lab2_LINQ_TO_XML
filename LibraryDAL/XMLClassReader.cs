using Library;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
namespace LibraryDAL
{
    public class XMLClassReader : IXMLClassReader
    {
        private readonly DALConfiguration _config;
        private string path;
        public XMLClassReader(IOptions<DALConfiguration> config)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;

        }
        public IEnumerable<Author> AuthorReader(string FileName) { 
            List<Author> authors = new List<Author>() { };
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path + FileName);
            XmlNode root = xmlDocument.DocumentElement;
     
            foreach(XmlNode node in root.ChildNodes)
            {
                int Id;
                string Name;
                bool success = int.TryParse(node["Id"].InnerText, out Id);
                Name = node["Name"].InnerText;
                if (success)
                {
                    authors.Add(new Author() { Id = Id, Name = Name });
                }
                else
                {
                    Console.WriteLine("Bad File !");
                }

                
            }
            
            return authors;
        }
        public IEnumerable<Book> BookReader(string FileName)
        {
            List<Book> Books = new List<Book>() { };
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path + FileName);
            XmlNode root = xmlDocument.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                int Id, GenreId = 0, Amount = 0;
                decimal CollateralValue = 0;
                string Name;
                bool success = int.TryParse(node["Id"].InnerText, out Id) 
                    && int.TryParse(node["GenreId"].InnerText, out GenreId)
                    && decimal.TryParse(node["CollateralValue"].InnerText, out CollateralValue)
                    && int.TryParse(node["Amount"].InnerText, out Amount);
                Name = node["Name"].InnerText;
                if (success)
                {
                    Books.Add(new Book() {
                        Id = Id,
                        Name = Name,
                        GenreId = GenreId,
                        CollateralValue = CollateralValue,
                        Amount = Amount });
                }
                else
                {
                    Console.WriteLine("Bad File !");
                }


            }

            return Books;
        }

        public IEnumerable<Client> ClientReader(string FileName)
        {
            List<Client> Clients = new List<Client>() { };
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path + FileName);
            XmlNode root = xmlDocument.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                int Id;
                string FullName, Adress, Phone, category;
                Library.enums.Categories Category =0;
                FullName = node["FullName"].InnerText;
                Adress = node["Adress"].InnerText;
                Phone = node["Phone"].InnerText;
                category = node["Category"].InnerText;
                bool success = int.TryParse(node["Id"].InnerText, out Id)
                    && Enum.TryParse(category, out Category);
                if (success)
                {
                    Clients.Add(new Client()
                    {
                        Id = Id,
                        FullName = FullName,
                        Adress = Adress,
                        Phone = Phone,
                        Category = Category

                    });
                }
                else
                {
                    Console.WriteLine("Bad File !");
                }

            }

            return Clients;
        }
        public IEnumerable<Co_Author> Co_AuthorReader(string FileName)
        {
            List<Co_Author> Co_Authors = new List<Co_Author>() { };
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path + FileName);
            XmlNode root = xmlDocument.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                int Id, BookId = 0, AuthorId = 0;
                bool success = int.TryParse(node["Id"].InnerText, out Id)
                    && int.TryParse(node["BookId"].InnerText, out BookId)
                    && int.TryParse(node["AuthorId"].InnerText, out AuthorId);
                if (success)
                {
                    Co_Authors.Add(new Co_Author()
                    {
                        Id = Id,
                        BookId = BookId,
                        AuthorId = AuthorId

                    });
                }
                else
                {
                    Console.WriteLine("Bad File !");
                }

            }

            return Co_Authors;
        }
        public IEnumerable<Genre> GenreReader(string FileName)
        {
            List<Genre> Genres = new List<Genre>() { };
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path + FileName);
            XmlNode root = xmlDocument.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                int Id;
                Library.enums.Genres Genre = 0;
                bool success = int.TryParse(node["Id"].InnerText, out Id)
                    && Enum.TryParse(node["pGenre"].InnerText, out Genre);
                if (success)
                {
                    Genres.Add(new Genre()
                    {
                        Id = Id,
                        pGenre = Genre

                    });
                }
                else
                {
                    Console.WriteLine("Bad File !");
                }

            }

            return Genres;
        }
        public IEnumerable<Subscription> SubscriptionReader(string FileName)
        {
            List<Subscription> Subscriptions = new List<Subscription>() { };
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path + FileName);
            XmlNode root = xmlDocument.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                int Id, ClientId = 0, BookId = 0;
                DateTime DateOfIssue = DateTime.MinValue, ExpectedReturnDate = DateTime.UtcNow;
                bool success = int.TryParse(node["Id"].InnerText, out Id)
                    && int.TryParse(node["ClientId"].InnerText, out ClientId)
                    && int.TryParse(node["BookId"].InnerText, out BookId)
                    && DateTime.TryParse(node["DateOfIssue"].InnerText, out DateOfIssue)
                    && DateTime.TryParse(node["ExpectedReturnDate"].InnerText, out ExpectedReturnDate);
                if (success)
                {
                    Subscriptions.Add(new Subscription()
                    {
                        Id = Id,
                        ClientId = ClientId,
                        BookId = BookId,
                        DateOfIssue = DateOfIssue,
                        ExpectedReturnDate = ExpectedReturnDate


                    });
                }
                else
                {
                    Console.WriteLine("Bad File !");
                }

            }

            return Subscriptions;
        }
    }
}