using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration; // for ConfigurationManager
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmAgency : Form
    {
        public frmAgency()
        {
            InitializeComponent();
        }

        private TravelExpertsV2Context context = new TravelExpertsV2Context();
        private Agency selectedAgency; // the current Agency

        public object MesssageBoxIcon { get; private set; }

        private void frmAgency_Load(object sender, EventArgs e)
        {
            DisplayAgency();
        }

        private void DisplayAgency()
        {
            dgvAgency.Columns.Clear();
            var agency = context.Agency
                .OrderBy(a => a.AgencyId)
                .Select(a => new
                {
                    a.AgencyId,
                    a.AgncyAddress,
                    a.AgncyCity,
                    a.AgncyProv, a.AgncyPostal, a.AgncyCountry,
                    a.AgncyPhone, a.AgncyFax
                }).ToList();

            dgvAgency.DataSource = agency;
            //add column for modify button

            //Add delete button to each line using  object initializer
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "X"
            };
            dgvAgency.Columns.Insert(0, deleteColumn);

            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "✎"
            };
            dgvAgency.Columns.Insert(1, modifyColumn);


            // HEADING OF GRID
            dgvAgency.EnableHeadersVisualStyles = false;
            dgvAgency.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 12, FontStyle.Bold);
            dgvAgency.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(172, 126, 241);
            dgvAgency.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn c in dgvAgency.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Dubai", 11);
            }

            dgvAgency.Columns[0].Width = 30;
            dgvAgency.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(209, 45, 42);
            dgvAgency.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dgvAgency.Columns[0].DefaultCellStyle.Font = new Font("Dubai", 12);
            dgvAgency.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 45, 42);
            dgvAgency.Columns[0].DefaultCellStyle.SelectionForeColor = Color.White;

            dgvAgency.Columns[1].Width = 30;
            dgvAgency.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(97, 208, 158);
            dgvAgency.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dgvAgency.Columns[1].DefaultCellStyle.Font = new Font("Dubai", 12);
            dgvAgency.Columns[1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(97, 208, 158);
            dgvAgency.Columns[1].DefaultCellStyle.SelectionForeColor = Color.White;

            // Change column header text
            //format the first column
            dgvAgency.Columns[2].HeaderText = "ID";
            dgvAgency.Columns[2].Width = 50;
            dgvAgency.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAgency.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //format the second column
            dgvAgency.Columns[3].HeaderText = "Address";
            dgvAgency.Columns[3].Width = 300;

            //format the third column
            dgvAgency.Columns[4].HeaderText = "City";
            dgvAgency.Columns[4].Width = 150;

            //format the fourth column
            dgvAgency.Columns[5].HeaderText = "Province";
            dgvAgency.Columns[5].Width = 100;

            //format the fifth column
            dgvAgency.Columns[6].HeaderText = "Postal Code";
            dgvAgency.Columns[6].Width = 140;

            //format the sixth column
            dgvAgency.Columns[7].HeaderText = "Country";
            dgvAgency.Columns[7].Width = 120;

            //format the seventh column
            dgvAgency.Columns[8].HeaderText = "Phone number";
            dgvAgency.Columns[8].Width = 180;

            //format the eighth column
            dgvAgency.Columns[9].HeaderText = "Fax number";
            dgvAgency.Columns[9].Width = 120;

        }

        
        //user clicked on cell - is it one of the buttons
        private void dgvAgency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int agencyID = (int)dgvAgency.Rows[e.RowIndex].Cells[2].Value;
                selectedAgency = context.Agency.Find(agencyID);
            }
            catch { return; }
            const int DeleteIndex = 0; 
            const int ModifyIndex = 1;
            if (e.ColumnIndex == DeleteIndex)
            {
                DeleteAgency();
            }
            else if (e.ColumnIndex == ModifyIndex)
            {
                ModifyAgency();
            }
        }

        private void DeleteAgency()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedAgency.AgncyAddress}?",
                "Confirm Delete", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes) //user confirmed
            {
                try
                {
                    context.Agency.Remove(selectedAgency);
                    context.SaveChanges(true);
                    DisplayAgency();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyException(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void HandleConcurrencyException(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedAgency).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that Agency.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that Agency. \n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayAgency();
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE: " + error.Number + " " +
                                error.Message + "\n";
            }
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        // do update on selected Agency
        private void ModifyAgency()
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
            var addModifyAgencyForm = new frmAddModifyAgency()
            {
                addModifyAgencyForm = false,
                Agency = selectedAgency
            };
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyAgencyForm.Close(); };
            addModifyAgencyForm.Controls.Add(btn);
            addModifyAgencyForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult result = addModifyAgencyForm.ShowDialog(); //display modal
            if (result == DialogResult.OK) // user clicked Accept on the second form
            {
                try
                {
                    selectedAgency = addModifyAgencyForm.Agency; //new data
                    context.SaveChanges();
                    DisplayAgency();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyException(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }



        }

        private void dgvAgency_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            var frmAddModifyAgency = new frmAddModifyAgency()
            {
                addModifyAgencyForm = true
            };

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { frmAddModifyAgency.Close(); };
            frmAddModifyAgency.Controls.Add(btn);
            frmAddModifyAgency.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };


            DialogResult answer = frmAddModifyAgency.ShowDialog();
            if (answer == DialogResult.OK)
            {
                try
                {
                    selectedAgency = frmAddModifyAgency.Agency;
                    context.Agency.Add(selectedAgency);
                    context.SaveChanges();
                    DisplayAgency();
                }
                catch (DbUpdateException ex)
                {

                }

            }
        }
    }
}

