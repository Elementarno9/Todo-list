using System;
using System.Linq;

namespace TodoListCLI.Commands
{
    class AddTodoCommand : ICommand
    {
        public void Run(string[] args)
        {
            CLI.ColorfulWriteLine("New todo:", CLI.ConsoleColors["input"]);
            string title = CLI.GetConsoleInput(" Title: ");
            string description = CLI.GetConsoleInput(" Description: ");
            DateTime deadline = CLI.GetDateTimeFromInput(" Deadline (as `dd.mm.yyyy`): ");
            string[] tags = CLI.GetConsoleInput(" Tags: ").Trim().Split();

            CLI.CurrentTodoList.Todos.Add(new Todo(title, description, deadline, tags.ToList()));

            CLI.ColorfulWriteLine("Successfully added new todo!", CLI.ConsoleColors["success"]);
        }
        public string HelpInfo() => "Add Todo to list. For date use format `dd.mm.yyyy`, for tags type all wanted tags separated by spaces.";
    }
}
