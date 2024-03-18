namespace HandballPlayers_DynamicList.Console.Services;

using HandballPlayers_DynamicList.Console.ExtensionsMethods;
using HandballPlayers_DynamicList.Console.Helpers;
using HandballPlayers_DynamicList.Console.Models;
using System;
using System.Linq.Expressions;

public class UserInterfaceService(ConsoleService consoleService, TableColorService tableColorService, HandballPlayerTableService tableService)
{

    private readonly ConsoleService _consoleService = consoleService;
    private readonly TableColorService _tableColorService = tableColorService;
    private readonly HandballPlayerTableService _tableService = tableService;

    public void MainPage()
    {
        string[] options = ["Table color", "Column length", "Sort order", "Quit"];
        while (true)
        {
            DisplayTable();
            _consoleService.AddHeader("Choose what to edit");

            var selection = GetSelectedOption(options).GetInt("Choose again").GetRequiredNumbers("Choose again", 1, options.Length);

            switch (selection)
            {
                case 1:
                    EditTableColorPage();
                    break;
                case 2:
                    EditColumnLengthPage();
                    break;
                case 3:
                    EditSortOrderPage();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }
    }
    private void EditSortOrderPage()
    {
        bool cancel = false;
        while (!cancel)
        {
            DisplayTable();
            _consoleService.AddHeader("Order by");

            string[] options = ["Firstname", "Lastname", "Position", "Age", "Color"];

            var selection = GetSelectedOption(options).GetInt("Order by").GetRequiredNumbers("Order by", 1, options.Length);

           
            switch (selection)
            {
                case 1:
                    Order("Firstname", row => row.TableItem.FirstName);
                    break;
                case 2:
                    Order("Lastname", row => row.TableItem.LastName);
                    break;
                case 3:
                    Order("Position", row => row.TableItem.Positions[0]);
                    break;
                case 4:
                    Order("Age", row => row.TableItem.GetAge());
                break;
                case 5:
                    Order("Color", row => row.TableColor);
                    break;
                case 0:
                    cancel = true;
                    break;
            }
        }
    }
    private void Order<TKey>(string orderBy, Expression<Func<PlayerTableRow, TKey>> keySelector)
    {
        string latestOrderDirection = _tableService.GetLatestOrderDirection();
        string latestOrderBy = _tableService.GetLatestOrderedBy();

        if (latestOrderBy == orderBy)
        {
            if (latestOrderDirection == "asc")
                _tableService.OrderByDescending(keySelector);
            else
                _tableService.OrderBy(keySelector);
        }
        else
        {
            _tableService.OrderBy(keySelector);
        }

        _tableService.SetLatestOrderedBy(orderBy);
    }
    private void EditColumnLengthPage()
    {

        while (true)
        {
            DisplayTable();
            _consoleService.AddHeader("Edit column length");

            var input = _consoleService.GetFieldInput("Choose column length (Q to go back)").GetInt("Column length").GetRequiredNumbers("Column length", 4, 100);
            if (input == 0)
                break;
            _tableService.EditColumnLength(input);
        }
    }
    private void EditTableColorPage()
    {
        while (true)
        {
            DisplayTable();
            _consoleService.AddHeader("Choose your color");

            var tableColorNames = _tableColorService.GetAvailableTableColorNames();
            var selection = GetSelectedOption(tableColorNames).GetInt("Color").GetRequiredNumbers("Color", 1, tableColorNames.Length);

            if (selection == 0)
                break;

            _tableColorService.UpdateAvailableTableColorNames(tableColorNames[selection - 1]);
            _tableColorService.SetCurrentTableColor(tableColorNames[selection - 1], _tableService.GetRowCount());
            _tableService.UpdateTableColor();
        }
    }
    public string GetSelectedOption(params string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            _consoleService.WriteLine($"{i + 1}. {options[i]}");
        }
        _consoleService.WriteLine(UIHelper.CreateDivider(27));
        _consoleService.Write("Your choice (Q to go back): ");

        return _consoleService.ReadLine();
    }
    private void DisplayTable()
    {
       
        _consoleService.ClearScreen();

        _consoleService.AddHeader("Handball Players");

        _tableService.CreateTable();
    }
}
