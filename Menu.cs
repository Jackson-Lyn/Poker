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
        }

        private void buttonFiveCard_Click(object sender, EventArgs e)
        {
            FiveCard fiveCardWindow = new FiveCard();
            fiveCardWindow.Show();  
        }
    }
}
