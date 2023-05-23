using System.Text;

namespace DrunkManGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Добрий день, вас вітає гра в П'яницю!!!\n\nВведіть кількість карт в колоді 36 або 52: ");
            int cardsCount = int.Parse(Console.ReadLine());
            if (cardsCount != 36 || cardsCount != 36) {
                cardsCount = 36;
                Console.WriteLine("Кількість карт введено невірно, створена колода із 36 карт");
            }
            Console.Write("Введіть кількість гравців: ");
            int gamersCount = int.Parse(Console.ReadLine());
            List<Gamer> gamersList = new List<Gamer>();
            for (int i = 1;i <= gamersCount; i++)
            {
                Console.Write($"Введіть ім'я {i} гравця: ");
                gamersList.Add(new Gamer(Console.ReadLine()));
            }
            Console.Write("Введіть прогнозовану кількість кроків: ");
            int stepsCount = int.Parse(Console.ReadLine());

            Game myGame = new Game();
            myGame.StartGame(gamersList, stepsCount, cardsCount);
        }
    }
}