namespace PokerGame
{
    partial class FiveCardHelp
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGotIt = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1150, 179);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Five Card Draw";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.label10.Location = new System.Drawing.Point(7, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(726, 25);
            this.label10.TabIndex = 4;
            this.label10.Text = "- The player with the best five-card hand after the final round of betting wins t" +
    "he pot.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.label11.Location = new System.Drawing.Point(6, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(929, 25);
            this.label11.TabIndex = 3;
            this.label11.Text = "- There is another round of betting after the draw, followed by a showdown if mor" +
    "e than one player remains.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.label12.Location = new System.Drawing.Point(2, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1028, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = " - After the betting round, players can discard some or all of their cards and re" +
    "place them with new cards from the deck.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.label13.Location = new System.Drawing.Point(7, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(750, 25);
            this.label13.TabIndex = 1;
            this.label13.Text = "- Each player is dealt five private cards, with a round of betting following the " +
    "initial deal.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.label14.Location = new System.Drawing.Point(7, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(718, 25);
            this.label14.TabIndex = 0;
            this.label14.Text = "- Five Card Draw is a classic poker game played with a standard deck of 52 cards." +
    "";
            // 
            // btnGotIt
            // 
            this.btnGotIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnGotIt.ForeColor = System.Drawing.Color.Black;
            this.btnGotIt.Location = new System.Drawing.Point(12, 210);
            this.btnGotIt.Name = "btnGotIt";
            this.btnGotIt.Size = new System.Drawing.Size(103, 41);
            this.btnGotIt.TabIndex = 12;
            this.btnGotIt.Text = "Got it";
            this.btnGotIt.UseVisualStyleBackColor = true;
            this.btnGotIt.Click += new System.EventHandler(this.CloseMenu);
            // 
            // FiveCardHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1174, 267);
            this.Controls.Add(this.btnGotIt);
            this.Controls.Add(this.groupBox2);
            this.Name = "FiveCardHelp";
            this.Text = "FiveCardHelp";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGotIt;
    }
}