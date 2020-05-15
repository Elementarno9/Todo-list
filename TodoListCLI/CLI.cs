using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TodoListCLI.Commands;

namespace TodoListCLI
{
    class CLI
    {
        public static readonly Dictionary<string, ConsoleColor> ConsoleColors = new Dictionary<string, ConsoleColor>()
        {
            ["none"] = ConsoleColor.White,
            ["input"] = ConsoleColor.Green,
            ["success"] = ConsoleColor.Green,
            ["error"] = ConsoleColor.Red
        };

        public bool IsWorking { get; private set; }

        public static readonly Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>()
        {
            ["add"] = new AddTodoCommand(),
            ["change"] = new ChangeStatusCommand(),
            ["search"] = new SearchCommand(),
            ["list"] = new ListTodoCommand(),
            ["save"] = new SaveCommand(),
            ["load"] = new LoadCommand(),
            ["help"] = new HelpCommand(),
            ["clear"] = new ClearCommand(),
            ["exit"] = new ExitCommand(),
        };
        public static CLI Current
        {
            get
            {
                current ??= new CLI();
                return current;
            }
            private set
            {
                current = value;
            }
        }

        private static CLI current;

        static void Main(string[] args)
        {
            Current.Run();
        }

        public void Run()
        {
            IsWorking = true;
            while (IsWorking)
            {
                try
                {
                    HandleInput(GetConsoleInput("> ").Trim().Split());
                } catch (TodoListException ex)
                {
                    ColorfulWriteLine($"ERROR: {ex.Message}", ConsoleColors["error"]);
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
                throw new TodoListException("Command's not found. Try again or use `help`.");
            }
        }

        public void Stop() => IsWorking = false;

        public static string GetConsoleInput(string line = "", bool colorful = true)
        {
            ColorfulWrite(line, ConsoleColors[colorful ? "input" : "none"]);
            return Console.ReadLine();
        }

        public static DateTime GetDateTimeFromInput(string line = "", string format = "dd.MM.yyyy")
        {
            DateTime result;

            while (!DateTime.TryParseExact(GetConsoleInput(line), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                ColorfulWriteLine($"Error: invalid input. ({format.ToLower()})", ConsoleColors["error"]);
            }

            return result;
        }

        public static void ColorfulWrite(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(line);
            Console.ResetColor();
        }

        public static void ColorfulWriteLine(string line, ConsoleColor color) => ColorfulWrite(line + "\n", color);
    }
}
