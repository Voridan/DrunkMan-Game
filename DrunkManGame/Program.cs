namespace DrunkManGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck d = new();
            d.PrintDeck();
            d.Shuffle();
            Console.WriteLine('\n');
            d.PrintDeck();

        }
    }
}