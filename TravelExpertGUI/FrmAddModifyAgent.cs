using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using TravelExpertData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TravelExpertsGUI
{
    public partial class FrmAddModifyAgent : Form
    {
        private TravelExpertsV2Context context = new TravelExpertsV2Context();
        public Agent agent;
        public Agency agency;
        public List<Agency> agencyList;
        public bool isAdd;
        public int nagent;

        public FrmAddModifyAgent()
        {
            InitializeComponent();
        }

        private void LoadList()
        {
            try
            {
                agencyList = context.Agency.OrderBy(a => a.AgencyId).ToList();

            }
            catch(DbUpdateException ex)
            {
                HandleDataError(ex);
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        private void HandleError(Exception ex)//General Error
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
        private void HandleDataError(DbUpdateException ex)//Method that be called when connecting with the database
                                                          //and generate errors
        {
            var sqlException = (SqlException)ex.InnerException;
            string message = "";
            foreach (SqlError error in sqlException.Errors)
            {
                message += "Error Code: " + error.Number + error.Message + "\n";

            }
            MessageBox.Show(message, "Data Error");
        }

        private void LoadCumboBox()
        {
            try
            {
                LoadList();
                cmbAgent.DataSource = this.agencyList;
                cmbAgent.DisplayMember = "AgencyId";
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }
        private void FrmAddModifyAgent_Load(object sender, EventArgs e)
        {
            LoadCumboBox();
            if (isAdd)
            {
                txtAgentID.Visible = false;
                lblAdd.Visible = true;
                lblModify.Visible = false;
                txtFirstName.Focus();
                this.Text = "Add Agent";
            }
            else
            {
                this.Text = "Modify Agent";
                lblAdd.Visible = false;
                lblModify.Visible = true;
                txtAgentID.Enabled = false;
                txtAgentID.Text = agent.AgentId.ToString();
                txtFirstName.Text = agent.AgtFirstName.ToString();
                txtLastName.Text = agent.AgtLastName.ToString();
                txtPhoneNumber.Text = agent.AgtBusPhone.ToString();
                txtEmail.Text = agent.AgtEmail.ToString();
                txtPosition.Text = agent.AgtPosition.ToString();
                txtPassword.Text = agent.AgentPassword.ToString();
                cmbAgent.Text = agent.AgencyId.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this operation", "Cancel Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (confirm == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {   if (TravelExpertGUI.Validator.IsEmpty(txtFirstName, "First Name")&&
                TravelExpertGUI.Validator.IsNvarchar(txtFirstName, "First Name") &&
                TravelExpertGUI.Validator.IsEmpty(txtPassword, "Password") &&
                TravelExpertGUI.Validator.IsEmpty(txtLastName, "Last Name")&&
                TravelExpertGUI.Validator.IsNvarchar(txtLastName, "Last Name") &&
                TravelExpertGUI.Validator.checkPhoneNumberFormat(txtPhoneNumber, "Phone Number")&&
                TravelExpertGUI.Validator.IsEmpty(txtEmail, "Email")&&
                TravelExpertGUI.Validator.IsValidEmail(txtEmail, "Email") &&
                TravelExpertGUI.Validator.IsEmpty(txtPosition, "Agent Position") &&
                TravelExpertGUI.Validator.IsNvarchar(txtFirstName, "First Name") )

            if (isAdd)
            {         
                    agent = new Agent();
                    agent.AgtFirstName = txtFirstName.Text.ToString();
                    agent.AgtLastName = txtLastName.Text.ToString();
                    agent.AgtBusPhone = txtPhoneNumber.Text.ToString();
                    agent.AgtEmail = txtEmail.Text.ToString();
                    agent.AgtPosition = txtPosition.Text.ToString();
                    agent.AgentPassword = txtPassword.Text;
                    agent.AgencyId = Convert.ToInt16(cmbAgent.Text);
                    this.DialogResult = DialogResult.OK;   
            }
            else
            {
                agent.AgtFirstName = txtFirstName.Text.ToString();
                agent.AgtLastName = txtLastName.Text.ToString();
                agent.AgtBusPhone = txtPhoneNumber.Text.ToString();
                agent.AgtEmail = txtEmail.Text.ToString();
                agent.AgtPosition = txtPosition.Text.ToString();
                agent.AgencyId = Convert.ToInt16(cmbAgent.Text);
                agent.AgentPassword = txtPassword.Text;
                this.DialogResult = DialogResult.No;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
