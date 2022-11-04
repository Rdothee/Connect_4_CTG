﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    public class Model
    {

        private int[][] Board; // Rows (Y) , Columns (X)
        public int Height { get; private set; } = 0;
        public int Width { get; private set; } = 0;
        public int[] ColumnDepth { get; private set; }
        public int NumberOfMoves { get; private set; }
        private readonly int[] lastPlacedChecker = new int[2]; // Y,X
        public bool IsPlayable
        {
            get
            {
                foreach (bool space in getPlayableColumns()) 
                {
                    if (space) { return true; }
                }
                return false;
            }
        }
        public Model()
        {

        }
        //copy constructor
        public Model(Model oldModel)
        {
            Board = oldModel.Board;
            ColumnDepth = oldModel.ColumnDepth;
            lastPlacedChecker = oldModel.lastPlacedChecker;
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
        //add checker to board
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

        public int[][] GetBoard()
        {
            return Board;
        }

        public int[] GetLastChecker()
        {
            return lastPlacedChecker;
        }


    }
}
