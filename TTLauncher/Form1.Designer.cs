namespace TTLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playButton = new System.Windows.Forms.Button();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.serverInfoListView = new System.Windows.Forms.ListView();
            this.versionLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.refreshServerInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.infoAboutServerLabel = new System.Windows.Forms.Label();
            this.linksLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.webButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playButton.Location = new System.Drawing.Point(220, 20);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(103, 31);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Подключиться";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nicknameLabel.Location = new System.Drawing.Point(9, 9);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(57, 15);
            this.nicknameLabel.TabIndex = 2;
            this.nicknameLabel.Text = "Никнейм";
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nicknameTextBox.Location = new System.Drawing.Point(12, 25);
            this.nicknameTextBox.MaxLength = 24;
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(197, 21);
            this.nicknameTextBox.TabIndex = 3;
            // 
            // serverInfoListView
            // 
            this.serverInfoListView.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverInfoListView.HideSelection = false;
            this.serverInfoListView.Location = new System.Drawing.Point(12, 82);
            this.serverInfoListView.Name = "serverInfoListView";
            this.serverInfoListView.Size = new System.Drawing.Size(344, 75);
            this.serverInfoListView.TabIndex = 5;
            this.serverInfoListView.UseCompatibleStateImageBehavior = false;
            this.serverInfoListView.View = System.Windows.Forms.View.List;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionLabel.Location = new System.Drawing.Point(324, 240);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.versionLabel.Size = new System.Drawing.Size(36, 12);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "label1";
            // 
            // authorLabel
            // 
            this.authorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorLabel.Location = new System.Drawing.Point(10, 240);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(36, 12);
            this.authorLabel.TabIndex = 7;
            this.authorLabel.Text = "label2";
            // 
            // refreshServerInfoTimer
            // 
            this.refreshServerInfoTimer.Interval = 2000;
            this.refreshServerInfoTimer.Tick += new System.EventHandler(this.refreshServerInfoTimer_Tick);
            // 
            // infoAboutServerLabel
            // 
            this.infoAboutServerLabel.AutoSize = true;
            this.infoAboutServerLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoAboutServerLabel.Location = new System.Drawing.Point(9, 64);
            this.infoAboutServerLabel.Name = "infoAboutServerLabel";
            this.infoAboutServerLabel.Size = new System.Drawing.Size(144, 15);
            this.infoAboutServerLabel.TabIndex = 8;
            this.infoAboutServerLabel.Text = "Информация о сервере";
            // 
            // linksLabel
            // 
            this.linksLabel.AutoSize = true;
            this.linksLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linksLabel.Location = new System.Drawing.Point(9, 173);
            this.linksLabel.Name = "linksLabel";
            this.linksLabel.Size = new System.Drawing.Size(52, 15);
            this.linksLabel.TabIndex = 9;
            this.linksLabel.Text = "Ссылки";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TTLauncher.Properties.Resources.vk;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(49, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 31);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webButton
            // 
            this.webButton.BackgroundImage = global::TTLauncher.Properties.Resources.web;
            this.webButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.webButton.Location = new System.Drawing.Point(12, 191);
            this.webButton.Name = "webButton";
            this.webButton.Size = new System.Drawing.Size(31, 31);
            this.webButton.TabIndex = 10;
            this.webButton.UseVisualStyleBackColor = true;
            this.webButton.Click += new System.EventHandler(this.webButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.BackgroundImage = global::TTLauncher.Properties.Resources.gear;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.Location = new System.Drawing.Point(329, 20);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(31, 31);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webButton);
            this.Controls.Add(this.linksLabel);
            this.Controls.Add(this.infoAboutServerLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.serverInfoListView);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.nicknameTextBox);
            this.Controls.Add(this.playButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tengoku Team Launcher";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.TextBox nicknameTextBox;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.ListView serverInfoListView;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Timer refreshServerInfoTimer;
        private System.Windows.Forms.Label infoAboutServerLabel;
        private System.Windows.Forms.Label linksLabel;
        private System.Windows.Forms.Button webButton;
        private System.Windows.Forms.Button button1;
    }
}

