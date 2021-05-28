namespace TravelExpertGUI
{
    partial class frmAddModifyPackage
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
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addModifyPackageHeading = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.txtPackageID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.textPackageEndDate = new System.Windows.Forms.TextBox();
            this.textPackageCommission = new System.Windows.Forms.TextBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.textPackageStartDate = new System.Windows.Forms.TextBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.textPackagePrice = new System.Windows.Forms.TextBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.textPackageDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPackageName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(542, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 38;
            this.label8.Text = "Commission";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 67);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.addModifyPackageHeading);
            this.panel2.Controls.Add(this.iconPictureBox2);
            this.panel2.Controls.Add(this.txtPackageID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 75);
            this.panel2.TabIndex = 41;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // addModifyPackageHeading
            // 
            this.addModifyPackageHeading.Font = new System.Drawing.Font("Dubai", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addModifyPackageHeading.ForeColor = System.Drawing.Color.White;
            this.addModifyPackageHeading.Location = new System.Drawing.Point(205, 8);
            this.addModifyPackageHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.addModifyPackageHeading.Name = "addModifyPackageHeading";
            this.addModifyPackageHeading.Size = new System.Drawing.Size(464, 61);
            this.addModifyPackageHeading.TabIndex = 40;
            this.addModifyPackageHeading.Text = "Add a new package";
            this.addModifyPackageHeading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addModifyPackageHeading.Click += new System.EventHandler(this.label10_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Globe;
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
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(131, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 26);
            this.label7.TabIndex = 40;
            this.label7.Text = "Add a new package";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Globe;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 65;
            this.iconPictureBox1.Location = new System.Drawing.Point(13, 12);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(69, 65);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(375, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 26);
            this.label6.TabIndex = 36;
            this.label6.Text = "Price";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(375, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 26);
            this.label4.TabIndex = 32;
            this.label4.Text = "Start date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.iconPictureBox6);
            this.panel4.Controls.Add(this.textPackageEndDate);
            this.panel4.Controls.Add(this.textPackageCommission);
            this.panel4.Controls.Add(this.iconPictureBox5);
            this.panel4.Controls.Add(this.textPackageStartDate);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.iconPictureBox4);
            this.panel4.Controls.Add(this.textPackagePrice);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.iconPictureBox3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textPackageDescription);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.textPackageName);
            this.panel4.Controls.Add(this.btnAccept);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(682, 292);
            this.panel4.TabIndex = 43;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox6.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.Percent;
            this.iconPictureBox6.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox6.IconSize = 26;
            this.iconPictureBox6.Location = new System.Drawing.Point(516, 13);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(45, 26);
            this.iconPictureBox6.TabIndex = 45;
            this.iconPictureBox6.TabStop = false;
            // 
            // textPackageEndDate
            // 
            this.textPackageEndDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPackageEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPackageEndDate.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPackageEndDate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPackageEndDate.Location = new System.Drawing.Point(346, 188);
            this.textPackageEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.textPackageEndDate.MaxLength = 30;
            this.textPackageEndDate.Multiline = true;
            this.textPackageEndDate.Name = "textPackageEndDate";
            this.textPackageEndDate.Size = new System.Drawing.Size(316, 23);
            this.textPackageEndDate.TabIndex = 6;
            this.textPackageEndDate.Tag = "Price";
            // 
            // textPackageCommission
            // 
            this.textPackageCommission.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPackageCommission.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPackageCommission.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPackageCommission.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPackageCommission.Location = new System.Drawing.Point(516, 40);
            this.textPackageCommission.Margin = new System.Windows.Forms.Padding(4);
            this.textPackageCommission.MaxLength = 30;
            this.textPackageCommission.Multiline = true;
            this.textPackageCommission.Name = "textPackageCommission";
            this.textPackageCommission.Size = new System.Drawing.Size(146, 23);
            this.textPackageCommission.TabIndex = 4;
            this.textPackageCommission.Tag = "Price";
            this.textPackageCommission.TextChanged += new System.EventHandler(this.textPackageCommission_TextChanged);
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.iconPictureBox5.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 29;
            this.iconPictureBox5.Location = new System.Drawing.Point(346, 154);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(33, 29);
            this.iconPictureBox5.TabIndex = 44;
            this.iconPictureBox5.TabStop = false;
            this.iconPictureBox5.Click += new System.EventHandler(this.iconPictureBox5_Click);
            // 
            // textPackageStartDate
            // 
            this.textPackageStartDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPackageStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPackageStartDate.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPackageStartDate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPackageStartDate.Location = new System.Drawing.Point(346, 113);
            this.textPackageStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.textPackageStartDate.MaxLength = 30;
            this.textPackageStartDate.Multiline = true;
            this.textPackageStartDate.Name = "textPackageStartDate";
            this.textPackageStartDate.Size = new System.Drawing.Size(317, 23);
            this.textPackageStartDate.TabIndex = 5;
            this.textPackageStartDate.Tag = "Price";
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 29;
            this.iconPictureBox4.Location = new System.Drawing.Point(346, 80);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(33, 29);
            this.iconPictureBox4.TabIndex = 43;
            this.iconPictureBox4.TabStop = false;
            // 
            // textPackagePrice
            // 
            this.textPackagePrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPackagePrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPackagePrice.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPackagePrice.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPackagePrice.Location = new System.Drawing.Point(346, 40);
            this.textPackagePrice.Margin = new System.Windows.Forms.Padding(4);
            this.textPackagePrice.MaxLength = 30;
            this.textPackagePrice.Multiline = true;
            this.textPackagePrice.Name = "textPackagePrice";
            this.textPackagePrice.Size = new System.Drawing.Size(147, 23);
            this.textPackagePrice.TabIndex = 3;
            this.textPackagePrice.Tag = "Price";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 36;
            this.iconPictureBox3.Location = new System.Drawing.Point(342, 13);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(46, 36);
            this.iconPictureBox3.TabIndex = 41;
            this.iconPictureBox3.TabStop = false;
            // 
            // textPackageDescription
            // 
            this.textPackageDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPackageDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPackageDescription.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPackageDescription.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPackageDescription.Location = new System.Drawing.Point(19, 107);
            this.textPackageDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textPackageDescription.MaxLength = 200;
            this.textPackageDescription.Multiline = true;
            this.textPackageDescription.Name = "textPackageDescription";
            this.textPackageDescription.Size = new System.Drawing.Size(316, 104);
            this.textPackageDescription.TabIndex = 2;
            this.textPackageDescription.Tag = "Description";
            this.textPackageDescription.TextChanged += new System.EventHandler(this.textPackageDescription_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(375, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 26);
            this.label5.TabIndex = 34;
            this.label5.Text = "End date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textPackageName
            // 
            this.textPackageName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPackageName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPackageName.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPackageName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPackageName.Location = new System.Drawing.Point(19, 42);
            this.textPackageName.Margin = new System.Windows.Forms.Padding(4);
            this.textPackageName.MaxLength = 50;
            this.textPackageName.Multiline = true;
            this.textPackageName.Name = "textPackageName";
            this.textPackageName.Size = new System.Drawing.Size(316, 23);
            this.textPackageName.TabIndex = 1;
            this.textPackageName.Tag = "Price";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(19, 230);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(316, 43);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(346, 230);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(317, 43);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 30;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAddModifyPackage
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(682, 360);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddModifyPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.frmAddModifyProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textPackageDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPackageName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox textPackageEndDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textPackageStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPackagePrice;
        private System.Windows.Forms.TextBox textPackageCommission;
        private System.Windows.Forms.TextBox txtPackageID;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.Label addModifyPackageHeading;
    }
}