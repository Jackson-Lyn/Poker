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
        private string name { get; set; }
        private List<Card> cards { get; set; }
        private int chips { get; set; }
        private bool isCheck { get; set; }
        #endregion

        #region CONSTRUCTORS
        public Player()
        {
            id = 1;
            name = "Random person";
            cards = new List<Card>();
            chips = 0;
            isCheck = false;
        }

        public Player(int id, string name, List<Card> cards, int chips)
        {
            this.id = id;
            this.name = name;
            this.cards = cards;
            this.chips = chips;
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
            foreach (Card card in cards)
            {
                card.FaceUp = false;
            }
        }
    }
}
