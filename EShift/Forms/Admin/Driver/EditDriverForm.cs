using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using EShift.Helpers;
using FontAwesome.Sharp;
using System.Globalization;

namespace EShift.Forms.Admin
{
    public partial class EditDriverForm : Form
    {
        private int driverId;
        public EditDriverForm(int id)
        {
            InitializeComponent();
            driverId = id;
            LoadDriverDetails();
        }

        private void LoadDriverDetails()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT FullName, Phone,
                               LicenceNumber, Status
                        FROM Drivers
                        WHERE DriverID = @DriverID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DriverID", driverId);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Driver not found.");
                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            string status = reader["Status"].ToString();

                            if (status == "ASSIGNED" ||
                                status == "ON DUTY")
                            {
                                MessageHelper.ShowError("This driver is assigned to a job " + "or currently on duty. Editing is restricted.");

                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            txt_name.Text =
                                reader["FullName"].ToString();

                            txt_phonenumber.Text =
                                reader["Phone"].ToString();

                            txt_licencenumber.Text =
                                reader["LicenceNumber"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load driver: " + ex.Message);

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string fullName = txt_name.Text.Trim();
            string phone = txt_phonenumber.Text.Trim();
            string licence = txt_licencenumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(licence))
            {
                MessageHelper.ShowError("Please fill in all fields.");
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        UPDATE Drivers
                        SET FullName = @FullName,
                            Phone = @PhoneNumber,
                            LicenceNumber = @LicenceNumber
                        WHERE DriverID = @DriverID
                          AND Status NOT IN ('ASSIGNED', 'ON DUTY')";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FullName", fullName);

                        cmd.Parameters.AddWithValue(
                            "@PhoneNumber", phone);

                        cmd.Parameters.AddWithValue(
                            "@LicenceNumber", licence);

                        cmd.Parameters.AddWithValue(
                            "@DriverID", driverId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            
                            using (MySqlCommand check =
                                new MySqlCommand(
                                    "SELECT Status FROM Drivers " +
                                    "WHERE DriverID = @DriverID",
                                    connection))
                            {
                                check.Parameters.AddWithValue(
                                    "@DriverID", driverId);

                                object result = check.ExecuteScalar();

                                if (result == null ||
                                    result.ToString() == "ASSIGNED" ||
                                    result.ToString() == "ON DUTY")
                                {
                                    MessageBox.Show(
                                        "Driver not found or currently assigned.");
                                    return;
                                }
                            }
                        }
                    }
                }

                MessageHelper.ShowSuccess("Driver details updated successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("This licence number is already registered.");
                }
                else
                {
                    MessageHelper.ShowError( "Unable to update driver: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error: " + ex.Message);
            }
        }

       

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_licencenumber.Clear();
            txt_phonenumber.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
