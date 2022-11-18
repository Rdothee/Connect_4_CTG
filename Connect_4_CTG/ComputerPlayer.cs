namespace Connect_4_CTG
{
    internal class ComputerPlayer : Player
    {
        //bridge design computerPlayer <-> Algorithm: Abstraction
        /*
         * this is the player class used by each computer
         * the type of algortihm is initialyzed in the Connect_4 class
         */
        protected Algorithm algorithm;

        public Algorithm Algorithm
        {
            set { algorithm = value; algorithm.PlayerID = PlayerID; }
        }
        public ComputerPlayer(string name, ConsoleColor color,int playerID) : base(name, color,playerID)
        {
           
        }

        public override int Play(Model Board)
        {
            return GenerateSolution(Board);
        }

        protected virtual int GenerateSolution(Model Board)
        {
            return algorithm.GenerateSolution(Board);
        }
    }
}