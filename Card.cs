using System;
using System.Collections.Generic;
using System.Text;

namespace BaiCao
{
    enum PropertyCard { Bich,Chuong,Ro,Co};

    enum PointCard { A,Mot,Hai,Ba,Bon,Nam,Sau,Bay,Tam,Chin,Muoi,J,Q,K};
    class Card
    {
        #region ATTRIBUTES
        PropertyCard propertyCard;
        PointCard pointCard;
        public String imageLinkCard;
        #endregion

        #region METHODS
        public Card(PropertyCard propertyCard, PointCard pointCard, String imageLinkCard)
        {
            this.propertyCard = propertyCard;
            this.pointCard = pointCard;
            this.imageLinkCard = imageLinkCard;
        }

        public int CalculatedPointCard()
        {
            switch (this.pointCard)
            {
                case BaiCao.PointCard.A: return 1;
                case BaiCao.PointCard.Hai: return 2;
                case BaiCao.PointCard.Ba: return 3;
                case BaiCao.PointCard.Bon: return 4;
                case BaiCao.PointCard.Nam: return 5;
                case BaiCao.PointCard.Sau: return 6;
                case BaiCao.PointCard.Bay: return 7;
                case BaiCao.PointCard.Tam: return 8;
                case BaiCao.PointCard.Chin: return 9;
                case BaiCao.PointCard.Muoi: return 10;
                default: return 0;               
            }
        }
        #endregion
    }
}
