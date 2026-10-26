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
    public partial class ManageAssistantForm : Form
    {
        public ManageAssistantForm()
        {
            InitializeComponent();
        }

        private void ManageAssistantForm_Load(object sender, EventArgs e)
        {
            LoadAssistants(); 

        }

        private void LoadAssistants(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT AssistantID, FullName, Phone,
                               Status, CreatedAt
                        FROM assistants
                        WHERE FullName LIKE @search
                           OR Phone LIKE @search
                        ORDER BY AssistantID DESC";

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

                        dgvAssistants.DataSource = dt;
                        dgvAssistants.ReadOnly = true;
                        dgvAssistants.AllowUserToAddRows = false;
                        dgvAssistants.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvAssistants.MultiSelect = false;
                        dgvAssistants.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvAssistants.Columns["AssistantID"].HeaderText =
                            "Assistant ID";

                        dgvAssistants.Columns["FullName"].HeaderText =
                            "Full Name";

                        dgvAssistants.Columns["Phone"].HeaderText =
                            "Phone Number";

                        dgvAssistants.Columns["Status"].HeaderText =
                            "Assistant Status";

                        dgvAssistants.Columns["CreatedAt"].HeaderText =
                            "Created Date";

                        UpdateButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load assistants: " + ex.Message);
            }
        }

        private void UpdateButtons()
        {
            if (dgvAssistants.CurrentRow == null ||
                dgvAssistants.CurrentRow.IsNewRow ||
                dgvAssistants.CurrentRow.Cells["AssistantID"].Value == null)
            {
                btn_edit.Enabled = false;
                btn_toggle.Enabled = false;
                return;
            }

            string status = Convert.ToString(
                dgvAssistants.CurrentRow.Cells["Status"].Value);

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
            LoadAssistants();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadAssistants(txt_search.Text.Trim());

        }

      

        private void dgvDrivers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (dgvAssistants.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select an assistant.");
                return;
            }

            int assistantId = Convert.ToInt32(
                dgvAssistants.CurrentRow.Cells["AssistantID"].Value);

            string currentStatus = Convert.ToString(
                dgvAssistants.CurrentRow.Cells["Status"].Value);

            if (currentStatus == "ASSIGNED" ||
                currentStatus == "ON DUTY")
            {
                MessageHelper.ShowError("Assistant status is controlled by job assignments.");
                return;
            }

            string newStatus = currentStatus == "AVAILABLE"
                ? "OFF DUTY"
                : "AVAILABLE";

            DialogResult result = MessageBox.Show(
                "Change assistant status from " + currentStatus +
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
                        UPDATE assistants
                        SET Status = @NewStatus
                        WHERE AssistantID = @AssistantID
                          AND Status = @CurrentStatus";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@NewStatus", newStatus);

                        cmd.Parameters.AddWithValue(
                            "@AssistantID", assistantId);

                        cmd.Parameters.AddWithValue(
                            "@CurrentStatus", currentStatus);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError("Assistant status has changed. Refresh and try again.");
                        }
                        else
                        {
                            MessageHelper.ShowSuccess("Assistant status updated successfully.");
                        }
                    }
                }

                LoadAssistants(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update assistant status: " + ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (AddAssistantForm form = new AddAssistantForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAssistants(txt_search.Text.Trim());
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvAssistants.CurrentRow == null)
            {
                MessageHelper.ShowError("Please select an assistant to edit.");
                return;
            }

            int assistantId = Convert.ToInt32(
                dgvAssistants.CurrentRow.Cells["AssistantID"].Value);

            using (EditAssistantForm form =
                new EditAssistantForm(assistantId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadAssistants(txt_search.Text.Trim());
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
