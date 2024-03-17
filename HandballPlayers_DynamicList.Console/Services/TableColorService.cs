using HandballPlayers_DynamicList.Console.Enums;

namespace HandballPlayers_DynamicList.Console.Services;

public class TableColorService
{
    private List<string> _availableColors = ["Red", "Green", "Blue", "Yellow", "Random"];
    private List<string> _allColors = ["White", "Red", "Green", "Blue", "Yellow", "Random"];
    private List<string> _randomColors = [];
    private string _currentTableColorName = "White";

    public string[] GetAvailableTableColorNames() => [.. _availableColors];
    public void UpdateAvailableTableColorNames(string color)
    {
        if (color != "Random")
            _availableColors = _allColors.Except(new List<string> { color }).ToList();
    }
    public TableColor ConvertToTableColor(string colorName)
    {

        Enum.TryParse(colorName, out TableColor color);

        return color;
    }
    public TableColor GetCurrentTableColor()
    {
        if (_currentTableColorName == "Random")
        {

            var randomColor = ConvertToTableColor(_randomColors[0]);
            _randomColors.Remove(_randomColors[0]);

            return randomColor;
        }
        return ConvertToTableColor(_currentTableColorName);
    }
    public void SetCurrentTableColor(string tableColorName)
    {
        _currentTableColorName = tableColorName;

        if (tableColorName == "Random")
        {
            var rnd = new Random();
            _randomColors = [];

            for (int i = 0; i < _availableColors.Count; i++)
            {
                _randomColors.Add(_allColors[rnd.Next(0, _allColors.Count - 2)]);
            }
        }
    }
}
