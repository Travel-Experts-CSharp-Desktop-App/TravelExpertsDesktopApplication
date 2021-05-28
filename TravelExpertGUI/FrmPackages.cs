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
    public partial class FrmPackages : Form
    {

        public FrmPackages()
        {
            InitializeComponent();
        }

        public TravelExpertsV2Context context = new TravelExpertsV2Context();
        private Package selectedProduct;

        private void FrmPackages_Load(object sender, EventArgs e)
        {
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);
            ShowProducts();
            addNewPackage.TabStop = false;
            addNewPackage.FlatStyle = FlatStyle.Flat;
            addNewPackage.FlatAppearance.BorderSize = 0;

        }


        /// <summary>
        /// A panel which redraws its surface using a secondary buffer to reduce or prevent flicker.
        /// </summary>
        public class PanelDoubleBuffered : System.Windows.Forms.Panel
        {
            public PanelDoubleBuffered()
                : base()
            {
                this.DoubleBuffered = true;
            }
        }

        // HANDLE DISPLAY OF GRID
        private void ShowProducts()
        {
            // CLEAR OLD CONTENT
            dataGridView1.Columns.Clear();
            // RETRIEVE PRODUCT DATA
            var products = context.Package
                // SELECT PRODUCT CODE / NAME OF PRODUCT / PRODUCT VERSION / RELEASE DATE
                .Select(p => new { p.PackageId, p.PkgName, p.PkgDesc, p.PkgStartDate, p.PkgEndDate, p.PkgBasePrice, p.PkgAgencyCommission })
                .ToList();
            // POINT TO GRID VIEW
            dataGridView1.DataSource = products;

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
            dataGridView1.Columns.Insert(0, deleteColumn);

            // 2) MODIFY BUTTON COLUMN
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "✎"
            };
            dataGridView1.Columns.Insert(1, modifyColumn);

            // ####################
            // ####################
            // ##### COLUMN  ######
            // ##### FORMAT  ######
            // ####################
            // ####################

            // HEADING OF GRID
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(236, 100, 8);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Dubai", 11);
            }

            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(209, 45, 42);
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Dubai", 12);
            dataGridView1.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 45, 42);
            dataGridView1.Columns[0].DefaultCellStyle.SelectionForeColor = Color.White;


            dataGridView1.Columns[1].Width = 30;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(97, 208, 158);
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[1].DefaultCellStyle.Font = new Font("Dubai", 12);
            dataGridView1.Columns[1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(97, 208, 158);
            dataGridView1.Columns[1].DefaultCellStyle.SelectionForeColor = Color.White;

            // FIRST COLUMN
            dataGridView1.Columns[2].HeaderText = "ID";
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // SECOND COLUMN
            dataGridView1.Columns[3].HeaderText = "Name";
            dataGridView1.Columns[3].Width = 140;

            // THIRD COLUMN
            dataGridView1.Columns[4].HeaderText = "Description";
            dataGridView1.Columns[4].Width = 220;

            // FOURTH COLUMN
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[5].HeaderText = "Start date";

            // FIFTH COLUMN
            dataGridView1.Columns[6].Width = 140;
            dataGridView1.Columns[6].HeaderText = "End date";

            dataGridView1.Columns[7].HeaderText = "Cost";
            dataGridView1.Columns[7].Width = 110;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "c";


            dataGridView1.Columns[8].HeaderText = "Commission";
            dataGridView1.Columns[8].Width = 110;
            dataGridView1.Columns[8].DefaultCellStyle.Format = "c";

        }


        // WHEN USER CLICKS ON MODIFY OR DELETE IN EACH COLUMN
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int customerID = (int)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                selectedProduct = context.Package.Find(customerID);
            }
            catch { return; }
            const int DeleteIndex = 0;
            const int ModifyIndex = 1;

            if (e.ColumnIndex == DeleteIndex)
            {
                DeleteProduct();
            }
            else if (e.ColumnIndex == ModifyIndex)
            {
                ModifyProduct();
            }
        }

        // DELETE SELECTED PRODUCT
        private void DeleteProduct()
        {
            // USER MUST CONFIRM BEFORE DELETING PRODUCT
            DialogResult result =
                MessageBox.Show($"Delete {selectedProduct.PkgName.Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    context.Package.Remove(selectedProduct);
                    context.SaveChanges(true);
                    ShowProducts();
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        // APPLY EDITS TO SELECTED PRODUCT
        private void ModifyProduct()
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

            var addModifyProductForm = new frmAddModifyPackage()
            {
                AddPackage = false,
                Package = selectedProduct
            };

            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyProductForm.Close(); };
            addModifyProductForm.Controls.Add(btn);
            addModifyProductForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult result = addModifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    // SAVE NEW DATA
                    selectedProduct = addModifyProductForm.Package;
                    context.SaveChanges();
                    ShowProducts();
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        // HANDLE GENERAL ERROR METHOD
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addNewPackage_Click(object sender, EventArgs e)
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

            var addModifyCustomerForm = new frmAddModifyPackage()
            {
                AddPackage = true
            };
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyCustomerForm.Close(); };
            addModifyCustomerForm.Controls.Add(btn);
            addModifyCustomerForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };
            DialogResult result = addModifyCustomerForm.ShowDialog();




            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    selectedProduct = addModifyCustomerForm.Package;// record customer from the second                                                                // form as the current customer
                    context.Package.Add(selectedProduct);
                    context.SaveChanges();
                    ShowProducts();
                }
                catch (DbUpdateException ex)
                {
                    //HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
            //addModifyCustomerForm.StartPosition = FormStartPosition.CenterParent;
            //addModifyCustomerForm.ShowDialog(this);
            // panel will be disposed and the form will "lighten" again...

        }

        private void editPackage_Click(object sender, EventArgs e)
        {

        }

        private void FrmPackages_Load_1(object sender, EventArgs e)
        {
            ShowProducts();
        }
    }



}
