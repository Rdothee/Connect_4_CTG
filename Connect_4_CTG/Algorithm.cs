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
        public int Player { get; internal set; }

        internal abstract int GenerateSolution(Model Board);

        protected bool MakesAlignment(int column)
        {
            return true;
        }
    }
}
