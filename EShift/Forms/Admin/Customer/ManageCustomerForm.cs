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
    public partial class ManageCustomerForm : Form
    {
        public ManageCustomerForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();

        }

        private void LoadCustomers(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT
                            u.UserID AS CustomerID,
                            u.FullName AS Name,
                            u.Email,
                            c.Phone,
                            c.Address
                        FROM Users u
                        INNER JOIN Customers c
                            ON u.UserID = c.UserID
                        WHERE u.Role = 'CUSTOMER'
                          AND (
                              u.FullName LIKE @search
                              OR u.Email LIKE @search
                              OR c.Phone LIKE @search
                          )
                        ORDER BY u.UserID DESC";

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

                        dgvCustomers.DataSource = dt;
                        dgvCustomers.ReadOnly = true;
                        dgvCustomers.AllowUserToAddRows = false;
                        dgvCustomers.MultiSelect = false;
                        dgvCustomers.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvCustomers.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load customers: " + ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadCustomers();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers(txt_search.Text.Trim());

        }

      

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a user to edit.");
                return;
            }

            int userId = Convert.ToInt32(
                dgvCustomers.CurrentRow.Cells["CustomerID"].Value);

            using (EditCustomerForm form = new EditCustomerForm(userId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCustomers(txt_search.Text.Trim());
                }
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a customer.");
                return;
            }

            DataGridViewRow row = dgvCustomers.CurrentRow;

            using (ViewCustomerForm form = new ViewCustomerForm(
                Convert.ToString(row.Cells["CustomerID"].Value),
                Convert.ToString(row.Cells["Name"].Value),
                Convert.ToString(row.Cells["Email"].Value),
                Convert.ToString(row.Cells["Phone"].Value),
                Convert.ToString(row.Cells["Address"].Value)))
            {
                form.ShowDialog(this);
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
