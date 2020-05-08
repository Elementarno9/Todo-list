using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TodoListCLI.Commands;

namespace TodoListCLI
{
    class CLI
    {
        public bool IsWorking { get; private set; }

        public static readonly Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>()
        {
            ["add"] = new AddTodoCommand(),
            ["change"] = new ChangeStatusCommand(),
            ["search"] = new SearchCommand(),
            ["list"] = new ListTodoCommand(),
            ["help"] = new HelpCommand(),
            ["exit"] = new ExitCommand(),
        };
        public static CLI Current { get; private set; }

        public CLI()
        {
            Current ??= this;
        }

        public void Run()
        {
            IsWorking = true;
            while (IsWorking)
            {
                try
                {
                    HandleInput(GetConsoleInput("> ").Split());
                } catch (TodoListException ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);
                }
            }
        }

        private void HandleInput(string[] input)
        {
            if (input.Length == 0 || string.IsNullOrWhiteSpace(input[0])) throw new TodoListException("Nothing in input.");

            if (Commands.ContainsKey(input[0]))
            {
                Commands[input[0]].Run(input.Skip(1).ToArray());
            } else
            {
                throw new TodoListException("Command's not found. Try again or use `help`");
            }
        }

        public void Stop() => IsWorking = false;

        public static string GetConsoleInput(string line = "")
        {
            Console.Write(line);
            return Console.ReadLine();
        }

        public static DateTime GetDateTimeFromInput(string line = "", string format = "dd.MM.yyyy")
        {
            DateTime result;

            while (!DateTime.TryParseExact(GetConsoleInput(line), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                Console.WriteLine("Error: invalid input. ({0})", format.ToLower());
            }

            return result;
        }
    }
}
