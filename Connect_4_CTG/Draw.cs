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
        private ConsoleColor[] Colors  { get; set; }
        private string Block = System.IO.File.ReadAllText("Block.txt");

        public void AddColor(ConsoleColor color,int playerIndex)
        {
            Colors[playerIndex]=color;
        }

        public Draw(int nrColumns, int nrRows)
        {
            Columns = nrColumns;
            Rows = nrRows;
            FullWidthRaster = Thickness * (nrColumns + 1) + BoxWidth * nrRows; //calculates the full width of the raster
        }

        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public void DrawBoard(int[][] Board)
        {
           
        }

        private void DrawBoxRow()
        {

        }

        private void DrawBoxPart(int playerIndex)
        {
            DrawEdge();
            if (playerIndex == 0)
            {
                for (int J = 0; J < Columns; J++) WriteLine(" ");
            }
            else
            {
                ForegroundColor = Colors[playerIndex];
                for (int J = 0; J < Columns; J++) WriteLine("#");
            }
        }

        private void DrawFullLine()
        {
            for(int i = 0; i < FullWidthRaster; i++)  WriteLine("\t"+Block); 
        }


        private void DrawEdge()
        {
            for(int i=0;i<Thickness;i++)  WriteLine(Block);   
        }
    }
}
