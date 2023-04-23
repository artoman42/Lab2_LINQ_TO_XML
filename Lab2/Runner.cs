using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUIL
{
    public class Runner:IRunner
    {
        private readonly IDictCommands _commands;
        public Runner(IDictCommands dictCommands)
        {
            _commands = dictCommands;    
        }
        public void Run()
        {
            _commands.Load();
            _commands.Invoke("GetInnerJoin");
        }
    }
}
