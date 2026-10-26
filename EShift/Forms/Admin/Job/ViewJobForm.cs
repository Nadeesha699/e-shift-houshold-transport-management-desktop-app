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
    public partial class ViewJobAdminForm : Form
    {
        private int jobId;


        public ViewJobAdminForm(int selectedJobId)
        {
            InitializeComponent();

            jobId = selectedJobId;
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
                SELECT
                    j.JobNumber,
                    u.FullName AS Customer,
                    j.PickupLocation,
                    j.Destination,
                    j.RequestedDate,
                    j.Status,
                    j.DeclineReason,
                    j.CreatedAt
                FROM Jobs j
                INNER JOIN Customers c
                    ON j.CustomerID = c.CustomerID
                INNER JOIN Users u
                    ON c.UserID = u.UserID
                WHERE j.JobID = @JobID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(jobSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblJobNumber.Text =
                                     reader["JobNumber"].ToString();

                                lblCustomer.Text =
                                     reader["Customer"].ToString();

                                lblPickup.Text =
                                    reader["PickupLocation"].ToString();

                                lblDestination.Text =
                                    reader["Destination"].ToString();

                                lblRequestedDate.Text =
                                    
                                    Convert.ToDateTime(reader["RequestedDate"])
                                        .ToString("yyyy-MM-dd hh:mm tt");

                                lblCreatedAt.Text =
                                    Convert.ToDateTime(reader["CreatedAt"])
                                        .ToString("yyyy-MM-dd");

                                lblDeclineReason.Text = reader["DeclineReason"] != DBNull.Value
                                     ? reader["DeclineReason"].ToString()
                                     : "No decline reason provided";

                                lblStatus.Text =
                                    reader["Status"].ToString();
                            }
                            else
                            {
                                MessageHelper.ShowError("Job not found.");

                                Close();
                                return;
                            }
                        }
                    }

                    // 2. Load the job's items into the DataGridView
                    string loadSql = @"
                SELECT
                    LoadNumber,
                    Description,
                    Quantity,
                    WeightKg
                FROM Loads
                WHERE JobID = @JobID";

                    using (MySqlCommand loadCmd =
                        new MySqlCommand(loadSql, connection))
                    {
                        loadCmd.Parameters.AddWithValue("@JobID", jobId);

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(loadCmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvLoads.DataSource = table;
                        }
                    }

                    // 3. Configure the DataGridView
                    dgvLoads.ReadOnly = true;
                    dgvLoads.AllowUserToAddRows = false;
                    dgvLoads.AllowUserToDeleteRows = false;
                    dgvLoads.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLoads.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    dgvLoads.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load job details: " + ex.Message);
            }
        }


    }
}
