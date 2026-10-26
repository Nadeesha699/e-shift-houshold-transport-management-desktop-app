namespace EShift.Forms.Admin
{
    partial class ViewJobAdminForm
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
            this.btn_close = new FontAwesome.Sharp.IconButton();
            this.btn_back = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPickup = new System.Windows.Forms.Label();
            this.lblRequestedDate = new System.Windows.Forms.Label();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblDeclineReason = new System.Windows.Forms.Label();
            this.lblJobNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvLoads = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.btn_close.IconColor = System.Drawing.Color.Navy;
            this.btn_close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_close.IconSize = 24;
            this.btn_close.Location = new System.Drawing.Point(22, 24);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(41, 35);
            this.btn_close.TabIndex = 52;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.SystemColors.Window;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.Navy;
            this.btn_back.Location = new System.Drawing.Point(414, 704);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(179, 42);
            this.btn_back.TabIndex = 51;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(47, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Pickup location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(46, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Requested date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Job Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(353, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Created date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(48, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Decline reason";
            // 
            // lblPickup
            // 
            this.lblPickup.AutoSize = true;
            this.lblPickup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPickup.ForeColor = System.Drawing.Color.Navy;
            this.lblPickup.Location = new System.Drawing.Point(47, 232);
            this.lblPickup.Name = "lblPickup";
            this.lblPickup.Size = new System.Drawing.Size(109, 25);
            this.lblPickup.TabIndex = 55;
            this.lblPickup.Text = "Full Name";
            // 
            // lblRequestedDate
            // 
            this.lblRequestedDate.AutoSize = true;
            this.lblRequestedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedDate.ForeColor = System.Drawing.Color.Navy;
            this.lblRequestedDate.Location = new System.Drawing.Point(46, 302);
            this.lblRequestedDate.Name = "lblRequestedDate";
            this.lblRequestedDate.Size = new System.Drawing.Size(109, 25);
            this.lblRequestedDate.TabIndex = 56;
            this.lblRequestedDate.Text = "Full Name";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedAt.ForeColor = System.Drawing.Color.Navy;
            this.lblCreatedAt.Location = new System.Drawing.Point(354, 302);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(109, 25);
            this.lblCreatedAt.TabIndex = 57;
            this.lblCreatedAt.Text = "Full Name";
            // 
            // lblDeclineReason
            // 
            this.lblDeclineReason.AutoSize = true;
            this.lblDeclineReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeclineReason.ForeColor = System.Drawing.Color.Navy;
            this.lblDeclineReason.Location = new System.Drawing.Point(49, 384);
            this.lblDeclineReason.Name = "lblDeclineReason";
            this.lblDeclineReason.Size = new System.Drawing.Size(109, 25);
            this.lblDeclineReason.TabIndex = 58;
            this.lblDeclineReason.Text = "Full Name";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNumber.ForeColor = System.Drawing.Color.Navy;
            this.lblJobNumber.Location = new System.Drawing.Point(42, 158);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(109, 25);
            this.lblJobNumber.TabIndex = 60;
            this.lblJobNumber.Text = "Full Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(42, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Job Number";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.ForeColor = System.Drawing.Color.Navy;
            this.lblDestination.Location = new System.Drawing.Point(352, 223);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(109, 25);
            this.lblDestination.TabIndex = 62;
            this.lblDestination.Text = "Full Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(352, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Destination";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(423, 76);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(140, 20);
            this.lblStatus.TabIndex = 66;
            this.lblStatus.Text = "Requested date";
            // 
            // dgvLoads
            // 
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Location = new System.Drawing.Point(51, 532);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.RowHeadersWidth = 51;
            this.dgvLoads.RowTemplate.Height = 24;
            this.dgvLoads.Size = new System.Drawing.Size(542, 150);
            this.dgvLoads.TabIndex = 67;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(50, 497);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 20);
            this.label11.TabIndex = 68;
            this.label11.Text = "Load details";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Navy;
            this.lblCustomer.Location = new System.Drawing.Point(47, 456);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(109, 25);
            this.lblCustomer.TabIndex = 70;
            this.lblCustomer.Text = "Full Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(47, 427);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 20);
            this.label12.TabIndex = 69;
            this.label12.Text = "Customer Name";
            // 
            // ViewJobAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 769);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvLoads);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDeclineReason);
            this.Controls.Add(this.lblCreatedAt);
            this.Controls.Add(this.lblRequestedDate);
            this.Controls.Add(this.lblPickup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewJobAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditUserForm";
            this.Load += new System.EventHandler(this.ViewJobForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btn_close;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPickup;
        private System.Windows.Forms.Label lblRequestedDate;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblDeclineReason;
        private System.Windows.Forms.Label lblJobNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvLoads;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label12;
    }
}