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
     * and initializes the controller and players
     */
    internal class Connect_4
    {
        private string Banner=" ";
        private const int playerID = 1;
        private const int opponentID = -1;

        public void Start()
        {
            Title = "Connect-4";
            try
            {
                Banner = System.IO.File.ReadAllText(@"Banner.txt");
            }
            catch (IOException) { Banner = "--- Banner not found ---\n\n"; }
           
            RunMainMenu();   
        }

        private void RunMainMenu()
        {
           string prompt = Banner;
            prompt += @"
Welcome to Connect-4. What would you like to do?
use the arrow keys to cycle through options and press enter to select an option."";
 !  Disclaimer: It's important to maximize the window of the console application for the best experience  !
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
                    QuickStart();
                    break;

            }
        }

        private void CustomStart()
        {
            List<IPlayer> players = new List<IPlayer>();
            players.Add(new HumanPlayer("player 1", ConsoleColor.Red, playerID));
            Clear();
            players.Add(ChoosePlayerType());

            Controller controller = Controller.GetInstance;
            controller.Players = players;
            controller = ChooseBoardType(controller);
            controller.StartGame();

        }

        private void QuickStart()
        {
            //set players
            List<IPlayer> players = new List<IPlayer>();
            ComputerPlayer computer = new ComputerPlayer("MiniMax (5)", ConsoleColor.Yellow, opponentID);
            computer.Algorithm = new MiniMax();
            players.Add(new HumanPlayer("player 1", ConsoleColor.Red, playerID));
            players.Add(computer);

            //start game
            Controller controller = Controller.GetInstance;
            controller.Players = players;
            controller.StartGame();
        }


        private Controller ChooseBoardType(Controller controller)
        {
            string prompt = $"Choose the game size:";
            string[] options = { "Connect-3 (3x3)", "Connect-4 (6x7)","Connect-5 (15x15)" };
            Menu gameTypeMenu = new Menu(options, prompt);
            int selectedIndex = gameTypeMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    controller.Columns = 3;
                    controller.Rows = 3;
                    controller.Connect = 3;
                    return controller;
                case 1:
                    return controller; //connect-4 is the default init
                case 2:
                    controller.Columns = 15;
                    controller.Rows = 15;
                    controller.Connect = 5;
                    return controller;
                default:
                    return controller;

            }
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
                    return new HumanPlayer("Player 2", ConsoleColor.Yellow, opponentID);
                      
                case 1:
                    computer = new ComputerPlayer("Naive ", ConsoleColor.Green, opponentID);
                    computer.Algorithm = new Naive();
                    return computer;
                case 2:
                    computer = new ComputerPlayer("MiniMax (4)", ConsoleColor.DarkCyan, opponentID);
                    computer.Algorithm = new MiniMax(4);
                    return computer;
                case 3:
                    computer = new ComputerPlayer("MiniMax (6)", ConsoleColor.DarkMagenta, opponentID);
                    computer.Algorithm = new MiniMax(6);
                    return computer;
                default:
                    computer = new ComputerPlayer("MiniMax (5)", ConsoleColor.Yellow, opponentID);
                    computer.Algorithm = new MiniMax();
                    return computer;


            }

        }
    }
}
