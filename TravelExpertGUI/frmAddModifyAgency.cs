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
    public partial class frmAddModifyAgency : Form
    {
        public bool addModifyAgencyForm { get; set; }
        public Agency Agency { get; set; }
        public frmAddModifyAgency()
        {
            InitializeComponent();
        }

        private void frmAddModifyAgency_Load(object sender, EventArgs e)
        {
            if (addModifyAgencyForm) // this is Add
            {
                addModifyPackageHeading.Text = "Add new Agency";
                txtAgencyID.ReadOnly = true;  // not allow entry of new product code
            }
            else // this is Modify
            {
                addModifyPackageHeading.Text = "Modify Agency";
                txtAgencyID.ReadOnly = true;   // can't change existing product code
                this.DisplayAgency();
            }
        }

        //Display customer method
        private void DisplayAgency()
        {
            txtAgencyID.Enabled = false;
            txtAgencyID.Text = Agency.AgencyId.ToString();
            txtAddress.Text = Agency.AgncyAddress;
            txtCountry.Text = Agency.AgncyCountry;
            txtCity.Text = Agency.AgncyCity;
            txtProvince.Text = Agency.AgncyProv;
            txtPostalCode.Text = Agency.AgncyPostal;
            txtPhoneNumber.Text = Agency.AgncyPhone;
            txtFaxNumber.Text = Agency.AgncyFax;
        }

        //User click Add button  method
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addModifyAgencyForm) // this is Add
                {
                    // initialize the Customer property with new Products object
                    this.Agency = new Agency();
                }
                this.LoadAgencyData(); // we have an object (public property Product) with new data
                this.DialogResult = DialogResult.OK;
            }
        }

        // Setup LoadCustomerDataMethod
        private void LoadAgencyData()
        {
            Agency.AgncyAddress = txtAddress.Text;
            Agency.AgncyCity = txtCity.Text;
            Agency.AgncyProv = txtProvince.Text;
            Agency.AgncyCountry = txtCountry.Text;
            Agency.AgncyPostal = txtPostalCode.Text;
            Agency.AgncyPhone = txtPhoneNumber.Text;
            Agency.AgncyFax = txtFaxNumber.Text;
        }

        //Check if there are data inside the input
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            errorMessage += Validator.IsPresent(txtAddress.Text, txtAddress.Tag.ToString());
            errorMessage += Validator.IsPresent(txtCity.Text, txtCity.Tag.ToString());
            errorMessage += Validator.IsPresent(txtCountry.Text, txtCountry.Tag.ToString());
            errorMessage += Validator.IsPresent(txtPostalCode.Text, txtPostalCode.Tag.ToString());
            errorMessage += Validator.IsPresent(txtProvince.Text, txtProvince.Tag.ToString());
            errorMessage += Validator.IsProvince(txtProvince.Text, "Province");
            errorMessage += Validator.isPhoneNumber(txtPhoneNumber.Text, "Phone number");
            errorMessage += Validator.IsDecimal(txtPhoneNumber.Text, "Phone number");
            errorMessage += Validator.IsPresent(txtFaxNumber.Text, txtFaxNumber.Tag.ToString());
            errorMessage += Validator.IsDecimal(txtFaxNumber.Text, txtFaxNumber.Tag.ToString());

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

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
