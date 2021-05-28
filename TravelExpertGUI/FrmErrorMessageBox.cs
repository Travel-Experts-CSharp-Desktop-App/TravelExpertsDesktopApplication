using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TravelExpertGUI
{
    public partial class FrmErrorMessageBox : Form
    {

        public FrmErrorMessageBox(string errorMessage)
        {
            InitializeComponent();
            detailedErrorMessage.Text = errorMessage;
            if (detailedErrorMessage.Text == "Authentication successful.")
            {
                detailedErrorMessage.Text = "You have successfully logged in to Travel Experts.";
                errorMessagePanel.BackColor = Color.ForestGreen;
                messageHeading.Text = "Welcome!";
                messageBoxIcon.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            }
        }



        private void loginFormMessageBox_Load(object sender, EventArgs e)
        {
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
