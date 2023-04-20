using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Player : Game
    {
        #region FIELD AND PROPERTIES

        private int id { get; set; }
        private List<Card> cards { get; set; }
        private int chips { get; set; }
        private bool isCheck { get; set; }
        private bool isFold { get; set; }
        private bool isBet { get; set; }
        private int totalChips { get; set; }
        private String playerAction { get; set; }
        private int previousBet { get; set; }
        private bool isCall { get; set; }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            id = 1;
            cards = new List<Card>();
            chips = 0;
            isCheck = false;
            isFold = false;
            this.totalChips = chips;
        }

        public Player(int id, List<Card> cards, int chips)
        {
            this.id = id;
            this.cards = cards;
            this.chips = chips;
            isCheck = false;
            isFold = false;
            this.totalChips = chips;
        }

        #endregion

        public void Check()
        {
            isCheck = true;
        }

        public void UnCheck()
        {
            isCheck = false;
        }

        public void Bet(int chipsBet)
        {
            isBet = true;
            chips -= chipsBet;
            previousBet += chipsBet;
        }

        public void ResetBet()
        {
            isBet = false;
        }

        public void ResetPreviousBet()
        {
            previousBet = 0;
        }

        public bool GetIsBet()
        {
            return this.isBet;
        }

        public int GetPreviousBet()
        {
            return this.previousBet;
        }

        public void SetIsCall(bool isCall)
        {
            this.isCall = isCall;
        }

        public void Fold()
        {
            isFold = true;
            foreach (Card card in cards)
            {
                card.FaceUp = false;
            }
        }

        public void UnFold()
        {
            isFold = false;
        }

        public int GetId()
        {
            return id;
        }

        public bool GetCheck()
        {
            return isCheck;
        }

        public bool GetFold()
        {
            return isFold;
        }

        public int GetChips()
        {
            return chips;
        }

        public void SetChips(int chips)
        {
            this.chips = chips;
        }

        public void SetCards(List<Card> cards)
        {
            this.cards = cards;
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        public void Call(int chipsBet, ref Game game)
        {
            if (game.GetIsBetRaised())
            {
                if (chipsBet > this.chips) // modified comparison operator
                {
                    // fold player
                    Fold();
                    SetPlayerAction("Fold");
                }
                else
                {
                    if (previousBet == 0)
                    {
                        game.AddPot(chipsBet); // modified method name
                        game.SetCurrentBet(chipsBet);
                        Bet(chipsBet);
                        SetPlayerAction("Call");
                    }
                    else
                    {
                        game.AddPot(chipsBet - previousBet);
                        game.SetCurrentBet(chipsBet);
                        Bet(chipsBet - previousBet);
                        SetPlayerAction("Call");
                    }
                }
            }
            else
            {
                Check();
                SetPlayerAction("Check");
            }
        }

        public void Raise(int chipsBet, ref Game game)
        {

            int totalBetAmount = chipsBet;

            if (totalBetAmount > this.chips)
            {
                // The player does not have enough chips to make the raise and must fold
                Fold();
                SetPlayerAction("Fold");
            }
            else
            {
                game.AddPot(totalBetAmount);
                game.SetCurrentBet(totalBetAmount + this.previousBet);
                Bet(totalBetAmount);
                SetPlayerAction("Raise");
            }
        }

        public void AllIn(int chipsBet, ref Game game)
        {

            int totalBetAmount = chipsBet;

            if (totalBetAmount > this.chips)
            {
                // The player does not have enough chips to make the raise and must fold
                Fold();
                SetPlayerAction("Fold");
            }
            else
            {
                this.chips -= totalBetAmount;
                game.AddPot(totalBetAmount);
                game.SetCurrentBet(totalBetAmount);

            }

        }

        public bool SetCheck()
        {
            return isCheck;
        }

        public void SetPlayerAction(String playerAction)
        {
            this.playerAction = playerAction;
        }
        public String GetPlayerAction()
        {
            return playerAction;
        }

        public void SetTotalChips()
        {
            this.totalChips = chips;
        }

        public int setBigBlind()
        {
            return (int)(totalChips * 0.02);
        }

        public int setSmallBlind()
        {
            return (int)(totalChips * 0.01);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// This function will generate a random aggression factor based on the difficulty passed
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double RandomAggressionFactor(string difficulty)
        {
            Random random = new Random();

            switch (difficulty.ToLower())
            {
                case "easy":
                    return random.NextDouble() * (1.0 - 0.5) + 0.5;
                case "medium":
                    return random.NextDouble() * (1.5 - 1.0) + 1.0;
                case "hard":
                    return random.NextDouble() * (2.0 - 1.5) + 1.5;
                default:
                    throw new ArgumentException("Invalid difficulty level");
            }
        }


        // matthew - generate a random power level for each player based on their cards 
        public static int RandomPowerLevel(List<Card> cards)
        {
            Random random = new Random();
            int powerLevel = 0;

            // add up the power level of each card
            foreach (Card card in cards)
            {
                powerLevel += card.CardValue;
            }

            // divide by the number of cards to get the average power level
            powerLevel /= cards.Count;

            // add a random number between 0 and 1 to the power level
            //powerLevel += random.NextInteger();

            return powerLevel;
        }

        public static void easyDiff(int chips, List<Card> cards, ref Game game, Player player, String diff)
        {
            // print the amount of chips the player has
            Console.WriteLine("Player " + player.GetId() + " has " + player.GetChips() + " chips");
            DetectHandRanking detectHandRanking = new DetectHandRanking(cards);
            // players hand strength
            //HandRanking  handRank = detectHandRanking.DeterminePokerHandType();
            int hand = detectHandRanking.TotalCardValue();
            int bigBlind = player.setBigBlind();
            int smallBlind = player.setBigBlind() / 2;
            // print big blind to console
            Console.WriteLine("Big Blind: " + bigBlind);
            // print small blind to console
            Console.WriteLine("Small Blind: " + smallBlind);

            // print hand strength to console
            Console.WriteLine("Hand Strength: " + hand);
            // Set big blind to 2 % of initial chips

            // get the size of the pot
            int pot = game.GetPot();
            // get the minimum bet allowed
            int minBet = game.GetCurrentBet();
            // get the maximum bet allowed
            int maxBet = player.chips;
            // higher means more aggressive
            double aggressionFactor = RandomAggressionFactor(diff);
            Console.WriteLine("Aggression Factor: " + diff);




            // weak hand and low chips 
            if (hand < 9 && chips > bigBlind * 10)
            {
                // If the pot is large enough relative to the minimum bet, call Otherwise, fold
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Call(minBet, ref game);
                    Console.WriteLine("Player " + player.GetId() + " called");


                }
                else
                {
                    player.Fold();
                    Console.WriteLine("Player " + player.GetId() + " folded");
                    player.SetPlayerAction("Fold");
                }
            }
            // decent hand, more than 10 big blinds
            else if (hand >= 9 && hand < 15 && chips >= bigBlind * 10)
            {
                // If the pot is large enough relative to the minimum bet, call
                // Otherwise, check
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Call(minBet, ref game);
                    Console.WriteLine("Next IF Player " + player.GetId() + " called");
                }
                else
                {
                    player.Check();
                    Console.WriteLine("Next IF Player " + player.GetId() + " checked");
                    player.SetPlayerAction("Check");
                }
            }
            // strong hand, more than 10 big blinds
            else if (hand >= 15 && chips >= bigBlind * 10)
            {
                // If the pot is large enough relative to the minimum bet, raise by 2x the minimum bet
                // Otherwise, check
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    if (minBet * 2 <= chips)
                    {
                        player.Raise(minBet * 2, ref game);
                        Console.WriteLine("Player " + player.GetId() + " raised");
                        player.SetPlayerAction("Raise");
                    }
                    else
                    {
                        player.Call(minBet, ref game);
                    }
                }
                else
                {
                    player.Check();
                    Console.WriteLine("Player " + player.GetId() + " checked");
                    player.SetPlayerAction("Check");
                }
            }
            else // weak hand or not enough chips for any other action
            {
                // If none of the above conditions are met, the AI can choose to check or fold
                // If the AI can check and the pot is still empty, check
                // Otherwise, fold
                //if (SetCheck() && pot == 0)
                //{
                //    Check();
                //}
                //else
                {
                    player.Fold();
                    Console.WriteLine("Player " + player.GetId() + " folded");
                    player.SetPlayerAction("Fold");
                }
            }
        }


        public static void mediumDiff(int chips, List<Card> cards, Game game, Player player, String diff)
        {
            DetectHandRanking detectHandRanking = new DetectHandRanking(cards);
            // players hand strength
            //HandRanking  handRank = detectHandRanking.DeterminePokerHandType();
            int hand = detectHandRanking.TotalCardValue();
            int bigBlind = player.setBigBlind();
            int smallBlind = player.setBigBlind() / 2;
            // print big blind to console
            Console.WriteLine("Big Blind: " + bigBlind);
            // print small blind to console
            Console.WriteLine("Small Blind: " + smallBlind);

            // print hand strength to console
            Console.WriteLine("Hand Strength: " + hand);
            // Set big blind to 2 % of initial chips

            // get the size of the pot
            int pot = game.GetPot();
            // get the minimum bet allowed
            int minBet = game.GetCurrentBet();
            // get the maximum bet allowed
            int maxBet = player.chips;
            // higher means more aggressive
            double aggressionFactor = RandomAggressionFactor(diff);
            Console.WriteLine("Aggression Factor: " + diff);

            int adjustedChips = (int)(chips * aggressionFactor);
            int adjustedHand = (int)(hand * aggressionFactor);

            if (adjustedHand < 9 && adjustedChips > bigBlind * 5)
            {
                player.Fold();
                player.SetPlayerAction("Fold");
            }
            else if (adjustedHand >= 9 && adjustedHand < 15 && adjustedChips >= bigBlind * 5)
            {
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Call(minBet, ref game);
                    player.SetPlayerAction("Call");
                }
                else
                {
                    player.Check();
                    player.SetPlayerAction("Check");
                }
            }
            else if (adjustedHand >= 15 && adjustedHand < 20 && adjustedChips >= bigBlind * 10)
            {
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Raise(minBet * 2, ref game);
                    player.SetPlayerAction("Raise");
                }
                else
                {
                    player.Check();
                    player.SetPlayerAction("Check");
                }
            }
            else if (adjustedHand >= 20 && adjustedChips >= bigBlind * 20)
            {
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Raise(minBet * 3, ref game);
                    player.SetPlayerAction("Raise");
                }
                else
                {
                    player.AllIn(player.chips, ref game);
                    player.SetPlayerAction("All in");
                }
            }
            else
            {
                // If none of the above conditions are met, the AI can choose to check or fold
                if (player.SetCheck())
                {
                    player.Check();
                    player.SetPlayerAction("Check");
                }
                else
                {
                    player.Fold();
                    player.SetPlayerAction("Fold");
                }
            }
        }



        /**
            * Plays a hand of poker with a hard difficulty level.
            * Determines the optimal action based on the player's chip count and hand strength.
            * @param chips the number of chips the player has
            * @param hand the strength of the player's hand (0-100)
         */
        public static void hardDiff(int chips, List<Card> cards, Game game, Player player, String diff)
        {
            DetectHandRanking detectHandRanking = new DetectHandRanking(cards);
            // players hand strength
            //HandRanking  handRank = detectHandRanking.DeterminePokerHandType();
            int hand = detectHandRanking.TotalCardValue();
            int bigBlind = player.setBigBlind();
            int smallBlind = player.setBigBlind() / 2;
            // print big blind to console
            Console.WriteLine("Big Blind: " + bigBlind);
            // print small blind to console
            Console.WriteLine("Small Blind: " + smallBlind);

            // print hand strength to console
            Console.WriteLine("Hand Strength: " + hand);
            // Set big blind to 2 % of initial chips

            // get the size of the pot
            int pot = game.GetPot();
            // get the minimum bet allowed
            int minBet = game.GetCurrentBet();
            // get the maximum bet allowed
            int maxBet = player.chips;
            // higher means more aggressive
            double aggressionFactor = RandomAggressionFactor(diff);
            Console.WriteLine("Aggression Factor: " + diff);

            // weak hand, more than 20 big blinds
            if (hand < 9 && chips > bigBlind * 20)
            {
                // If the pot is large enough relative to the minimum bet, call Otherwise, fold

                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Call(minBet, ref game);
                    player.SetPlayerAction("Call");
                }
                else
                {
                    player.Fold();
                    player.SetPlayerAction("Fold");
                }
            }
            // decent hand, more than 20 big blinds
            else if (hand >= 9 && hand < 15 && chips >= bigBlind * 20)
            {
                // If the pot is large enough relative to the minimum bet, call
                // If the minimum bet is less than the maximum bet and the hand is strong enough, raise
                // Otherwise, call
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Call(minBet, ref game);
                    player.SetPlayerAction("Call");
                }
                else if (minBet <= maxBet && (hand >= 12 || pot > 0))
                {
                    player.Raise(minBet, ref game);
                    player.SetPlayerAction("Raise");
                }
                else
                {
                    player.Call(minBet, ref game);
                    player.SetPlayerAction("Call");
                }
            }
            else if (hand >= 15 && hand < 20 && chips >= bigBlind * 30) // strong hand, more than 30 big blinds
            {
                // If the pot is large enough relative to the minimum bet, raise by 2x the minimum bet
                // If the minimum bet is less than the maximum bet and the hand is strong enough, raise
                // Otherwise, call
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Raise(minBet * 2, ref game);
                    player.SetPlayerAction("Raise");
                }
                else if (minBet <= maxBet && (hand >= 18 || pot > 0))
                {
                    player.Raise(minBet, ref game);
                    player.SetPlayerAction("Raise");
                }
                else
                {
                    player.Call(minBet, ref game);
                    player.SetPlayerAction("Call");
                }
            }
            else if (hand >= 20 && chips >= bigBlind * 40) // very strong hand, more than 40 big blinds
            {
                // If the pot is large enough relative to the minimum bet, go all-in
                // Otherwise, raise by the maximum allowed amount
                if (pot > 0 && (pot / minBet) >= aggressionFactor)
                {
                    player.Raise(maxBet, ref game);
                    player.SetPlayerAction("Raise");
                }
                else
                {
                    player.AllIn(player.chips, ref game);
                    player.SetPlayerAction("All In");
                }
            }
            else // weak hand or not enough chips for any other action
            {
                // If none of the above conditions are met, the AI can choose to check or fold
                // If the AI can check and the pot is still empty, check
                // Otherwise, fold
                if (player.SetCheck() && pot == 0)
                {
                    player.Check();
                    player.SetPlayerAction("Check");
                }
                else
                {
                    player.Fold();
                    player.SetPlayerAction("Fold");
                }
            }
        }


    }
}
