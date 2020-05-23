using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI.Storage
{
    interface ITodoStorageSystem
    {
        public void SaveTodoList(string path, TodoList list);
        public TodoList LoadTodoList(string path);
    }
}
