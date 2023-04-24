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
            while (true)
            {
                Console.Write("Enter command: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                string[] parts = input.Split(' ');
                string command = parts[0];

                _commands.Invoke(command, parts.Skip(1).ToArray());
            }
        }
    }
}
