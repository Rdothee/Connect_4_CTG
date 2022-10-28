using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4_CTG
{
    internal abstract class Player
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
        public bool IsPlaying { get; protected set; }
        public abstract void Play();
        
     
    }
}
