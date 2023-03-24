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

namespace PokerGame
{
    public partial class TexasHoldEm : Form
    {
        #region CONSTRUCTORS
        public TexasHoldEm()
        {
            InitializeComponent();
            Loading();
        }

        public TexasHoldEm(string difficulty, string chips, string players)
        {
            InitializeComponent();
            SetPictures();
            Loading(chips);
        }
        #endregion

        #region CUSTOM DESIGN METHODS
        public void SetPictures()
        {
            pictureBoxTitle.Image = Properties.Resources.ResourceManager.GetObject("TexasHoldem") as Image;
            picDealer.Image = Properties.Resources.ResourceManager.GetObject("dealer") as Image;
            picChips.Image = Properties.Resources.ResourceManager.GetObject("chips") as Image;
        }
        public void RoundLabel(System.Windows.Forms.Label label)
        {
            GraphicsPath graphicsPath = _getRoundPath(label.ClientRectangle, 10);

            label.Region = new Region(graphicsPath);

            label.Invalidate();
        }

        private static GraphicsPath _getRoundPath(Rectangle rectangle, int radius)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;

            radius = radius << 1;

            GraphicsPath path = new GraphicsPath();

            if (radius > 0)
            {
                if (radius > height) radius = height;
                if (radius > width) radius = width;
                path.AddArc(x, y, radius, radius, 180, 90);
                path.AddArc(x + width - radius, y, radius, radius, 270, 90);
                path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
                path.AddArc(x, y + height - radius, radius, radius, 90, 90);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(rectangle);
            }

            return path;
        }

        private void _drawRoundedRectangle(Graphics graphics, Pen pen, int x, int y, int width, int height, int radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = _generateRoundedRectangle(graphics, rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }
        private static GraphicsPath _generateRoundedRectangle(Graphics graphics, RectangleF rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rectangle.Location, sizeF);

            path.AddArc(arc, 180, 90);
            arc.X = rectangle.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rectangle.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }
        #endregion

        #region ASYNC METHODS
        private async void Loading()
        {
            await Task.Delay(5000);
            cardBox1Player.FaceUp = true;
            cardBox2Player.FaceUp = true;
            textRoundNumber.Text = "1";
            labelPot.Text = "Pot: 0 Chips";
            labelPlayerTurn.Text = "Your Turn";
        }

        private async void Loading(string chips)
        {
            Loading();
            await Task.Delay(1500);
            textBoxTotalChips.Text = chips;
        }
        #endregion

        #region EVENT HANDLERS
        private void TexasHoldEm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(labelPot.BackColor, 6.0f))
            {
                _drawRoundedRectangle(e.Graphics, pen, labelPot.Location.X - 1, labelPot.Location.Y - 1, labelPot.ClientRectangle.Width + 1, labelPot.ClientRectangle.Height + 1, 10);
            }
        }

        #endregion
    }
}
