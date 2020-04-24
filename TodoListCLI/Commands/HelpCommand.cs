using System;
using System.Linq;

namespace TodoListCLI.Commands
{
    class HelpCommand : ICommand
    {
        public void Run(string[] args)
        {
            CLI.Commands.ToList().ForEach((pair) => Console.WriteLine(" `{0}`: {1}", pair.Key, pair.Value.HelpInfo()));
        }
        public string HelpInfo() => "List of commands.";
    }
}
