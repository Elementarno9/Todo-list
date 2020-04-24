namespace TodoListCLI.Commands
{
    class ExitCommand : ICommand
    {
        public void Run(string[] args) => CLI.Current.Stop();
        public string HelpInfo() => "Exit.";
    }
}
