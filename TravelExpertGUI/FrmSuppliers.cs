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
using TravelExpertsGUI;

namespace TravelExpertGUI
{
    public partial class FrmSuppliers : Form
    {
        private TravelExpertsV2Context context = new TravelExpertsV2Context();
        public Supplier selectedSupplier;
       
        public FrmSuppliers()
        {
            InitializeComponent();
        }
        private void ConfigureDataGridForSupplier()
        {
            dSupplier.Columns.Clear();
            var supplier = context.Supplier
                .OrderBy(s => s.SupName)
                .Select(s => new { s.SupplierId, s.SupName, s.SupAdress, s.SupCountry, s.SupCity, s.SupEmail, s.SupPhoneNumber })
                .ToList();
            dSupplier.DataSource = supplier;//Fill the data grid with data

            //Add delete button to each line using  object initializer
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "X"
            };
            dSupplier.Columns.Insert(0, deleteColumn);

            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "✎"
            };
            dSupplier.Columns.Insert(1, modifyColumn);


            // HEADING OF GRID
            dSupplier.EnableHeadersVisualStyles = false;
            dSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 12, FontStyle.Bold);
            dSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(172, 126, 241);
            dSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn c in dSupplier.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Dubai", 11);
            }

            dSupplier.Columns[0].Width = 30;
            dSupplier.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(209, 45, 42);
            dSupplier.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dSupplier.Columns[0].DefaultCellStyle.Font = new Font("Dubai", 12);
            dSupplier.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 45, 42);
            dSupplier.Columns[0].DefaultCellStyle.SelectionForeColor = Color.White;

            dSupplier.Columns[1].Width = 30;
            dSupplier.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(97, 208, 158);
            dSupplier.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dSupplier.Columns[1].DefaultCellStyle.Font = new Font("Dubai", 12);
            dSupplier.Columns[1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(97, 208, 158);
            dSupplier.Columns[1].DefaultCellStyle.SelectionForeColor = Color.White;


            //Styling the columns
            //format the first column
            dSupplier.Columns[2].HeaderText = "Supplier ID";
            dSupplier.Columns[2].Width = 150;
            dSupplier.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dSupplier.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //format the second column
            dSupplier.Columns[3].HeaderText = "Supplier Name";
            dSupplier.Columns[3].Width = 250;
            //format the third column
            dSupplier.Columns[4].HeaderText = "Address";
            dSupplier.Columns[4].Width = 300;
            //format the third column
            dSupplier.Columns[5].HeaderText = "Country";
            dSupplier.Columns[5].Width = 150;
            //format the Fourth column
            dSupplier.Columns[6].HeaderText = "City";
            dSupplier.Columns[6].Width = 150;
            //format the Fifth column
            dSupplier.Columns[7].HeaderText = "Email";
            dSupplier.Columns[7].Width =270;
            //format the Fifth column
            dSupplier.Columns[8].HeaderText = "Phone Number";
            dSupplier.Columns[8].Width = 250;
        }


        private void FrmSuppliers_Load(object sender, EventArgs e)
        {
            ConfigureDataGridForSupplier();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int supplierID = (int)dSupplier.Rows[e.RowIndex].Cells[2].Value;
                selectedSupplier = context.Supplier.Find(supplierID);
            }
            catch { return; }
            const int DeleteIndex = 0;
            const int ModifyIndex = 1;

            if (e.ColumnIndex == DeleteIndex)
            {
                DeleteSupplier();
            }
            else if (e.ColumnIndex == ModifyIndex)
            {
                ModifySupplier();
            }
        }

        private void ModifySupplier()
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

            FrmAddModifySupplier nextForm = new FrmAddModifySupplier()
            {
                AddSupplier = false,
                Supplier = selectedSupplier

            };


            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { nextForm.Close(); };
            nextForm.Controls.Add(btn);
            nextForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult answer = nextForm.ShowDialog();
            if (answer == DialogResult.No)
            {
                selectedSupplier = nextForm.Supplier;
                try
                {

                    selectedSupplier = nextForm.Supplier;
                    context.SaveChanges();
                    ConfigureDataGridForSupplier();
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
        private void DeleteSupplier()
        {
            DialogResult responds =  MessageBox.Show("Are you sure you want to delete " + " " + selectedSupplier.SupName, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (responds == DialogResult.Yes)
            {
                context.Supplier.Remove(selectedSupplier);
                context.SaveChanges();
                ConfigureDataGridForSupplier();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
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

            FrmAddModifySupplier nextForm = new FrmAddModifySupplier()
            {
                AddSupplier = true,
            };

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { nextForm.Close(); };
            nextForm.Controls.Add(btn);
            nextForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult answer = nextForm.ShowDialog();

            if (answer == DialogResult.OK)
            {
                try
                {
                    selectedSupplier = nextForm.Supplier;// record customer from the second
                                                                    // form as the current customer
                    context.Supplier.Add(selectedSupplier);
                    context.SaveChanges();
                    ConfigureDataGridForSupplier();
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
