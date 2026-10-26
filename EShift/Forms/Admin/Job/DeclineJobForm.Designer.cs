namespace EShift.Forms.Admin
{
    partial class DeclineJobForm
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
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_closes = new System.Windows.Forms.Button();
            this.btn_close = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(34, 99);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(277, 30);
            this.txtReason.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(30, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Decline Reason";
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Navy;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(33, 159);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(276, 42);
            this.btn_submit.TabIndex = 39;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_closes
            // 
            this.btn_closes.BackColor = System.Drawing.SystemColors.Window;
            this.btn_closes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_closes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closes.ForeColor = System.Drawing.Color.Navy;
            this.btn_closes.Location = new System.Drawing.Point(33, 207);
            this.btn_closes.Name = "btn_closes";
            this.btn_closes.Size = new System.Drawing.Size(276, 42);
            this.btn_closes.TabIndex = 40;
            this.btn_closes.Text = "Close";
            this.btn_closes.UseVisualStyleBackColor = false;
            this.btn_closes.Click += new System.EventHandler(this.btn_closes_Click);
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
            this.btn_close.Location = new System.Drawing.Point(12, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(41, 35);
            this.btn_close.TabIndex = 41;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // DeclineJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 305);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_closes);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeclineJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_closes;
        private FontAwesome.Sharp.IconButton btn_close;
    }
}