using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Connect_4_CTG
{
    internal class Draw
    {
        private const int BoxWidth = 7;
        private const int BoxHeight = 3;
        private const int Thickness = 2;
        private const string Horizontal = "\t";
        private int Columns;
        private int Rows;
        private int FullWidthRaster;
        private Dictionary<int,ConsoleColor> Colors  = new Dictionary<int, ConsoleColor>();
        private string Block = System.IO.File.ReadAllText("Block.txt");

        public void AddColor(ConsoleColor color,int playerIndex)
        {
            Colors.Add(playerIndex,color);
        }

        public Draw(int nrColumns, int nrRows)
        {
            Columns = nrColumns;
            Rows = nrRows;
            FullWidthRaster = Thickness * (nrColumns + 1) + BoxWidth * nrColumns; //calculates the full width of the raster
        }

        // draws up the board
        public void Board(int[][] Board)
        {
            Write("\n");
            Write(Horizontal);
            IndicateColumns();
            for(int i = 0; i < Board.Length; i++)
            {
                Write(Horizontal);
                FullLine();
                for (int j = 0; j < BoxHeight; j++) {
                    Write(Horizontal);
                    BoxRow(Board[i]);
                }
            }
            Write(Horizontal);
            FullLine();
           
        }

        //crate a full row of boxes 
        private void BoxRow(int[]row)
        {
            for(int i=0; i<row.Length; i++)
            {
                BoxPart(row[i]);
            }
            Edge();
            WriteLine("");
        }

        //fills box with spaces (no checker) or the appropriate color
        private void BoxPart(int playerIndex)
        {
            Edge();
            if (playerIndex == 0)
            {
                for (int J = 0; J < BoxWidth; J++) Write(" ");
            }
            else
            {
                ConsoleColor color;
                Colors.TryGetValue(playerIndex, out color);
                ForegroundColor = color;
                for (int J = 0; J < BoxWidth; J++) Write(color.ToString().Substring(0,1));
            }
            ResetColor();
        }

        //crates a line to separate rows 
        private void FullLine()
        {
            for(int i = 0; i < FullWidthRaster; i++)  Write(Block);
            WriteLine("");
        }

        //creates a single edge for the box
        private void Edge()
        {
            for(int i=0;i<Thickness;i++)  Write(Block);   
        }

        private void IndicateColumns()
        {
            for(int j = 0; j < BoxWidth/2+Thickness; j++) Write(" ");
            for (int i=0; i < Columns; i++)
            {
                Write(i+1);
                int margin = 1;
                if (i >= 9) margin = 0;
                for (int j = 0; j < BoxWidth+margin; j++) Write(" ");
            }
            WriteLine("");
        }

    }
}
