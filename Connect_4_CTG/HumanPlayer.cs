using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Connect_4_CTG
{
    /*
     * class that manages the human player 
     * recieves and returns input
     * print's info for player
     */
    internal class HumanPlayer : Player
    {
        private bool[] Options;
        public HumanPlayer(string name, ConsoleColor color,int playerID) : base(name, color,playerID)
        {

        }

        public override int Play(Model Board)
        {
            Options = Board.getPlayableColumns();
            prompt(Options);
            int choice = queryInput();
            if(choice >= 0 && choice < Options.Length)
            {
                if (Options[choice]) return choice;
            }
            WriteLine("enter valid number:");
            return Play(Board);
        }

        private void prompt(bool[] options)
        {
            WriteLine("Playable Columns are:");
            for (int i = 0; i < options.Length; i++) if (options[i]) Write($" {i+1} ");
            WriteLine("");
            WriteLine("");
            WriteLine("Please enter the number of a playable Column to place a checker...");
        }

        private int queryInput()
        {
            int choice;
            
            try
            {
                while (!int.TryParse(ReadLine(), out choice))
                {
                    WriteLine("that is invalid. Enter a valid Column number...");
                }

            }
            catch (IOException)
            {
                WriteLine("input not well recieved try again...");
                return queryInput();
            }
            return choice-1;
        }
    }

}
