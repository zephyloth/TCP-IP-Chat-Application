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
            this.tbInfo = new System.Windows.Forms.RichTextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.imglistIcon = new System.Windows.Forms.ImageList(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.Location = new System.Drawing.Point(75, 12);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(192, 174);
            this.tbInfo.TabIndex = 1;
            this.tbInfo.Text = "";
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbSend.Location = new System.Drawing.Point(12, 192);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(255, 22);
            this.tbSend.TabIndex = 2;
            // 
            // imglistIcon
            // 
            this.imglistIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistIcon.ImageStream")));
            this.imglistIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistIcon.Images.SetKeyName(0, "TestIcon.png");
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(12, 220);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(255, 32);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "button1";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(12, 12);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(57, 173);
            this.lbUsers.TabIndex = 4;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbInfo);
            this.Name = "frmClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox tbInfo;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.ImageList imglistIcon;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lbUsers;
    }
}

