using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodoListCLI
{
    class TodoList
    {
        public List<Todo> Todos { get; private set; } = new List<Todo>();

        public static TodoList Current {
            get {
                current ??= new TodoList();
                return current;
            }
            private set {
                current = value;
            }
        }

        private static TodoList current;

        public static void PrintTodos(List<Todo> todos)
        {
            var tableStrings = todos.Select(todo => todo.GetInfo()).ToList();
            tableStrings.Insert(0, new[] { "Title", "Description", "Deadline", "Tags", "Status" });

            var maxWidthPerColumn = tableStrings.First().Select((x, n) => tableStrings.Max(row => row[n].Length + 2)).ToArray();

            var lines = tableStrings.Select(row =>
                "|" + string.Join("|",
                    row.Select((cell, col) => cell.PadCenter(maxWidthPerColumn[col]))
                ) + "|"
            ).ToList();

            lines.Insert(1, new string('-', maxWidthPerColumn.Sum() + maxWidthPerColumn.Length + 1));

            lines.ForEach(Console.WriteLine);
        }

        public static void PrintTodos() => PrintTodos(Current.Todos);
    }
}
