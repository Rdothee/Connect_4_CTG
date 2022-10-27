using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using static System.Console;

namespace Connect_4_CTG
{
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



            }while(keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}