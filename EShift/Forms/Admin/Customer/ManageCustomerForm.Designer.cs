namespace EShift.Forms
{
    partial class ManageCustomerForm
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_close = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_refresh = new FontAwesome.Sharp.IconButton();
            this.btn_view = new FontAwesome.Sharp.IconButton();
            this.btn_edit = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_profile = new FontAwesome.Sharp.IconButton();
            this.btn_logout = new FontAwesome.Sharp.IconButton();
            this.btn_reports = new FontAwesome.Sharp.IconButton();
            this.btn_manageTransport = new FontAwesome.Sharp.IconButton();
            this.btn_manageContainers = new FontAwesome.Sharp.IconButton();
            this.btn_manageLorries = new FontAwesome.Sharp.IconButton();
            this.btn_manageAssistants = new FontAwesome.Sharp.IconButton();
            this.btn_manageDrivers = new FontAwesome.Sharp.IconButton();
            this.btn_manageJobs = new FontAwesome.Sharp.IconButton();
            this.btn_manageProducts = new FontAwesome.Sharp.IconButton();
            this.btn_manageCustomers = new FontAwesome.Sharp.IconButton();
            this.btn_manageUsers = new FontAwesome.Sharp.IconButton();
            this.btn_dashboard = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Manage Customers";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(340, 294);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(1007, 476);
            this.dgvCustomers.TabIndex = 20;
            // 
            // txt_search
            // 
            this.txt_search.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(366, 238);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(900, 30);
            this.txt_search.TabIndex = 30;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btn_close.IconColor = System.Drawing.Color.Navy;
            this.btn_close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_close.IconSize = 24;
            this.btn_close.Location = new System.Drawing.Point(329, 238);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(36, 34);
            this.btn_close.TabIndex = 31;
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(362, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Search by Name or Email";
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_refresh.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btn_refresh.IconColor = System.Drawing.Color.Indigo;
            this.btn_refresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_refresh.IconSize = 27;
            this.btn_refresh.Location = new System.Drawing.Point(1272, 236);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(74, 32);
            this.btn_refresh.TabIndex = 33;
            this.btn_refresh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_view
            // 
            this.btn_view.BackColor = System.Drawing.Color.Navy;
            this.btn_view.FlatAppearance.BorderSize = 0;
            this.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_view.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btn_view.IconColor = System.Drawing.Color.White;
            this.btn_view.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_view.IconSize = 24;
            this.btn_view.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_view.Location = new System.Drawing.Point(332, 115);
            this.btn_view.Name = "btn_view";
            this.btn_view.Padding = new System.Windows.Forms.Padding(5);
            this.btn_view.Size = new System.Drawing.Size(504, 80);
            this.btn_view.TabIndex = 36;
            this.btn_view.Text = "View Customer";
            this.btn_view.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_view.UseVisualStyleBackColor = false;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_edit.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.btn_edit.IconColor = System.Drawing.Color.White;
            this.btn_edit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_edit.IconSize = 24;
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_edit.Location = new System.Drawing.Point(854, 115);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Padding = new System.Windows.Forms.Padding(5);
            this.btn_edit.Size = new System.Drawing.Size(493, 80);
            this.btn_edit.TabIndex = 37;
            this.btn_edit.Text = "Edit Customer";
            this.btn_edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(328, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Manage Customer Details and Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btn_profile);
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_reports);
            this.panel1.Controls.Add(this.btn_manageTransport);
            this.panel1.Controls.Add(this.btn_manageContainers);
            this.panel1.Controls.Add(this.btn_manageLorries);
            this.panel1.Controls.Add(this.btn_manageAssistants);
            this.panel1.Controls.Add(this.btn_manageDrivers);
            this.panel1.Controls.Add(this.btn_manageJobs);
            this.panel1.Controls.Add(this.btn_manageProducts);
            this.panel1.Controls.Add(this.btn_manageCustomers);
            this.panel1.Controls.Add(this.btn_manageUsers);
            this.panel1.Controls.Add(this.btn_dashboard);
            this.panel1.Location = new System.Drawing.Point(-4, -58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 922);
            this.panel1.TabIndex = 41;
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
            this.btn_profile.Location = new System.Drawing.Point(10, 739);
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
            this.btn_logout.Location = new System.Drawing.Point(7, 799);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(295, 70);
            this.btn_logout.TabIndex = 50;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_reports
            // 
            this.btn_reports.BackColor = System.Drawing.Color.Transparent;
            this.btn_reports.FlatAppearance.BorderSize = 0;
            this.btn_reports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reports.ForeColor = System.Drawing.Color.Transparent;
            this.btn_reports.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btn_reports.IconColor = System.Drawing.Color.White;
            this.btn_reports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_reports.IconSize = 24;
            this.btn_reports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reports.Location = new System.Drawing.Point(10, 683);
            this.btn_reports.Name = "btn_reports";
            this.btn_reports.Size = new System.Drawing.Size(295, 57);
            this.btn_reports.TabIndex = 11;
            this.btn_reports.Text = "Reports";
            this.btn_reports.UseVisualStyleBackColor = false;
            this.btn_reports.Click += new System.EventHandler(this.btn_reports_Click);
            // 
            // btn_manageTransport
            // 
            this.btn_manageTransport.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageTransport.FlatAppearance.BorderSize = 0;
            this.btn_manageTransport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageTransport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageTransport.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageTransport.IconChar = FontAwesome.Sharp.IconChar.TruckFast;
            this.btn_manageTransport.IconColor = System.Drawing.Color.White;
            this.btn_manageTransport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageTransport.IconSize = 24;
            this.btn_manageTransport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageTransport.Location = new System.Drawing.Point(10, 620);
            this.btn_manageTransport.Name = "btn_manageTransport";
            this.btn_manageTransport.Size = new System.Drawing.Size(295, 57);
            this.btn_manageTransport.TabIndex = 10;
            this.btn_manageTransport.Text = "Transport";
            this.btn_manageTransport.UseVisualStyleBackColor = false;
            this.btn_manageTransport.Click += new System.EventHandler(this.btn_manageTransport_Click);
            // 
            // btn_manageContainers
            // 
            this.btn_manageContainers.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageContainers.FlatAppearance.BorderSize = 0;
            this.btn_manageContainers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageContainers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageContainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageContainers.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageContainers.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            this.btn_manageContainers.IconColor = System.Drawing.Color.White;
            this.btn_manageContainers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageContainers.IconSize = 24;
            this.btn_manageContainers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageContainers.Location = new System.Drawing.Point(10, 557);
            this.btn_manageContainers.Name = "btn_manageContainers";
            this.btn_manageContainers.Size = new System.Drawing.Size(295, 57);
            this.btn_manageContainers.TabIndex = 9;
            this.btn_manageContainers.Text = "Containers";
            this.btn_manageContainers.UseVisualStyleBackColor = false;
            this.btn_manageContainers.Click += new System.EventHandler(this.btn_manageContainers_Click);
            // 
            // btn_manageLorries
            // 
            this.btn_manageLorries.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageLorries.FlatAppearance.BorderSize = 0;
            this.btn_manageLorries.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageLorries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageLorries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageLorries.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageLorries.IconChar = FontAwesome.Sharp.IconChar.TruckMoving;
            this.btn_manageLorries.IconColor = System.Drawing.Color.White;
            this.btn_manageLorries.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageLorries.IconSize = 24;
            this.btn_manageLorries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageLorries.Location = new System.Drawing.Point(10, 494);
            this.btn_manageLorries.Name = "btn_manageLorries";
            this.btn_manageLorries.Size = new System.Drawing.Size(295, 57);
            this.btn_manageLorries.TabIndex = 8;
            this.btn_manageLorries.Text = "Lorries";
            this.btn_manageLorries.UseVisualStyleBackColor = false;
            this.btn_manageLorries.Click += new System.EventHandler(this.btn_manageLorries_Click);
            // 
            // btn_manageAssistants
            // 
            this.btn_manageAssistants.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageAssistants.FlatAppearance.BorderSize = 0;
            this.btn_manageAssistants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageAssistants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageAssistants.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageAssistants.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageAssistants.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btn_manageAssistants.IconColor = System.Drawing.Color.White;
            this.btn_manageAssistants.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageAssistants.IconSize = 24;
            this.btn_manageAssistants.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageAssistants.Location = new System.Drawing.Point(7, 431);
            this.btn_manageAssistants.Name = "btn_manageAssistants";
            this.btn_manageAssistants.Size = new System.Drawing.Size(295, 57);
            this.btn_manageAssistants.TabIndex = 7;
            this.btn_manageAssistants.Text = "Assistants";
            this.btn_manageAssistants.UseVisualStyleBackColor = false;
            this.btn_manageAssistants.Click += new System.EventHandler(this.btn_manageAssistants_Click);
            // 
            // btn_manageDrivers
            // 
            this.btn_manageDrivers.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageDrivers.FlatAppearance.BorderSize = 0;
            this.btn_manageDrivers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageDrivers.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageDrivers.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.btn_manageDrivers.IconColor = System.Drawing.Color.White;
            this.btn_manageDrivers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageDrivers.IconSize = 24;
            this.btn_manageDrivers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageDrivers.Location = new System.Drawing.Point(7, 368);
            this.btn_manageDrivers.Name = "btn_manageDrivers";
            this.btn_manageDrivers.Size = new System.Drawing.Size(295, 57);
            this.btn_manageDrivers.TabIndex = 6;
            this.btn_manageDrivers.Text = "Drivers";
            this.btn_manageDrivers.UseVisualStyleBackColor = false;
            this.btn_manageDrivers.Click += new System.EventHandler(this.btn_manageDrivers_Click);
            // 
            // btn_manageJobs
            // 
            this.btn_manageJobs.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageJobs.FlatAppearance.BorderSize = 0;
            this.btn_manageJobs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageJobs.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageJobs.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btn_manageJobs.IconColor = System.Drawing.Color.White;
            this.btn_manageJobs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageJobs.IconSize = 24;
            this.btn_manageJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageJobs.Location = new System.Drawing.Point(7, 305);
            this.btn_manageJobs.Name = "btn_manageJobs";
            this.btn_manageJobs.Size = new System.Drawing.Size(295, 57);
            this.btn_manageJobs.TabIndex = 5;
            this.btn_manageJobs.Text = "Jobs";
            this.btn_manageJobs.UseVisualStyleBackColor = false;
            this.btn_manageJobs.Click += new System.EventHandler(this.btn_manageJobs_Click);
            // 
            // btn_manageProducts
            // 
            this.btn_manageProducts.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageProducts.FlatAppearance.BorderSize = 0;
            this.btn_manageProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageProducts.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageProducts.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.btn_manageProducts.IconColor = System.Drawing.Color.White;
            this.btn_manageProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageProducts.IconSize = 24;
            this.btn_manageProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageProducts.Location = new System.Drawing.Point(7, 242);
            this.btn_manageProducts.Name = "btn_manageProducts";
            this.btn_manageProducts.Size = new System.Drawing.Size(295, 57);
            this.btn_manageProducts.TabIndex = 4;
            this.btn_manageProducts.Text = "Products";
            this.btn_manageProducts.UseVisualStyleBackColor = false;
            this.btn_manageProducts.Click += new System.EventHandler(this.btn_manageProducts_Click);
            // 
            // btn_manageCustomers
            // 
            this.btn_manageCustomers.BackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageCustomers.FlatAppearance.BorderSize = 0;
            this.btn_manageCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageCustomers.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageCustomers.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btn_manageCustomers.IconColor = System.Drawing.Color.White;
            this.btn_manageCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageCustomers.IconSize = 24;
            this.btn_manageCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageCustomers.Location = new System.Drawing.Point(7, 179);
            this.btn_manageCustomers.Name = "btn_manageCustomers";
            this.btn_manageCustomers.Size = new System.Drawing.Size(295, 57);
            this.btn_manageCustomers.TabIndex = 3;
            this.btn_manageCustomers.Text = "Customers";
            this.btn_manageCustomers.UseVisualStyleBackColor = false;
            // 
            // btn_manageUsers
            // 
            this.btn_manageUsers.BackColor = System.Drawing.Color.Transparent;
            this.btn_manageUsers.FlatAppearance.BorderSize = 0;
            this.btn_manageUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.btn_manageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manageUsers.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manageUsers.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btn_manageUsers.IconColor = System.Drawing.Color.White;
            this.btn_manageUsers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_manageUsers.IconSize = 24;
            this.btn_manageUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manageUsers.Location = new System.Drawing.Point(7, 120);
            this.btn_manageUsers.Name = "btn_manageUsers";
            this.btn_manageUsers.Size = new System.Drawing.Size(295, 57);
            this.btn_manageUsers.TabIndex = 2;
            this.btn_manageUsers.Text = "Users";
            this.btn_manageUsers.UseVisualStyleBackColor = false;
            this.btn_manageUsers.Click += new System.EventHandler(this.btn_manageUsers_Click);
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.FlatAppearance.BorderSize = 0;
            this.btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btn_dashboard.IconColor = System.Drawing.Color.White;
            this.btn_dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_dashboard.IconSize = 24;
            this.btn_dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dashboard.Location = new System.Drawing.Point(7, 59);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(292, 68);
            this.btn_dashboard.TabIndex = 1;
            this.btn_dashboard.Text = "Dashboard";
            this.btn_dashboard.UseVisualStyleBackColor = false;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // ManageCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1383, 806);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.TextBox txt_search;
        private FontAwesome.Sharp.IconButton btn_close;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btn_refresh;
        private FontAwesome.Sharp.IconButton btn_view;
        private FontAwesome.Sharp.IconButton btn_edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_profile;
        private FontAwesome.Sharp.IconButton btn_logout;
        private FontAwesome.Sharp.IconButton btn_reports;
        private FontAwesome.Sharp.IconButton btn_manageTransport;
        private FontAwesome.Sharp.IconButton btn_manageContainers;
        private FontAwesome.Sharp.IconButton btn_manageLorries;
        private FontAwesome.Sharp.IconButton btn_manageAssistants;
        private FontAwesome.Sharp.IconButton btn_manageDrivers;
        private FontAwesome.Sharp.IconButton btn_manageJobs;
        private FontAwesome.Sharp.IconButton btn_manageProducts;
        private FontAwesome.Sharp.IconButton btn_manageCustomers;
        private FontAwesome.Sharp.IconButton btn_manageUsers;
        private FontAwesome.Sharp.IconButton btn_dashboard;
    }
}