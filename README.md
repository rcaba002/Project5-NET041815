#Project 4
##Card Game Web Application

Once again, we're going to be building upon the Poker Hands projects seen in Weeks 1 and 3. In this project, we'll build more card games into the existing application and deploy the entire suite of games as a website!

As usual, these problems will not be formally graded, but you might be asked to share your solutions with the class. Any time on Saturday not spend working through this problem in workshop format will be spent presenting solutions to the class.

**Save your project files in the `.answers` directory under a new directory called `FirstnameLastname` (using your first and last name, obviously).**


-------------

#### Players should be able to use a basic graphic interface to choose between three card games.

Use the HTML and CSS templates included in the `resources` folder to build the front end of the website. All websites are built using a standard directory structure: the home page is displayed using the `index.html` file in the root directory, and any pages linked from the home pages are displayed through `index.html` files in sub-directories. This gives the website clean URLs and a neat organizational structure. All CSS files are in the `css` directory and are linked-to in the headers of each `index.html` file. You may manipulate these files if you'd like, or you can leave them as they are and focus solely on the back-end. We've provided the appropriate directory structure for poker, blackjack, and war internally-linked pages.

On the landing page, players should be able to choose from the following card game options:

- Poker (using the same rules as your previous projects)
- Blackjack (for one player only)
- War (for two players)

The player should be able to select any of these options from the landing page.

-------------

#### A player should be able to choose game parameters before a game starts.

Landing pages for each type of game should prompt the user to choose game-specific parameters that are not persistent between gaming sessions. Options for each game should include:
- for **Poker**: all options included in the Project 3 build of the poker application
- for **Blackjack**: Player Name and # of rounds to be played (specified as an int)
- for **War**: Player name only


-------------

#### After players input all parameters, the game should begin.

Poker games should follow the same processes from Week 3, but adapted to a graphics-based UI. The other games should progress as follows:

**BLACKJACK**

The goal of blackjack is to beat the value of a dealer's cards without exceeding a point-value of 21 per hand. Both player and dealer are dealt two cards, with only the player's hand face-up. Points are determined in a hand by adding the numeric values of cards (either the number of the card, or 10 for face-cards/royalty, or either 1 or 11 for Aces depending on preference in each hand). After the first two cards are revealed, the player can either keep only the two cards presented or be "hit" by another card by request. Once the player decides to stay (without "busting" by exceeding 21 points for the hand), the dealer reveals their cards and hits if the value is less than 17. Whomever has the highest point value after the process is completed wins the hand.

1. **Player name should be displayed, along with current score.** Player name is input for the human player before game begins, and all score counters start at 0.
2. **Player and Dealer will both be dealt 2 cards.** The human player will have their hand displayed on the screen, while the dealers' hands will remain hidden.
5. **Player will be prompted to "hit" or "stay"**. The human player will continue until they select "stay" or they "bust" by exceeding 21 points for the hand.
6. **If Player "stays" before busting, Dealer reveals cards.** If dealer's cards exceed 17 points, value of the cards is evaluated and the highest point value wins. If the dealer's cards to not exceed 17, then they will automatically draw cards until the value exceeds 17, then the value of both hands is evaluated to determine the winner of that hand.
7. **Win counters are incremented.** After a hand winner is determined, the score for that player is shown and incremented.
9. **Repeat steps 1-5 until game ends.** Game will end after the # of rounds specified by the user at the beginning of the session.


**WAR**

War is a simple comparison game between two players. Hands are won by presenting a higher card (drawn from the top of a dealt deck) than your opponent. Only two players will be allowed in this version. Card value is the same as face value, with Ace as the highest-value card. The entire deck is dealt out to the two players, and a player wins once their opponents share of the deck has been entirely depleted. Since this game can be long and tedious, be extra certain to include an obvious "exit" option on all screens.

1. **Player name should be displayed, along with current # of cards.** Both players should start with 25 cards.
2. **Human and Computer players should place cards.** The order of cards is important for this game, so make sure that card order is stored in some way and not simply randomized. For each hand, compare the value of the cards played, and put both cards on the "bottom" of the winners share of the deck.
3. **If Human and Computer players play the same value card on a hand, start a "War".** To resolve a "War", deal out three cards from the top of each Player's decks, then play a final card. The winner of the hand is determined by this fifth card. If the card values still match, repeat the "War" method of determining a winner until a winner is found. Winner takes all of the cards from the hand and adds them to the bottom of their deck.
4. **Repeat steps 1-3 until game ends.** Game will end once one of the players has won the entire deck.

For both games, be sure to allow users to exit prematurely if they wish.

-------------

#### End the game and repeat.

Return the user to the first menu, prompting the user to restart the game with new parameters or exit.






