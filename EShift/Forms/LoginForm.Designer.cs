namespace EShift
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_sign_in = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_sign_up = new System.Windows.Forms.Label();
            this.btn_close = new FontAwesome.Sharp.IconButton();
            this.btn_eye = new FontAwesome.Sharp.IconButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-5, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(859, 741);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(892, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Welcome Back";
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(897, 370);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(362, 30);
            this.txt_email.TabIndex = 5;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(897, 464);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(331, 30);
            this.txt_password.TabIndex = 6;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(893, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(893, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // btn_sign_in
            // 
            this.btn_sign_in.BackColor = System.Drawing.Color.Navy;
            this.btn_sign_in.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sign_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sign_in.ForeColor = System.Drawing.Color.White;
            this.btn_sign_in.Location = new System.Drawing.Point(897, 531);
            this.btn_sign_in.Name = "btn_sign_in";
            this.btn_sign_in.Size = new System.Drawing.Size(362, 42);
            this.btn_sign_in.TabIndex = 9;
            this.btn_sign_in.Text = "Sign In";
            this.btn_sign_in.UseVisualStyleBackColor = false;
            this.btn_sign_in.Click += new System.EventHandler(this.btn_sign_in_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(912, 598);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Join EShift today ?";
            // 
            // lbl_sign_up
            // 
            this.lbl_sign_up.AutoSize = true;
            this.lbl_sign_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sign_up.ForeColor = System.Drawing.Color.Navy;
            this.lbl_sign_up.Location = new System.Drawing.Point(1115, 598);
            this.lbl_sign_up.Name = "lbl_sign_up";
            this.lbl_sign_up.Size = new System.Drawing.Size(75, 20);
            this.lbl_sign_up.TabIndex = 11;
            this.lbl_sign_up.Text = "Sign Up";
            this.lbl_sign_up.Click += new System.EventHandler(this.lbl_sign_up_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btn_close.IconColor = System.Drawing.Color.Red;
            this.btn_close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_close.IconSize = 24;
            this.btn_close.Location = new System.Drawing.Point(1225, 22);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(41, 34);
            this.btn_close.TabIndex = 29;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_eye
            // 
            this.btn_eye.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_eye.FlatAppearance.BorderSize = 0;
            this.btn_eye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btn_eye.IconColor = System.Drawing.Color.Navy;
            this.btn_eye.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_eye.IconSize = 24;
            this.btn_eye.Location = new System.Drawing.Point(1221, 465);
            this.btn_eye.Name = "btn_eye";
            this.btn_eye.Size = new System.Drawing.Size(38, 29);
            this.btn_eye.TabIndex = 30;
            this.btn_eye.UseVisualStyleBackColor = false;
            this.btn_eye.Click += new System.EventHandler(this.btn_eye_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(897, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1288, 722);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_eye);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_sign_up);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_sign_in);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_sign_in;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_sign_up;
        private FontAwesome.Sharp.IconButton btn_close;
        private FontAwesome.Sharp.IconButton btn_eye;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

