using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerGame.Models.FiveCardDraw
{
    public class PlayersCardsViewModel
    {
        public Card[] PlayersHand { get; set; }

        public Hand PlayerHas { get; set; }

        public string PlayerHigh { get; set; }
    }
}