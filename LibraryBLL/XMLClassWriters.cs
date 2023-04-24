using Microsoft.Extensions.Options;
using System.Globalization;
using System.Xml;

namespace LibraryBLL
{
    public class XMLClassWriters : IXMLClassWriters
    {
        private readonly BLLConfiguration _config;
        private string path;
        public XMLClassWriters(IOptions<BLLConfiguration> config)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;
        }
        public void AuthorsWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true; 
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings)) {
                string s;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Authors");
                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Author");
                    Console.WriteLine("Enter Author Id:");
                    s = Console.ReadLine();
                    xmlWriter.WriteStartElement("Id");
                    xmlWriter.WriteString(s);
                    xmlWriter.WriteEndElement();
                    Console.WriteLine("Enter Author Name:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Name", s);
                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

        }

        public void BooksWrite(string FileName, int amount) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                string s;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Books");
                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Book");
                    Console.WriteLine("Enter Book Id:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Id", s);
                    Console.WriteLine("Enter Book Name:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Name", s);
                    Console.WriteLine("Enter GenreId:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("GenreId", s);
                    Console.WriteLine("Enter Collateral Value:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("CollateralValue", s);
                    Console.WriteLine("Enter Amount:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Amount", s);

                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }


        }

        public void ClientsWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                string s;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Clients");
                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Client");
                    Console.WriteLine("Enter Client Id:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Id", s);
                    Console.WriteLine("Enter Client Full Name:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("FullName", s);
                    Console.WriteLine("Enter Client Adress:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Adress", s);
                    Console.WriteLine("Enter Client Phone:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Phone", s);
                    Console.WriteLine("Enter Client Category:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Category", s);
                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }


        }
        public void Co_AuthorWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                string s;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Сo_Authors");
                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Co_Author");
                    Console.WriteLine("Enter Сo_Author Id:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Id", s);
                    Console.WriteLine("Enter BookId:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("BookId", s);
                    Console.WriteLine("Enter AuthorId:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("AuthorId", s);

                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

        }
        public void GenresWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                string s;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Genres");
                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Genre");
                    Console.WriteLine("Enter Genre Id:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Id", s);
                    Console.WriteLine("Enter pGenre:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("pGenre", s);

                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

        }

        public void SubscriptionsWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                string s;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Subscriptions");
                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Subscription");
                    Console.WriteLine("Enter Subscription Id:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("Id", s);
                    Console.WriteLine("Enter ClientId:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("ClientId", s);
                    Console.WriteLine("Enter BookId:");
                    s = Console.ReadLine();
                    xmlWriter.WriteElementString("BookId", s);
                    Console.WriteLine("Enter DateOfIssue(YYYY-MM-DDTHH:MM:SSZ):");
                    s = Console.ReadLine();
                    if (IsValidDateFormat(s))
                    {
                        xmlWriter.WriteElementString("DateOfIssue", s);
                    }
                    else
                    {
                        Console.WriteLine("Bad format!Try Again! And will be set today");
                        s = DateTime.Now.ToString("s",CultureInfo.GetCultureInfo("en-US"));
                        xmlWriter.WriteElementString("DateOfIssue", s);
                    }
                    Console.WriteLine("Enter ExpectedReturnDate(YYYY-MM-DDTHH:MM:SSZ):");
                    s = Console.ReadLine();
                    if (IsValidDateFormat(s))
                    {
                        xmlWriter.WriteElementString("ExpectedReturnDate", s);
                    }
                    else
                    {
                        Console.WriteLine("Bad format!Try Again! And will be set today");
                        s = DateTime.Now.ToString("s", CultureInfo.GetCultureInfo("en-US"));
                        xmlWriter.WriteElementString("ExpectedReturnDate", s);
                    }
                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

        }
        public static bool IsValidDateFormat(string input)
        {
            DateTime output;
            return DateTime.TryParseExact(input, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
        }
    }
}