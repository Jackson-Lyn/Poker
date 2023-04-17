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
    public partial class TexasHoldEmHelp : Form
    {
        public TexasHoldEmHelp()
        {
            InitializeComponent();

            // Make this form non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void CloseHelp(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
