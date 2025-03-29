namespace TextEditorCommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();    
    }
}
