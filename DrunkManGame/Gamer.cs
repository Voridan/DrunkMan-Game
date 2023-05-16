using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkManGame
{
    public class Gamer
    {
        public string Name { get; set; }
        public List<Card> Set { get; set; }
        public bool? Status { get; set; } // isWinner - true , isLooser - false , null -  undetermined state
        public Gamer(string name)
        {
            Name = name;
            Set = new List<Card>();
        }
        public Gamer(Gamer another)
        {
            Name = another.Name;
            Status = another.Status;
            foreach (Card card in another.Set) 
            {
                Set.Add(new Card(card));
            }
        }
        public void WriteUserSet()
        {
            foreach (var setItem in Set)
            {
                Console.WriteLine(setItem);
            }
        }
        
        public Card GiveCard()
        {
            Card returnCard = Set[Set.Count - 1];
            Set.Remove(returnCard);
            return returnCard;
        }

        public List<Card> GiveAllCards()
        {
            List<Card> tempSet = new List<Card>(Set);
            Set.Clear();
            return tempSet;
        }

        public override string ToString()
        {
            Console.Write($"{Name}: ");
            foreach (Card card in Set)
                Console.Write($"{card}; ");
            return "";
        }

    }
}
