using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    // a concrete implementation of algorithm 

    /*
     * http://blog.gamesolver.org/solving-connect-four/03-minmax/
     * 
 * Recursively solve a connect 4 position using negamax variant of min-max algorithm.
 * @return the score of a position:
 *  - 0 for a draw game
 *  - positive score if you can win whatever your opponent is playing. Your score is
 *    the number of moves before the end you can win (the faster you win, the higher your score)
 *  - negative score if your opponent can force you to lose. Your score is the oposite of 
 *    the number of moves before the end you will lose (the faster you lose, the lower your score).
 */

    internal class MiniMax : Algorithm
    {
        public MiniMax(Model model)
        {
        }


        internal override int GenerateSolution(Model board)
        {
            this.Model = board;

            throw new NotImplementedException();
        }

       private int Negmax()
        {
            bool[] playableColumns = Model.getPlayableColumns();
            for(int i=0; i< Model.Width; i++)
            {
                if (playableColumns[i]) ;
            }
            return 0;
        }
    }
}
