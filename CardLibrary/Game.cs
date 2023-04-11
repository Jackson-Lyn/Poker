using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Game
    {
        #region PROPERTIES
        private int round { get; set; }
        private List<Player> players { get; set; }
        private int pot { get; set; }
        private int playerTurn { get; set; }
        private int numberOfPlayers { get; set; }
        private bool isBetRaised { get; set; }
        #endregion

        #region CONSTRUCTORS
        public Game() 
        {
            this.round = 1;
            this.pot = 0;
            this.players = new List<Player>();
            this.playerTurn = 0;
            this.numberOfPlayers = players.Count;
        }

        public Game(List<Player> players)
        {
            this.round = 1;
            this.pot = 0;
            this.players = players;
            this.playerTurn = 0;
            this.numberOfPlayers = players.Count;
        }
        #endregion

        public void SetPlayers(List<Player> players)
        {
            this.players = players;
        }

        public void SetPlayerTurn(int turn)
        {
            this.playerTurn = turn;
        }

        public void SetNumberOfPlayers(int number)
        {
            this.numberOfPlayers = number;
        }

        public void SetIsBetRaised(bool isBetRaised)
        {
            this.isBetRaised = isBetRaised;
        }

        public int GetNumberOfPlayers()
        {
            return this.numberOfPlayers;
        }


        public int GetRoundNumber()
        {
            return this.round;
        }

        public int GetPot()
        {
            return this.pot;
        }

        public int GetPlayerTurn()
        {
            return this.playerTurn;
        }
        
        public List<Player> GetPlayers()
        {
            return this.players;    
        }

        public bool GetIsBetRaised()
        {
            return this.isBetRaised;
        }

        public void NextRound()
        {
            this.round++;
        }

        public void NextTurn()
        {
            if (playerTurn == players.Count-1)
            {
                playerTurn = players[0].GetId();
                if (players[playerTurn].GetFold())
                {
                    playerTurn++;
                }
            }
            else
            {
                playerTurn++;
                if (players[playerTurn].GetFold())
                {
                    playerTurn++;
                }
            }
        }

        public void AddPot(int chips)
        {
            pot += chips;
        }

        public bool RevealCard()
        {
            bool check = true;
            foreach (Player p in this.players)
            {
                if (!p.GetFold())
                {
                    if (p.GetCheck() == false)
                    {
                        check = false;
                    }
                }
            }

            return check;
        }
    }
}
