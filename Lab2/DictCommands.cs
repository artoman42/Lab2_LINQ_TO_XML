using Library.enums;
using LibraryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUIL
{
    public class DictCommands : IDictCommands
    {
        private readonly ICommands _commands;
        private readonly IXMLClassWriters _writers;
        public DictCommands(ICommands commands, IXMLClassWriters xMLClassWriters)
        {
            _commands = commands;
            _writers = xMLClassWriters;
        }
        public Dictionary<DictCommandsEnum, Delegate> ActionDictionary = new Dictionary<DictCommandsEnum, Delegate>();
        public void Load()
        {
            ActionDictionary[DictCommandsEnum.InvokeAuthorsWrite] = new Action<string, int>(_writers.AuthorsWrite);
            ActionDictionary[DictCommandsEnum.InvokeBooksWrite] = new Action<string, int>(_writers.BooksWrite);
            ActionDictionary[DictCommandsEnum.InvokeClientsWrite] = new Action<string, int>(_writers.ClientsWrite);
            ActionDictionary[DictCommandsEnum.InvokeCo_AuthorWrite] = new Action<string, int>(_writers.Co_AuthorWrite);
            ActionDictionary[DictCommandsEnum.InvokeGenresWrite] = new Action<string, int>(_writers.GenresWrite);
            ActionDictionary[DictCommandsEnum.InvokeSubscriptionsWrite] = new Action<string, int>(_writers.SubscriptionsWrite);
            ActionDictionary[DictCommandsEnum.ShowAuthorReader] = new Action<string>(_commands.ShowAuthorReader);
            ActionDictionary[DictCommandsEnum.ShowBookReader] = new Action<string>(_commands.ShowBookReader);
            ActionDictionary[DictCommandsEnum.ShowClientReader] = new Action<string>(_commands.ShowClientReader);
            ActionDictionary[DictCommandsEnum.ShowCo_AuthorReader] = new Action<string>(_commands.ShowCo_AuthorReader);
            ActionDictionary[DictCommandsEnum.ShowGenreReader] = new Action<string>(_commands.ShowGenreReader);
            ActionDictionary[DictCommandsEnum.ShowSubscriptionReader] = new Action<string>(_commands.ShowSubscriptionReader);
            ActionDictionary[DictCommandsEnum.ShowAuthorDeserialize] = new Action<string>(_commands.ShowAuthorDeserialize);
            ActionDictionary[DictCommandsEnum.ShowBookDeserialize] = new Action<string>(_commands.ShowBookDeserialize);
            ActionDictionary[DictCommandsEnum.ShowClientDeserialize] = new Action<string>(_commands.ShowClientDeserialize);
            ActionDictionary[DictCommandsEnum.ShowCo_AuthorDeserialize] = new Action<string>(_commands.ShowCo_AuthorDeserialize);
            ActionDictionary[DictCommandsEnum.ShowGenreDeserialize] = new Action<string>(_commands.ShowGenreDeserialize);
            ActionDictionary[DictCommandsEnum.ShowSubscriptionDeserialize] = new Action<string>(_commands.ShowSubscriptionDeserialize);
            ActionDictionary[DictCommandsEnum.ShowGetInnerJoin] = new Action(_commands.ShowInnerJoin);
            ActionDictionary[DictCommandsEnum.ShowSelectClientsByCategory] = new Action<Categories>(_commands.ShowSelectClientsByCategory);
            ActionDictionary[DictCommandsEnum.ShowGetAllBooksByClient] = new Action(_commands.ShowGetAllBooksByClient);
            ActionDictionary[DictCommandsEnum.ShowGetFullAmountOfBook] = new Action(_commands.ShowGetFullAmountOfBook);
            ActionDictionary[DictCommandsEnum.ShowGetBooksByGenres] = new Action(_commands.ShowGetBooksByGenres);
            ActionDictionary[DictCommandsEnum.ShowGetBoolAllBooksWithSpecificAmount] = new Action<int>(_commands.ShowGetBoolAllBooksWithSpecificAmount);
            ActionDictionary[DictCommandsEnum.ShowGetClientsWithSkipedIndex] = new Action<int>(_commands.ShowGetClientsWithSkipedIndex);
            ActionDictionary[DictCommandsEnum.GetSortedOldestTakenBooks] = new Action(_commands.GetSortedOldestTakenBooks);
            ActionDictionary[DictCommandsEnum.ShowGetAvgRentProfit] = new Action(_commands.ShowGetAvgRentProfit);
            ActionDictionary[DictCommandsEnum.ShowGetRentedBooksInRange] = new Action<int, int>(_commands.ShowGetRentedBooksInRange);
            ActionDictionary[DictCommandsEnum.ShowGetPercentOfCategoryClients] = new Action<Categories>(_commands.ShowGetPercentOfCategoryClients);
            ActionDictionary[DictCommandsEnum.ShowGetAllBooksStartedWithChar] = new Action<char>(_commands.ShowGetAllBooksStartedWithChar);
            ActionDictionary[DictCommandsEnum.ShowGetJoinBooksGenres] = new Action(_commands.ShowGetJoinBooksGenres);
            ActionDictionary[DictCommandsEnum.ShowGetClientsWithOutRent] = new Action(_commands.ShowGetClientsWithOutRent);
            ActionDictionary[DictCommandsEnum.ShowGetMaxCollateralValue] = new Action(_commands.ShowGetMaxCollateralValue);
            
           
        }
        public void Invoke(string s, string[] param)
        {
            if (Enum.TryParse(s, out DictCommandsEnum command))
            {
                if (ActionDictionary.TryGetValue(command, out Delegate action))
                {
                    
                    var methodInfo = action.Method;
                    
                    var parameters = methodInfo.GetParameters();
                    
                    if (parameters.Length == 0)
                    {
                        action.DynamicInvoke();
                    }
                    else
                    {
                        if(param.Count() != parameters.Length)
                        {
                            Console.WriteLine("Need params!");
                        }else 
                        {
                            object[] args = new object[parameters.Length];
                            Categories category;
                            int am;
                            for (var i = 0;  i < parameters.Length; i++)
                            {
                                if (parameters[i].ParameterType == typeof(string))
                                {
                                    args[i] = param[i];
                                }
                                if (parameters[i].ParameterType == typeof(Categories)) {
                                    
                                    if (Enum.TryParse(param[i], out category)) {
                                        args[i] = category;
                                    }
                                }
                                if (parameters[i].ParameterType == typeof(int))
                                {
                                    if (int.TryParse(param[i], out am)) { args[i] = am; }
                                }
                            }
                            if (args.Length == parameters.Length) Console.Write(action.DynamicInvoke(args));
                            else Console.WriteLine("Wrong args");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Command not found");
                }
            }
            else
            {
                Console.WriteLine("Bad command");
            }
        }
    }
}
