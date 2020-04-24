using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI
{
    class TodoListException : Exception
    {
        public TodoListException(string message) : base(message) { }
    }
}
