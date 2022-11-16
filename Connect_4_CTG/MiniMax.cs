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
        public int Depth { get; set; } = 8; //depth of minimax lookup
        private Model newState;
        //private Model AlteredBoard;
        public MiniMax()
        {

        }

        protected override Analyzer Analyzer { get; set; }

        internal override int GenerateSolution(Model model)
        {
            this.Model = model;
            Analyzer = new Analyzer();
            Analyzer.Model = model;
           return ConsiderBest();
        }


       /* private int SelectColumn(List<int> results)
        {
            int preference = Model.Width / 2;
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
        }*/

        private int ConsiderBest()
        {
            List<int> best = new List<int>();
            List<int> results = RunMiniMax(this.PlayerID);
            for(int i = 0; i < results.Count; i++)
            {
                if (results[i] == results.Max()) best.Add(i);
            }
            if (best.Count == 1) return best[0];

            // if best is tied, pick most middle
            int[] centrals = new int[Model.Width];
            
            for(int i = 0; i < best.Count; i++)
            {
                centrals[i] = ((int)Math.Round((float)Model.Width/2,0)) - Math.Abs(3-i);
            }

            List<int> newBest = new List<int>();
            for (int i = 0; i < best.Count; i++)
            {
                if(centrals[i] == centrals.Max()) newBest.Add(i);
            }
            if(newBest.Count == 1) return newBest[0];
            else return newBest[Model.GetNumberOfFreeSpaces() % newBest.Count];
        }

        /*
         * Start of MiniMax
         * returns list of values representing the weight for each column
         */
       private List<int> RunMiniMax(int player)
        {
            List<int> miniMax = new List<int>();
            Console.Write("results: ");
            for(int i=0; i < Model.Width; i++)
            {
                if (!Model.IsColumnPlayable(i)) miniMax[0]= (-999*player);
                //Model newState = new Model(Model);
                Model newState = (Model)Model.Clone();
                newState.AddChecker(i, player);
                int res = AddLayer(player * -1, Depth - 1,newState);
                //Console.Write(res);
                miniMax.Add(res);
            }
            Console.WriteLine();
            return miniMax;
        }
        //recursive part of MiniMax
        private int AddLayer(int player, int depth, Model upperState)
        {
            int[] results = new int[upperState.Width];
            for (int i=0;i < Model.Width;i++)
            {
                int result;
                if (upperState.IsColumnPlayable(i))
                {
                    Model recursiveState = (Model)upperState.Clone();
                    recursiveState.AddChecker(i, player);
                    Analyzer.Model = recursiveState;
                    Analyzer.PlayerID = player;
                    if (Analyzer.CheckWin(i, player))
                    {
                        Draw draw = new Draw(recursiveState.Width,recursiveState.Height);
                        draw.AddColor(ConsoleColor.Yellow, -1);
                        draw.AddColor(ConsoleColor.Red, 1);
                        draw.Board(recursiveState.GetBoard());
                        Console.WriteLine("win found");
                    }
                    if (!Analyzer.CheckWin(i,player) && depth > 1)
                    {
                        result = AddLayer(player * -1, depth - 1, recursiveState);
                    }
                    else
                    {

                        if (!Analyzer.CheckWin(i, player)) result =0;
                        else if(player == this.PlayerID) result = 1;
                        else result = -1;
                    }
                    results.Append(result);

                    //alpha beta pruning
                    if (player == 1 && result > 0) return result;
                    if (player == -1 && result < 0) return result;
                }
            }
            if(player ==1) return results.Max();
            if(player == -1) return results.Min();
            return 0;
        }
    }
}
