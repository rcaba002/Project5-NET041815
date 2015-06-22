using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PokerGame.Models.FiveCardDraw
{
    public class AllCardsViewModel
    {
        public Card[] PlayersHand { get; set; }

        public Hand PlayerHas { get; set; }

        public string PlayerHigh { get; set; }

        public List<Card[]> AllsortedCompHands { get; set; }

        public List<Hand> AllcompHas { get; set; }

        public List<string> AllcompHighs { get; set; }

        public int Count { get; set; }

        public string Wins { get; set; }

        public int Counter = 0;
        
        public List<Tuple<string,string>> CompHasList = new List<Tuple<string, string>>(); 

        public void Extract()
        {
            for (int i = 0; i < AllsortedCompHands.Count; i++)
            {
                CompHasList.Add(new Tuple<string, string>(AllcompHas[i].ToString(), AllcompHighs[i]));
            }
        }
    }
}