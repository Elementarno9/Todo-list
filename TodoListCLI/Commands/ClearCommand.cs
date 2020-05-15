using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI.Commands
{
    class ClearCommand : ICommand
    {

        public void Run(string[] args) => Console.Clear();
        public string HelpInfo() => "Clear console.";
    }
}
