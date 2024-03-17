namespace HandballPlayers_DynamicList.Console.Services;

using HandballPlayers_DynamicList.Console.Helpers;
using System;
using System.Text;

public class ConsoleService
{
    public void EmptyLine() => Console.WriteLine();
    public void ReadKey() => Console.ReadKey();
    public void ClearScreen() => Console.Clear();
    public string ReadLine() => Console.ReadLine()!;
    public void Write(string text) => Console.Write(text);
    public void WriteLine(string text) => Console.WriteLine(text);
    public void WriteLine(StringBuilder text) => Console.WriteLine(text);
    public void SetColor(ConsoleColor color) => Console.ForegroundColor = color;
    public void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }
    public string GetFieldInput(string text)
    {
        Console.Write($"{text}: ");
        return Console.ReadLine()!;
    }
    public void AddHeader(string title)
    {
        WriteLine(title);
        WriteLine(UIHelper.CreateDivider(title.Length));
        EmptyLine();
    }
}
