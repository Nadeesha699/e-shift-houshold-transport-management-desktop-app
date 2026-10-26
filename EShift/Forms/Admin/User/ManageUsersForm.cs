using EShift.Forms.Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using EShift.Helpers;

namespace EShift.Forms
{
    public partial class ManageUserForm : Form
    {
        public ManageUserForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadUsers();

        }

        private void LoadUsers(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT
                            UserID,
                            FullName,
                            Email,
                            Role,
                            IsActive,
                            CreatedAt
                        FROM Users
                        WHERE FullName LIKE @search
                           OR Email LIKE @search
                        ORDER BY CreatedAt DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@search", "%" + search + "%");

                        DataTable dt = new DataTable();

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dgvUsers.DataSource = dt;

                        dgvUsers.ReadOnly = true;
                        dgvUsers.AllowUserToAddRows = false;
                        dgvUsers.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvUsers.MultiSelect = false;
                        dgvUsers.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvUsers.Columns["UserID"] != null)
                            dgvUsers.Columns["UserID"].HeaderText =
                                "User ID";

                        if (dgvUsers.Columns["FullName"] != null)
                            dgvUsers.Columns["FullName"].HeaderText =
                                "Full Name";

                        if (dgvUsers.Columns["IsActive"] != null)
                            dgvUsers.Columns["IsActive"].HeaderText =
                                "Account Status";

                        if (dgvUsers.Columns["CreatedAt"] != null)
                            dgvUsers.Columns["CreatedAt"].HeaderText =
                                "Created Date";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load users: " + ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadUsers();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txt_search.Text.Trim());

        }

      

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null ||
                dgvUsers.CurrentRow.IsNewRow)
            {
                btn_toggle.Enabled = false;
                return;
            }

            bool isActive = Convert.ToBoolean(
                dgvUsers.CurrentRow.Cells["IsActive"].Value);


            if (isActive)
            {
                btn_toggle.Text = "Deactivate Account";
                btn_toggle.BackColor = Color.FromArgb(220, 53, 69);
            }
            else
            {
                btn_toggle.Text = "Activate Account";
                btn_toggle.BackColor = Color.FromArgb(25, 135, 84);
            }

            btn_toggle.Enabled = true;
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a user.");
                return;
            }

            int userId = Convert.ToInt32(
                dgvUsers.CurrentRow.Cells["UserID"].Value);

            string role = Convert.ToString(
                dgvUsers.CurrentRow.Cells["Role"].Value);

            bool isActive = Convert.ToBoolean(
                dgvUsers.CurrentRow.Cells["IsActive"].Value);


            string action = isActive ? "deactivate" : "activate";

            DialogResult result = MessageBox.Show(
                "Are you sure you want to " + action + " this account?",
                "Confirm Account Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                UPDATE Users
                SET IsActive = @status
                WHERE UserID = @id";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@status", !isActive);

                        cmd.Parameters.AddWithValue("@id", userId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Account status updated successfully.");

                LoadUsers(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update account: " + ex.Message);
            }
        }

        private void btn_add_admin_Click(object sender, EventArgs e)
        {
            using (AddUserForm form = new AddUserForm())
            {

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadUsers(txt_search.Text.Trim());
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a user to edit.");
                return;
            }

            int userId = Convert.ToInt32(
                dgvUsers.CurrentRow.Cells["UserID"].Value);

            using (EditUserForm form = new EditUserForm(userId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadUsers(txt_search.Text.Trim());
                }
            }
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            AdminDashboardForm form = new AdminDashboardForm();
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

        private void btn_profile_Click(object sender, EventArgs e)
        {
            AdminProfile form = new AdminProfile();
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
