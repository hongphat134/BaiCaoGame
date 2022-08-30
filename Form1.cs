using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiCao
{
    public partial class BaiCaoForm : Form
    {
        #region ATTRIBUTES
        GamePlay gamePlay;
        const int BONUS_DISTANCED_MAINPLAYER_CARD = 10;
        const int DISTANCED_CARD = 30;        
        const int DISTANCED_PLAYER = 140;
        const String IMAGE_FOLDER_PATH = "../image/";
        const String PATTERN_CARD_PATH_IMAGE = "../image/vo_bai.jpg";
        #endregion
        public BaiCaoForm()
        {            
            InitializeComponent();
            Random random = new Random();

            gamePlay = new GamePlay();
            gamePlay.CreateListCard();            
            gamePlay.DistributeCards();
        }

        public void LoadPlayer()
        {
            //Load Main Player
            Label mainPlayerName = new Label();
            mainPlayerName.Name = "lblMainPlayerName";
            mainPlayerName.Location = new Point(500, 620);
            mainPlayerName.Text = gamePlay.mainPlayer.name;
            mainPlayerName.TextAlign = ContentAlignment.MiddleCenter;
            mainPlayerName.Font = new System.Drawing.Font("Unispace", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mainPlayerName.BackColor = Color.Transparent;
            mainPlayerName.ForeColor = Color.Crimson;
            Controls.Add(mainPlayerName);
            Label mainPlayerCoin = new Label();
            mainPlayerCoin.Name = "lblMainPlayerCoin";
            mainPlayerCoin.Location = new Point(500, 650);
            mainPlayerCoin.Text = gamePlay.mainPlayer.coin.ToString() + "$";
            mainPlayerCoin.AutoSize = true;
            mainPlayerCoin.TextAlign = ContentAlignment.MiddleCenter;
            mainPlayerCoin.Font = new System.Drawing.Font("Unispace", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mainPlayerCoin.BackColor = Color.Transparent;
            mainPlayerCoin.ForeColor = Color.Green;
            Controls.Add(mainPlayerCoin);

            PictureBox[] mainPlayerCards = {
                    new PictureBox{
                        Location = new Point(570 - (DISTANCED_CARD + BONUS_DISTANCED_MAINPLAYER_CARD),450),
                        Size = new Size(120,150),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbMainPlayerCard1",
                        BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[0].imageLinkCard),
                    },
                    new PictureBox{
                        Location = new Point(570 - ((DISTANCED_CARD + BONUS_DISTANCED_MAINPLAYER_CARD) * 2),450),
                        Size = new Size(120,150),
                         BackgroundImageLayout = ImageLayout.Stretch,
                         Name = "ptrbMainPlayerCard2",
                        BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[1].imageLinkCard),
                    },
                    new PictureBox{
                        Location = new Point(570 - ((DISTANCED_CARD+ BONUS_DISTANCED_MAINPLAYER_CARD)*3),450),
                        Size = new Size(120,150),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbMainPlayerCard3",
                       BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[2].imageLinkCard),
                    }
            };
            Controls.AddRange(mainPlayerCards);
         
            //Load Players
            for(int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                Label playerName = new Label();
                playerName.Name = "lblPlayerName" + (idx +1);
                playerName.AutoSize = true;
                playerName.Location = new Point( 40 + ( DISTANCED_PLAYER * idx) , 10);
                playerName.Text = gamePlay.listPlayer[idx].name;
                playerName.TextAlign = ContentAlignment.MiddleCenter;
                playerName.Font = new System.Drawing.Font("Unispace", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                playerName.BackColor = Color.Transparent;
                playerName.ForeColor = Color.Crimson;
                Controls.Add(playerName);
                Label playerCoin = new Label();
                playerCoin.Name = "lblPlayerCoin" + (idx + 1);
                playerCoin.Location = new Point(40 + (DISTANCED_PLAYER *idx), 40);
                playerCoin.Text = gamePlay.listPlayer[idx].coin.ToString() + "$";
                playerCoin.TextAlign = ContentAlignment.MiddleCenter;
                playerCoin.Font = new System.Drawing.Font("Unispace", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                playerCoin.BackColor = Color.Transparent;
                playerCoin.ForeColor = Color.Green;
                Controls.Add(playerCoin);

                PictureBox[] playerCards = {
                    new PictureBox{
                        Location = new Point(40 + (DISTANCED_CARD * 2) +  (DISTANCED_PLAYER * idx),70),
                        Size = new Size(60,90),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbPlayer" + (idx + 1) + "Card1",
                        BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE),
                    },
                    new PictureBox{
                        Location = new Point(40 + (DISTANCED_CARD * 1) +  (DISTANCED_PLAYER * idx),70),
                        Size = new Size(60,90),
                         BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbPlayer" + (idx + 1) + "Card2",
                        BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE),
                    },
                    new PictureBox{
                        Location = new Point(40 + (DISTANCED_CARD * 0) +  (DISTANCED_PLAYER * idx),70),
                        Size = new Size(60,90),
                         BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbPlayer" + (idx + 1) + "Card3",
                        BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE),
                    }
            };
                Controls.AddRange(playerCards);
            }
        }

        public void LoadCheckCards()
        {
            Button btnCheckCards = new Button()
            {
                Location = new Point(700, 460),
                Name = "btnCheckCards",
                Size = new Size(60, 60),
                Text = "Lật bài",
            };
            btnCheckCards.Click += BtnCheckCards_Click;
            Controls.Add(btnCheckCards);
        }

        public void LoadResults()
        {
            //Main Player
            Label lblMainPlayerWinResult = new Label()
            {
                Name = "lblMainPlayerResult",
                Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                ForeColor = Color.Green,
                BackColor = Color.Transparent,
                Location = new Point(320,480),
                AutoSize = true,                
            };
            Controls.Add(lblMainPlayerWinResult);

            //Players
            for(int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                Label lblPlayerResult = new Label()
                {
                    Name = "lblPlayer" + (idx + 1) + "Result",
                    Font = new System.Drawing.Font("Ravie", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                    ForeColor = Color.Green,
                    BackColor = Color.Transparent,
                    Location = new Point(40 + (140 * idx), 180),
                    AutoSize = true,                   
                };
                Controls.Add(lblPlayerResult);
            }
        }

        public void ClearResults()
        {
            Controls["lblMainPlayerResult"].Visible = false;

            for (int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                Controls["lblPlayer" + (idx + 1) + "Result"].Visible =false;
            }
        }

        public void LoadGamePlay()
        {           
            LoadPlayer();
            LoadCheckCards();
            LoadResults();
        }

        public void LoadBtnReplay()
        {
            Button btnReplay = new Button()
            {
                Name = "btnReplay",
                Size = new Size(60, 60),
                Location = new Point(800, 460),
                Text = "Chơi tiếp", 
                Visible = false,
            };
            btnReplay.Click += BtnReplay_Click;
            Controls.Add(btnReplay);
        }

        private void BtnReplay_Click(object sender, EventArgs e)
        {
            
            gamePlay.LoadListCard();
            gamePlay.ClearPlayerCards();
            gamePlay.DistributeCards();
            ClearResults();
            this.Controls["ptrbMainPlayerCard1"].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[0].imageLinkCard);
            this.Controls["ptrbMainPlayerCard2"].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[1].imageLinkCard);
            this.Controls["ptrbMainPlayerCard3"].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[2].imageLinkCard);
            for (int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                this.Controls["ptrbPlayer" + (idx + 1) + "Card1"].BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE);
                this.Controls["ptrbPlayer" + (idx + 1) + "Card2"].BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE);
                this.Controls["ptrbPlayer" + (idx + 1) + "Card3"].BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE);
            }

            this.Controls["btnCheckCards"].Visible = true;
            this.Controls["btnReplay"].Visible = false;
        }

        public void ShowCoins()
        {
            this.Controls["lblMainPlayerCoin"].Text = gamePlay.mainPlayer.coin.ToString() + "$";

            for (int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                Controls["lblPlayerCoin" + (idx + 1)].Text = gamePlay.listPlayer[idx].coin.ToString() + "$";
            }
        }

        public void ShowResults()
        {
            this.Controls["lblMainPlayerResult"].Visible = true;
            int totalMainPlayerMoney = gamePlay.CalculatedMoney(gamePlay.mainPlayer);
            if (totalMainPlayerMoney > 0)
            {
                this.Controls["lblMainPlayerResult"].ForeColor = Color.Green;
                this.Controls["lblMainPlayerResult"].Text = "+" + totalMainPlayerMoney.ToString() + "$";
            }
            else if(totalMainPlayerMoney == 0)
            {
                this.Controls["lblMainPlayerResult"].ForeColor = Color.Green;
                this.Controls["lblMainPlayerResult"].Text = totalMainPlayerMoney.ToString() + "$";
            }
            else
            {
                this.Controls["lblMainPlayerResult"].ForeColor = Color.DarkRed;
                this.Controls["lblMainPlayerResult"].Text = totalMainPlayerMoney.ToString() + "$";
            }
            

            for (int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                this.Controls["lblPlayer" + (idx + 1) + "Result"].Visible = true;
                int totalPlayerMoney = gamePlay.CalculatedMoney(gamePlay.listPlayer[idx]);
                if (totalPlayerMoney > 0)
                {
                    this.Controls["lblPlayer" + (idx + 1) + "Result"].ForeColor = Color.Green;
                    this.Controls["lblPlayer" + (idx + 1) + "Result"].Text = "+ " + totalPlayerMoney.ToString() + "$";
                }
                else if(totalPlayerMoney == 0)
                {
                    this.Controls["lblPlayer" + (idx + 1) + "Result"].ForeColor = Color.Green;
                    this.Controls["lblPlayer" + (idx + 1) + "Result"].Text = totalPlayerMoney.ToString() + "$";
                }
                else
                {
                    this.Controls["lblPlayer" + (idx + 1) + "Result"].ForeColor = Color.DarkRed;
                    this.Controls["lblPlayer" + (idx + 1) + "Result"].Text = totalPlayerMoney.ToString() + "$";
                }
            }
            gamePlay.CalculatedCoin();
            ShowCoins();
        }

        private void BtnCheckCards_Click(object sender, EventArgs e)
        {            
            this.Controls["btnCheckCards"].Visible = false;
            this.Controls["btnReplay"].Visible = true;

            for (int idx = 0; idx < gamePlay.listPlayer.Count; idx++)
            {
                String cardName1 = "ptrbPlayer" + (idx + 1) + "Card1";               
                this.Controls[cardName1].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.listPlayer[idx].cards[0].imageLinkCard);

                String cardName2 = "ptrbPlayer" + (idx + 1) + "Card2";               
                Controls[cardName2].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.listPlayer[idx].cards[1].imageLinkCard);

                String cardName3 = "ptrbPlayer" + (idx + 1) + "Card3";
                Controls[cardName3].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.listPlayer[idx].cards[2].imageLinkCard);
            }

            gamePlay.CalculatedGame();
            ShowResults();
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            btnPlayGame.Visible = false;
            btnRules.Visible = false;
            LoadGamePlay(); LoadBtnReplay();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            lbRulesContent.Visible = (lbRulesContent.Visible == true ? false : true);
        }
    }
}