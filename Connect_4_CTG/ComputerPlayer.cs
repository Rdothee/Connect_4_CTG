namespace Connect_4_CTG
{
    internal class ComputerPlayer : Player
    {
        //bridge design computerPlayer <-> Algorithm: Abstraction
        protected Algorithm algorithm;

        public Algorithm Algorithm
        {
            set { algorithm = value; }
        }
        public ComputerPlayer(string name, ConsoleColor color) : base(name, color)
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