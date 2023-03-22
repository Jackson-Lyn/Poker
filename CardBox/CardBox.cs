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
                // if the value is different than the card's FaceUp property
                if (myCard.FaceUp != value) // then the card is flipping over
                {
                    myCard.FaceUp = value; // change the card's FaceUp property

                    UpdateCardImage(); // update card image

                    // if there is an event handler for CardFlipped in the client program
                    if (CardFlipped != null)
                    {
                        CardFlipped(this, new EventArgs()); // call it
                    }
                }
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

        public CardBox(Card card, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = orientation;
            myCard = card;
        }

        #endregion

        #region EVENT AND EVENT HANDLERS
        /// <summary>
        /// An event handler for initial image for the card
        /// </summary>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        public event EventHandler CardFlipped;

        /// <summary>
        /// An event the client program can handle when the user clicks the control
        /// </summary>
        new public event EventHandler Click;

        /// <summary>
        /// An event handler for the user clicking the picture box control
        /// </summary>
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            // if there is a handler for clicking the control in the client program
            if (Click != null)
            {
                Click(this, e);
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Updates the card Image
        /// </summary>
        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if (myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        /// <summary>
        /// Overrides ToString method
        /// </summary>
        public override string ToString()
        {
            return myCard.ToString();
        }

        #endregion

    }
}
