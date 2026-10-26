namespace EShift
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.btn_sign_up = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_back = new FontAwesome.Sharp.IconButton();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_npassword = new System.Windows.Forms.TextBox();
            this.txt_cpassword = new System.Windows.Forms.TextBox();
            this.btn_eye1 = new FontAwesome.Sharp.IconButton();
            this.btn_eye2 = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_sign_up
            // 
            this.btn_sign_up.BackColor = System.Drawing.Color.Navy;
            this.btn_sign_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sign_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sign_up.ForeColor = System.Drawing.Color.White;
            this.btn_sign_up.Location = new System.Drawing.Point(925, 592);
            this.btn_sign_up.Name = "btn_sign_up";
            this.btn_sign_up.Size = new System.Drawing.Size(156, 42);
            this.btn_sign_up.TabIndex = 17;
            this.btn_sign_up.Text = "Sign Up";
            this.btn_sign_up.UseVisualStyleBackColor = false;
            this.btn_sign_up.Click += new System.EventHandler(this.btn_sign_up_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(649, 472);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(970, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Create Customer Account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(650, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Full Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(649, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Phone number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(970, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Residential address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(968, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Confirm Password";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.Window;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.Navy;
            this.btn_clear.Location = new System.Drawing.Point(1097, 592);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(154, 42);
            this.btn_clear.TabIndex = 26;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.btn_back.IconColor = System.Drawing.Color.Navy;
            this.btn_back.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_back.IconSize = 24;
            this.btn_back.Location = new System.Drawing.Point(626, 12);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(50, 35);
            this.btn_back.TabIndex = 28;
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(653, 315);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(277, 30);
            this.txt_name.TabIndex = 29;
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(974, 315);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(277, 30);
            this.txt_email.TabIndex = 30;
            // 
            // txt_phone
            // 
            this.txt_phone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(653, 408);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(277, 30);
            this.txt_phone.TabIndex = 31;
            // 
            // txt_address
            // 
            this.txt_address.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.Location = new System.Drawing.Point(974, 408);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(277, 30);
            this.txt_address.TabIndex = 32;
            // 
            // txt_npassword
            // 
            this.txt_npassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_npassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_npassword.Location = new System.Drawing.Point(653, 495);
            this.txt_npassword.Name = "txt_npassword";
            this.txt_npassword.Size = new System.Drawing.Size(242, 30);
            this.txt_npassword.TabIndex = 33;
            this.txt_npassword.UseSystemPasswordChar = true;
            // 
            // txt_cpassword
            // 
            this.txt_cpassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_cpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpassword.Location = new System.Drawing.Point(972, 499);
            this.txt_cpassword.Name = "txt_cpassword";
            this.txt_cpassword.Size = new System.Drawing.Size(240, 30);
            this.txt_cpassword.TabIndex = 34;
            this.txt_cpassword.UseSystemPasswordChar = true;
            // 
            // btn_eye1
            // 
            this.btn_eye1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_eye1.FlatAppearance.BorderSize = 0;
            this.btn_eye1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eye1.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btn_eye1.IconColor = System.Drawing.Color.Navy;
            this.btn_eye1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_eye1.IconSize = 24;
            this.btn_eye1.Location = new System.Drawing.Point(893, 500);
            this.btn_eye1.Name = "btn_eye1";
            this.btn_eye1.Size = new System.Drawing.Size(37, 29);
            this.btn_eye1.TabIndex = 35;
            this.btn_eye1.UseVisualStyleBackColor = false;
            this.btn_eye1.Click += new System.EventHandler(this.btn_eye1_Click);
            // 
            // btn_eye2
            // 
            this.btn_eye2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_eye2.FlatAppearance.BorderSize = 0;
            this.btn_eye2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eye2.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btn_eye2.IconColor = System.Drawing.Color.Navy;
            this.btn_eye2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_eye2.IconSize = 24;
            this.btn_eye2.Location = new System.Drawing.Point(1212, 499);
            this.btn_eye2.Name = "btn_eye2";
            this.btn_eye2.Size = new System.Drawing.Size(37, 29);
            this.btn_eye2.TabIndex = 36;
            this.btn_eye2.UseVisualStyleBackColor = false;
            this.btn_eye2.Click += new System.EventHandler(this.btn_eye2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-15, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 727);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(654, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1288, 722);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_eye2);
            this.Controls.Add(this.btn_eye1);
            this.Controls.Add(this.txt_cpassword);
            this.Controls.Add(this.txt_npassword);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_sign_up);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sign_up;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_clear;
        private FontAwesome.Sharp.IconButton btn_back;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_npassword;
        private System.Windows.Forms.TextBox txt_cpassword;
        private FontAwesome.Sharp.IconButton btn_eye1;
        private FontAwesome.Sharp.IconButton btn_eye2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}