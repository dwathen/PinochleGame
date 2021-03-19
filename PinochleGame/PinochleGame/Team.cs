using System;
using System.Collections.Generic;
using System.Text;

namespace PinochleGame
{
    public class Team
    {
        public List<Player> Players { get; set; }
        public int Points { get; set; }

        public Team()
        {
            Players = new List<Player>();
            Points = 0;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
