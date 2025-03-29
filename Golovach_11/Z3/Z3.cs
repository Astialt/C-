using System;

namespace TextEditorCommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var editor = new TextEditor();
            var invoker = new EditorInvoker();

    
            Console.WriteLine("Действия в редакторе:");
            invoker.ExecuteCommand(new CopyCommand(editor, "Привет, "));
            invoker.ExecuteCommand(new PasteCommand(editor));
            invoker.ExecuteCommand(new CopyCommand(editor, "мир!"));
            invoker.ExecuteCommand(new PasteCommand(editor));


            Console.WriteLine("\nОтмена:");
            invoker.Undo();
            invoker.Undo();

            Console.WriteLine("\nПовтор:");
            invoker.Redo();
            invoker.Redo();

            Console.ReadLine();
        }
    }
}
