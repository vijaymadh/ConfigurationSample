namespace Utility
{
    partial class SimpleTest
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
            this.ABCCounter = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ABCCounter
            // 
            this.ABCCounter.Location = new System.Drawing.Point(72, 46);
            this.ABCCounter.Name = "ABCCounter";
            this.ABCCounter.Size = new System.Drawing.Size(75, 23);
            this.ABCCounter.TabIndex = 0;
            this.ABCCounter.Text = "ABCCounter";
            this.ABCCounter.UseVisualStyleBackColor = true;
            this.ABCCounter.Click += new System.EventHandler(this.ABCCounter_Click);
            // 
            // lblData
            // 
            this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblData.Location = new System.Drawing.Point(253, 51);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(338, 376);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "label1";
            // 
            // SimpleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.ABCCounter);
            this.Name = "SimpleTest";
            this.Text = "SimpleTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ABCCounter;
        private System.Windows.Forms.Label lblData;
    }
}