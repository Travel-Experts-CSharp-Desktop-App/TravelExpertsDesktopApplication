using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpertsGUI
{
    public partial class FrmAddModifySupplier : Form
    {
        private TravelExpertsV2Context context = new TravelExpertsV2Context();
        public Supplier Supplier { get; set; }
        // ADD FROM EDIT
        public bool AddSupplier { get; set; }

        private Supplier selectedSupplier;
        public List<Supplier> supplierList;


        public FrmAddModifySupplier()
        {
            InitializeComponent();
        }

        private void HandleError(Exception ex)//General Error
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void LoadSupplierList()
        {
            try
            {
                supplierList = context.Supplier.ToList();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void FrmAddModifySupplier_Load(object sender, EventArgs e)
        {

            LoadSupplierList();
            int spl = supplierList.Count();
            int nspl = spl + 70;

            txtSupplierID.Text = nspl.ToString();

            if (AddSupplier)
            {               
                this.Text = "Add Supplier";
                lblAdd.Visible = true;
                lblModify.Visible = false;
            }
            else
            {
                this.Text = "Modify Supplier";
                lblAdd.Visible = false;
                lblModify.Visible = true;
                this.ShowSupplier();
            }
        }

        /* Is Valid Data */
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            //errorMessage += TravelExpertGUI.Validator.IsPresent(txtName.Text, txtName.Tag.ToString());
            /*errorMessage += TravelExpertGUI.Validator.IsPresent(txtAdress.Text, txtAdress.Tag.ToString());
            errorMessage += TravelExpertGUI.Validator.IsPresent(txtCountry.Text, txtCountry.Tag.ToString());
            errorMessage += TravelExpertGUI.Validator.IsPresent(txtCity.Text, txtCity.Tag.ToString());
            errorMessage += TravelExpertGUI.Validator.IsPresent(txtEmail.Text, txtEmail.Tag.ToString());
            errorMessage += TravelExpertGUI.Validator.IsPresent(txtPhonNumber.Text, txtPhonNumber.Tag.ToString());
            errorMessage += TravelExpertGUI.Validator.IsInt32(txtPhonNumber.Text, txtPhonNumber.Tag.ToString());
            errorMessage += TravelExpertGUI.Validator.isPhoneNumber(txtPhonNumber.Text, "Phone number");*/

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        // SHOW THE SUPPLIER TO USER
        private void ShowSupplier()
        {
            txtPackageID.Enabled = false;
            txtSupplierID.Text = Supplier.SupplierId.ToString();
            txtName.Text = Supplier.SupName;
            txtAdress.Text = Supplier.SupAdress;
            txtCountry.Text = Supplier.SupCountry;
            txtCity.Text = Supplier.SupCity;
            txtEmail.Text = Supplier.SupEmail;
            txtPhonNumber.Text = Supplier.SupPhoneNumber;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (AddSupplier)
            {
                // PRODUCT PROPERTY FOR OBJECT
                this.Supplier = new Supplier();
            }
            this.LoadSupplierData();
            this.DialogResult = DialogResult.OK;
        }

        private void LoadSupplierData()
        {
            Supplier.SupplierId = Convert.ToInt32(txtSupplierID.Text);
            Supplier.SupName = txtName.Text;
            Supplier.SupAdress = txtAdress.Text;
            Supplier.SupCountry = txtCountry.Text;
            Supplier.SupCity = txtCity.Text;
            Supplier.SupEmail = txtEmail.Text;
            Supplier.SupPhoneNumber = txtPhonNumber.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhonNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhonNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSupplierID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
