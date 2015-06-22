using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PokerGame.Models.FiveCardDraw
{
    public class Welcome
    {
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }

        [DisplayName("# of Computers")]
        public int NumOfComputers { get; set; }

        [DisplayName("Ante Size")]
        public decimal AnteSize { get; set; }

        [DisplayName("Wallet Size")]
        public decimal WalletSize { get; set; }
    }
}