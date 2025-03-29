namespace TextEditorCommandPattern
{
    public class CopyCommand : ICommand
    {
        private readonly TextEditor _editor;
        private readonly string _textToCopy;

        public CopyCommand(TextEditor editor, string textToCopy)
        {
            _editor = editor;
            _textToCopy = textToCopy;
        }

        public void Execute()
        {
            _editor.Copy(_textToCopy);
        }

        public void Undo()
        {
            Console.WriteLine("Команда Copy не имеет операции Undo.");
        }
    }
}
