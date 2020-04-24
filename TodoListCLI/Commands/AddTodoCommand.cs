using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI.Commands
{
    class AddTodoCommand : ICommand
    {
        public void Run(string[] args)
        {
            
        }
        public string HelpInfo() => "Add Todo to list.";
    }
}
