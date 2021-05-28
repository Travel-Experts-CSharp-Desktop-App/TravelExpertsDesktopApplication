using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmAddModifyProduct : Form
    {
        // these public properties are set by the main form
        private TravelExpertsV2Context context = new TravelExpertsV2Context();

        public Product Product { get; set; } // selected product on the main form
        public Supplier supplier;
        public bool AddProduct { get; set; } // flag that distinguishes Add from Modify
        public frmAddModifyProduct()
        {
            InitializeComponent();
        }


        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            if (AddProduct) // this is Add
            {
                addModifyPackageHeading.Text = "Add Product";
                txtProductID.ReadOnly = true;  // allow entry of new product code
            }
            else // this is Modify
            {
                addModifyPackageHeading.Text = "Modify Product";
                txtProductID.ReadOnly = true;   // can't change existing product code
                this.DisplayProducts();
            }
        }

        private void DisplayProducts()
        {
            txtProductID.Enabled = false;
            txtProductID.Text = Product.ProductId.ToString();
            txtProductName.Text = Product.ProdName;
            txtProductFee.Text = Product.ProdFee.ToString();
            //txtSupplierID.Text = Product.ProductSupplier.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddProduct) // this is Add
                {
                    // initialize the product property with new Product object
                    this.Product = new Product();
                }
                this.LoadProductData(); 
                this.DialogResult = DialogResult.OK;
            }
        }

        private void LoadProductData()
        {
            Product.ProdName = txtProductName.Text;
            Product.ProdFee = Convert.ToDecimal(txtProductFee.Text);
            //Product.ProductSupplier = Convert.ToInt32(txtSupplierID.Text);
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtSupplierID.Text, txtSupplierID.Tag.ToString());
            errorMessage += Validator.IsDecimal(txtSupplierID.Text, txtSupplierID.Tag.ToString());
            errorMessage += Validator.IsPresent(txtProductName.Text, txtProductName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtProductFee.Text, txtProductFee.Tag.ToString());
            errorMessage += Validator.IsDecimal(txtProductFee.Text, txtProductFee.Tag.ToString());


            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSupplierID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
