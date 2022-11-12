using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Connect_4_CTG
{
    public sealed class Controller
    {
        //properties
        private const int Columns = 8;
        private const int Rows = 7;
        private const int Connect = 4;
        public List<IPlayer> Players { get; set; }
        public bool WinState { get; private set; }

        //variables
        private static Controller Instance = null;
        // private List<IPlayer> Players = new List<IPlayer>();
        Analyzer Analyzer;
        private Model model = new Model();
        private int TurnCounter=0;
        private int[][] DirectionSteps = new int[4][];
        Draw Draw;
       
        //singleton design, a new instance is created when the game is won
         public static Controller GetInstance
        {
            get
            {
                if(Instance == null)
                {
                    Instance = new Controller();
                }
                else if(Instance.WinState) Instance = new Controller();
                return Instance;
            }
        }

        private Controller()
        {
            
        }

       /* public void AddPlayers(IPlayer player)
        {
           Players.Add(player);
           player.PlayerID = Players.IndexOf(player)+1;
        }*/

        public void StartGame()
        {
            WinState = false;
            model.CreateBoard(Rows, Columns);
            model.Connect = Connect;
            Draw = new Draw(Columns, Rows);
            Analyzer = new Analyzer();
            Clear();
            foreach (var player in Players) Draw.AddColor(player.Color, Players.IndexOf(player));
            //InitializeSteps();// used to initialize the different steps for determining the win
            while (!WinState)
            {
                Turn();
            }
        }

        private void Turn()
        {
            ++TurnCounter;
            foreach (var player in Players)
            {
                Clear();
                Analyzer.Model = model;
                PrintPlayerInfo(player);
                Draw.Board(model.GetBoard());
                int play = player.Play(model);
                model.AddChecker(play, player.PlayerID);
                CheckWin(player.PlayerID);
            }
        }

        private void CheckWin(int playerID)
        {
            Analyzer.PlayerID = playerID;
            Analyzer.Model = model;
            if(Analyzer.CheckWin(playerID)) Restart($"Player {Players[playerID - 1].Name} has Won!!!");
            if(Analyzer.Draw) Restart($"It's a draw, nobody won!!!");

        }

        private void PrintPlayerInfo(IPlayer player)
        {
            Write($"{player.Name}'s Turn: ");
            WriteLine(TurnCounter);
            Write("Checker:");
            ForegroundColor = player.Color;
            WriteLine(Players.IndexOf(player) + 1);
            ResetColor();
        }

        private void Restart(string prompt)
        {
            WinState = true;
            Clear();
            Draw.Board(model.GetBoard());
            WriteLine(prompt);
            WriteLine("Press Enter to return to Main Menu...");
            ReadKey(true);
            Connect_4 game = new Connect_4();
            game.Start();
        }

        //create direction to check for the win method
        /*private void InitializeSteps()
        {
            DirectionSteps[0] = new int[2] { -1, 0 }; //N
            DirectionSteps[1] = new int[2] { -1, 1 }; //NE
            DirectionSteps[2] = new int[2] { 0, 1 }; //E
            DirectionSteps[3] = new int[2] { 1, 1 }; //SE
        }
        //check if a player has won the game, use directions of DirectionSteps
        private void CheckWin(int[] lastPlayedChecker, int playerID, int[][]Board)
        {
            int xCenter = lastPlayedChecker[1];   // x-coordinate of tile placed last
            int yCenter = lastPlayedChecker[0];  // y-coordinate of tile placed last
            foreach (var directionStep in DirectionSteps)
            { 
                int matchingTiles = 1; // tile placed last is the first match

                // to check each direction also into the opposite direction
                // have a multiplier of -1 / 1 for each of them:
                for (int directionUpDown = -1; directionUpDown <= 1; directionUpDown += 2)
                {
                    int xStep = directionStep[1] * directionUpDown;
                    int yStep = directionStep[0] * directionUpDown;

                    // "walk" into the current direction, starting 1 tile away;
                    for (int distance = 1; distance <= Connect+1; distance++)
                    {
                        // now "looking" at these coordinates:
                        int x = xCenter + xStep * distance;
                        int y = yCenter + yStep * distance;

                        if (IsOutsideOfGrid(x, y))
                            break;

                        if (Board[y][x] == playerID)
                            matchingTiles++;
                        else
                            break;
                    }
                }

                if (matchingTiles >= Connect) 
                {
                    Restart($"Player {Players[playerID - 1].Name} has Won!!!");
                };
}
        }

        private void CheckForDrawGame()
        {
            if (!model.IsPlayable)
            {
                Restart($"It's a draw, nobody won!!!");
            }
        }
        //restarts connect-4, back to main menu
        private void Restart(string prompt)
        {
            WinState = true;
            Clear();
            Draw.Board(model.GetBoard());
            WriteLine(prompt);
            WriteLine("Press Enter to return to Main Menu...");
            ReadKey(true);
            Connect_4 game = new Connect_4();
            game.Start();
        }

        private bool IsOutsideOfGrid(int x, int y)
        {
            if(x < 0 || y < 0) { return true; }
            else if(x > Columns-1 || y > Rows-1) { return true; }
            return false;
        }*/
    }
}
