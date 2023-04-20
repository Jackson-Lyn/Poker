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
using System.Collections.ObjectModel;

namespace PokerGame
{
    public partial class FiveCard : Form
    {

        #region GLOBAL VARIABLES AND CONSTANTS
        Game game = new Game();
        List<Player> allPlayers = new List<Player>();
        Deck deck = new Deck();
     

        const int TWO_PLAYERS = 2;
        const int THREE_PLAYERS = 3;
        const int FOUR_PLAYERS = 4;

        const int ONE_SECOND = 1000;
        const int ONE_HALF_SECOND = 1500;
        const int FIVE_SECONDS = 5000;
        const int SIX_SECONDS = 6000;
        #endregion

        #region CONSTRUCTORS
        public FiveCard()
        {
            InitializeComponent();
        }

        private List<CardBox.CardBox> CardBoxes;
        public FiveCard(string difficulty, string chips, string players)
        {
            InitializeComponent();
            cardBox1Player.Click += CardBox_Click;
            cardBox2Player.Click += CardBox_Click;
            cardBox3Player.Click += CardBox_Click;
            cardBox4Player.Click += CardBox_Click;
            cardBox5Player.Click += CardBox_Click;
            deck.Shuffle();
           CardBoxes = new List<CardBox.CardBox>
            {
                cardBox1Player, cardBox2Player, cardBox3Player, cardBox4Player, cardBox5Player
            };
            SetPictures();
            int numOfPlayers = int.Parse(players);

            if (numOfPlayers == TWO_PLAYERS)
            {
                cardBox1Bot2.Visible = false;
                cardBox2Bot2.Visible = false;
                cardBox3Bot2.Visible = false;
                cardBox4Bot2.Visible = false;
                cardBox5Bot2.Visible = false;
                cardBox1Bot3.Visible = false;
                cardBox2Bot3.Visible = false;
                cardBox3Bot3.Visible = false;
                cardBox4Bot3.Visible = false;
                cardBox5Bot3.Visible = false;
            }
            else if (numOfPlayers == THREE_PLAYERS)
            {
                cardBox1Bot3.Visible = false;
                cardBox2Bot3.Visible = false;
                cardBox3Bot3.Visible = false;
                cardBox4Bot3.Visible = false;
                cardBox5Bot3.Visible = false;
                //labelBot3Name.Visible = false;
            }
            Loading(chips, players);
        }

  
        #endregion

        #region CUSTOM DESIGN METHODS
        public void SetPictures()
        {
           // pictureBoxTitle.Image = Properties.Resources.ResourceManager.GetObject("TexasHoldem") as Image;
            picDealer.Image = Properties.Resources.ResourceManager.GetObject("dealer") as Image;
            picChips.Image = Properties.Resources.ResourceManager.GetObject("chips") as Image;
          //  pictureBoxDialog2.Image = Properties.Resources.ResourceManager.GetObject("dialog") as Image;
        }
        #endregion

        #region ASYNC METHODS

        private async void Loading(string chips, string players)
        {
            DisablePlayerControls();
            await Task.Delay(FIVE_SECONDS);
            textRoundNumber.Text = game.GetRoundNumber().ToString();
            labelPot.Text = string.Format("Pot: {0} Chips", game.GetPot());

            await Task.Delay(ONE_HALF_SECOND);
            textBoxTotalChips.Text = chips;

            int numOfPlayers = int.Parse(players);
            game.SetNumberOfPlayers(numOfPlayers);

            for (int i = 0; i < numOfPlayers; i++)
            {
                List<Card> userCards = new List<Card>
                {
                    deck.GetCard(),
                    deck.GetCard(),
                    deck.GetCard(),
                    deck.GetCard(),
                    deck.GetCard()
                };
                Player user = new Player(i, userCards, int.Parse(chips));
                SetPlayerCards(userCards, user.GetId());
                allPlayers.Add(user);
            }
            game.SetPlayers(allPlayers);

            CheckPlayerTurn();

            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            cardBox3Player.FaceUp = true;
            cardBox4Player.FaceUp = true;
            cardBox5Player.FaceUp = true;
            EnablePlayerControls();
        }

        private void FaceDownAllCards()
        {
            cardBox1Player.FaceUp = false;
            cardBox2Player.FaceUp = false;
            cardBox3Player.FaceUp = false;
            cardBox4Player.FaceUp = false;
            cardBox5Player.FaceUp = false;
            cardBox1Bot2.FaceUp = false;
            cardBox2Bot2.FaceUp = false;
            cardBox3Bot2.FaceUp = false;
            cardBox4Bot2.FaceUp = false;
            cardBox5Bot2.FaceUp = false;
            cardBox1Bot1.FaceUp = false;
            cardBox2Bot1.FaceUp = false;
            cardBox3Bot1.FaceUp = false;
            cardBox4Bot1.FaceUp = false;
            cardBox5Bot1.FaceUp = false;
            cardBox1Bot3.FaceUp = false;
            cardBox2Bot3.FaceUp = false;
            cardBox3Bot3.FaceUp = false;
            cardBox4Bot3.FaceUp = false;
            cardBox5Bot3.FaceUp = false;
        }

        private void FaceUpAllCards()
        {
            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            cardBox3Player.FaceUp = true;
            cardBox4Player.FaceUp = true;
            cardBox5Player.FaceUp = true;
            cardBox1Bot2.FaceUp = true;
            cardBox2Bot2.FaceUp = true;
            cardBox3Bot2.FaceUp = true;
            cardBox4Bot2.FaceUp = true;
            cardBox5Bot2.FaceUp = true;
            cardBox1Bot1.FaceUp = true;
            cardBox2Bot1.FaceUp = true;
            cardBox3Bot1.FaceUp = true;
            cardBox4Bot1.FaceUp = true;
            cardBox5Bot1.FaceUp = true;
            cardBox1Bot3.FaceUp = true;
            cardBox2Bot3.FaceUp = true;
            cardBox3Bot3.FaceUp = true;
            cardBox4Bot3.FaceUp = true;
            cardBox5Bot3.FaceUp = true;
        }

        private async void EndAndNextRound()
        {
            DisablePlayerControls();
            FaceUpAllCards();
            DetermineWinner();
            game.NextRound();
            labelPlayerTurn.Text = "Loading Next Round";
            textRoundNumber.Text = game.GetRoundNumber().ToString();
            await Task.Delay(FIVE_SECONDS);
            game.ResetPot();
            labelPot.Text = "Pot: " + game.GetPot().ToString() + " Chips";
            FaceDownAllCards();
            deck = new Deck();
            deck.Shuffle();
            foreach (Player p in allPlayers)
            {
                p.UnFold();
                p.UnCheck();
            }
            await Task.Delay(FIVE_SECONDS);

            for (int i = 0; i < game.GetPlayers().Count; i++)
            {
                List<Card> userCards = new List<Card>
                {
                    deck.GetCard(),
                    deck.GetCard()
                };
                game.GetPlayers()[i].SetCards(userCards);
                SetPlayerCards(userCards, game.GetPlayers()[i].GetId());
            }
            
            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            cardBox3Player.FaceUp = true;
            cardBox4Player.FaceUp = true;
            cardBox5Player.FaceUp = true;
            game.SetPlayerTurn(0);
            CheckPlayerTurn();

            EnablePlayerControls();
        }
        #endregion

        #region PUBLIC METHODS
      

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


        public void SwapCards()
        {
            foreach (CardBox.CardBox cardBox in CardBoxes)
            {
                if (cardBox.BorderStyle == BorderStyle.Fixed3D)
                {
                    Card newCard = deck.GetCard();
                    if (newCard != null)
                    {
                        cardBox.Card = newCard;
                        cardBox.BorderStyle = BorderStyle.None;
                    }
                    }
            }
        }



        #endregion

        #region PRIVATE METHODS
        private void UpdatePotLabel()
        {
            labelPot.Text = "Pot: " + game.GetPot().ToString() + " Chips";
        }

        private void InitiateBot()
        {
            bot1Timer = new Timer() { Interval = SIX_SECONDS };

            bot1Timer.Tick += (s, ea) => Bot1Turn();

            bot1Timer.Start();

            if (game.GetNumberOfPlayers() >= THREE_PLAYERS)
            {
                bot2Timer = new Timer() { Interval = SIX_SECONDS * 2 };
                bot2Timer.Tick += (s, ea) => Bot2Turn();
                bot2Timer.Start();
                if (game.GetNumberOfPlayers() == FOUR_PLAYERS)
                {
                    bot3Timer = new Timer() { Interval = SIX_SECONDS * 3 };
                    bot3Timer.Tick += (s, ea) => Bot3Turn();
                    bot3Timer.Start();
                }
            }
        }
        private async void Bot1Turn()
        {
            if (bot1Timer != null)
            {
                bot1Timer.Stop();
                bot1Timer.Dispose();
                bot1Timer = null;
            }

            if (game.GetPlayers()[1].GetFold())
            {
                if (game.GetNumberOfPlayers() == TWO_PLAYERS)
                {
                    EndAndNextRound();
                }
                else
                {
                    game.NextTurn();
                    if (game.GetNumberOfPlayers() == THREE_PLAYERS)
                    {
                        if (game.GetPlayers()[0].GetFold() || game.GetPlayers()[2].GetFold())
                        {
                            EndAndNextRound();
                        }
                    }
                    else if (game.GetNumberOfPlayers() == FOUR_PLAYERS)
                    {
                        if ((game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold()) || (game.GetPlayers()[0].GetFold() && game.GetPlayers()[3].GetFold()) || (game.GetPlayers()[2].GetFold() && game.GetPlayers()[3].GetFold()))
                        {
                            EndAndNextRound();
                        }
                    }
                }
            }
            else
            {
                if (game.GetPlayers()[0].GetCheck())
                {
                    game.GetPlayers()[1].Check();
                    //pictureBoxDialog1.Visible = true;
                    //labelBot1.Text = "Check!";
                    await Task.Delay(ONE_SECOND);
                    //pictureBoxDialog1.Visible = false;
                    //labelBot1.Text = string.Empty;
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (allPlayers.Count == TWO_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                    //OpenMiddleCard();
                }
                else if (game.GetIsBetRaised())
                {
                    game.GetPlayers()[1].Bet(game.GetCurrentBet());
                    //pictureBoxDialog1.Visible = true;
                    //labelBot1.Text = "Call!";
                    await Task.Delay(ONE_SECOND);
                    //pictureBoxDialog1.Visible = false;
                    //labelBot1.Text = string.Empty;
                    game.AddPot(game.GetCurrentBet());
                    UpdatePotLabel();
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (game.GetNumberOfPlayers() == TWO_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                    //OpenMiddleCard();
                }
            }

        }

        private async void Bot2Turn()
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
                if (game.GetPlayers()[0].GetCheck())
                {
                    game.GetPlayers()[2].Check();
                    //pictureBoxDialog2.Visible = true;
                    //labelBot2.Text = "Check!";
                    await Task.Delay(ONE_SECOND);
                    //pictureBoxDialog2.Visible = false;
                    //labelBot2.Text = string.Empty;
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (allPlayers.Count == THREE_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                    //OpenMiddleCard();
                }
                else if (game.GetIsBetRaised())
                {
                    game.GetPlayers()[2].Bet(game.GetCurrentBet());
                    //pictureBoxDialog2.Visible = true;
                    //labelBot2.Text = "Call!";
                    await Task.Delay(ONE_SECOND);
                    //pictureBoxDialog2.Visible = false;
                    //labelBot2.Text = string.Empty;
                    game.AddPot(game.GetCurrentBet());
                    UpdatePotLabel();
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (game.GetNumberOfPlayers() == THREE_PLAYERS)
                    {
                        EnablePlayerControls();
                    }   
                }
            }
        }

        private async void Bot3Turn()
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
                if (game.GetPlayers()[0].GetCheck())
                {
                    game.GetPlayers()[3].Check();
                    //pictureBoxDialog3.Visible = true;
                   // labelBot3.Text = "Check!";
                    await Task.Delay(ONE_SECOND);
                    //pictureBoxDialog3.Visible = false;
                    //labelBot3.Text = string.Empty;
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (allPlayers.Count == FOUR_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                }
                else if (game.GetIsBetRaised())
                {
                    game.GetPlayers()[3].Bet(game.GetCurrentBet());
                    //pictureBoxDialog3.Visible = true;
                    //labelBot3.Text = "Call!";
                    await Task.Delay(ONE_SECOND);
                    //pictureBoxDialog3.Visible = false;
                    //labelBot3.Text = string.Empty;
                    game.AddPot(game.GetCurrentBet());
                    UpdatePotLabel();
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (game.GetNumberOfPlayers() == FOUR_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                }
            }
        }

        private void EnablePlayerControls()
        {
            buttonCheck.Enabled = true;
            buttonCall.Enabled = true;
            buttonFold.Enabled = true;
            buttonRaise.Enabled = true;
        }

        private void DisablePlayerControls()
        {
            buttonCheck.Enabled = false;
            buttonCall.Enabled = false;
            buttonFold.Enabled = false;
            buttonRaise.Enabled = false;
        }

        private void SetCardBox(UserControl userControl, Card card)
        {
            CardBox.CardBox cardBox = userControl as CardBox.CardBox;

            cardBox.Suit = card.Suit;
            cardBox.Rank = card.Rank;
        }

      

        private int SameHandRankingHelper(DetectHandRanking detect, DetectHandRanking detect1)
        {
            for (int i = 5; i > 0; i--)
            {
                if (((int)detect.cards[i].CardValue * 10 + (int)detect.cards[i].Suit) > ((int)detect1.cards[i].CardValue * 10 + (int)detect1.cards[i].Suit))
                {
                    return 0;
                }
                else if (((int)detect.cards[i].CardValue * 10 + (int)detect.cards[i].Suit) < ((int)detect1.cards[i].CardValue * 10 + (int)detect1.cards[i].Suit))
                {
                    return 1;
                }
            }
            return -1;
        }

        private void DetermineWinner()
        {
            #region TWO PLAYERS
            if (game.GetNumberOfPlayers() == TWO_PLAYERS)
            {
                if (game.GetPlayers()[0].GetFold())
                {
                    game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                    MessageBox.Show("Bot 1 Wins The Round!");
                }
                else if (game.GetPlayers()[1].GetFold())
                {
                    game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                    MessageBox.Show("You Win The Round!");
                }
                else
                {
                    List<Card> allPlayerCards = new List<Card>();
                    List<Card> allBot1Cards = new List<Card>();

                   

                    DetectHandRanking detect = new DetectHandRanking(allPlayerCards);
                    DetectHandRanking detect1 = new DetectHandRanking(allBot1Cards);

                    if ((int)detect.DeterminePokerHandType() > (int)detect1.DeterminePokerHandType())
                    {
                        game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                        textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                        MessageBox.Show("You Win The Round!");
                    }
                    else if ((int)detect.DeterminePokerHandType() < (int)detect1.DeterminePokerHandType())
                    {
                        game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                        MessageBox.Show("Bot 1 Wins The Round!");
                    }
                    else
                    {
                        if (detect.totalCardValue > detect1.totalCardValue)
                        {
                            game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                            textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                            MessageBox.Show("You Win The Round!");
                        }
                        else if (detect.totalCardValue == detect1.totalCardValue)
                        {
                            if (SameHandRankingHelper(detect, detect1) == 0)
                            {
                                game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                                textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                                MessageBox.Show("You Win The Round!");
                            }
                            else if (SameHandRankingHelper(detect, detect1) == 1)
                            {

                                game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                                MessageBox.Show("Bot 1 Wins The Round!");
                            }
                            else
                            {
                                MessageBox.Show("Draw!");
                            }
                        }
                        else
                        {
                            game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                            MessageBox.Show("Bot 1 Wins The Round!");
                        }
                    }
                }
            }
            #endregion

            #region THREE PLAYERS
            else if (game.GetNumberOfPlayers() == 3)
            {
                if (game.GetPlayers()[1].GetFold() && game.GetPlayers()[2].GetFold())
                {
                    game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                    textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                    MessageBox.Show("You Win The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold())
                {
                    game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                    MessageBox.Show("Bot 1 Wins The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[1].GetFold())
                {
                    game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                    MessageBox.Show("Bot 2 Wins The Round!");
                }
                else
                {
                    List<Card> allPlayerCards = new List<Card>();
                    List<Card> allBot1Cards = new List<Card>();
                    List<Card> allBot2Cards = new List<Card>();

                  

                    if (!game.GetPlayers()[0].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[0].GetCards())
                        {
                            allPlayerCards.Add(card);
                        }
                    }
                    else
                    {
                        allPlayerCards.Clear();
                    }
                    if (!game.GetPlayers()[1].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[1].GetCards())
                        {
                            allBot1Cards.Add(card);
                        }
                    }
                    else
                    {
                        allBot1Cards.Clear();
                    }
                    if (!game.GetPlayers()[2].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[2].GetCards())
                        {
                            allBot2Cards.Add(card);
                        }
                    }
                    else
                    {
                        allBot2Cards.Clear();
                    }

                    List<DetectHandRanking> detects = new List<DetectHandRanking>();

                    if (allPlayerCards.Count > 0)
                    {
                        DetectHandRanking detect = new DetectHandRanking(allPlayerCards);
                        detect.DeterminePokerHandType();
                        detects.Add(detect);
                    }
                    if (allBot1Cards.Count > 0)
                    {
                        DetectHandRanking detect1 = new DetectHandRanking(allBot1Cards); detect1.DeterminePokerHandType();
                        detects.Add(detect1);
                    }
                    if (allBot2Cards.Count > 0)
                    {
                        DetectHandRanking detect2 = new DetectHandRanking(allBot2Cards);
                        detect2.DeterminePokerHandType();
                        detects.Add(detect2);
                    }

                    int roundWinnerID = -1;

                    for (int i = 0; i < detects.Count; i++)
                    {
                        for (int j = 0; j < detects.Count; j++)
                        {
                            if (i != j)
                            {
                                if ((int)detects[i].DeterminePokerHandType() > (int)detects[j].DeterminePokerHandType())
                                {
                                    roundWinnerID = i;
                                }
                                else if ((int)detects[i].DeterminePokerHandType() < (int)detects[j].DeterminePokerHandType())
                                {
                                    j = detects.Count;
                                }
                                else
                                {
                                    if (detects[i].totalCardValue > detects[j].totalCardValue)
                                    {
                                        roundWinnerID = i;
                                    }
                                    else if (detects[i].totalCardValue < detects[j].totalCardValue)
                                    {
                                        j = detects.Count;
                                    }
                                    else
                                    {
                                        if (SameHandRankingHelper(detects[i], detects[j]) == 0)
                                        {
                                            roundWinnerID = i;
                                        }
                                        else if (SameHandRankingHelper(detects[i], detects[j]) == 1)
                                        {
                                            j = detects.Count;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (roundWinnerID == game.GetPlayers()[0].GetId())
                    {
                        game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                        textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                        MessageBox.Show(detects[0].DeterminePokerHandType().ToString());
                        MessageBox.Show("You Win The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[1].GetId())
                    {
                        game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                        MessageBox.Show(detects[1].DeterminePokerHandType().ToString());
                        MessageBox.Show("Bot 1 Wins The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[2].GetId())
                    {
                        game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                        MessageBox.Show(detects[2].DeterminePokerHandType().ToString());
                        MessageBox.Show("Bot 2 Wins The Round!");
                    }
                }
            }

            #endregion

            #region FOUR PLAYERS
            else if (game.GetNumberOfPlayers() == 4)
            {
                if (game.GetPlayers()[1].GetFold() && game.GetPlayers()[2].GetFold() && game.GetPlayers()[3].GetFold())
                {
                    game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                    textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                    MessageBox.Show("You Win The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold() && game.GetPlayers()[3].GetFold())
                {
                    game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                    MessageBox.Show("Bot 1 Wins The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[1].GetFold() && game.GetPlayers()[3].GetFold())
                {
                    game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                    MessageBox.Show("Bot 2 Wins The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold() && game.GetPlayers()[2].GetFold())
                {
                    game.GetPlayers()[3].SetChips(game.GetPot() + game.GetPlayers()[3].GetChips());
                    MessageBox.Show("Bot 3 Wins The Round!");
                }
                else
                {
                    List<Card> allPlayerCards = new List<Card>();
                    List<Card> allBot1Cards = new List<Card>();
                    List<Card> allBot2Cards = new List<Card>();
                    List<Card> allBot3Cards = new List<Card>();

                 

                    if (!game.GetPlayers()[0].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[0].GetCards())
                        {
                            allPlayerCards.Add(card);
                        }
                    }
                    else
                    {
                        allPlayerCards.Clear();
                    }
                    if (!game.GetPlayers()[1].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[1].GetCards())
                        {
                            allBot1Cards.Add(card);
                        }
                    }
                    else
                    {
                        allBot1Cards.Clear();
                    }
                    if (!game.GetPlayers()[2].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[2].GetCards())
                        {
                            allBot2Cards.Add(card);
                        }
                    }
                    else
                    {
                        allBot2Cards.Clear();
                    }
                    if (!game.GetPlayers()[3].GetFold())
                    {
                        foreach (Card card in game.GetPlayers()[3].GetCards())
                        {
                            allBot3Cards.Add(card);
                        }
                    }
                    else
                    {
                        allBot3Cards.Clear();
                    }

                    List<DetectHandRanking> detects = new List<DetectHandRanking>();

                    if (allPlayerCards.Count > 0)
                    {
                        DetectHandRanking detect = new DetectHandRanking(allPlayerCards);
                        detect.DeterminePokerHandType();
                        detects.Add(detect);
                    }
                    if (allBot1Cards.Count > 0)
                    {
                        DetectHandRanking detect1 = new DetectHandRanking(allBot1Cards); detect1.DeterminePokerHandType();
                        detects.Add(detect1);
                    }
                    if (allBot2Cards.Count > 0)
                    {
                        DetectHandRanking detect2 = new DetectHandRanking(allBot2Cards);
                        detect2.DeterminePokerHandType();
                        detects.Add(detect2);
                    }
                    if (allBot3Cards.Count > 0)
                    {
                        DetectHandRanking detect3 = new DetectHandRanking(allBot3Cards);
                        detect3.DeterminePokerHandType();
                        detects.Add(detect3);
                    }

                    int roundWinnerID = -1;

                    for (int i = 0; i < detects.Count; i++)
                    {
                        for (int j = 0; j < detects.Count; j++)
                        {
                            if (i != j)
                            {
                                if ((int)detects[i].DeterminePokerHandType() > (int)detects[j].DeterminePokerHandType())
                                {
                                    roundWinnerID = i;
                                }
                                else if ((int)detects[i].DeterminePokerHandType() < (int)detects[j].DeterminePokerHandType())
                                {
                                    j = detects.Count;
                                }
                                else
                                {
                                    if (detects[i].totalCardValue > detects[j].totalCardValue)
                                    {
                                        roundWinnerID = i;
                                    }
                                    else if (detects[i].totalCardValue < detects[j].totalCardValue)
                                    {
                                        j = detects.Count;
                                    }
                                    else
                                    {
                                        if (SameHandRankingHelper(detects[i], detects[j]) == 0)
                                        {
                                            roundWinnerID = i;
                                        }
                                        else if (SameHandRankingHelper(detects[i], detects[j]) == 1)
                                        {
                                            j = detects.Count;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (roundWinnerID == game.GetPlayers()[0].GetId())
                    {
                        game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                        textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                        MessageBox.Show(detects[0].DeterminePokerHandType().ToString());
                        MessageBox.Show("You Win The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[1].GetId())
                    {
                        game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                        MessageBox.Show(detects[1].DeterminePokerHandType().ToString());
                        MessageBox.Show("Bot 1 Wins The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[2].GetId())
                    {
                        game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                        MessageBox.Show(detects[2].DeterminePokerHandType().ToString());
                        MessageBox.Show("Bot 2 Wins The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[3].GetId())
                    {
                        game.GetPlayers()[3].SetChips(game.GetPot() + game.GetPlayers()[3].GetChips());
                        MessageBox.Show(detects[3].DeterminePokerHandType().ToString());
                        MessageBox.Show("Bot 3 Wins The Round!");
                    }
                }
            }

            #endregion
        }
        #endregion 

        #region EVENT HANDLERS

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            game.GetPlayers()[0].Check();
            game.NextTurn();
            CheckPlayerTurn();
            DisablePlayerControls();

            InitiateBot();
        }

        private async void buttonFold_Click(object sender, EventArgs e)
        {
            if (game.GetPlayers()[0].GetIsBet())
            {
                game.GetPlayers()[0].Fold();

                cardBox1Player.FaceUp = false;
                cardBox2Player.FaceUp = false;

                game.NextTurn();
                CheckPlayerTurn();
                DisablePlayerControls();

                if (game.GetNumberOfPlayers() == TWO_PLAYERS)
                {
                    EndAndNextRound();
                }
                else if (game.GetNumberOfPlayers() == THREE_PLAYERS)
                {
                    if (game.GetPlayers()[1].GetFold() || game.GetPlayers()[2].GetFold())
                    {
                        EndAndNextRound();
                    }
                    else
                    {
                     
                            InitiateBot();
                            await Task.Delay(SIX_SECONDS * 2);
                        
                    }
                }
                else if (game.GetNumberOfPlayers() == FOUR_PLAYERS)
                {
                    if ((game.GetPlayers()[1].GetFold() && game.GetPlayers()[2].GetFold()) || (game.GetPlayers()[1].GetFold() && game.GetPlayers()[3].GetFold()) || (game.GetPlayers()[2].GetFold() && game.GetPlayers()[3].GetFold()))
                    {
                        EndAndNextRound();
                    }
                    else
                    {
                 
                    }
                }
            }
            else
            {
                MessageBox.Show("You are unable to fold unless you submit a bet.", "Illegal Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            using (RaiseInput raiseForm = new RaiseInput(game.GetPlayers()[0].GetChips()))
            {
                if (raiseForm.ShowDialog() == DialogResult.OK)
                {
                    game.GetPlayers()[0].Bet(raiseForm.GetChips());
                    textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                    game.SetIsBetRaised(true);
                    game.SetCurrentBet(raiseForm.GetChips());
                    game.AddPot(raiseForm.GetChips());

                    labelPot.Text = "Pot: " + game.GetPot().ToString() + " Chips";

                    game.NextTurn();
                    CheckPlayerTurn();
                    DisablePlayerControls();

                    InitiateBot();
                }
            }
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            if (game.GetIsBetRaised())
            {
                game.GetPlayers()[0].Bet(game.GetCurrentBet());
                game.NextTurn();
                CheckPlayerTurn();
                DisablePlayerControls();

                InitiateBot();
            }
            else
            {
                MessageBox.Show("Unable to call when no one raised the bet.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            SwapCards();
        }


        private void CardBox_Click(object sender, EventArgs e)
        {
            CardBox.CardBox clickedCardBox = (CardBox.CardBox)sender;
            if (clickedCardBox.BorderStyle == BorderStyle.None)
            {
                clickedCardBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                clickedCardBox.BorderStyle = BorderStyle.None;
            }
        }

        private void ShowHelpWindow(object sender, EventArgs e)
        {
            new TexasHoldEmHelp().Show();
        }

        #endregion


        public void SetPlayerCards(List<Card> cards, int id)
        {
            if (id == 1)
            {
                SetCardBox(cardBox1Player, cards[0]);
                SetCardBox(cardBox2Player, cards[1]);
                SetCardBox(cardBox3Player, cards[2]);
                SetCardBox(cardBox4Player, cards[3]);
                SetCardBox(cardBox5Player, cards[4]);
            }
            else if (id == 2)
            {
                SetCardBox(cardBox1Bot1, cards[0]);
                SetCardBox(cardBox2Bot1, cards[1]);
                SetCardBox(cardBox3Bot1, cards[2]);
                SetCardBox(cardBox4Bot1, cards[3]);
                SetCardBox(cardBox5Bot1, cards[4]);
            }
            else if (id == 3)
            {
                SetCardBox(cardBox1Bot2, cards[0]);
                SetCardBox(cardBox2Bot2, cards[1]);
                SetCardBox(cardBox3Bot2, cards[2]);
                SetCardBox(cardBox4Bot2, cards[3]);
                SetCardBox(cardBox5Bot2, cards[4]);
            }
            else if (id == 4)
            {
                SetCardBox(cardBox1Bot3, cards[0]);
                SetCardBox(cardBox2Bot3, cards[1]);
                SetCardBox(cardBox3Bot3, cards[2]);
                SetCardBox(cardBox4Bot3, cards[3]);
                SetCardBox(cardBox5Bot3, cards[4]);
            }

        }

        public void RoundLabel(System.Windows.Forms.Label label)
        {
            GraphicsPath graphicsPath = _getRoundPath(label.ClientRectangle, 10);

            label.Region = new Region(graphicsPath);

            label.Invalidate();
        }

        private static GraphicsPath _getRoundPath(Rectangle rectangle, int radius)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;

            radius = radius << 1;

            GraphicsPath path = new GraphicsPath();

            if (radius > 0)
            {
                if (radius > height) radius = height;
                if (radius > width) radius = width;
                path.AddArc(x, y, radius, radius, 180, 90);
                path.AddArc(x + width - radius, y, radius, radius, 270, 90);
                path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
                path.AddArc(x, y + height - radius, radius, radius, 90, 90);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(rectangle);
            }

            return path;
        }

        private void _drawRoundedRectangle(Graphics graphics, Pen pen, int x, int y, int width, int height, int radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = _generateRoundedRectangle(graphics, rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }
        private static GraphicsPath _generateRoundedRectangle(Graphics graphics, RectangleF rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rectangle.Location, sizeF);

            path.AddArc(arc, 180, 90);
            arc.X = rectangle.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rectangle.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void FiveCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(labelPot.BackColor, 6.0f))
            {
                _drawRoundedRectangle(e.Graphics, pen, labelPot.Location.X-1, labelPot.Location.Y-1, labelPot.ClientRectangle.Width+1, labelPot.ClientRectangle.Height+1, 10);
            }
        }


        private void ShowFiveCardMenu(object sender, EventArgs e)
        {
            new FiveCardHelp().Show();
        }
      

      
    }
}
// test
