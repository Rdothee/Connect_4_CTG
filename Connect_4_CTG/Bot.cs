namespace Connect_4_CTG
{
    internal class Bot : Player
    {
        private int BotType;
        public Bot(string name, ConsoleColor color, int botType) : base(name, color)
        {
            BotType = botType;
        }

        public override void Play()
        {
            throw new NotImplementedException();
        }
    }
}