using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodoListCLI.Commands
{
    class ListTodoCommand : ICommand
    {
        public void Run(string[] args)
        {
            TodoStatus? status = null;
            if (args.Length > 0)
            {
                switch(args[0])
                {
                    case "active": status = TodoStatus.Active;
                        break;
                    case "success": status = TodoStatus.Success;
                        break;
                    case "failure":
                    case "fail": status = TodoStatus.Failure;
                        break;
                    case "all": // Don't choose status
                        break;
                    default: throw new TodoListException("Invalid argument for `list` command");
                }
            }
            TodoList.PrintTodos(status);
        }
        public string HelpInfo() => "Get add current todos. Usage: `list <active/success/failure(fail)>`. Add argument to list todos which have this status.";
    }
}
