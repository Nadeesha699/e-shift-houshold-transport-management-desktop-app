using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EShift.Forms.Admin;
using EShift.Helpers;
using MySql.Data.MySqlClient;

namespace EShift.Forms
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
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

                    lblTotalUsers.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Users").ToString();

                    lblTotalCustomers.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Customers").ToString();

                    lblTotalProducts.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Products").ToString();

                    lblTotalJobs.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Jobs").ToString();

                    lblPendingJobs.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Jobs WHERE UPPER(Status) = 'PENDING'").ToString();

                    lblProgressJobs.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Jobs WHERE UPPER(Status) = 'IN_PROGRESS'").ToString();

                    lblCompleteJobs.Text =
                        GetCount(connection,
                            "SELECT COUNT(*) FROM Jobs WHERE UPPER(Status) = 'COMPLETED'").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load dashboard statistics: " + ex.Message);
            }
        }

        private int GetCount(
            MySqlConnection connection, string sql)
        {
            using (MySqlCommand cmd =
                new MySqlCommand(sql, connection))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
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
