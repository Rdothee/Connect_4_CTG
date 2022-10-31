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
            int choice=99999;
            prompt(options);
            try
            {
                    while (!int.TryParse(ReadLine(), out choice) && !options[choice - 1])
                    {
                        WriteLine("that as invalid. Enter a valid Column number...");
                        ReadKey(true);
                    }
            
            }
            catch (IOException)
            {
                WriteLine("input not well recieved try again...");
                return Play(options);
            }

            return choice-1;
        }

        private void prompt(bool[] options)
        {
            WriteLine("");
            for (int i = 0; i < options.Length; i++) if (options[i]) Write($"Column {i+1}\t");
            WriteLine("");
            WriteLine("enter number of playable column:"); 
        }
    }

}
