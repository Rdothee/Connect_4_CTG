using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    // a concrete implementation of algorithm 
    internal class MiniMax : Algorithm
    {
        public MiniMax(Model model)
        {
        }


        internal override int GenerateSolution(Model board)
        {
            this.Board = board;
            throw new NotImplementedException();
        }

       private int negmax()
        {
            return 0;
        }
    }
}
