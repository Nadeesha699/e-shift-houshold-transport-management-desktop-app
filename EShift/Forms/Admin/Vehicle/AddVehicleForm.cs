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
    public partial class AddVehicleForm : Form
    {
        public AddVehicleForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string registration = txt_registrationnumber.Text.Trim();
            decimal capacity;

            if (string.IsNullOrWhiteSpace(registration))
            {
                MessageHelper.ShowError("Enter the vehicle registration number.");
                txt_registrationnumber.Focus();
                return;
            }

            if (!decimal.TryParse(
                txt_loadcapacity.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out capacity) || capacity <= 0)
            {
                MessageHelper.ShowError("Enter a valid load capacity greater than zero.");
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
                        INSERT INTO Lorries
                            (RegistrationNumber, CapacityKg)
                        VALUES
                            (@RegistrationNumber, @LoadCapacity)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@RegistrationNumber", registration);

                        cmd.Parameters.AddWithValue(
                            "@LoadCapacity", capacity);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Vehicle added successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("This registration number already exists.");
                }
                else
                {
                    MessageHelper.ShowError( "Unable to add vehicle: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error: " + ex.Message);
            }
        }

       

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_registrationnumber.Clear();
            txt_loadcapacity.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
