namespace ConfigurationValidation.Adobe
{
    partial class TestAKV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestAKV));
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtKeyVaultAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRefreshCode = new System.Windows.Forms.TextBox();
            this.RefreshCode = new System.Windows.Forms.Label();
            this.txtAccessAPI = new System.Windows.Forms.TextBox();
            this.AccessAPI = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.TextBox();
            this.AKVList = new System.Windows.Forms.Button();
            this.dgSecrets = new System.Windows.Forms.DataGridView();
            this.SecretName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecretValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSecrets)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client ID/App Id";
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(135, 38);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(931, 22);
            this.txtClientId.TabIndex = 1;
            this.txtClientId.Text = "1fb36fdf-208a-4b53-ab5e-7d4cac05faa2";
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(135, 84);
            this.txtSecret.Margin = new System.Windows.Forms.Padding(4);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.Size = new System.Drawing.Size(931, 22);
            this.txtSecret.TabIndex = 3;
            this.txtSecret.Text = "O7jqRrrVAABUaplu8T2IdTSKHCuDHAq9NV3xTiQ7IAQ=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Secret";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(937, 162);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(127, 28);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtKeyVaultAddress
            // 
            this.txtKeyVaultAddress.Location = new System.Drawing.Point(135, 130);
            this.txtKeyVaultAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtKeyVaultAddress.Name = "txtKeyVaultAddress";
            this.txtKeyVaultAddress.Size = new System.Drawing.Size(931, 22);
            this.txtKeyVaultAddress.TabIndex = 7;
            this.txtKeyVaultAddress.Text = "https://iflirp1seckv.vault.usgovcloudapi.net/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vault Add";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(799, 162);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Get Auth Refresh Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRefreshCode
            // 
            this.txtRefreshCode.Location = new System.Drawing.Point(153, 249);
            this.txtRefreshCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefreshCode.Name = "txtRefreshCode";
            this.txtRefreshCode.Size = new System.Drawing.Size(709, 22);
            this.txtRefreshCode.TabIndex = 10;
            // 
            // RefreshCode
            // 
            this.RefreshCode.AutoSize = true;
            this.RefreshCode.Location = new System.Drawing.Point(34, 253);
            this.RefreshCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefreshCode.Name = "RefreshCode";
            this.RefreshCode.Size = new System.Drawing.Size(95, 17);
            this.RefreshCode.TabIndex = 9;
            this.RefreshCode.Text = "Refresh Code";
            // 
            // txtAccessAPI
            // 
            this.txtAccessAPI.Location = new System.Drawing.Point(153, 294);
            this.txtAccessAPI.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccessAPI.Name = "txtAccessAPI";
            this.txtAccessAPI.Size = new System.Drawing.Size(709, 22);
            this.txtAccessAPI.TabIndex = 12;
            // 
            // AccessAPI
            // 
            this.AccessAPI.AutoSize = true;
            this.AccessAPI.Location = new System.Drawing.Point(34, 298);
            this.AccessAPI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AccessAPI.Name = "AccessAPI";
            this.AccessAPI.Size = new System.Drawing.Size(78, 17);
            this.AccessAPI.TabIndex = 11;
            this.AccessAPI.Text = "Access API";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(901, 287);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 28);
            this.button2.TabIndex = 13;
            this.button2.Text = "Update Auth Refresh Code";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(19, 207);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4);
            this.lblResult.Name = "lblResult";
            this.lblResult.ReadOnly = true;
            this.lblResult.Size = new System.Drawing.Size(1027, 22);
            this.lblResult.TabIndex = 14;
            // 
            // AKVList
            // 
            this.AKVList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AKVList.Location = new System.Drawing.Point(50, 324);
            this.AKVList.Margin = new System.Windows.Forms.Padding(4);
            this.AKVList.Name = "AKVList";
            this.AKVList.Size = new System.Drawing.Size(189, 28);
            this.AKVList.TabIndex = 15;
            this.AKVList.Text = "Load All Secrets";
            this.AKVList.UseVisualStyleBackColor = true;
            this.AKVList.Click += new System.EventHandler(this.AKVList_Click);
            // 
            // dgSecrets
            // 
            this.dgSecrets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgSecrets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgSecrets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSecrets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSecrets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSecrets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SecretName,
            this.SecretValue});
            this.dgSecrets.Location = new System.Drawing.Point(261, 323);
            this.dgSecrets.Name = "dgSecrets";
            this.dgSecrets.RowTemplate.Height = 24;
            this.dgSecrets.Size = new System.Drawing.Size(834, 289);
            this.dgSecrets.TabIndex = 16;
            // 
            // SecretName
            // 
            this.SecretName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SecretName.HeaderText = "Secret Name";
            this.SecretName.Name = "SecretName";
            this.SecretName.Width = 135;
            // 
            // SecretValue
            // 
            this.SecretValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SecretValue.HeaderText = "Secret Value";
            this.SecretValue.Name = "SecretValue";
            this.SecretValue.Width = 132;
            // 
            // TestAKV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1762, 840);
            this.Controls.Add(this.dgSecrets);
            this.Controls.Add(this.AKVList);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtAccessAPI);
            this.Controls.Add(this.AccessAPI);
            this.Controls.Add(this.txtRefreshCode);
            this.Controls.Add(this.RefreshCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtKeyVaultAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtSecret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestAKV";
            this.Text = "Test AKV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestAKV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSecrets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtKeyVaultAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRefreshCode;
        private System.Windows.Forms.Label RefreshCode;
        private System.Windows.Forms.TextBox txtAccessAPI;
        private System.Windows.Forms.Label AccessAPI;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox lblResult;
        private System.Windows.Forms.Button AKVList;
        private System.Windows.Forms.DataGridView dgSecrets;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecretName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecretValue;
    }
}

