using EShift.Forms.Admin;
using EShift.Helpers;
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
    public partial class ManageTransportForm : Form
    {

        public ManageTransportForm()
        {
            InitializeComponent();
        }

        private void LoadAllData()
        {
            LoadAvailableJobs();
            LoadAvailableLorries();
            LoadAvailableDrivers();
            LoadAvailableAssistants();
            LoadAvailableContainers();
            LoadAssignments();
        }

        private void ConfigureGrid()
        {
            dgvAssignments.ReadOnly = true;
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAssignments.MultiSelect = false;
            dgvAssignments.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAvailableJobs()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT
                j.JobID,
                j.JobNumber,
                COUNT(l.LoadID) AS TotalLoads,
                COALESCE(SUM(l.WeightKg), 0) AS TotalWeight
            FROM Jobs j
            INNER JOIN Loads l ON l.JobID = j.JobID
            WHERE j.Status = 'ACCEPTED'
              AND NOT EXISTS (
                  SELECT 1
                  FROM TransportAssignments ta
                  WHERE ta.JobID = j.JobID
              )
            GROUP BY j.JobID, j.JobNumber
            ORDER BY j.JobID";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dt.Columns.Add("DisplayText", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        row["DisplayText"] =
                            row["JobNumber"] +
                            " | " + row["TotalLoads"] + " loads" +
                            " | " + Convert.ToDecimal(row["TotalWeight"])
                                .ToString("N2") + " kg";
                    }

                    cmbLoad.DataSource = dt;
                    cmbLoad.DisplayMember = "DisplayText";
                    cmbLoad.ValueMember = "JobID";
                    cmbLoad.SelectedIndex = -1;
                }
            }
        }

        private void LoadAvailableLorries()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT LorryID,
                               CONCAT(
                                   RegistrationNumber, ' - ',
                                   CapacityKg, ' kg'
                               ) AS LorryDisplay
                        FROM Lorries
                        WHERE UPPER(Status) = 'AVAILABLE'
                        ORDER BY RegistrationNumber";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbLorry.DataSource = null;
                        cmbLorry.DisplayMember = "LorryDisplay";
                        cmbLorry.ValueMember = "LorryID";
                        cmbLorry.DataSource = dt;
                        cmbLorry.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load available lorries: " + ex.Message);
            }
        }

        private void LoadAvailableDrivers()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT DriverID,
                               CONCAT(
                                   FullName, ' - ', Phone
                               ) AS DriverDisplay
                        FROM Drivers
                        WHERE UPPER(Status) = 'AVAILABLE'
                        ORDER BY FullName";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbDriver.DataSource = null;
                        cmbDriver.DisplayMember = "DriverDisplay";
                        cmbDriver.ValueMember = "DriverID";
                        cmbDriver.DataSource = dt;
                        cmbDriver.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load available drivers: " + ex.Message);
            }
        }

        private void LoadAvailableAssistants()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT AssistantID,
                               CONCAT(FullName, ' - ', Phone)
                                   AS AssistantDisplay
                        FROM Assistants
                        WHERE UPPER(Status) = 'AVAILABLE'
                        ORDER BY FullName";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbAssistant.DataSource = null;
                        cmbAssistant.DisplayMember = "AssistantDisplay";
                        cmbAssistant.ValueMember = "AssistantID";
                        cmbAssistant.DataSource = dt;
                        cmbAssistant.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load available assistants: " + ex.Message);
            }
        }

        private void LoadAvailableContainers()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                        SELECT ContainerID,
                               CONCAT(
                                   ContainerNumber, ' - ',
                                   CapacityKg, ' kg'
                               ) AS ContainerDisplay
                        FROM Containers
                        WHERE UPPER(Status) = 'AVAILABLE'
                        ORDER BY ContainerNumber";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbContainer.DataSource = null;
                        cmbContainer.DisplayMember = "ContainerDisplay";
                        cmbContainer.ValueMember = "ContainerID";
                        cmbContainer.DataSource = dt;
                        cmbContainer.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load available containers: " + ex.Message);
            }
        }

        private void LoadAssignments()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    string sql = @"
                    SELECT
                        ta.AssignmentID,
                        ta.JobID,
                        j.JobNumber,
                        lo.RegistrationNumber,
                        d.FullName AS Driver,
                        a.FullName AS Assistant,
                        c.ContainerNumber,
                        ta.AssignedAt,
                        ta.Status
                    FROM TransportAssignments ta
                    INNER JOIN Jobs j
                        ON j.JobID = ta.JobID
                    INNER JOIN Lorries lo
                        ON lo.LorryID = ta.LorryID
                    INNER JOIN Drivers d
                        ON d.DriverID = ta.DriverID
                    INNER JOIN Assistants a
                        ON a.AssistantID = ta.AssistantID
                    INNER JOIN Containers c
                        ON c.ContainerID = ta.ContainerID
                    ORDER BY ta.AssignmentID DESC";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvAssignments.DataSource = dt;
                    }
                }

                ConfigureGrid();

                if (dgvAssignments.Columns.Contains("AssignmentID"))
                    dgvAssignments.Columns["AssignmentID"].HeaderText =
                        "Assignment ID";

                if (dgvAssignments.Columns.Contains("JobID"))
                    dgvAssignments.Columns["JobID"].HeaderText = "Job ID";

                if (dgvAssignments.Columns.Contains("JobNumber"))
                    dgvAssignments.Columns["JobNumber"].HeaderText =
                        "Job Number";

                if (dgvAssignments.Columns.Contains("RegistrationNumber"))
                    dgvAssignments.Columns["RegistrationNumber"].HeaderText =
                        "Lorry";

                if (dgvAssignments.Columns.Contains("Driver"))
                    dgvAssignments.Columns["Driver"].HeaderText = "Driver";

                if (dgvAssignments.Columns.Contains("Assistant"))
                    dgvAssignments.Columns["Assistant"].HeaderText =
                        "Assistant";

                if (dgvAssignments.Columns.Contains("ContainerNumber"))
                    dgvAssignments.Columns["ContainerNumber"].HeaderText =
                        "Container";

                if (dgvAssignments.Columns.Contains("AssignedAt"))
                    dgvAssignments.Columns["AssignedAt"].HeaderText =
                        "Assigned Date";
                if (dgvAssignments.Columns.Contains("Status"))
                    dgvAssignments.Columns["Status"].HeaderText =
                        "Status";

            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load assignments.\n" + ex.Message);
            }
        }

        private int GetSelectedAssignmentId()
        {
            if (dgvAssignments.CurrentRow == null ||
         !dgvAssignments.Columns.Contains("AssignmentID"))
            {
                return 0;
            }

            object value =
                dgvAssignments.CurrentRow.Cells["AssignmentID"].Value;

            if (value == null || value == DBNull.Value)
                return 0;

            return Convert.ToInt32(value);
        }

        private bool TryGetComboId(ComboBox combo, out int id)
        {
            id = 0;

            if (combo.SelectedValue == null ||
                combo.SelectedValue is DataRowView)
            {
                return false;
            }

            return int.TryParse(
                Convert.ToString(combo.SelectedValue), out id) && id > 0;
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            int jobId;
            int lorryId;
            int driverId;
            int assistantId;
            int containerId;

            if (!TryGetComboId(cmbLoad, out jobId) ||
                !TryGetComboId(cmbLorry, out lorryId) ||
                !TryGetComboId(cmbDriver, out driverId) ||
                !TryGetComboId(cmbAssistant, out assistantId) ||
                !TryGetComboId(cmbContainer, out containerId))
            {
                MessageHelper.ShowError("Please select a job, lorry, driver, assistant, and container.");

                return;
            }

            DialogResult result = MessageBox.Show(
                "Assign the selected transport resources to this job?",
                "Confirm Assignment",
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

                    // Check the accepted job and calculate its total
                    // load weight. Resources are assigned to the job.
                    decimal totalWeight;

                    string jobSql = @"
                    SELECT SUM(COALESCE(l.WeightKg, 0))
                    FROM Jobs j
                    INNER JOIN Loads l ON l.JobID = j.JobID
                    WHERE j.JobID = @JobID
                      AND UPPER(j.Status) = 'ACCEPTED'
                      AND NOT EXISTS (
                          SELECT 1
                          FROM TransportAssignments ta
                          WHERE ta.JobID = j.JobID
                      )
                    FOR UPDATE";

                    using (MySqlCommand cmd =
                        new MySqlCommand(jobSql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);

                        object value = cmd.ExecuteScalar();

                        if (value == null || value == DBNull.Value)
                        {
                            throw new Exception(
                                "The job is unavailable, has no loads, " +
                                "or has already been assigned.");
                        }

                        totalWeight = Convert.ToDecimal(value);
                    }

                    if (totalWeight <= 0)
                    {
                        throw new Exception(
                            "The total weight of the job must be greater than zero.");
                    }

                    // Validate lorry and capacity.
                    decimal lorryCapacity;

                    string lorrySql = @"
                    SELECT CapacityKg
                    FROM Lorries
                    WHERE LorryID = @ID
                      AND UPPER(Status) = 'AVAILABLE'
                    FOR UPDATE";

                    using (MySqlCommand cmd =
                        new MySqlCommand(lorrySql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ID", lorryId);

                        object value = cmd.ExecuteScalar();

                        if (value == null || value == DBNull.Value)
                            throw new Exception("The selected lorry is unavailable.");

                        lorryCapacity = Convert.ToDecimal(value);
                    }

                    if (lorryCapacity < totalWeight)
                    {
                        throw new Exception(
                            "The lorry capacity is insufficient for the total job weight.");
                    }

                    // Validate driver availability.
                    CheckResourceAvailable(
                        connection, transaction,
                        "Drivers", "DriverID", driverId, "driver");

                    // Validate assistant availability.
                    CheckResourceAvailable(
                        connection, transaction,
                        "Assistants", "AssistantID", assistantId, "assistant");

                    // Validate container and capacity.
                    decimal containerCapacity;

                    string containerSql = @"
                    SELECT CapacityKg
                    FROM Containers
                    WHERE ContainerID = @ID
                      AND UPPER(Status) = 'AVAILABLE'
                    FOR UPDATE";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            containerSql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ID", containerId);

                        object value = cmd.ExecuteScalar();

                        if (value == null || value == DBNull.Value)
                        {
                            throw new Exception(
                                "The selected container is unavailable.");
                        }

                        containerCapacity = Convert.ToDecimal(value);
                    }

                    if (containerCapacity < totalWeight)
                    {
                        throw new Exception(
                            "The container capacity is insufficient for the total job weight.");
                    }

                    // Insert using JobID, not LoadID.
                    string insertSql = @"
                    INSERT INTO TransportAssignments
                        (JobID, LorryID, DriverID,
                         AssistantID, ContainerID, AssignedAt)
                    VALUES
                        (@JobID, @LorryID, @DriverID,
                         @AssistantID, @ContainerID, NOW())";

                    using (MySqlCommand cmd =
                        new MySqlCommand(insertSql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);
                        cmd.Parameters.AddWithValue("@LorryID", lorryId);
                        cmd.Parameters.AddWithValue("@DriverID", driverId);
                        cmd.Parameters.AddWithValue("@AssistantID", assistantId);
                        cmd.Parameters.AddWithValue("@ContainerID", containerId);

                        cmd.ExecuteNonQuery();
                    }

                    // Reserve all selected resources.
                    UpdateResourceStatus(
                        connection, transaction,
                        "Lorries", "LorryID", lorryId);

                    UpdateResourceStatus(
                        connection, transaction,
                        "Drivers", "DriverID", driverId);

                    UpdateResourceStatus(
                        connection, transaction,
                        "Assistants", "AssistantID", assistantId);

                    UpdateResourceStatus(
                        connection, transaction,
                        "Containers", "ContainerID", containerId);

                    transaction.Commit();

                    MessageHelper.ShowSuccess(
                        "Transport resources assigned successfully.");
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
                        "Unable to assign transport resources.\n" +
                        ex.Message);
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            LoadAllData();
        }

        private void CheckResourceAvailable(
               MySqlConnection connection,
               MySqlTransaction transaction,
               string tableName,
               string idColumn,
               int resourceId,
               string resourceName)
        {
            string sql =
                "SELECT " + idColumn +
                " FROM " + tableName +
                " WHERE " + idColumn + " = @ID" +
                " AND UPPER(Status) = 'AVAILABLE' FOR UPDATE";

            using (MySqlCommand cmd =
                new MySqlCommand(sql, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ID", resourceId);

                if (cmd.ExecuteScalar() == null)
                {
                    throw new Exception(
                        "The selected " + resourceName +
                        " is no longer available.");
                }
            }
        }

        private void UpdateResourceStatus(
           MySqlConnection connection,
           MySqlTransaction transaction,
           string tableName,
           string idColumn,
           int resourceId)
        {
            // These table and column names are internal constants
            // passed by this form, not user-entered values.
            string sql = @"
                UPDATE " + tableName + @"
                SET Status = 'ASSIGNED'
                WHERE " + idColumn + @" = @ID
                  AND UPPER(Status) = 'AVAILABLE'";

            using (MySqlCommand cmd =
                new MySqlCommand(sql, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ID", resourceId);

                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new Exception(
                        "A resource is no longer available. " +
                        "The assignment has been cancelled.");
                }
            }
        }



        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }


        private void ManageTransportForm_Load_1(object sender, EventArgs e)
        {
            cmbLoad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLorry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDriver.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssistant.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContainer.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadAllData();
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

        private void btn_manageContainers_Click(object sender, EventArgs e)
        {
            ManageContainerForm form = new ManageContainerForm();
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
