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
       
        protected abstract Analyzer Analyzer { get; set; }
        public int PlayerID { get; internal set; }
        protected Model Model = new Model();







    }
}
