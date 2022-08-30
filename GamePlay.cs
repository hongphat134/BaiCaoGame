using System;
using System.Collections.Generic;
using System.Text;

namespace BaiCao
{
    class GamePlay
    {
        #region ATTRIBUTES
        public List<Card> listCard;
        public Player mainPlayer;
        public List<Player> listPlayer;
        public int deposit;
        Random r = new Random();
        #endregion

        #region METHODS
        public GamePlay()
        {
            this.deposit = 10000;
            this.listCard = new List<Card>();
            int index = r.Next(10, 99);
            this.mainPlayer = new Player("HTP", index * 10000);

            this.listPlayer = new List<Player>();
            for(int idx = 1; idx <= 8;idx++)
            {
                index = r.Next(10, 99);
                this.listPlayer.Add(new Player("Player " + idx, index * 10000));
            }
        }

        public void CreateListCard()
        {
            this.listCard.Clear();            
            PropertyCard[] listPropertyCard = { PropertyCard.Bich,PropertyCard.Chuong,PropertyCard.Ro,PropertyCard.Co};
            PointCard[] listPointCard = { PointCard.A, PointCard.Hai, PointCard.Ba, PointCard.Bon,
                                          PointCard.Nam,PointCard.Sau,PointCard.Bay,PointCard.Tam,
                                          PointCard.Chin,PointCard.Muoi,PointCard.J,PointCard.Q,PointCard.K};
            
            for(int pointCardIndx = 1; pointCardIndx <= 13 ; pointCardIndx++)
            {
                for(int propertyCardIndx = 1; propertyCardIndx <= 4; propertyCardIndx++)
                {
                    Card card = new Card(listPropertyCard[propertyCardIndx -1],listPointCard[pointCardIndx - 1],pointCardIndx + "_" + propertyCardIndx + ".PNG");

                    this.listCard.Add(card);
                }
               
            }
        }

        public void LoadListCard()
        {
            
            this.listCard.AddRange(mainPlayer.cards);
            foreach(Player player in listPlayer)
            {
                this.listCard.AddRange(player.cards);
            }
        }

        public void DistributeCards()
        {
            //MainPlayer
            int index = r.Next(this.listCard.Count);
            mainPlayer.cards.Add(listCard[index]);
            listCard.RemoveAt(index);            
            index = r.Next(this.listCard.Count);
            mainPlayer.cards.Add(listCard[index]);
            listCard.RemoveAt(index);
            index = r.Next(this.listCard.Count);
            mainPlayer.cards.Add(listCard[index]);
            listCard.RemoveAt(index);

            //Players
            foreach(Player player in this.listPlayer)
            {
                index = r.Next(this.listCard.Count);
                player.cards.Add(listCard[index]);
                listCard.RemoveAt(index);
                index = r.Next(this.listCard.Count);
                player.cards.Add(listCard[index]);
                listCard.RemoveAt(index);
                index = r.Next(this.listCard.Count);
                player.cards.Add(listCard[index]);
                listCard.RemoveAt(index);
            }
        }

        public void ClearPlayerCards()
        {
            mainPlayer.cards.Clear();
            mainPlayer.results = 0;
            foreach(Player player in this.listPlayer)
            {
                player.cards.Clear();
                player.results = 0;
            }
        }
        
        public void CalculatedGame()
        {
            int winRate = 0;
            int mainPlayerPoint = mainPlayer.TotalPoint();

            foreach(Player player in listPlayer)
            {
                int playerPoint = player.TotalPoint();

                if (playerPoint < mainPlayerPoint) { 
                    winRate++;
                    player.results--;
                }
                else if (playerPoint == mainPlayerPoint) continue;
                else { 
                    winRate--;
                    player.results++;
                }
            }
            mainPlayer.results = winRate;
        }    
        
        public int CalculatedMoney(Player player)
        {
            return this.deposit * player.results;
        }

        public void CalculatedCoin() {
            mainPlayer.coin += CalculatedMoney(mainPlayer);

            foreach(Player player in listPlayer)
            {
                player.coin += CalculatedMoney(player);
            }
        }
        #endregion
    }
}
