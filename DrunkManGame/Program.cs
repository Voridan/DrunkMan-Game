namespace DrunkManGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gamer g1 = new Gamer("Raul");
            Gamer g2 = new Gamer("Paul");
            Gamer g3 = new Gamer("Sanches");
            Gamer g4 = new Gamer("Serhio");
            Card c1 = new Card("10", Card.Suits["spades"], 10);
            Card c2 = new Card("10", Card.Suits["clubs"], 10);

            Game myGame = new Game();
            myGame.StartGame(new List<Gamer> { g1, g2, g3, g4 }, 100);


        }
    }
}