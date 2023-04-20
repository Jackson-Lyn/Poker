using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void buttonTexas_Click(object sender, EventArgs e)
        {
            var buttonDiff = groupBoxDifficulty.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(n => n.Checked);
            var buttonChips = groupBoxChips.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(n => n.Checked);
            var buttonPlayers = groupBoxPlayers.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(n => n.Checked);

            TexasHoldEm texasWindow = new TexasHoldEm(buttonDiff.Text, buttonChips.Text, buttonPlayers.Text);
            texasWindow.Show();
            texasWindow.Focus();
            DisableNewGame();

            texasWindow.FormClosed += new FormClosedEventHandler(TexasWindowClosed);
        }

        private void buttonFiveCard_Click(object sender, EventArgs e)
        {
            var buttonDiff = groupBoxDifficulty.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(n => n.Checked);
            var buttonChips = groupBoxChips.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(n => n.Checked);
            var buttonPlayers = groupBoxPlayers.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(n => n.Checked);

            FiveCard FiveCardWindow = new FiveCard(buttonDiff.Text, buttonChips.Text, buttonPlayers.Text);
            FiveCardWindow.Show();
            FiveCardWindow.Focus();
            DisableNewGame();

            FiveCardWindow.FormClosed += new FormClosedEventHandler(FiveCardWindowClosed);
        }

        private void TexasWindowClosed(object sender, EventArgs e)
        {
            buttonTexas.Enabled = true;
            buttonFiveCard.Enabled = true;

            // Focus on this form
            this.Activate();
            this.Focus();
        }

        private void DisableNewGame()
        {
            buttonTexas.Enabled = false;
            buttonFiveCard.Enabled = false;
        }

        /**
         * Show the help window.
         * 
         * <param name="e"></param>
         * <param name="sender"></param>
         */
        private void ShowHelp(object sender, EventArgs e)
        {
            new MenuHelp().Show();
        }

        private void FiveCardWindowClosed(object sender, EventArgs e)
        {
            buttonTexas.Enabled = true;
            buttonFiveCard.Enabled = true;
        }

    }
}
