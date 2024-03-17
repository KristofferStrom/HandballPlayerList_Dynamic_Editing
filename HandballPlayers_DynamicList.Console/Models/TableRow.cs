using HandballPlayers_DynamicList.Console.Enums;

namespace HandballPlayers_DynamicList.Console.Models;

public abstract class TableRow<T> where T : class
{
    public T TableItem { get; set; } = null!;
    public TableColor TableColor { get; set; }
}
