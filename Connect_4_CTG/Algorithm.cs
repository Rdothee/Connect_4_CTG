using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    //bridge design computerPlayer <-> Algorithm: implementor

    /*
     * the base for each computer players 
     * implements an instawin function 
     */
    internal abstract class Algorithm
    {
        internal abstract int GenerateSolution(Model model);

        protected Analyzer Analyzer = new Analyzer();
        public int PlayerID { get; internal set; }
        protected Model Model = new Model();

        //check if there is a possibility to immediately win the game. 
        protected int InstaWin(int player)
        {
            Analyzer.PlayerID = player;
            Analyzer.Model = Model;
            for (int i = 0; i < Model.Width; i++)
            {
                if (Model.IsColumnPlayable(i))
                {
                    if (Analyzer.CheckWin(i, player)) return i;
                }
            }
            return -1;
        }




    }
}
