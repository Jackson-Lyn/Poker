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
    public partial class RaiseInput : Form
    {
        int chips = 0;
        public RaiseInput()
        {
            InitializeComponent();
        }

        public RaiseInput(int totalChips)
        {
            InitializeComponent();
            chips = totalChips;
        }

        private void btnRaise_Click(object sender, EventArgs e)
        {
            if (numUDRaise.Value > chips)
            {
                MessageBox.Show("You cannot bet more than " + chips + " chips.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numUDRaise.Value == 0)
            {
                MessageBox.Show("You cannot bet 0 chips.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonAllIn_Click(object sender, EventArgs e)
        {
            numUDRaise.Value = chips;
        }

        public int GetChips()
        {
            return (int)numUDRaise.Value;
        }
    }
}
