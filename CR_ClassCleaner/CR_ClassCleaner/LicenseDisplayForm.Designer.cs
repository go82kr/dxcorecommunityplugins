﻿namespace CR_ClassCleaner
{
    partial class LicenseDisplayForm
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
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLicense
            // 
            this.txtLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLicense.Location = new System.Drawing.Point(0, 0);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLicense.Size = new System.Drawing.Size(436, 266);
            this.txtLicense.TabIndex = 0;
            // 
            // LicenseDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 266);
            this.Controls.Add(this.txtLicense);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseDisplayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CR_ClassCleaner License";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LicenseDisplayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLicense;
    }
}