using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class DetectHandRanking
    {
        public List<Card> cards;
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        public int totalCardValue = 0;
        public DetectHandRanking(List<Card> cards)
        {
            this.cards = cards;
        }

        public DetectHandRanking(List<Card> middleCards, List<Card> playerCards)
        {
            this.cards = middleCards;
            foreach (Card card in playerCards)
            {
                this.cards.Add(card);
            }
        }

        private void GetNumberOfSuit()
        {
            heartsSum = 0;
            clubSum = 0;
            spadesSum = 0;
            diamondSum = 0;
            foreach (Card card in cards)
            {
                if (card.Suit == Suit.Hearts)
                {
                    heartsSum++;
                }
                else if (card.Suit == Suit.Clubs)
                {
                    clubSum++;
                }
                else if (card.Suit == Suit.Diamonds)
                {
                    diamondSum++;
                }
                else
                {
                    spadesSum++;
                }
            }
        }
        public int TotalCardValue()
        {
            totalCardValue = 0;
            foreach (Card card in cards)
            {
                totalCardValue += (int)card.Rank;
            }
            return totalCardValue;
        }

        public bool Straight()
        {
            //Sort ascending
            cards.Sort((card1, card2) =>
            card1.Rank.CompareTo(card2.Rank));

            if (cards.Count == 7)
            {
                if (cards[0].Rank == cards[1].Rank - 1 &&
                    cards[1].Rank == cards[2].Rank - 1 &&
                    cards[2].Rank == cards[3].Rank - 1 &&
                    cards[3].Rank == cards[4].Rank - 1)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1)
                {
                    totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1)
                {
                    totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[3].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1)
                {
                    totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
            }
            else if (cards.Count == 5)
            {
                if (cards[0].Rank == cards[1].Rank - 1 &&
                    cards[1].Rank == cards[2].Rank - 1 &&
                    cards[2].Rank == cards[3].Rank - 1 &&
                    cards[3].Rank == cards[4].Rank - 1)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
            } 
            return false;
        }

        public List<Card> ArrangeCards()
        {
            //First determine whether the poker hand is a Straight or a Straight Flush.
            //The Straight function also sorts the Poker Hand in ascending order.
            bool straight = Straight();

            //Move Aces to the end if:
            if (cards.Count == 7)
            {
                if (!straight || //Not a straight
                    cards[6].Rank == Rank.King)//Straight with a king at the end
                {
                    //Move all Aces To the End
                    while (cards[0].Rank == Rank.Ace)
                    {
                        cards.Add(cards[0]);
                        cards.RemoveAt(0);
                    }
                }
            }
            else if (cards.Count == 5)
            {
                if (!straight || //Not a straight
                    cards[4].Rank == Rank.King)//Straight with a king at the end
                {
                    //Move all Aces To the End
                    while (cards[0].Rank == Rank.Ace)
                    {
                        cards.Add(cards[0]);
                        cards.RemoveAt(0);
                    }
                }
            }
            return cards;
        }

        public HandRanking DeterminePokerHandType()
        {
            ArrangeCards();

            GetNumberOfSuit();

            if (RoyalStraightFlush()) { return HandRanking.RoyalStraightFlush; }

            if (StraightFlush()) { return HandRanking.StraightFlush; }

            if (FourOfAKind()) { return HandRanking.FourOfAKind; }

            if (FullHouse()) { return HandRanking.FullHouse; }

            if (Flush()) { return HandRanking.Flush; }

            if (Straight()) { return HandRanking.Straight; }

            if (ThreeOfAKind()) { return HandRanking.ThreeOfAKind; }

            if (TwoPair()) { return HandRanking.TwoPair; }

            if (Pair()) { return HandRanking.Pair; }

            totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
            return HandRanking.HighCard;
        }


        private bool RoyalStraightFlush()
        {
            if (StraightFlush())
            {
                if (cards.Count == 7)
                {
                    if (cards[0].Rank == Rank.Ten && cards[1].Rank == Rank.Jack && cards[2].Rank == Rank.Queen && cards[3].Rank == Rank.King && cards[4].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                        return true;
                    }
                    else if (cards[0].Rank == Rank.Ten && cards[2].Rank == Rank.Jack && cards[3].Rank == Rank.Queen && cards[4].Rank == Rank.King && cards[5].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                        return true;
                    }
                    else if (cards[0].Rank == Rank.Ten && cards[3].Rank == Rank.Jack && cards[4].Rank == Rank.Queen && cards[5].Rank == Rank.King && cards[6].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                        return true;
                    }
                    else if (cards[1].Rank == Rank.Ten && cards[2].Rank == Rank.Jack && cards[3].Rank == Rank.Queen && cards[4].Rank == Rank.King && cards[5].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                        return true;
                    }
                    else if (cards[1].Rank == Rank.Ten && cards[3].Rank == Rank.Jack && cards[4].Rank == Rank.Queen && cards[5].Rank == Rank.King && cards[6].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                        return true;
                    }
                    else if (cards[2].Rank == Rank.Ten && cards[3].Rank == Rank.Jack && cards[4].Rank == Rank.Queen && cards[5].Rank == Rank.King && cards[6].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                        return true;
                    }
                }
                else if (cards.Count == 5)
                {
                    if (cards[0].Rank == Rank.Ten && cards[1].Rank == Rank.Jack && cards[2].Rank == Rank.Queen && cards[3].Rank == Rank.King && cards[4].Rank == Rank.Ace)
                    {
                        totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool StraightFlush()
        {
            return Flush() && Straight();
        }

        private bool Flush()
        {
            return (heartsSum >= 5 || diamondSum >= 5 || spadesSum >= 5 || clubSum >= 5);
        }

        private bool FourOfAKind()
        {
            if (cards.Count == 7)
            {
                if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank && cards[0].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank && cards[1].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank && cards[2].Rank == cards[5].Rank)
                {
                    totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[3].Rank == cards[4].Rank && cards[3].Rank == cards[5].Rank && cards[3].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
            }
            else if (cards.Count == 5)
            {
                if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank && cards[0].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank && cards[1].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
            }
            return false;
        }

        private bool FullHouse()
        {
            if (cards.Count == 7)
            {
                if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = ((int)cards[0].CardValue * 10 + (int)cards[0].Suit) + ((int)cards[1].CardValue * 10 + (int)cards[1].Suit) + ((int)cards[2].CardValue * 10 + (int)cards[2].Suit);
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank && cards[4].Rank == cards[5].Rank)
                {
                    totalCardValue = ((int)cards[3].CardValue * 10 + (int)cards[3].Suit) + ((int)cards[1].CardValue * 10 + (int)cards[1].Suit) + ((int)cards[2].CardValue * 10 + (int)cards[2].Suit);
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank && cards[5].Rank == cards[6].Rank)
                {
                    totalCardValue = ((int)cards[3].CardValue * 10 + (int)cards[3].Suit) + ((int)cards[4].CardValue * 10 + (int)cards[4].Suit) + ((int)cards[2].CardValue * 10 + (int)cards[2].Suit);
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank)
                {
                    totalCardValue = ((int)cards[3].CardValue * 10 + (int)cards[3].Suit) + ((int)cards[4].CardValue * 10 + (int)cards[4].Suit) + ((int)cards[2].CardValue * 10 + (int)cards[2].Suit);
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank && cards[3].Rank == cards[5].Rank)
                {
                    totalCardValue = ((int)cards[3].CardValue * 10 + (int)cards[3].Suit) + ((int)cards[4].CardValue * 10 + (int)cards[4].Suit) + ((int)cards[5].CardValue * 10 + (int)cards[5].Suit);
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[4].Rank == cards[5].Rank && cards[4].Rank == cards[6].Rank)
                {
                    totalCardValue = ((int)cards[5].CardValue * 10 + (int)cards[5].Suit) + ((int)cards[4].CardValue * 10 + (int)cards[4].Suit) + ((int)cards[6].CardValue * 10 + (int)cards[6].Suit);
                    return true;
                }
            }
            else if (cards.Count == 5)
            {
                if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = ((int)cards[0].CardValue * 10 + (int)cards[0].Suit) + ((int)cards[1].CardValue * 10 + (int)cards[1].Suit) + ((int)cards[2].CardValue * 10 + (int)cards[2].Suit);
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank)
                {
                    totalCardValue = ((int)cards[3].CardValue * 10 + (int)cards[3].Suit) + ((int)cards[4].CardValue * 10 + (int)cards[4].Suit) + ((int)cards[2].CardValue * 10 + (int)cards[2].Suit);
                    return true;
                }
            }
            return false;
        }

        private bool ThreeOfAKind()
        {
            if (cards.Count == 7)
            {
                if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[3].Rank == cards[4].Rank && cards[3].Rank == cards[5].Rank)
                {
                    totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[4].Rank == cards[5].Rank && cards[4].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
            }
            else if (cards.Count == 5)
            {
                if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
            }
            return false;
        }

        private bool TwoPair()
        {
            if (cards.Count == 7)
            {
                if (cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank && cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank && cards[4].Rank == cards[5].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank && cards[5].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit + (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[4].Rank == cards[5].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit + (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[5].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit + (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[4].Rank == cards[5].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit + (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank && cards[5].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit + (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
                else if (cards[3].Rank == cards[4].Rank && cards[5].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit + (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
            }
            else if (cards.Count == 5)
            {
                if (cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank && cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit + (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
            }
            return false;
        }

        private bool Pair()
        {
            if (cards.Count == 7)
            {
                if (cards[0].Rank == cards[1].Rank)
                {
                    totalCardValue = (int)cards[0].CardValue * 10 + (int)cards[0].Suit + (int)cards[1].CardValue * 10 + (int)cards[1].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[2].CardValue * 10 + (int)cards[2].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit + (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit + (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
                else if (cards[4].Rank == cards[5].Rank)
                {
                    totalCardValue = (int)cards[4].CardValue * 10 + (int)cards[4].Suit + (int)cards[5].CardValue * 10 + (int)cards[5].Suit;
                    return true;
                }
                else if (cards[5].Rank == cards[6].Rank)
                {
                    totalCardValue = (int)cards[5].CardValue * 10 + (int)cards[5].Suit + (int)cards[6].CardValue * 10 + (int)cards[6].Suit;
                    return true;
                }
            }
            else if (cards.Count == 5)
            {
                if (cards[0].Rank == cards[1].Rank)
                {
                    totalCardValue = (int)cards[0].CardValue * 10 + (int)cards[0].Suit + (int)cards[1].CardValue * 10 + (int)cards[1].Suit;
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank)
                {
                    totalCardValue = (int)cards[1].CardValue * 10 + (int)cards[1].Suit + (int)cards[2].CardValue * 10 + (int)cards[2].Suit;
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank)
                {
                    totalCardValue = (int)cards[2].CardValue * 10 + (int)cards[2].Suit + (int)cards[3].CardValue * 10 + (int)cards[3].Suit;
                    return true;
                }
                else if (cards[3].Rank == cards[4].Rank)
                {
                    totalCardValue = (int)cards[3].CardValue * 10 + (int)cards[3].Suit + (int)cards[4].CardValue * 10 + (int)cards[4].Suit;
                    return true;
                }
            }
            return false;
        }
    }
}
