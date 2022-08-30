
namespace BaiCao
{
    partial class BaiCaoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlayGame = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.lbRulesContent = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPlayGame
            // 
            this.btnPlayGame.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlayGame.Location = new System.Drawing.Point(536, 299);
            this.btnPlayGame.Name = "btnPlayGame";
            this.btnPlayGame.Size = new System.Drawing.Size(143, 82);
            this.btnPlayGame.TabIndex = 0;
            this.btnPlayGame.Text = "Chơi Game";
            this.btnPlayGame.UseVisualStyleBackColor = true;
            this.btnPlayGame.Click += new System.EventHandler(this.btnPlayGame_Click);
            // 
            // btnRules
            // 
            this.btnRules.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRules.Location = new System.Drawing.Point(991, 21);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(143, 82);
            this.btnRules.TabIndex = 1;
            this.btnRules.Text = "Luật chơi";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // lbRulesContent
            // 
            this.lbRulesContent.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRulesContent.FormattingEnabled = true;
            this.lbRulesContent.ItemHeight = 19;
            this.lbRulesContent.Items.AddRange(new object[] {
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
            this.lbRulesContent.Location = new System.Drawing.Point(692, 107);
            this.lbRulesContent.Margin = new System.Windows.Forms.Padding(10);
            this.lbRulesContent.Name = "lbRulesContent";
            this.lbRulesContent.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbRulesContent.Size = new System.Drawing.Size(442, 213);
            this.lbRulesContent.TabIndex = 3;
            this.lbRulesContent.Visible = false;
            // 
            // BaiCaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BaiCao.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1175, 695);
            this.Controls.Add(this.lbRulesContent);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnPlayGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaiCaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Bài Cào";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayGame;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.ListBox lbRulesContent;
    }
}

