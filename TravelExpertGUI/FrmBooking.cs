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
    public partial class FrmBooking : Form
    {
        private TravelExpertsV2Context context = new TravelExpertsV2Context();
        private Package selectedPackage;
        public List<Package> packageList;// list that hold the packages Data

        private Product selectedProduct;
        public List<Product> productList;// list that hold the Product Data
        private Customer selectedCustomer;
        public List<Customer> customerList;// list that hold the Customer Data

        private Class selectedClass;
        public List<Class> classList;// list that hold the Class Data

        private Booking selectedBooking;
        public List<Booking> boockingList;// list that hold the booking Data

        private BookingProduct selectedBookingProduct;
        public List<BookingProduct> BookingProductList;// list that hold the BookingProduc Data
        public FrmBooking()
        {
            InitializeComponent();
        }

        ////Load the booking List
        /////This form is running properly if you comment from the line 41 to 51
        private void BookingList()
        {
            try
            {
                boockingList = context.Booking.ToList();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }





        private void LoadBookingProductList()
        {
            try
            {
                BookingProductList = context.BookingProduct.ToList();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            bookingPhase1.Visible = true;
            bookingPhase3.Visible = false;
            bookingPhase2.Visible = false;
            bookingPhase4.Visible = false;
            //to fill the auto increment txtBox for ProductList
            LoadBookingProductList();
            int x = BookingProductList.Count();
           
                int nx = x + 1;
                txtPBID.Text = nx.ToString();

            BookingList();
            int y = boockingList.Count();
            int ny = y + 1;
            txtBookingID.Text = ny.ToString();


            //lbld3.Visible = false;
            //lbld2.Visible = false;
            //lbld1.Visible = false;
            lblDate.Text = DateTime.Today.ToShortDateString().ToString();
            LoadPackageList();
            LoadComboPackages();
            cmbPackage.Text = "";
            LoadProductList();
            LoadComboProducts();
            cmbProductID.Text = "";
            LoadCustomerList();
            LoadComboCustomers();
            cmbCustomerID.Text = "";

            LoadClassList();
            LoadComboClasses();
            cmbClass.Text = "";
            

        }

        private void LoadComboPackages()
        {
            cmbPackage.DataSource = this.packageList;
            cmbPackage.DisplayMember = "PkgName";
            cmbPackage.ValueMember = "PackageId";
        }

        //Load the Product List
        private void LoadProductList()
        {
            try
            {
                productList = context.Product.ToList();

            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void LoadComboProducts()//Load cmboProduct with data
        {
            cmbProductID.DataSource = this.productList;
            cmbProductID.DisplayMember = "ProdName";
            cmbProductID.ValueMember = "ProductId";
        }

        //Load the package List
        private void LoadPackageList()
        {
            try
            {
                packageList = context.Package.OrderBy(s => s.PackageId).ToList();

            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
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

        private void HandleError(Exception ex)//General Error
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void DisplayProductData()//Method that display data on the text boxes for Products
        {
            txtProduct.Text = selectedProduct.ProdName;
            txtProductFee.Text = selectedProduct.ProdFee.ToString();
        }
        private void DisplayPackageData()//Method that display data on the text boxes for Packages
        {
            txtPkgName.Text = selectedPackage.PkgName;
            txtStartDate.Text = selectedPackage.PkgStartDate.ToShortDateString().ToString();
            txtEndDate.Text = selectedPackage.PkgEndDate.ToShortDateString().ToString();
            txtDescription.Text = selectedPackage.PkgDesc;
            txtBasePrise.Text = selectedPackage.PkgBasePrice.ToString();
            txtCommission.Text = selectedPackage.PkgAgencyCommission.ToString();
        }

        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            if (cmbProductID.Text == "")
            {
                MessageBox.Show("Product Data is Required", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ProductCode = (int)cmbProductID.SelectedValue;
                try
                {
                    selectedProduct = context.Product.Find(ProductCode);

                    if (selectedProduct == null)
                    {
                        MessageBox.Show("No Package found", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        DisplayProductData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                //lbld1.Visible = true;
            }
            


        }

        private void btnGetPackage_Click(object sender, EventArgs e)
        {
            if (cmbPackage.Text == "")
            {
                MessageBox.Show("Package data is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int PkgCode = (int)cmbPackage.SelectedValue;
                try
                {
                    selectedPackage = context.Package.Find(PkgCode);

                    if (selectedPackage == null)
                    {
                        MessageBox.Show("No Package found", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        DisplayPackageData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                //lbld2.Visible = true;
            }
            
        }

        //Load the Customer List
        private void LoadCustomerList()
        {
            try
            {
                customerList = context.Customer.ToList();

            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void LoadComboCustomers()//Load cmboCustomer with data
        {
            cmbCustomerID.DataSource = this.customerList;
            cmbCustomerID.DisplayMember = "CustFirstName";
            cmbCustomerID.ValueMember = "CustomerId";
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if(cmbCustomerID.Text == "")
            {
                MessageBox.Show("Customer data is Required!", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int Customerid = (int)cmbCustomerID.SelectedValue;
                try
                {
                    selectedCustomer = context.Customer.Find(Customerid);

                    if (selectedCustomer == null)
                    {
                        MessageBox.Show("No Package found", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        DisplayCustomerData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void DisplayCustomerData()
        {
            txtFirstName.Text = selectedCustomer.CustFirstName;
            txtLastName.Text = selectedCustomer.CustLastName;
            txtAdress.Text = selectedCustomer.CustAddress.ToString();
            txtEmail.Text = selectedCustomer.CustEmail.ToString();
            txtPhoneNumber.Text = selectedCustomer.CustHomePhone.ToString();
            txtProvince.Text = selectedCustomer.CustProv;
            txtCity.Text = selectedCustomer.CustCity;
            txtPostalCode.Text = selectedCustomer.CustPostal;
            txtCountry.Text = selectedCustomer.CustCountry;

        }

        //Load the Class List
        private void LoadClassList()
        {
            try
            {
                classList = context.Class.ToList();

            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void LoadComboClasses()//Load the clabbCombo with list of classes
        {
            cmbClass.DataSource = this.classList;
            cmbClass.DisplayMember = "ClassName";
            cmbClass.ValueMember = "ClassId";
        }

        private void btnGetClass_Click(object sender, EventArgs e)
        {
            if(cmbClass.Text == "")
            {
                MessageBox.Show("Class data is Required!", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Classid = (string)cmbClass.SelectedValue;
                try
                {
                    selectedClass = context.Class.Find(Classid);

                    if (selectedClass == null)
                    {
                        MessageBox.Show("No Package found", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        DisplayClassData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                //lbld3.Visible = true;
            }
           
        }

        private void DisplayClassData()
        {
            txtClassName.Text = selectedClass.ClassName;
            txtClassDesc.Text = selectedClass.ClassDesc.ToString();
            txtClassFee.Text = selectedClass.ClassFee.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblDate.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtProductFee.Text == "" || txtBasePrise.Text == "" || txtClassFee.Text == "")
            {
                MessageBox.Show("Please, provide all data needs to calculate Total", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                decimal pfee = Convert.ToDecimal(txtProductFee.Text);
                decimal bfee = Convert.ToDecimal(txtBasePrise.Text);
                decimal cfee = Convert.ToDecimal(txtClassFee.Text);
                decimal tax = 0.05m;
                decimal total = pfee + bfee + cfee;
                decimal ttct = total * tax;
                decimal ttc = total + ttct;
                decimal Fttc = Math.Round(ttc, 2);
                lblTotal.Text = Fttc.ToString("");
                lblMoneyIcon.Visible = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            if (Validator.IsNotEmpty(cmbCustomerID, "Customer") &&
                Validator.IsNotEmpty(cmbPackage, "Package Name") &&
                Validator.IsNotEmpty(cmbClass, "Class") &&
                Validator.IsNotEmpty(cmbProductID, "Product") &&
                Validator.IsEmpty(txtFirstName, "Customer") &&
                Validator.IsEmpty(txtClassName, "Class") &&
                Validator.IsEmpty(txtProduct, "Product") &&
                Validator.IsEmpty(txtPkgName, "Package"))
            {
                try
                {
                    AddBooking();
                    AddBookingProduct();
                    MessageBox.Show("Thank you for booking from TravelExperts", "TravelExperts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }

        }

        private void AddBooking()
        {
            selectedBooking = new Booking();
            //selectedBooking.BookingId = Convert.ToInt16(txtBookingID.Text);
            selectedBooking.BookingDate = Convert.ToDateTime(lblDate.Text);
            selectedBooking.CustomerId = Convert.ToInt16(cmbCustomerID.SelectedValue);
            selectedBooking.PackageId = Convert.ToInt16(cmbPackage.SelectedValue);
            selectedBooking.ClassId = cmbClass.SelectedValue.ToString();
            context.Booking.Add(selectedBooking);

            context.SaveChanges();
            txtBookingID.Text = selectedBooking.BookingId.ToString();
        }

        private void AddBookingProduct()
        {

            selectedBookingProduct = new BookingProduct();
            //selectedBookingProduct.Bpid = Convert.ToInt16(txtPBID.Text);
            selectedBookingProduct.ProductId = Convert.ToInt16(cmbProductID.SelectedValue);
            selectedBookingProduct.BookingId = Convert.ToInt16(txtBookingID.Text);
            selectedBookingProduct.FeeAmt = Convert.ToDecimal(lblTotal.Text);
            context.BookingProduct.Add(selectedBookingProduct);
            
            context.SaveChanges();
        }

        private void Reset()
        {
            lblMoneyIcon.Visible = false;
            //clear costumer data
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAdress.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtProvince.Text = "";
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtCity.Text = "";
            //clear class data
            txtClassDesc.Text = "";
            txtClassFee.Text = "";
            txtClassName.Text = "";
            //clear product data
            txtProduct.Text = "";
            txtProductFee.Text = "";
            //clear package data
            txtPkgName.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtDescription.Text = "";
            txtBasePrise.Text = "";
            txtCommission.Text = "";
            cmbClass.Text = "";
            cmbCustomerID.Text = "";
            cmbPackage.Text = "";
            cmbProductID.Text = "";
            lblTotal.Text = "Awaiting values";

        }

        private void productSelectionBtn_Click(object sender, EventArgs e)
        {
            bookingPhase1.Visible = false;
            bookingPhase3.Visible = false;
            bookingPhase2.Visible = true;
            bookingPhase4.Visible = false;
        }

        private void packageSelectionBtn_Click(object sender, EventArgs e)
        {
            bookingPhase1.Visible = true;
            bookingPhase3.Visible = false;
            bookingPhase2.Visible = false;
            bookingPhase4.Visible = false;
        }

        private void classSelectionBtn_Click(object sender, EventArgs e)
        {
            bookingPhase1.Visible = false;
            bookingPhase3.Visible = true;
            bookingPhase2.Visible = false;
            bookingPhase4.Visible = false;
        }

        private void customerSelectionBtn_Click(object sender, EventArgs e)
        {
            bookingPhase1.Visible = false;
            bookingPhase3.Visible = false;
            bookingPhase2.Visible = false;
            bookingPhase4.Visible = true;
        }

        private void bookingPhase2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCalculate_Click1(object sender, EventArgs e)
        {

        }

    }
}
