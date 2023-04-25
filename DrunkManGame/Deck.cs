using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkManGame
{
    public class Deck
    {
        public List<Card> deck;
        public Deck() { 
            deck = new List<Card>();

            foreach (var valKey in Card.Values.Keys)
            {
                foreach (var suitKey in Card.Suits.Keys) {
                    deck.Add(new Card(Card.Values[valKey], Card.Suits[suitKey], int.Parse(valKey)));
                }
            }
        }

        public void PrintDeck() {
            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }
        }

        public void Shuffle()
        { 
            Random rng = new Random();  
            int n = deck.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                Card value = deck[k];  
                deck[k] = deck[n];  
                deck[n] = value;  
            }  
        }

        public void Distribute(List<Gamer> gamers)
        {
            int deckCount = deck.Count;
            foreach (var gamer in gamers)
            {
                List<Card> userDeck = new List<Card>();
                for (int i = 0; i < deckCount / gamers.Count; i++)
                {
                    userDeck.Add(deck[deck.Count-1]);
                    deck.RemoveAt(deck.Count-1);
                }

                gamer.Set = userDeck;
            }
        }

    }
}
