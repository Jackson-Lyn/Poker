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
        private List<Card> cards;
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        public DetectHandRanking(List<Card> cards)
        {
            this.cards = cards;
        }

        private void GetNumberOfSuit()
        {
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
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1)
                {
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1)
                {
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
                else if (cards[0].Rank == cards[1].Rank - 1 &&
                         cards[1].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
                else if (cards[0].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[3].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
                else if (cards[0].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
                else if (cards[1].Rank == cards[2].Rank - 1 &&
                         cards[2].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1)
                {
                    return true;
                }
                else if (cards[1].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
                else if (cards[2].Rank == cards[3].Rank - 1 &&
                         cards[3].Rank == cards[4].Rank - 1 &&
                         cards[4].Rank == cards[5].Rank - 1 &&
                         cards[5].Rank == cards[6].Rank - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Card> ArrangeCards()
        {
            //First determine whether the poker hand is a Straight or a Straight Flush.
            //The IsStraight function also sorts the Poker Hand in ascending order.
            bool straight = Straight();

            //Move Aces to the end if:
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
            return cards;
        }

        public static HandRanking DeterminePokerHandType(List<Card> cards)
        {
            DetectHandRanking detect = new DetectHandRanking(cards);
            detect.ArrangeCards();

            detect.GetNumberOfSuit();

            if (detect.RoyalStraightFlush()) { return HandRanking.RoyalStraightFlush; }

            if (detect.StraightFlush()) { return HandRanking.StraightFlush; }

            if (detect.FourOfAKind()) { return HandRanking.FourOfAKind; }

            if (detect.FullHouse()) { return HandRanking.FullHouse; }

            if (detect.Flush()) { return HandRanking.Flush; }

            if (detect.Straight()) { return HandRanking.Straight; }

            if (detect.ThreeOfAKind()) { return HandRanking.ThreeOfAKind; }

            if (detect.TwoPair()) { return HandRanking.TwoPair; }

            if (detect.Pair()) { return HandRanking.Pair; }

            return HandRanking.HighCard;
        }

        private bool RoyalStraightFlush()
        {
            if (StraightFlush())
            {
                if (cards[0].Rank == Rank.Ten && cards[1].Rank == Rank.Jack && cards[2].Rank == Rank.Queen && cards[3].Rank == Rank.King && cards[4].Rank == Rank.Ace)
                {
                    return true;
                }
                else if (cards[0].Rank == Rank.Ten && cards[2].Rank == Rank.Jack && cards[3].Rank == Rank.Queen && cards[4].Rank == Rank.King && cards[5].Rank == Rank.Ace)
                {
                    return true;
                }
                else if (cards[0].Rank == Rank.Ten && cards[3].Rank == Rank.Jack && cards[4].Rank == Rank.Queen && cards[5].Rank == Rank.King && cards[6].Rank == Rank.Ace)
                {
                    return true;
                }
                else if (cards[1].Rank == Rank.Ten && cards[2].Rank == Rank.Jack && cards[3].Rank == Rank.Queen && cards[4].Rank == Rank.King && cards[5].Rank == Rank.Ace)
                {
                    return true;
                }
                else if (cards[1].Rank == Rank.Ten && cards[3].Rank == Rank.Jack && cards[4].Rank == Rank.Queen && cards[5].Rank == Rank.King && cards[6].Rank == Rank.Ace)
                {
                    return true;
                }
                else if (cards[2].Rank == Rank.Ten && cards[3].Rank == Rank.Jack && cards[4].Rank == Rank.Queen && cards[5].Rank == Rank.King && cards[6].Rank == Rank.Ace)
                {
                    return true;
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
            if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank && cards[0].Rank == cards[3].Rank)
            {
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank && cards[1].Rank == cards[4].Rank)
            {
                return true;
            }
            else if (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank && cards[2].Rank == cards[5].Rank)
            {
                return true;
            }
            else if (cards[3].Rank == cards[4].Rank && cards[3].Rank == cards[5].Rank && cards[3].Rank == cards[6].Rank)
            {
                return true;
            }
            return false;
        }

        private bool FullHouse()
        {
            if ((cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank) || (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank && cards[4].Rank == cards[5].Rank) || (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank && cards[5].Rank == cards[6].Rank))
            {
                return true;
            }
            else if ((cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank) || (cards[1].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank && cards[3].Rank == cards[5].Rank) || (cards[2].Rank == cards[3].Rank && cards[4].Rank == cards[5].Rank && cards[4].Rank == cards[6].Rank))
            {
                return true;
            }
            return false;
        }

        private bool ThreeOfAKind()
        {
            if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank)
            {
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank && cards[1].Rank == cards[3].Rank)
            {
                return true;
            }
            else if (cards[2].Rank == cards[3].Rank && cards[2].Rank == cards[4].Rank)
            {
                return true;
            }
            else if (cards[3].Rank == cards[4].Rank && cards[3].Rank == cards[5].Rank)
            {
                return true;
            }
            else if (cards[4].Rank == cards[5].Rank && cards[4].Rank == cards[6].Rank)
            {
                return true;
            }
            return false;
        }

        private bool TwoPair()
        {
            if (cards[0].Rank == cards[1].Rank && cards[2].Rank == cards[3].Rank)
            {
                return true;
            }
            else if (cards[0].Rank == cards[1].Rank && cards[3].Rank == cards[4].Rank)
            {
                return true;
            }
            else if (cards[0].Rank == cards[1].Rank && cards[4].Rank == cards[5].Rank)
            {
                return true;
            }
            else if (cards[0].Rank == cards[1].Rank && cards[5].Rank == cards[6].Rank)
            {
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank && cards[3].Rank == cards[4].Rank)
            {
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank && cards[4].Rank == cards[5].Rank)
            {
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank && cards[5].Rank == cards[6].Rank)
            {
                return true;
            }
            else if (cards[2].Rank == cards[3].Rank && cards[4].Rank == cards[5].Rank)
            {
                return true;
            }
            else if (cards[2].Rank == cards[3].Rank && cards[5].Rank == cards[6].Rank)
            {
                return true;
            }
            else if (cards[3].Rank == cards[4].Rank && cards[5].Rank == cards[6].Rank)
            {
                return true;
            }
            return false;
        }

        private bool Pair()
        {
            if (cards[0].Rank == cards[1].Rank)
            {
                return true;
            }
            else if (cards[1].Rank == cards[2].Rank)
            {
                return true;
            }
            else if (cards[2].Rank == cards[3].Rank)
            {
                return true;
            }
            else if (cards[3].Rank == cards[4].Rank)
            {
                return true;
            }
            else if (cards[4].Rank == cards[5].Rank)
            {
                return true;
            }
            else if (cards[5].Rank == cards[6].Rank)
            {
                return true;
            }
            return false;
        }
    }
}
