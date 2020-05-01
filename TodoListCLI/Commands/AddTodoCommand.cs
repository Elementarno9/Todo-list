using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodoListCLI.Commands
{
    class AddTodoCommand : ICommand
    {
        public void Run(string[] args)
        {
            Console.WriteLine("Adding new todo.");

            string title = CLI.GetConsoleInput(" Title: ");
            string description = CLI.GetConsoleInput(" Description: ");
            DateTime deadline = CLI.GetDateTimeFromInput(" Deadline (as `dd.mm.yyyy`): ");
            string[] tags = CLI.GetConsoleInput(" Tags: ").Split();

            TodoList.Current.Todos.Add(new Todo(title, description, deadline, tags.ToList()));

            Console.WriteLine("Successfully added new todo!");
        }
        public string HelpInfo() => "Add Todo to list.";
    }
}
