using LibraryBLL;
using LibraryBLL.QeuryHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;
using Library;
using Library.enums;

namespace LibraryUIL
{
    public class Commands : ICommands
    {
        private readonly IQueries _IQeuries;
        private readonly IXMLClassWriters _xMLClassWriters;
        private readonly IXMLClassDeserializer _xMLClassDeserializer;
        private readonly IXMLClassReader _xMLClassReader;
        private readonly IXSDValidation _xSDValidation;
        public Commands(IQueries queries, IXMLClassWriters xMLClassWriters,
            IXMLClassDeserializer xMLClassDeserializer, IXMLClassReader xMLClassReader,
            IXSDValidation xSDValidation)
        {
            _IQeuries = queries;
            _xMLClassWriters = xMLClassWriters;
            _xMLClassDeserializer = xMLClassDeserializer;
            _xMLClassReader = xMLClassReader;
            _xSDValidation = xSDValidation;
        }
        public void ShowValue<T>( T value)
        {
            Console.WriteLine(value);
        }

        public void ShowList<T>(IEnumerable<T> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ShowDictionaryWithList<T1, T2>(Dictionary<T1,List<T2>> dict){
            foreach(var item in dict)
            {
                Console.WriteLine(item);
                foreach(var item2 in item.Value)
                {
                    Console.WriteLine(item2);
                }
            }
        }
        public void ShowAuthorReader(string fileName) {
            ShowList<Author>(_xMLClassReader.AuthorReader(fileName));
        }
        public void ShowBookReader(string fileName)
        {
            ShowList<Book>(_xMLClassReader.BookReader(fileName));
        }
        public void ShowClientReader(string fileName)
        {
            ShowList<Client>(_xMLClassReader.ClientReader(fileName));
        }
        public void ShowCo_AuthorReader(string fileName)
        {
            ShowList<Co_Author>(_xMLClassReader.Co_AuthorReader(fileName));
        }
        public void ShowGenreReader(string fileName)
        {
            ShowList<Genre>(_xMLClassReader.GenreReader(fileName));
        }
        public void ShowSubscriptionReader(string fileName)
        {
            ShowList<Subscription>(_xMLClassReader.SubscriptionReader(fileName));
        }
        public void ShowAuthorDeserialize(string fileName)
        {
            ShowList<Author>(_xMLClassDeserializer.AuthorDeserialize(fileName));
        }
        public void ShowBookDeserialize(string fileName)
        {
            ShowList<Book>(_xMLClassDeserializer.BookDeserialize(fileName));
        }
        public void ShowClientDeserialize(string fileName)
        {
            ShowList<Client>(_xMLClassDeserializer.ClientDeserialize(fileName));
        }
        public void ShowCo_AuthorDeserialize(string fileName)
        {
            ShowList<Co_Author>(_xMLClassDeserializer.Co_AuthorDeserialize(fileName));
        }
        public void ShowGenreDeserialize(string fileName) 
        {
            ShowList<Genre>(_xMLClassDeserializer.GenreDeserialize(fileName));
        }
        public void ShowSubscriptionDeserialize(string fileName)
        {
            ShowList<Subscription>(_xMLClassDeserializer.SubscriptionDeserialize(fileName));
        }

        public void ShowInnerJoin()
        {
            var l = _IQeuries.GetInnerJoin();
            ShowList<HelpClassInnerJoinClientSubscription>(l);
        }
        public void ShowSelectClientsByCategory(Categories category)
        {
            ShowList<HelpClassFindClientsByCategory>(_IQeuries.SelectClientsByCategory(category));
        }
        public void ShowGetAllBooksByClient()
        {
            ShowDictionaryWithList<string, Book>(_IQeuries.GetAllBooksByClient());
        }
        public void ShowGetFullAmountOfBook()
        {
            ShowValue<int>(_IQeuries.GetFullAmountOfBook());
        }
        public void ShowGetBooksByGenres()
        {
            ShowList<HelpClassGroupJoinBookGenre>(_IQeuries.GetBooksByGenres());
        }
        public void ShowGetBoolAllBooksWithSpecificAmount(int amount = 5)
        {
            ShowValue<bool>(_IQeuries.GetBoolAllBooksWithSpecificAmount(amount));
        }
        public void ShowGetClientsWithSkipedIndex(int index = 2)
        {
            ShowList<Client>(_IQeuries.GetClientsWithSkipedIndex(index));    
        }
        public void GetSortedOldestTakenBooks()
        {
            ShowList<HelpClassSortedBooks>(_IQeuries.GetSortedOldestTakenBooks());  
        }
        public void ShowGetAvgRentProfit()
        {
            ShowValue<decimal>(_IQeuries.GetAvgRentProfit());
        }
        public void ShowGetRentedBooksInRange(int begin = -3, int end = 3)
        {
            ShowList<Book>(_IQeuries.GetRentedBooksInRange(begin, end));
        }
        public void ShowGetPercentOfCategoryClients(Categories category = Categories.Student)
        {
            ShowValue<decimal>(_IQeuries.GetPercentOfCategoryClients(category));
        }
        public void ShowGetAllBooksStartedWithChar(char a = 'Е')
        {
            ShowList<string>(_IQeuries.GetAllBooksStartedWithChar(a));
        }
        public void ShowGetJoinBooksGenres()
        {
            ShowList<HelpClassJoinBookGenres>(_IQeuries.GetJoinBooksGenres());
        }
        public void ShowGetClientsWithOutRent()
        {
            ShowList<Client>(_IQeuries.GetClientsWithOutRent());
        }
        public void ShowGetMaxCollateralValue()
        {
            ShowValue<decimal>(_IQeuries.GetMaxCollateralValue());
        }
        public void ShowGetClientFirstHaveLuckyNumber(string number = "666")
        {
            ShowValue<Client>(_IQeuries.GetClientFirstHaveLuckyNumber(number));
        }
    }
}
