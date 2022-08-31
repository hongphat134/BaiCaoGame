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
            LoadSettings();
            Random random = new Random();           
        }
        public void LoadSettings()
        {
            Button btnPlayGame = new System.Windows.Forms.Button();
            Button btnRules = new System.Windows.Forms.Button();
            ListBox lbRulesContent = new System.Windows.Forms.ListBox();
            TextBox txtPlayerCount = new System.Windows.Forms.TextBox();
            Label lblPlayerCount = new System.Windows.Forms.Label();
            Label lblBetsMoney = new System.Windows.Forms.Label();
            TextBox txtBetsMoney = new System.Windows.Forms.TextBox();
            Label lblMoneyMount = new System.Windows.Forms.Label();
            TextBox txtMoneyMount = new System.Windows.Forms.TextBox();
            SuspendLayout();

            btnPlayGame.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPlayGame.Location = new System.Drawing.Point(653, 298);
            btnPlayGame.Name = "btnPlayGame";
            btnPlayGame.Size = new System.Drawing.Size(143, 82);
            btnPlayGame.TabIndex = 0;
            btnPlayGame.Text = "Chơi Game";
            btnPlayGame.UseVisualStyleBackColor = true;
            btnPlayGame.Click += new System.EventHandler(btnPlayGame_Click);

            // btnRules        
            btnRules.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRules.Location = new System.Drawing.Point(1124, 12);
            btnRules.Name = "btnRules";
            btnRules.Size = new System.Drawing.Size(143, 82);
            btnRules.TabIndex = 1;
            btnRules.Text = "Luật chơi";
            btnRules.UseVisualStyleBackColor = true;
            btnRules.Click += new System.EventHandler(btnRules_Click);
            // 
            // lbRulesContent
            // 
            lbRulesContent.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbRulesContent.FormattingEnabled = true;
            lbRulesContent.ItemHeight = 19;
            lbRulesContent.Items.AddRange(new object[] {
            "- Mỗi người chơi sẽ nhận được 3 lá bài",
            "- Cách tính điểm như sau:",
            "   + A -> 1 điểm  ,2 -> 9 tương ứng 2 -> 9 điểm,",
            "    10 + J + Q + K -> 10 điểm",
            "   + Tổng số nút = tổng điểm 3 lá bài cộng lại chia 10 ",
            " lấy phần dư ( 27 / 10 = 3 dư 7 -> 7 nút)",
            "- Nút người chơi A cao hơn người chơi B -> A thắng B",
            "- Trường hợp đặc biệt nếu sở hữu cả 3 lá bài thuộc ",
            " J -> K -> bộ bài có giá trị cao nhất mà không ",
            " tính điểm"});
            lbRulesContent.Location = new System.Drawing.Point(825, 96);
            lbRulesContent.Margin = new System.Windows.Forms.Padding(10);
            lbRulesContent.Name = "lbRulesContent";
            lbRulesContent.SelectionMode = System.Windows.Forms.SelectionMode.None;
            lbRulesContent.Size = new System.Drawing.Size(442, 213);
            lbRulesContent.TabIndex = 3;
            lbRulesContent.Visible = false;
            // 
            // txtPlayerCount
            // 
            txtPlayerCount.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtPlayerCount.Location = new System.Drawing.Point(497, 281);
            txtPlayerCount.MaxLength = 1;
            txtPlayerCount.Name = "txtPlayerCount";
            txtPlayerCount.Size = new System.Drawing.Size(44, 28);
            txtPlayerCount.TabIndex = 4;
            txtPlayerCount.Text = "4";
            txtPlayerCount.KeyDown += new System.Windows.Forms.KeyEventHandler(txtPlayerCount_KeyDown);
            // 
            // lblPlayerCount
            // 
            lblPlayerCount.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblPlayerCount.Location = new System.Drawing.Point(354, 281);
            lblPlayerCount.Name = "lblPlayerCount";
            lblPlayerCount.Size = new System.Drawing.Size(128, 26);
            lblPlayerCount.TabIndex = 5;
            lblPlayerCount.Text = "Số người chơi";
            lblPlayerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBetsMoney
            // 
            lblBetsMoney.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblBetsMoney.Location = new System.Drawing.Point(354, 325);
            lblBetsMoney.Name = "lblBetsMoney";
            lblBetsMoney.Size = new System.Drawing.Size(128, 26);
            lblBetsMoney.TabIndex = 7;
            lblBetsMoney.Text = "Tiền cược";
            lblBetsMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBetsMoney
            // 
            txtBetsMoney.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtBetsMoney.Location = new System.Drawing.Point(497, 325);
            txtBetsMoney.MaxLength = 6;
            txtBetsMoney.Name = "txtBetsMoney";
            txtBetsMoney.Size = new System.Drawing.Size(118, 28);
            txtBetsMoney.TabIndex = 6;
            txtBetsMoney.Text = "10000";
            txtBetsMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(txtBetsMoney_KeyDown);
            // 
            // lblMoneyMount
            // 
            lblMoneyMount.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblMoneyMount.Location = new System.Drawing.Point(354, 367);
            lblMoneyMount.Name = "lblMoneyMount";
            lblMoneyMount.Size = new System.Drawing.Size(128, 26);
            lblMoneyMount.TabIndex = 9;
            lblMoneyMount.Text = "Số lượng tiền";
            lblMoneyMount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMoneyMount
            // 
            txtMoneyMount.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtMoneyMount.Location = new System.Drawing.Point(497, 367);
            txtMoneyMount.MaxLength = 8;
            txtMoneyMount.Name = "txtMoneyMount";
            txtMoneyMount.Size = new System.Drawing.Size(118, 28);
            txtMoneyMount.TabIndex = 8;
            txtMoneyMount.Text = "200000";
            txtMoneyMount.KeyDown += new System.Windows.Forms.KeyEventHandler(txtMoneyMount_KeyDown);

            Controls.Add(lblMoneyMount);
            Controls.Add(txtMoneyMount);
            Controls.Add(lblBetsMoney);
            Controls.Add(txtBetsMoney);
            Controls.Add(lblPlayerCount);
            Controls.Add(txtPlayerCount);
            Controls.Add(lbRulesContent);
            Controls.Add(btnRules);
            Controls.Add(btnPlayGame);
        }

        public void LoadMainPlayer()
        {
            Label mainPlayerName = new Label();
            mainPlayerName.Name = "lblMainPlayerName";
            mainPlayerName.Location = new Point(600, 620);
            mainPlayerName.Text = gamePlay.mainPlayer.name;
            mainPlayerName.TextAlign = ContentAlignment.MiddleCenter;
            mainPlayerName.Font = new System.Drawing.Font("Unispace", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mainPlayerName.BackColor = Color.Transparent;
            mainPlayerName.ForeColor = Color.Crimson;
            Controls.Add(mainPlayerName);
            Label mainPlayerCoin = new Label();
            mainPlayerCoin.Name = "lblMainPlayerCoin";
            mainPlayerCoin.Location = new Point(600, 650);
            mainPlayerCoin.Text = gamePlay.mainPlayer.coin.ToString() + "$";
            mainPlayerCoin.AutoSize = true;
            mainPlayerCoin.TextAlign = ContentAlignment.MiddleCenter;
            mainPlayerCoin.Font = new System.Drawing.Font("Unispace", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mainPlayerCoin.BackColor = Color.Transparent;
            mainPlayerCoin.ForeColor = Color.Green;
            Controls.Add(mainPlayerCoin);

            PictureBox ptrbAvatarMainPlayer = new PictureBox();
            ptrbAvatarMainPlayer.BackColor = System.Drawing.Color.Transparent;
            ptrbAvatarMainPlayer.BackgroundImage = Image.FromFile("../my_logo.png");
            ptrbAvatarMainPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ptrbAvatarMainPlayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ptrbAvatarMainPlayer.Cursor = System.Windows.Forms.Cursors.Default;
            ptrbAvatarMainPlayer.Image = Image.FromFile("../avatar_background.png");
            ptrbAvatarMainPlayer.Location = new System.Drawing.Point(555, 675);
            ptrbAvatarMainPlayer.Name = "ptrbAvatarMainPlayer";
            ptrbAvatarMainPlayer.Size = new System.Drawing.Size(170, 177);
            ptrbAvatarMainPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ptrbAvatarMainPlayer.TabIndex = 0;
            ptrbAvatarMainPlayer.TabStop = false;
            Controls.Add(ptrbAvatarMainPlayer);

            PictureBox[] mainPlayerCards = {
                    new PictureBox{
                        Location = new Point(670 - (DISTANCED_CARD + BONUS_DISTANCED_MAINPLAYER_CARD),450),
                        Size = new Size(120,150),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbMainPlayerCard1",
                        BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[0].imageLinkCard),
                    },
                    new PictureBox{
                        Location = new Point(670 - ((DISTANCED_CARD + BONUS_DISTANCED_MAINPLAYER_CARD) * 2),450),
                        Size = new Size(120,150),
                         BackgroundImageLayout = ImageLayout.Stretch,
                         Name = "ptrbMainPlayerCard2",
                        BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[1].imageLinkCard),
                    },
                    new PictureBox{
                        Location = new Point(670 - ((DISTANCED_CARD+ BONUS_DISTANCED_MAINPLAYER_CARD)*3),450),
                        Size = new Size(120,150),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbMainPlayerCard3",
                       BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[2].imageLinkCard),
                    }
            };
            Controls.AddRange(mainPlayerCards);
        }

        public void LoadPlayer()
        {
            int idx = 0;
            foreach(Player player in gamePlay.listPlayer)
            {
                Label playerName = new Label();
                playerName.Name = "lblPlayerName" + player.ID;
                playerName.AutoSize = true;
                playerName.Location = new Point( 50 + ( DISTANCED_PLAYER * idx) , 120);
                playerName.Text = player.name;
                playerName.TextAlign = ContentAlignment.MiddleCenter;
                playerName.Font = new System.Drawing.Font("Unispace", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                playerName.BackColor = Color.Transparent;
                playerName.ForeColor = Color.Crimson;
                Controls.Add(playerName);
                Label playerCoin = new Label();
                playerCoin.Name = "lblPlayerCoin" + player.ID;
                playerCoin.Location = new Point(50 + (DISTANCED_PLAYER *idx), 140);
                playerCoin.Text = player.coin.ToString() + "$";
                playerCoin.TextAlign = ContentAlignment.MiddleCenter;
                playerCoin.Font = new System.Drawing.Font("Unispace", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                playerCoin.BackColor = Color.Transparent;
                playerCoin.ForeColor = Color.Green;
                Controls.Add(playerCoin);

                PictureBox ptrbAvatarPlayer = new PictureBox();
                ptrbAvatarPlayer.BackColor = System.Drawing.Color.Transparent;
                ptrbAvatarPlayer.BackgroundImage = Image.FromFile("../avatar.png");
                ptrbAvatarPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                ptrbAvatarPlayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ptrbAvatarPlayer.Cursor = System.Windows.Forms.Cursors.Default;
                ptrbAvatarPlayer.Image = Image.FromFile("../avatar_background.png");
                ptrbAvatarPlayer.Location = new System.Drawing.Point(40 + (DISTANCED_PLAYER * idx), 10);
                ptrbAvatarPlayer.Name = "ptrbAvatarPlayer" + player.ID;
                ptrbAvatarPlayer.Size = new System.Drawing.Size(120, 120);
                ptrbAvatarPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                ptrbAvatarPlayer.TabIndex = 0;
                ptrbAvatarPlayer.TabStop = false;
                Controls.Add(ptrbAvatarPlayer);

                PictureBox[] playerCards = {
                    new PictureBox{
                        Location = new Point(40 + (DISTANCED_CARD * 2) +  (DISTANCED_PLAYER * idx),170),
                        Size = new Size(60,90),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbPlayer" + player.ID + "Card1",
                        BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE),
                    },
                    new PictureBox{
                        Location = new Point(40 + (DISTANCED_CARD * 1) +  (DISTANCED_PLAYER * idx),170),
                        Size = new Size(60,90),
                         BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbPlayer" + player.ID + "Card2",
                        BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE),
                    },
                    new PictureBox{
                        Location = new Point(40 + (DISTANCED_CARD * 0) +  (DISTANCED_PLAYER * idx),170),
                        Size = new Size(60,90),
                         BackgroundImageLayout = ImageLayout.Stretch,
                        Name = "ptrbPlayer" + player.ID + "Card3",
                        BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE),
                    }
            };
                Controls.AddRange(playerCards);
                idx++;
            }
        }

        public void LoadDeposit()
        {
            Label lblDepositTitle = new Label();
            lblDepositTitle.Name = "lblDepositTitle";
            lblDepositTitle.Location = new Point(30, 620);
            lblDepositTitle.Text = "Tiền cược ($): ";
            lblDepositTitle.AutoSize = true;
            lblDepositTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDepositTitle.Font = new System.Drawing.Font("Unispace", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblDepositTitle.BackColor = Color.Transparent;
            lblDepositTitle.ForeColor = Color.Green;
            Controls.Add(lblDepositTitle);
            Label lblDeposit = new Label();
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Location = new Point(200, 620);
            lblDeposit.Text = gamePlay.deposit.ToString() + " $";
            lblDeposit.TextAlign = ContentAlignment.MiddleCenter;
            lblDeposit.Font = new System.Drawing.Font("Unispace", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblDeposit.BackColor = Color.Transparent;
            lblDeposit.ForeColor = Color.Green;
            Controls.Add(lblDeposit);

        }

        public void LoadCheckCards()
        {
            Button btnCheckCards = new Button()
            {
                Location = new Point(800, 460),
                Name = "btnCheckCards",
                Size = new Size(80, 50),
                Text = "Lật bài",
                BackColor = System.Drawing.SystemColors.ButtonHighlight,
                Font = new System.Drawing.Font("Time New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
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
                Location = new Point(400,500),
                AutoSize = true,                
            };
            Controls.Add(lblMainPlayerWinResult);

            //Players
            int idx = 0;
            foreach(Player player in gamePlay.listPlayer)
            {
                Label lblPlayerResult = new Label()
                {
                    Name = "lblPlayer" + player.ID + "Result",
                    Font = new System.Drawing.Font("Ravie", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                    ForeColor = Color.Green,
                    BackColor = Color.Transparent,
                    Location = new Point(40 + (140 * idx), 300),
                    AutoSize = true,                   
                };
                Controls.Add(lblPlayerResult);
                idx++;
            }
        }

        public void ClearResults()
        {
            Controls["lblMainPlayerResult"].Visible = false;

            foreach(Player player in gamePlay.listPlayer)
            {
                Controls["lblPlayer" + player.ID + "Result"].Visible =false;
            }
        }

        public void LoadGamePlay()
        {
            gamePlay = new GamePlay(Int32.Parse(Controls["txtPlayerCount"].Text),
                                        Int32.Parse(Controls["txtBetsMoney"].Text),
                                        Int32.Parse(Controls["txtMoneyMount"].Text));           
            gamePlay.CreateListCard();
            gamePlay.DistributeCards();

            LoadMainPlayer();
            LoadPlayer();
            LoadDeposit();
            LoadCheckCards();
            LoadResults();
        }

        public void LoadBtnReplay()
        {
            Button btnReplay = new Button()
            {
                Name = "btnReplay",
                Size = new Size(100, 50),
                Location = new Point(900, 460),
                Text = "Chơi tiếp", 
                Visible = false,
                BackColor = System.Drawing.SystemColors.ButtonHighlight,
                Font = new System.Drawing.Font("Time New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
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
            Controls["ptrbMainPlayerCard1"].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[0].imageLinkCard);
            Controls["ptrbMainPlayerCard2"].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[1].imageLinkCard);
            Controls["ptrbMainPlayerCard3"].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + gamePlay.mainPlayer.cards[2].imageLinkCard);
            foreach(Player player in gamePlay.listPlayer)
            {
                Controls["ptrbPlayer" + player.ID + "Card1"].BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE);
                Controls["ptrbPlayer" + player.ID + "Card2"].BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE);
                Controls["ptrbPlayer" + player.ID + "Card3"].BackgroundImage = Image.FromFile(PATTERN_CARD_PATH_IMAGE);
            }

            Controls["btnCheckCards"].Visible = true;
            Controls["btnReplay"].Visible = false;
        }

        public void ShowCoins()
        {
            Controls["lblMainPlayerCoin"].Text = gamePlay.mainPlayer.coin.ToString() + "$";

            foreach(Player player in gamePlay.listPlayer)
            {
                Controls["lblPlayerCoin" + player.ID].Text = player.coin.ToString() + "$";
            }
        }

        public void ShowResults()
        {
            Controls["lblMainPlayerResult"].Visible = true;
            int totalMainPlayerMoney = gamePlay.CalculatedMoney(gamePlay.mainPlayer);
            if (totalMainPlayerMoney > 0)
            {
                Controls["lblMainPlayerResult"].ForeColor = Color.Green;
                Controls["lblMainPlayerResult"].Text = "+" + totalMainPlayerMoney.ToString() + "$";
            }
            else if(totalMainPlayerMoney == 0)
            {
                Controls["lblMainPlayerResult"].ForeColor = Color.Green;
                Controls["lblMainPlayerResult"].Text = totalMainPlayerMoney.ToString() + "$";
            }
            else
            {
                Controls["lblMainPlayerResult"].ForeColor = Color.DarkRed;
                Controls["lblMainPlayerResult"].Text = totalMainPlayerMoney.ToString() + "$";
            }
            

            foreach(Player player in gamePlay.listPlayer)
            {
                Controls["lblPlayer" + player.ID + "Result"].Visible = true;
                int totalPlayerMoney = gamePlay.CalculatedMoney(player);
                if (totalPlayerMoney > 0)
                {
                    Controls["lblPlayer" + player.ID + "Result"].ForeColor = Color.Green;
                    Controls["lblPlayer" + player.ID + "Result"].Text = "+ " + totalPlayerMoney.ToString() + "$";
                }
                else if(totalPlayerMoney == 0)
                {
                    Controls["lblPlayer" + player.ID + "Result"].ForeColor = Color.Green;
                    Controls["lblPlayer" + player.ID + "Result"].Text = totalPlayerMoney.ToString() + "$";
                }
                else
                {
                    Controls["lblPlayer" + player.ID + "Result"].ForeColor = Color.DarkRed;
                    Controls["lblPlayer" + player.ID + "Result"].Text = totalPlayerMoney.ToString() + "$";
                }
            }
            gamePlay.CalculatedCoin();
        }

        public void ShowResetButton()
        {
            Button btnReset = new Button()
            {
                Name = "btnResetGame",
                Text = "Trở về MENU chính",
                Location = new Point(600,300),
                Size = new Size(180,60),
                BackColor = System.Drawing.SystemColors.ButtonHighlight,
                Font = new System.Drawing.Font("Time New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
        };
            btnReset.Click += BtnReset_Click;
            Controls.Add(btnReset);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            LoadSettings();
            ShowSettings(true);
        }

        public void ShowSettings(bool flag)
        {           
            Controls["lblBetsMoney"].Visible = flag;
            Controls["lblMoneyMount"].Visible = flag;
            Controls["lblPlayerCount"].Visible = flag;

            Controls["txtBetsMoney"].Visible = flag;
            Controls["txtMoneyMount"].Visible = flag;
            Controls["txtPlayerCount"].Visible = flag;

            Controls["btnPlayGame"].Visible = flag;
            Controls["btnRules"].Visible = flag;            
        }

        public void RemovePlayers(List<int> playerIDList)
        {           
            foreach(int ID in playerIDList)
            {
                Controls.Remove(Controls["lblPlayerName" + ID]);
                Controls.Remove(Controls["lblPlayerCoin" + ID]);
                Controls.Remove(Controls["ptrbPlayer" + ID + "Card1"]);
                Controls.Remove(Controls["ptrbPlayer" + ID + "Card2"]);
                Controls.Remove(Controls["ptrbPlayer" + ID + "Card3"]);
                Controls.Remove(Controls["lblPlayer" + ID + "Result"]);
                Controls.Remove(Controls["ptrbAvatarPlayer" + ID]);
            }
       }

        public bool CheckSettings()
        {
            return Controls["txtBetsMoney"].Text == "" || Controls["txtMoneyMount"].Text == "" || Controls["txtPlayerCount"].Text == "" 
                || ( (Int32.Parse(Controls["txtBetsMoney"].Text) *(Int32.Parse(Controls["txtPlayerCount"].Text) ) > Int32.Parse(Controls["txtMoneyMount"].Text)));
        }

        private void BtnCheckCards_Click(object sender, EventArgs e)
        {            
            Controls["btnCheckCards"].Visible = false;
            

            foreach(Player player in gamePlay.listPlayer)
            {
                String cardName1 = "ptrbPlayer" + player.ID + "Card1";               
                Controls[cardName1].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + player.cards[0].imageLinkCard);

                String cardName2 = "ptrbPlayer" + player.ID + "Card2";               
                Controls[cardName2].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + player.cards[1].imageLinkCard);

                String cardName3 = "ptrbPlayer" + player.ID + "Card3";
                Controls[cardName3].BackgroundImage = Image.FromFile(IMAGE_FOLDER_PATH + player.cards[2].imageLinkCard);
            }

            gamePlay.CalculatedGame();
            ShowResults();
            ShowCoins();
            List<int> removePlayerIDList = gamePlay.CheckCoinToFindOutOfMoneyIDPlayer();            
            
            gamePlay.removeOutOfMoneyPlayers(removePlayerIDList);
            RemovePlayers(removePlayerIDList);

            if (gamePlay.IsWon())
            {
                MessageBox.Show("Tất cả đối thủ đã CHÁY TÚI! bạn đã THẮNG!");
                ShowResetButton();
            }
            else if (gamePlay.IsLose())
            {
                MessageBox.Show("Bạn đã THUA vì hết tiền cược!");
                ShowResetButton();
            }
            else Controls["btnReplay"].Visible = true;
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            
            if (!CheckSettings())
            {
                ShowSettings(false);
                LoadGamePlay(); LoadBtnReplay();
            }
            else MessageBox.Show("Bạn phải nhập thông tin hợp lệ!\n" +
                            "Chỉ nhập số và ko để trống!\n" +
                            "Số tiền cược phải nhỏ hơn số lượng tiền!\n" +
                            "Vì bạn là NHÀ CÁI nên số lượng tiền >= (số tiền cược x số người chơi)!");
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            Controls["lbRulesContent"].Visible = (Controls["lbRulesContent"].Visible == true ? false : true);
        }

        private void txtPlayerCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }

        private void txtBetsMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }

        private void txtMoneyMount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }
    }
}