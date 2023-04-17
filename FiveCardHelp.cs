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
    public partial class FiveCardHelp : Form
    {
        public FiveCardHelp()
        {
            InitializeComponent();
        }

        private void CloseMenu(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
