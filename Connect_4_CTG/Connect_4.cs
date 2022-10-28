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
        private String Banner=" ";
        public void Start()
        {
            Title = "Connect-4";
            Banner = System.IO.File.ReadAllText(@"Banner.txt");
            RunMainMenu();   
            
        }

        private void RunMainMenu()
        {
            WriteLine("The game is starting!...\n\n");
           string prompt = Banner;
            prompt += @"
Welcom to Connect-4. What would you like to do?
use the arrow keys to cycle through options and press enter to select an option."";
---Main menu---";
            String[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(options, prompt);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;

            }
        }

        private void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            Clear();
            try
            {
                string info = System.IO.File.ReadAllText(@"AboutInfo.txt");
                WriteLine(info);
            }
            catch(IOException e)
            {
                WriteLine("--Could not load file--");
                WriteLine(e.ToString());
            }
            WriteLine("\n\nPress any key to return to Main menu...");
            ReadKey(true);
            RunMainMenu();

        }

        private void RunFirstChoice()
        {

        }
    }
}
