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
    public partial class EditVehicleForm : Form
    {
        private int lorryId;

        public EditVehicleForm(int id)
        {
            InitializeComponent();
            lorryId = id;
            LoadVehicleDetails();
        }

        private void LoadVehicleDetails()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT RegistrationNumber, CapacityKg, Status
                        FROM Lorries
                        WHERE LorryID = @LorryID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@LorryID", lorryId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageHelper.ShowError("Vehicle not found.");
                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            string status = reader["Status"].ToString();

                            if (status == "Assigned")
                            {
                                MessageHelper.ShowError("This vehicle is assigned to a job. " +
                                    "Complete or release the assignment before editing.");

                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            txt_registrationnumber.Text =
                                reader["RegistrationNumber"].ToString();

                            txt_loadcapacity.Text =
                                Convert.ToDecimal(
                                    reader["CapacityKg"]).ToString(
                                        CultureInfo.CurrentCulture);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load vehicle: " + ex.Message);

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string registration =
                txt_registrationnumber.Text.Trim();

            decimal capacity;

            if (string.IsNullOrWhiteSpace(registration))
            {
                MessageHelper.ShowError(
                    "Enter the vehicle registration number.");

                txt_registrationnumber.Focus();
                return;
            }

            if (!decimal.TryParse(
                txt_loadcapacity.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out capacity) || capacity <= 0)
            {
                MessageHelper.ShowError(
                    "Enter a valid load capacity greater than zero.");

                txt_loadcapacity.Focus();
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        UPDATE Lorries
                        SET RegistrationNumber = @RegistrationNumber,
                            CapacityKg = @LoadCapacity
                        WHERE LorryID = @LorryID
                          AND Status <> 'ASSIGNED'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@RegistrationNumber", registration);

                        cmd.Parameters.AddWithValue(
                            "@LoadCapacity", capacity);

                        cmd.Parameters.AddWithValue(
                            "@LorryID", lorryId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            // Recheck whether the vehicle still exists
                            // and whether it is currently assigned.
                            using (MySqlCommand check =
                                new MySqlCommand(
                                    "SELECT Status FROM Lorries " +
                                    "WHERE LorryID = @LorryID",
                                    connection))
                            {
                                check.Parameters.AddWithValue(
                                    "@LorryID", lorryId);

                                object result = check.ExecuteScalar();

                                if (result == null)
                                {
                                    MessageHelper.ShowError(
                                        "Vehicle no longer exists.");
                                }
                                else if (result.ToString() == "ASSIGNED")
                                {
                                    MessageHelper.ShowError (
                                        "This vehicle is now assigned. " +
                                        "Editing is not allowed.");
                                    return;
                                }
                            }
                        }

                        // A zero row count can also mean the values
                        // were unchanged, so successful execution is
                        // sufficient when the vehicle is not assigned.
                    }
                }

                MessageHelper.ShowSuccess("Vehicle details saved successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("That registration number is already in use.");
                }
                else
                {
                    MessageHelper.ShowError("Unable to update vehicle: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError( "Error: " + ex.Message);
            }
        }

       

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
