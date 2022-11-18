using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    /*
     * used to save a certain state of the board 
     */

    public class Model
    {
        public int Connect { get; set; }
        public int Height { get; private set; } = 0;
        public int Width { get; private set; } = 0;
        public int[] ColumnDepth { get; private set; } //keeps track of the next playable row for each column

        private int[][] Board; // Rows (Y) , Columns (X)
        private int NumberOfMoves = 0;
        private readonly int[] lastPlacedChecker = new int[2]; // Y,X
        public bool IsPlayable
        {
            get
            {
                if (NumberOfMoves == Height * Width) return false;
                return true;
            }
        }

        //used to make deep-copys of the model class
        public Model Clone()
        {
            Model newModel = (Model) MemberwiseClone();
            newModel.Height = Height;
            newModel.Width = Width;
            newModel.ColumnDepth = new int[ColumnDepth.Length];
            newModel.NumberOfMoves = NumberOfMoves;
            newModel.Board = new int[Height][];
            for (int j = 0; j < ColumnDepth.Length; j++) { newModel.ColumnDepth[j] = ColumnDepth[j]; }
            for(int row =0; row< Board.Length; row++) {
                newModel.Board[row] = new int[Width];
                for (int column=0; column < Board[row].Length; column++)
                {
                    newModel.Board[row][column] = Board[row][column];
                }
            }
            return newModel;
        }


        internal void CreateBoard(int rows, int columns)
        {
           Height = rows;
           Width = columns;
           Board = new int[rows][];
           ColumnDepth = new int[columns];
           for(int j = 0; j < ColumnDepth.Length; j++) { ColumnDepth[j] = rows-1;}
           for(int i = 0; i < Board.Length; i++) { Board[i]= new int[columns]; }
        }
        //add checker to board, can only be used for playable columns
        public void AddChecker( int column, int playerID)
        {
            Board[ColumnDepth[column]][column] = playerID;
            lastPlacedChecker[0] = ColumnDepth[column]; // Y
            lastPlacedChecker[1] = column; // X
            ColumnDepth[column]--;
            NumberOfMoves++;
        }

        //return the columns which are not full
        public bool[] getPlayableColumns()
        {
            bool[] playableColumns = new bool[Board[0].Length];
            for(int i = 0; i < Board[0].Length; i++)
            {
                if(IsColumnPlayable(i))
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

        public bool IsColumnPlayable(int col)
        {
            return Board[0][col] == 0;
        }

        public int[][] GetBoard()
        {
            return Board;
        }

        public int[] GetLastChecker()
        {
            return lastPlacedChecker;
        }

        public int GetNumberOfFreeSpaces()
        {
            return (Height * Width) - NumberOfMoves;
        }


    }
}
