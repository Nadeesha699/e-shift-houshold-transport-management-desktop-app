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
    public partial class MyJobsForm : Form
    {
        private long customerId;
        public MyJobsForm()
        {
            InitializeComponent();
            customerId = SessionManager.CustomerID;
        }

        private void MyJobsForm_Load(object sender, EventArgs e)
        {
            LoadMyJobs();
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dgvJobs.ReadOnly = true;
            dgvJobs.AllowUserToAddRows = false;
            dgvJobs.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvJobs.MultiSelect = false;
            dgvJobs.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvJobs.RowHeadersVisible = false;

            btn_view.Enabled = false;
            btn_cancelRequest.Enabled = false;
        }

        private void LoadMyJobs(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT
                            JobID,
                            JobNumber,
                            PickupLocation,
                            Destination,
                            RequestedDate,
                            Status
                        FROM Jobs
                        WHERE CustomerID = @CustomerID
                          AND (
                              JobNumber LIKE @search
                              OR PickupLocation LIKE @search
                              OR Destination LIKE @search
                              OR Status LIKE @search
                          )
                        ORDER BY CreatedAt DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID", customerId);

                        cmd.Parameters.AddWithValue(
                            "@search", "%" + search + "%");

                        DataTable dt = new DataTable();

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dgvJobs.DataSource = dt;

                        if (dgvJobs.Columns["JobID"] != null)
                            dgvJobs.Columns["JobID"].Visible = false;

                        if (dgvJobs.Columns["JobNumber"] != null)
                            dgvJobs.Columns["JobNumber"].HeaderText =
                                "Job Number";

                        if (dgvJobs.Columns["PickupLocation"] != null)
                            dgvJobs.Columns["PickupLocation"].HeaderText =
                                "Pickup Location";

                        if (dgvJobs.Columns["Destination"] != null)
                            dgvJobs.Columns["Destination"].HeaderText =
                                "Destination";

                        if (dgvJobs.Columns["RequestedDate"] != null)
                        {
                            dgvJobs.Columns["RequestedDate"].HeaderText =
                                "Requested Date";

                            dgvJobs.Columns["RequestedDate"]
                                .DefaultCellStyle.Format = "dd MMM yyyy";
                        }

                        if (dgvJobs.Columns["Status"] != null)
                            dgvJobs.Columns["Status"].HeaderText =
                                "Booking Status";

                        UpdateActionButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load your bookings: " + ex.Message);
            }
        }

        private int GetSelectedJobId()
        {
            if (dgvJobs.CurrentRow == null ||
                dgvJobs.CurrentRow.IsNewRow)
            {
                return 0;
            }

            return Convert.ToInt32(
                dgvJobs.CurrentRow.Cells["JobID"].Value);
        }

        private string GetSelectedStatus()
        {
            if (dgvJobs.CurrentRow == null ||
                dgvJobs.CurrentRow.IsNewRow)
            {
                return string.Empty;
            }

            return Convert.ToString(
                dgvJobs.CurrentRow.Cells["Status"].Value)
                .Trim().ToUpperInvariant();
        }

        private void UpdateActionButtons()
        {
            bool hasSelection = GetSelectedJobId() > 0;

            btn_view.Enabled = hasSelection;

            btn_cancelRequest.Enabled =
                hasSelection && GetSelectedStatus() == "PENDING";

            if (!hasSelection)
            {
                btn_cancelRequest.Text = "Cancel Request";
                btn_cancelRequest.BackColor =
                    SystemColors.Control;
                return;
            }

            if (GetSelectedStatus() == "PENDING")
            {
                btn_cancelRequest.Text = "Cancel Request";
                btn_cancelRequest.BackColor =
                    Color.FromArgb(220, 53, 69);
            }
            else
            {
                btn_cancelRequest.Text = "Cannot Cancel";
                btn_cancelRequest.BackColor =
                    SystemColors.Control;
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadMyJobs();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadMyJobs(txt_search.Text.Trim());

        }

      

        private void dgvJobs_SelectionChanged(object sender, EventArgs e)
        {
            UpdateActionButtons();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            int jobId = GetSelectedJobId();

            if (jobId <= 0)
            {
                MessageHelper.ShowError("Please select a booking.");
                return;
            }

            if (GetSelectedStatus() != "PENDING")
            {
                MessageHelper.ShowError(
                    "Only pending bookings can be cancelled.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancellation",
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
                UPDATE Jobs
                SET Status = 'CANCELLED'
                WHERE JobID = @JobID
                  AND CustomerID = @CustomerID
                  AND Status = 'PENDING'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageHelper.ShowSuccess(
                                "Booking cancelled successfully.");

                            LoadMyJobs(txt_search.Text.Trim());
                        }
                        else
                        {
                            MessageHelper.ShowError(
                                "Booking could not be cancelled. " +
                                "Please refresh and check its status.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to cancel booking: " + ex.Message);
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            int jobId = GetSelectedJobId();

            if (jobId <= 0)
            {
                MessageHelper.ShowError(
                    "Please select a booking to view.");
                return;
            }

            using (ViewJobForm detailsForm =
                new ViewJobForm(jobId, customerId))
            {
                detailsForm.ShowDialog(this);
            }
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            CustomerProfile form = new CustomerProfile();
            form.Show();
            this.Hide();

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
