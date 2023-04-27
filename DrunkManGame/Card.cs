using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkManGame
{
    public class Card: IComparable
    {
        public string Value { get; set; }
        public string Suit { get; set; }
        public int Priority { get; set; }

        public Card(string value, string suit, int priority) { 
            Value = value;
            Suit = suit;
            Priority = priority;
        }

        public static Dictionary<string, string> Suits = new()
        {
            { "spades", "♠" },
            { "clubs", "♣" },
            { "diamonds", "♦" },
            { "hearts", "♥" }
        };

        public static Dictionary<string, string> Values = new()
        {
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" },
            { "10", "10" },
            { "11", "Jack" },
            { "12", "Queen" },
            { "13", "King" },
            { "14", "Ace" }
        };

        public override string ToString()
        {
            return $"{Value} {Suit} {Priority}";
        }

        public int CompareTo(object? obj)
        {
            return Priority.CompareTo((obj as Card).Priority);
        }
    }

    
}
