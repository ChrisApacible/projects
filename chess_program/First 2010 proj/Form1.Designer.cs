namespace First_2010_proj
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bMove = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.bPause = new System.Windows.Forms.Button();
            this.lbTurn = new System.Windows.Forms.Label();
            this.lbNotation = new System.Windows.Forms.ListBox();
            this.lbNotation2 = new System.Windows.Forms.ListBox();
            this.txtWhite = new System.Windows.Forms.Label();
            this.txtBlack = new System.Windows.Forms.Label();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.txtTimerBlack = new System.Windows.Forms.TextBox();
            this.gbNotationPanel = new System.Windows.Forms.Panel();
            this.bSend = new System.Windows.Forms.Button();
            this.txtThread = new System.Windows.Forms.TextBox();
            this.pbTimers = new System.Windows.Forms.Panel();
            this.gbMainMenu = new System.Windows.Forms.Panel();
            this.bClient = new System.Windows.Forms.Button();
            this.bServer = new System.Windows.Forms.Button();
            this.cbAi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimePerPlayer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bNewGame = new System.Windows.Forms.Button();
            this.bRestart = new System.Windows.Forms.Button();
            this.bResume = new System.Windows.Forms.Button();
            this.gbPauseMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.gbAllMenu = new System.Windows.Forms.Panel();
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            this.tBot = new System.Windows.Forms.Timer(this.components);
            this.tThread = new System.Windows.Forms.Timer(this.components);
            this.gbNotationPanel.SuspendLayout();
            this.pbTimers.SuspendLayout();
            this.gbMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbPauseMenu.SuspendLayout();
            this.gbAllMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bMove
            // 
            this.bMove.BackColor = System.Drawing.SystemColors.InfoText;
            this.bMove.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bMove.Location = new System.Drawing.Point(231, 194);
            this.bMove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bMove.Name = "bMove";
            this.bMove.Size = new System.Drawing.Size(8, 27);
            this.bMove.TabIndex = 64;
            this.bMove.Text = "Move";
            this.bMove.UseVisualStyleBackColor = false;
            this.bMove.Visible = false;
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtInput.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInput.Location = new System.Drawing.Point(219, 195);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.MaxLength = 4;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(8, 27);
            this.txtInput.TabIndex = 65;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.Visible = false;
            // 
            // bPause
            // 
            this.bPause.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPause.Location = new System.Drawing.Point(32, 508);
            this.bPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(180, 24);
            this.bPause.TabIndex = 66;
            this.bPause.Text = "Menu";
            this.bPause.UseVisualStyleBackColor = true;
            this.bPause.Click += new System.EventHandler(this.bRestart_Click);
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurn.ForeColor = System.Drawing.SystemColors.Info;
            this.lbTurn.Location = new System.Drawing.Point(70, 6);
            this.lbTurn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(128, 17);
            this.lbTurn.TabIndex = 67;
            this.lbTurn.Text = "White\'s Turn 1";
            // 
            // lbNotation
            // 
            this.lbNotation.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbNotation.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotation.FormattingEnabled = true;
            this.lbNotation.ItemHeight = 17;
            this.lbNotation.Location = new System.Drawing.Point(8, 124);
            this.lbNotation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbNotation.Name = "lbNotation";
            this.lbNotation.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbNotation.Size = new System.Drawing.Size(118, 361);
            this.lbNotation.TabIndex = 68;
            // 
            // lbNotation2
            // 
            this.lbNotation2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbNotation2.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotation2.FormattingEnabled = true;
            this.lbNotation2.ItemHeight = 17;
            this.lbNotation2.Location = new System.Drawing.Point(130, 124);
            this.lbNotation2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbNotation2.Name = "lbNotation2";
            this.lbNotation2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbNotation2.Size = new System.Drawing.Size(118, 361);
            this.lbNotation2.TabIndex = 69;
            // 
            // txtWhite
            // 
            this.txtWhite.AutoSize = true;
            this.txtWhite.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhite.ForeColor = System.Drawing.SystemColors.Info;
            this.txtWhite.Location = new System.Drawing.Point(38, 62);
            this.txtWhite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtWhite.Name = "txtWhite";
            this.txtWhite.Size = new System.Drawing.Size(58, 17);
            this.txtWhite.TabIndex = 70;
            this.txtWhite.Text = "White";
            // 
            // txtBlack
            // 
            this.txtBlack.AutoSize = true;
            this.txtBlack.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlack.ForeColor = System.Drawing.SystemColors.Info;
            this.txtBlack.Location = new System.Drawing.Point(158, 62);
            this.txtBlack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtBlack.Name = "txtBlack";
            this.txtBlack.Size = new System.Drawing.Size(58, 17);
            this.txtBlack.TabIndex = 71;
            this.txtBlack.Text = "Black";
            // 
            // txtTimer
            // 
            this.txtTimer.BackColor = System.Drawing.SystemColors.Info;
            this.txtTimer.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimer.Location = new System.Drawing.Point(6, 2);
            this.txtTimer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(118, 24);
            this.txtTimer.TabIndex = 72;
            this.txtTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTimerBlack
            // 
            this.txtTimerBlack.BackColor = System.Drawing.SystemColors.Info;
            this.txtTimerBlack.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimerBlack.Location = new System.Drawing.Point(128, 2);
            this.txtTimerBlack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimerBlack.Name = "txtTimerBlack";
            this.txtTimerBlack.ReadOnly = true;
            this.txtTimerBlack.Size = new System.Drawing.Size(118, 24);
            this.txtTimerBlack.TabIndex = 73;
            this.txtTimerBlack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbNotationPanel
            // 
            this.gbNotationPanel.Controls.Add(this.bSend);
            this.gbNotationPanel.Controls.Add(this.txtThread);
            this.gbNotationPanel.Controls.Add(this.pbTimers);
            this.gbNotationPanel.Controls.Add(this.lbNotation2);
            this.gbNotationPanel.Controls.Add(this.bPause);
            this.gbNotationPanel.Controls.Add(this.lbTurn);
            this.gbNotationPanel.Controls.Add(this.txtInput);
            this.gbNotationPanel.Controls.Add(this.lbNotation);
            this.gbNotationPanel.Controls.Add(this.bMove);
            this.gbNotationPanel.Controls.Add(this.txtWhite);
            this.gbNotationPanel.Controls.Add(this.txtBlack);
            this.gbNotationPanel.Location = new System.Drawing.Point(692, 16);
            this.gbNotationPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbNotationPanel.Name = "gbNotationPanel";
            this.gbNotationPanel.Size = new System.Drawing.Size(256, 670);
            this.gbNotationPanel.TabIndex = 75;
            this.gbNotationPanel.Visible = false;
            // 
            // bSend
            // 
            this.bSend.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSend.Location = new System.Drawing.Point(92, 32);
            this.bSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(72, 23);
            this.bSend.TabIndex = 79;
            this.bSend.Text = "READY";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Visible = false;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // txtThread
            // 
            this.txtThread.Location = new System.Drawing.Point(92, 32);
            this.txtThread.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtThread.Name = "txtThread";
            this.txtThread.Size = new System.Drawing.Size(73, 20);
            this.txtThread.TabIndex = 5;
            this.txtThread.Visible = false;
            // 
            // pbTimers
            // 
            this.pbTimers.Controls.Add(this.txtTimer);
            this.pbTimers.Controls.Add(this.txtTimerBlack);
            this.pbTimers.Location = new System.Drawing.Point(2, 84);
            this.pbTimers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbTimers.Name = "pbTimers";
            this.pbTimers.Size = new System.Drawing.Size(252, 34);
            this.pbTimers.TabIndex = 74;
            // 
            // gbMainMenu
            // 
            this.gbMainMenu.Controls.Add(this.bClient);
            this.gbMainMenu.Controls.Add(this.bServer);
            this.gbMainMenu.Controls.Add(this.cbAi);
            this.gbMainMenu.Controls.Add(this.label2);
            this.gbMainMenu.Controls.Add(this.cbTime);
            this.gbMainMenu.Controls.Add(this.label4);
            this.gbMainMenu.Controls.Add(this.txtTimePerPlayer);
            this.gbMainMenu.Controls.Add(this.pictureBox1);
            this.gbMainMenu.Controls.Add(this.bNewGame);
            this.gbMainMenu.Location = new System.Drawing.Point(389, 59);
            this.gbMainMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbMainMenu.Name = "gbMainMenu";
            this.gbMainMenu.Size = new System.Drawing.Size(189, 456);
            this.gbMainMenu.TabIndex = 3;
            // 
            // bClient
            // 
            this.bClient.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClient.Location = new System.Drawing.Point(7, 262);
            this.bClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bClient.Name = "bClient";
            this.bClient.Size = new System.Drawing.Size(180, 23);
            this.bClient.TabIndex = 81;
            this.bClient.Text = "ONLINE-BLACK";
            this.bClient.UseVisualStyleBackColor = true;
            this.bClient.Click += new System.EventHandler(this.bClient_Click);
            // 
            // bServer
            // 
            this.bServer.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bServer.Location = new System.Drawing.Point(4, 216);
            this.bServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bServer.Name = "bServer";
            this.bServer.Size = new System.Drawing.Size(180, 23);
            this.bServer.TabIndex = 80;
            this.bServer.Text = "ONLINE-WHITE";
            this.bServer.UseVisualStyleBackColor = true;
            this.bServer.Click += new System.EventHandler(this.bServer_Click);
            // 
            // cbAi
            // 
            this.cbAi.BackColor = System.Drawing.SystemColors.Info;
            this.cbAi.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAi.FormattingEnabled = true;
            this.cbAi.Items.AddRange(new object[] {
            "SINGLE PLAYER",
            "MULTIPLAYER"});
            this.cbAi.Location = new System.Drawing.Point(22, 423);
            this.cbAi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAi.Name = "cbAi";
            this.cbAi.Size = new System.Drawing.Size(144, 25);
            this.cbAi.TabIndex = 79;
            this.cbAi.Visible = false;
            this.cbAi.SelectedIndexChanged += new System.EventHandler(this.cbAi_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(29, 404);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Player options";
            this.label2.Visible = false;
            // 
            // cbTime
            // 
            this.cbTime.BackColor = System.Drawing.SystemColors.Info;
            this.cbTime.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Items.AddRange(new object[] {
            "NO TIMER",
            "5:00",
            "10:00",
            "15:00",
            "30:00",
            "45:00",
            "60:00",
            "90:00",
            "120:00"});
            this.cbTime.Location = new System.Drawing.Point(28, 366);
            this.cbTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(144, 25);
            this.cbTime.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(36, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 42);
            this.label4.TabIndex = 76;
            this.label4.Text = "CHESS";
            // 
            // txtTimePerPlayer
            // 
            this.txtTimePerPlayer.AutoSize = true;
            this.txtTimePerPlayer.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimePerPlayer.ForeColor = System.Drawing.SystemColors.Info;
            this.txtTimePerPlayer.Location = new System.Drawing.Point(36, 346);
            this.txtTimePerPlayer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTimePerPlayer.Name = "txtTimePerPlayer";
            this.txtTimePerPlayer.Size = new System.Drawing.Size(142, 17);
            this.txtTimePerPlayer.TabIndex = 74;
            this.txtTimePerPlayer.Text = "Time per player";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::First_2010_proj.Properties.Resources.liberty40f;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 105);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // bNewGame
            // 
            this.bNewGame.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNewGame.Location = new System.Drawing.Point(7, 306);
            this.bNewGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(180, 23);
            this.bNewGame.TabIndex = 4;
            this.bNewGame.Text = "Offline";
            this.bNewGame.UseVisualStyleBackColor = true;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // bRestart
            // 
            this.bRestart.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRestart.Location = new System.Drawing.Point(2, 32);
            this.bRestart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(180, 23);
            this.bRestart.TabIndex = 1;
            this.bRestart.Text = "Quit";
            this.bRestart.UseVisualStyleBackColor = true;
            this.bRestart.Click += new System.EventHandler(this.bRestart_Click_1);
            // 
            // bResume
            // 
            this.bResume.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bResume.Location = new System.Drawing.Point(2, 4);
            this.bResume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bResume.Name = "bResume";
            this.bResume.Size = new System.Drawing.Size(180, 23);
            this.bResume.TabIndex = 0;
            this.bResume.Text = "Resume";
            this.bResume.UseVisualStyleBackColor = true;
            this.bResume.Click += new System.EventHandler(this.bResume_Click);
            // 
            // gbPauseMenu
            // 
            this.gbPauseMenu.Controls.Add(this.label1);
            this.gbPauseMenu.Controls.Add(this.cbColor);
            this.gbPauseMenu.Controls.Add(this.bResume);
            this.gbPauseMenu.Controls.Add(this.bRestart);
            this.gbPauseMenu.Location = new System.Drawing.Point(236, 175);
            this.gbPauseMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbPauseMenu.Name = "gbPauseMenu";
            this.gbPauseMenu.Size = new System.Drawing.Size(185, 247);
            this.gbPauseMenu.TabIndex = 4;
            this.gbPauseMenu.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(38, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Board Color";
            // 
            // cbColor
            // 
            this.cbColor.BackColor = System.Drawing.SystemColors.Info;
            this.cbColor.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "Brown",
            "Gray",
            "Green",
            "Red",
            "Purple",
            "Orange"});
            this.cbColor.Location = new System.Drawing.Point(28, 133);
            this.cbColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(127, 25);
            this.cbColor.TabIndex = 78;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            // 
            // gbAllMenu
            // 
            this.gbAllMenu.Controls.Add(this.gbPauseMenu);
            this.gbAllMenu.Controls.Add(this.gbMainMenu);
            this.gbAllMenu.Location = new System.Drawing.Point(-4, 2);
            this.gbAllMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbAllMenu.Name = "gbAllMenu";
            this.gbAllMenu.Size = new System.Drawing.Size(692, 684);
            this.gbAllMenu.TabIndex = 76;
            // 
            // tTimer
            // 
            this.tTimer.Interval = 1000;
            this.tTimer.Tick += new System.EventHandler(this.tTimer_Tick);
            // 
            // tBot
            // 
            this.tBot.Enabled = true;
            this.tBot.Interval = 1000;
            this.tBot.Tick += new System.EventHandler(this.tBot_Tick);
            // 
            // tThread
            // 
            this.tThread.Interval = 50;
            this.tThread.Tick += new System.EventHandler(this.tThread_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(949, 687);
            this.Controls.Add(this.gbAllMenu);
            this.Controls.Add(this.gbNotationPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(965, 726);
            this.MinimumSize = new System.Drawing.Size(965, 726);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHESS";
            this.gbNotationPanel.ResumeLayout(false);
            this.gbNotationPanel.PerformLayout();
            this.pbTimers.ResumeLayout(false);
            this.pbTimers.PerformLayout();
            this.gbMainMenu.ResumeLayout(false);
            this.gbMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbPauseMenu.ResumeLayout(false);
            this.gbPauseMenu.PerformLayout();
            this.gbAllMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.ListBox lbNotation;
        private System.Windows.Forms.ListBox lbNotation2;
        private System.Windows.Forms.Label txtWhite;
        private System.Windows.Forms.Label txtBlack;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.TextBox txtTimerBlack;
        private System.Windows.Forms.Panel gbNotationPanel;
        private System.Windows.Forms.Panel gbMainMenu;
        private System.Windows.Forms.Button bResume;
        private System.Windows.Forms.Button bRestart;
        private System.Windows.Forms.Button bNewGame;
        private System.Windows.Forms.Panel gbPauseMenu;
        private System.Windows.Forms.Panel gbAllMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtTimePerPlayer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pbTimers;
        private System.Windows.Forms.Timer tTimer;
        private System.Windows.Forms.ComboBox cbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbAi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tBot;
        private System.Windows.Forms.TextBox txtThread;
        private System.Windows.Forms.Button bClient;
        private System.Windows.Forms.Button bServer;
        private System.Windows.Forms.Timer tThread;
        private System.Windows.Forms.Button bSend;
    }
}

