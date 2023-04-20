namespace PokerGame
{
    partial class FiveCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFold = new System.Windows.Forms.Button();
            this.textBoxTotalChips = new System.Windows.Forms.TextBox();
            this.buttonRaise = new System.Windows.Forms.Button();
            this.buttonCall = new System.Windows.Forms.Button();
            this.labelRound = new System.Windows.Forms.Label();
            this.textRoundNumber = new System.Windows.Forms.TextBox();
            this.labelPlayerTurn = new System.Windows.Forms.Label();
            this.labelPot = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.cardBox5Player = new CardBox.CardBox();
            this.cardBox4Player = new CardBox.CardBox();
            this.cardBox3Player = new CardBox.CardBox();
            this.cardBox2Player = new CardBox.CardBox();
            this.cardBox1Player = new CardBox.CardBox();
            this.picChips = new System.Windows.Forms.PictureBox();
            this.picDealer = new System.Windows.Forms.PictureBox();
            this.cardBox2Bot1 = new CardBox.CardBox();
            this.cardBox1Bot1 = new CardBox.CardBox();
            this.cardBox4Bot1 = new CardBox.CardBox();
            this.cardBox3Bot1 = new CardBox.CardBox();
            this.cardBox5Bot1 = new CardBox.CardBox();
            this.cardBox1Bot2 = new CardBox.CardBox();
            this.cardBox2Bot2 = new CardBox.CardBox();
            this.cardBox3Bot2 = new CardBox.CardBox();
            this.cardBox4Bot2 = new CardBox.CardBox();
            this.cardBox5Bot2 = new CardBox.CardBox();
            this.cardBox4Bot3 = new CardBox.CardBox();
            this.cardBox3Bot3 = new CardBox.CardBox();
            this.cardBox2Bot3 = new CardBox.CardBox();
            this.cardBox1Bot3 = new CardBox.CardBox();
            this.cardBox5Bot3 = new CardBox.CardBox();
            this.buttonSwap = new System.Windows.Forms.Button();
            this.pictureBoxDialog = new System.Windows.Forms.PictureBox();
            this.labelBot1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picChips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialog)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1252, 644);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowFiveCardMenu);
            // 
            // buttonFold
            // 
            this.buttonFold.Location = new System.Drawing.Point(860, 642);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(67, 27);
            this.buttonFold.TabIndex = 3;
            this.buttonFold.Text = "Fold";
            this.buttonFold.UseVisualStyleBackColor = true;
            this.buttonFold.Click += new System.EventHandler(this.buttonFold_Click);
            // 
            // textBoxTotalChips
            // 
            this.textBoxTotalChips.Location = new System.Drawing.Point(381, 448);
            this.textBoxTotalChips.Name = "textBoxTotalChips";
            this.textBoxTotalChips.ReadOnly = true;
            this.textBoxTotalChips.Size = new System.Drawing.Size(100, 22);
            this.textBoxTotalChips.TabIndex = 4;
            // 
            // buttonRaise
            // 
            this.buttonRaise.Location = new System.Drawing.Point(860, 604);
            this.buttonRaise.Name = "buttonRaise";
            this.buttonRaise.Size = new System.Drawing.Size(67, 27);
            this.buttonRaise.TabIndex = 5;
            this.buttonRaise.Text = "Raise";
            this.buttonRaise.UseVisualStyleBackColor = true;
            this.buttonRaise.Click += new System.EventHandler(this.buttonRaise_Click);
            // 
            // buttonCall
            // 
            this.buttonCall.Location = new System.Drawing.Point(860, 566);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(67, 27);
            this.buttonCall.TabIndex = 6;
            this.buttonCall.Text = "Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.buttonCall_Click);
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.BackColor = System.Drawing.Color.Gold;
            this.labelRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelRound.Location = new System.Drawing.Point(218, 20);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(111, 29);
            this.labelRound.TabIndex = 21;
            this.labelRound.Text = "ROUND:";
            // 
            // textRoundNumber
            // 
            this.textRoundNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textRoundNumber.Location = new System.Drawing.Point(335, 20);
            this.textRoundNumber.Name = "textRoundNumber";
            this.textRoundNumber.ReadOnly = true;
            this.textRoundNumber.Size = new System.Drawing.Size(27, 30);
            this.textRoundNumber.TabIndex = 22;
            // 
            // labelPlayerTurn
            // 
            this.labelPlayerTurn.AutoSize = true;
            this.labelPlayerTurn.BackColor = System.Drawing.Color.Red;
            this.labelPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelPlayerTurn.Location = new System.Drawing.Point(218, 59);
            this.labelPlayerTurn.Name = "labelPlayerTurn";
            this.labelPlayerTurn.Size = new System.Drawing.Size(230, 29);
            this.labelPlayerTurn.TabIndex = 23;
            this.labelPlayerTurn.Text = "PLAYER X\'s TURN";
            // 
            // labelPot
            // 
            this.labelPot.BackColor = System.Drawing.Color.Aqua;
            this.labelPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelPot.Location = new System.Drawing.Point(507, 234);
            this.labelPot.Name = "labelPot";
            this.labelPot.Size = new System.Drawing.Size(347, 29);
            this.labelPot.TabIndex = 37;
            this.labelPot.Text = "POT: X Chips";
            this.labelPot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(860, 527);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(67, 27);
            this.buttonCheck.TabIndex = 59;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // cardBox5Player
            // 
            this.cardBox5Player.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox5Player.FaceUp = false;
            this.cardBox5Player.Location = new System.Drawing.Point(735, 522);
            this.cardBox5Player.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox5Player.Name = "cardBox5Player";
            this.cardBox5Player.Rank = CardLibrary.Rank.Ace;
            this.cardBox5Player.Size = new System.Drawing.Size(113, 146);
            this.cardBox5Player.Suit = CardLibrary.Suit.Spades;
            this.cardBox5Player.TabIndex = 64;
            // 
            // cardBox4Player
            // 
            this.cardBox4Player.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox4Player.FaceUp = false;
            this.cardBox4Player.Location = new System.Drawing.Point(618, 522);
            this.cardBox4Player.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox4Player.Name = "cardBox4Player";
            this.cardBox4Player.Rank = CardLibrary.Rank.Ace;
            this.cardBox4Player.Size = new System.Drawing.Size(113, 146);
            this.cardBox4Player.Suit = CardLibrary.Suit.Spades;
            this.cardBox4Player.TabIndex = 63;
            // 
            // cardBox3Player
            // 
            this.cardBox3Player.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox3Player.FaceUp = false;
            this.cardBox3Player.Location = new System.Drawing.Point(501, 522);
            this.cardBox3Player.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox3Player.Name = "cardBox3Player";
            this.cardBox3Player.Rank = CardLibrary.Rank.Ace;
            this.cardBox3Player.Size = new System.Drawing.Size(113, 146);
            this.cardBox3Player.Suit = CardLibrary.Suit.Spades;
            this.cardBox3Player.TabIndex = 62;
            // 
            // cardBox2Player
            // 
            this.cardBox2Player.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox2Player.FaceUp = false;
            this.cardBox2Player.Location = new System.Drawing.Point(384, 522);
            this.cardBox2Player.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox2Player.Name = "cardBox2Player";
            this.cardBox2Player.Rank = CardLibrary.Rank.Ace;
            this.cardBox2Player.Size = new System.Drawing.Size(113, 146);
            this.cardBox2Player.Suit = CardLibrary.Suit.Spades;
            this.cardBox2Player.TabIndex = 61;
            // 
            // cardBox1Player
            // 
            this.cardBox1Player.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox1Player.FaceUp = false;
            this.cardBox1Player.Location = new System.Drawing.Point(267, 523);
            this.cardBox1Player.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox1Player.Name = "cardBox1Player";
            this.cardBox1Player.Rank = CardLibrary.Rank.Ace;
            this.cardBox1Player.Size = new System.Drawing.Size(113, 146);
            this.cardBox1Player.Suit = CardLibrary.Suit.Spades;
            this.cardBox1Player.TabIndex = 60;
            // 
            // picChips
            // 
            this.picChips.ImageLocation = "";
            this.picChips.Location = new System.Drawing.Point(267, 426);
            this.picChips.Name = "picChips";
            this.picChips.Size = new System.Drawing.Size(107, 74);
            this.picChips.TabIndex = 65;
            this.picChips.TabStop = false;
            // 
            // picDealer
            // 
            this.picDealer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picDealer.ImageLocation = "";
            this.picDealer.Location = new System.Drawing.Point(955, 459);
            this.picDealer.Name = "picDealer";
            this.picDealer.Size = new System.Drawing.Size(214, 210);
            this.picDealer.TabIndex = 66;
            this.picDealer.TabStop = false;
            // 
            // cardBox2Bot1
            // 
            this.cardBox2Bot1.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox2Bot1.FaceUp = false;
            this.cardBox2Bot1.Location = new System.Drawing.Point(546, 11);
            this.cardBox2Bot1.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox2Bot1.Name = "cardBox2Bot1";
            this.cardBox2Bot1.Rank = CardLibrary.Rank.Ace;
            this.cardBox2Bot1.Size = new System.Drawing.Size(113, 146);
            this.cardBox2Bot1.Suit = CardLibrary.Suit.Spades;
            this.cardBox2Bot1.TabIndex = 68;
            // 
            // cardBox1Bot1
            // 
            this.cardBox1Bot1.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox1Bot1.FaceUp = false;
            this.cardBox1Bot1.Location = new System.Drawing.Point(429, 11);
            this.cardBox1Bot1.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox1Bot1.Name = "cardBox1Bot1";
            this.cardBox1Bot1.Rank = CardLibrary.Rank.Ace;
            this.cardBox1Bot1.Size = new System.Drawing.Size(113, 146);
            this.cardBox1Bot1.Suit = CardLibrary.Suit.Spades;
            this.cardBox1Bot1.TabIndex = 67;
            // 
            // cardBox4Bot1
            // 
            this.cardBox4Bot1.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox4Bot1.FaceUp = false;
            this.cardBox4Bot1.Location = new System.Drawing.Point(781, 11);
            this.cardBox4Bot1.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox4Bot1.Name = "cardBox4Bot1";
            this.cardBox4Bot1.Rank = CardLibrary.Rank.Ace;
            this.cardBox4Bot1.Size = new System.Drawing.Size(113, 146);
            this.cardBox4Bot1.Suit = CardLibrary.Suit.Spades;
            this.cardBox4Bot1.TabIndex = 70;
            // 
            // cardBox3Bot1
            // 
            this.cardBox3Bot1.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox3Bot1.FaceUp = false;
            this.cardBox3Bot1.Location = new System.Drawing.Point(664, 11);
            this.cardBox3Bot1.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox3Bot1.Name = "cardBox3Bot1";
            this.cardBox3Bot1.Rank = CardLibrary.Rank.Ace;
            this.cardBox3Bot1.Size = new System.Drawing.Size(113, 146);
            this.cardBox3Bot1.Suit = CardLibrary.Suit.Spades;
            this.cardBox3Bot1.TabIndex = 69;
            // 
            // cardBox5Bot1
            // 
            this.cardBox5Bot1.CardOrientation = System.Windows.Forms.Orientation.Vertical;
            this.cardBox5Bot1.FaceUp = false;
            this.cardBox5Bot1.Location = new System.Drawing.Point(898, 11);
            this.cardBox5Bot1.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox5Bot1.Name = "cardBox5Bot1";
            this.cardBox5Bot1.Rank = CardLibrary.Rank.Ace;
            this.cardBox5Bot1.Size = new System.Drawing.Size(113, 146);
            this.cardBox5Bot1.Suit = CardLibrary.Suit.Spades;
            this.cardBox5Bot1.TabIndex = 71;
            // 
            // cardBox1Bot2
            // 
            this.cardBox1Bot2.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox1Bot2.FaceUp = false;
            this.cardBox1Bot2.Location = new System.Drawing.Point(-2, 99);
            this.cardBox1Bot2.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox1Bot2.Name = "cardBox1Bot2";
            this.cardBox1Bot2.Rank = CardLibrary.Rank.Ace;
            this.cardBox1Bot2.Size = new System.Drawing.Size(146, 113);
            this.cardBox1Bot2.Suit = CardLibrary.Suit.Spades;
            this.cardBox1Bot2.TabIndex = 73;
            // 
            // cardBox2Bot2
            // 
            this.cardBox2Bot2.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox2Bot2.FaceUp = false;
            this.cardBox2Bot2.Location = new System.Drawing.Point(-2, 207);
            this.cardBox2Bot2.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox2Bot2.Name = "cardBox2Bot2";
            this.cardBox2Bot2.Rank = CardLibrary.Rank.Ace;
            this.cardBox2Bot2.Size = new System.Drawing.Size(146, 113);
            this.cardBox2Bot2.Suit = CardLibrary.Suit.Spades;
            this.cardBox2Bot2.TabIndex = 72;
            // 
            // cardBox3Bot2
            // 
            this.cardBox3Bot2.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox3Bot2.FaceUp = false;
            this.cardBox3Bot2.Location = new System.Drawing.Point(-2, 321);
            this.cardBox3Bot2.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox3Bot2.Name = "cardBox3Bot2";
            this.cardBox3Bot2.Rank = CardLibrary.Rank.Ace;
            this.cardBox3Bot2.Size = new System.Drawing.Size(146, 113);
            this.cardBox3Bot2.Suit = CardLibrary.Suit.Spades;
            this.cardBox3Bot2.TabIndex = 74;
            // 
            // cardBox4Bot2
            // 
            this.cardBox4Bot2.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox4Bot2.FaceUp = false;
            this.cardBox4Bot2.Location = new System.Drawing.Point(-2, 432);
            this.cardBox4Bot2.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox4Bot2.Name = "cardBox4Bot2";
            this.cardBox4Bot2.Rank = CardLibrary.Rank.Ace;
            this.cardBox4Bot2.Size = new System.Drawing.Size(146, 113);
            this.cardBox4Bot2.Suit = CardLibrary.Suit.Spades;
            this.cardBox4Bot2.TabIndex = 75;
            // 
            // cardBox5Bot2
            // 
            this.cardBox5Bot2.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox5Bot2.FaceUp = false;
            this.cardBox5Bot2.Location = new System.Drawing.Point(-2, 540);
            this.cardBox5Bot2.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox5Bot2.Name = "cardBox5Bot2";
            this.cardBox5Bot2.Rank = CardLibrary.Rank.Ace;
            this.cardBox5Bot2.Size = new System.Drawing.Size(146, 113);
            this.cardBox5Bot2.Suit = CardLibrary.Suit.Spades;
            this.cardBox5Bot2.TabIndex = 76;
            // 
            // cardBox4Bot3
            // 
            this.cardBox4Bot3.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox4Bot3.FaceUp = false;
            this.cardBox4Bot3.Location = new System.Drawing.Point(1174, 382);
            this.cardBox4Bot3.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox4Bot3.Name = "cardBox4Bot3";
            this.cardBox4Bot3.Rank = CardLibrary.Rank.Ace;
            this.cardBox4Bot3.Size = new System.Drawing.Size(146, 113);
            this.cardBox4Bot3.Suit = CardLibrary.Suit.Spades;
            this.cardBox4Bot3.TabIndex = 78;
            // 
            // cardBox3Bot3
            // 
            this.cardBox3Bot3.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox3Bot3.FaceUp = false;
            this.cardBox3Bot3.Location = new System.Drawing.Point(1174, 265);
            this.cardBox3Bot3.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox3Bot3.Name = "cardBox3Bot3";
            this.cardBox3Bot3.Rank = CardLibrary.Rank.Ace;
            this.cardBox3Bot3.Size = new System.Drawing.Size(146, 113);
            this.cardBox3Bot3.Suit = CardLibrary.Suit.Spades;
            this.cardBox3Bot3.TabIndex = 77;
            // 
            // cardBox2Bot3
            // 
            this.cardBox2Bot3.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox2Bot3.FaceUp = false;
            this.cardBox2Bot3.Location = new System.Drawing.Point(1174, 148);
            this.cardBox2Bot3.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox2Bot3.Name = "cardBox2Bot3";
            this.cardBox2Bot3.Rank = CardLibrary.Rank.Ace;
            this.cardBox2Bot3.Size = new System.Drawing.Size(146, 113);
            this.cardBox2Bot3.Suit = CardLibrary.Suit.Spades;
            this.cardBox2Bot3.TabIndex = 80;
            // 
            // cardBox1Bot3
            // 
            this.cardBox1Bot3.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox1Bot3.FaceUp = false;
            this.cardBox1Bot3.Location = new System.Drawing.Point(1174, 31);
            this.cardBox1Bot3.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox1Bot3.Name = "cardBox1Bot3";
            this.cardBox1Bot3.Rank = CardLibrary.Rank.Ace;
            this.cardBox1Bot3.Size = new System.Drawing.Size(146, 113);
            this.cardBox1Bot3.Suit = CardLibrary.Suit.Spades;
            this.cardBox1Bot3.TabIndex = 79;
            // 
            // cardBox5Bot3
            // 
            this.cardBox5Bot3.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cardBox5Bot3.FaceUp = false;
            this.cardBox5Bot3.Location = new System.Drawing.Point(1174, 499);
            this.cardBox5Bot3.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox5Bot3.Name = "cardBox5Bot3";
            this.cardBox5Bot3.Rank = CardLibrary.Rank.Ace;
            this.cardBox5Bot3.Size = new System.Drawing.Size(146, 113);
            this.cardBox5Bot3.Suit = CardLibrary.Suit.Spades;
            this.cardBox5Bot3.TabIndex = 81;
            // 
            // buttonSwap
            // 
            this.buttonSwap.Location = new System.Drawing.Point(860, 473);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(67, 27);
            this.buttonSwap.TabIndex = 82;
            this.buttonSwap.Text = "Swap";
            this.buttonSwap.UseVisualStyleBackColor = true;
            this.buttonSwap.Click += new System.EventHandler(this.buttonSwap_Click);
            // 
            // pictureBoxDialog
            // 
            this.pictureBoxDialog.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\PokerGame\\Resources\\dial" +
    "og.png";
            this.pictureBoxDialog.Location = new System.Drawing.Point(1016, -5);
            this.pictureBoxDialog.Name = "pictureBoxDialog";
            this.pictureBoxDialog.Size = new System.Drawing.Size(162, 162);
            this.pictureBoxDialog.TabIndex = 83;
            this.pictureBoxDialog.TabStop = false;
            // 
            // labelBot1
            // 
            this.labelBot1.AutoSize = true;
            this.labelBot1.BackColor = System.Drawing.Color.White;
            this.labelBot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelBot1.Location = new System.Drawing.Point(1071, 78);
            this.labelBot1.Name = "labelBot1";
            this.labelBot1.Size = new System.Drawing.Size(0, 29);
            this.labelBot1.TabIndex = 84;
            // 
            // FiveCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1331, 673);
            this.Controls.Add(this.labelBot1);
            this.Controls.Add(this.pictureBoxDialog);
            this.Controls.Add(this.buttonSwap);
            this.Controls.Add(this.cardBox5Bot3);
            this.Controls.Add(this.cardBox2Bot3);
            this.Controls.Add(this.cardBox1Bot3);
            this.Controls.Add(this.cardBox4Bot3);
            this.Controls.Add(this.cardBox3Bot3);
            this.Controls.Add(this.cardBox5Bot2);
            this.Controls.Add(this.cardBox4Bot2);
            this.Controls.Add(this.cardBox3Bot2);
            this.Controls.Add(this.cardBox1Bot2);
            this.Controls.Add(this.cardBox2Bot2);
            this.Controls.Add(this.cardBox5Bot1);
            this.Controls.Add(this.cardBox4Bot1);
            this.Controls.Add(this.cardBox3Bot1);
            this.Controls.Add(this.cardBox2Bot1);
            this.Controls.Add(this.cardBox1Bot1);
            this.Controls.Add(this.picDealer);
            this.Controls.Add(this.picChips);
            this.Controls.Add(this.cardBox5Player);
            this.Controls.Add(this.cardBox4Player);
            this.Controls.Add(this.cardBox3Player);
            this.Controls.Add(this.cardBox2Player);
            this.Controls.Add(this.cardBox1Player);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.labelPot);
            this.Controls.Add(this.labelPlayerTurn);
            this.Controls.Add(this.textRoundNumber);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.buttonCall);
            this.Controls.Add(this.buttonRaise);
            this.Controls.Add(this.textBoxTotalChips);
            this.Controls.Add(this.buttonFold);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FiveCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiveCard";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FiveCard_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picChips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonFold;
        private System.Windows.Forms.TextBox textBoxTotalChips;
        private System.Windows.Forms.Button buttonRaise;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.TextBox textRoundNumber;
        private System.Windows.Forms.Label labelPlayerTurn;
        private System.Windows.Forms.Label labelPot;
        private System.Windows.Forms.Button buttonCheck;
        private CardBox.CardBox cardBox1Player;
        private CardBox.CardBox cardBox2Player;
        private CardBox.CardBox cardBox3Player;
        private CardBox.CardBox cardBox4Player;
        private CardBox.CardBox cardBox5Player;
        private System.Windows.Forms.PictureBox picChips;
        private System.Windows.Forms.PictureBox picDealer;
        private CardBox.CardBox cardBox2Bot1;
        private CardBox.CardBox cardBox1Bot1;
        private CardBox.CardBox cardBox4Bot1;
        private CardBox.CardBox cardBox3Bot1;
        private CardBox.CardBox cardBox5Bot1;
        private CardBox.CardBox cardBox1Bot2;
        private CardBox.CardBox cardBox2Bot2;
        private CardBox.CardBox cardBox3Bot2;
        private CardBox.CardBox cardBox4Bot2;
        private CardBox.CardBox cardBox5Bot2;
        private CardBox.CardBox cardBox4Bot3;
        private CardBox.CardBox cardBox3Bot3;
        private CardBox.CardBox cardBox2Bot3;
        private CardBox.CardBox cardBox1Bot3;
        private CardBox.CardBox cardBox5Bot3;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.PictureBox pictureBoxDialog;
        private System.Windows.Forms.Label labelBot1;
    }
}