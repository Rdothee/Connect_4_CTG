using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Connect_4_CTG
{
    internal static class Menu
    {

        public static void MainMenu()
        {
            PrintMenu();
            bool Chosen = false;
            while (!Chosen)
            {
                String input = ReadInput();
                switch (input)
                {
                    case "1":


                    case "2":


                    case "3":
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Enter number from 1 to 3 ");
                        Chosen = false;
                        break;

                }
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("---- Connect 4 ----");
            Console.WriteLine("\t1) Start Game");
            Console.WriteLine("\t2) Select Players");
            Console.WriteLine("\t3) Exit");
            Console.Write("\r\nSelect an option: ");
        }

        private static String ReadInput()
        {
            String input = null;
            try
            {
                    input = Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("---IOexception occured---");
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);

            }
            return input;
        }
    }
}