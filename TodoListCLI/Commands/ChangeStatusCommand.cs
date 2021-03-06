﻿using System;
using System.Linq;

namespace TodoListCLI.Commands
{
    class ChangeStatusCommand : ICommand
    {
        public void Run(string[] args)
        {
            string title = args.Length > 0 ? args[0] : CLI.GetConsoleInput(" Title of todo: ");
            string status_str = args.Length > 1 ? args[1] : CLI.GetConsoleInput(" New status: ");
            TodoStatus status;

            switch (status_str)
            {
                case "active": status = TodoStatus.Active;
                    break;
                case "fail":
                case "failure": status = TodoStatus.Failure;
                    break;
                case "success": status = TodoStatus.Success;
                    break;
                default:
                    throw new TodoListException("Invalid status.");
            }

            var suitableTodos = TodoList.SortTodos(CLI.CurrentTodoList.Todos.Where(todo => todo.Title == title && todo.Status != status).ToList()).ToList();
            Todo toChange;

            if (suitableTodos.Count == 0) throw new TodoListException("No suitable todos.");
            else if (suitableTodos.Count == 1) toChange = suitableTodos[0];
            else
            {
                int index;
                TodoList.PrintTodos(suitableTodos);
                if (int.TryParse(CLI.GetConsoleInput(" Choose the todo to change (type index): "), out index)
                    && (index - 1) >= 0 && (index - 1) < suitableTodos.Count) toChange = suitableTodos[index - 1];
                else throw new TodoListException("Indalid index");
            }
            toChange.ChangeStatus(status);
            Console.WriteLine("Status changed.");
        }
        public string HelpInfo() => "Change status of todo. Usage `change <title> <status>`.";
    }
}
