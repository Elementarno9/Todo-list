using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI
{
    class TodoList
    {
        public List<Todo> Todos { get; private set; } = new List<Todo>();

        public static TodoList Current { get; private set; }

        public TodoList()
        {
            Current ??= this;
        }
    }
}
