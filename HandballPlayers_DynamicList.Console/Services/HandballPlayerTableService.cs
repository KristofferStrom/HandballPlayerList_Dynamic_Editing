namespace HandballPlayers_DynamicList.Console.Services;
using HandballPlayers_DynamicList.Console.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

public class HandballPlayerTableService(ConsoleService consoleService, HandballPlayersService handballPlayersService, TableColorService colorService) : TableService(consoleService)
{
    private readonly HandballPlayersService _handballPlayersService = handballPlayersService;
    private readonly TableColorService _colorService = colorService;
    private List<PlayerTableRow> _tableRows = [];
    private readonly string[] _headers = ["Name", "Position", "Age", "Preferred Hand"];
    private string _latestOrderDirection = "";
    private string _latestOrderedBy = "FirstName";

    public List<PlayerTableRow> GetTableRows()
    {
        if(_tableRows.Count == 0)
        {
            foreach (var player in _handballPlayersService.GetAllPlayers())
            {
                _tableRows.Add(new PlayerTableRow
                {
                    TableItem = player,
                    TableColor = _colorService.GetCurrentTableColor()
                });
            }
        }

        return _tableRows;
    }
    public void OrderBy<TKey>(Expression<Func<PlayerTableRow, TKey>> keySelector)
    {
        _tableRows = [.. _tableRows.OrderBy(keySelector.Compile())];
        _latestOrderDirection = "asc";
    }
    public void UpdateTableColor()
    {
        _tableRows = [];

        foreach (var player in _handballPlayersService.GetAllPlayers())
        {
            _tableRows.Add(new PlayerTableRow
            {
                TableItem = player,
                TableColor = _colorService.GetCurrentTableColor()
            });
        }
    }
    public void CreateTable()
    {

        AddTableHeaders(_headers);

        foreach (var row in GetTableRows())
        {
            AddTableRow(row.TableColor, $"{row.TableItem.FirstName} {row.TableItem.LastName}", row.TableItem.GetPositionsToString(), row.TableItem.GetAge().ToString(), row.TableItem.PreferredUseOfHand.ToString());
        }

        EndTable();
    }
    public string GetLatestOrderDirection() => _latestOrderDirection;
    public string GetLatestOrderedBy() => _latestOrderedBy;
    public void SetLatestOrderedBy(string orderBy) => _latestOrderedBy = orderBy;
    public void OrderByDescending<TKey>(Expression<Func<PlayerTableRow, TKey>> keySelector)
    {
        _tableRows = [.. _tableRows.OrderByDescending(keySelector.Compile())];
        _latestOrderDirection = "desc";
    }
}
