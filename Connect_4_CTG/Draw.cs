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
        private int Columns;
        private int Rows;
        private int FullWidthRaster;
        private List<ConsoleColor> Colors  = new List<ConsoleColor>();
        private string Block = System.IO.File.ReadAllText("Block.txt");

        public void AddColor(ConsoleColor color,int playerIndex)
        {
            Colors.Insert(playerIndex,color);
        }

        public Draw(int nrColumns, int nrRows)
        {
            Columns = nrColumns;
            Rows = nrRows;
            FullWidthRaster = Thickness * (nrColumns + 1) + BoxWidth * nrColumns; //calculates the full width of the raster
        }

        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public void Board(int[][] Board)
        {
            for(int i = 0; i < Board.Length; i++)
            {
                FullLine();
                for (int j = 0; j < BoxHeight; j++) BoxRow(Board[i]);
            }
            FullLine();
           
        }

        private void BoxRow(int[]row)
        {
            for(int i=0; i<row.Length; i++)
            {
                BoxPart(row[i]);
            }
            Edge();
            WriteLine("");
        }

        private void BoxPart(int playerIndex)
        {
            Edge();
            if (playerIndex == 0)
            {
                for (int J = 0; J < BoxWidth; J++) Write(" ");
            }
            else
            {
                ForegroundColor = Colors[playerIndex-1];
                for (int J = 0; J < BoxWidth; J++) Write("#");
            }
            ResetColor();
        }

        private void FullLine()
        {
            for(int i = 0; i < FullWidthRaster; i++)  Write(Block);
            WriteLine("");
        }


        private void Edge()
        {
            for(int i=0;i<Thickness;i++)  Write(Block);   
        }

    }
}
