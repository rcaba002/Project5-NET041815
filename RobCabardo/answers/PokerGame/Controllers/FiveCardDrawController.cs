using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokerGame.Models.FiveCardDraw;

namespace PokerGame.Controllers
{
    public class FiveCardDrawController : Controller
    {
        // Create new deck of 52 cards
        private readonly Card[] _deck = new Card[52];
        public Card[] GetDeck { get { return _deck; } }

        public static string Player { get; set; }
        public static Hand Playerhand;
        public static string Playerhighcard;
        public static string Highcard;

        // Create player hand of 5 random cards
        private Card[] _playerHand;
        private static Card[] _sortedPlayerHand;

        // Create computer hand of 5 random cards
        private Card[] _computerHand;
        private Card[] _sortedComputerHand;
        private string _computerhighcard;

        // Create List for all computer hands
        private List<Card[]> _allComputerHands = new List<Card[]>();
        private static List<Card[]> _allSortedComputerHands = new List<Card[]>();
        private List<Hand> AllComputerHas = new List<Hand>();
        private List<string> AllComputerHighCards = new List<string>();

        public ActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Welcome(FormCollection newGame)
        {
            Player = newGame["PlayerName"];
            var numOfCompHands = Convert.ToInt32(newGame["NumOfComputers"]);

            Start(numOfCompHands);

            return RedirectToAction("PlayersCards");
        }

        public ActionResult PlayersCards()
        {
            EvaluateHands();

            Highcard = Convert.ToString(Playerhand) == "HighCard" ? Playerhighcard : "";

            var results = new PlayersCardsViewModel
            {
                PlayersHand = _sortedPlayerHand,
                PlayerHas = Playerhand,
                PlayerHigh = Highcard
            };

            return View(results);
        }

        public ActionResult AllCards()
        {
            var results = new AllCardsViewModel
            {
                PlayersHand = _sortedPlayerHand,
                PlayerHas = Playerhand,
                PlayerHigh = Highcard,
                AllsortedCompHands = _allSortedComputerHands,
                AllcompHas = AllComputerHas,
                AllcompHighs = AllComputerHighCards,
                Count = _allSortedComputerHands.Count(),
                Wins = EvaluateHands()
            };

            results.Extract();

            return View(results);
        }

        public void Start(int numOfCompHands)
        {
            SetUpDeck();
            GetHands(numOfCompHands);
            SortCards();
        }

        public void SetUpDeck()
        {
            var i = 0;

            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Value v in Enum.GetValues(typeof(Card.Value)))
                {
                    _deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }

            ShuffleCards();
        }

        public void ShuffleCards()
        {
            var rand = new Random();

            // Shuffle one thousand times
            for (var shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (var i = 0; i < 52; i++)
                {
                    // Swap cards
                    var secondCardIndex = rand.Next(13);
                    var temp = _deck[i];
                    _deck[i] = _deck[secondCardIndex];
                    _deck[secondCardIndex] = temp;
                }
            }
        }

        public void GetHands(int numOfCompHands)
        {
            _playerHand = new Card[5];

            var p = 5; // Deck index

            for (int i = 0; i < 5; i++)
                _playerHand[i] = GetDeck[i];

            for (var j = 0; j < numOfCompHands; j++)
            {
                _computerHand = new Card[5];

                var i = 0; // Computer hand index

                while (i < 5)
                {
                    _computerHand[i] = GetDeck[p];
                    p++;
                    i++;
                }

                _allComputerHands.Add(_computerHand);
            }
        }

        public void SortCards()
        {
            _sortedPlayerHand = new Card[5];

            var queryPlayer = from hand in _playerHand
                              orderby hand.MyValue
                              select hand;

            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                _sortedPlayerHand[index] = element;
                index++;
            }

            foreach (var x in _allComputerHands)
            {
                _sortedComputerHand = new Card[5];

                var queryComputer = from hand in x
                                    orderby hand.MyValue
                                    select hand;

                index = 0;
                foreach (var element in queryComputer.ToList())
                {
                    _sortedComputerHand[index] = element;
                    index++;
                }

                _allSortedComputerHands.Add(_sortedComputerHand);
            }
        }

        public string EvaluateHands()
        {
            var playerHandEvaluator = new HandEvaluator(_sortedPlayerHand);

            // get player hand
            Playerhand = playerHandEvaluator.EvaluateHand();

            // get player high card
            if (playerHandEvaluator.HandValues.HighCard == 11)
                Playerhighcard = "Jack";
            else if (playerHandEvaluator.HandValues.HighCard == 12)
                Playerhighcard = "Queen";
            else if (playerHandEvaluator.HandValues.HighCard == 13)
                Playerhighcard = "King";
            else if (playerHandEvaluator.HandValues.HighCard == 14)
                Playerhighcard = "Ace";
            else
                Playerhighcard = playerHandEvaluator.HandValues.HighCard.ToString();

            var a = 1;

            var compHand = Hand.HighCard;
            var compTotal = 0;
            var compHighCard = 0;

            var compWinner = " ";
            var winner = " ";

            foreach (var x in _allSortedComputerHands)
            {
                var computerHandEvaluator = new HandEvaluator(x);
                var computerhand = computerHandEvaluator.EvaluateHand();
                AllComputerHas.Add(computerhand);

                if (computerHandEvaluator.HandValues.HighCard == 11)
                    _computerhighcard = "Jack";
                else if (playerHandEvaluator.HandValues.HighCard == 12)
                    _computerhighcard = "Queen";
                else if (playerHandEvaluator.HandValues.HighCard == 13)
                    _computerhighcard = "King";
                else if (playerHandEvaluator.HandValues.HighCard == 14)
                    _computerhighcard = "Ace";
                else
                    _computerhighcard = playerHandEvaluator.HandValues.HighCard.ToString();

                _computerhighcard = Convert.ToString(computerhand) == "HighCard" ? _computerhighcard : "";

                AllComputerHighCards.Add(_computerhighcard);

                if (computerhand > compHand)
                {
                    compHand = computerhand;
                    compTotal = computerHandEvaluator.HandValues.Total;
                    compHighCard = computerHandEvaluator.HandValues.HighCard;
                    compWinner = string.Format("Computer {0}", a);
                }
                else if (compHand > computerhand)
                {
                    compHand = compHand;
                    compTotal = compTotal;
                    compHighCard = compHighCard;
                }
                else
                {
                    if (computerHandEvaluator.HandValues.Total > compTotal)
                    {
                        compHand = computerhand;
                        compTotal = computerHandEvaluator.HandValues.Total;
                        compHighCard = computerHandEvaluator.HandValues.HighCard;
                        compWinner = string.Format("Computer {0}", a);
                    }
                    else if (compTotal > computerHandEvaluator.HandValues.Total)
                    {
                        compHand = compHand;
                        compTotal = compTotal;
                        compHighCard = compHighCard;
                    }
                    else
                    {
                        if (computerHandEvaluator.HandValues.HighCard > compHighCard)
                        {
                            compHand = computerhand;
                            compTotal = computerHandEvaluator.HandValues.Total;
                            compHighCard = computerHandEvaluator.HandValues.HighCard;
                            compWinner = string.Format("Computer {0}", a);
                        }
                        else if (compHighCard > computerHandEvaluator.HandValues.HighCard)
                        {
                            compHand = compHand;
                            compTotal = compTotal;
                            compHighCard = compHighCard;
                        }
                        else // v2.0 will check 2nd highest card
                        {
                            compHand = compHand;
                            compTotal = compTotal;
                            compHighCard = compHighCard;
                            compWinner = string.Format("It's a Draw!");
                        }
                    }
                }

                a++;
            }

            if (Playerhand > compHand)
            {
                winner = string.Format(Player);
            }
            else if (compHand > Playerhand)
            {
                winner = compWinner;
            }
            else
            {
                if (playerHandEvaluator.HandValues.Total > compTotal)
                {
                    winner = string.Format(Player);
                }
                else if (compTotal > playerHandEvaluator.HandValues.Total)
                {
                    winner = compWinner;
                }
                else
                {
                    if (playerHandEvaluator.HandValues.HighCard > compHighCard)
                    {
                        winner = string.Format(Player);
                    }
                    else if (compHighCard > playerHandEvaluator.HandValues.HighCard)
                    {
                        winner = compWinner;
                    }
                    else // v2.0 will check 2nd highest card
                    {
                        winner = string.Format("It's a Draw!");
                    }
                }
            }

            return winner;
        }
    }
}
