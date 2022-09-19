namespace ConfigurationValidation.Adobe.CSV
{
    partial class GetAllAgreementInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetAllAgreementInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAKVClientID = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtEchoSignClientSecret = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEchoSignClientId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAKVClientSecret = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAKVVaultUri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFaileEnvelope = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AKV Client ID";
            // 
            // txtAKVClientID
            // 
            this.txtAKVClientID.Location = new System.Drawing.Point(128, 12);
            this.txtAKVClientID.Name = "txtAKVClientID";
            this.txtAKVClientID.Size = new System.Drawing.Size(582, 20);
            this.txtAKVClientID.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(635, 152);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtEchoSignClientSecret
            // 
            this.txtEchoSignClientSecret.Location = new System.Drawing.Point(128, 126);
            this.txtEchoSignClientSecret.Name = "txtEchoSignClientSecret";
            this.txtEchoSignClientSecret.Size = new System.Drawing.Size(582, 20);
            this.txtEchoSignClientSecret.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "EchoSign Client Secret";
            // 
            // txtEchoSignClientId
            // 
            this.txtEchoSignClientId.Location = new System.Drawing.Point(128, 100);
            this.txtEchoSignClientId.Name = "txtEchoSignClientId";
            this.txtEchoSignClientId.Size = new System.Drawing.Size(582, 20);
            this.txtEchoSignClientId.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "EchoSign Client ID";
            // 
            // txtAKVClientSecret
            // 
            this.txtAKVClientSecret.Location = new System.Drawing.Point(128, 41);
            this.txtAKVClientSecret.Name = "txtAKVClientSecret";
            this.txtAKVClientSecret.Size = new System.Drawing.Size(582, 20);
            this.txtAKVClientSecret.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "AKV Client Secret";
            // 
            // txtAKVVaultUri
            // 
            this.txtAKVVaultUri.Location = new System.Drawing.Point(128, 67);
            this.txtAKVVaultUri.Name = "txtAKVVaultUri";
            this.txtAKVVaultUri.Size = new System.Drawing.Size(582, 20);
            this.txtAKVVaultUri.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "AKV Vault Uri";
            // 
            // txtFaileEnvelope
            // 
            this.txtFaileEnvelope.Location = new System.Drawing.Point(12, 192);
            this.txtFaileEnvelope.Multiline = true;
            this.txtFaileEnvelope.Name = "txtFaileEnvelope";
            this.txtFaileEnvelope.Size = new System.Drawing.Size(714, 278);
            this.txtFaileEnvelope.TabIndex = 17;
            // 
            // GetAllAgreementInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 506);
            this.Controls.Add(this.txtFaileEnvelope);
            this.Controls.Add(this.txtAKVVaultUri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAKVClientSecret);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEchoSignClientId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEchoSignClientSecret);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtAKVClientID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetAllAgreementInfo";
            this.Text = "Check Esign Envelope Status";
            this.Load += new System.EventHandler(this.CheckEsignEnvelope_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAKVClientID;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtEchoSignClientSecret;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEchoSignClientId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAKVClientSecret;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAKVVaultUri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFaileEnvelope;
    }
}