using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerGame.Models.FiveCardDraw
{
    public class Card
    {
        public enum Suit
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        public enum Value
        {
            Two = 2, Three, Four, Five, Six, Seven,
            Eight, Nine, Ten, Jack, Queen, King, Ace
        }

        //properties
        public Suit MySuit { get; set; }
        public Value MyValue { get; set; }
    }
}