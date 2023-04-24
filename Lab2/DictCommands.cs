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
        public DictCommands(ICommands commands)
        {
            _commands = commands;
        }
        public Dictionary<DictCommandsEnum, Delegate> ActionDictionary = new Dictionary<DictCommandsEnum, Delegate>();
        public void Load()
        {
            ActionDictionary[DictCommandsEnum.GetInnerJoin] = new Action(_commands.ShowInnerJoin);
            ActionDictionary[DictCommandsEnum.ShowAuthorDeserialize] = new Action<string>(_commands.ShowAuthorDeserialize);
       
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
                        if(param.Count() == 0)
                        {
                            Console.WriteLine("Need params!");
                        }
                        action.DynamicInvoke(param);
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
