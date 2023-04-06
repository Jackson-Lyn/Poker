using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Player
    {
        #region FIELD AND PROPERTIES

        private int id { get; set; }
        private List<Card> cards { get; set; }
        private int chips { get; set; }
        private bool isCheck { get; set; }
        private bool isFold { get; set; }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            id = 1;
            cards = new List<Card>();
            chips = 0;
            isCheck = false;
            isFold = false;
        }

        public Player(int id, List<Card> cards, int chips)
        {
            this.id = id;
            this.cards = cards;
            this.chips = chips;
            isCheck = false;
            isFold = false;
        }

        #endregion

        public void Check()
        {
            isCheck = !isCheck;
        }

        public void Bet(int chipsBet)
        {
            chips -= chipsBet;
        }

        public void Fold()
        {
            isFold = true;
            foreach (Card card in cards)
            {
                card.FaceUp = false;
            }
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

        public void SetCheck(bool check)
        {
            isCheck = check;
        }

        public void SetCards(List<Card> cards)
        {
            this.cards = cards;
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

        //public void easyDiff(int chips, int hand)
        //{
        //    // Set default bigBlind 
        //    int bigBlind = 10;
        //    // get the size of the pot
        //    int pot = GetPot();
        //    // get the minimum bet allowed
        //    int minBet = getMinimumBet();
        //    // get the maximum bet allowed
        //    int maxBet = getMaxBet();
        //    // higher means more aggressive
        //    double aggressionFactor = RandomAggressionFactor("easy");

        //    // weak hand and low chips 
        //    if (hand < 9 && chips > bigBlind * 10)
        //    {
        //        // If the pot is large enough relative to the minimum bet, call Otherwise, fold
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Call();
        //        }
        //        else
        //        {
        //            Fold();
        //        }
        //    }
        //    // decent hand, more than 10 big blinds
        //    else if (hand >= 9 && hand < 15 && chips >= bigBlind * 10)
        //    {
        //        // If the pot is large enough relative to the minimum bet, call
        //        // Otherwise, check
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Call();
        //        }
        //        else
        //        {
        //            Check();
        //        }
        //    }
        //    // strong hand, more than 10 big blinds
        //    else if (hand >= 15 && chips >= bigBlind * 10)
        //    {
        //        // If the pot is large enough relative to the minimum bet, raise by 2x the minimum bet
        //        // Otherwise, check
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Raise(minBet * 2);
        //        }
        //        else
        //        {
        //            Check();
        //        }
        //    }
        //    else // weak hand or not enough chips for any other action
        //    {
        //        // If none of the above conditions are met, the AI can choose to check or fold
        //        // If the AI can check and the pot is still empty, check
        //        // Otherwise, fold
        //        if (SetCheck() && pot == 0)
        //        {
        //            Check();
        //        }
        //        else
        //        {
        //            Fold();
        //        }
        //    }
        //}


        //public void mediumDiff(int chips, int hand)
        //{
        //    // Set default bigBlind 
        //    int bigBlind = 10;
        //    // get the size of the pot
        //    int pot = GetPot();
        //    // get the minimum bet allowed
        //    int minBet = getMinimumBet();
        //    // get the maximum bet allowed
        //    int maxBet = getMaxBet();
        //    // higher means more aggressive
        //    double aggressionFactor = RandomAggressionFactor("medium");

        //    int adjustedChips = (int)(chips * aggressionFactor);
        //    int adjustedHand = (int)(hand * aggressionFactor);

        //    if (adjustedHand < 9 && adjustedChips > bigBlind * 5)
        //    {
        //        Fold();
        //    }
        //    else if (adjustedHand >= 9 && adjustedHand < 15 && adjustedChips >= bigBlind * 5)
        //    {
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Call();
        //        }
        //        else
        //        {
        //            Fold();
        //        }
        //    }
        //    else if (adjustedHand >= 15 && adjustedHand < 20 && adjustedChips >= bigBlind * 10)
        //    {
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Raise(minBet);
        //        }
        //        else
        //        {
        //            Call();
        //        }
        //    }
        //    else if (adjustedHand >= 20 && adjustedChips >= bigBlind * 20)
        //    {
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Raise(maxBet);
        //        }
        //        else
        //        {
        //            AllIn();
        //        }
        //    }
        //    else
        //    {
        //        // If none of the above conditions are met, the AI can choose to check or fold
        //        if (SetCheck())
        //        {
        //            Check();
        //        }
        //        else
        //        {
        //            Fold();
        //        }
        //    }
        //}



        ///**
        //    * Plays a hand of poker with a hard difficulty level.
        //    * Determines the optimal action based on the player's chip count and hand strength.
        //    * @param chips the number of chips the player has
        //    * @param hand the strength of the player's hand (0-100)
        // */
        //public void hardDiff(int chips, int hand)
        //{
        //    // Set default bigBlind 
        //    int bigBlind = 10;
        //    // get the size of the pot
        //    int pot = GetPot();
        //    // get the minimum bet allowed
        //    int minBet = getMinimumBet();
        //    // get the maximum bet allowed
        //    int maxBet = getMaxBet();
        //    // higher means more aggressive
        //    double aggressionFactor = RandomAggressionFactor("hard");

        //    // weak hand, more than 20 big blinds
        //    if (hand < 9 && chips > bigBlind * 20) 
        //    {
        //        // If the pot is large enough relative to the minimum bet, call Otherwise, fold

        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Call();
        //        }
        //        else
        //        {
        //            Fold();
        //        }
        //    }
        //    // decent hand, more than 20 big blinds
        //    else if (hand >= 9 && hand < 15 && chips >= bigBlind * 20) 
        //    {
        //        // If the pot is large enough relative to the minimum bet, call
        //        // If the minimum bet is less than the maximum bet and the hand is strong enough, raise
        //        // Otherwise, call
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Call();
        //        }
        //        else if (minBet <= maxBet && (hand >= 12 || pot > 0))
        //        {
        //            Raise(minBet);
        //        }
        //        else
        //        {
        //            Call();
        //        }
        //    }
        //    else if (hand >= 15 && hand < 20 && chips >= bigBlind * 30) // strong hand, more than 30 big blinds
        //    {
        //        // If the pot is large enough relative to the minimum bet, raise by 2x the minimum bet
        //        // If the minimum bet is less than the maximum bet and the hand is strong enough, raise
        //        // Otherwise, call
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Raise(minBet * 2);
        //        }
        //        else if (minBet <= maxBet && (hand >= 18 || pot > 0))
        //        {
        //            Raise(minBet);
        //        }
        //        else
        //        {
        //            Call();
        //        }
        //    }
        //    else if (hand >= 20 && chips >= bigBlind * 40) // very strong hand, more than 40 big blinds
        //    {
        //        // If the pot is large enough relative to the minimum bet, go all-in
        //        // Otherwise, raise by the maximum allowed amount
        //        if (pot > 0 && (pot / minBet) >= aggressionFactor)
        //        {
        //            Raise(maxBet);
        //        }
        //        else
        //        {
        //            AllIn();
        //        }
        //    }
        //    else // weak hand or not enough chips for any other action
        //    {
        //        // If none of the above conditions are met, the AI can choose to check or fold
        //        // If the AI can check and the pot is still empty, check
        //        // Otherwise, fold
        //        if (SetCheck() && pot == 0)
        //        {
        //            Check();
        //        }
        //        else
        //        {
        //            Fold();
        //        }
        //    }
        //}


    }
}
