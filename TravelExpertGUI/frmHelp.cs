using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TravelExpertGUI
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookingsHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = true;
            packagesHelpPanel.Visible = false;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = false;
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = false;
        }

        private void packagesHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = false;
            packagesHelpPanel.Visible = true;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = false;
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = false;
        }

        private void productsHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = false;
            packagesHelpPanel.Visible = false;
            productsHelpPanel.Visible = true;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = false;
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = false;
        }

        private void suppliersHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = false;
            packagesHelpPanel.Visible = false;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = true;
            customersHelpPanel.Visible = false;
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = false;
        }

        private void customerHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = false;
            packagesHelpPanel.Visible = false;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = true;
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = false;
        }

        private void agentHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = false;
            packagesHelpPanel.Visible = false;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = false;
            agentHelpPanel.Visible = true;
            agencyHelpPanel.Visible = false;
        }

        private void agencyHelpMenu_Click(object sender, EventArgs e)
        {
            bookingsHelpPanel.Visible = false;
            packagesHelpPanel.Visible = false;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = false;
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = true;
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            agentHelpPanel.Visible = false;
            agencyHelpPanel.Visible = true;
            productsHelpPanel.Visible = false;
            suppliersHelpPanel.Visible = false;
            customersHelpPanel.Visible = false;
            packagesHelpPanel.Visible = false;
            bookingsHelpPanel.Visible = false;

        }
    }
}
