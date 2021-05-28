using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        public TravelExpertsV2Context context = new TravelExpertsV2Context();
        public Product selectedProduct;
        private void frmProduct_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            dgvProducts.Columns.Clear();
            var product = context.Product
                .OrderBy (prod => prod.ProductId)
                .Select(prod => new
                {
                    prod.ProductId,
                    prod.ProdName,
                    prod.ProdFee
                }).ToList();

            dgvProducts.DataSource = product;

            //Add delete button to each line using  object initializer
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "X"
            };
            dgvProducts.Columns.Insert(0, deleteColumn);

            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Text = "✎"
            };
            dgvProducts.Columns.Insert(1, modifyColumn);

            // HEADING OF GRID
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 12, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 138, 114);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn c in dgvProducts.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Dubai", 11);
            }

            dgvProducts.Columns[0].Width = 30;
            dgvProducts.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(209, 45, 42);
            dgvProducts.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dgvProducts.Columns[0].DefaultCellStyle.Font = new Font("Dubai", 12);
            dgvProducts.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 45, 42);
            dgvProducts.Columns[0].DefaultCellStyle.SelectionForeColor = Color.White;

            dgvProducts.Columns[1].Width = 30;
            dgvProducts.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(97, 208, 158);
            dgvProducts.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dgvProducts.Columns[1].DefaultCellStyle.Font = new Font("Dubai", 12);
            dgvProducts.Columns[1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(97, 208, 158);
            dgvProducts.Columns[1].DefaultCellStyle.SelectionForeColor = Color.White;

            // format the first column
            dgvProducts.Columns[2].HeaderText = "ID";
            dgvProducts.Columns[2].Width = 50;
            dgvProducts.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // format the 2nd column
            dgvProducts.Columns[3].HeaderText = "Product Name";
            dgvProducts.Columns[3].Width = 400;

            // format the 3rd column
            dgvProducts.Columns[4].HeaderText = "Product Fee";
            dgvProducts.Columns[4].Width = 350;
            dgvProducts.Columns[4].DefaultCellStyle.Format = "c";

            // format the 4th column
            /*dgvProducts.Columns[5].HeaderText = "Supplier ID";
            dgvProducts.Columns[5].Width = 130;*/
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int customerID = (int)dgvProducts.Rows[e.RowIndex].Cells[2].Value;
                selectedProduct = context.Product.Find(customerID);
            }
            catch { return; }
            const int DeleteIndex = 0; // Delete buttons are column 8
            const int ModifyIndex = 1; // Delete buttons are column 8

            if (e.ColumnIndex == DeleteIndex) // user clicked on Delete
            {
                DeleteProduct();
            }
            else if (e.ColumnIndex == ModifyIndex)
            {
                ModifyProduct();
            }
        }

        private void DeleteProduct()
        {
            DialogResult result =
               MessageBox.Show($"Are sure you want to delete {selectedProduct.ProdName}?",
               "Confirm Delete", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)// user confirmed
            {
                try
                {
                    context.Product.Remove(selectedProduct);
                    context.SaveChanges(true);
                    DisplayProducts();
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

            var addModifyProductForm = new frmAddModifyProduct()
            { // object initializer
                AddProduct = false,
                Product = selectedProduct
            };

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyProductForm.Close(); };
            addModifyProductForm.Controls.Add(btn);
            addModifyProductForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult result = addModifyProductForm.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product; // new data
                    context.SaveChanges();
                    DisplayProducts();
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

            var state = context.Entry(selectedProduct).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted this product.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated tthis product.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayProducts();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
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

            var addModifyProductForm = new frmAddModifyProduct()
            {
                AddProduct = true
            };

            // ENSURE SHADOW IS REMOVED
            Button btn = new Button() { Text = "OK" };
            btn.Click += (ss, ee) => { addModifyProductForm.Close(); };
            addModifyProductForm.Controls.Add(btn);
            addModifyProductForm.FormClosed += (ss, ee) => { shadow.Hide(); Enabled = true; };

            DialogResult result = addModifyProductForm.ShowDialog();
            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product;// record customer from the second
                                                                      // form as the current customer
                    context.Product.Add(selectedProduct);
                    context.SaveChanges();
                    DisplayProducts();
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

        private void btnExitProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
}    
