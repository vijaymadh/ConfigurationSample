namespace ConfigurationValidation.Adobe
{
    partial class SendEsignDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendEsignDocument));
            this.btnSendDocument = new System.Windows.Forms.Button();
            this.Document = new System.Windows.Forms.OpenFileDialog();
            this.txtevelope = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWebHookId = new System.Windows.Forms.TextBox();
            this.lblPSUrl = new System.Windows.Forms.Label();
            this.txtPSUrl = new System.Windows.Forms.TextBox();
            this.chkConsole = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConsoleUrl = new System.Windows.Forms.TextBox();
            this.chkSealEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSendDocument
            // 
            this.btnSendDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendDocument.Location = new System.Drawing.Point(16, 15);
            this.btnSendDocument.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendDocument.Name = "btnSendDocument";
            this.btnSendDocument.Size = new System.Drawing.Size(285, 53);
            this.btnSendDocument.TabIndex = 0;
            this.btnSendDocument.Text = "Send Document";
            this.btnSendDocument.UseVisualStyleBackColor = true;
            this.btnSendDocument.Click += new System.EventHandler(this.btnSendDocument_Click);
            // 
            // Document
            // 
            this.Document.FileName = "openFileDialog1";
            // 
            // txtevelope
            // 
            this.txtevelope.Location = new System.Drawing.Point(123, 95);
            this.txtevelope.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtevelope.Name = "txtevelope";
            this.txtevelope.ReadOnly = true;
            this.txtevelope.Size = new System.Drawing.Size(1273, 22);
            this.txtevelope.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Envelope Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Web Hook ID";
            // 
            // txtWebHookId
            // 
            this.txtWebHookId.Location = new System.Drawing.Point(123, 137);
            this.txtWebHookId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWebHookId.Name = "txtWebHookId";
            this.txtWebHookId.ReadOnly = true;
            this.txtWebHookId.Size = new System.Drawing.Size(1273, 22);
            this.txtWebHookId.TabIndex = 3;
            // 
            // lblPSUrl
            // 
            this.lblPSUrl.AutoSize = true;
            this.lblPSUrl.Location = new System.Drawing.Point(24, 169);
            this.lblPSUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPSUrl.Name = "lblPSUrl";
            this.lblPSUrl.Size = new System.Drawing.Size(48, 17);
            this.lblPSUrl.TabIndex = 6;
            this.lblPSUrl.Text = "PS Url";
            // 
            // txtPSUrl
            // 
            this.txtPSUrl.Location = new System.Drawing.Point(123, 169);
            this.txtPSUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPSUrl.Name = "txtPSUrl";
            this.txtPSUrl.ReadOnly = true;
            this.txtPSUrl.Size = new System.Drawing.Size(1273, 22);
            this.txtPSUrl.TabIndex = 5;
            // 
            // chkConsole
            // 
            this.chkConsole.AutoSize = true;
            this.chkConsole.Location = new System.Drawing.Point(348, 35);
            this.chkConsole.Name = "chkConsole";
            this.chkConsole.Size = new System.Drawing.Size(81, 21);
            this.chkConsole.TabIndex = 7;
            this.chkConsole.Text = "Console";
            this.chkConsole.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Console Url";
            // 
            // txtConsoleUrl
            // 
            this.txtConsoleUrl.Location = new System.Drawing.Point(123, 209);
            this.txtConsoleUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsoleUrl.Name = "txtConsoleUrl";
            this.txtConsoleUrl.ReadOnly = true;
            this.txtConsoleUrl.Size = new System.Drawing.Size(1273, 22);
            this.txtConsoleUrl.TabIndex = 8;
            // 
            // chkSealEnabled
            // 
            this.chkSealEnabled.AutoSize = true;
            this.chkSealEnabled.Location = new System.Drawing.Point(463, 35);
            this.chkSealEnabled.Name = "chkSealEnabled";
            this.chkSealEnabled.Size = new System.Drawing.Size(58, 21);
            this.chkSealEnabled.TabIndex = 10;
            this.chkSealEnabled.Text = "Seal";
            this.chkSealEnabled.UseVisualStyleBackColor = true;
            // 
            // SendEsignDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 271);
            this.Controls.Add(this.chkSealEnabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConsoleUrl);
            this.Controls.Add(this.chkConsole);
            this.Controls.Add(this.lblPSUrl);
            this.Controls.Add(this.txtPSUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWebHookId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtevelope);
            this.Controls.Add(this.btnSendDocument);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SendEsignDocument";
            this.Text = "SendEsignDocument";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendDocument;
        private System.Windows.Forms.OpenFileDialog Document;
        private System.Windows.Forms.TextBox txtevelope;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWebHookId;
        private System.Windows.Forms.Label lblPSUrl;
        private System.Windows.Forms.TextBox txtPSUrl;
        private System.Windows.Forms.CheckBox chkConsole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConsoleUrl;
        private System.Windows.Forms.CheckBox chkSealEnabled;
    }
}