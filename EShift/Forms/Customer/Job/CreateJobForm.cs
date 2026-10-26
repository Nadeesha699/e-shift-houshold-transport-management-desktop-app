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
    public partial class CreateJobForm : Form
    {
        private long customerId;
        private long userId;
        private DataTable itemTable;
        public CreateJobForm()
        {
            InitializeComponent();
            customerId = SessionManager.CustomerID;
            userId = SessionManager.UserID;
        }

        private void CreateJobForm_Load(object sender, EventArgs e)
        {
            dtpRequestedDate.MinDate = DateTime.Today;
            dtpRequestedDate.Value = DateTime.Today;

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;

            numWeight.Minimum = 0.01M;
            numWeight.Maximum = 100000M;
            numWeight.DecimalPlaces = 2;

            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            SetupItemTable();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT ProductID, ProductName
                        FROM Products
                        WHERE IsActive = 1
                        ORDER BY ProductName";

                    DataTable products = new DataTable();

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        adapter.Fill(products);
                    }

                    // ProductID 0 means a custom household item.
                    DataRow customRow = products.NewRow();
                    customRow["ProductID"] = 0;
                    customRow["ProductName"] = "Other / Custom Item";
                    products.Rows.InsertAt(customRow, 0);

                    cmbProduct.DataSource = products;
                    cmbProduct.DisplayMember = "ProductName";
                    cmbProduct.ValueMember = "ProductID";
                    cmbProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    "Unable to load products.\n" + ex.Message);
            }
        }


        private void SetupItemTable()
        {
            itemTable = new DataTable();

            itemTable.Columns.Add("ProductID", typeof(int));
            itemTable.Columns.Add("Item", typeof(string));
            itemTable.Columns.Add("Description", typeof(string));
            itemTable.Columns.Add("Quantity", typeof(int));
            itemTable.Columns.Add("WeightPerItemKg", typeof(decimal));
            itemTable.Columns.Add("TotalWeightKg", typeof(decimal));

            dgvItems.DataSource = itemTable;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.ReadOnly = true;
            dgvItems.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvItems.Columns["ProductID"].Visible = false;
            dgvItems.Columns["WeightPerItemKg"].HeaderText =
                "Weight per item (kg)";
            dgvItems.Columns["TotalWeightKg"].HeaderText =
                "Total weight (kg)";
        }



        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string pickup = txt_pickup.Text.Trim();
            string destination = txt_destination.Text.Trim();

            if (pickup.Length == 0)
            {
                MessageHelper.ShowError("Please enter the pickup location.");
                txt_pickup.Focus();
                return;
            }

            if (destination.Length == 0)
            {
                MessageHelper.ShowError("Please enter the destination.");
                txt_destination.Focus();
                return;
            }

            if (string.Equals(
                pickup, destination,
                StringComparison.OrdinalIgnoreCase))
            {
                MessageHelper.ShowError(
                    "Pickup location and destination must be different.");
                return;
            }

            if (dtpRequestedDate.Value.Date < DateTime.Today)
            {
                MessageHelper.ShowError(
                    "The requested date cannot be in the past.");
                return;
            }

            if (itemTable.Rows.Count == 0)
            {
                MessageHelper.ShowError(
                    "Add at least one household item before submitting.");
                return;
            }

            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                connection = DatabaseConnection.GetConnection();
                connection.Open();

                transaction = connection.BeginTransaction();

                // Verify that the authenticated customer profile
                // is linked to the logged-in user and is active.
                string customerSql = @"
                       SELECT COUNT(*)
                       FROM Customers c
                       INNER JOIN Users u ON c.UserID = u.UserID
                       WHERE c.CustomerID = @CustomerID
                         AND u.UserID = @UserID
                         AND UPPER(u.Role) = 'CUSTOMER'
                         AND u.IsActive = 1";

                using (MySqlCommand customerCommand =
                    new MySqlCommand(customerSql, connection, transaction))
                {
                    customerCommand.Parameters.AddWithValue(
                        "@CustomerID", customerId);

                    customerCommand.Parameters.AddWithValue(
                        "@UserID", userId);

                    int customerExists = Convert.ToInt32(
                        customerCommand.ExecuteScalar());

                    if (customerExists == 0)
                    {
                        throw new Exception(
                            "Your customer account is not active or the customer profile is invalid. " +
                            "Please contact the administrator.");
                    }
                }

                string jobNumber =
                    "JOB" + Guid.NewGuid().ToString("N")
                        .Substring(0, 12).ToUpper();

                string jobSql = @"
                    INSERT INTO Jobs
                    (
                        JobNumber,
                        CustomerID,
                        PickupLocation,
                        Destination,
                        RequestedDate,
                        Status
                    )
                    VALUES
                    (
                        @JobNumber,
                        @CustomerID,
                        @PickupLocation,
                        @Destination,
                        @RequestedDate,
                        'PENDING'
                    )";

                int jobId;

                using (MySqlCommand jobCommand =
                    new MySqlCommand(jobSql, connection, transaction))
                {
                    jobCommand.Parameters.AddWithValue(
                        "@JobNumber", jobNumber);
                    jobCommand.Parameters.AddWithValue(
                        "@CustomerID", customerId);
                    jobCommand.Parameters.AddWithValue(
                        "@PickupLocation", pickup);
                    jobCommand.Parameters.AddWithValue(
                        "@Destination", destination);
                    jobCommand.Parameters.AddWithValue(
                        "@RequestedDate", dtpRequestedDate.Value.Date);

                    jobCommand.ExecuteNonQuery();
                    jobId = Convert.ToInt32(jobCommand.LastInsertedId);
                }

                string loadSql = @"
                    INSERT INTO Loads
                    (
                        LoadNumber,
                        JobID,
                        ProductID,
                        Description,
                        Quantity,
                        WeightKg
                    )
                    VALUES
                    (
                        @LoadNumber,
                        @JobID,
                        @ProductID,
                        @Description,
                        @Quantity,
                        @WeightKg
                    )";

                int itemNumber = 1;

                foreach (DataRow row in itemTable.Rows)
                {
                    int selectedProductId =
                        Convert.ToInt32(row["ProductID"]);

                    object productValue =
                        selectedProductId == 0
                            ? (object)DBNull.Value
                            : selectedProductId;

                    string loadNumber = jobNumber + "-L" +
                        itemNumber.ToString("00");

                    using (MySqlCommand loadCommand =
                        new MySqlCommand(loadSql, connection, transaction))
                    {
                        loadCommand.Parameters.AddWithValue(
                            "@LoadNumber", loadNumber);
                        loadCommand.Parameters.AddWithValue(
                            "@JobID", jobId);
                        loadCommand.Parameters.AddWithValue(
                            "@ProductID", productValue);
                        loadCommand.Parameters.AddWithValue(
                            "@Description", row["Description"]);
                        loadCommand.Parameters.AddWithValue(
                            "@Quantity", row["Quantity"]);

                        // WeightKg stores the total weight for this load,
                        // not the weight of just one item.
                        loadCommand.Parameters.AddWithValue(
                            "@WeightKg", row["TotalWeightKg"]);

                        loadCommand.ExecuteNonQuery();
                    }

                    itemNumber++;
                }

                transaction.Commit();

                MessageHelper.ShowSuccess(
                    "Job submitted successfully!\n\n" +
                    "Job Number: " + jobNumber +
                    "\nStatus: Pending");

                ClearForm();
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
                    "Unable to submit the booking.\n" + ex.Message);
            }
            finally
            {
                if (transaction != null)
                    transaction.Dispose();

                if (connection != null)
                    connection.Dispose();
            }
        }

        private void ClearForm()
        {
            txt_pickup.Clear();
            txt_destination.Clear();
            txt_itemdescription.Clear();

            dtpRequestedDate.Value = DateTime.Today;

            if (cmbProduct.Items.Count > 0)
                cmbProduct.SelectedIndex = 0;

            numQuantity.Value = 1;
            numWeight.Value = 1;

            if (itemTable != null)
                itemTable.Rows.Clear();

            txt_pickup.Focus();
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null)
            {
                MessageHelper.ShowError("Please select a product.");
                return;
            }

            int productId =
                Convert.ToInt32(cmbProduct.SelectedValue);

            string productName =
                cmbProduct.Text.Trim();

            string description =
                txt_itemdescription.Text.Trim();

            if (productId == 0 && description.Length == 0)
            {
                MessageHelper.ShowError(
                    "Enter a name or description for your custom item.");
                txt_itemdescription.Focus();
                return;
            }

            if (productId != 0 && description.Length == 0)
            {
                description = productName;
            }

            int quantity = Convert.ToInt32(numQuantity.Value);
            decimal weightPerItem = numWeight.Value;
            decimal totalWeight = quantity * weightPerItem;

            // Prevent the same product and description from being
            // accidentally added twice. Users can instead increase quantity.
            foreach (DataRow existingRow in itemTable.Rows)
            {
                if (Convert.ToInt32(existingRow["ProductID"]) == productId &&
                    existingRow["Item"].ToString() == productName &&
                    existingRow["Description"].ToString()
                        .Equals(description,
                            StringComparison.OrdinalIgnoreCase))
                {
                    MessageHelper.ShowError(
                        "This item is already in the list. " +
                        "Remove it first if you want to change its quantity.");
                    return;
                }
            }

            itemTable.Rows.Add(
                productId,
                productName,
                description,
                quantity,
                weightPerItem,
                totalWeight);

            txt_itemdescription.Clear();
            numQuantity.Value = 1;
            numWeight.Value = 1;
        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageHelper.ShowError("Select an item to remove.");
                return;
            }

            int rowIndex = dgvItems.SelectedRows[0].Index;

            if (rowIndex >= 0 && rowIndex < itemTable.Rows.Count)
            {
                itemTable.Rows.RemoveAt(rowIndex);
            }
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            CustomerDashboardForm form = new CustomerDashboardForm();
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

        
    }
}
