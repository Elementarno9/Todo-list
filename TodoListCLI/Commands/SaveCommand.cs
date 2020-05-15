using System;
using TodoListCLI.Storage;

namespace TodoListCLI.Commands
{
    class SaveCommand : ICommand
    {

        public void Run(string[] args)
        {
            if (args.Length == 0) throw new TodoListException("No path. See usage (`help load`)");

            try
            {
                TodoStorage.SaveTodoList(args[0]);
                CLI.ColorfulWriteLine("Successfully saved!", CLI.ConsoleColors["success"]);
            }
            catch (Exception)
            {
                throw new TodoListException("An error occured while todo list was saving. Maybe file is invalid.");
            }
        }
        public string HelpInfo() => "Save current todo-list. Usage: `save <path>`.";
    }
}
