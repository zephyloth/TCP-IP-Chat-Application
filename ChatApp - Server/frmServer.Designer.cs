namespace ChatApp___Server
{
    partial class frmServer
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
            this.tbInfo = new System.Windows.Forms.RichTextBox();
            this.cbEncryption = new System.Windows.Forms.ComboBox();
            this.lblEncryption = new System.Windows.Forms.Label();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbInfo.Location = new System.Drawing.Point(122, 6);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(356, 297);
            this.tbInfo.TabIndex = 2;
            this.tbInfo.Text = "";
            // 
            // cbEncryption
            // 
            this.cbEncryption.FormattingEnabled = true;
            this.cbEncryption.Items.AddRange(new object[] {
            "BlowFish (Default)",
            "AES (128)",
            "AES (256)"});
            this.cbEncryption.Location = new System.Drawing.Point(4, 43);
            this.cbEncryption.Name = "cbEncryption";
            this.cbEncryption.Size = new System.Drawing.Size(97, 21);
            this.cbEncryption.TabIndex = 17;
            this.cbEncryption.SelectedIndexChanged += new System.EventHandler(this.cbEncryption_SelectedIndexChanged);
            // 
            // lblEncryption
            // 
            this.lblEncryption.AutoSize = true;
            this.lblEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEncryption.Location = new System.Drawing.Point(4, 27);
            this.lblEncryption.Name = "lblEncryption";
            this.lblEncryption.Size = new System.Drawing.Size(96, 13);
            this.lblEncryption.TabIndex = 18;
            this.lblEncryption.Text = "Encryption Method";
            // 
            // gbProperties
            // 
            this.gbProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbProperties.Controls.Add(this.lblEncryption);
            this.gbProperties.Controls.Add(this.cbEncryption);
            this.gbProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbProperties.Location = new System.Drawing.Point(8, 1);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(108, 302);
            this.gbProperties.TabIndex = 20;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Properties";
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.gbProperties);
            this.Controls.Add(this.tbInfo);
            this.Name = "frmServer";
            this.ShowIcon = false;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.gbProperties.ResumeLayout(false);
            this.gbProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox tbInfo;
        private System.Windows.Forms.ComboBox cbEncryption;
        private System.Windows.Forms.Label lblEncryption;
        private System.Windows.Forms.GroupBox gbProperties;
    }
}

