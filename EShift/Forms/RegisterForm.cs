using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using EShift.Helpers;
using FontAwesome.Sharp;

namespace EShift
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }

        private void btn_sign_up_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_email.Text) || string.IsNullOrWhiteSpace(txt_phone.Text) || string.IsNullOrWhiteSpace(txt_address.Text) || string.IsNullOrWhiteSpace(txt_npassword.Text) || string.IsNullOrWhiteSpace(txt_cpassword.Text))
            {
                MessageHelper.ShowError("Please fill in all required fields.");
                return;

            }

            if (txt_name.Text.Length < 2 || txt_name.Text.Length > 100)
            {
                MessageHelper.ShowError("Name must be between 2 and 100 characters.");
                return;
            }

            string emailPattern =
                @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if (!Regex.IsMatch(txt_email.Text, emailPattern))
            {
                MessageHelper.ShowError("Please enter a valid email address.");
                return;
            }

            if (txt_email.Text.Length > 150)
            {
                MessageHelper.ShowError("Email address is too long.");
                return;
            }

            string phonePattern = @"^[0-9+\-()\s]{7,20}$";

            if (!Regex.IsMatch(txt_phone.Text, phonePattern))
            {
                MessageHelper.ShowError("Enter a valid phone number (7–20 characters).");
                return;
            }

            if (txt_address.Text.Length > 255)
            {
                MessageHelper.ShowError("Address cannot exceed 255 characters.");
                return;
            }

            if (txt_npassword.Text.Length < 8 ||
                txt_npassword.Text.Length > 128 ||
                !Regex.IsMatch(txt_npassword.Text, @"[A-Z]") ||
                !Regex.IsMatch(txt_npassword.Text, @"[a-z]") ||
                !Regex.IsMatch(txt_npassword.Text, @"[0-9]"))
            {
                MessageHelper.ShowError(
                    "Password must be 8–128 characters and include " +
                    "uppercase, lowercase, and numeric characters.");
                return;
            }

            if (txt_npassword.Text != txt_cpassword.Text)
            {
                MessageHelper.ShowError("Passwords do not match.");
                txt_cpassword.Clear();
                txt_cpassword.Focus();
                return;
            }

            RegisterCustomer(txt_name.Text, txt_email.Text, txt_phone.Text, txt_address.Text, txt_npassword.Text);

        }

        private void RegisterCustomer(
           string fullName,
           string email,
           string phone,
           string address,
           string password)
        {
            using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();


                    string passwordHash = PasswordHelper.HashPassword(password);

                    using (MySqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {


                            string userSql = @"
                                INSERT INTO Users
                                    (FullName, Email, PasswordHash,
                                     Role, IsActive)
                                VALUES
                                    (@FullName, @Email, @PasswordHash,
                                     'CUSTOMER', 1)";

                            using (MySqlCommand userCommand =
                                   new MySqlCommand(
                                       userSql, connection, transaction))
                            {
                                userCommand.Parameters.AddWithValue(
                                    "@FullName", fullName);
                                userCommand.Parameters.AddWithValue(
                                    "@Email", email);
                                userCommand.Parameters.AddWithValue(
                                    "@PasswordHash", passwordHash);

                                userCommand.ExecuteNonQuery();
                            }

                            long userId;

                            using (MySqlCommand idCommand =
                                   new MySqlCommand(
                                       "SELECT LAST_INSERT_ID()",
                                       connection, transaction))
                            {
                                userId = Convert.ToInt64(
                                    idCommand.ExecuteScalar());
                            }

                            string customerSql = @"
                                INSERT INTO Customers
                                    (UserID, Phone, Address)
                                VALUES
                                    (@UserID, @Phone, @Address)";

                            using (MySqlCommand customerCommand =
                                   new MySqlCommand(
                                       customerSql,
                                       connection, transaction))
                            {
                                customerCommand.Parameters.AddWithValue(
                                    "@UserID", userId);
                                customerCommand.Parameters.AddWithValue(
                                    "@Phone", phone);
                                customerCommand.Parameters.AddWithValue(
                                    "@Address", address);

                                customerCommand.ExecuteNonQuery();
                            }

                            // Both inserts succeeded
                            transaction.Commit();

                            MessageHelper.ShowSuccess("Registration successful! You can now log in e-Shift Registration");

                            ClearFields();

                        }
                        catch
                        {
                            // Roll back both inserts if either fails
                            try
                            {
                                transaction.Rollback();
                            }
                            catch
                            {

                            }

                            throw;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageHelper.ShowError(
                            "This email is already registered. " +
                            "Please use another email.");
                    }
                    else
                    {
                        MessageHelper.ShowError(
                            "A database error occurred. Please try again.");
                    }

                }
                catch (Exception)
                {
                    MessageHelper.ShowError(
                        "Registration failed. Please try again.");
                }
            }
        }

       

      

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txt_email.Clear();
            txt_name.Clear();
            txt_address.Clear();
            txt_phone.Clear();
            txt_npassword.Clear();
            txt_cpassword.Clear();
        }

        private void btn_eye1_Click(object sender, EventArgs e)
        {
            if (txt_npassword.UseSystemPasswordChar)
            {
                txt_npassword.UseSystemPasswordChar = false;
                btn_eye1.IconChar = IconChar.Eye;
            }
            else
            {
                txt_npassword.UseSystemPasswordChar = true;
                btn_eye1.IconChar = IconChar.EyeSlash;

            }

        }

        private void btn_eye2_Click(object sender, EventArgs e)
        {
            if (txt_cpassword.UseSystemPasswordChar)
            {
                txt_cpassword.UseSystemPasswordChar = false;
                btn_eye2.IconChar = IconChar.Eye;
            }
            else
            {
                txt_cpassword.UseSystemPasswordChar = true;
                btn_eye2.IconChar = IconChar.EyeSlash;

            }

        }

       
    }
}
