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
            //
        }

    }
}
