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
    public partial class CustomerProfile : Form
    {
        private long customerId;
        public CustomerProfile()
        {
            InitializeComponent();
            customerId = SessionManager.UserID;
        }

        private void btn_editprofile_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

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

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageHelper.ShowError(
                    "Please enter your phone number.");
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageHelper.ShowError(
                    "Please enter your address.");
                txtAddress.Focus();
                return;
            }

            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection = DatabaseConnection.GetConnection();
                connection.Open();

                transaction = connection.BeginTransaction();

                string userSql = @"
                    UPDATE Users
                    SET FullName = @FullName,
                        Email = @Email
                    WHERE UserID = @UserID
                      AND UPPER(Role) = 'CUSTOMER'";

                using (MySqlCommand cmd =
                    new MySqlCommand(userSql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "@FullName", fullName);

                    cmd.Parameters.AddWithValue(
                        "@Email", email);

                    cmd.Parameters.AddWithValue(
                        "@UserID", customerId);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        // A zero result can mean unchanged values.
                        // Verify that the customer account still exists.
                        string checkSql = @"
                            SELECT COUNT(*)
                            FROM Users
                            WHERE UserID = @UserID
                              AND UPPER(Role) = 'CUSTOMER'";

                        using (MySqlCommand check =
                            new MySqlCommand(
                                checkSql, connection, transaction))
                        {
                            check.Parameters.AddWithValue(
                                "@UserID", customerId);

                            if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                            {
                                throw new Exception(
                                    "Customer account was not found.");
                            }
                        }
                    }
                }

                string customerSql = @"
                    UPDATE Customers
                    SET Phone = @Phone,
                        Address = @Address
                    WHERE UserID = @UserID";

                using (MySqlCommand cmd =
                    new MySqlCommand(
                        customerSql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@UserID", customerId);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        // If the profile row is missing, don't report
                        // success for a partial update.
                        string checkSql = @"
                            SELECT COUNT(*)
                            FROM Customers
                            WHERE UserID = @UserID";

                        using (MySqlCommand check =
                            new MySqlCommand(
                                checkSql, connection, transaction))
                        {
                            check.Parameters.AddWithValue(
                                "@UserID", customerId);

                            if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                            {
                                throw new Exception(
                                    "Customer contact record was not found.");
                            }
                        }
                    }
                }

                transaction.Commit();

                MessageHelper.ShowSuccess(
                    "Profile updated successfully.");

                LoadProfile();
            }
            catch (MySqlException ex)
            {
                if (transaction != null)
                {
                    try { transaction.Rollback(); }
                    catch { }
                }

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
                if (transaction != null)
                {
                    try { transaction.Rollback(); }
                    catch { }
                }

                MessageHelper.ShowError(
                    "Unable to update profile: " + ex.Message);
            }
            finally
            {
                if (transaction != null)
                    transaction.Dispose();

                if (connection != null)
                    connection.Dispose();
            }
        }

        private void CustomerProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT
                            u.FullName,
                            u.Email,
                            c.Phone,
                            c.Address
                        FROM Users u
                        INNER JOIN Customers c
                            ON c.UserID = u.UserID
                        WHERE u.UserID = @UserID
                          AND UPPER(u.Role) = 'CUSTOMER'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@UserID", customerId);

                        DataTable dt = new DataTable();

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        if (dt.Rows.Count == 0)
                        {
                            MessageHelper.ShowError(
                                "Customer profile not found.");
                            return;
                        }

                        txtFullName.Text =
                            Convert.ToString(dt.Rows[0]["FullName"]);

                        txtEmail.Text =
                            Convert.ToString(dt.Rows[0]["Email"]);

                        txtPhone.Text =
                            dt.Rows[0]["Phone"] == DBNull.Value
                                ? ""
                                : Convert.ToString(dt.Rows[0]["Phone"]);

                        txtAddress.Text =
                            dt.Rows[0]["Address"] == DBNull.Value
                                ? ""
                                : Convert.ToString(dt.Rows[0]["Address"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load customer profile: " + ex.Message);
            }
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
                  AND UPPER(Role) = 'CUSTOMER'";

                    string storedHash;

                    using (MySqlCommand cmd =
                        new MySqlCommand(selectSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", customerId);

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageHelper.ShowError(
                                "Customer account not found.");
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
                  AND UPPER(Role) = 'CUSTOMER'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(updateSql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@PasswordHash", newPasswordHash);

                        cmd.Parameters.AddWithValue(
                            "@UserID", customerId);

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
            CustomerDashboardForm form = new CustomerDashboardForm();
            form.Show();
            this.Hide();
        }

        private void btn_createJob_Click(object sender, EventArgs e)
        {
            CreateJobForm form = new CreateJobForm();
            form.Show();
            this.Hide();

        }

        private void btn_myJobs_Click(object sender, EventArgs e)
        {
            MyJobsForm form = new MyJobsForm();
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
