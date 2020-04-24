using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI.Commands
{
    class SearchCommand : ICommand
    {

        public void Run(string[] args)
        {
            throw new NotImplementedException();
        }
        public string HelpInfo() => "Search tasks.";
    }
}
