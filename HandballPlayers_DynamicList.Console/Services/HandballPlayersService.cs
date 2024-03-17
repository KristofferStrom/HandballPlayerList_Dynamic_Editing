using HandballPlayers_DynamicList.Console.Enums;
using HandballPlayers_DynamicList.Console.Models;


namespace HandballPlayers_DynamicList.Console.Services
{
    public class HandballPlayersService
    {
        private List<Player> _players = new List<Player>
        {
            new() {FirstName = "Felix", LastName = "Claar", Positions = [PlayerPosition.V9, PlayerPosition.M9], BirthYear = 1996, JerseyNumber = 7, PreferredUseOfHand = PreferredUseOfHand.Right  },
            new() {FirstName = "Felix", LastName = "Möller", Positions = [PlayerPosition.M6] , BirthYear = 2003, JerseyNumber = 13, PreferredUseOfHand = PreferredUseOfHand.Right  },
            new() {FirstName = "Nicola", LastName = "Karabatic", Positions = [PlayerPosition.V9, PlayerPosition.M9] , BirthYear = 1984, JerseyNumber = 13, PreferredUseOfHand = PreferredUseOfHand.Right  },
            new() {FirstName = "Mathias", LastName = "Gidsel", Positions = [PlayerPosition.H9] , BirthYear = 1999, JerseyNumber = 5, PreferredUseOfHand = PreferredUseOfHand.Left  },
        };
        public IEnumerable<Player> GetAllPlayers()
        {
            return _players;
        }
    }
}
