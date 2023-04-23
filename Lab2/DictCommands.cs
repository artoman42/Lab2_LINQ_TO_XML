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
        public Dictionary<DictCommandsEnum, Action> ActionDictionary = new Dictionary<DictCommandsEnum, Action>();
        public void Load()
        {
            ActionDictionary.Add(DictCommandsEnum.GetInnerJoin, _commands.ShowInnerJoin);
        }
        public void Invoke(string s)
        {
           if(Enum.TryParse(s, out DictCommandsEnum command))
            {
                ActionDictionary[command].Invoke();
            }
            else
            {
                Console.WriteLine("BadCommand");
            }
        }
    }
}
