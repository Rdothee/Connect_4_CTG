using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Connect_4_CTG
{
    public sealed class Controller
    {
        //singleton pattren used 
        private const int Columns = 7;
        private const int Rows = 6;
        private static Controller Instance = null;
        private List<IPlayer> Players = new List<IPlayer>();
        private int TurnCounter=0;
        Draw Draw;
       
         public static Controller GetInstance
        {
            get
            {
                if(Instance == null)
                {
                    Instance = new Controller();
                }
                return Instance;
            }
        }

        private Controller()
        {
            Model.CreateBoard(Rows, Columns);
            Draw = new Draw(Columns,Rows);
        }

        public void AddPlayers(IPlayer player)
        {
           Players.Add(player);
        }

        public void Turn()
        {
            ++TurnCounter;
            foreach (var player in Players)
            {
                player.Play(Model.GetInstance.getPlayableColumns());
            }
        }

       
    



    }
}
