namespace DrunkManGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck d = new();
            // d.PrintDeck();
            d.Shuffle();
            Console.WriteLine('\n');
            d.PrintDeck();
            Gamer g1 = new Gamer("Raul");
            Gamer g2 = new Gamer("Paul");
            Gamer g3 = new Gamer("Sanches");
            d.Distribute(new List<Gamer>  {g1,g2,g3});
            Console.WriteLine("user 1 \n");
            g1.WriteUserSet();
            Console.WriteLine("user 2 \n");
            g2.WriteUserSet();

            Card c = new("Q",Card.Suits["spades"], 12);
            Console.WriteLine(c);



        }
    }
}