using EShift.Forms.Admin;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;
using EShift.Helpers;
using System.Reflection;
using System.Security.Cryptography;

namespace EShift.Forms
{
    public partial class ManageJobForm : Form
    {
        public ManageJobForm()
        {
            InitializeComponent();
        }

        private void ManageJobForm_Load(object sender, EventArgs e)
        {
            LoadJobs();

        }
        private void LoadJobs(string search = "")
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {

                    string sql = @"
                           SELECT
                              j.JobID,
                              j.JobNumber,
                              u.FullName AS Customer,
                              j.PickupLocation,
                              j.Destination,
                              j.RequestedDate,
                              j.Status
                          FROM Jobs j
                          INNER JOIN Customers c
                              ON j.CustomerID = c.CustomerID
                          INNER JOIN Users u
                              ON c.UserID = u.UserID
                          WHERE j.JobNumber LIKE @search
                              OR u.FullName LIKE @search
                              OR j.PickupLocation LIKE @search
                              OR j.Destination LIKE @search
                          ORDER BY j.JobID DESC";

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

                        dgvJobs.DataSource = dt;
                        dgvJobs.ReadOnly = true;
                        dgvJobs.AllowUserToAddRows = false;
                        dgvJobs.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dgvJobs.MultiSelect = false;
                        dgvJobs.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvJobs.Columns["JobID"].Visible = false;
                        dgvJobs.Columns["JobNumber"].HeaderText =
                            "Job Number";
                        dgvJobs.Columns["Customer"].HeaderText =
                            "Customer";
                        dgvJobs.Columns["PickupLocation"].HeaderText =
                            "Pickup Location";
                        dgvJobs.Columns["Destination"].HeaderText =
                            "Destination";
                        dgvJobs.Columns["RequestedDate"].HeaderText =
                            "Requested Date";
                        dgvJobs.Columns["Status"].HeaderText =
                            "Status";

                        UpdateButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load jobs: " + ex.Message);
            }
        }
        private int GetSelectedJobId()
        {
            if (dgvJobs.CurrentRow == null ||
                dgvJobs.CurrentRow.Cells["JobID"].Value == null)
            {
                return 0;
            }

            return Convert.ToInt32(
                dgvJobs.CurrentRow.Cells["JobID"].Value);
        }

        private string GetSelectedStatus()
        {
            if (dgvJobs.CurrentRow == null)
                return "";

            return Convert.ToString(
                dgvJobs.CurrentRow.Cells["Status"].Value);
        }

        private void UpdateButtons()
        {
            string status = GetSelectedStatus();

            btn_view.Enabled = GetSelectedJobId() > 0;
            btn_accept.Enabled = status == "PENDING";
            btn_decline.Enabled = status == "PENDING";

            btn_updateStatus.Enabled =
                status == "ACCEPTED" ||
                status == "IN_PROGRESS";
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            LoadJobs();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadJobs(txt_search.Text.Trim());

        }

        private void dgvJobs_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            int selectedJobId = GetSelectedJobId();

            if (selectedJobId == 0)
            {
                MessageHelper.ShowError("Please select a job first.");

                return;
            }

            using (ViewJobAdminForm form =
                new ViewJobAdminForm(selectedJobId))
            {
                form.ShowDialog(this);
            }
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            ChangeJobStatus("ACCEPTED");
        }

        private void btn_decline_Click(object sender, EventArgs e)
        {
            int jobId = GetSelectedJobId();

            if (jobId == 0 || GetSelectedStatus() != "PENDING")
            {
                MessageHelper.ShowError(
                    "Select a pending job to decline.");
                return;
            }

            string reason;

            using (DeclineJobForm popup = new DeclineJobForm())
            {
                popup.StartPosition = FormStartPosition.CenterParent;

                if (popup.ShowDialog(this) != DialogResult.OK)
                    return;

                reason = popup.DeclineReason;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to decline this job?",
                "Confirm Decline",
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
                        SET Status = 'DECLINED',
                            DeclineReason = @Reason
                        WHERE JobID = @JobID
                          AND Status = 'PENDING'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Reason", reason.Trim());

                        cmd.Parameters.AddWithValue(
                            "@JobID", jobId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError(
                                "The job status changed. Refresh and try again.");
                        }
                        else
                        {
                            MessageHelper.ShowSuccess(
                                "Job declined successfully.");
                        }
                    }
                }

                LoadJobs(txt_search.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to decline job: " + ex.Message);
            }

        }

        private void ChangeJobStatus(string newStatus)
        {
            int jobId = GetSelectedJobId();

            if (jobId == 0)
            {
                MessageHelper.ShowError("Please select a job.");
                return;
            }

            string currentStatus = GetSelectedStatus();

            if (newStatus == currentStatus)
            {
                MessageHelper.ShowError("The job already has this status.");
                return;
            }

            if (currentStatus == "COMPLETED")
            {
                MessageHelper.ShowError("This job is already completed.");
                return;
            }

            if (currentStatus == "PENDING" &&
                newStatus != "ACCEPTED" &&
                newStatus != "DECLINED")
            {
                MessageHelper.ShowError(
                    "Pending jobs can only be accepted or declined.");
                return;
            }

            if (currentStatus == "DECLINED" ||
                currentStatus == "CANCELLED")
            {
                MessageHelper.ShowError(
                    "This job cannot be updated because it is " +
                    currentStatus.ToLower() + ".");
                return;
            }

            if (newStatus == "COMPLETED" &&
                currentStatus != "IN_PROGRESS")
            {
                MessageHelper.ShowError(
                    "Only jobs in progress can be completed.");
                return;
            }

            if (newStatus == "IN_PROGRESS" &&
                currentStatus != "ACCEPTED")
            {
                MessageHelper.ShowError(
                    "Only accepted jobs can be started.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Change job status from " + currentStatus +
                " to " + newStatus + "?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (MySqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                MySqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Step 1: Update job status
                    string updateJobSql = @"
                UPDATE Jobs
                SET Status = @NewStatus
                WHERE JobID = @JobID
                  AND Status = @CurrentStatus";

                    using (MySqlCommand cmd = new MySqlCommand(
                        updateJobSql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue(
                            "@NewStatus", newStatus);

                        cmd.Parameters.AddWithValue(
                            "@JobID", jobId);

                        cmd.Parameters.AddWithValue(
                            "@CurrentStatus", currentStatus);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows != 1)
                        {
                            throw new Exception(
                                "The job status has changed. Please refresh and try again.");
                        }
                    }

                    // Step 2: Release resources only when the job is completed
                    if (newStatus == "COMPLETED")
                    {
                        // Mark assignments as RELEASED instead of deleting them.
                        string releaseAssignmentsSql = @"
                            UPDATE TransportAssignments
                            SET Status = 'RELEASED'
                            WHERE JobID = @JobID
                                 AND Status = 'ASSIGNED'";

                        using (MySqlCommand cmd = new MySqlCommand(
                            releaseAssignmentsSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@JobID", jobId);
                            cmd.ExecuteNonQuery();
                        }

                        // Return resources to AVAILABLE only when no active assignments remain.
                        string[] resourceSql =
                        {
                          @"UPDATE Lorries
                            SET Status = 'AVAILABLE'
                            WHERE UPPER(Status) = 'ASSIGNED'
                            AND NOT EXISTS
                            (
                              SELECT 1
                              FROM TransportAssignments ta
                              WHERE ta.LorryID = Lorries.LorryID
                                AND ta.Status = 'ASSIGNED'
                            )",

                          @"UPDATE Drivers
                            SET Status = 'AVAILABLE'
                            WHERE UPPER(Status) = 'ASSIGNED'
                            AND NOT EXISTS
                            (
                              SELECT 1
                              FROM TransportAssignments ta
                              WHERE ta.DriverID = Drivers.DriverID
                               AND ta.Status = 'ASSIGNED'
                            )",

                          @"UPDATE Assistants
                            SET Status = 'AVAILABLE'
                            WHERE UPPER(Status) = 'ASSIGNED'
                            AND NOT EXISTS
                            (
                              SELECT 1
                              FROM TransportAssignments ta
                              WHERE ta.AssistantID = Assistants.AssistantID
                               AND ta.Status = 'ASSIGNED'
                            )",

                          @"UPDATE Containers
                            SET Status = 'AVAILABLE'
                            WHERE UPPER(Status) = 'ASSIGNED'
                            AND NOT EXISTS
                            (
                              SELECT 1
                              FROM TransportAssignments ta
                              WHERE ta.ContainerID = Containers.ContainerID
                              AND ta.Status = 'ASSIGNED'
                            )"
                        };

                        foreach (string sql in resourceSql)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                sql, connection, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }



                    // Step 3: Commit all changes together
                    transaction.Commit();

                    if (newStatus == "COMPLETED")
                    {
                        MessageHelper.ShowSuccess(
                            "Job completed successfully. " +
                            "Unused lorries, drivers, assistants and containers " +
                            "have been returned to available status.");
                    }
                    else
                    {
                        MessageHelper.ShowSuccess(
                            "Job status updated to " + newStatus + ".");
                    }
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                            // Preserve the original error.
                        }
                    }

                    MessageHelper.ShowError(
                        "Unable to update job status: " + ex.Message);
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            LoadJobs(txt_search.Text.Trim());
        }



        private void btn_updateStatus_Click(object sender, EventArgs e)
        {
            string currentStatus = GetSelectedStatus();

            if (currentStatus == "ACCEPTED")
            {
                ChangeJobStatus("IN_PROGRESS");
            }
            else if (currentStatus == "IN_PROGRESS")
            {
                ChangeJobStatus("COMPLETED");
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
