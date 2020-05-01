using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodoListCLI.Commands
{
    class ListTodoCommand : ICommand
    {
        public void Run(string[] args) => TodoList.PrintTodos();
        public string HelpInfo() => "Get add current todos.";
    }
}
