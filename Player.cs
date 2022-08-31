using System;
using System.Collections.Generic;
using System.Text;

namespace BaiCao
{
    class Player
    {
        #region ATTRIBUTES
        public int ID;
        public String name;
        public int coin;
        public List<Card> cards;
        public int results;
        #endregion

        #region METHODS
        public Player(int ID,String name, int coin)
        {
            this.ID = ID;
            this.name = name;
            this.coin = coin;
            this.cards = new List<Card>();
            this.results = 0;
        }

        public int TotalPoint()
        {
            //TH 3 cào = 999
            int totalPoint = cards[0].CalculatedPointCard() + cards[1].CalculatedPointCard() + cards[2].CalculatedPointCard();
            return totalPoint == 0 ? 999: (totalPoint % 10);
        }
        #endregion
    }
}
