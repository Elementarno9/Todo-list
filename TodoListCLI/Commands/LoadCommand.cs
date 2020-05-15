using System;
using System.IO;
using TodoListCLI.Storage;

namespace TodoListCLI.Commands
{
    class LoadCommand : ICommand
    {

        public void Run(string[] args)
        {
            if (args.Length == 0) throw new TodoListException("No path. See usage (`help load`)");
            if (!File.Exists(args[0])) throw new TodoListException("File not found.");

            try
            {
                TodoList.ChangeCurrent(TodoStorage.LoadTodoList(args[0]));
                CLI.ColorfulWriteLine("Successfully loaded.", CLI.ConsoleColors["success"]);
            } catch (Exception)
            {
                throw new TodoListException("An error occured while todo list was loading. Maybe file is invalid.");
            }
        }
        public string HelpInfo() => "Load todo-list from file. Usage: `load <path>`.";
    }
}
