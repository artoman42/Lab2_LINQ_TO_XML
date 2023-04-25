using Library;
using Library.enums;
using LibraryBLL.QeuryHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL
{
    public interface IQueries
    {
        public IEnumerable<HelpClassInnerJoinClientSubscription> GetInnerJoin();
        public IEnumerable<HelpClassFindClientsByCategory> SelectClientsByCategory(Categories category = Categories.Student);
        public Dictionary<string, List<Book>> GetAllBooksByClient();
        public int GetFullAmountOfBook();
        public IEnumerable<HelpClassGroupJoinBookGenre> GetBooksByGenres();
        public bool GetBoolAllBooksWithSpecificAmount(int amount = 5);
        public IEnumerable<Client> GetClientsWithSkipedIndex(int index = 2);

        public IEnumerable<HelpClassSortedBooks> GetSortedOldestTakenBooks();
        public decimal GetAvgRentProfit();
        public IEnumerable<Book> GetRentedBooksInRange(int begin = -3, int end = 3);
        public decimal GetPercentOfCategoryClients(Categories category = Categories.Student);
        public IEnumerable<string> GetAllBooksStartedWithChar(char a = 'Е');
        public IEnumerable<HelpClassJoinBookGenres> GetJoinBooksGenres();
        public IEnumerable<Client> GetClientsWithOutRent();
        public decimal GetMaxCollateralValue();
        public Client GetClientFirstHaveLuckyNumber(string number = "666");
    }
}
