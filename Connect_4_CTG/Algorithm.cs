using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    //bridge design computerPlayer <-> Algorithm: implementor
    internal abstract class Algorithm
    {
        internal abstract int GenerateSolution(Model Board);

        public int PlayerID { get; internal set; }
        protected Model Model = new Model();
        protected Analyzer Analyzer;




        /*private int[][] DirectionSteps = new int[4][];
        protected Model Board = new Model();
        public int PlayerID { get; internal set; }

       


        //3 methods used to check if an alignment is formed for a certain playable column
        private void InitializeSteps()
        {
            DirectionSteps[0] = new int[2] { -1, 0 }; //N
            DirectionSteps[1] = new int[2] { -1, 1 }; //NE
            DirectionSteps[2] = new int[2] { 0, 1 }; //E
            DirectionSteps[3] = new int[2] { 1, 1 }; //SE
        }

        private bool IsOutsideOfGrid(int x, int y)
        {
            if (x < 0 || y < 0) { return true; }
            else if (x > Board.Width - 1 || y > Board.Height - 1) { return true; }
            return false;
        }

        protected bool MakesAlignment(int column)
        {
            InitializeSteps();
            int xCenter = column;   // x-coordinate of tile placed last
            int yCenter = Board.ColumnDepth[column];  // y-coordinate of tile placed last
            foreach (var directionStep in DirectionSteps)
            {
                int matchingTiles = 0; 

                // to check each direction also into the opposite direction
                // have a multiplier of -1 / 1 for each of them:
                for (int directionUpDown = -1; directionUpDown <= 1; directionUpDown += 2)
                {
                    int xStep = directionStep[1] * directionUpDown;
                    int yStep = directionStep[0] * directionUpDown;

                    int x = xCenter + xStep;
                    int y = yCenter + yStep;

                    if (IsOutsideOfGrid(x, y))
                        break;

                    if (Board.GetBoard()[y][x] == PlayerID)
                        return true;

                }
            }
            return false;
        }*/



    }
}
