using HandballPlayers_DynamicList.Console.Enums;
using System.Text;

namespace HandballPlayers_DynamicList.Console.Models;

public class Player
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int BirthYear { get; set; }
    public int JerseyNumber { get; set; }
    public PreferredUseOfHand PreferredUseOfHand { get; set; }
    public List<PlayerPosition> Positions { get; set; } = null!;

    public string GetPositionsToString()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Positions.Count; i++)
        {
            sb.Append(Positions[i].ToString());

            if (i < Positions.Count - 1)
                sb.Append(", ");
        }

        return sb.ToString();
    }

    public int GetAge()
    {
        return DateTime.Now.Year - BirthYear;
    }
}
