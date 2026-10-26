using EShift.Forms.Admin;
using EShift.Helpers;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShift.Forms
{
    public partial class AdminProfile : Form
    {
        private long adminId;
        public AdminProfile()
        {
            InitializeComponent();
            adminId = SessionManager.UserID;
        }

        private void LoadProfile()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT FullName, Email, Role
                        FROM Users
                        WHERE UserID = @UserID
                          AND UPPER(Role) = 'ADMIN'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", adminId);

                        DataTable dt = new DataTable();

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        if (dt.Rows.Count == 0)
                        {
                            MessageHelper.ShowError(
                                "Administrator profile not found.");
                            return;
                        }

                        txtFullName.Text =
                            Convert.ToString(dt.Rows[0]["FullName"]);

                        txtEmail.Text =
                            Convert.ToString(dt.Rows[0]["Email"]);

                    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load profile: " + ex.Message);
            }
        }

        private void btn_editprofile_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageHelper.ShowError("Please enter your full name.");
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains("@") ||
                !email.Contains("."))
            {
                MessageHelper.ShowError(
                    "Please enter a valid email address.");
                txtEmail.Focus();
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        UPDATE Users
                        SET FullName = @FullName,
                            Email = @Email
                        WHERE UserID = @UserID
                          AND UPPER(Role) = 'ADMIN'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FullName", fullName);

                        cmd.Parameters.AddWithValue(
                            "@Email", email);

                        cmd.Parameters.AddWithValue(
                            "@UserID", adminId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageHelper.ShowSuccess(
                                "Profile updated successfully.");
                            LoadProfile();
                        }
                        else
                        {
                            // MySQL may report zero changed rows if
                            // the submitted values are unchanged.
                            LoadProfile();
                            MessageHelper.ShowSuccess(
                                "Profile information saved.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError(
                        "This email address is already in use.");
                }
                else
                {
                    MessageHelper.ShowError(
                        "Unable to update profile: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to update profile: " + ex.Message);
            }
        }

        private void CustomerProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void btn_cancel1_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void btn_updatepassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate empty fields
            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageHelper.ShowError(
                    "Please complete all password fields.");
                return;
            }

            // Validate new password length
            if (newPassword.Length < 8)
            {
                MessageHelper.ShowError(
                    "The new password must contain at least 8 characters.");
                txtNewPassword.Focus();
                return;
            }

            // Confirm the new password
            if (newPassword != confirmPassword)
            {
                MessageHelper.ShowError(
                    "The new passwords do not match.");
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            // Prevent reusing the current password
            if (currentPassword == newPassword)
            {
                MessageHelper.ShowError(
                    "Your new password must be different from your current password.");
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Get the current password hash
                    string selectSql = @"
                SELECT PasswordHash
                FROM Users
                WHERE UserID = @UserID
                  AND UPPER(Role) = 'ADMIN'";

                    string storedHash;

                    using (MySqlCommand cmd =
                        new MySqlCommand(selectSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", adminId);

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageHelper.ShowError(
                                "Administrator account not found.");
                            return;
                        }

                        storedHash = Convert.ToString(result);
                    }

                    // Verify the current password using BCrypt
                    if (!PasswordHelper.VerifyPassword(currentPassword, storedHash))
                    {
                        MessageHelper.ShowError(
                           "Your current password is incorrect.");
                        txtCurrentPassword.Clear();
                        txtCurrentPassword.Focus();
                        return; ;
                    }

                    // Hash the new password before saving
                    string newPasswordHash =
                        PasswordHelper.HashPassword(newPassword);

                    string updateSql = @"
                UPDATE Users
                SET PasswordHash = @PasswordHash
                WHERE UserID = @UserID
                  AND UPPER(Role) = 'ADMIN'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(updateSql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@PasswordHash", newPasswordHash);

                        cmd.Parameters.AddWithValue(
                            "@UserID", adminId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageHelper.ShowSuccess(
                                "Password updated successfully.");

                            txtCurrentPassword.Clear();
                            txtNewPassword.Clear();
                            txtConfirmPassword.Clear();
                        }
                        else
                        {
                            MessageHelper.ShowError(
                                "Password could not be updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to update password: " + ex.Message);
            }
        }

        private void btn_eye1_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.UseSystemPasswordChar)
            {
                txtCurrentPassword.UseSystemPasswordChar = false;
                btn_eye1.IconChar = IconChar.Eye;
            }
            else
            {
                txtCurrentPassword.UseSystemPasswordChar = true;
                btn_eye1.IconChar = IconChar.EyeSlash;

            }
        }

        private void btn_eye2_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.UseSystemPasswordChar)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                btn_eye2.IconChar = IconChar.Eye;
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
                btn_eye2.IconChar = IconChar.EyeSlash;

            }

        }

        private void btn_eye3_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.UseSystemPasswordChar)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
                btn_eye3.IconChar = IconChar.Eye;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
                btn_eye3.IconChar = IconChar.EyeSlash;

            }
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            AdminDashboardForm form = new AdminDashboardForm();
            form.Show();
            this.Hide();
        }

        private void btn_manageUsers_Click(object sender, EventArgs e)
        {
            ManageUserForm form = new ManageUserForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageCustomers_Click(object sender, EventArgs e)
        {
            ManageCustomerForm form = new ManageCustomerForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageProducts_Click(object sender, EventArgs e)
        {
            ManageProductsForm form = new ManageProductsForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageJobs_Click(object sender, EventArgs e)
        {
            ManageJobForm form = new ManageJobForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageDrivers_Click(object sender, EventArgs e)
        {
            ManageDriverForm form = new ManageDriverForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageAssistants_Click(object sender, EventArgs e)
        {
            ManageAssistantForm form = new ManageAssistantForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageLorries_Click(object sender, EventArgs e)
        {
            ManageVehicleForm form = new ManageVehicleForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageContainers_Click(object sender, EventArgs e)
        {
            ManageContainerForm form = new ManageContainerForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageTransport_Click(object sender, EventArgs e)
        {
            ManageTransportForm form = new ManageTransportForm();
            form.Show();
            this.Hide();

        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            ReportsForm form = new ReportsForm();
            form.Show();
            this.Hide();

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Are you sure you want to log out?",
           "Confirm Logout",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            this.Hide();

            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }

            this.Close();

        }
    }
}
