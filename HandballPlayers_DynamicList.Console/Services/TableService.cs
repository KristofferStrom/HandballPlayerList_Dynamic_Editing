using HandballPlayers_DynamicList.Console.Enums;
using HandballPlayers_DynamicList.Console.Helpers;
using HandballPlayers_DynamicList.Console.Models;
using System.Text;

namespace HandballPlayers_DynamicList.Console.Services;

public abstract class TableService(ConsoleService consoleService)
{
    private readonly ConsoleService _consoleService = consoleService;
    private int _dividerLength;
    private int _columnLength = 20;

    public void EndTable()
    {
        _consoleService.EmptyLine();
        AddDivider();
        _consoleService.EmptyLine();
    }
    public void AddTableHeaders(params string[] titles)
    {
        var sb = new StringBuilder();

        foreach (var title in titles)
        {
            sb.Append(CreateColumn(_columnLength, title));
        }
        _dividerLength = sb.Length - 1;
        _consoleService.WriteLine(sb);
        AddDivider();
    }
    public void AddTableRow(TableColor color, params string[] row)
    {
        var sb = new StringBuilder();

        foreach (var item in row)
        {
            sb.Append(CreateColumn(_columnLength, item));
        }
        _consoleService.SetColor((ConsoleColor)color); 
        _consoleService.WriteLine(sb);
        _consoleService.ResetColor();
    }
    public void AddDivider()
    {
        _consoleService.WriteLine(UIHelper.CreateDivider(_dividerLength));
    }
    public void EditColumnLength(int columnLength)
    {
        _columnLength = columnLength;
    }
    private string CreateColumn(int columnLength, string tableItem)
    {
        if (tableItem.Length >= columnLength)
        {
            return tableItem[..(columnLength - 4)] + "... ";
        }

        if (tableItem.Length < columnLength)
        {
            return tableItem + UIHelper.CreateWhitespace(columnLength - tableItem.Length);
        }

        return tableItem;
    }
}
