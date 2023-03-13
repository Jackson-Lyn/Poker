namespace WindowsFormsApp1
{
    partial class TexasHoldEm
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
            this.picChips = new System.Windows.Forms.PictureBox();
            this.picDealer = new System.Windows.Forms.PictureBox();
            this.buttonFold = new System.Windows.Forms.Button();
            this.textBoxTotalChips = new System.Windows.Forms.TextBox();
            this.buttonRaise = new System.Windows.Forms.Button();
            this.buttonCall = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picCenterCard1 = new System.Windows.Forms.PictureBox();
            this.picCenterCard2 = new System.Windows.Forms.PictureBox();
            this.picCenterCard3 = new System.Windows.Forms.PictureBox();
            this.picCenterCard4 = new System.Windows.Forms.PictureBox();
            this.picCenterCard5 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.picPlayerCard2 = new System.Windows.Forms.PictureBox();
            this.picPlayer3Card1 = new System.Windows.Forms.PictureBox();
            this.picPlayer3Card2 = new System.Windows.Forms.PictureBox();
            this.picPlayer2Card1 = new System.Windows.Forms.PictureBox();
            this.picPlayer2Card2 = new System.Windows.Forms.PictureBox();
            this.picPlayer4Card2 = new System.Windows.Forms.PictureBox();
            this.picPlayer4Card1 = new System.Windows.Forms.PictureBox();
            this.labelRound = new System.Windows.Forms.Label();
            this.textRoundNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picChips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer3Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer3Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer4Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer4Card1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1134, 636);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // picChips
            // 
            this.picChips.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\chips.png";
            this.picChips.Location = new System.Drawing.Point(221, 598);
            this.picChips.Name = "picChips";
            this.picChips.Size = new System.Drawing.Size(107, 74);
            this.picChips.TabIndex = 1;
            this.picChips.TabStop = false;
            // 
            // picDealer
            // 
            this.picDealer.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\dealer.png";
            this.picDealer.Location = new System.Drawing.Point(1170, 492);
            this.picDealer.Name = "picDealer";
            this.picDealer.Size = new System.Drawing.Size(214, 210);
            this.picDealer.TabIndex = 2;
            this.picDealer.TabStop = false;
            // 
            // buttonFold
            // 
            this.buttonFold.Location = new System.Drawing.Point(774, 613);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(67, 27);
            this.buttonFold.TabIndex = 3;
            this.buttonFold.Text = "Fold";
            this.buttonFold.UseVisualStyleBackColor = true;
            // 
            // textBoxTotalChips
            // 
            this.textBoxTotalChips.Location = new System.Drawing.Point(334, 615);
            this.textBoxTotalChips.Name = "textBoxTotalChips";
            this.textBoxTotalChips.ReadOnly = true;
            this.textBoxTotalChips.Size = new System.Drawing.Size(100, 22);
            this.textBoxTotalChips.TabIndex = 4;
            // 
            // buttonRaise
            // 
            this.buttonRaise.Location = new System.Drawing.Point(774, 575);
            this.buttonRaise.Name = "buttonRaise";
            this.buttonRaise.Size = new System.Drawing.Size(67, 27);
            this.buttonRaise.TabIndex = 5;
            this.buttonRaise.Text = "Raise";
            this.buttonRaise.UseVisualStyleBackColor = true;
            this.buttonRaise.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonCall
            // 
            this.buttonCall.Location = new System.Drawing.Point(774, 537);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(67, 27);
            this.buttonCall.TabIndex = 6;
            this.buttonCall.Text = "Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\TexasHoldem.png";
            this.pictureBox2.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 116);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // picCenterCard1
            // 
            this.picCenterCard1.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back.png";
            this.picCenterCard1.Location = new System.Drawing.Point(375, 238);
            this.picCenterCard1.Name = "picCenterCard1";
            this.picCenterCard1.Size = new System.Drawing.Size(113, 160);
            this.picCenterCard1.TabIndex = 8;
            this.picCenterCard1.TabStop = false;
            // 
            // picCenterCard2
            // 
            this.picCenterCard2.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back.png";
            this.picCenterCard2.Location = new System.Drawing.Point(494, 238);
            this.picCenterCard2.Name = "picCenterCard2";
            this.picCenterCard2.Size = new System.Drawing.Size(113, 160);
            this.picCenterCard2.TabIndex = 9;
            this.picCenterCard2.TabStop = false;
            // 
            // picCenterCard3
            // 
            this.picCenterCard3.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back.png";
            this.picCenterCard3.Location = new System.Drawing.Point(613, 238);
            this.picCenterCard3.Name = "picCenterCard3";
            this.picCenterCard3.Size = new System.Drawing.Size(113, 160);
            this.picCenterCard3.TabIndex = 10;
            this.picCenterCard3.TabStop = false;
            // 
            // picCenterCard4
            // 
            this.picCenterCard4.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back.png";
            this.picCenterCard4.Location = new System.Drawing.Point(732, 238);
            this.picCenterCard4.Name = "picCenterCard4";
            this.picCenterCard4.Size = new System.Drawing.Size(113, 160);
            this.picCenterCard4.TabIndex = 11;
            this.picCenterCard4.TabStop = false;
            // 
            // picCenterCard5
            // 
            this.picCenterCard5.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back.png";
            this.picCenterCard5.Location = new System.Drawing.Point(851, 238);
            this.picCenterCard5.Name = "picCenterCard5";
            this.picCenterCard5.Size = new System.Drawing.Size(113, 160);
            this.picCenterCard5.TabIndex = 12;
            this.picCenterCard5.TabStop = false;
            // 
            // picPlayerCard1
            // 
            this.picPlayerCard1.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\Clubs_Ace.PNG";
            this.picPlayerCard1.Location = new System.Drawing.Point(540, 515);
            this.picPlayerCard1.Name = "picPlayerCard1";
            this.picPlayerCard1.Size = new System.Drawing.Size(107, 146);
            this.picPlayerCard1.TabIndex = 13;
            this.picPlayerCard1.TabStop = false;
            // 
            // picPlayerCard2
            // 
            this.picPlayerCard2.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\Diamonds_Nine.PNG";
            this.picPlayerCard2.Location = new System.Drawing.Point(653, 515);
            this.picPlayerCard2.Name = "picPlayerCard2";
            this.picPlayerCard2.Size = new System.Drawing.Size(115, 146);
            this.picPlayerCard2.TabIndex = 14;
            this.picPlayerCard2.TabStop = false;
            // 
            // picPlayer3Card1
            // 
            this.picPlayer3Card1.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back_180.png";
            this.picPlayer3Card1.Location = new System.Drawing.Point(537, -31);
            this.picPlayer3Card1.Name = "picPlayer3Card1";
            this.picPlayer3Card1.Size = new System.Drawing.Size(110, 156);
            this.picPlayer3Card1.TabIndex = 15;
            this.picPlayer3Card1.TabStop = false;
            // 
            // picPlayer3Card2
            // 
            this.picPlayer3Card2.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back_180.png";
            this.picPlayer3Card2.Location = new System.Drawing.Point(653, -31);
            this.picPlayer3Card2.Name = "picPlayer3Card2";
            this.picPlayer3Card2.Size = new System.Drawing.Size(110, 156);
            this.picPlayer3Card2.TabIndex = 16;
            this.picPlayer3Card2.TabStop = false;
            // 
            // picPlayer2Card1
            // 
            this.picPlayer2Card1.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back_rotated.png";
            this.picPlayer2Card1.Location = new System.Drawing.Point(-36, 213);
            this.picPlayer2Card1.Name = "picPlayer2Card1";
            this.picPlayer2Card1.Size = new System.Drawing.Size(158, 112);
            this.picPlayer2Card1.TabIndex = 17;
            this.picPlayer2Card1.TabStop = false;
            // 
            // picPlayer2Card2
            // 
            this.picPlayer2Card2.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back_rotated.png";
            this.picPlayer2Card2.Location = new System.Drawing.Point(-36, 331);
            this.picPlayer2Card2.Name = "picPlayer2Card2";
            this.picPlayer2Card2.Size = new System.Drawing.Size(158, 112);
            this.picPlayer2Card2.TabIndex = 18;
            this.picPlayer2Card2.TabStop = false;
            // 
            // picPlayer4Card2
            // 
            this.picPlayer4Card2.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back_rotated.png";
            this.picPlayer4Card2.Location = new System.Drawing.Point(1207, 213);
            this.picPlayer4Card2.Name = "picPlayer4Card2";
            this.picPlayer4Card2.Size = new System.Drawing.Size(158, 112);
            this.picPlayer4Card2.TabIndex = 19;
            this.picPlayer4Card2.TabStop = false;
            // 
            // picPlayer4Card1
            // 
            this.picPlayer4Card1.ImageLocation = "C:\\Users\\vense\\Documents\\Durham College\\Semester 4\\oop 3\\WindowsFormsApp1\\Resourc" +
    "es\\card_back_rotated.png";
            this.picPlayer4Card1.Location = new System.Drawing.Point(1207, 331);
            this.picPlayer4Card1.Name = "picPlayer4Card1";
            this.picPlayer4Card1.Size = new System.Drawing.Size(158, 112);
            this.picPlayer4Card1.TabIndex = 20;
            this.picPlayer4Card1.TabStop = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(218, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "PLAYER 4\'s TURN";
            // 
            // TexasHoldEm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1331, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textRoundNumber);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.picPlayer4Card1);
            this.Controls.Add(this.picPlayer4Card2);
            this.Controls.Add(this.picPlayer2Card2);
            this.Controls.Add(this.picPlayer2Card1);
            this.Controls.Add(this.picPlayer3Card2);
            this.Controls.Add(this.picPlayer3Card1);
            this.Controls.Add(this.picPlayerCard2);
            this.Controls.Add(this.picPlayerCard1);
            this.Controls.Add(this.picCenterCard5);
            this.Controls.Add(this.picCenterCard4);
            this.Controls.Add(this.picCenterCard3);
            this.Controls.Add(this.picCenterCard2);
            this.Controls.Add(this.picCenterCard1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonCall);
            this.Controls.Add(this.buttonRaise);
            this.Controls.Add(this.textBoxTotalChips);
            this.Controls.Add(this.buttonFold);
            this.Controls.Add(this.picChips);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picDealer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "TexasHoldEm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TexasHoldEm";
            ((System.ComponentModel.ISupportInitialize)(this.picChips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCenterCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer3Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer3Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer4Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer4Card1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picChips;
        private System.Windows.Forms.PictureBox picDealer;
        private System.Windows.Forms.Button buttonFold;
        private System.Windows.Forms.TextBox textBoxTotalChips;
        private System.Windows.Forms.Button buttonRaise;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picCenterCard1;
        private System.Windows.Forms.PictureBox picCenterCard2;
        private System.Windows.Forms.PictureBox picCenterCard3;
        private System.Windows.Forms.PictureBox picCenterCard4;
        private System.Windows.Forms.PictureBox picCenterCard5;
        private System.Windows.Forms.PictureBox picPlayerCard1;
        private System.Windows.Forms.PictureBox picPlayerCard2;
        private System.Windows.Forms.PictureBox picPlayer3Card1;
        private System.Windows.Forms.PictureBox picPlayer3Card2;
        private System.Windows.Forms.PictureBox picPlayer2Card1;
        private System.Windows.Forms.PictureBox picPlayer2Card2;
        private System.Windows.Forms.PictureBox picPlayer4Card2;
        private System.Windows.Forms.PictureBox picPlayer4Card1;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.TextBox textRoundNumber;
        private System.Windows.Forms.Label label1;
    }
}