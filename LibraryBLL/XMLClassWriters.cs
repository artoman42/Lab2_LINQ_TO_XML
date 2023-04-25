using Library;
using LibraryBLL.Validators;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Xml;
using FluentValidation;
using FluentValidation.Results;
using Library.enums;

namespace LibraryBLL
{
    public class XMLClassWriters : IXMLClassWriters
    {
        private readonly BLLConfiguration _config;
        private readonly IValidator<Author> _authorValidator;
        private readonly IValidator<Book> _bookValidator;
        private readonly IValidator<Client> _clientValidator;
        private readonly IValidator<Co_Author> _co_authorValidator;
        private readonly IValidator<Genre> _genreValidator;
        private readonly IValidator<Subscription> _subscriptionValidator;
        private string path;
        public XMLClassWriters(IOptions<BLLConfiguration> config, IValidator<Author> authorValidator,
            IValidator<Book> bookValidator, IValidator<Client> clientValidator,
            IValidator<Co_Author> co_authorValidator, IValidator<Genre> genreValidator,
            IValidator<Subscription> subscriptionValidator)
        {
            _config = config.Value;
            path = _config.XMLDocsFolder;
            _authorValidator = authorValidator;
            _bookValidator = bookValidator;
            _clientValidator = clientValidator;
            _co_authorValidator = co_authorValidator;
            _genreValidator = genreValidator;
            _subscriptionValidator = subscriptionValidator;
        }
        public void AuthorsWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Authors");

                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Author");
                    Console.WriteLine("Enter Author Id:");
                    int authorId;
                    while (!int.TryParse(Console.ReadLine(), out authorId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }

                    Console.WriteLine("Enter Author Name:");
                    string authorName = Console.ReadLine();

                    Author author = new Author { Id = authorId, Name = authorName };

                    ValidationResult results = _authorValidator.Validate(author);

                    if (!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine("Validation Error: {0}", failure.ErrorMessage);
                        }

                        i--;
                        continue;
                    }

                    xmlWriter.WriteStartElement("Id");
                    xmlWriter.WriteString(author.Id.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("Name", author.Name);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }
        public void BooksWrite(string FileName, int amount)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(path + FileName, settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Books");


                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Book");
                    Console.WriteLine("Enter Book Id:");
                    int bookId;
                    while (!int.TryParse(Console.ReadLine(), out bookId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    Console.WriteLine("Enter Book Name:");
                    string bookName = Console.ReadLine();
                    Console.WriteLine("Enter Genre Id:");
                    int genreId;
                    while (!int.TryParse(Console.ReadLine(), out genreId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    Console.WriteLine("Enter Collateral Value:");
                    decimal collateralValue;
                    while (!decimal.TryParse(Console.ReadLine(), out collateralValue))
                    {
                        Console.WriteLine("Invalid input. Please enter an decimal.");
                    }
                    Console.WriteLine("Enter Amount:");
                    int amountValue;
                    while (!int.TryParse(Console.ReadLine(), out amountValue))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }

                    Book book = new Book { Id = bookId, Name = bookName, GenreId = genreId, CollateralValue = collateralValue, Amount = amountValue };

                    ValidationResult results = _bookValidator.Validate(book);

                    if (!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine("Validation Error: {0}", failure.ErrorMessage);
                        }
                        i--;
                        continue;
                    }

                    xmlWriter.WriteElementString("Id", book.Id.ToString());
                    xmlWriter.WriteElementString("Name", book.Name);
                    xmlWriter.WriteElementString("GenreId", book.GenreId.ToString());
                    xmlWriter.WriteElementString("CollateralValue", book.CollateralValue.ToString());
                    xmlWriter.WriteElementString("Amount", book.Amount.ToString());

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
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Clients");

                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Client");

                    Console.WriteLine("Enter Client Id:");
                    int clientId;
                    while (!int.TryParse(Console.ReadLine(), out clientId))
                    {
                        Console.WriteLine("Invalid input. Please enter an Categories.");
                    }
                    Console.WriteLine("Enter Client Full Name:");
                    string clientFullName = Console.ReadLine();

                    Console.WriteLine("Enter Client Address:");
                    string clientAdress = Console.ReadLine();

                    Console.WriteLine("Enter Client Phone:");
                    string clientPhone = Console.ReadLine();

                    Console.WriteLine("Enter Client Category:");
                    Categories clientCategory;
                    while (!Enum.TryParse(Console.ReadLine(), out clientCategory))
                    {
                        Console.WriteLine("Invalid input. Please enter an Categories.");
                    }
                    Client client = new Client
                    {
                        Id = clientId,
                        FullName = clientFullName,
                        Adress = clientAdress,
                        Phone = clientPhone,
                        Category = clientCategory
                    };

                    ValidationResult results = _clientValidator.Validate(client);

                    if (!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine("Validation Error: {0}", failure.ErrorMessage);
                        }

                        i--;
                        continue;
                    }

                    xmlWriter.WriteElementString("Id", client.Id.ToString());
                    xmlWriter.WriteElementString("FullName", client.FullName);
                    xmlWriter.WriteElementString("Adress", client.Adress);
                    xmlWriter.WriteElementString("Phone", client.Phone);
                    xmlWriter.WriteElementString("Category", client.Category.ToString());

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
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Сo_Authors");

                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Co_Author");

                    Console.WriteLine("Enter Co_Author Id:");
                    int co_AuthorId;
                    while (!int.TryParse(Console.ReadLine(), out co_AuthorId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }

                    Console.WriteLine("Enter BookId:");
                    int bookId;
                    while (!int.TryParse(Console.ReadLine(), out bookId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }

                    Console.WriteLine("Enter AuthorId:");
                    int authorId;
                    while (!int.TryParse(Console.ReadLine(), out authorId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    Co_Author co_Author = new Co_Author { Id = co_AuthorId, BookId = bookId, AuthorId = authorId };

                    ValidationResult results = _co_authorValidator.Validate(co_Author);

                    if (!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine("Validation Error: {0}", failure.ErrorMessage);
                        }

                        i--;
                        continue;
                    }

                    xmlWriter.WriteElementString("Id", co_Author.Id.ToString());
                    xmlWriter.WriteElementString("BookId", co_Author.BookId.ToString());
                    xmlWriter.WriteElementString("AuthorId", co_Author.AuthorId.ToString());

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
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Genres");

                for (int i = 0; i < amount; i++)
                {
                    xmlWriter.WriteStartElement("Genre");

                    Console.WriteLine("Enter Genre Id:");
                    int genreId;
                    while (!int.TryParse(Console.ReadLine(), out genreId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    Console.WriteLine("Enter pGenre:");
                    Genres pGenre;
                    while (!Enum.TryParse(Console.ReadLine(), out pGenre))
                    {
                        Console.WriteLine("Invalid input. Please enter an Genres.");
                    }
                    Genre genre = new Genre()
                    {
                        Id = genreId,
                        pGenre = pGenre
                    };
                    ValidationResult results = _genreValidator.Validate(genre);

                    if (!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine(failure.ErrorMessage);
                        }
                        i--; 
                        continue;
                    }

                    xmlWriter.WriteElementString("Id", genre.Id.ToString());
                    xmlWriter.WriteElementString("pGenre", genre.pGenre.ToString());

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
                    int subscriptionId;
                    while (!int.TryParse(Console.ReadLine(), out subscriptionId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    
                    Console.WriteLine("Enter ClientId:");
                    int clientId;
                    while (!int.TryParse(Console.ReadLine(), out clientId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    
                    Console.WriteLine("Enter BookId:");
                    int bookId;
                    while (!int.TryParse(Console.ReadLine(), out bookId))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    
                    Console.WriteLine("Enter DateOfIssue(YYYY-MM-DDTHH:MM:SSZ):");
                    DateTime dateOfIssue;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-ddTHH:mm:ssZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfIssue))
                    {
                        Console.WriteLine("Invalid input. Please enter an \"yyyy-MM-ddTHH:mm:ssZ\".");
                    }
                    

                    Console.WriteLine("Enter ExpectedReturnDate(YYYY-MM-DDTHH:MM:SSZ):");
                    DateTime expectedReturnDate;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-ddTHH:mm:ssZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out expectedReturnDate))
                    {
                        Console.WriteLine("Invalid input. Please enter an \"yyyy-MM-ddTHH:mm:ssZ\".");
                    }
                    
                    Subscription subscription = new Subscription()
                    {
                        Id = subscriptionId,
                        ClientId = clientId,
                        BookId = bookId,
                        DateOfIssue = dateOfIssue,
                        ExpectedReturnDate = expectedReturnDate
                    };
                    ValidationResult results = _subscriptionValidator.Validate(subscription);

                    if(!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine(failure.ErrorMessage);
                        }
                        i--;
                        continue;
                    }
                    xmlWriter.WriteElementString("Id", subscription.Id.ToString());
                    xmlWriter.WriteElementString("ClientId", subscription.ClientId.ToString());
                    xmlWriter.WriteElementString("BookId", subscription.BookId.ToString());
                    xmlWriter.WriteElementString("DateOfIssue", subscription.DateOfIssue.ToString());
                    xmlWriter.WriteElementString("ExpectedReturnDate", subscription.DateOfIssue.ToString());
                    
                    xmlWriter.WriteEndElement();

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

        }
        
    }
}