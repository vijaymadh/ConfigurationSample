namespace ConfigurationValidation.AsposePDF
{
    partial class TextReplacement
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
            this.btnSource = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.OpenFileDialog();
            this.btnTarget = new System.Windows.Forms.Button();
            this.lblSourcer = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.target = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSource
            // 
            this.btnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.Location = new System.Drawing.Point(12, 12);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(172, 36);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "Select Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // Source
            // 
            this.Source.FileName = "SoruceDoc";
            // 
            // btnTarget
            // 
            this.btnTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarget.Location = new System.Drawing.Point(12, 71);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(172, 36);
            this.btnTarget.TabIndex = 2;
            this.btnTarget.Text = "Select Target";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // lblSourcer
            // 
            this.lblSourcer.AutoSize = true;
            this.lblSourcer.Location = new System.Drawing.Point(201, 20);
            this.lblSourcer.Name = "lblSourcer";
            this.lblSourcer.Size = new System.Drawing.Size(0, 13);
            this.lblSourcer.TabIndex = 3;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(201, 84);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(0, 13);
            this.lblTarget.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(796, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(190, 13);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(778, 20);
            this.txtSource.TabIndex = 6;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(190, 71);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(778, 20);
            this.txtTarget.TabIndex = 7;
            // 
            // target
            // 
            this.target.FileName = "SargetDoc";
            // 
            // TextReplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 158);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblSourcer);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.btnSource);
            this.Name = "TextReplacement";
            this.Text = "TextReplacement";
            this.Load += new System.EventHandler(this.TextReplacement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.OpenFileDialog Source;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Label lblSourcer;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.OpenFileDialog target;
    }
}