using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static System.Console;

namespace Connect_4_CTG
{
    /*
     * class used for all menus
     * functions: drawing of the menu, recieving and returning input.
     */
    internal class Menu
    {
        private int SelectedIndex;
        private String[] Options;
        private String Prompt;

        public Menu( string[] options, string prompt)
        {
            SelectedIndex = 0;
            Options = options;
            Prompt = prompt;
        }

        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for(int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if ( i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White; 
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;

            do
            {
                Clear();
                DisplayOptions();


                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //update selectedIndex based on arrow key
                if(keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex > Options.Length-1)
                    {
                        SelectedIndex = 0;
                    }
                }



            }while(keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}