using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EShift.Helpers;
using MySql.Data.MySqlClient;

namespace EShift.Forms
{
    public partial class CustomerDashboardForm : Form
    {
        private long customerId;
        public CustomerDashboardForm()
        {
            InitializeComponent();
            customerId = SessionManager.CustomerID;
            txtCustomerName.Text = SessionManager.FullName;

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT
                            COUNT(*) AS TotalJobs,
                            COALESCE(SUM(
                                CASE
                                    WHEN UPPER(Status) = 'PENDING'
                                    THEN 1 ELSE 0
                                END
                            ), 0) AS PendingJobs,
                            COALESCE(SUM(
                                CASE
                                    WHEN UPPER(Status) = 'IN_PROGRESS'
                                    THEN 1 ELSE 0
                                END
                            ), 0) AS ProgressJobs,
                            COALESCE(SUM(
                                CASE
                                    WHEN UPPER(Status) = 'COMPLETED'
                                    THEN 1 ELSE 0
                                END
                            ), 0) AS CompletedJobs
                        FROM Jobs
                        WHERE CustomerID = @CustomerID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID", customerId);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTotalJobs.Text =
                                    reader["TotalJobs"].ToString();

                                lblPendingJobs.Text =
                                    reader["PendingJobs"].ToString();

                                lblInProgressJobs.Text =
                                    reader["ProgressJobs"].ToString();

                                lblCompletedJobs.Text =
                                    reader["CompletedJobs"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load dashboard statistics: " +
                    ex.Message);
            }
        }

        private void btn_createJob_Click(object sender, EventArgs e)
        {
            CreateJobForm form = new CreateJobForm();
            form.Show();
            this.Hide();
        }

        private void btn_myJobs_Click(object sender, EventArgs e)
        {
            MyJobsForm form = new MyJobsForm();
            form.Show();
            this.Hide();

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            CustomerProfile form = new CustomerProfile();
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

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            CreateJobForm form = new CreateJobForm();
            form.Show();
            this.Hide();

        }
    }
}
