using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkManGame
{
    public class Game
    {
        /*
         while cnt < val:
            if every user is not empty(users list):
                1.take card from every user(stepCards)
                2.{
                    getCardWithLowestPrior(cards list)
                    getCardWithHighestPrior(cards list)
                    if lowestPriorCard == 6 && highestPriorCard == 14:
                        (users list)[cards list.index(lowestPriorCard)].set += stepCards
                    else:
                        if cards list has the same cards:
                            getUsersWithEqualCards()
                            war(users with equal cards, step cards)
                        i = (user in users list with highestPirorCard).index
                        user_i.set += stepcards
                        
                }
           
            else if at least one user empty(users list):
                remove empty users from list 
            
         */
        void StartGame(List<Gamer> players, int stepsPrediction, int deckSize=36)
        {
            if (deckSize != 52 || deckSize != 36)
                return;

            Deck deck = new Deck(deckSize);
            deck.Shuffle();
            int lowestPrior = deckSize == 36 ? 6 : 2;
            List<Gamer> gamers = new(); 
            foreach (Gamer gamer in players) 
                gamers.Add(new Gamer(gamer));
            
            deck.Distribute(gamers);  // роздаєм карти гравцям
            int count = 0;  // лічильник ходів
            
            while(count < stepsPrediction)
            {
                count++;
                if (ArePlayersEmpty(gamers))
                {
                    List<Card> stepSet = new List<Card>();
                    foreach (Gamer gamer in gamers)
                        stepSet.Add(gamer.GiveCard());
                    Card MaxCard = GetCardWithHighestPrior(stepSet);
                    Card MinCard = GetCardWithLowestPrior(stepSet);


                    //if(MinCard.Priority == lowestPrior && MaxCard.Priority == 14)
                    //{
                        //gamers[stepSet.FindIndex(el => )]
                    //}
                }
                else
                {
                    RemoveEmptyPlayers(gamers);
                }
            }
            
        }
        
        private bool ArePlayersEmpty(List<Gamer> gamers) 
        {
            return gamers.All(gamer => gamer.Set.Count > 0);
        }

        private void RemoveEmptyPlayers(List<Gamer> gamers)
        {
            foreach(Gamer gamer in gamers)
            {
                if(gamer.Set.Count == 0)
                    gamers.Remove(gamer);
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

        private Card GetCardWithLowestPrior(List<Card> cards) => cards.Min();    

        private Card GetCardWithHighestPrior(List<Card> cards) => cards.Max();
    }
}
