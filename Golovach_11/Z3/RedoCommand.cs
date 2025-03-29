namespace TextEditorCommandPattern
{
    public class RedoCommand : ICommand
    {
        private readonly TextEditor _editor;

        public RedoCommand(TextEditor editor)
        {
            _editor = editor;
        }

        public void Execute()
        {
            _editor.RedoPaste();
        }

        public void Undo()
        {
            Console.WriteLine("Redo невозможно отменить.");
        }
    }
}
