using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;

namespace CardLibrary
{
    public class Card : ICloneable, // supports cloning, which creates a new instance of a class with the same value as an existing instance.
                               IComparable // Defines a generalized type-specific comparison method that a class implements to sort its instances.
    {
        #region FIELDS AND PROPERTIES

        /// <summary>
        /// Suit Property
        /// Used to set or get the card Suit
        /// </summary>
        protected Suit mySuit;
        public Suit Suit
        {
            get { return mySuit; } // return suit
            set { mySuit = value; } // set suit
        }

        /// <summary>
        /// Rank Property
        /// Used to set or get the card rank
        /// </summary>
        protected Rank myRank;
        public Rank Rank
        {
            get { return myRank; }
            set { myRank = value; }
        }

        /// <summary>
        /// CardValue Property
        /// Used to set or get the card value
        /// </summary>
        protected int myValue;
        public int CardValue
        {
            get { return myValue; }
            set { myValue = value; }
        }

        /// <summary>
        /// AlternateValue Property
        /// Used to set or get the alternate value
        /// </summary>
        protected int? altValue = null;
        public int? AlternateValue
        {
            get { return altValue; }
            set { altValue = value; }
        }

        /// <summary>
        /// AlternateValue Property
        /// Used to set or get the alternate value
        /// </summary>
        protected bool faceUp = false;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }
        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// PlayingCard Constructor
        /// Initializes PlayingCard object. It is the Ace of Spades, Faced Down, and no alternate value by default.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="suit"></param>
        public Card(Rank rank = Rank.Ace, Suit suit = Suit.Spades)
        {
            // Set the rank and suit
            this.myRank = rank;
            this.mySuit = suit;
            // Set the default card value
            this.myValue = (int)rank;
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// CompareTo Method
        /// Card-specific comparison method used to sort Card instances. Compares this instance with another object from the argument.
        /// </summary>
        /// <param name="obj">The object that is being compared</param>
        /// <returns>an integer that indicates whether this Card precedes, follows, or occurs</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public virtual int CompareTo(object obj)
        {
            // Check if the argument is null
            if (obj == null)
            {
                // throw an exception when it's null
                throw new ArgumentNullException("Unable to compare a Card to a null object.");
            }
            // Convert the object to a PlayingCard object
            Card compareCard = obj as Card;

            // If it successfully treats the obj as a PlayingCard object
            if (compareCard != null)
            {
                // Compare based on the value, after that compare the suit
                int thisSort = this.myValue * 10 + (int)this.mySuit;
                int compareCardSort = compareCard.myValue * 10 + (int)compareCard.mySuit;
                return (thisSort.CompareTo(compareCardSort));
            }
            else
            {
                // throw an exception when obj cannot be converted to a PlayingCard
                throw new ArgumentException("Object that is being compared cannot be converted to a PlayingCard");
            }
        }

        /// <summary>
        /// Clone Method
        /// To support the ICloneable interface. Used for deep copying in card collection classes.
        /// </summary>
        /// <returns>A copy of the PlayingCard as a System.Object</returns>
        public object Clone()
        {
            return this.MemberwiseClone(); // return a Memberwise clone
        }

        /// <summary>
        /// Overridden ToString Method
        /// Overrides System.Object.ToString() Method
        /// </summary>
        /// <returns>the name of the card as a string</returns>
        public override string ToString()
        {
            string cardString;
            // if the card is faced up
            if (faceUp)
            {
                cardString = myRank.ToString() + " of " + mySuit.ToString();
            }
            else
            {
                cardString = "Face Down";
            }
            return cardString;
        }

        /// <summary>
        /// Overridden Equals Method
        /// Overrides System.Object.Equals() Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if the cards are equal</returns>
        public override bool Equals(object obj)
        {
            return (this.CardValue == ((Card)obj).CardValue);
        }

        /// <summary>
        /// Overridden GetHashCode Method
        /// Overrides System.Object.GetHashCode() Method
        /// </summary>
        /// <returns>CardValue * 10 + Suit number</returns>
        public override int GetHashCode()
        {
            return this.myValue * 10 + (int)this.mySuit;
        }

        /// <summary>
        /// GetCardImage Method
        /// Gets the image associated with the card from the resource file.
        /// </summary>
        /// <returns>a Card Image </returns>
        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;

            if (!faceUp)
            {
                imageName = "card_back";
            }
            else if (
                myRank.ToString().Equals("Ace") || myRank.ToString().Equals("King") ||
                myRank.ToString().Equals("Queen") || myRank.ToString().Equals("Jack")
                )
            {
                imageName = myRank.ToString() + "_of_" + mySuit.ToString();
            }
            else
            {
                imageName = "_" + (int)myRank + "_of_" + mySuit.ToString().ToLower();
            }
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            return cardImage;
        }

        /// <summary>
        /// DebugString Method
        /// Returns a string of the state of the card for debugging purposes
        /// </summary>
        /// <returns>string of the state of the card</returns>
        public string DebugString()
        {
            string cardState = (string)(myRank.ToString() + " of " + mySuit.ToString()).PadLeft(20);
            cardState += (string)((FaceUp) ? "(Face Up)" : "(Face Down)").PadLeft(12);
            cardState += " Value: " + myValue.ToString().PadLeft(2);
            cardState += ((altValue != null)) ? "/" + altValue.ToString() : "";
            return cardState;
        }

        #endregion

        #region RELATIONAL OPERATORS

        // Overloaded operators
        public static bool operator ==(Card left, Card right)
        {
            return (left.CardValue == right.CardValue);
        }

        public static bool operator !=(Card left, Card right)
        {
            return (left.CardValue != right.CardValue);
        }

        public static bool operator <(Card left, Card right)
        {
            return (left.CardValue < right.CardValue);
        }

        public static bool operator <=(Card left, Card right)
        {
            return (left.CardValue <= right.CardValue);
        }

        public static bool operator >(Card left, Card right)
        {
            return (left.CardValue > right.CardValue);
        }

        public static bool operator >=(Card left, Card right)
        {
            return (left.CardValue >= right.CardValue);
        }

        #endregion
    }
}