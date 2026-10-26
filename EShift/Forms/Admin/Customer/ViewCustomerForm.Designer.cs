namespace EShift.Forms.Admin
{
    partial class ViewCustomerForm
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
            this.txt_name = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.Label();
            this.txt_phonenumber = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.btn_back.Location = new System.Drawing.Point(47, 505);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(276, 42);
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
            this.label5.Location = new System.Drawing.Point(42, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(42, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Customer Deatails";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(41, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Phone number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(41, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Residential address";
            // 
            // txt_name
            // 
            this.txt_name.AutoSize = true;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.ForeColor = System.Drawing.Color.Navy;
            this.txt_name.Location = new System.Drawing.Point(42, 228);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(109, 25);
            this.txt_name.TabIndex = 55;
            this.txt_name.Text = "Full Name";
            // 
            // txt_email
            // 
            this.txt_email.AutoSize = true;
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.ForeColor = System.Drawing.Color.Navy;
            this.txt_email.Location = new System.Drawing.Point(42, 298);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(109, 25);
            this.txt_email.TabIndex = 56;
            this.txt_email.Text = "Full Name";
            // 
            // txt_phonenumber
            // 
            this.txt_phonenumber.AutoSize = true;
            this.txt_phonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phonenumber.ForeColor = System.Drawing.Color.Navy;
            this.txt_phonenumber.Location = new System.Drawing.Point(42, 372);
            this.txt_phonenumber.Name = "txt_phonenumber";
            this.txt_phonenumber.Size = new System.Drawing.Size(109, 25);
            this.txt_phonenumber.TabIndex = 57;
            this.txt_phonenumber.Text = "Full Name";
            // 
            // txt_address
            // 
            this.txt_address.AutoSize = true;
            this.txt_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.ForeColor = System.Drawing.Color.Navy;
            this.txt_address.Location = new System.Drawing.Point(42, 451);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(109, 25);
            this.txt_address.TabIndex = 58;
            this.txt_address.Text = "Full Name";
            // 
            // txt_id
            // 
            this.txt_id.AutoSize = true;
            this.txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.ForeColor = System.Drawing.Color.Navy;
            this.txt_id.Location = new System.Drawing.Point(42, 158);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(109, 25);
            this.txt_id.TabIndex = 60;
            this.txt_id.Text = "Full Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(42, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Customer ID";
            // 
            // ViewCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(361, 579);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_phonenumber);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditUserForm";
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
        private System.Windows.Forms.Label txt_name;
        private System.Windows.Forms.Label txt_email;
        private System.Windows.Forms.Label txt_phonenumber;
        private System.Windows.Forms.Label txt_address;
        private System.Windows.Forms.Label txt_id;
        private System.Windows.Forms.Label label7;
    }
}