
namespace TravelExpertGUI
{
    partial class frmAddModifyProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductFee = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addModifyPackageHeading = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.txtPackageID = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Fee:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(201, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Supplier ID:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(21, 258);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(157, 38);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Tag = "Accept";
            this.btnAdd.Text = "Accept";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(201, 258);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductID.Location = new System.Drawing.Point(98, 28);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(71, 16);
            this.txtProductID.TabIndex = 7;
            this.txtProductID.Tag = "Product ID";
            this.txtProductID.Visible = false;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProductName.Location = new System.Drawing.Point(21, 132);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(338, 23);
            this.txtProductName.TabIndex = 8;
            this.txtProductName.Tag = "Product Name";
            // 
            // txtProductFee
            // 
            this.txtProductFee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductFee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductFee.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProductFee.Location = new System.Drawing.Point(21, 203);
            this.txtProductFee.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductFee.Name = "txtProductFee";
            this.txtProductFee.Size = new System.Drawing.Size(157, 23);
            this.txtProductFee.TabIndex = 9;
            this.txtProductFee.Tag = "Product Fee";
            this.txtProductFee.TextChanged += new System.EventHandler(this.txtProductFee_TextChanged);
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSupplierID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierID.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSupplierID.Location = new System.Drawing.Point(201, 203);
            this.txtSupplierID.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(158, 23);
            this.txtSupplierID.TabIndex = 10;
            this.txtSupplierID.Tag = "Supplier ID";
            this.txtSupplierID.TextChanged += new System.EventHandler(this.txtSupplierID_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.addModifyPackageHeading);
            this.panel2.Controls.Add(this.iconPictureBox2);
            this.panel2.Controls.Add(this.txtPackageID);
            this.panel2.Controls.Add(this.txtProductID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 75);
            this.panel2.TabIndex = 42;
            // 
            // addModifyPackageHeading
            // 
            this.addModifyPackageHeading.Font = new System.Drawing.Font("Dubai", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addModifyPackageHeading.ForeColor = System.Drawing.Color.White;
            this.addModifyPackageHeading.Location = new System.Drawing.Point(133, 7);
            this.addModifyPackageHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.addModifyPackageHeading.Name = "addModifyPackageHeading";
            this.addModifyPackageHeading.Size = new System.Drawing.Size(237, 61);
            this.addModifyPackageHeading.TabIndex = 40;
            this.addModifyPackageHeading.Text = "Add a new product";
            this.addModifyPackageHeading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 59;
            this.iconPictureBox2.Location = new System.Drawing.Point(9, 9);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(73, 59);
            this.iconPictureBox2.TabIndex = 0;
            this.iconPictureBox2.TabStop = false;
            // 
            // txtPackageID
            // 
            this.txtPackageID.BackColor = System.Drawing.Color.DimGray;
            this.txtPackageID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageID.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPackageID.Location = new System.Drawing.Point(109, 20);
            this.txtPackageID.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackageID.MaxLength = 10;
            this.txtPackageID.Multiline = true;
            this.txtPackageID.Name = "txtPackageID";
            this.txtPackageID.Size = new System.Drawing.Size(60, 34);
            this.txtPackageID.TabIndex = 99999999;
            this.txtPackageID.Tag = "Code";
            this.txtPackageID.Visible = false;
            // 
            // frmAddModifyProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 307);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.txtProductFee);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddModifyProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModifyProduct";
            this.Load += new System.EventHandler(this.frmAddModifyProduct_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductFee;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label addModifyPackageHeading;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.TextBox txtPackageID;
    }
}