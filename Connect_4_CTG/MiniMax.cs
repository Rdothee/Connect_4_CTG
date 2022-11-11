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
        public int Depth { get; set; } = 2;
        private Model newState;
        //private Model AlteredBoard;
        public MiniMax()
        {
            this.PlayerID = 1;
        }

        protected override Analyzer Analyzer { get; set; }

        internal override int GenerateSolution(Model model)
        {
            this.Model = model;
           // AlterBoard();
            Analyzer = new Analyzer();
            Analyzer.Model = model;
            throw new NotImplementedException();
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
       private List<int> StartMiniMax()
        {
            List<int> miniMax = new List<int>();
            for(int i=0; i < Model.Width; i++)
            {
                if (!Model.getPlayableColumns()[i]) miniMax[0]= (-999*this.PlayerID);
                Model newState = new Model(Model);
                newState.AddChecker(i, this.PlayerID);
                int res = AddLayer(this.PlayerID * -1, Depth - 1,newState);
                miniMax.Add(res);
            }
            
            return miniMax;
        }

        private int AddLayer(int player, int depth, Model upperState)
        {
            List<int> results = new List<int>();
            for(int i=0;i < Model.Width;i++)
            {
                int result;
                if (upperState.getPlayableColumns()[i])
                {
                    Model recursiveState = new Model(upperState);
                    newState.AddChecker(i, this.PlayerID);
                    Analyzer.Model = recursiveState;
                    Analyzer.PlayerID = player;
                    if (!Analyzer.Win && depth > 1)
                    {
                        result = AddLayer(player * -1, depth - 1, recursiveState);
                    }
                    else if (Analyzer.Draw) result = 0;
                    else if (Analyzer.Win) result = player;
                    else result = player * -1;
                    results.Add(result);

                    //alpha beta pruning
                    if (player == 1 && result > 0) return result;
                    if (player == -1 && result < 0) return result;
                }
            }
            if (player == 1) return results.Max();
            if (player == -1) return results.Min();
            return 0;
        }
    }
}
