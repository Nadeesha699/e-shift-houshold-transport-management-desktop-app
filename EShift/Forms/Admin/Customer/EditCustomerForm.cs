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
    public partial class EditCustomerForm : Form
    {
        private int customerUserId;

        public EditCustomerForm(int id)
        {
            InitializeComponent();

            customerUserId = id;

            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT u.FullName, u.Email,
                           c.Phone, c.Address
                    FROM Users u
                    INNER JOIN Customers c
                        ON u.UserID = c.UserID
                    WHERE u.UserID = @UserID
                      AND u.Role = 'CUSTOMER'";

                using (MySqlCommand cmd =
                    new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue(
                        "@UserID", customerUserId);

                    connection.Open();

                    using (MySqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_name.Text =
                                reader["FullName"].ToString();

                            txt_email.Text =
                                reader["Email"].ToString();

                            txt_phone.Text =
                               reader["Phone"].ToString();

                           txt_address.Text =
                               reader["Address"].ToString();
                        }
                        else
                        {
                            MessageHelper.ShowError("Customer not found.");

                            this.Close();
                        }
                    }
                }
            }
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_phone.Text) ||
                string.IsNullOrWhiteSpace(txt_address.Text))
            {
                MessageHelper.ShowError("Please fill in all fields Validation");

                return;
            }

            using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction =
                    connection.BeginTransaction())
                {
                    try
                    {
                        string userQuery = @"
                            UPDATE Users
                            SET FullName = @FullName,
                                Email = @Email
                            WHERE UserID = @UserID
                              AND Role = 'CUSTOMER'";

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                userQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@FullName",
                                txt_name.Text.Trim());

                            cmd.Parameters.AddWithValue(
                                "@Email",
                                txt_email.Text.Trim());

                            cmd.Parameters.AddWithValue(
                                "@UserID", customerUserId);

                            cmd.ExecuteNonQuery();
                        }

                        string customerQuery = @"
                            UPDATE Customers
                            SET Phone = @Phone,
                                Address = @Address
                            WHERE UserID = @UserID";

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                customerQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@Phone",
                                txt_phone.Text.Trim());

                            cmd.Parameters.AddWithValue(
                                "@Address",
                                txt_address.Text.Trim());


                            cmd.Parameters.AddWithValue(
                                "@UserID", customerUserId);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageHelper.ShowSuccess("Customer details updated successfully!");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();

                        if (ex.Number == 1062)
                        {
                            MessageHelper.ShowError("This email address is already in use Duplicate Email");
                        }
                        else
                        {
                            MessageHelper.ShowError("Database error: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageHelper.ShowError("Error: " + ex.Message); ;
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

       
    }
}
