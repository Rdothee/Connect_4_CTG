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
            List<string> soptions = new List<string>();
            for (int i = 0; i < options.Length; i++) if (options[i]) soptions.Add($"Column {i}");

            Menu controls = new Menu(soptions.ToArray(),"choose column to play on");
            return controls.Run();
        }
    }
  
}
