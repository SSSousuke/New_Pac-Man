namespace New_Packman
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.opencloseTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyTimer = new System.Windows.Forms.Timer(this.components);
            this.powerupTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.eliminateLabel = new System.Windows.Forms.Label();
            this.gameoverTimer = new System.Windows.Forms.Timer(this.components);
            this.startEnemy4 = new System.Windows.Forms.PictureBox();
            this.startEnemy3 = new System.Windows.Forms.PictureBox();
            this.startEnemy2 = new System.Windows.Forms.PictureBox();
            this.startEnemy1 = new System.Windows.Forms.PictureBox();
            this.menuPic = new System.Windows.Forms.PictureBox();
            this.gameendPic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.enemy8Pic = new System.Windows.Forms.PictureBox();
            this.enemy7Pic = new System.Windows.Forms.PictureBox();
            this.enemy5Pic = new System.Windows.Forms.PictureBox();
            this.enemy6Pic = new System.Windows.Forms.PictureBox();
            this.enemy3Pic = new System.Windows.Forms.PictureBox();
            this.enemy4Pic = new System.Windows.Forms.PictureBox();
            this.enemy2Pic = new System.Windows.Forms.PictureBox();
            this.enemy1Pic = new System.Windows.Forms.PictureBox();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.menuLabel = new System.Windows.Forms.Label();
            this.enemySoundTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameendPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy8Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy7Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy5Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy6Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy4Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // playerTimer
            // 
            this.playerTimer.Enabled = true;
            this.playerTimer.Interval = 10;
            this.playerTimer.Tick += new System.EventHandler(this.playerTimer_Tick_1);
            // 
            // opencloseTimer
            // 
            this.opencloseTimer.Enabled = true;
            this.opencloseTimer.Tick += new System.EventHandler(this.opencloseTimer_Tick);
            // 
            // enemyTimer
            // 
            this.enemyTimer.Enabled = true;
            this.enemyTimer.Interval = 1;
            this.enemyTimer.Tick += new System.EventHandler(this.enemyTimer_Tick);
            // 
            // powerupTimer
            // 
            this.powerupTimer.Interval = 80;
            this.powerupTimer.Tick += new System.EventHandler(this.powerupTimer_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.scoreLabel.Location = new System.Drawing.Point(161, 52);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(103, 21);
            this.scoreLabel.TabIndex = 10;
            // 
            // eliminateLabel
            // 
            this.eliminateLabel.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminateLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.eliminateLabel.Location = new System.Drawing.Point(265, 52);
            this.eliminateLabel.Name = "eliminateLabel";
            this.eliminateLabel.Size = new System.Drawing.Size(142, 22);
            this.eliminateLabel.TabIndex = 11;
            // 
            // gameoverTimer
            // 
            this.gameoverTimer.Interval = 1;
            this.gameoverTimer.Tick += new System.EventHandler(this.gameoverTimer_Tick);
            // 
            // startEnemy4
            // 
            this.startEnemy4.BackColor = System.Drawing.Color.Transparent;
            this.startEnemy4.BackgroundImage = global::New_Packman.Properties.Resources.startEnemy4L;
            this.startEnemy4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startEnemy4.Location = new System.Drawing.Point(885, 233);
            this.startEnemy4.Name = "startEnemy4";
            this.startEnemy4.Size = new System.Drawing.Size(35, 35);
            this.startEnemy4.TabIndex = 21;
            this.startEnemy4.TabStop = false;
            this.startEnemy4.Visible = false;
            // 
            // startEnemy3
            // 
            this.startEnemy3.BackColor = System.Drawing.Color.Transparent;
            this.startEnemy3.BackgroundImage = global::New_Packman.Properties.Resources.startEnemy3L;
            this.startEnemy3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startEnemy3.Location = new System.Drawing.Point(840, 233);
            this.startEnemy3.Name = "startEnemy3";
            this.startEnemy3.Size = new System.Drawing.Size(35, 35);
            this.startEnemy3.TabIndex = 20;
            this.startEnemy3.TabStop = false;
            this.startEnemy3.Visible = false;
            // 
            // startEnemy2
            // 
            this.startEnemy2.BackColor = System.Drawing.Color.Transparent;
            this.startEnemy2.BackgroundImage = global::New_Packman.Properties.Resources.startEnemy2L;
            this.startEnemy2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startEnemy2.Location = new System.Drawing.Point(795, 233);
            this.startEnemy2.Name = "startEnemy2";
            this.startEnemy2.Size = new System.Drawing.Size(35, 35);
            this.startEnemy2.TabIndex = 19;
            this.startEnemy2.TabStop = false;
            this.startEnemy2.Visible = false;
            // 
            // startEnemy1
            // 
            this.startEnemy1.BackColor = System.Drawing.Color.Transparent;
            this.startEnemy1.BackgroundImage = global::New_Packman.Properties.Resources.startEnemy1L;
            this.startEnemy1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startEnemy1.Location = new System.Drawing.Point(750, 233);
            this.startEnemy1.Name = "startEnemy1";
            this.startEnemy1.Size = new System.Drawing.Size(35, 35);
            this.startEnemy1.TabIndex = 18;
            this.startEnemy1.TabStop = false;
            this.startEnemy1.Visible = false;
            // 
            // menuPic
            // 
            this.menuPic.BackColor = System.Drawing.Color.Transparent;
            this.menuPic.BackgroundImage = global::New_Packman.Properties.Resources.menuPic;
            this.menuPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuPic.Location = new System.Drawing.Point(7, -44);
            this.menuPic.Name = "menuPic";
            this.menuPic.Size = new System.Drawing.Size(547, 308);
            this.menuPic.TabIndex = 17;
            this.menuPic.TabStop = false;
            // 
            // gameendPic
            // 
            this.gameendPic.BackColor = System.Drawing.Color.Transparent;
            this.gameendPic.BackgroundImage = global::New_Packman.Properties.Resources.gameoverPic;
            this.gameendPic.Location = new System.Drawing.Point(98, 114);
            this.gameendPic.Name = "gameendPic";
            this.gameendPic.Size = new System.Drawing.Size(364, 232);
            this.gameendPic.TabIndex = 15;
            this.gameendPic.TabStop = false;
            this.gameendPic.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::New_Packman.Properties.Resources.enemyWeak;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(360, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 14);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // enemy8Pic
            // 
            this.enemy8Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy8Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy8Pic.Location = new System.Drawing.Point(433, 367);
            this.enemy8Pic.Name = "enemy8Pic";
            this.enemy8Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy8Pic.TabIndex = 8;
            this.enemy8Pic.TabStop = false;
            // 
            // enemy7Pic
            // 
            this.enemy7Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy7Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy7Pic.Location = new System.Drawing.Point(113, 367);
            this.enemy7Pic.Name = "enemy7Pic";
            this.enemy7Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy7Pic.TabIndex = 7;
            this.enemy7Pic.TabStop = false;
            // 
            // enemy5Pic
            // 
            this.enemy5Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy5Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy5Pic.Location = new System.Drawing.Point(63, 242);
            this.enemy5Pic.Name = "enemy5Pic";
            this.enemy5Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy5Pic.TabIndex = 6;
            this.enemy5Pic.TabStop = false;
            // 
            // enemy6Pic
            // 
            this.enemy6Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy6Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy6Pic.Location = new System.Drawing.Point(483, 242);
            this.enemy6Pic.Name = "enemy6Pic";
            this.enemy6Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy6Pic.TabIndex = 5;
            this.enemy6Pic.TabStop = false;
            // 
            // enemy3Pic
            // 
            this.enemy3Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy3Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy3Pic.Location = new System.Drawing.Point(313, 77);
            this.enemy3Pic.Name = "enemy3Pic";
            this.enemy3Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy3Pic.TabIndex = 3;
            this.enemy3Pic.TabStop = false;
            // 
            // enemy4Pic
            // 
            this.enemy4Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy4Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy4Pic.Location = new System.Drawing.Point(453, 57);
            this.enemy4Pic.Name = "enemy4Pic";
            this.enemy4Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy4Pic.TabIndex = 2;
            this.enemy4Pic.TabStop = false;
            // 
            // enemy2Pic
            // 
            this.enemy2Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy2Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy2Pic.Location = new System.Drawing.Point(233, 77);
            this.enemy2Pic.Name = "enemy2Pic";
            this.enemy2Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy2Pic.TabIndex = 1;
            this.enemy2Pic.TabStop = false;
            // 
            // enemy1Pic
            // 
            this.enemy1Pic.BackColor = System.Drawing.Color.Transparent;
            this.enemy1Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemy1Pic.Location = new System.Drawing.Point(93, 57);
            this.enemy1Pic.Name = "enemy1Pic";
            this.enemy1Pic.Size = new System.Drawing.Size(16, 16);
            this.enemy1Pic.TabIndex = 0;
            this.enemy1Pic.TabStop = false;
            // 
            // startTimer
            // 
            this.startTimer.Interval = 1;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // menuLabel
            // 
            this.menuLabel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuLabel.Location = new System.Drawing.Point(0, 320);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(560, 26);
            this.menuLabel.TabIndex = 22;
            this.menuLabel.Text = "Press ❝SPASE❞ to start the game";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // enemySoundTimer
            // 
            this.enemySoundTimer.Enabled = true;
            this.enemySoundTimer.Tick += new System.EventHandler(this.enemySoundTimer_Tick);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(560, 500);
            this.Controls.Add(this.startEnemy4);
            this.Controls.Add(this.startEnemy3);
            this.Controls.Add(this.startEnemy2);
            this.Controls.Add(this.startEnemy1);
            this.Controls.Add(this.menuPic);
            this.Controls.Add(this.menuLabel);
            this.Controls.Add(this.gameendPic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.eliminateLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.enemy8Pic);
            this.Controls.Add(this.enemy7Pic);
            this.Controls.Add(this.enemy5Pic);
            this.Controls.Add(this.enemy6Pic);
            this.Controls.Add(this.enemy3Pic);
            this.Controls.Add(this.enemy4Pic);
            this.Controls.Add(this.enemy2Pic);
            this.Controls.Add(this.enemy1Pic);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEnemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameendPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy8Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy7Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy5Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy6Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy4Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer playerTimer;
        private System.Windows.Forms.Timer opencloseTimer;
        private System.Windows.Forms.PictureBox enemy1Pic;
        private System.Windows.Forms.PictureBox enemy2Pic;
        private System.Windows.Forms.PictureBox enemy4Pic;
        private System.Windows.Forms.PictureBox enemy3Pic;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.PictureBox enemy6Pic;
        private System.Windows.Forms.PictureBox enemy5Pic;
        private System.Windows.Forms.PictureBox enemy7Pic;
        private System.Windows.Forms.PictureBox enemy8Pic;
        private System.Windows.Forms.Timer powerupTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label eliminateLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox gameendPic;
        private System.Windows.Forms.Timer gameoverTimer;
        private System.Windows.Forms.PictureBox menuPic;
        private System.Windows.Forms.PictureBox startEnemy1;
        private System.Windows.Forms.PictureBox startEnemy2;
        private System.Windows.Forms.PictureBox startEnemy3;
        private System.Windows.Forms.PictureBox startEnemy4;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.Timer enemySoundTimer;
    }
}

