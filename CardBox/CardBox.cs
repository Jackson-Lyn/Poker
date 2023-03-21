using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLibrary;

namespace CardBox
{
    public partial class CardBox: UserControl
    {
        #region FIELDS AND PROPERTIES
        /// <summary>
        /// Creating a private attribute to store a Card
        /// </summary>
        private Card myCard;
        /// <summary>
        /// Accessor and mutator for the attribute
        /// </summary>
        public Card Card
        {
            set
            {
                myCard = value;
                // Update the card image
                UpdateCardImage();
            }
            get { return myCard; }
        }

        /// <summary>
        /// Suit property: sets/gets the Card object's Suit value
        /// </summary>
        public Suit Suit
        {
            set
            {
                Card.Suit = value;
                UpdateCardImage();
            }
            get { return Card.Suit; }
        }

        /// <summary>
        /// Rank property: sets/gets the Card object's Rank value
        /// </summary>
        public Rank rank
        {
            set
            {
                Card.Rank = value;
                UpdateCardImage();
            }
            get { return Card.Rank; }
        }

        /// <summary>
        /// FaceUp property: sets/gets the Card object's FaceUp value
        /// </summary>
        public bool FaceUp
        {
            set
            {
                myCard.FaceUp = value;
                UpdateCardImage();
            }
            get { return Card.FaceUp; }
        }

        /// <summary>
        /// CardOrientation Property: sets/gets the Orientation of the card
        /// </summary>
        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                // if value is different than myOrientation
                if (myOrientation != value)
                {
                    myOrientation = value; // change the orientation
                    // swap the height and width of the control
                    this.Size = new Size(Size.Height, Size.Width);
                    // update the card image
                    UpdateCardImage();
                }
            }
            get { return myOrientation; }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor
        /// Constructs the control with a new card, oriented vertically
        /// </summary>
        public CardBox()
        {
            InitializeComponent(); // initialize designer
            myOrientation = Orientation.Vertical;
            myCard = new Card();
        }

        #endregion

        #region METHODS

        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if (myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        #endregion
    }
}
