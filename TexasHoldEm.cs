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
using System.Diagnostics.PerformanceData;
using System.ComponentModel.Design;

namespace PokerGame
{
    public partial class TexasHoldEm : Form
    {
        #region GLOBAL VARIABLES AND CONSTANTS
        Game game = new Game();
        List<Player> allPlayers = new List<Player>();
        Deck deck = new Deck();
        List<Card> middleCards = new List<Card>();

        const int TWO_PLAYERS = 2;
        const int THREE_PLAYERS = 3;
        const int FOUR_PLAYERS = 4;

        const int ONE_SECOND = 1000;
        const int ONE_HALF_SECOND = 1500;
        const int FIVE_SECONDS = 5000;
        const int SIX_SECONDS = 6000;

        private bool isEliminated = false;
        private string difficulty;
        private string chips;
        private string players;
        #endregion

        #region CONSTRUCTORS
        public TexasHoldEm()
        {
            InitializeComponent();
        }

        public TexasHoldEm(string difficulty, string chips, string players)
        {
            InitializeComponent();
            
            this.difficulty = difficulty;
            this.chips      = chips;
            this.players    = players;

            InitializeGame(difficulty, chips, players);
        }
        #endregion

        #region CUSTOM DESIGN METHODS
        public void SetPictures()
        {
            pictureBoxTitle.Image = Properties.Resources.ResourceManager.GetObject("TexasHoldem") as Image;
            picDealer.Image = Properties.Resources.ResourceManager.GetObject("dealer") as Image;
            picChips.Image = Properties.Resources.ResourceManager.GetObject("chips") as Image;
            pictureBoxDialog2.Image = Properties.Resources.ResourceManager.GetObject("dialog") as Image;
        }

        private void InitializeGame(string difficulty, string chips, string players)
        {
            pictureBoxDialog2.Visible = false;
            pictureBoxDialog1.Visible = false;
            pictureBoxDialog3.Visible = false;
            SetPictures();
            SetMiddleCards();
            int numOfPlayers = int.Parse(players);

            if (numOfPlayers == TWO_PLAYERS)
            {
                cardBox1Bot2.Visible = false;
                cardBox2Bot2.Visible = false;
                cardBox1Bot3.Visible = false;
                cardBox2Bot3.Visible = false;
                labelBot2Name.Visible = false;
                labelBot3Name.Visible = false;
            }
            else if (numOfPlayers == THREE_PLAYERS)
            {
                cardBox1Bot3.Visible = false;
                cardBox2Bot3.Visible = false;
                labelBot3Name.Visible = false;
            }
            Loading(chips, players);
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
            EnablePlayerControls();
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

        private async void ProceedToNextRound()
        {
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
                p.ResetBet();
            }
            game.SetIsBetRaised(false);
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
            SetMiddleCards();
            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            game.SetPlayerTurn(0);
            CheckPlayerTurn();

            EnablePlayerControls();
        }

        private async Task<DialogResult> ShowEndDialog(string message)
        {
            DialogResult result = MessageBox.Show(message, "Confirmation",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2,
                                   MessageBoxOptions.DefaultDesktopOnly);
            return result;
        }

        private async void EndAndNextRound()
        {
            DisablePlayerControls();
            FaceUpAllCards();
            DetermineWinner();

            bool hasChipsLeft = game.GetPlayers()[0].GetChips() > 0;
            // If human player lost in the current round
            if (! hasChipsLeft)
            {
                DialogResult result = await ShowEndDialog("Would you like to restart the game?"); 
                if (result == DialogResult.No)
                {
                    // Close this Form
                    this.Close();
                    this.Dispose();
                }
                else if (result == DialogResult.Yes)
                {
                    // Restart the game
                    TexasHoldEm texasHoldEm = new TexasHoldEm(this.difficulty, this.chips, this.players);
                    texasHoldEm.Show();
                    this.Dispose();
                }
            }
            // If the human player won in the current round
            else
            {
                DialogResult result = await ShowEndDialog("Would you like to continue to the next round?");
                if (result == DialogResult.No)
                {
                    // Close this Form
                    this.Close();
                    this.Dispose();
                }
                else if (result == DialogResult.Yes)
                {
                    this.Activate();
                    this.Focus();

                    // Proceed to the next round
                    ProceedToNextRound();
                }
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
            middleCards.Clear();
            deck.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                middleCards.Add(deck.GetCard());
            }
            SetCardBox(cardBoxMiddle1, middleCards[0]);
            SetCardBox(cardBoxMiddle2, middleCards[1]);
            SetCardBox(cardBoxMiddle3, middleCards[2]);
            SetCardBox(cardBoxMiddle4, middleCards[3]);
            SetCardBox(cardBoxMiddle5, middleCards[4]);

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
                    pictureBoxDialog1.Visible = true;
                    labelBot1.Text = "Check!";
                    await Task.Delay(ONE_SECOND);
                    pictureBoxDialog1.Visible = false;
                    labelBot1.Text = string.Empty;
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (allPlayers.Count == TWO_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                    OpenMiddleCard();
                }
                else if (game.GetIsBetRaised())
                {
                    if (game.GetPlayers()[1].GetPreviousBet() != 0)
                    {
                        game.GetPlayers()[1].Bet(game.GetPlayers()[1].GetPreviousBet() - game.GetCurrentBet());
                    }
                    else
                    {
                        game.GetPlayers()[1].Bet(game.GetCurrentBet());
                    }
                    game.GetPlayers()[1].SetIsCall(true);
                    pictureBoxDialog1.Visible = true;
                    labelBot1.Text = "Call!";
                    await Task.Delay(ONE_SECOND);
                    pictureBoxDialog1.Visible = false;
                    labelBot1.Text = string.Empty;
                    game.AddPot(game.GetCurrentBet());
                    UpdatePotLabel();
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (game.GetNumberOfPlayers() == TWO_PLAYERS)
                    {
                        if (game.GetIsBetRaised() && game.GetPlayers()[1].GetIsCall())
                        {
                            game.SetIsBetRaised(false);
                            foreach (Player p in game.GetPlayers())
                            {
                                p.SetIsCall(false);
                            }
                        }
                        EnablePlayerControls();
                    }
                    OpenMiddleCard();
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
                    pictureBoxDialog2.Visible = true;
                    labelBot2.Text = "Check!";
                    await Task.Delay(ONE_SECOND);
                    pictureBoxDialog2.Visible = false;
                    labelBot2.Text = string.Empty;
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (allPlayers.Count == THREE_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                    OpenMiddleCard();
                }
                else if (game.GetIsBetRaised())
                {
                    if (game.GetPlayers()[2].GetPreviousBet() != 0)
                    {
                        game.GetPlayers()[2].Bet(game.GetPlayers()[2].GetPreviousBet() - game.GetCurrentBet());
                    }
                    else
                    {
                        game.GetPlayers()[2].Bet(game.GetCurrentBet());
                    }
                    game.GetPlayers()[2].SetIsCall(true);
                    pictureBoxDialog2.Visible = true;
                    labelBot2.Text = "Call!";
                    await Task.Delay(ONE_SECOND);
                    pictureBoxDialog2.Visible = false;
                    labelBot2.Text = string.Empty;
                    game.AddPot(game.GetCurrentBet());
                    UpdatePotLabel();
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (game.GetNumberOfPlayers() == THREE_PLAYERS)
                    {
                        if (game.GetIsBetRaised() && game.GetPlayers()[1].GetIsCall() && game.GetPlayers()[2].GetIsCall())
                        {
                            game.SetIsBetRaised(false);
                            foreach(Player p in game.GetPlayers())
                            {
                                p.SetIsCall(false);
                            }
                        }
                        EnablePlayerControls();
                    }
                    OpenMiddleCard();
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
                    pictureBoxDialog3.Visible = true;
                    labelBot3.Text = "Check!";
                    await Task.Delay(ONE_SECOND);
                    pictureBoxDialog3.Visible = false;
                    labelBot3.Text = string.Empty;
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (allPlayers.Count == FOUR_PLAYERS)
                    {
                        EnablePlayerControls();
                    }
                    OpenMiddleCard();
                }
                else if (game.GetIsBetRaised())
                {
                    if (game.GetPlayers()[3].GetPreviousBet() != 0)
                    {
                        game.GetPlayers()[3].Bet(game.GetPlayers()[3].GetPreviousBet() - game.GetCurrentBet());
                    }
                    else
                    {
                        game.GetPlayers()[3].Bet(game.GetCurrentBet());
                    }
                    game.GetPlayers()[3].SetIsCall(true);
                    pictureBoxDialog3.Visible = true;
                    labelBot3.Text = "Call!";
                    await Task.Delay(ONE_SECOND);
                    pictureBoxDialog3.Visible = false;
                    labelBot3.Text = string.Empty;
                    game.AddPot(game.GetCurrentBet());
                    UpdatePotLabel();
                    game.NextTurn();
                    CheckPlayerTurn();
                    if (game.GetNumberOfPlayers() == FOUR_PLAYERS)
                    {
                        if (game.GetIsBetRaised() && game.GetPlayers()[1].GetIsCall() && game.GetPlayers()[2].GetIsCall() && game.GetPlayers()[3].GetIsCall())
                        {
                            game.SetIsBetRaised(false);
                            foreach (Player p in game.GetPlayers())
                            {
                                p.SetIsCall(false);
                            }
                        }
                        EnablePlayerControls();
                    }
                    OpenMiddleCard();
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
                    p.UnCheck();
                }
            }
            else if (game.GetPlayerTurn() == 0)
            {
                foreach (Player p in allPlayers)
                {
                    p.UnCheck();
                }
            }
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
                    this.isEliminated = true;
                    MessageBox.Show("Bot 1 Wins The Round!");
                }
                else if (game.GetPlayers()[1].GetFold())
                {
                    game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                    this.isEliminated = false;
                    MessageBox.Show("You Win The Round!");
                }
                else
                {
                    List<Card> allPlayerCards = new List<Card>();
                    List<Card> allBot1Cards = new List<Card>();

                    foreach (Card card in middleCards)
                    {
                        allPlayerCards.Add(card);
                        allBot1Cards.Add(card);
                    }
                    foreach (Card card in allPlayers[0].GetCards())
                    {
                        allPlayerCards.Add(card);
                    }
                    foreach (Card card in allPlayers[1].GetCards())
                    {
                        allBot1Cards.Add(card);
                    }

                    DetectHandRanking detect = new DetectHandRanking(allPlayerCards);
                    DetectHandRanking detect1 = new DetectHandRanking(allBot1Cards);

                    if ((int)detect.DeterminePokerHandType() > (int)detect1.DeterminePokerHandType())
                    {
                        game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                        textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                        this.isEliminated = false;
                        MessageBox.Show("You Win The Round!");
                    }
                    else if ((int)detect.DeterminePokerHandType() < (int)detect1.DeterminePokerHandType())
                    {
                        game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                        this.isEliminated = true;
                        MessageBox.Show("Bot 1 Wins The Round!");
                    }
                    else
                    {
                        if (detect.totalCardValue > detect1.totalCardValue)
                        {
                            game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                            textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                            this.isEliminated = false;
                            MessageBox.Show("You Win The Round!");
                        }
                        else if (detect.totalCardValue == detect1.totalCardValue)
                        {
                            if (SameHandRankingHelper(detect, detect1) == 0)
                            {
                                game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                                textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                                this.isEliminated = false;
                                MessageBox.Show("You Win The Round!");
                            }
                            else if (SameHandRankingHelper(detect, detect1) == 1)
                            {

                                game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                                this.isEliminated = true;
                                MessageBox.Show("Bot 1 Wins The Round!");
                            }
                            else
                            {
                                this.isEliminated = false;
                                MessageBox.Show("Draw!");
                            }
                        }
                        else
                        {
                            game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                            this.isEliminated = true;
                            MessageBox.Show("Bot 1 Wins The Round!");
                        }
                    }
                }
            }
            #endregion

            #region THREE PLAYERS
            else if (game.GetNumberOfPlayers() == THREE_PLAYERS)
            {
                if (game.GetPlayers()[1].GetFold() && game.GetPlayers()[2].GetFold())
                {
                    game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                    textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                    this.isEliminated = false;
                    MessageBox.Show("You Win The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold())
                {
                    game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                    this.isEliminated = true;
                    MessageBox.Show("Bot 1 Wins The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[1].GetFold())
                {
                    game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                    this.isEliminated = true;
                    MessageBox.Show("Bot 2 Wins The Round!");
                }
                else
                {
                    List<Card> allPlayerCards = new List<Card>();
                    List<Card> allBot1Cards = new List<Card>();
                    List<Card> allBot2Cards = new List<Card>();

                    foreach (Card card in middleCards)
                    {
                        allPlayerCards.Add(card);
                        allBot1Cards.Add(card);
                        allBot2Cards.Add(card);
                    }

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
                        this.isEliminated = false;
                        MessageBox.Show("You Win The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[1].GetId())
                    {
                        game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                        MessageBox.Show(detects[1].DeterminePokerHandType().ToString());
                        this.isEliminated = true;
                        MessageBox.Show("Bot 1 Wins The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[2].GetId())
                    {
                        game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                        MessageBox.Show(detects[2].DeterminePokerHandType().ToString());
                        this.isEliminated = true;
                        MessageBox.Show("Bot 2 Wins The Round!");
                    }
                }
            }

            #endregion

            #region FOUR PLAYERS
            else if (game.GetNumberOfPlayers() == FOUR_PLAYERS)
            {
                if (game.GetPlayers()[1].GetFold() && game.GetPlayers()[2].GetFold() && game.GetPlayers()[3].GetFold())
                {
                    game.GetPlayers()[0].SetChips(game.GetPot() + game.GetPlayers()[0].GetChips());
                    textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                    this.isEliminated = false;
                    MessageBox.Show("You Win The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold() && game.GetPlayers()[3].GetFold())
                {
                    game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                    this.isEliminated = true;
                    MessageBox.Show("Bot 1 Wins The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[1].GetFold() && game.GetPlayers()[3].GetFold())
                {
                    game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                    this.isEliminated = true;
                    MessageBox.Show("Bot 2 Wins The Round!");
                }
                else if (game.GetPlayers()[0].GetFold() && game.GetPlayers()[2].GetFold() && game.GetPlayers()[2].GetFold())
                {
                    game.GetPlayers()[3].SetChips(game.GetPot() + game.GetPlayers()[3].GetChips());
                    this.isEliminated = true;
                    MessageBox.Show("Bot 3 Wins The Round!");
                }
                else
                {
                    List<Card> allPlayerCards = new List<Card>();
                    List<Card> allBot1Cards = new List<Card>();
                    List<Card> allBot2Cards = new List<Card>();
                    List<Card> allBot3Cards = new List<Card>();

                    foreach (Card card in middleCards)
                    {
                        allPlayerCards.Add(card);
                        allBot1Cards.Add(card);
                        allBot2Cards.Add(card);
                        allBot3Cards.Add(card);
                    }

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
                        this.isEliminated = false;
                        MessageBox.Show("You Win The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[1].GetId())
                    {
                        game.GetPlayers()[1].SetChips(game.GetPot() + game.GetPlayers()[1].GetChips());
                        MessageBox.Show(detects[1].DeterminePokerHandType().ToString());
                        this.isEliminated = true;
                        MessageBox.Show("Bot 1 Wins The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[2].GetId())
                    {
                        game.GetPlayers()[2].SetChips(game.GetPot() + game.GetPlayers()[2].GetChips());
                        MessageBox.Show(detects[2].DeterminePokerHandType().ToString());
                        this.isEliminated = true;
                        MessageBox.Show("Bot 2 Wins The Round!");
                    }
                    else if (roundWinnerID == game.GetPlayers()[3].GetId())
                    {
                        game.GetPlayers()[3].SetChips(game.GetPot() + game.GetPlayers()[3].GetChips());
                        MessageBox.Show(detects[3].DeterminePokerHandType().ToString());
                        this.isEliminated = true;
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
                game.SetIsBetRaised(false);

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
                        while (!cardBoxMiddle4.FaceUp)
                        {
                            InitiateBot();
                            await Task.Delay(SIX_SECONDS * 2);
                        }
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
                        while (!cardBoxMiddle4.FaceUp)
                        {
                            InitiateBot();
                            await Task.Delay(SIX_SECONDS * 3);
                        }
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

                    UpdatePotLabel();

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
                game.GetPlayers()[0].Bet(game.GetCurrentBet() - game.GetPlayers()[0].GetPreviousBet());
                textBoxTotalChips.Text = game.GetPlayers()[0].GetChips().ToString();
                game.AddPot(game.GetCurrentBet() - game.GetPlayers()[0].GetPreviousBet());

                UpdatePotLabel();

                game.GetPlayers()[0].SetIsCall(true);
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

        private void ShowHelpWindow(object sender, EventArgs e)
        {
            new TexasHoldEmHelp().Show();
        }

        private void TexasHoldEm_Load(object sender, EventArgs e)
        {
            // Set the TopMost property of the form to true
            this.TopMost = true;
        }

        private void TexasHoldEm_Activated(object sender, EventArgs e)
        {
            // Set the TopMost property of the form back to false
            this.TopMost = false;
        }

        #endregion
    }
}
