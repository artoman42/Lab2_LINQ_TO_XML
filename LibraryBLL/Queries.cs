﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Library;
using Library.enums;
using LibraryBLL.QeuryHelperClasses;
using LibraryDAL;
using Microsoft.Extensions.Primitives;

namespace LibraryBLL
{

    public class Queries : IQueries
    {
        private readonly IXClassDoc _xClassDoc;
        public Queries(IXClassDoc xClassDoc)
        {
            _xClassDoc = xClassDoc;
        }
        public IEnumerable<HelpClassInnerJoinClientSubscription> GetInnerJoin()
        {
            string name = new Client().GetPropertyName(x => x.FullName);
            string dateOfIssue = new Subscription().GetPropertyName(x => x.DateOfIssue);
            string expectedReturnDate = new Subscription().GetPropertyName(x => x.ExpectedReturnDate);
            string id = typeof(Client).GetIdName();
            string clientId = new Subscription().GetPropertyName(x => x.ClientId);

            return  from c in _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>()
                   from s in _xClassDoc.GetXDoc(typeof(Subscription)).GetElements<Subscription>()
                   where c.Element(id).ParseValue<int>() == s.Element(clientId).ParseValue<int>()
                   select new HelpClassInnerJoinClientSubscription
                   {
                       Name = c.Element(name).Value,
                       DateOfIssue = DateTime.Parse(s.Element(dateOfIssue).Value),
                       ExpectedReturnDate = DateTime.Parse(s.Element(expectedReturnDate).Value)
                       
                   };
        }
        public IEnumerable<HelpClassFindClientsByCategory> SelectClientsByCategory(Categories category = Categories.Student)
        {
            string _category = new Client().GetPropertyName(x => x.Category);
            string name = new Client().GetPropertyName(x => x.FullName);

            return from c in _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>()
                   where c.Element(_category).ParseValue<Categories>() == category
                   select new HelpClassFindClientsByCategory()
                   {
                       Name = c.Element(name).Value,
                       Category = c.Element(_category).ParseValue<Categories>()
                   };

        }
        public Dictionary<string, List<Book>> GetAllBooksByClient()
        {
            string _bookId = typeof(Book).GetIdName();
            string _clientId = typeof(Client).GetIdName();
            string bookId = new Subscription().GetPropertyName(x => x.BookId);
            string clientId = new Subscription().GetPropertyName(x => x.ClientId);
            string fullName = new Client().GetPropertyName(x => x.FullName);

            return _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>()
                .GroupJoin(_xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                            .Join(_xClassDoc.GetXDoc(typeof(Subscription)).GetElements<Subscription>(),
                                  c => c.Element(_bookId).ParseValue<int>(),
                                  cb => cb.Element(bookId).ParseValue<int>(),
                                  (c, cb) => new {
                                      ClientId = cb.Element(clientId).ParseValue<int>(),
                                      BookItem = c
                                  }),
                                  b => b.Element(_clientId).ParseValue<int>(),
                                  bc => bc.ClientId,
                                  (b, books) => new
                                  {
                                      ClientName = b.Element(fullName).Value,
                                      Books = books.Select(c => c.BookItem.ParseValue<Book>()).ToList()
                                  })
                .Where(c => c.Books.Count() != 0)
                .ToDictionary(x => x.ClientName, x => x.Books);
        }
        public int GetFullAmountOfBook()
        {
            string amount = new Book().GetPropertyName(x => x.Amount);
            return _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                .Aggregate(0, (sum, a) => sum + a.Element(amount).ParseValue<int>());
        }
        public IEnumerable<HelpClassGroupJoinBookGenre> GetBooksByGenres()
        {
            string _genreId = typeof(Genre).GetIdName();
            string genreId = new Book().GetPropertyName(x => x.GenreId);
            string pGenre = new Genre().GetPropertyName(x => x.pGenre);
            return _xClassDoc.GetXDoc(typeof(Genre)).GetElements<Genre>()
                .GroupJoin(_xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>(),
                    g => g.Element(_genreId).ParseValue<int>(),
                    b => b.Element(genreId).ParseValue<int>(),
                    (b, g) => new HelpClassGroupJoinBookGenre
                    {
                        Genre = b.Element(pGenre).ParseValue<Genres>(),
                        Books = g.Select(x => new Book()
                        {
                            Id = x.Element(typeof(Book).GetIdName()).ParseValue<int>(),
                            Amount = x.Element(new Book().GetPropertyName(c => c.Amount)).ParseValue<int>(),
                            CollateralValue = x.Element(new Book().GetPropertyName(d => d.CollateralValue)).ParseValue<decimal>(),
                            GenreId = x.Element(new Book().GetPropertyName(g => g.GenreId)).ParseValue<int>(),
                            Name = x.Element(new Book().GetPropertyName(b => b.Name)).Value


                        }).ToList()
                    }
                ) ;
        }
        public bool GetBoolAllBooksWithSpecificAmount(int amount = 5)
        {
            string _amount = new Book().GetPropertyName(x => x.Amount);
            return _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                .All(x => x.Element(_amount).ParseValue<int>() >= amount);
        }
        public IEnumerable<Client> GetClientsWithSkipedIndex(int index = 2)
        {

            return _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>()
                .Skip(index)
                .Select(x =>  new Client()
                {
                    Id = x.Element(typeof(Client).GetIdName()).ParseValue<int>(),
                    Adress = x.Element(new Client().GetPropertyName(x=>x.Adress)).Value,
                    Category = x.Element(new Client().GetPropertyName(x => x.Category)).ParseValue<Categories>(),
                    FullName = x.Element(new Client().GetPropertyName(x => x.FullName)).Value,
                    Phone = x.Element(new Client().GetPropertyName(x => x.Phone)).Value
                });
        }
        public IEnumerable<HelpClassSortedBooks> GetSortedOldestTakenBooks()
        {
            string dateOfIssue = new Subscription().GetPropertyName(x => x.DateOfIssue);
            string name = new Book().GetPropertyName(x => x.Name);
            string _bookId = typeof(Book).GetIdName();
            string bookId = new Subscription().GetPropertyName(x => x.BookId);
            return from b in _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                   join s in _xClassDoc.GetXDoc(typeof(Subscription)).GetElements<Subscription>()
                   on b.Element(typeof(Book).GetIdName()).ParseValue<int>() 
                   equals s.Element(bookId).ParseValue<int>()
                   orderby s.Element(dateOfIssue).ParseValue<DateTime>()
                   select new HelpClassSortedBooks()
                   {
                       DateOfIssue = s.Element(dateOfIssue).ParseValue<DateTime>(),
                       Name = b.Element(name).Value
                   };
        }
        public decimal GetAvgRentProfit()
        {
            string _bookId = typeof(Book).GetIdName();
            string bookId = new Subscription().GetPropertyName(x => x.BookId);
            var t = from b in _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                    join s in _xClassDoc.GetXDoc(typeof(Subscription)).GetElements<Subscription>()
                    on b.Element(_bookId).ParseValue<int>()
                    equals s.Element(bookId).ParseValue<int>()
                    select new Subscription()
                    {
                        Id = s.Element(typeof(Subscription).GetIdName()).ParseValue<int>(),
                        BookId = s.Element(bookId).ParseValue<int>(),
                        ClientId = s.Element(new Subscription().GetPropertyName(x => x.ClientId)).ParseValue<int>(),
                        DateOfIssue = s.Element(new Subscription().GetPropertyName(x => x.DateOfIssue)).ParseValue<DateTime>(),
                        ExpectedReturnDate = s.Element(new Subscription().GetPropertyName(x => x.ExpectedReturnDate)).ParseValue<DateTime>()
                    };
            return t.Average(x => x.RentalPrice);
        }
        public IEnumerable<Book> GetRentedBooksInRange(int begin = -3, int end = 3)
        {
            string _bookId = typeof(Book).GetIdName();
            string bookId = new Subscription().GetPropertyName(x => x.BookId);
            string dateOfIssue = new Subscription().GetPropertyName(x => x.DateOfIssue);
            return from b in _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                   join s in _xClassDoc.GetXDoc(typeof(Subscription)).GetElements<Subscription>()
                   on b.Element(_bookId).ParseValue<int>()
                   equals s.Element(bookId).ParseValue<int>()
                   where s.Element(dateOfIssue).ParseValue<DateTime>() >= DateTime.Now.AddMonths(begin)
                   && s.Element(dateOfIssue).ParseValue<DateTime>() <= DateTime.Now.AddMonths(end)
                   select new Book()
                   {
                       Id = b.Element(_bookId).ParseValue<int>(),
                       Amount = b.Element(new Book().GetPropertyName(c => c.Amount)).ParseValue<int>(),
                       CollateralValue = b.Element(new Book().GetPropertyName(d => d.CollateralValue)).ParseValue<decimal>(),
                       GenreId = b.Element(new Book().GetPropertyName(g => g.GenreId)).ParseValue<int>(),
                       Name = b.Element(new Book().GetPropertyName(b => b.Name)).Value


                   };
        }
        public decimal GetPercentOfCategoryClients(Categories category = Categories.Student)
        {
            string _category = new Client().GetPropertyName(x => x.Category);
            var list = from c in _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>()
                       where c.Element(_category).ParseValue<Categories>() == category
                       select new Client
                       {
                           Id = c.Element(typeof(Client).GetIdName()).ParseValue<int>(),
                           Adress = c.Element(new Client().GetPropertyName(x => x.Adress)).Value,
                           Category = c.Element(_category).ParseValue<Categories>(),
                           FullName = c.Element(new Client().GetPropertyName(x => x.FullName)).Value,
                           Phone = c.Element(new Client().GetPropertyName(x => x.Phone)).Value
                       };
            return (decimal)list.Count() / _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>().Count() * 100M;
        }//11
        public IEnumerable<string> GetAllBooksStartedWithChar(char a = 'Е')
        {
            string name = new Book().GetPropertyName(x => x.Name);

            return from b in _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                   where b.Element(name).Value[0] == a
                   select b.Element(name).Value;
        }
        public IEnumerable<HelpClassJoinBookGenres> GetJoinBooksGenres()
        {
            string genreId = new Book().GetPropertyName(x => x.GenreId);
            string _genreId = typeof(Genre).GetIdName();
            return _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>()
                .Join(_xClassDoc.GetXDoc(typeof(Genre)).GetElements<Genre>(),
                b => b.Element(genreId).ParseValue<int>(),
                g => g.Element(_genreId).ParseValue<int>(),
                (b, g) => new HelpClassJoinBookGenres
                {
                    Name = b.Element(new Book().GetPropertyName(x => x.Name)).Value,
                    Genre = g.Element(new Genre().GetPropertyName(x => x.pGenre)).ParseValue<Genres>()
                }
                );
        }
        public IEnumerable<Client> GetClientsWithOutRent()
        {
            string clientId = new Subscription().GetPropertyName(x => x.ClientId);
            string _clientId = typeof(Client).GetIdName();
            return from c in _xClassDoc.GetXDoc(typeof(Client)).GetElements<Client>()
                   where !(from s in _xClassDoc.GetXDoc(typeof(Subscription)).GetElements<Subscription>()
                           select s.Element(clientId).ParseValue<int>())
                           .Contains(c.Element(_clientId).ParseValue<int>())
                   select new Client()
                   {
                       Id = c.Element(_clientId).ParseValue<int>(),
                       Adress = c.Element(new Client().GetPropertyName(x => x.Adress)).Value,
                       Category = c.Element(new Client().GetPropertyName(x =>x.Category)).ParseValue<Categories>(),
                       FullName = c.Element(new Client().GetPropertyName(x => x.FullName)).Value,
                       Phone = c.Element(new Client().GetPropertyName(x => x.Phone)).Value
                   };

        }
        public decimal GetMaxCollateralValue()
        {
            string collateralValue = new Book().GetPropertyName(x => x.CollateralValue);
            return _xClassDoc.GetXDoc(typeof(Book)).GetElements<Book>().Max(
                x => x.Element(collateralValue).ParseValue<decimal>());
        }

    }
}
