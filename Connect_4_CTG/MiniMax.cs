using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    /*
     * miniMax algortithm
     * only works for 2 players
     * playerID of
     *  computer = 1
     *  opponent = -1
     */

    internal class MiniMax : Algorithm
    {
        public int Depth { get; set; } = 5; //depth of minimax lookup
        private Model newState;
        //private Model AlteredBoard;
        public MiniMax()
        {

        }

        protected override Analyzer Analyzer { get; set; }

        internal override int GenerateSolution(Model model)
        {
            this.Model = model;
           // AlterBoard();
            Analyzer = new Analyzer();
            Analyzer.Model = model;
            List<int> results = RunMiniMax(this.PlayerID);
            return SelectColumn(results);
        }

        //alters playerID of the board to work with the minMax algortihm
       /* private void AlterBoard()
        {
            int[][] Board = Model.GetBoard();
            AlteredBoard = new Model(Model);
            for(int x = 0; x < Model.Width; x++)
            {
                for(int y=Model.Height; y > Model.ColumnDepth[x]; y++)
                {
                    if (Board[y][x] == this.PlayerID) Board[y][x] = 1;
                    else Board[y][x] = -1;
                }
            }
            AlteredBoard.SetBoard(Board);
        }*/

        //player ID of computer = 1 and player ID of opponent = -1
        private int SelectColumn(List<int> results)
        {
            int preference = results.Count() / 2;
            int bestOption;
            int option;
            if (results.Exists(x => x == this.PlayerID)) option = this.PlayerID;
            else if (results.Contains(0)) option = 0;
            else option = this.PlayerID*-1;
            bestOption = results.IndexOf(option);
            for (int i = 0; i < results.Count(); i++)
            {
                if (results[i] == option)
                {
                    if (Math.Abs(i - preference) < bestOption) bestOption = i;
                } 
            }
            return bestOption;
        }
        /*
         * Start of MiniMax
         * returns list of values representing the weight for each column
         */
       private List<int> RunMiniMax(int player)
        {
            List<int> miniMax = new List<int>();
            for(int i=0; i < Model.Width; i++)
            {
                if (!Model.getPlayableColumns()[i]) miniMax[0]= (-999*player);
                Model newState = new Model(Model);
                newState.AddChecker(i, player);
                int res = AddLayer(player * -1, Depth - 1,newState);
                miniMax.Add(res);
            }
            
            return miniMax;
        }
        //recursive part of MiniMax
        private int AddLayer(int player, int depth, Model upperState)
        {
            for(int i=0;i < Model.Width;i++)
            {
                int result;
                if (upperState.getPlayableColumns()[i])
                {
                    Model recursiveState = new Model(upperState);
                    recursiveState.AddChecker(i, player);
                    Analyzer.Model = recursiveState;
                    Analyzer.PlayerID = player;
                    if (!Analyzer.CheckWin(i,player) && depth > 1)
                    {
                        result = AddLayer((player * -1), depth - 1, recursiveState);
                    }
                    else if (Analyzer.Draw) result = 0;
                    else if (Analyzer.CheckWin(i, player)) result = player;
                    else result = player * -1;

                    //alpha beta pruning
                    if (player == 1 && result > 0) return result;
                    if (player == -1 && result < 0) return result;
                }
            }
            return 0;
        }
    }
}
