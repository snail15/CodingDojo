using System;
using System.Collections.Generic;

namespace cards{
    class Program{
        static void Main(string[] args){
            
        }
        public class Card{
            public string stringVal;
            public string suit;
            public int val;
            
            public Card(string val, string suit, string val){
                this.stringVal = val;
                this.suit = suit;
                this.val = val;

            }

        }

        public class Deck{
            public List<Card> cards;
            
            public Deck(){
                string[] suits = {"Clubs", "Spades", "Diamonds", "Hearts"};
                string[] vals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
                int intVal;
                foreach (string suit in suits){
                    foreach (string val in vals)
                    {
                        if(val == "Ace"){
                            intVal = 1;
                        } else if(val == "Jack"){
                            intVal = 11;
                        } else if(val == "Queen"){
                            intVal = 12;
                        } else if(val == "King"){
                            intVal = 13;
                        }
                        else {
                            intVal = int.Parse(val);
                        }
                        cards.Add(new Card(val, suit, intVal))
                    }
                }
            }
            private List<Card> deal(){
                Card dealtCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count-1);
                return dealtCard;
            }

            
        }
    }
}
