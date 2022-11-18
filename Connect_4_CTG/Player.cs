using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    /*
     * abstract class used by all players as base
     */
    internal abstract class Player : IPlayer
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
        public int PlayerID { get; private set; }

        public Player() { }

        public Player(String name, ConsoleColor color, int playerID)
        {
            this.Name = name;
            this.Color = color;
            this.PlayerID = playerID;
        }
        public abstract int Play(Model Board);


    }
}
