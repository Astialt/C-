using System;

namespace TextEditorCommandPattern
{
   public class TextEditor
{
    private string _text = "";       
    private string _clipboard = ""; 

    public string Clipboard => _clipboard;

    public void Copy(string text)
    {
        _clipboard = text;
        Console.WriteLine($"Скопировано в буфер: \"{_clipboard}\"");
    }

    public void Paste()
    {
        _text += _clipboard;
        Console.WriteLine($"Текущее содержимое текста: \"{_text}\"");
    }

    public void UndoPaste(string lastClipboard)
    {
        if (_text.EndsWith(lastClipboard))
        {
            _text = _text.Substring(0, _text.Length - lastClipboard.Length);
            Console.WriteLine($"Отмена вставки. Текст: \"{_text}\"");
        }
    }

    public void RedoPaste()
    {
        _text += _clipboard;
        Console.WriteLine($"Повтор вставки. Текст: \"{_text}\"");
    }
}
}
