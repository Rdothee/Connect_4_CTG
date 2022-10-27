using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace Connect_4_CTG
{
    internal class Connect_4
    {
        public void Start()
        {
            
            WriteLine("The game is starting!...\n\n");

            string prompt = "Welcom to Connect-4. What would you like to do?";
            String[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(options, prompt);
            int selectedIndex = mainMenu.Run();
            

            WriteLine("press any key to exit...");

            ReadKey(true);
            
        }
    }
}
