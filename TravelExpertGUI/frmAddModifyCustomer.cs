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
    public partial class frmAddModifyCustomer : Form
    {
        // these public properties are set by the main form
        public Customer Customer { get; set; } // selected product on the main form
        public bool AddCustomer { get; set; } // flag that distinguishes Add from Modify
        public frmAddModifyCustomer()
        {
            InitializeComponent();
        }

        private void frmAddModifyCustomer_Load(object sender, EventArgs e)
        {
            if (AddCustomer) // this is Add
            {
                addModifyPackageHeading.Text = "Add Customer";
                txtCustomerID.ReadOnly = true;  // not allow entry of new product code
            }
            else // this is Modify
            {
                addModifyPackageHeading.Text = "Modify Customer";
                txtCustomerID.ReadOnly = true;   // can't change existing product code
                this.DisplayCustomer();
            }

        }
        //Display customer method
        private void DisplayCustomer()
        {
            txtCustomerID.Enabled = false;
            txtCustomerID.Text = Customer.CustomerId.ToString();
            txtAddress.Text = Customer.CustAddress;
            txtCity.Text = Customer.CustCity;
            txtCountry.Text = Customer.CustCountry;
            txtEmail.Text = Customer.CustEmail;
            txtFirstName.Text = Customer.CustFirstName;
            txtLastName.Text = Customer.CustLastName;
            txtPhone.Text = Customer.CustHomePhone;
            txtProvince.Text = Customer.CustProv;
            txtPostCode.Text = Customer.CustPostal;
        }
        //User click Add button  method
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddCustomer) // this is Add
                {
                    // initialize the Customer property with new Products object
                    this.Customer = new Customer();
                }
                this.LoadCustomerData(); // we have an object (public property Product) with new data
                this.DialogResult = DialogResult.OK;
            }
        }
        // Setup LoadCustomerDataMethod
        private void LoadCustomerData()
        {
            //Customer.CustomerId = Convert.ToInt32(txtCustomerID.Text);
            Customer.CustFirstName = txtFirstName.Text;
            Customer.CustLastName = txtLastName.Text;
            Customer.CustAddress = txtAddress.Text;
            Customer.CustCity = txtCity.Text;
            Customer.CustProv = txtProvince.Text;
            Customer.CustPostal = txtPostCode.Text;
            Customer.CustEmail = txtEmail.Text;
            Customer.CustCountry= txtCountry.Text;
            Customer.CustHomePhone = txtPhone.Text;
        }
        //Check if there are data inside the input
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
       
            errorMessage += Validator.IsPresent(txtAddress.Text, txtAddress.Tag.ToString());
            errorMessage += Validator.IsPresent(txtCity.Text, txtCity.Tag.ToString());
            errorMessage += Validator.IsPresent(txtCountry.Text, txtCountry.Tag.ToString());
            errorMessage += Validator.IsPresent(txtFirstName.Text, txtFirstName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtLastName.Text, txtLastName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtPhone.Text, txtPhone.Tag.ToString());
            errorMessage += Validator.isPhoneNumber(txtPhone.Text, "Phone number");
            errorMessage += Validator.IsDecimal(txtPhone.Text, "Phone number");
            errorMessage += Validator.IsPresent(txtPostCode.Text, txtPostCode.Tag.ToString());
            errorMessage += Validator.IsProvince(txtProvince.Text, "Province");


            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    } // Form
}     //NameSpace
