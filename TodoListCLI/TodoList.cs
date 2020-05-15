﻿using System;
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

        public static void PrintTodos(List<Todo> todos, TodoStatus? status = null)
        {
            if (status != null) todos = todos.Where(todo => todo.Status == status).ToList();

            if (todos.Count == 0)
            {
                Console.WriteLine("No todos.");
                return;
            }

            // Transform todos into information (string[])
            var tableStrings = SortTodos(todos).Select((todo, idx) => {
                var result = todo.GetInfo().ToList();
                result.Insert(0, (idx + 1).ToString());
                return result.ToArray();
                }).ToList();
            
            // Header
            tableStrings.Insert(0, new[] { "#", "Title", "Description", "Deadline", "Tags", "Status" });

            // Find max width of each column
            var maxWidthPerColumn = tableStrings.First().Select((x, n) => tableStrings.Max(row => row[n].Length + 2)).ToArray();

            // Generate lines
            var lines = tableStrings.Select(row =>
                "|" + string.Join("|",
                    row.Select((cell, col) => cell.PadCenter(maxWidthPerColumn[col]))
                ) + "|"
            ).ToList();

            // Separators
            var sep = new string('-', maxWidthPerColumn.Sum() + maxWidthPerColumn.Length + 1);
            lines.Insert(0, sep);   // Add before header
            lines.Insert(2, sep);   // Add after header
            lines.Add(sep);         // Add in the end

            // Print into console
            lines.ForEach(Console.WriteLine);
        }

        public static void PrintTodos(TodoStatus? status = null) => PrintTodos(Current.Todos, status);

        public static IEnumerable<Todo> SortTodos(List<Todo> todos) => todos.OrderBy(todo => todo.Status).ThenBy(todo => todo.Deadline);
    }
}
