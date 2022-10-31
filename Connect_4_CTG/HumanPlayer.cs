using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Connect_4_CTG
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name, ConsoleColor color) : base(name, color)
        {

        }

        public override int Play(bool[] options)
        {

            prompt(options);
            int choice = queryInput()-1;
            for(int i = 0; i < options.Length; i++)
            {
                if(i == choice)
                {
                    if (options[i]) return choice;
                }
            }
            WriteLine("enter valid number");
            return Play(options);
        }

        private void prompt(bool[] options)
        {
            WriteLine("");
            for (int i = 0; i < options.Length; i++) if (options[i]) Write($"Column {i+1}\t");
            WriteLine("");
            WriteLine("enter number of playable column:"); 
        }

        private int queryInput()
        {
            int choice;
            
            try
            {
                while (!int.TryParse(ReadLine(), out choice))
                {
                    WriteLine("that is invalid. Enter a valid Column number...");
                    ReadKey(true);
                }

            }
            catch (IOException)
            {
                WriteLine("input not well recieved try again...");
                return queryInput();
            }
            return choice;
        }
    }

}
