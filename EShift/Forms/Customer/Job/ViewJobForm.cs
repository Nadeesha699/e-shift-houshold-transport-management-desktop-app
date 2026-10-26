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
using System.Windows.Forms;
using EShift.Helpers;

namespace EShift.Forms.Admin
{
    public partial class ViewJobForm : Form
    {
        private int jobId;
        private long customerId;


        public ViewJobForm(int selectedJobId, long selectedCustomerId)
        {
            InitializeComponent();

            jobId = selectedJobId;
            customerId = selectedCustomerId;
        }


       

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void ViewJobForm_Load(object sender, EventArgs e)
        {
            LoadJobDetails();
        }

        private void LoadJobDetails()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string jobSql = @"
                        SELECT JobNumber, PickupLocation,
                               Destination, RequestedDate,
                               Status, DeclineReason, CreatedAt
                        FROM Jobs
                        WHERE JobID = @JobID
                          AND CustomerID = @CustomerID";

                    DataTable jobTable = new DataTable();

                    using (MySqlCommand cmd =
                        new MySqlCommand(jobSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);
                        cmd.Parameters.AddWithValue(
                            "@CustomerID", customerId);

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(jobTable);
                        }
                    }

                    if (jobTable.Rows.Count == 0)
                    {
                        MessageHelper.ShowError(
                            "Booking not found or access denied.");
                        Close();
                        return;
                    }

                    DataRow job = jobTable.Rows[0];

                    lblJobNumber.Text =
                        Convert.ToString(job["JobNumber"]);

                    lblPickup.Text =
                        Convert.ToString(job["PickupLocation"]);

                    lblDestination.Text =
                        Convert.ToString(job["Destination"]);

                    lblRequestedDate.Text =
                        Convert.ToDateTime(job["RequestedDate"])
                        .ToString("dd MMM yyyy hh:mm tt");

                    lblStatus.Text =
                        Convert.ToString(job["Status"]);

                    lblCreatedAt.Text =
                        Convert.ToDateTime(job["CreatedAt"])
                        .ToString("dd MMM yyyy");

                    lblDeclineReason.Text =
                        job["DeclineReason"] == DBNull.Value
                        ? "No decline reason provided"
                        : Convert.ToString(job["DeclineReason"]);

                    string loadsSql = @"
                        SELECT LoadNumber, Description,
                               Quantity, WeightKg
                        FROM Loads
                        WHERE JobID = @JobID
                        ORDER BY LoadID";

                    DataTable loads = new DataTable();

                    using (MySqlCommand cmd =
                        new MySqlCommand(loadsSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(loads);
                        }
                    }

                    dgvLoads.DataSource = loads;

                    dgvLoads.ReadOnly = true;
                    dgvLoads.AllowUserToAddRows = false;
                    dgvLoads.AllowUserToDeleteRows = false;
                    dgvLoads.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLoads.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvLoads.RowHeadersVisible = false;

                    decimal totalWeight = 0;

                    foreach (DataRow load in loads.Rows)
                    {
                        if (load["WeightKg"] != DBNull.Value)
                        {
                            totalWeight +=
                                Convert.ToDecimal(load["WeightKg"]);
                        }
                    }

                    lblTotalWeight.Text =
                        totalWeight.ToString("0.00") + " kg";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load booking details: " + ex.Message);
            }
        }


    }
}
