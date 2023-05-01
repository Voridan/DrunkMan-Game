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

        public Card(Card another)
        {
            Value = another.Value;
            Suit = another.Suit;
            Priority = another.Priority;
        }

        public static Dictionary<string, string> Suits = new()
        {
            { "spades", "♠" },
            { "clubs", "♣" },
            { "diamonds", "♦" },
            { "hearts", "♥" }
        };

        public static Dictionary<string, string> Values36 = new()
        {
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" },
            { "10", "10" },
            { "11", "J" },
            { "12", "Q" },
            { "13", "K" },
            { "14", "A" }
        };
        public static Dictionary<string, string> Values52 = new()
        {
            { "2", "2" },
            { "3", "3" },
            { "4", "4" },
            { "5", "5" },
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" },
            { "10", "10" },
            { "11", "J" },
            { "12", "Q" },
            { "13", "K" },
            { "14", "A" }
        };

        public override string ToString()
        {
            int sizeCol= 7;
            int sizeRow = 5;

            for (int i = 0; i < sizeRow; i++) {
                for (int j = 0; j < sizeCol; j++)
                {
                    if (i == 0 && j == 0 || i == sizeRow - 1 && j == sizeCol - 1)
                    {
                        Console.Write(Value);
                    }
                    else if (i == 0 || i == sizeRow - 1)
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write(' ');
                        }
                        else if (j % 2 == 0)
                        {
                            Console.Write("#");
                        }    
                    }
                    else if (j == 0 || j == sizeCol - 1)
                    {
                        Console.Write("#");
                    }
                    else if (j == 3 && i == 2)
                    {
                        Console.Write(Suit);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            return "";
        }

        public int CompareTo(object? obj)
        {
            return Priority.CompareTo((obj as Card).Priority);
        }
    }

    
}
