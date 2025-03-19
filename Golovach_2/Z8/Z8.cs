using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите зашифрованную строку: ");
        string encryptedText = Console.ReadLine()!;

        Console.Write("Введите ключ (сдвиг): ");
        int key = Convert.ToInt32(Console.ReadLine());

        string decryptedText = DecryptCaesarCipher(encryptedText, key);

        Console.WriteLine($"Расшифрованная строка: {decryptedText}");
    }

static string DecryptCaesarCipher(string text, int shift)
{
    char[] decryptedChars = new char[text.Length];

    for (int i = 0; i < text.Length; i++)
    {
        char currentChar = text[i];

        if (currentChar >= 'А' && currentChar <= 'Я') 
        {
            char offset = 'А';
            decryptedChars[i] = (char)((currentChar - offset - shift + 32) % 32 + offset);
        }
        else if (currentChar >= 'а' && currentChar <= 'я') 
        {
            char offset = 'а';
            decryptedChars[i] = (char)((currentChar - offset - shift + 32) % 32 + offset);
        }
        else
        {
            decryptedChars[i] = currentChar;
        }
    }
    return new string(decryptedChars);
}
}
