namespace TextEditorCommandPattern
{
    public class UndoCommand : ICommand
    {
        private readonly ICommand _command;

        public UndoCommand(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            _command.Undo();
        }

        public void Undo()
        {
            Console.WriteLine("Undo невозможно отменить.");
        }
    }
}
