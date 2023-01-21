namespace ChatApp___Client
{
    partial class frmClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.imgListIcons = new System.Windows.Forms.ImageList(this.components);
            this.tpTesting = new System.Windows.Forms.TabPage();
            this.btnRefreshResults = new MaterialSkin.Controls.MaterialButton();
            this.lvResults = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTestResults = new MaterialSkin.Controls.MaterialLabel();
            this.tpChat = new System.Windows.Forms.TabPage();
            this.lblClientName = new MaterialSkin.Controls.MaterialLabel();
            this.tbInfo = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.cbTestMode = new MaterialSkin.Controls.MaterialCheckbox();
            this.lblUsers = new MaterialSkin.Controls.MaterialLabel();
            this.lvUsers = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSend = new MaterialSkin.Controls.MaterialButton();
            this.tbSend = new MaterialSkin.Controls.MaterialTextBox();
            this.TabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tpTesting.SuspendLayout();
            this.tpChat.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListIcons
            // 
            this.imgListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIcons.ImageStream")));
            this.imgListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIcons.Images.SetKeyName(0, "Chat32.png");
            this.imgListIcons.Images.SetKeyName(1, "Perf32.png");
            // 
            // tpTesting
            // 
            this.tpTesting.Controls.Add(this.btnRefreshResults);
            this.tpTesting.Controls.Add(this.lvResults);
            this.tpTesting.Controls.Add(this.lblTestResults);
            this.tpTesting.ImageKey = "Perf32.png";
            this.tpTesting.Location = new System.Drawing.Point(4, 39);
            this.tpTesting.Name = "tpTesting";
            this.tpTesting.Size = new System.Drawing.Size(786, 390);
            this.tpTesting.TabIndex = 2;
            this.tpTesting.Text = "Testing";
            this.tpTesting.UseVisualStyleBackColor = true;
            // 
            // btnRefreshResults
            // 
            this.btnRefreshResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshResults.AutoSize = false;
            this.btnRefreshResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshResults.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefreshResults.Depth = 0;
            this.btnRefreshResults.HighEmphasis = true;
            this.btnRefreshResults.Icon = null;
            this.btnRefreshResults.Location = new System.Drawing.Point(610, 346);
            this.btnRefreshResults.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshResults.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshResults.Name = "btnRefreshResults";
            this.btnRefreshResults.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefreshResults.Size = new System.Drawing.Size(164, 32);
            this.btnRefreshResults.TabIndex = 22;
            this.btnRefreshResults.Text = "Recompute Results";
            this.btnRefreshResults.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefreshResults.UseAccentColor = false;
            this.btnRefreshResults.UseVisualStyleBackColor = true;
            this.btnRefreshResults.Click += new System.EventHandler(this.btnRefreshResults_Click);
            // 
            // lvResults
            // 
            this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResults.AutoSizeTable = false;
            this.lvResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvResults.Depth = 0;
            this.lvResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvResults.FullRowSelect = true;
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(16, 35);
            this.lvResults.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvResults.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvResults.MouseState = MaterialSkin.MouseState.OUT;
            this.lvResults.Name = "lvResults";
            this.lvResults.OwnerDraw = true;
            this.lvResults.Size = new System.Drawing.Size(758, 302);
            this.lvResults.TabIndex = 21;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Method";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Key Size";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Text Size";
            this.columnHeader4.Width = 131;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Number of Iterations";
            this.columnHeader5.Width = 186;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Elapsed Time (Ms)";
            this.columnHeader6.Width = 150;
            // 
            // lblTestResults
            // 
            this.lblTestResults.AutoSize = true;
            this.lblTestResults.Depth = 0;
            this.lblTestResults.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTestResults.Location = new System.Drawing.Point(13, 13);
            this.lblTestResults.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTestResults.Name = "lblTestResults";
            this.lblTestResults.Size = new System.Drawing.Size(325, 19);
            this.lblTestResults.TabIndex = 20;
            this.lblTestResults.Text = "Test Results (Only Encryption and Decryption)";
            // 
            // tpChat
            // 
            this.tpChat.Controls.Add(this.lblClientName);
            this.tpChat.Controls.Add(this.tbInfo);
            this.tpChat.Controls.Add(this.cbTestMode);
            this.tpChat.Controls.Add(this.lblUsers);
            this.tpChat.Controls.Add(this.lvUsers);
            this.tpChat.Controls.Add(this.btnSend);
            this.tpChat.Controls.Add(this.tbSend);
            this.tpChat.ImageKey = "Chat32.png";
            this.tpChat.Location = new System.Drawing.Point(4, 39);
            this.tpChat.Name = "tpChat";
            this.tpChat.Padding = new System.Windows.Forms.Padding(3);
            this.tpChat.Size = new System.Drawing.Size(786, 390);
            this.tpChat.TabIndex = 0;
            this.tpChat.Text = "Chat";
            this.tpChat.UseVisualStyleBackColor = true;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Depth = 0;
            this.lblClientName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientName.Location = new System.Drawing.Point(209, 12);
            this.lblClientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(1, 0);
            this.lblClientName.TabIndex = 14;
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfo.Depth = 0;
            this.tbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbInfo.Location = new System.Drawing.Point(212, 43);
            this.tbInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(567, 285);
            this.tbInfo.TabIndex = 10;
            this.tbInfo.Text = "";
            // 
            // cbTestMode
            // 
            this.cbTestMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTestMode.AutoSize = true;
            this.cbTestMode.Depth = 0;
            this.cbTestMode.Location = new System.Drawing.Point(669, 3);
            this.cbTestMode.Margin = new System.Windows.Forms.Padding(0);
            this.cbTestMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbTestMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbTestMode.Name = "cbTestMode";
            this.cbTestMode.ReadOnly = false;
            this.cbTestMode.Ripple = true;
            this.cbTestMode.Size = new System.Drawing.Size(110, 37);
            this.cbTestMode.TabIndex = 13;
            this.cbTestMode.Text = "Test Mode";
            this.cbTestMode.UseVisualStyleBackColor = true;
            this.cbTestMode.CheckedChanged += new System.EventHandler(this.cbTestMode_CheckedChanged);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Depth = 0;
            this.lblUsers.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUsers.Location = new System.Drawing.Point(6, 12);
            this.lblUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(89, 19);
            this.lblUsers.TabIndex = 9;
            this.lblUsers.Text = "Online Users";
            // 
            // lvUsers
            // 
            this.lvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvUsers.AutoSizeTable = false;
            this.lvUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvUsers.Depth = 0;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(6, 40);
            this.lvUsers.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.OwnerDraw = true;
            this.lvUsers.Size = new System.Drawing.Size(200, 288);
            this.lvUsers.TabIndex = 8;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.AutoSize = false;
            this.btnSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSend.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSend.Depth = 0;
            this.btnSend.HighEmphasis = true;
            this.btnSend.Icon = null;
            this.btnSend.Location = new System.Drawing.Point(704, 334);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSend.Size = new System.Drawing.Size(75, 50);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSend.UseAccentColor = false;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.AnimateReadOnly = false;
            this.tbSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSend.Depth = 0;
            this.tbSend.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSend.LeadingIcon = null;
            this.tbSend.Location = new System.Drawing.Point(6, 334);
            this.tbSend.MaxLength = 128;
            this.tbSend.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSend.Multiline = false;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(691, 50);
            this.tbSend.TabIndex = 6;
            this.tbSend.Text = "";
            this.tbSend.TrailingIcon = null;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tpChat);
            this.TabControl.Controls.Add(this.tpTesting);
            this.TabControl.Depth = 0;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ImageList = this.imgListIcons;
            this.TabControl.Location = new System.Drawing.Point(3, 64);
            this.TabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(794, 433);
            this.TabControl.TabIndex = 6;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.TabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControl;
            this.Name = "frmClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.tpTesting.ResumeLayout(false);
            this.tpTesting.PerformLayout();
            this.tpChat.ResumeLayout(false);
            this.tpChat.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgListIcons;
        private System.Windows.Forms.TabPage tpTesting;
        private MaterialSkin.Controls.MaterialButton btnRefreshResults;
        private MaterialSkin.Controls.MaterialListView lvResults;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private MaterialSkin.Controls.MaterialLabel lblTestResults;
        private System.Windows.Forms.TabPage tpChat;
        private MaterialSkin.Controls.MaterialLabel lblClientName;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbInfo;
        private MaterialSkin.Controls.MaterialCheckbox cbTestMode;
        private MaterialSkin.Controls.MaterialLabel lblUsers;
        private MaterialSkin.Controls.MaterialListView lvUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MaterialSkin.Controls.MaterialButton btnSend;
        private MaterialSkin.Controls.MaterialTextBox tbSend;
        private MaterialSkin.Controls.MaterialTabControl TabControl;
    }
}

