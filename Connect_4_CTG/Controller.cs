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
        private const int Columns = 7;
        private const int Rows = 6;
        private const int Connect = 4;
        public bool WinState { get; private set; }

        //variables
        private static Controller Instance = null;
        private List<IPlayer> Players = new List<IPlayer>();
        private Model model = new Model();
        private int TurnCounter=0;
        private int[][] DirectionSteps = new int[4][];
        Draw Draw;
       
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

        public Controller()
        {
            WinState = false;
            model.CreateBoard(Rows, Columns);
            Draw = new Draw(Columns,Rows);
        }

        public void AddPlayers(IPlayer player)
        {
           Players.Add(player);
        }

        public void StartGame()
        {
            Clear();
            foreach (var player in Players) Draw.AddColor(player.Color, Players.IndexOf(player));
            InitializeSteps();// used to initialize the different steps for determining the win
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
                int playerID = Players.IndexOf(player)+1; 
                Clear();
                PrintPlayerInfo(player);
                Draw.Board(model.GetBoard());
                int play = player.Play(model.getPlayableColumns());
                model.AddChecker(play, playerID);
                CheckWin(model.GetLastChecker(), playerID, model.GetBoard());
            }
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

        private void InitializeSteps()
        {
            DirectionSteps[0] = new int[2] { -1, 0 }; //N
            DirectionSteps[1] = new int[2] { -1, 1 }; //NE
            DirectionSteps[2] = new int[2] { 0, 1 }; //E
            DirectionSteps[3] = new int[2] { 1, 1 }; //SE
        }

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
                    // distance will be 5 at maximum
                    for (int distance = 1; distance <= 5; distance++)
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
                    WinState = true;
                    Clear();
                    Draw.Board(model.GetBoard());
                    WriteLine($"Player {Players[playerID-1].Name} has Won!!!");
                    WriteLine("Press Enter to return to Main Menu...");
                    ReadKey(true);
                    
       
                };
        // player with that tileColor has won
}
        }

        private bool IsOutsideOfGrid(int x, int y)
        {
            if(x < 0 || y < 0) { return true; }
            else if(x > Columns-1 || y > Rows-1) { return true; }
            return false;
        }
    }
}
