namespace EShift.Forms.Admin
{
    partial class ReportsForm
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
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.btn_generate = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reports";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(330, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Generate reports on jobs, customers, and transport resources.";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Gray;
            this.lblRecordCount.Location = new System.Drawing.Point(809, 213);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(143, 20);
            this.lblRecordCount.TabIndex = 41;
            this.lblRecordCount.Text = "Pickup Location";
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblReportTitle.Location = new System.Drawing.Point(593, 213);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(105, 20);
            this.lblReportTitle.TabIndex = 43;
            this.lblReportTitle.Text = "Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(631, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(635, 147);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(342, 30);
            this.dtpStartDate.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(330, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Select the Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(334, 148);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(276, 33);
            this.cmbReportType.TabIndex = 49;
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(334, 261);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.RowTemplate.Height = 24;
            this.dgvReports.Size = new System.Drawing.Size(1013, 509);
            this.dgvReports.TabIndex = 56;
            // 
            // btn_generate
            // 
            this.btn_generate.BackColor = System.Drawing.Color.Crimson;
            this.btn_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generate.ForeColor = System.Drawing.Color.White;
            this.btn_generate.Location = new System.Drawing.Point(986, 191);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(172, 42);
            this.btn_generate.TabIndex = 58;
            this.btn_generate.Text = "Generate Report";
            this.btn_generate.UseVisualStyleBackColor = false;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.Navy;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.Location = new System.Drawing.Point(1175, 191);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(172, 42);
            this.btn_export.TabIndex = 59;
            this.btn_export.Text = "Export PDF";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(1004, 144);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(343, 30);
            this.dtpEndDate.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(1000, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "End Date";
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
            this.panel1.Location = new System.Drawing.Point(-1, -58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 922);
            this.panel1.TabIndex = 64;
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
            this.btn_profile.Location = new System.Drawing.Point(3, 739);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(302, 57);
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
            this.btn_logout.Size = new System.Drawing.Size(295, 66);
            this.btn_logout.TabIndex = 50;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_reports
            // 
            this.btn_reports.BackColor = System.Drawing.Color.MediumBlue;
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
            this.btn_reports.Location = new System.Drawing.Point(0, 683);
            this.btn_reports.Name = "btn_reports";
            this.btn_reports.Size = new System.Drawing.Size(305, 57);
            this.btn_reports.TabIndex = 11;
            this.btn_reports.Text = "Reports";
            this.btn_reports.UseVisualStyleBackColor = false;
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
            this.btn_manageTransport.Location = new System.Drawing.Point(3, 620);
            this.btn_manageTransport.Name = "btn_manageTransport";
            this.btn_manageTransport.Size = new System.Drawing.Size(302, 57);
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
            this.btn_manageContainers.Location = new System.Drawing.Point(3, 557);
            this.btn_manageContainers.Name = "btn_manageContainers";
            this.btn_manageContainers.Size = new System.Drawing.Size(302, 57);
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
            this.btn_manageLorries.Location = new System.Drawing.Point(0, 494);
            this.btn_manageLorries.Name = "btn_manageLorries";
            this.btn_manageLorries.Size = new System.Drawing.Size(305, 57);
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
            this.btn_manageCustomers.BackColor = System.Drawing.Color.Transparent;
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
            this.btn_manageCustomers.Click += new System.EventHandler(this.btn_manageCustomers_Click);
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
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1383, 806);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboardForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
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