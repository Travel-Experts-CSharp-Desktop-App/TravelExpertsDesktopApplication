using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TravelExpertData;


namespace TravelExperts
{


    public partial class FrmMainMenu : Form
    {
        private FontAwesome.Sharp.IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public FrmMainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 42);
            panelMenu.Controls.Add(leftBorderBtn);
            // FORM
            this.Text = string.Empty;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172,126,241);
            public static Color color2 = Color.FromArgb(149, 88, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(236, 100, 8);
            public static Color color7 = Color.FromArgb(49, 188, 10);
            public static Color color8 = Color.FromArgb(30, 221, 41);
            public static Color color9 = Color.FromArgb(255, 21, 111);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                // Button
                currentBtn = (FontAwesome.Sharp.IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 68);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if(currentBtn != null)
            {
                // Button
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }


        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                // Open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelCurrentChildForm.Text = childForm.Text;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void mainMenuAgency_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new TravelExpertGUI.frmAgency());
        }

        private void mainMenuAgent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new TravelExpertGUI.FrmAgent());
        }

        private void mainMenuProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new TravelExpertGUI.frmProduct());
        }

        private void mainMenuSuppliers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new TravelExpertGUI.FrmSuppliers());

        }

        private void mainMenuBookings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new TravelExpertGUI.FrmBooking());
        }

        private void mainMenuPackages_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new TravelExpertGUI.FrmPackages());
        }

        private void mainMenuCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new TravelExpertGUI.frmCustomer());
        }

        private void mainMenuHelp_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            OpenChildForm(new TravelExpertGUI.frmHelp());
        }

        private void mainMenuLogo_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            iconCurrentChildForm.IconColor = Color.White;
            labelCurrentChildForm.Text = "Home";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void pageBreadcrumbs_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void exitApplication_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void maximizeApplication_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void minimizeApplication_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }



        private void closeApplication_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void logoutApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            TravelExpertGUI.FrmLogin formMain = new TravelExpertGUI.FrmLogin();
            formMain.ShowDialog();
        }

        private void packageButton_Click(object sender, EventArgs e)
        {
            ActivateButton(mainMenuPackages, RGBColors.color6);
            OpenChildForm(new TravelExpertGUI.FrmPackages());
        }

        private void supplierButton_Click(object sender, EventArgs e)
        {
            ActivateButton(mainMenuSuppliers, RGBColors.color4);
            OpenChildForm(new TravelExpertGUI.FrmSuppliers());

        }

        private void productsButton_Click(object sender, EventArgs e)
        {
            ActivateButton(mainMenuProducts, RGBColors.color3);
            OpenChildForm(new TravelExpertGUI.frmProduct());
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            ActivateButton(mainMenuHelp, RGBColors.color7);
            OpenChildForm(new TravelExpertGUI.frmHelp());
        }

        private void createABooking_click(object sender, EventArgs e)
        {
            ActivateButton(mainMenuBookings, RGBColors.color5);
            OpenChildForm(new TravelExpertGUI.FrmBooking());
        }
    }
}
