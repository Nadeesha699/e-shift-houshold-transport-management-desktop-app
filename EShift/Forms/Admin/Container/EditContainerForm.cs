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
    public partial class EditContainerForm : Form
    {
        private int containerId;
        public EditContainerForm(int id)
        {
            InitializeComponent();
            containerId = id;
            LoadContainerDetails();
        }
        private void LoadContainerDetails()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT ContainerNumber, CapacityKg, Status
                        FROM containers
                        WHERE ContainerID = @ContainerID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ContainerID", containerId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageHelper.ShowError("Container not found.");

                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                                return;
                            }

                            string status =
                                Convert.ToString(reader["Status"]);

                            if (status == "ASSIGNED")
                            {
                                MessageHelper.ShowError("You cannot edit a container currently assigned to a job.");

                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                                return;
                            }

                            txt_containernumber.Text =
                                Convert.ToString(reader["ContainerNumber"]);

                            txt_loadcapacity.Text =
                                Convert.ToDecimal(reader["CapacityKg"])
                                    .ToString(CultureInfo.CurrentCulture);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load container details: " + ex.Message);

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string containerNumber = txt_containernumber.Text.Trim();
            decimal capacity;

            if (string.IsNullOrWhiteSpace(containerNumber) ||
                string.IsNullOrWhiteSpace(txt_loadcapacity.Text.Trim()))
            {
                MessageHelper.ShowError( "Please enter the container number and capacity.");
                return;
            }

            if (containerNumber.Length > 30)
            {
                MessageHelper.ShowError("Container number cannot exceed 30 characters.");
                return;
            }

            if (!decimal.TryParse(
                txt_loadcapacity.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out capacity) || capacity <= 0)
            {
                MessageHelper.ShowError("Enter a valid capacity greater than zero.");
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        UPDATE containers
                        SET ContainerNumber = @ContainerNumber,
                            CapacityKg = @Capacity
                        WHERE ContainerID = @ContainerID
                          AND Status <> 'ASSIGNED'";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ContainerNumber", containerNumber);

                        cmd.Parameters.AddWithValue(
                            "@Capacity", capacity);

                        cmd.Parameters.AddWithValue(
                            "@ContainerID", containerId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError("Container was not updated. It may be assigned to a job or no longer exist.");
                            return;
                        }
                    }
                }

                MessageHelper.ShowSuccess("Container details updated successfully.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("This container number already exists.");
                }
                else
                {
                    MessageHelper.ShowError("Unable to update container: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update container: " + ex.Message);
            }
        }

       

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
