using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
            dgvCustomers.Columns.Clear();
        }

        public TravelExpertsV2Context context = new TravelExpertsV2Context();
        public Customer selectedCustomer;

        private void dvgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //this is a default event
        }
        private void DisplayCustomers()
        {
            
            dgvCustomers.Columns.Clear();
            var customer = context.Customer
                .OrderBy(cust => cust.CustFirstName) 
                .Select(cust => new 
                {
                    cust.CustomerId,
                    cust.CustFirstName,
                    cust.CustLastName,
                    cust.CustAddress,
                    cust.CustCity,
                    cust.CustHomePhone,
                    cust.CustEmail
                }) .ToList();
                dgvCustomers.DataSource = customer;

            //Add delete button to each line using  object initializer
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "X"
            };
            dgvCustomers.Columns.Insert(0, deleteColumn);

            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "✎"
            };
            dgvCustomers.Columns.Insert(1, modifyColumn);



            // HEADING OF GRID
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 12, FontStyle.Bold);
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 188, 10);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn c in dgvCustomers.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Dubai", 11);
            }

            dgvCustomers.Columns[0].Width = 30;
            dgvCustomers.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(209, 45, 42);
            dgvCustomers.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.Columns[0].DefaultCellStyle.Font = new Font("Dubai", 12);
            dgvCustomers.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 45, 42);
            dgvCustomers.Columns[0].DefaultCellStyle.SelectionForeColor = Color.White;


            dgvCustomers.Columns[1].Width = 30;
            dgvCustomers.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(97, 208, 158);
            dgvCustomers.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.Columns[1].DefaultCellStyle.Font = new Font("Dubai", 12);
            dgvCustomers.Columns[1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(97, 208, 158);
            dgvCustomers.Columns[1].DefaultCellStyle.SelectionForeColor = Color.White;


            // format the first column
            dgvCustomers.Columns[2].HeaderText = "ID";
            dgvCustomers.Columns[2].Width = 50;
            dgvCustomers.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // format the 2nd column
            dgvCustomers.Columns[3].HeaderText = "First Name";
            dgvCustomers.Columns[3].Width = 120;

            // format the 3rd column
            dgvCustomers.Columns[4].HeaderText = "Last Name";
            dgvCustomers.Columns[4].Width = 120;

            // format the 4th column
            dgvCustomers.Columns[5].HeaderText = "Address";
            dgvCustomers.Columns[5].Width = 120;

            // format the 5th column
            dgvCustomers.Columns[6].HeaderText = "City";
            dgvCustomers.Columns[6].Width = 100;

            // format the 6th column
            dgvCustomers.Columns[7].HeaderText = "Phone Number";
            dgvCustomers.Columns[7].Width = 150;

            // format the 7th column
            dgvCustomers.Columns[8].HeaderText = "Email";
            dgvCustomers.Columns[8].Width = 200;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int customerID = (int)dgvCustomers.Rows[e.RowIndex].Cells[2].Value;
                selectedCustomer = context.Customer.Find(customerID);
            }
            catch { return; }
            const int DeleteIndex = 0; // Delete buttons are column 8
            const int ModifyIndex = 1; // Delete buttons are column 8

            if (e.ColumnIndex == DeleteIndex) // user clicked on Delete
            {
                DeleteCustomer();
            } else if (e.ColumnIndex == ModifyIndex) {
                ModifyCustomer();
            }
        }

        //User cliked on the cell (delete/modify)
        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // store index values for Modify and Delete button columns
            const int ModifyIndex = 7; // Modify buttons are column 7

            try { 
                int customerID = (int)dgvCustomers.Rows[e.RowIndex].Cells[2].Value;
                selectedCustomer = context.Customer.Find(customerID);
                ModifyCustomer();
            }
            catch { return; }  
        }

        private void DeleteCustomer()
        {
            DialogResult result =
               MessageBox.Show($"Are you sure to delete " +
               $" {selectedCustomer.CustFirstName}  {selectedCustomer.CustLastName} ?",        
               "Confirm Delete", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)// user confirmed
            {
                try
                {
                    context.Customer.Remove(selectedCustomer);
                    context.SaveChanges(true);
                    DisplayCustomers();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
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

        private void ModifyCustomer()
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

            var addModifyCustomerForm = new frmAddModifyCustomer()
            { // object initializer
                AddCustomer = false,
                Customer = selectedCustomer
            };

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyCustomerForm.Close(); };
            addModifyCustomerForm.Controls.Add(btn);
            addModifyCustomerForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult result = addModifyCustomerForm.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    selectedCustomer = addModifyCustomerForm.Customer; // new data
                    context.SaveChanges();
                    DisplayCustomers();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
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

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE:  " + error.Number + " " +
                                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedCustomer).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted this customer.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated tthis customer.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayCustomers();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editCustomer_Click(object sender, EventArgs e)
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

            var addModifyCustomerForm = new frmAddModifyCustomer()
            {
                AddCustomer = true
            };

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyCustomerForm.Close(); };
            addModifyCustomerForm.Controls.Add(btn);
            addModifyCustomerForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult result = addModifyCustomerForm.ShowDialog();
            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    selectedCustomer = addModifyCustomerForm.Customer;// record customer from the second
                                                                      // form as the current customer
                    context.Customer.Add(selectedCustomer);
                    context.SaveChanges();
                    DisplayCustomers();
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

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            DisplayCustomers();
        }

        private void dvgCustomer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    } //Form              
}     //namespace
