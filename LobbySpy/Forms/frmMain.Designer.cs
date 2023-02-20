namespace LobbySpy
{
    partial class frmMain
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentLobby = new System.Windows.Forms.Label();
            this.lbLobby = new System.Windows.Forms.ListBox();
            this.btnMultiOpgg = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbHistory = new System.Windows.Forms.RichTextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.btnMultiUgg = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 211);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Waiting for League Client...";
            // 
            // lblCurrentLobby
            // 
            this.lblCurrentLobby.AutoSize = true;
            this.lblCurrentLobby.Location = new System.Drawing.Point(12, 33);
            this.lblCurrentLobby.Name = "lblCurrentLobby";
            this.lblCurrentLobby.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentLobby.TabIndex = 1;
            this.lblCurrentLobby.Text = "Current Lobby";
            // 
            // lbLobby
            // 
            this.lbLobby.Enabled = false;
            this.lbLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLobby.FormattingEnabled = true;
            this.lbLobby.ItemHeight = 18;
            this.lbLobby.Location = new System.Drawing.Point(15, 49);
            this.lbLobby.Name = "lbLobby";
            this.lbLobby.Size = new System.Drawing.Size(230, 130);
            this.lbLobby.TabIndex = 3;
            this.lbLobby.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbLobby_MouseDoubleClick);
            // 
            // btnMultiOpgg
            // 
            this.btnMultiOpgg.Enabled = false;
            this.btnMultiOpgg.Location = new System.Drawing.Point(15, 185);
            this.btnMultiOpgg.Name = "btnMultiOpgg";
            this.btnMultiOpgg.Size = new System.Drawing.Size(110, 23);
            this.btnMultiOpgg.TabIndex = 4;
            this.btnMultiOpgg.Text = "Multi OP.GG";
            this.btnMultiOpgg.UseVisualStyleBackColor = true;
            this.btnMultiOpgg.Click += new System.EventHandler(this.btnMultiOpgg_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuQuit,
            this.toolStripMenuItemCredits});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(501, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuQuit
            // 
            this.toolStripMenuQuit.Name = "toolStripMenuQuit";
            this.toolStripMenuQuit.Size = new System.Drawing.Size(42, 20);
            this.toolStripMenuQuit.Text = "Quit";
            this.toolStripMenuQuit.Click += new System.EventHandler(this.toolStripMenuQuit_Click);
            // 
            // toolStripMenuItemCredits
            // 
            this.toolStripMenuItemCredits.Name = "toolStripMenuItemCredits";
            this.toolStripMenuItemCredits.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItemCredits.Text = "Credits";
            this.toolStripMenuItemCredits.Click += new System.EventHandler(this.toolStripMenuItemCredits_Click);
            // 
            // rtbHistory
            // 
            this.rtbHistory.Location = new System.Drawing.Point(251, 49);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.ReadOnly = true;
            this.rtbHistory.Size = new System.Drawing.Size(240, 130);
            this.rtbHistory.TabIndex = 6;
            this.rtbHistory.Text = "";
            this.rtbHistory.TextChanged += new System.EventHandler(this.rtbHistory_TextChanged);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(248, 33);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(71, 13);
            this.lblHistory.TabIndex = 7;
            this.lblHistory.Text = "Lobby History";
            // 
            // btnMultiUgg
            // 
            this.btnMultiUgg.Enabled = false;
            this.btnMultiUgg.Location = new System.Drawing.Point(135, 185);
            this.btnMultiUgg.Name = "btnMultiUgg";
            this.btnMultiUgg.Size = new System.Drawing.Size(110, 23);
            this.btnMultiUgg.TabIndex = 8;
            this.btnMultiUgg.Text = "Multi U.GG";
            this.btnMultiUgg.UseVisualStyleBackColor = true;
            this.btnMultiUgg.Click += new System.EventHandler(this.btnMultiUgg_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 237);
            this.Controls.Add(this.btnMultiUgg);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.rtbHistory);
            this.Controls.Add(this.btnMultiOpgg);
            this.Controls.Add(this.lbLobby);
            this.Controls.Add(this.lblCurrentLobby);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "LobbySpy";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentLobby;
        private System.Windows.Forms.ListBox lbLobby;
        private System.Windows.Forms.Button btnMultiOpgg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuQuit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCredits;
        private System.Windows.Forms.RichTextBox rtbHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Button btnMultiUgg;
    }
}

