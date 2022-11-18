using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
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
        public int Columns { get; set; } = 7;
        public int Rows { get; set; }= 6;
        public int Connect { get; set; } = 4;
        public List<IPlayer> Players { get; set; }
        public bool WinState { get; private set; }

        //variables
        private static Controller Instance = null;
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

        public void StartGame()
        {
            WinState = false;
            model.CreateBoard(Rows, Columns);
            model.Connect = Connect;
            Draw = new Draw(Columns, Rows);
            Analyzer = new Analyzer();
            Clear();
            foreach (var player in Players) Draw.AddColor(player.Color, player.PlayerID);
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
                CheckWin(player);
            }
        }

        private void CheckWin(IPlayer player)
        {
            Analyzer.PlayerID = player.PlayerID;
            Analyzer.Model = model;
            if(Analyzer.CheckWin(player.PlayerID)) Restart($"Player {player.Name} has Won!!!",player.Color);
            if(Analyzer.CheckForDrawGame()) Restart($"It's a draw, nobody won!!!",ConsoleColor.White);

        }

        private void PrintPlayerInfo(IPlayer player)
        {
            Write($"{player.Name}'s Turn: ");
            WriteLine(TurnCounter);
            Write("Checker:");
            
            ConsoleColor color = player.Color;
            ForegroundColor = color;
            WriteLine(color.ToString().Substring(0, 1));

            ResetColor();
        }

        private void Restart(string prompt,ConsoleColor color)
        {
            WinState = true;
            Clear();
            Draw.Board(model.GetBoard());
            ForegroundColor = color;
            WriteLine(prompt);
            WriteLine("Press Enter to return to Main Menu...");
            ResetColor();
            ReadKey(true);
            Connect_4 game = new Connect_4();
            game.Start();
        }
    }
}
