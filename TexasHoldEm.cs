using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using CardLibrary;
using CardBox;
using System.Security.AccessControl;

namespace PokerGame
{
    public partial class TexasHoldEm : Form
    {
        Game game = new Game();
        List<Player> allPlayers = new List<Player>();
        Deck deck = new Deck();
        #region CONSTRUCTORS
        public TexasHoldEm()
        {
            InitializeComponent();
        }

        public TexasHoldEm(string difficulty, string chips, string players)
        {
            InitializeComponent();
            SetPictures();
            SetMiddleCards();
            int numOfPlayers = int.Parse(players);

            if (numOfPlayers == 2)
            {
                cardBox1Bot2.Visible = false;
                cardBox2Bot2.Visible = false;
                cardBox1Bot3.Visible = false;
                cardBox2Bot3.Visible = false;
            }
            else if (numOfPlayers == 3)
            {
                cardBox1Bot3.Visible = false;
                cardBox2Bot3.Visible = false;
            }
            Loading(chips, players);
        }
        #endregion

        #region CUSTOM DESIGN METHODS
        public void SetPictures()
        {
            pictureBoxTitle.Image = Properties.Resources.ResourceManager.GetObject("TexasHoldem") as Image;
            picDealer.Image = Properties.Resources.ResourceManager.GetObject("dealer") as Image;
            picChips.Image = Properties.Resources.ResourceManager.GetObject("chips") as Image;
        }
        #endregion

        #region ASYNC METHODS

        private async void Loading(string chips, string players)
        {
            EnableOrDisablePlayerControls();
            await Task.Delay(5000);
            textRoundNumber.Text = game.GetRoundNumber().ToString();
            labelPot.Text = string.Format("Pot: {0} Chips", game.GetPot());

            await Task.Delay(1500);
            textBoxTotalChips.Text = chips;

            int numOfPlayers = int.Parse(players);
            game.SetNumberOfPlayers(numOfPlayers);

            for (int i = 0; i < numOfPlayers; i++)
            {
                List<Card> userCards = new List<Card>
                {
                    deck.GetCard(),
                    deck.GetCard()
                };
                Player user = new Player(i, userCards, 1000);
                SetPlayerCards(userCards, user.GetId());
                allPlayers.Add(user);
            }
            game.SetPlayers(allPlayers);

            CheckPlayerTurn();

            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            EnableOrDisablePlayerControls();
        }

        private void FaceDownAllCards()
        {
            cardBox1Player.FaceUp = false;
            cardBox2Player.FaceUp = false;
            cardBox1Bot2.FaceUp = false;
            cardBox2Bot2.FaceUp = false;
            cardBox1Bot1.FaceUp = false;
            cardBox2Bot1.FaceUp = false;
            cardBox1Bot3.FaceUp = false;
            cardBox2Bot3.FaceUp = false;
            cardBoxMiddle1.FaceUp = false;
            cardBoxMiddle2.FaceUp = false;
            cardBoxMiddle3.FaceUp = false;
            cardBoxMiddle4.FaceUp = false;
            cardBoxMiddle5.FaceUp = false;
        }

        private void FaceUpAllCards()
        {
            cardBox1Bot2.FaceUp = true;
            cardBox2Bot2.FaceUp = true;
            cardBox1Bot1.FaceUp = true;
            cardBox2Bot1.FaceUp = true;
            cardBox1Bot3.FaceUp = true;
            cardBox2Bot3.FaceUp = true;
        }

        private async void EndAndNextRound()
        {
            if (buttonCall.Enabled)
            {
                EnableOrDisablePlayerControls();
            }
            FaceUpAllCards();
            game.NextRound();
            labelPlayerTurn.Text = "Loading Next Round";
            textRoundNumber.Text = game.GetRoundNumber().ToString();
            await Task.Delay(5000);
            FaceDownAllCards();
            deck = new Deck();
            deck.Shuffle();
            foreach (Player p in allPlayers)
            {
                p.SetFold(false);
                p.SetCheck(false);
            }
            await Task.Delay(5000);

            for (int i = 0; i < game.GetPlayers().Count; i++)
            {
                List<Card> userCards = new List<Card>
                {
                    deck.GetCard(),
                    deck.GetCard()
                };
                allPlayers[i].SetCards(userCards);
                SetPlayerCards(userCards, allPlayers[i].GetId());
            }
            SetMiddleCards();
            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            game.SetPlayerTurn(0);
            CheckPlayerTurn();
            if (!buttonCall.Enabled)
            {
                EnableOrDisablePlayerControls();
            }
        }
        #endregion

        #region PUBLIC METHODS
        public void SetPlayerCards(List<Card> cards, int id)
        {
            if (id == 0)
            {
                SetCardBox(cardBox1Player, cards[0]);
                SetCardBox(cardBox2Player, cards[1]);
            }
            else if (id == 1)
            {
                SetCardBox(cardBox1Bot1, cards[0]);
                SetCardBox(cardBox2Bot1, cards[1]);
            }
            else if (id == 2)
            {
                SetCardBox(cardBox1Bot2, cards[0]);
                SetCardBox(cardBox2Bot2, cards[1]);
            }
            else if (id == 3)
            {
                SetCardBox(cardBox1Bot3, cards[0]);
                SetCardBox(cardBox2Bot3, cards[1]);
            }

        }
        
        public void SetMiddleCards()
        {
            deck.Shuffle();
            SetCardBox(cardBoxMiddle1, deck.GetCard());
            SetCardBox(cardBoxMiddle2, deck.GetCard());
            SetCardBox(cardBoxMiddle3, deck.GetCard());
            SetCardBox(cardBoxMiddle4, deck.GetCard());
            SetCardBox(cardBoxMiddle5, deck.GetCard());

        }

        public void CheckPlayerTurn()
        {
            if (game.GetPlayerTurn() == 0)
            {
                labelPlayerTurn.Text = "Your Turn";
            }
            else
            {
                labelPlayerTurn.Text = string.Format("Bot {0}'s Turn", game.GetPlayers()[game.GetPlayerTurn()].GetId());
            }
        }

        Timer bot1Timer;
        Timer bot2Timer;
        Timer bot3Timer;

        #endregion

        #region PRIVATE METHODS
        private void InitiateBot()
        {
            bot1Timer = new Timer() { Interval = 5000 };

            bot1Timer.Tick += (s, ea) => Bot1Turn();

            bot1Timer.Start();

            if (game.GetNumberOfPlayers() >= 3)
            {
                bot2Timer = new Timer() { Interval = 10000 };
                bot2Timer.Tick += (s, ea) => Bot2Turn();
                bot2Timer.Start();
                if (game.GetNumberOfPlayers() == 4)
                {
                    bot3Timer = new Timer() { Interval = 15000 };
                    bot3Timer.Tick += (s, ea) => Bot3Turn();
                    bot3Timer.Start();
                }
            }
        }
        private void Bot1Turn()
        {
            if (bot1Timer != null)
            {
                bot1Timer.Stop();
                bot1Timer.Dispose();
                bot1Timer = null;
            }

            if (allPlayers[1].GetFold())
            {
                game.NextTurn();
            }
            else
            {
                allPlayers[1].Check();
                game.NextTurn();
                CheckPlayerTurn();
                if (allPlayers.Count == 2)
                {
                    EnableOrDisablePlayerControls();
                }
                OpenMiddleCard();
            }

        }

        private void Bot2Turn()
        {
            if (bot2Timer != null)
            {
                bot2Timer.Stop();
                bot2Timer.Dispose();
                bot2Timer = null;
            }

            if (allPlayers[2].GetFold())
            {
                game.NextTurn();
            }
            else
            {
                allPlayers[2].Check();
                game.NextTurn();
                CheckPlayerTurn();
                if (allPlayers.Count == 3)
                {
                    EnableOrDisablePlayerControls();
                }

                OpenMiddleCard();
            }
        }

        private void Bot3Turn()
        {
            if (bot3Timer != null)
            {
                bot3Timer.Stop();
                bot3Timer.Dispose();
                bot3Timer = null;
            }

            if (allPlayers[3].GetFold())
            {
                game.NextTurn();
            }
            else
            {
                allPlayers[3].Check();
                game.NextTurn();
                CheckPlayerTurn();
                if (allPlayers.Count == 4)
                {
                    if (!allPlayers[0].GetFold())
                    {
                        EnableOrDisablePlayerControls();
                    }
                }

                OpenMiddleCard();
            }
        }

        private void EnableOrDisablePlayerControls()
        {
            buttonCheck.Enabled = !buttonCheck.Enabled;
            buttonCall.Enabled = !buttonCall.Enabled;
            buttonFold.Enabled = !buttonFold.Enabled;
            buttonRaise.Enabled = !buttonRaise.Enabled;
        }

        private void SetCardBox(UserControl userControl, Card card)
        {
            CardBox.CardBox cardBox = userControl as CardBox.CardBox;

            cardBox.Suit = card.Suit;
            cardBox.Rank = card.Rank;
        }

        private void OpenMiddleCard()
        {
            if (game.RevealCard())
            {
                if (!cardBoxMiddle1.FaceUp)
                {
                    cardBoxMiddle1.FaceUp = true;
                    cardBoxMiddle2.FaceUp = true;
                    cardBoxMiddle3.FaceUp = true;
                }
                else if (!cardBoxMiddle4.FaceUp)
                {
                    cardBoxMiddle4.FaceUp = true;
                }
                else if (!cardBoxMiddle5.FaceUp)
                {
                    cardBoxMiddle5.FaceUp = true;
                    EndAndNextRound();
                }
                foreach (Player p in allPlayers)
                {
                    p.SetCheck(false);
                }
            }
        }
        #endregion 

        #region EVENT HANDLERS

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            allPlayers[0].Check();
            game.NextTurn();
            CheckPlayerTurn();
            EnableOrDisablePlayerControls();

            InitiateBot();
        }

        private async void buttonFold_Click(object sender, EventArgs e)
        {
            allPlayers[0].Fold();

            cardBox1Player.FaceUp = false;
            cardBox2Player.FaceUp = false;

            game.NextTurn();
            CheckPlayerTurn();
            EnableOrDisablePlayerControls();

            while (!cardBoxMiddle5.FaceUp)
            {
                InitiateBot();
                await Task.Delay(15000);
            }
        }
        #endregion

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            RaiseInput raiseForm = new RaiseInput();
            raiseForm.Show();
            raiseForm.Focus();
        }
    }
}
