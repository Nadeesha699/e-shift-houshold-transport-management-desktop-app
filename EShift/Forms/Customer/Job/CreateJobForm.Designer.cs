namespace EShift.Forms
{
    partial class CreateJobForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pickup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_destination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRequestedDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.txt_itemdescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btn_removeItem = new System.Windows.Forms.Button();
            this.btn_addItem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_profile = new FontAwesome.Sharp.IconButton();
            this.btn_logout = new FontAwesome.Sharp.IconButton();
            this.btn_myJobs = new FontAwesome.Sharp.IconButton();
            this.btn_createJob = new FontAwesome.Sharp.IconButton();
            this.btn_dashboard = new FontAwesome.Sharp.IconButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Create Job";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(328, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Create and submit a new household goods transport booking";
            // 
            // txt_pickup
            // 
            this.txt_pickup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_pickup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pickup.Location = new System.Drawing.Point(332, 150);
            this.txt_pickup.Name = "txt_pickup";
            this.txt_pickup.Size = new System.Drawing.Size(263, 30);
            this.txt_pickup.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(329, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Pickup Location";
            // 
            // txt_destination
            // 
            this.txt_destination.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_destination.Location = new System.Drawing.Point(615, 150);
            this.txt_destination.Name = "txt_destination";
            this.txt_destination.Size = new System.Drawing.Size(276, 30);
            this.txt_destination.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(611, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(922, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Requested Transport Date";
            // 
            // dtpRequestedDate
            // 
            this.dtpRequestedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequestedDate.Location = new System.Drawing.Point(926, 148);
            this.dtpRequestedDate.Name = "dtpRequestedDate";
            this.dtpRequestedDate.Size = new System.Drawing.Size(416, 30);
            this.dtpRequestedDate.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(611, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Select a household product";
            // 
            // cmbProduct
            // 
            this.cmbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(615, 228);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(276, 33);
            this.cmbProduct.TabIndex = 49;
            // 
            // txt_itemdescription
            // 
            this.txt_itemdescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_itemdescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemdescription.Location = new System.Drawing.Point(335, 231);
            this.txt_itemdescription.Name = "txt_itemdescription";
            this.txt_itemdescription.Size = new System.Drawing.Size(260, 30);
            this.txt_itemdescription.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(331, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Custom Item Name";
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.Location = new System.Drawing.Point(926, 228);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(75, 30);
            this.numQuantity.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(922, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Quantity";
            // 
            // numWeight
            // 
            this.numWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWeight.Location = new System.Drawing.Point(1036, 228);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(306, 30);
            this.numWeight.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(1032, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 20);
            this.label9.TabIndex = 55;
            this.label9.Text = "Weight per Item (kg)";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(335, 411);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(1012, 372);
            this.dgvItems.TabIndex = 56;
            // 
            // btn_removeItem
            // 
            this.btn_removeItem.BackColor = System.Drawing.Color.Crimson;
            this.btn_removeItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeItem.ForeColor = System.Drawing.Color.White;
            this.btn_removeItem.Location = new System.Drawing.Point(780, 302);
            this.btn_removeItem.Name = "btn_removeItem";
            this.btn_removeItem.Size = new System.Drawing.Size(172, 42);
            this.btn_removeItem.TabIndex = 58;
            this.btn_removeItem.Text = "Remove item";
            this.btn_removeItem.UseVisualStyleBackColor = false;
            this.btn_removeItem.Click += new System.EventHandler(this.btn_removeItem_Click);
            // 
            // btn_addItem
            // 
            this.btn_addItem.BackColor = System.Drawing.Color.Navy;
            this.btn_addItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addItem.ForeColor = System.Drawing.Color.White;
            this.btn_addItem.Location = new System.Drawing.Point(591, 302);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(172, 42);
            this.btn_addItem.TabIndex = 59;
            this.btn_addItem.Text = "Add item";
            this.btn_addItem.UseVisualStyleBackColor = false;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btn_profile);
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_myJobs);
            this.panel1.Controls.Add(this.btn_createJob);
            this.panel1.Controls.Add(this.btn_dashboard);
            this.panel1.Location = new System.Drawing.Point(-11, -58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 922);
            this.panel1.TabIndex = 62;
            // 
            // btn_profile
            // 
            this.btn_profile.BackColor = System.Drawing.Color.Transparent;
            this.btn_profile.FlatAppearance.BorderSize = 0;
            this.btn_profile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_profile.ForeColor = System.Drawing.Color.Transparent;
            this.btn_profile.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btn_profile.IconColor = System.Drawing.Color.White;
            this.btn_profile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_profile.IconSize = 24;
            this.btn_profile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_profile.Location = new System.Drawing.Point(12, 242);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(295, 57);
            this.btn_profile.TabIndex = 51;
            this.btn_profile.Text = "My Profile";
            this.btn_profile.UseVisualStyleBackColor = false;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.Transparent;
            this.btn_logout.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btn_logout.IconColor = System.Drawing.Color.White;
            this.btn_logout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_logout.IconSize = 24;
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(12, 305);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(295, 65);
            this.btn_logout.TabIndex = 50;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_myJobs
            // 
            this.btn_myJobs.BackColor = System.Drawing.Color.Transparent;
            this.btn_myJobs.FlatAppearance.BorderSize = 0;
            this.btn_myJobs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_myJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_myJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_myJobs.ForeColor = System.Drawing.Color.Transparent;
            this.btn_myJobs.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btn_myJobs.IconColor = System.Drawing.Color.White;
            this.btn_myJobs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_myJobs.IconSize = 24;
            this.btn_myJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_myJobs.Location = new System.Drawing.Point(12, 179);
            this.btn_myJobs.Name = "btn_myJobs";
            this.btn_myJobs.Size = new System.Drawing.Size(295, 57);
            this.btn_myJobs.TabIndex = 8;
            this.btn_myJobs.Text = "My Jobs";
            this.btn_myJobs.UseVisualStyleBackColor = false;
            this.btn_myJobs.Click += new System.EventHandler(this.btn_myJobs_Click);
            // 
            // btn_createJob
            // 
            this.btn_createJob.BackColor = System.Drawing.Color.MediumBlue;
            this.btn_createJob.FlatAppearance.BorderSize = 0;
            this.btn_createJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_createJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createJob.ForeColor = System.Drawing.Color.Transparent;
            this.btn_createJob.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btn_createJob.IconColor = System.Drawing.Color.White;
            this.btn_createJob.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_createJob.IconSize = 24;
            this.btn_createJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_createJob.Location = new System.Drawing.Point(12, 116);
            this.btn_createJob.Name = "btn_createJob";
            this.btn_createJob.Size = new System.Drawing.Size(295, 57);
            this.btn_createJob.TabIndex = 5;
            this.btn_createJob.Text = "Create Job";
            this.btn_createJob.UseVisualStyleBackColor = false;
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.FlatAppearance.BorderSize = 0;
            this.btn_dashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btn_dashboard.IconColor = System.Drawing.Color.White;
            this.btn_dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_dashboard.IconSize = 24;
            this.btn_dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dashboard.Location = new System.Drawing.Point(12, 59);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(292, 68);
            this.btn_dashboard.TabIndex = 1;
            this.btn_dashboard.Text = "Dashboard";
            this.btn_dashboard.UseVisualStyleBackColor = false;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(331, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 63;
            this.label10.Text = "Load Items";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.Window;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear.Location = new System.Drawing.Point(1169, 302);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(176, 42);
            this.btn_clear.TabIndex = 65;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Navy;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(975, 302);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(172, 42);
            this.btn_submit.TabIndex = 64;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            // 
            // CreateJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1383, 806);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_addItem);
            this.Controls.Add(this.btn_removeItem);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.txt_itemdescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpRequestedDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_destination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_pickup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.CreateJobForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pickup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_destination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRequestedDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.TextBox txt_itemdescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btn_removeItem;
        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_profile;
        private FontAwesome.Sharp.IconButton btn_logout;
        private FontAwesome.Sharp.IconButton btn_myJobs;
        private FontAwesome.Sharp.IconButton btn_createJob;
        private FontAwesome.Sharp.IconButton btn_dashboard;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_submit;
    }
}