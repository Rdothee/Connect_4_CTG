using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    internal class Naive : Algorithm
    {

        internal override int GenerateSolution(Model model)
        {
            this.Model = model;
            Analyzer = new Analyzer();
            Analyzer.Model = model;
            return ChooseMove();
        }

        private int ChooseMove()
        {
            int instaWin = InstaWin(this.PlayerID);
            int instaLose = InstaWin(this.PlayerID * -1);
            if (instaWin != -1) return instaWin;
            if (instaLose != -1) return instaLose; //counter win of other player
            return MakeRandomMove();

        }

        private int MakeRandomMove()
        {
            int choice = 0;
            do
            {
                Random rnd = new Random();
                choice = rnd.Next();
                choice = choice % Model.getPlayableColumns().Length;
            }
            while (!Model.getPlayableColumns()[choice]) ; 

            return choice;
        }

      

    }
}
