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
    public partial class ManageProductsForm : Form
    {
        public ManageProductsForm()
        {
            InitializeComponent();
        }

        private void ManageProductsForm_Load(object sender, EventArgs e)
        {
            LoadProducts();

        }


        private void LoadProducts(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT
                            ProductID,
                            ProductName,
                            Description,
                            IsActive
                        FROM Products
                        WHERE ProductName LIKE @search
                           OR Description LIKE @search
                        ORDER BY ProductID DESC";

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

                        dgvProducts.DataSource = dt;

                        dgvProducts.ReadOnly = true;
                        dgvProducts.AllowUserToAddRows = false;
                        dgvProducts.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvProducts.MultiSelect = false;
                        dgvProducts.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvProducts.Columns["ProductID"].HeaderText =
                            "Product ID";

                        dgvProducts.Columns["ProductName"].HeaderText =
                            "Product Name";


                        dgvProducts.Columns["IsActive"].HeaderText =
                            "Status";

                        dgvProducts.Columns["IsActive"].Visible = false;

                        if (!dgvProducts.Columns.Contains("Status"))
                        {
                            DataGridViewTextBoxColumn statusColumn =
                                new DataGridViewTextBoxColumn();

                            statusColumn.Name = "Status";
                            statusColumn.HeaderText = "Status";
                            statusColumn.ReadOnly = true;

                            dgvProducts.Columns.Add(statusColumn);
                        }

                        foreach (DataGridViewRow row in dgvProducts.Rows)
                        {
                            if (row.IsNewRow) continue;

                            bool active = Convert.ToBoolean(
                                row.Cells["IsActive"].Value);

                            row.Cells["Status"].Value =
                                active ? "Active" : "Inactive";

                        }

                        UpdateToggleButton();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError( "Unable to load products: " + ex.Message);
            }
        }

        private void UpdateToggleButton()
        {
            if (dgvProducts.CurrentRow == null ||
                dgvProducts.CurrentRow.IsNewRow)
            {
                btn_edit.Enabled = false;
                btn_toggle.Enabled = false;
                return;
            }

            bool isActive = Convert.ToBoolean(
                dgvProducts.CurrentRow.Cells["IsActive"].Value);

            btn_edit.Enabled = true;
            btn_toggle.Enabled = true;

            btn_toggle.Text = isActive
                ? "Deactivate Product"
                : "Activate Product";

            btn_toggle.BackColor = isActive
                ? Color.FromArgb(220, 53, 69)
                : Color.FromArgb(25, 135, 84);

            btn_toggle.ForeColor = Color.White;
        }


        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadProducts();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txt_search.Text.Trim());

        }

      

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            UpdateToggleButton();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a product.");
                return;
            }

            int productId = Convert.ToInt32(
                dgvProducts.CurrentRow.Cells["ProductID"].Value);

            bool isActive = Convert.ToBoolean(
                dgvProducts.CurrentRow.Cells["IsActive"].Value);

            string action = isActive ? "deactivate" : "activate";

            DialogResult result = MessageBox.Show(
                "Are you sure you want to " + action + " this product?",
                "Confirm Product Status",
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
                        UPDATE Products
                        SET IsActive = @status
                        WHERE ProductID = @id";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@status", !isActive);

                        cmd.Parameters.AddWithValue(
                            "@id", productId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Product status updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadProducts(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update product: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           using (AddProductForm form = new AddProductForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts(txt_search.Text.Trim());
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a product to edit.");
                return;
            }

            int productId = Convert.ToInt32(
                dgvProducts.CurrentRow.Cells["ProductID"].Value);

            using (EditProductForm form =
                new EditProductForm(productId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts(txt_search.Text.Trim());
                }
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
