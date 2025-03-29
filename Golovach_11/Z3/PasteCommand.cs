namespace TextEditorCommandPattern
{
   public class PasteCommand : ICommand
{
    private readonly TextEditor _editor;
    private string _lastClipboard;

    public PasteCommand(TextEditor editor)
    {
        _editor = editor;
    }

    public void Execute()
    {
        _lastClipboard = _editor.Clipboard; // Используем свойство
        _editor.Paste();
    }

    public void Undo()
    {
        _editor.UndoPaste(_lastClipboard);
    }
}
}

