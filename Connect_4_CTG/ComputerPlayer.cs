namespace Connect_4_CTG
{
    internal class ComputerPlayer : Player
    {
        //bridge design computerPlayer <-> Algorithm: Abstraction
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
            throw new NotImplementedException();
        }

        protected virtual int GenerateSolution(Model Board)
        {
            return algorithm.GenerateSolution(Board);
        }
    }
}