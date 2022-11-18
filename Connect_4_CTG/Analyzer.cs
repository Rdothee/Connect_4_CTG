using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    internal class Analyzer
    {
        /*
         * Analyzer is used to check for wins or Draw
         * When using the analyzer always set the model property 
         */

        public Model Model { get; set; }
        public int PlayerID = 0;   
  
      

        private int[][] DirectionSteps = new int[4][];
        private int Connect=4;

       

        public Analyzer()
        {
            InitializeSteps();
        }

        //create direction to check for the win method
        private void InitializeSteps()
        {
            DirectionSteps[0] = new int[2] { -1, 0 }; //N
            DirectionSteps[1] = new int[2] { -1, 1 }; //NE
            DirectionSteps[2] = new int[2] { 0, 1 }; //E
            DirectionSteps[3] = new int[2] { 1, 1 }; //SE
        }
        //check if a player has won the game, after last played checker
        public bool CheckWin(int playerID)
        {
            this.PlayerID = playerID;
            int[] lastPlayedChecker = Model.GetLastChecker();
            int xCenter = lastPlayedChecker[1];   // x-coordinate of tile placed last
            int yCenter = lastPlayedChecker[0];  // y-coordinate of tile placed last
            return MakesAlignment(xCenter, yCenter);
        }

        //check if player wins the game, if a certain column is played
        public bool CheckWin(int col,int playerID)
        {
            this.PlayerID = playerID;
            int xCenter = col;   // x-coordinate of tile placed last
            int yCenter = Model.ColumnDepth[col];  // y-coordinate of tile placed last
            return MakesAlignment(xCenter, yCenter);
        }

        private bool MakesAlignment(int xCenter, int yCenter)
        {
            int[][] Board = Model.GetBoard();
            Connect = Model.Connect;
            foreach (var directionStep in DirectionSteps)
            {
                int matchingTiles = 1; // tile placed last is the first match

                // to check each direction also into the opposite direction
                // have a multiplier of -1 / 1 for each of them:
                for (int directionUpDown = -1; directionUpDown <= 1; directionUpDown += 2)
                {
                    int xStep = directionStep[1] * directionUpDown;
                    int yStep = directionStep[0] * directionUpDown;

                    // "walk" into the current direction, starting 1 tile away;
                    for (int distance = 1; distance <= Connect; distance++)
                    {
                        // now "looking" at these coordinates:
                        int x = xCenter + xStep * distance;
                        int y = yCenter + yStep * distance;

                        if (IsOutsideOfGrid(x, y))
                            break;

                        if (Board[y][x] == PlayerID)
                            matchingTiles++;
                        else
                            break;
                    }
                }

                if (matchingTiles >= Connect)
                {
                    return true;
                };
              
            }
            return false;
        }

        public bool CheckForDrawGame()
        {
            if (!Model.IsPlayable)
            {
                return true;
            }
            return false;
        }
        private bool IsOutsideOfGrid(int x, int y)
        {
            if (x < 0 || y < 0) { return true; }
            else if (x > Model.Width - 1 || y > Model.Height - 1) { return true; }
            return false;
        }
    }
}
