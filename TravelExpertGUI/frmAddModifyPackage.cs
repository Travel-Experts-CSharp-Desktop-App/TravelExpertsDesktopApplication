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

namespace TravelExpertGUI
{
    public partial class frmAddModifyPackage : Form
    {
        // SET PUBLIC PROPERTIES ON MAIN FORM
        // SELECTED PRODUCT
        public Package Package { get; set; }
        // ADD FROM EDIT
        public bool AddPackage { get; set; }


        public frmAddModifyPackage() {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e) {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            // ADD
            if (AddPackage) {
                addModifyPackageHeading.Text = "Add Product";
                // ALLOW USER TO CHANGE CODE
                txtPackageID.ReadOnly = true;
            // MODIFICATION
            } else {
                addModifyPackageHeading.Text = "Modify Product";
                // PREVENT USER FROM CHANGING CODE
                txtPackageID.ReadOnly = true;   
                this.ShowProduct();
            }
        }

        // SHOW THE PRODUCT TO USER
        private void ShowProduct() {
            addModifyPackageHeading.Text = "Modify a package";
            txtPackageID.Enabled = false;
            txtPackageID.Text = Package.PackageId.ToString();
            textPackageName.Text = Package.PkgName;
            textPackageDescription.Text = Package.PkgDesc;
            textPackageStartDate.Text = Package.PkgStartDate.ToString();
            textPackageEndDate.Text = Package.PkgEndDate.ToString();
            textPackagePrice.Text = Package.PkgBasePrice.ToString();
            textPackageCommission.Text = Package.PkgAgencyCommission.ToString();
        }

        // WHEN USER CLICKS ACCEPT
        private void btnAccept_Click(object sender, EventArgs e) {
            if (IsValidData()) {
                if (AddPackage) {
                    // PRODUCT PROPERTY FOR OBJECT
                    this.Package = new Package();
                }
                this.LoadPackageData();
                this.DialogResult = DialogResult.OK;
            }
        }
        // CHECK USER INPUT
        private bool IsValidData() {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(textPackageDescription.Text, textPackageDescription.Tag.ToString());
            errorMessage += Validator.IsPresent(textPackageName.Text, textPackageName.Tag.ToString());
            errorMessage += Validator.IsPresent(textPackagePrice.Text, textPackagePrice.Tag.ToString());
            errorMessage += Validator.IsDecimal(textPackagePrice.Text, textPackagePrice.Tag.ToString());
            errorMessage += Validator.IsPresent(textPackageCommission.Text, textPackageCommission.Tag.ToString());
            errorMessage += Validator.IsDecimal(textPackageCommission.Text, textPackageCommission.Tag.ToString());
            errorMessage += Validator.IsPresent(textPackageStartDate.Text, "Package start date must not be empty.");
            errorMessage += Validator.IsPresent(textPackageEndDate.Text, "Package end date must not be empty.");
            errorMessage += Validator.isDateTime(textPackageStartDate.Text, "Package start date");
            errorMessage += Validator.isDateTime(textPackageEndDate.Text, "Package end date");

            if (errorMessage != "") {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }
        private void LoadPackageData() {
            Package.PkgName = textPackageName.Text;
            Package.PkgDesc = textPackageDescription.Text;
            var stringDt1 = Convert.ToDateTime(textPackageStartDate.Text);
            var stringDt2 = Convert.ToDateTime(textPackageEndDate.Text);
            Package.PkgStartDate = stringDt1;
            Package.PkgEndDate = stringDt2;
            Package.PkgBasePrice = Convert.ToDecimal(textPackagePrice.Text);
            Package.PkgAgencyCommission = Convert.ToDecimal(textPackageCommission.Text);
        }


        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textPackageDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textPackageCommission_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}