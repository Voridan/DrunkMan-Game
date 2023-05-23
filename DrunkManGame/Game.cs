using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkManGame
{
    public class Game
    {
        public void StartGame(List<Gamer> players, int stepsPrediction, int deckSize=36)
        {
            Console.WriteLine("\n *** Гра почалась *** \n");
            if (deckSize != 52 && deckSize != 36)
                return;

            Deck deck = new Deck(deckSize);
            deck.Shuffle();
            int lowestPrior = deckSize == 36 ? 6 : 2;
            List<Gamer> gamers = new(); 

            foreach (Gamer gamer in players) 
                gamers.Add(new Gamer(gamer));
            
            deck.Distribute(gamers);  // роздаєм карти гравцям
            int count = 0;  // лічильник ходів
            bool gameEnded = false;
            while(count < stepsPrediction)
            {
                
                if (gamers.Count == 1)
                {
                    Console.WriteLine($"Переможець: {gamers[0].Name}");
                    gameEnded = true;
                    break;
                }
                
                if (PlayersNotEmpty(gamers) && gamers.Count > 1)
                {
                    Console.WriteLine($"\n==== Крок: {++count} ====\n");
                    foreach (Gamer gamer in gamers)
                        Console.WriteLine(gamer);
                    List<Card> stepSet = new List<Card>();
                    //foreach (Gamer gamer in gamers)
                    //    Console.WriteLine(gamer);
                    foreach (Gamer gamer in gamers)
                        stepSet.Add(gamer.GiveCard());

                    Card MaxCard = GetCardWithHighestPrior(stepSet);
                    Card MinCard = GetCardWithLowestPrior(stepSet);
                    List<Card> sameCards = GetEqualCard(stepSet);
                    foreach (Card card in stepSet)
                        Console.WriteLine(card);

                    //Console.WriteLine("-------------------------");


                    if (MinCard.Priority == lowestPrior && MaxCard.Priority == 14)
                    {
                        Gamer stepWinner = gamers[stepSet.FindIndex(card => card == MinCard)];
                        foreach (Card card in stepSet)
                            stepWinner.Set.Insert(0, card);
                    }
                    else if (sameCards.Count != 0 && sameCards.Contains(MaxCard))
                    {
                        //Console.WriteLine("\n *** War *** \n");
                        List<Gamer> warriors = GetUsersWithSameCards(gamers, sameCards.Max(), stepSet);
                        War(warriors, stepSet, lowestPrior);
                        
                    }
                    else
                    {
                        Gamer stepWinner = gamers[stepSet.FindIndex(card => card == MaxCard)];
                        foreach (Card card in stepSet)
                            stepWinner.Set.Insert(0, card);
                    }
                    //foreach (Gamer gamer in gamers)
                    //    Console.WriteLine(gamer);
                }
                else
                {
                    RemoveEmptyPlayers(gamers);
                }
            }
            if (!gameEnded)
                Console.WriteLine("Гра не закінчилась за {0}", stepsPrediction);
        }
        
        private bool PlayersNotEmpty(List<Gamer> gamers) 
        {
            return gamers.All(gamer => gamer.Set.Count > 0);
        }

        private void RemoveEmptyPlayers(List<Gamer> gamers)
        {
            for (int i = 0; i<gamers.Count; i++)
            {
                if (gamers[i].Set.Count == 0)
                {
                    gamers.RemoveAt(i);
                    i--;
                }
                    
            }
        }

        private int Factorial(int n)
        {
            int result = 1;
            for (int i = n; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }

        private List<Card> GetEqualCard(List<Card> stepcards)
        {
            List<Card> equalsCards = new();
            int count = stepcards.Count;
            int checkCount = Factorial(count) / Factorial(2) * Factorial(count - 2);
            int iterCount = 0;
            for (int i = 0; i < count; i++)   // ідем по картах
            {
                for (int j = count - 1; j > i; j--)  // порівнюєм поточну з усіма наступними
                {
                    iterCount++;
                    if(stepcards[i] == stepcards[j])
                    {
                        if (equalsCards.Count == 0) 
                        {
                            equalsCards.Add(stepcards[i]);
                        }
                        else if (!equalsCards.Contains(stepcards[i]))
                        {
                            equalsCards.Add(stepcards[i]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return equalsCards;
        }

        private List<Gamer> GetUsersWithSameCards(List<Gamer> gamers, Card card, List<Card> stepCards) 
        {
            List<Gamer> resList = new();
            for (int i = 0; i < stepCards.Count; i++)
            {
                if (stepCards[i] == card)
                    resList.Add(gamers[i]);
            }
            return resList;
        }
        private Card GetCardWithLowestPrior(List<Card> cards) => cards.Min();    

        private Card GetCardWithHighestPrior(List<Card> cards) => cards.Max();

        private void War(List<Gamer> warriors, List<Card> stepset , int lowestPrior)
        {
            int warStep = 0;
            while (true)
            {
                Console.WriteLine($"\n *** Війна *** \n Крок: {++warStep}\n");
                for (int i = 0; i < warriors.Count; ++i)
                {
                    if (warriors[i].Set.Count < 3)
                    {
                        stepset.AddRange(warriors[i].GiveAllCards());
                        warriors.Remove(warriors[i]);
                    }
                }
                if (warriors.Count == 1)
                {
                    warriors[0].Set.AddRange(stepset);
                    break;
                }
                for (int i = 0; i < 3; ++i)
                {
                    foreach (var warrior in warriors)
                    {
                        stepset.Add(warrior.GiveCard());
                    }
                }

                List<Card> lastCards = new();
                for (int i = 1; i <= warriors.Count; ++i)
                {
                    lastCards.Add(stepset[stepset.Count-i]);
                }

                foreach (Card card in lastCards)
                    Console.WriteLine(card);

                Card maxCard = lastCards.Max();
                Card minCard = lastCards.Min();
                List<Card> sameCards = GetEqualCard(lastCards);
                if(sameCards.Count != 0) {
                    continue;
                }
                if (minCard.Priority == lowestPrior && maxCard.Priority == 14)
                {
                    Gamer warWinner = warriors[lastCards.FindIndex(card => card == minCard)];
                    foreach (Card card in stepset)
                        warWinner.Set.Insert(0, card);
                    break;
                }
                else
                {
                    Gamer stepWinner = warriors[lastCards.FindIndex(card => card == maxCard)];
                    foreach (Card card in stepset)
                        stepWinner.Set.Insert(0, card);
                    break;
                }
            }
            foreach (Gamer gamer in warriors)
                Console.WriteLine(gamer);

            Console.WriteLine("\n *** Війна закінчилась ***\n");
        }
    }
}
