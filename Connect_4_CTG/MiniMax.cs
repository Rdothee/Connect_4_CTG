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
     * playerID
     *  -1 and 1
     *  
     */

    internal class MiniMax : Algorithm
    {
        public int Depth { get; set; } = 5; //depth of minimax lookup


        public MiniMax()
        {

        }

        public MiniMax(int depth)
        {
            this.Depth = depth;
        }

        // protected override Analyzer Analyzer { get; set; }

        internal override int GenerateSolution(Model model)
        {
            this.Model = model;
            Analyzer = new Analyzer();
            Analyzer.Model = model;
           return ChooseMove();
        }

        private int ChooseMove()
        {
            int instaWin = InstaWin(this.PlayerID);
            int instaLose = InstaWin(this.PlayerID*-1);
            if (instaWin != -1) return instaWin;
            if (instaLose != -1) return instaLose; //counter win of other player
            return ConsiderBest();
            
        }

        private int ConsiderBest()
        {
            List<int> best = new List<int>();
            List<int> results = RunMiniMax(this.PlayerID);
            int minOrMax;
            if (this.PlayerID == 1) { minOrMax = results.Max(); }
            else minOrMax = results.Min();
            for(int i = 0; i < results.Count; i++)
            {
                if (results[i] == minOrMax) best.Add(i);
            }
            if (best.Count == 1) return best[0];

            // if best is tied, pick most middle
            int[] centrals = new int[Model.Width];
            int preference = ((int)Math.Round((float)Model.Width / 2, 0));
            foreach (int i in best)
            {
                centrals[i] = preference - Math.Abs((preference-1)-i);
            }

            List<int> newBest = new List<int>();
            foreach (int i in best)
            {
                if(centrals[i] == centrals.Max()) newBest.Add(i);
            }
            if(newBest.Count == 1) return newBest[0];
            else return newBest[Model.GetNumberOfFreeSpaces() % newBest.Count];
        }

        /*
         * core of MiniMax
         * returns list of values representing the weight for each column
         */
       private List<int> RunMiniMax(int player)
        {
            List<int> miniMax = new List<int>();
            Console.Write("results: ");
            for(int i=0; i < Model.Width; i++)
            {
                if (!Model.IsColumnPlayable(i)) 
                {
                    miniMax.Add(-999 * player);
                    continue;
                } 
                Model newState = (Model)Model.Clone();
                newState.AddChecker(i, player);
                int res = AddLayer(player * -1, Depth - 1,newState);
                Console.Write(res);
                miniMax.Add(res);
            }
            Console.WriteLine();
            return miniMax;
        }

        //recursive part of MiniMax
        private int AddLayer(int player, int depth, Model upperState)
        {
            List<int> results = new List<int>();
            for (int i=0;i < Model.Width;i++)
            {
                int result;
                if (upperState.IsColumnPlayable(i))
                {
                    Model recursiveState = (Model)upperState.Clone();
                    recursiveState.AddChecker(i, player);
                    Analyzer.Model = recursiveState;
                    Analyzer.PlayerID = player;
                    if (!Analyzer.CheckWin(player) && depth > 1)
                    {
                        result = AddLayer(player * -1, depth - 1, recursiveState);
                    }
                    else
                    {

                        if (!Analyzer.CheckWin(player)) result =0;
                        else if(player == 1) result = 1;
                        else result = -1;
                    }
                    results.Add(result);

                    //alpha beta pruning
                    if (player == 1 && result > 0) return result;
                    if (player == -1 && result < 0) return result;
                }
            }
            if (results.Count() == 0) return 0;
            if(player ==1) return results.Max();
            if(player == -1) return results.Min();
            return 0;
        }
    }
}
