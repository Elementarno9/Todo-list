using System;
using System.Linq;

namespace TodoListCLI.Commands
{
    class HelpCommand : ICommand
    {
        public void Run(string[] args)
        {
            if (args.Length > 0 && CLI.Commands.ContainsKey(args[0])) Console.WriteLine("{0}", CLI.Commands[args[0]].HelpInfo());
            else CLI.Commands.ToList().ForEach((pair) => Console.WriteLine(" `{0}`: {1}", pair.Key, pair.Value.HelpInfo()));
        }
        public string HelpInfo() => "List of commands.";
    }
}
