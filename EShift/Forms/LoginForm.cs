using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;
using EShift.Helpers;
using FontAwesome.Sharp;
using EShift.Forms;
using Microsoft.Win32;

namespace EShift
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }





        private void lbl_sign_up_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sign_in_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_email.Text) || string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageHelper.ShowError("Please fill in all required fields.");
                return;
            }

            UserLogin(txt_email.Text, txt_password.Text);
        }



        private void UserLogin(string email, string password)
        {
            using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();

                    long userId;
                    string fullName;
                    string storedEmail;
                    string passwordHash;
                    string role;
                    bool isActive;

               
                    string sql = @"
                SELECT UserID, FullName, Email,
                       PasswordHash, Role, IsActive
                FROM Users
                WHERE Email = @Email
                LIMIT 1";

                    using (MySqlCommand command =
                           new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Email", email.Trim());

                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageHelper.ShowError("Invalid email.");
                                return;
                            }

                            isActive = Convert.ToBoolean(
                                reader["IsActive"]);

                            userId = Convert.ToInt64(
                                reader["UserID"]);

                            fullName = reader["FullName"].ToString();
                            storedEmail = reader["Email"].ToString();
                            passwordHash = reader["PasswordHash"].ToString();
                            role = reader["Role"].ToString();
                        }
                    }

                    if (!isActive)
                    {
                        MessageHelper.ShowError(
                            "Your account is inactive. Please contact the administrator.");
                        return;
                    }

             
                    if (!PasswordHelper.VerifyPassword(
                            password, passwordHash))
                    {
                        MessageHelper.ShowError("Invalid password.");
                        return;
                    }

                    bool isAdmin = role.Equals(
                        "ADMIN", StringComparison.OrdinalIgnoreCase);

                    bool isCustomer = role.Equals(
                        "CUSTOMER", StringComparison.OrdinalIgnoreCase);

                    if (!isAdmin && !isCustomer)
                    {
                        MessageHelper.ShowError(
                            "Your account has an unsupported role.");
                        return;
                    }

                    // Step 5: Save login account information
                    SessionManager.UserID = userId;
                    SessionManager.FullName = fullName;
                    SessionManager.Email = storedEmail;
                    SessionManager.Role = role;

                    // Clear any previous customer's ID
                    SessionManager.CustomerID = 0;

                  
                    if (isCustomer)
                    {
                        string customerQuery = @"
                    SELECT CustomerID
                    FROM Customers
                    WHERE UserID = @UserID
                    LIMIT 1";

                        using (MySqlCommand cmd =
                               new MySqlCommand(customerQuery, connection))
                        {
                            cmd.Parameters.AddWithValue(
                                "@UserID", userId);

                            object result = cmd.ExecuteScalar();

                            if (result == null ||
                                result == DBNull.Value)
                            {
                                MessageHelper.ShowError(
                                    "Your customer profile was not found. " +
                                    "Please contact the administrator.");
                                return;
                            }

                            SessionManager.CustomerID =
                                Convert.ToInt64(result);
                        }
                    }

                    MessageHelper.ShowSuccess(
                        "Login successful. Welcome, " + fullName + "!");

                   
                    if (isAdmin)
                    {
                        AdminDashboardForm form =
                            new AdminDashboardForm();

                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        CustomerDashboardForm form =
                            new CustomerDashboardForm();

                        form.Show();
                        this.Hide();
                    }
                }
                catch (MySqlException)
                {
                    MessageHelper.ShowError(
                        "Unable to connect to the database. Please try again.");
                }
                catch (Exception)
                {
                    MessageHelper.ShowError(
                        "Login failed. Please try again.");
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

       
    }
}
