namespace TodoListCLI.Commands
{
    class ExitCommand : ICommand
    {
        public void Run(string[] args) => CLI.Stop();
        public string HelpInfo() => "Exit.";
    }
}
