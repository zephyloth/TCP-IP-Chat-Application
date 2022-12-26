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
            this.TabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tpChat = new System.Windows.Forms.TabPage();
            this.btnSend1000x = new MaterialSkin.Controls.MaterialButton();
            this.tbInfo = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.lblUsers = new MaterialSkin.Controls.MaterialLabel();
            this.lvUsers = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSend = new MaterialSkin.Controls.MaterialButton();
            this.tbSend = new MaterialSkin.Controls.MaterialTextBox();
            this.tpProfile = new System.Windows.Forms.TabPage();
            this.imgListIcons = new System.Windows.Forms.ImageList(this.components);
            this.TabControl.SuspendLayout();
            this.tpChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tpChat);
            this.TabControl.Controls.Add(this.tpProfile);
            this.TabControl.Depth = 0;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ImageList = this.imgListIcons;
            this.TabControl.Location = new System.Drawing.Point(3, 64);
            this.TabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(693, 436);
            this.TabControl.TabIndex = 6;
            // 
            // tpChat
            // 
            this.tpChat.Controls.Add(this.btnSend1000x);
            this.tpChat.Controls.Add(this.tbInfo);
            this.tpChat.Controls.Add(this.lblUsers);
            this.tpChat.Controls.Add(this.lvUsers);
            this.tpChat.Controls.Add(this.btnSend);
            this.tpChat.Controls.Add(this.tbSend);
            this.tpChat.ImageKey = "Chat32.png";
            this.tpChat.Location = new System.Drawing.Point(4, 39);
            this.tpChat.Name = "tpChat";
            this.tpChat.Padding = new System.Windows.Forms.Padding(3);
            this.tpChat.Size = new System.Drawing.Size(685, 393);
            this.tpChat.TabIndex = 0;
            this.tpChat.Text = "Chat";
            this.tpChat.UseVisualStyleBackColor = true;
            // 
            // btnSend1000x
            // 
            this.btnSend1000x.AutoSize = false;
            this.btnSend1000x.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSend1000x.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSend1000x.Depth = 0;
            this.btnSend1000x.HighEmphasis = true;
            this.btnSend1000x.Icon = null;
            this.btnSend1000x.Location = new System.Drawing.Point(117, 6);
            this.btnSend1000x.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSend1000x.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend1000x.Name = "btnSend1000x";
            this.btnSend1000x.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSend1000x.Size = new System.Drawing.Size(116, 22);
            this.btnSend1000x.TabIndex = 11;
            this.btnSend1000x.Text = "Send 1000x";
            this.btnSend1000x.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSend1000x.UseAccentColor = false;
            this.btnSend1000x.UseVisualStyleBackColor = true;
            this.btnSend1000x.Click += new System.EventHandler(this.btnSend1000x_Click);
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
            this.tbInfo.Location = new System.Drawing.Point(212, 35);
            this.tbInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(466, 296);
            this.tbInfo.TabIndex = 10;
            this.tbInfo.Text = "";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Depth = 0;
            this.lblUsers.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUsers.Location = new System.Drawing.Point(11, 9);
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
            this.lvUsers.Location = new System.Drawing.Point(6, 35);
            this.lvUsers.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.OwnerDraw = true;
            this.lvUsers.Size = new System.Drawing.Size(200, 296);
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
            this.btnSend.Location = new System.Drawing.Point(603, 337);
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
            this.tbSend.Location = new System.Drawing.Point(6, 337);
            this.tbSend.MaxLength = 50;
            this.tbSend.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSend.Multiline = false;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(590, 50);
            this.tbSend.TabIndex = 6;
            this.tbSend.Text = "";
            this.tbSend.TrailingIcon = null;
            // 
            // tpProfile
            // 
            this.tpProfile.ImageKey = "User32.png";
            this.tpProfile.Location = new System.Drawing.Point(4, 39);
            this.tpProfile.Name = "tpProfile";
            this.tpProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tpProfile.Size = new System.Drawing.Size(685, 393);
            this.tpProfile.TabIndex = 1;
            this.tpProfile.Text = "Profile Properties";
            this.tpProfile.UseVisualStyleBackColor = true;
            // 
            // imgListIcons
            // 
            this.imgListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIcons.ImageStream")));
            this.imgListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIcons.Images.SetKeyName(0, "Chat32.png");
            this.imgListIcons.Images.SetKeyName(1, "User32.png");
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(699, 503);
            this.Controls.Add(this.TabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControl;
            this.Name = "frmClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.TabControl.ResumeLayout(false);
            this.tpChat.ResumeLayout(false);
            this.tpChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl TabControl;
        private System.Windows.Forms.TabPage tpChat;
        private System.Windows.Forms.TabPage tpProfile;
        private MaterialSkin.Controls.MaterialTextBox tbSend;
        private MaterialSkin.Controls.MaterialButton btnSend;
        private MaterialSkin.Controls.MaterialListView lvUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MaterialSkin.Controls.MaterialLabel lblUsers;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbInfo;
        private System.Windows.Forms.ImageList imgListIcons;
        private MaterialSkin.Controls.MaterialButton btnSend1000x;
    }
}

