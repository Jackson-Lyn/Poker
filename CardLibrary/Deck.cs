using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Deck
    {
        private List<Card> cards { get; set; }

        public Deck()
        {
            cards = new List<Card>();

            Suit[] suits = Enum.GetValues(typeof(Suit)) as Suit[];
            Rank[] ranks = Enum.GetValues(typeof(Rank)) as Rank[];

            for (int suit = 0; suit < suits.Length; suit++)
            {
                for (int rank = 0; rank < ranks.Length; rank++)
                {
                    cards.Add(new Card(ranks[rank], suits[suit]));
                }
            }
        } 

        static readonly Random random = new Random();
        public void Shuffle()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }

        }
    }
}
