using Library.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUIL
{
    public interface ICommands
    {
        
        public void ShowValue<T>(T value);
        public void ShowList<T>(IEnumerable<T> list);
        public void ShowDictionaryWithList<T1, T2>(Dictionary<T1, List<T2>> dict);

        public void ShowAuthorReader(string fileName);
        public void ShowBookReader(string fileName);
        public void ShowClientReader(string fileName);
        public void ShowCo_AuthorReader(string fileName);
        public void ShowGenreReader(string fileName);
        public void ShowSubscriptionReader(string fileName);
        public void ShowAuthorDeserialize(string fileName);
        public void ShowBookDeserialize(string fileName);
        public void ShowClientDeserialize(string fileName);
        public void ShowCo_AuthorDeserialize(string fileName);
        public void ShowGenreDeserialize(string fileName);
        public void ShowSubscriptionDeserialize(string fileName);
        public void ShowInnerJoin();
        public void ShowSelectClientsByCategory(Categories category);
        public void ShowGetAllBooksByClient();
        public void ShowGetFullAmountOfBook();
        public void ShowGetBooksByGenres();
        public void ShowGetBoolAllBooksWithSpecificAmount(int amount = 5);
        public void ShowGetClientsWithSkipedIndex(int index = 2);
        public void GetSortedOldestTakenBooks();
        public void ShowGetAvgRentProfit();
        public void ShowGetRentedBooksInRange(int begin = -3, int end = 3);
        public void ShowGetPercentOfCategoryClients(Categories category = Categories.Student);
        public void ShowGetAllBooksStartedWithChar(char a = 'Е');
        public void ShowGetJoinBooksGenres();
        public void ShowGetClientsWithOutRent();
        public void ShowGetMaxCollateralValue();

    }
}
