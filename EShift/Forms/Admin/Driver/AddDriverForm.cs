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
    public partial class AddDriverForm : Form
    {
        public AddDriverForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
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
                        INSERT INTO Drivers
                            (FullName, Phone, LicenceNumber)
                        VALUES
                            (@FullName, @PhoneNumber, @LicenceNumber)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FullName", fullName);

                        cmd.Parameters.AddWithValue(
                            "@PhoneNumber", phone);

                        cmd.Parameters.AddWithValue(
                            "@LicenceNumber", licence);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Driver added successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("This driving licence number is already registered.");
                }
                else
                {
                    MessageHelper.ShowError("Unable to add driver: " + ex.Message);
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
