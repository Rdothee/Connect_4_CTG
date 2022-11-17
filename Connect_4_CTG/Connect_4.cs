using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace Connect_4_CTG
{
    /*
     * This class is responsible for all menu's in the game 
     */
    internal class Connect_4
    {
        private string Banner=" ";


        public void Start()
        {
            Title = "Connect-4";
            Banner = System.IO.File.ReadAllText(@"Banner.txt");
            RunMainMenu();   
        }

        private void RunMainMenu()
        {
           string prompt = Banner;
            prompt += @"
Welcome to Connect-4. What would you like to do?
use the arrow keys to cycle through options and press enter to select an option."";
---Main menu---";
            string[] options = { "Play", "About", "Exit" };
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
            string prompt = $"Quickly start a game against the computer OR choose opponent and board size";
            string[] options = { "Quickstart", "Custom" };
            Menu gameTypeMenu = new Menu(options, prompt);
            int selectedIndex = gameTypeMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    QuickStart();
                    break;
                case 1:
                    CustomStart();
                    break;
                default:
                    CustomStart();
                    break;

            }
        }

        private void CustomStart()
        {
            List<IPlayer> players = new List<IPlayer>();
            players.Add(new HumanPlayer("player 1", ConsoleColor.Red, 1));
            Clear();
            players.Add(ChoosePlayerType());

            Controller controller = Controller.GetInstance;
            controller.Players = players;
            controller.StartGame();

        }

        private void QuickStart()
        {
            //set players
            List<IPlayer> players= new List<IPlayer>();
            ComputerPlayer computer = new ComputerPlayer("MiniMax (5)", ConsoleColor.Yellow, -1);
            computer.Algorithm = new MiniMax();
            players.Add(new HumanPlayer("player 1",ConsoleColor.Red,1));
            players.Add(computer);

            //start game
            Controller controller = Controller.GetInstance;
            controller.Players = players;
            controller.StartGame();
        }


        private Player CreateNewPlayer(string name, ConsoleColor color, int playerID)
        {
            /*if(playerType == 0)
            {
                return new HumanPlayer(name, color);
            }
            else
            {
                return new ComputerPlayer(name, color);
            }*/
            return new HumanPlayer(name, color,playerID);
        }

        private IPlayer ChoosePlayerType()
        {
                string prompt = "Select opponent:";
                string[] options = { "Human player" ,"Computer1: Naive (easy)", "Computer2: MiniMax(Depth 4)", "Computer3: MiniMax(Depth 6)"};
                Menu playerMenu = new Menu(options, prompt);
                int selectedIndex = playerMenu.Run();
            ComputerPlayer computer;
            switch (selectedIndex)
            {
                case 0:
                    return new HumanPlayer("Player 2", ConsoleColor.Yellow, -1);
                      
                case 1:
                    computer = new ComputerPlayer("Naive ", ConsoleColor.Yellow, -1);
                    computer.Algorithm = new Naive();
                    return computer;
                case 2:
                    computer = new ComputerPlayer("MiniMax (4)", ConsoleColor.Yellow, -1);
                    computer.Algorithm = new MiniMax(4);
                    return computer;
                case 3:
                    computer = new ComputerPlayer("MiniMax (6)", ConsoleColor.Yellow, -1);
                    computer.Algorithm = new MiniMax(6);
                    return computer;
                default:
                    computer = new ComputerPlayer("MiniMax (5)", ConsoleColor.Yellow, -1);
                    computer.Algorithm = new MiniMax();
                    return computer;


            }

        }


        //unused extras
        /*private ConsoleColor AskColor()
        {
            string prompt = $"What color would you like to play as?";
            string[] options = { "Red", "Green", "Blue", "Yellow" };
            Menu colorMenu = new Menu(options, prompt);
            int selectedIndex = colorMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    return ConsoleColor.Red;
                case 1:
                    return ConsoleColor.Green;                 
                case 2:
                    return ConsoleColor.Blue;                  
                case 3:
                    return ConsoleColor.Yellow;                  
                default:
                    return ConsoleColor.Magenta;
                    

            }
        }

        private string ChooseName()
        {
           WriteLine($"type your name");
            try
            {
                string name = ReadLine();
                return name;
            }
            catch(IOException)
            {
                WriteLine("Can't choose a name? Let's call you John.");
                return "John Doe";
            }
        }*/
    }
}
