using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoListCLI.Commands
{
    class SearchCommand : ICommand
    {

        public void Run(string[] args)
        {
            var tags = args.ToList() ?? new List<string>();

            if (tags.Count == 0) throw new TodoListException("No tags. See `help search` to find more.");

            var suitableTodos = CLI.CurrentTodoList.Todos.Where(todo => args.Select(tag => todo.HasTag(tag)).Contains(true)).ToList();

            if (suitableTodos.Count == 0) throw new TodoListException("No suitable todos.");
            TodoList.PrintTodos(suitableTodos);
        }
        public string HelpInfo() => "Search tasks. Usage: `search <tags>`, where tags is separeted by spaces.";
    }
}
