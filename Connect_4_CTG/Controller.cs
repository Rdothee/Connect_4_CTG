using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    public sealed class Controller
    {
        //singleton pattren used 
        private const int Columns = 7;
        private const int Rows = 6;
        private static Controller Instance = null;
        private IPlayer[] Players { get; set; }
        Model Board= Model.GetInstance;
       
         public static Controller GetInstance
        {
            get
            {
                if(GetInstance == null)
                {
                    Instance = new Controller();
                }
                return Instance;
            }
        }

        private Controller()
        {
            Model.CreateBoard(Rows, Columns);
        }

        public void AddPlayers(IPlayer player)
        {
            if (Players == null)
                Players[0] = player;
            Players.Append(player);
        }

        private void turn()
        {

        }


    }
}
