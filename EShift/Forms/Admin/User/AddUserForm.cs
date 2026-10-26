using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using EShift.Helpers;
using FontAwesome.Sharp;

namespace EShift.Forms.Admin
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageHelper.ShowError("Please fill in all fields.");
                return;
            }

            if (!Regex.IsMatch(txt_email.Text,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageHelper.ShowError("Please enter a valid email address.");
                return;
            }

            if (txt_password.Text.Length < 8)
            {
                MessageHelper.ShowError("Password must contain at least 8 characters.");
                return;
            }

            string passwordHash = PasswordHelper.HashPassword(txt_password.Text);

            try
            {
                using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        INSERT INTO Users
                            (FullName, Email, PasswordHash,
                             Role, IsActive, CreatedAt)
                        VALUES
                            (@name, @email, @password,
                             'ADMIN', 1, NOW())"
                    ;
                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@email", txt_email.Text);
                        cmd.Parameters.AddWithValue(
                            "@password", passwordHash);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Administrator account created successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("This email is already registered.");
                }
                else
                {
                    MessageHelper.ShowError( "Database error: " + ex.Message);
                }
            }
        }

        private void btn_eye_Click(object sender, EventArgs e)
        {
            if (txt_password.UseSystemPasswordChar)
            {
                txt_password.UseSystemPasswordChar = false;
                btn_eye.IconChar = IconChar.Eye;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
                btn_eye.IconChar = IconChar.EyeSlash;

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_email.Clear();
            txt_password.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
