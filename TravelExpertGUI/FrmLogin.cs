using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using TravelExpertData;
using TravelExpertGUI;
using TravelExperts;



namespace TravelExpertGUI
{
    public partial class FrmLogin : Form
    {
        public TravelExpertsV2Context context = new TravelExpertsV2Context();

        public static DataTable executeSQL(string sql)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                connection.ConnectionString = TravelExpertsV2Context.stringConnection;
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);
                connection.Close();
                connection = null;
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message,
                    "SQL server connection failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }

            return dt;

        }


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(agentEmailAddressLogin.Text) && !string.IsNullOrEmpty(agentPasswordLogin.Text))
            {
                string mySQL = string.Empty;

                mySQL += "SELECT * FROM Agent ";
                mySQL += "WHERE AgtEmail = '" + agentEmailAddressLogin.Text + "' ";
                mySQL += "AND AgentPassword = '" + agentPasswordLogin.Text + "'";

                DataTable userData = executeSQL(mySQL);

                if(userData.Rows.Count > 0)
                {
                    // ADD SHADOW BACKGROUND
                    Form shadow = new Form();
                    shadow.MinimizeBox = false;
                    shadow.MaximizeBox = false;
                    shadow.ControlBox = false;

                    shadow.Text = "";
                    shadow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    shadow.BackColor = Color.Black;
                    shadow.Opacity = 0.3;
                    shadow.StartPosition = FormStartPosition.CenterParent;

                    shadow.Show();
                    shadow.Enabled = false;

                    shadow.Size = ClientSize;
                    shadow.Location = PointToScreen(Point.Empty);
                    // END SHADOW BACKGROUND

                    string errorMessage = "Authentication successful.";
                    FrmErrorMessageBox errors = new FrmErrorMessageBox(errorMessage);

                    // ENSURE SHADOW IS REMOVED
                    Button btn = new Button() { Text = "OK" };
                    btn.Click += (ss, ee) => { errors.Close(); };
                    errors.Controls.Add(btn);
                    errors.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };
                    errors.ShowDialog();

                    agentEmailAddressLogin.Clear();
                    agentPasswordLogin.Clear();

                    this.Hide();

                    FrmMainMenu formMain = new FrmMainMenu();
                    formMain.ShowDialog();
                    formMain = null;
                    agentEmailAddressLogin.Select();
                } else
                {
                    // ADD SHADOW BACKGROUND
                    Form shadow = new Form();
                    shadow.MinimizeBox = false;
                    shadow.MaximizeBox = false;
                    shadow.ControlBox = false;

                    shadow.Text = "";
                    shadow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    shadow.BackColor = Color.Black;
                    shadow.Opacity = 0.3;
                    shadow.StartPosition = FormStartPosition.CenterParent;

                    shadow.Show();
                    shadow.Enabled = false;

                    shadow.Size = ClientSize;
                    shadow.Location = PointToScreen(Point.Empty);
                    // END SHADOW BACKGROUND

                    string errorMessage = "The email address and password you entered is incorrect.";
                    FrmErrorMessageBox errors = new FrmErrorMessageBox(errorMessage);

                    // ENSURE SHADOW IS REMOVED
                    Button btn = new Button() { Text = "OK" };
                    btn.Click += (ss, ee) => { errors.Close(); };
                    errors.Controls.Add(btn);
                    errors.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

                    errors.ShowDialog();
                    agentEmailAddressLogin.Focus();
                    agentEmailAddressLogin.SelectAll();
                }

            } else if (string.IsNullOrEmpty(agentEmailAddressLogin.Text))
            {
                // ADD SHADOW BACKGROUND
                Form shadow = new Form();
                shadow.MinimizeBox = false;
                shadow.MaximizeBox = false;
                shadow.ControlBox = false;

                shadow.Text = "";
                shadow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                shadow.BackColor = Color.Black;
                shadow.Opacity = 0.3;
                shadow.StartPosition = FormStartPosition.CenterParent;

                shadow.Show();
                shadow.Enabled = false;

                shadow.Size = ClientSize;
                shadow.Location = PointToScreen(Point.Empty);
                // END SHADOW BACKGROUND

                string errorMessage = "You must enter an email address to login.";
                FrmErrorMessageBox errors = new FrmErrorMessageBox(errorMessage);

                // ENSURE SHADOW IS REMOVED
                Button btn = new Button() { Text = "OK" };
                btn.Click += (ss, ee) => { errors.Close(); };
                errors.Controls.Add(btn);
                errors.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };
                errors.ShowDialog();

                agentEmailAddressLogin.Focus();
                agentEmailAddressLogin.SelectAll();
            }
            else if (string.IsNullOrEmpty(agentPasswordLogin.Text))
            {
                // ADD SHADOW BACKGROUND
                Form shadow = new Form();
                shadow.MinimizeBox = false;
                shadow.MaximizeBox = false;
                shadow.ControlBox = false;

                shadow.Text = "";
                shadow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                shadow.BackColor = Color.Black;
                shadow.Opacity = 0.3;
                shadow.StartPosition = FormStartPosition.CenterParent;

                shadow.Show();
                shadow.Enabled = false;

                shadow.Size = ClientSize;
                shadow.Location = PointToScreen(Point.Empty);
                // END SHADOW BACKGROUND

                string errorMessage = "You must insert a password to login.";
                FrmErrorMessageBox errors = new FrmErrorMessageBox(errorMessage);

                // ENSURE SHADOW IS REMOVED
                Button btn = new Button() { Text = "OK" };
                btn.Click += (ss, ee) => { errors.Close(); };
                errors.Controls.Add(btn);
                errors.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };
                errors.ShowDialog();

                agentPasswordLogin.Focus();
                agentPasswordLogin.SelectAll();
            }


        }

        private void agentEmailAddressLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
