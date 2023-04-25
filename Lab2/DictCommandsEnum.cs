using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUIL
{
    public enum DictCommandsEnum
    {
        InvokeAuthorsWrite,
        InvokeBooksWrite,
        InvokeClientsWrite,
        InvokeCo_AuthorWrite,
        InvokeGenresWrite,
        InvokeSubscriptionsWrite,
        ShowAuthorReader,
        ShowBookReader,
        ShowClientReader,
        ShowCo_AuthorReader,
        ShowGenreReader,
        ShowSubscriptionReader,
        ShowAuthorDeserialize,
        ShowBookDeserialize,
        ShowClientDeserialize,
        ShowCo_AuthorDeserialize,
        ShowGenreDeserialize,
        ShowSubscriptionDeserialize,
        ShowGetInnerJoin,
        ShowSelectClientsByCategory,
        ShowGetAllBooksByClient,
        ShowGetFullAmountOfBook,
        ShowGetBooksByGenres,
        ShowGetBoolAllBooksWithSpecificAmount,
        ShowGetClientsWithSkipedIndex,
        GetSortedOldestTakenBooks,
        ShowGetAvgRentProfit,
        ShowGetRentedBooksInRange,
        ShowGetPercentOfCategoryClients,
        ShowGetAllBooksStartedWithChar,
        ShowGetJoinBooksGenres,
        ShowGetClientsWithOutRent,
        ShowGetMaxCollateralValue

    }
}
