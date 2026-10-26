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
    public partial class ManageDriverForm : Form
    {
        public ManageDriverForm()
        {
            InitializeComponent();
        }

        private void ManageDriverForm_Load(object sender, EventArgs e)
        {
            LoadDrivers();

        }

        private void LoadDrivers(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT DriverID, FullName, Phone,
                               LicenceNumber, Status, CreatedAt
                        FROM Drivers
                        WHERE FullName LIKE @search
                           OR Phone LIKE @search
                           OR LicenceNumber LIKE @search
                        ORDER BY DriverID DESC";

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

                        dgvDrivers.DataSource = dt;
                        dgvDrivers.ReadOnly = true;
                        dgvDrivers.AllowUserToAddRows = false;
                        dgvDrivers.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvDrivers.MultiSelect = false;
                        dgvDrivers.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvDrivers.Columns["DriverID"].HeaderText =
                            "Driver ID";

                        dgvDrivers.Columns["FullName"].HeaderText =
                            "Full Name";

                        dgvDrivers.Columns["Phone"].HeaderText =
                            "Phone Number";

                        dgvDrivers.Columns["LicenceNumber"].HeaderText =
                            "Driving Licence Number";

                        dgvDrivers.Columns["Status"].HeaderText =
                            "Driver Status";

                        dgvDrivers.Columns["CreatedAt"].HeaderText =
                            "Created Date";

                        UpdateButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load drivers: " + ex.Message);
            }
        }

        private void UpdateButtons()
        {
            if (dgvDrivers.CurrentRow == null ||
                dgvDrivers.CurrentRow.IsNewRow ||
                dgvDrivers.CurrentRow.Cells["DriverID"].Value == null)
            {
                btn_edit.Enabled = false;
                btn_toggle.Enabled = false;
                return;
            }

            string status = Convert.ToString(
                dgvDrivers.CurrentRow.Cells["Status"].Value);

            btn_edit.Enabled = true;

            if (status == "ASSIGNED" || status == "ON DUTY")
            {
                btn_toggle.Text = "Status Managed by Jobs";
                btn_toggle.Enabled = false;
            }
            else if (status == "AVAILABLE")
            {
                btn_toggle.Text = "Set Off Duty";
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
            LoadDrivers();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadDrivers(txt_search.Text.Trim());

        }

      

        private void dgvDrivers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a driver.");
                return;
            }

            int driverId = Convert.ToInt32(
                dgvDrivers.CurrentRow.Cells["DriverID"].Value);

            string currentStatus = Convert.ToString(
                dgvDrivers.CurrentRow.Cells["Status"].Value);

            if (currentStatus == "ASSIGNED" ||
                currentStatus == "ON DUTY")
            {
                MessageHelper.ShowError( "Driver status is controlled by job assignments.");
                return;
            }

            string newStatus = currentStatus == "AVAILABLE"
                ? "OFF DUTY"
                : "AVAILABLE";

            DialogResult result = MessageBox.Show(
                "Change driver status from " + currentStatus +
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
                        UPDATE Drivers
                        SET Status = @NewStatus
                        WHERE DriverID = @DriverID
                          AND Status = @CurrentStatus";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@NewStatus", newStatus);

                        cmd.Parameters.AddWithValue(
                            "@DriverID", driverId);

                        cmd.Parameters.AddWithValue(
                            "@CurrentStatus", currentStatus);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError("Driver status has changed. Refresh and try again.");
                        }
                        else
                        {
                            MessageHelper.ShowSuccess("Driver status updated successfully.");
                        }
                    }
                }

                LoadDrivers(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update driver status: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (AddDriverForm form = new AddDriverForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDrivers(txt_search.Text.Trim());
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select a driver to edit.");
                return;
            }

            int driverId = Convert.ToInt32(
                dgvDrivers.CurrentRow.Cells["DriverID"].Value);

            using (EditDriverForm form =
                new EditDriverForm(driverId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDrivers(txt_search.Text.Trim());
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

        private void btn_manageLorries_Click(object sender, EventArgs e)
        {
            ManageVehicleForm form = new ManageVehicleForm();
            form.Show();
            this.Hide();


        }
    }

}
