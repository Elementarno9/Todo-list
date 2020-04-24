namespace TodoListCLI.Commands
{
    interface ICommand
    {
        public void Run(string[] args);
        public string HelpInfo();
    }
}
