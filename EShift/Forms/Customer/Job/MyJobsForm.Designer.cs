namespace EShift.Forms
{
    partial class MyJobsForm
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
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_close = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_refresh = new FontAwesome.Sharp.IconButton();
            this.btn_view = new FontAwesome.Sharp.IconButton();
            this.btn_cancelRequest = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_profile = new FontAwesome.Sharp.IconButton();
            this.btn_logout = new FontAwesome.Sharp.IconButton();
            this.btn_myJobs = new FontAwesome.Sharp.IconButton();
            this.btn_createJob = new FontAwesome.Sharp.IconButton();
            this.btn_dashboard = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "My Jobs";
            // 
            // dgvJobs
            // 
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Location = new System.Drawing.Point(331, 303);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.RowHeadersWidth = 51;
            this.dgvJobs.RowTemplate.Height = 24;
            this.dgvJobs.Size = new System.Drawing.Size(1007, 465);
            this.dgvJobs.TabIndex = 20;
            this.dgvJobs.SelectionChanged += new System.EventHandler(this.dgvJobs_SelectionChanged);
            // 
            // txt_search
            // 
            this.txt_search.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(362, 247);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(897, 30);
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
            this.btn_close.Location = new System.Drawing.Point(325, 247);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(36, 34);
            this.btn_close.TabIndex = 31;
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(358, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 18);
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
            this.btn_refresh.Location = new System.Drawing.Point(1265, 245);
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
            this.btn_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_view.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btn_view.IconColor = System.Drawing.Color.White;
            this.btn_view.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_view.IconSize = 24;
            this.btn_view.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_view.Location = new System.Drawing.Point(326, 105);
            this.btn_view.Name = "btn_view";
            this.btn_view.Padding = new System.Windows.Forms.Padding(5);
            this.btn_view.Size = new System.Drawing.Size(507, 92);
            this.btn_view.TabIndex = 36;
            this.btn_view.Text = "View Job";
            this.btn_view.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_view.UseVisualStyleBackColor = false;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // btn_cancelRequest
            // 
            this.btn_cancelRequest.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_cancelRequest.FlatAppearance.BorderSize = 0;
            this.btn_cancelRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelRequest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cancelRequest.IconChar = FontAwesome.Sharp.IconChar.Shield;
            this.btn_cancelRequest.IconColor = System.Drawing.Color.White;
            this.btn_cancelRequest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_cancelRequest.IconSize = 24;
            this.btn_cancelRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cancelRequest.Location = new System.Drawing.Point(850, 105);
            this.btn_cancelRequest.Name = "btn_cancelRequest";
            this.btn_cancelRequest.Padding = new System.Windows.Forms.Padding(5);
            this.btn_cancelRequest.Size = new System.Drawing.Size(488, 92);
            this.btn_cancelRequest.TabIndex = 38;
            this.btn_cancelRequest.Text = "Deactive Account";
            this.btn_cancelRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancelRequest.UseVisualStyleBackColor = false;
            this.btn_cancelRequest.Click += new System.EventHandler(this.btn_toggle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(322, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Manage system accounts and access permissions";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btn_profile);
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_myJobs);
            this.panel1.Controls.Add(this.btn_createJob);
            this.panel1.Controls.Add(this.btn_dashboard);
            this.panel1.Location = new System.Drawing.Point(-12, -58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 922);
            this.panel1.TabIndex = 63;
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
            this.btn_myJobs.BackColor = System.Drawing.Color.MediumBlue;
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
            // 
            // btn_createJob
            // 
            this.btn_createJob.BackColor = System.Drawing.Color.Transparent;
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
            this.btn_createJob.Click += new System.EventHandler(this.btn_createJob_Click);
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
            // MyJobsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1383, 806);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancelRequest);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dgvJobs);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyJobsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboardForm";
            this.Load += new System.EventHandler(this.MyJobsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.TextBox txt_search;
        private FontAwesome.Sharp.IconButton btn_close;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btn_refresh;
        private FontAwesome.Sharp.IconButton btn_view;
        private FontAwesome.Sharp.IconButton btn_cancelRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_profile;
        private FontAwesome.Sharp.IconButton btn_logout;
        private FontAwesome.Sharp.IconButton btn_myJobs;
        private FontAwesome.Sharp.IconButton btn_createJob;
        private FontAwesome.Sharp.IconButton btn_dashboard;
    }
}