namespace Connect_4_CTG
{
    public interface IPlayer
    {
        ConsoleColor Color { get; set; }
        string Name { get; set; }
        public int PlayerID { get; }

        int Play(Model Board);
    }
}