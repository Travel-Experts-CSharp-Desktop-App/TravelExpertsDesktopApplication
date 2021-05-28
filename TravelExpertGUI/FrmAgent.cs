using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using TravelExpertData;
using Microsoft.EntityFrameworkCore;
using TravelExpertsGUI;
using Microsoft.Data.SqlClient;

namespace TravelExpertGUI
{
    public partial class FrmAgent : Form
    {
        private TravelExpertsV2Context context = new TravelExpertsV2Context();
        private Agent selectedAgent;
        List<Agent> AgentsList;
        private bool isAdd;

        public FrmAgent()
        {
            InitializeComponent();
        }
        private void ConfigureDataGrid()
        {
            dAgents.Columns.Clear();
            var agent = context.Agent
                .OrderBy(a => a.AgentId)
                .Select(a => new { a.AgentId, a.AgtFirstName, a.AgtLastName, a.AgtBusPhone, a.AgtEmail, a.AgtPosition, a.AgencyId})
                .ToList();
            dAgents.DataSource = agent;//Fill the data grid with data

            // ####################
            // ####################
            // ##### COLUMN  ######
            // ##### BUTTONS ######
            // ####################
            // ####################

            // 1) DELETE BUTTON COLUMN
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "X"
            };
            dAgents.Columns.Insert(0, deleteColumn);

            // 2) MODIFY BUTTON COLUMN
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "✎"
            };
            dAgents.Columns.Insert(1, modifyColumn);

            // ####################
            // ####################
            // ##### COLUMN  ######
            // ##### FORMAT  ######
            // ####################
            // ####################

            // HEADING OF GRID
            dAgents.EnableHeadersVisualStyles = false;
            dAgents.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 12, FontStyle.Bold);
            dAgents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(149, 88, 176);
            dAgents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn c in dAgents.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Dubai", 11);
            }

            dAgents.Columns[0].Width = 30;
            dAgents.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(209, 45, 42);
            dAgents.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dAgents.Columns[0].DefaultCellStyle.Font = new Font("Dubai", 12);
            dAgents.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 45, 42);
            dAgents.Columns[0].DefaultCellStyle.SelectionForeColor = Color.White;


            dAgents.Columns[1].Width = 30;
            dAgents.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(97, 208, 158);
            dAgents.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dAgents.Columns[1].DefaultCellStyle.Font = new Font("Dubai", 12);
            dAgents.Columns[1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(97, 208, 158);
            dAgents.Columns[1].DefaultCellStyle.SelectionForeColor = Color.White;

            //format the first column
            dAgents.Columns[2].HeaderText = "Agent ID";
            dAgents.Columns[2].Width = 150;
            dAgents.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dAgents.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //format the second column
            dAgents.Columns[3].HeaderText = "First Name";
            dAgents.Columns[3].Width = 190;

            //format the third column
            dAgents.Columns[4].HeaderText = "Last Name";
            dAgents.Columns[4].Width = 190;

            //format the third column
            dAgents.Columns[5].HeaderText = "Phone Number";
            dAgents.Columns[5].Width = 200;

            //format the Fourth column
            dAgents.Columns[6].HeaderText = "Email";
            dAgents.Columns[6].Width = 300;

            //format the Fifth column
            dAgents.Columns[7].HeaderText = "Position";
            dAgents.Columns[7].Width = 170;

            //format the Fifth column
            dAgents.Columns[8].HeaderText = "Agency ID";
            dAgents.Columns[8].Width = 150;

        }
      
        private void FrmAgent_Load(object sender, EventArgs e)
        {
            ConfigureDataGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void dAgents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dAgents_CellClick(object sender, DataGridViewCellEventArgs e)
            // e object carries information about the click
            // like e.columnIndex and e.RowIndex
        {
            try
            {
                int AgentID = (int)dAgents.Rows[e.RowIndex].Cells[2].Value;
                selectedAgent = context.Agent.Find(AgentID);
            }
            catch { return; }
            const int DeleteIndex = 0;
            const int ModifyIndex = 1;

            if (e.ColumnIndex == DeleteIndex)
            {
                DeleteAgent();
            }
            else if (e.ColumnIndex == ModifyIndex)
            {
                ModifyAgent();
            }
        }

        private void DeleteAgent()
        {
            DialogResult respond = MessageBox.Show("Do you want to delete " + " " + selectedAgent.AgtFirstName.ToString(), "Delete Conformation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respond == DialogResult.Yes)
            {
                try
                {
                    context.Agent.Remove(selectedAgent);
                    context.SaveChanges();
                    ConfigureDataGrid();
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
        }

        //private void DeleteAgent()
        //{

        //}

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
        private void ModifyAgent()
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

            FrmAddModifyAgent otherForm = new FrmAddModifyAgent();
            otherForm.isAdd = false;
            otherForm.agent = selectedAgent;

            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { otherForm.Close(); };
            otherForm.Controls.Add(btn);
            otherForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };


            DialogResult result = otherForm.ShowDialog();
            if (result == DialogResult.No)
            {
                selectedAgent = otherForm.agent;
                try
                {
                    context.Agent.Update(selectedAgent);
                    context.SaveChanges();
                    ConfigureDataGrid();
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

          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
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

            FrmAddModifyAgent otherForm = new FrmAddModifyAgent();
            otherForm.isAdd = true;
            otherForm.agent = null;

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { otherForm.Close(); };
            otherForm.Controls.Add(btn);
            otherForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };


            DialogResult answer = otherForm.ShowDialog();
            if(answer == DialogResult.OK)
            {
                try
                {
                    selectedAgent = otherForm.agent;
                    context.Agent.Add(selectedAgent);
                    context.SaveChanges();
                    ConfigureDataGrid();
                }
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }

            }
        }
    }
}
