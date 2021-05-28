
namespace TravelExpertGUI
{
    partial class FrmErrorMessageBox
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
            this.detailedErrorMessage = new System.Windows.Forms.TextBox();
            this.errorMessagePanel = new System.Windows.Forms.Panel();
            this.messageHeading = new System.Windows.Forms.Label();
            this.messageBoxIcon = new FontAwesome.Sharp.IconPictureBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.errorMessagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // detailedErrorMessage
            // 
            this.detailedErrorMessage.BackColor = System.Drawing.Color.White;
            this.detailedErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailedErrorMessage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.detailedErrorMessage.ForeColor = System.Drawing.Color.Black;
            this.detailedErrorMessage.Location = new System.Drawing.Point(19, 96);
            this.detailedErrorMessage.Multiline = true;
            this.detailedErrorMessage.Name = "detailedErrorMessage";
            this.detailedErrorMessage.ReadOnly = true;
            this.detailedErrorMessage.Size = new System.Drawing.Size(320, 74);
            this.detailedErrorMessage.TabIndex = 99999;
            this.detailedErrorMessage.Text = "You must enter an email address and password to login.";
            // 
            // errorMessagePanel
            // 
            this.errorMessagePanel.BackColor = System.Drawing.Color.Firebrick;
            this.errorMessagePanel.Controls.Add(this.messageHeading);
            this.errorMessagePanel.Controls.Add(this.messageBoxIcon);
            this.errorMessagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.errorMessagePanel.Location = new System.Drawing.Point(0, 0);
            this.errorMessagePanel.Name = "errorMessagePanel";
            this.errorMessagePanel.Size = new System.Drawing.Size(351, 77);
            this.errorMessagePanel.TabIndex = 1;
            // 
            // messageHeading
            // 
            this.messageHeading.AutoSize = true;
            this.messageHeading.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageHeading.ForeColor = System.Drawing.Color.White;
            this.messageHeading.Location = new System.Drawing.Point(180, 19);
            this.messageHeading.Name = "messageHeading";
            this.messageHeading.Size = new System.Drawing.Size(159, 47);
            this.messageHeading.TabIndex = 1;
            this.messageHeading.Text = "Try again";
            // 
            // messageBoxIcon
            // 
            this.messageBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.messageBoxIcon.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
            this.messageBoxIcon.IconColor = System.Drawing.Color.White;
            this.messageBoxIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.messageBoxIcon.IconSize = 80;
            this.messageBoxIcon.Location = new System.Drawing.Point(0, 5);
            this.messageBoxIcon.Name = "messageBoxIcon";
            this.messageBoxIcon.Size = new System.Drawing.Size(80, 100);
            this.messageBoxIcon.TabIndex = 0;
            this.messageBoxIcon.TabStop = false;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(220, 190);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(125, 43);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Ok";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // FrmErrorMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 241);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.errorMessagePanel);
            this.Controls.Add(this.detailedErrorMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmErrorMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "loginFormMessageBox";
            this.Load += new System.EventHandler(this.loginFormMessageBox_Load);
            this.errorMessagePanel.ResumeLayout(false);
            this.errorMessagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel errorMessagePanel;
        private System.Windows.Forms.Label messageHeading;
        private FontAwesome.Sharp.IconPictureBox messageBoxIcon;
        public System.Windows.Forms.TextBox detailedErrorMessage;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}