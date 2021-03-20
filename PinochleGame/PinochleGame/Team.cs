using System;
using System.Collections.Generic;
using System.Text;

namespace PinochleGame
{
    public class Team
    {
        public List<Player> Players { get; set; }
        public int RoundPoints { get; set; }
        public int GamePoints { get; set; }

        public Team()
        {
            Players = new List<Player>();
            RoundPoints = 0;
            GamePoints = 0;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public bool HasPlayer(Player player)
        {
            if (Players.Contains(player))
                return true;
            else
                return false;
        }

        public Player GetTeammate(Player self)
        {
            foreach (Player player in Players)
            {
                if (self != player)
                    return player;
            }

            return new Player();
        }
    }
}
