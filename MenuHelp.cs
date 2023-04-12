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
    public partial class MenuHelp : Form
    {
        public MenuHelp()
        {
            InitializeComponent();

            // Make this form non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /**
         * Close this form.
         */
        private void CloseHelp(object sender, EventArgs e)
        {
            // Close and release resources
            this.Dispose();
        }
    }
}
