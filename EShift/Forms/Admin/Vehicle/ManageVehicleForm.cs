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
    public partial class ManageVehicleForm : Form
    {
        public ManageVehicleForm()
        {
            InitializeComponent();
        }

        private void ManageVehicleForm_Load(object sender, EventArgs e)
        {
            LoadVehicles();

        }

        private void LoadVehicles(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT LorryID, RegistrationNumber,
                               CapacityKg, Status, CreatedAt
                        FROM Lorries
                        WHERE RegistrationNumber LIKE @search
                        ORDER BY LorryID DESC";

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

                        dgvVehicles.DataSource = dt;
                        dgvVehicles.ReadOnly = true;
                        dgvVehicles.AllowUserToAddRows = false;
                        dgvVehicles.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvVehicles.MultiSelect = false;
                        dgvVehicles.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvVehicles.Columns["LorryID"].HeaderText =
                            "Vehicle ID";

                        dgvVehicles.Columns["RegistrationNumber"].HeaderText =
                            "Registration Number";

                        dgvVehicles.Columns["CapacityKg"].HeaderText =
                            "Load Capacity (kg)";

                        dgvVehicles.Columns["Status"].HeaderText =
                            "Vehicle Status";

                        dgvVehicles.Columns["CreatedAt"].HeaderText =
                            "Created Date";

                        UpdateButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError( "Unable to load vehicles: " + ex.Message);
            }
        }

        private void UpdateButtons()
        {
            if (dgvVehicles.CurrentRow == null ||
                dgvVehicles.CurrentRow.IsNewRow ||
                dgvVehicles.CurrentRow.Cells["LorryID"].Value == null)
            {
                btn_edit.Enabled = false;
                btn_toggle.Enabled = false;
                return;
            }

            string status = Convert.ToString(
                dgvVehicles.CurrentRow.Cells["Status"].Value);

            btn_edit.Enabled = true;

            if (status == "ASSIGNED")
            {
                btn_toggle.Text = "ASSIGNED";
                btn_toggle.Enabled = false;
            }
            else if (status == "MAINTENANCE")
            {
                btn_toggle.Text = "Mark Available";
                btn_toggle.Enabled = true;
                btn_toggle.BackColor = Color.FromArgb(25, 135, 84);
            }
            else
            {
                btn_toggle.Text = "Send to Maintenance";
                btn_toggle.Enabled = true;
                btn_toggle.BackColor = Color.FromArgb(220, 53, 69);
            }

            btn_toggle.ForeColor = Color.White;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadVehicles();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadVehicles(txt_search.Text.Trim());

        }

      

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a vehicle.");
                return;
            }

            int lorryId = Convert.ToInt32(
                dgvVehicles.CurrentRow.Cells["LorryID"].Value);

            string currentStatus = Convert.ToString(
                dgvVehicles.CurrentRow.Cells["Status"].Value);

            if (currentStatus == "ASSIGNED")
            {
                MessageHelper.ShowError("An assigned vehicle cannot be changed manually.");
                return;
            }

            string newStatus = currentStatus == "AVAILABLE"
                ? "MAINTENANCE"
                : "AVAILABLE";

            DialogResult result = MessageBox.Show(
                "Change vehicle status from " + currentStatus +
                " to " + newStatus + "?",
                "Confirm Status Change",
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
                        UPDATE Lorries
                        SET Status = @Status
                        WHERE LorryID = @LorryID
                          AND Status = @CurrentStatus";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Status", newStatus);

                        cmd.Parameters.AddWithValue(
                            "@LorryID", lorryId);

                        cmd.Parameters.AddWithValue(
                            "@CurrentStatus", currentStatus);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError("The vehicle status has changed. Refresh and try again.");
                        }
                        else
                        {
                            MessageHelper.ShowSuccess("Vehicle status updated successfully.");
                        }
                    }
                }

                LoadVehicles(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update vehicle status: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (AddVehicleForm form = new AddVehicleForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadVehicles(txt_search.Text.Trim());
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a vehicle to edit.");
                return;
            }

            int lorryId = Convert.ToInt32(
                dgvVehicles.CurrentRow.Cells["LorryID"].Value);

            using (EditVehicleForm form = new EditVehicleForm(lorryId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadVehicles(txt_search.Text.Trim());
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
