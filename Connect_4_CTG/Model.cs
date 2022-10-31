using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    internal class Model
    {

        private static Model Instance = null;
        public static int[][] Board;
        public static int[] ColumnDepth { private set; get; }
        private Model()
        {

        }

        public static Model GetInstance
        {
            get
            {
                if (GetInstance == null)
                {
                    Instance = new Model();
                }
                return Instance;
            }
        }

        internal static void CreateBoard(int rows, int columns)
        {

           Board = new int[rows][];
           ColumnDepth = new int[columns];
           for(int j = 0; j < ColumnDepth.Length; j++) { ColumnDepth[j] = rows;}
           for(int i = 0; i < Board.Length; i++) { Board[i]= new int[columns]; }
        }

        public void AddChecker( int column, int playerID)
        {
            ColumnDepth[column]++;
            Board[ColumnDepth[column]][column] = playerID;
        }

        public bool[] getPlayableColumns()
        {
            bool[] playableColumns = new bool[Board[0].Length];
            for(int i = 0; i < Board[0].Length; i++)
            {
                if(Board[0][i] == 0)
                {
                    playableColumns[i] = true;
                }
                else
                {
                    playableColumns[i] = false;
                }
            }
            return playableColumns;
        }
    }
}
