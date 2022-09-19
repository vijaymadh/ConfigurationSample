namespace ConfigurationValidation.Adobe
{
    partial class EchoSignOauthGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtAccessUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCallBackUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOAuthCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSampleUrl = new System.Windows.Forms.TextBox();
            this.txtRefreshToken = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chkWebHook = new System.Windows.Forms.CheckBox();
            this.txtAccountUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ClientId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Secret";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(133, 113);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(628, 23);
            this.txtClientID.TabIndex = 2;
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(133, 149);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.Size = new System.Drawing.Size(628, 23);
            this.txtSecret.TabIndex = 3;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(628, 427);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(87, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(10, 427);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(153, 25);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Refresh Toekn";
            // 
            // txtAccessUrl
            // 
            this.txtAccessUrl.Location = new System.Drawing.Point(133, 76);
            this.txtAccessUrl.Name = "txtAccessUrl";
            this.txtAccessUrl.Size = new System.Drawing.Size(628, 23);
            this.txtAccessUrl.TabIndex = 7;
            this.txtAccessUrl.Text = "https://api.na3.adobesign.com/";
            this.txtAccessUrl.TextChanged += new System.EventHandler(this.txtAPIUrl_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "API Access Point";
            // 
            // txtCallBackUrl
            // 
            this.txtCallBackUrl.Location = new System.Drawing.Point(133, 188);
            this.txtCallBackUrl.Name = "txtCallBackUrl";
            this.txtCallBackUrl.Size = new System.Drawing.Size(628, 23);
            this.txtCallBackUrl.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Callback Url";
            // 
            // txtOAuthCode
            // 
            this.txtOAuthCode.Location = new System.Drawing.Point(133, 221);
            this.txtOAuthCode.Name = "txtOAuthCode";
            this.txtOAuthCode.Size = new System.Drawing.Size(628, 23);
            this.txtOAuthCode.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "OAuthCode";
            // 
            // txtSampleUrl
            // 
            this.txtSampleUrl.Location = new System.Drawing.Point(14, 315);
            this.txtSampleUrl.Multiline = true;
            this.txtSampleUrl.Name = "txtSampleUrl";
            this.txtSampleUrl.ReadOnly = true;
            this.txtSampleUrl.Size = new System.Drawing.Size(707, 107);
            this.txtSampleUrl.TabIndex = 13;
            // 
            // txtRefreshToken
            // 
            this.txtRefreshToken.Location = new System.Drawing.Point(8, 454);
            this.txtRefreshToken.Multiline = true;
            this.txtRefreshToken.Name = "txtRefreshToken";
            this.txtRefreshToken.ReadOnly = true;
            this.txtRefreshToken.Size = new System.Drawing.Size(707, 107);
            this.txtRefreshToken.TabIndex = 14;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(632, 292);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(18, 13);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(92, 17);
            this.lblVersion.TabIndex = 16;
            this.lblVersion.Text = "Account Url";
            // 
            // chkWebHook
            // 
            this.chkWebHook.AutoSize = true;
            this.chkWebHook.Location = new System.Drawing.Point(14, 292);
            this.chkWebHook.Name = "chkWebHook";
            this.chkWebHook.Size = new System.Drawing.Size(104, 21);
            this.chkWebHook.TabIndex = 18;
            this.chkWebHook.Text = "Web Hook";
            this.chkWebHook.UseVisualStyleBackColor = true;
            // 
            // txtAccountUrl
            // 
            this.txtAccountUrl.Location = new System.Drawing.Point(133, 16);
            this.txtAccountUrl.Name = "txtAccountUrl";
            this.txtAccountUrl.Size = new System.Drawing.Size(628, 23);
            this.txtAccountUrl.TabIndex = 19;
            this.txtAccountUrl.Text = "https://secure.na3.adobesign.com";
            // 
            // EchoSignOauthGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 655);
            this.Controls.Add(this.txtAccountUrl);
            this.Controls.Add(this.chkWebHook);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtRefreshToken);
            this.Controls.Add(this.txtSampleUrl);
            this.Controls.Add(this.txtOAuthCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCallBackUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccessUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtSecret);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EchoSignOauthGenerator";
            this.Text = "Echo SignOauth Generator";
            this.Load += new System.EventHandler(this.EchoSignOauthGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtAccessUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCallBackUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOAuthCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSampleUrl;
        private System.Windows.Forms.TextBox txtRefreshToken;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chkWebHook;
        private System.Windows.Forms.TextBox txtAccountUrl;
    }
}