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
    public partial class ManageContainerForm : Form
    {
        public ManageContainerForm()
        {
            InitializeComponent();
        }

        private void ManageContainersForm_Load(object sender, EventArgs e)
        {
            LoadContainers();

        }

        private void LoadContainers(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT ContainerID, ContainerNumber,
                               CapacityKg, Status, CreatedAt
                        FROM Containers
                        WHERE ContainerNumber LIKE @search
                        ORDER BY ContainerID DESC";

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

                        dgvContainers.DataSource = dt;
                        dgvContainers.ReadOnly = true;
                        dgvContainers.AllowUserToAddRows = false;
                        dgvContainers.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvContainers.MultiSelect = false;
                        dgvContainers.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvContainers.Columns["ContainerID"].HeaderText =
                            "Container ID";

                        dgvContainers.Columns["ContainerNumber"].HeaderText =
                            "Container Number";

                        dgvContainers.Columns["CapacityKg"].HeaderText =
                            "Capacity (kg)";

                        dgvContainers.Columns["Status"].HeaderText =
                            "Container Status";

                        dgvContainers.Columns["CreatedAt"].HeaderText =
                            "Created Date";

                        UpdateButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load containers: " + ex.Message);
            }
        }

        private void UpdateButtons()
        {
            if (dgvContainers.CurrentRow == null ||
               dgvContainers.CurrentRow.IsNewRow ||
               dgvContainers.CurrentRow.Cells["ContainerID"].Value == null)
            {
                btn_edit.Enabled = false;
                btn_toggle.Enabled = false;
                return;
            }

            string status = Convert.ToString(
                dgvContainers.CurrentRow.Cells["Status"].Value);

            btn_edit.Enabled = status != "ASSIGNED";

            if (status == "ASSIGNED")
            {
                btn_toggle.Text = "Status Managed by Jobs";
                btn_toggle.Enabled = false;
            }
            else if (status == "AVAILABLE")
            {
                btn_toggle.Text = "Set Maintenance";
                btn_toggle.BackColor =
                    Color.FromArgb(220, 53, 69);
                btn_toggle.ForeColor = Color.White;
                btn_toggle.Enabled = true;
            }
            else
            {
                btn_toggle.Text = "Set Available";
                btn_toggle.BackColor =
                    Color.FromArgb(25, 135, 84);
                btn_toggle.ForeColor = Color.White;
                btn_toggle.Enabled = true;
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadContainers();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadContainers(txt_search.Text.Trim());

        }

      

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (dgvContainers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a container.");
                return;
            }

            int containerId = Convert.ToInt32(
                dgvContainers.CurrentRow.Cells["ContainerID"].Value);

            string currentStatus = Convert.ToString(
                dgvContainers.CurrentRow.Cells["Status"].Value);

            if (currentStatus == "ASSIGNED")
            {
                MessageHelper.ShowError("Container status is controlled by job assignments.");
                return;
            }

            string newStatus = currentStatus == "AVAILABLE"
                ? "MAINTENANCE"
                : "AVAILABLE";

            DialogResult result = MessageBox.Show(
                "Change container status from " + currentStatus +
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
                        UPDATE Containers
                        SET Status = @NewStatus
                        WHERE ContainerID = @ContainerID
                          AND Status = @CurrentStatus";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@NewStatus", newStatus);

                        cmd.Parameters.AddWithValue(
                            "@ContainerID", containerId);

                        cmd.Parameters.AddWithValue(
                            "@CurrentStatus", currentStatus);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError("Container status has changed. Refresh and try again.");
                        }
                        else
                        {
                            MessageHelper.ShowSuccess("Container status updated successfully.");
                        }
                    }
                }

                LoadContainers(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update container status: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (AddContainerForm form = new AddContainerForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadContainers(txt_search.Text.Trim());
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvContainers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a container to edit.");
                return;
            }

            int containerId = Convert.ToInt32(
                dgvContainers.CurrentRow.Cells["ContainerID"].Value);

            using (EditContainerForm form =
                new EditContainerForm(containerId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadContainers(txt_search.Text.Trim());
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

        private void btn_manageLorries_Click(object sender, EventArgs e)
        {
            ManageVehicleForm form = new ManageVehicleForm();
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
