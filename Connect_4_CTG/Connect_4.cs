﻿using System;
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
        private string Banner=" ";
        private string Player; 


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
Welcom to Connect-4. What would you like to do?
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
           
            
        }

        private void GameType()
        {
            string prompt = $"Quickly start a game OR customise some properties";
            string[] options = { "Quickstart", "Custome"};
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
            Clear();
            Player = "Player 1";
            Player player1 = CreateNewPlayer();
            Clear();
            Player = "Player 2";
            Player player2 = CreateNewPlayer();
        }

        private void QuickStart()
        {
            Player player1 = CreateNewPlayer("player1",ConsoleColor.Red,0);
            Player player2 = CreateNewPlayer("player1", ConsoleColor.Red, ); ;
        }

        private Player CreateNewPlayer()
        {
            string playerName = ChooseName();
            ConsoleColor color = AskColor();
            int playerType = SetPlayerType();

            throw new NotImplementedException();
        }

        private Player CreateNewPlayer(string name, ConsoleColor color, int playerType)
        {
            if(playerType == 0)
            {
                Player player = new HumanPlayer();
            }
            else
            {
                Player player = new Bot();
            }

            throw new NotImplementedException();
        }

        private int SetPlayerType()
        {
            if(Player.Equals("Player 1"))
            {
                return 0;
                WriteLine("Player one is always human");
            }
            else
            {
                string prompt = "(PLAYER1) What color would you like to play as?";
                string[] options = { "Red", "Green", "Blue", "Yellow" };
                Menu colorMenu = new Menu(options, prompt);
                int selectedIndex = colorMenu.Run();
                return selectedIndex;
            }
        }

        private ConsoleColor AskColor()
        {
            string prompt = $"{Player} What color would you like to play as?";
            string[] options = { "Red", "Green", "Blue", "Yellow" };
            Menu colorMenu = new Menu(options, prompt);
            int selectedIndex = colorMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    return ConsoleColor.Red;
                    break;
                case 1:
                    return ConsoleColor.Green;
                    break;
                case 2:
                    return ConsoleColor.Blue;
                    break;
                case 3:
                    return ConsoleColor.Yellow;
                    break;
                default:
                    return ConsoleColor.Magenta;
                    break;

            }
        }

        private string ChooseName()
        {
           WriteLine($"type name of {Player}");
            try
            {
                string name = ReadLine();
                return name;
            }
            catch(IOException e)
            {
                WriteLine("Can't choose a name? Let's call you John.");
                return "John Doe";
            }
        }
    }
}
