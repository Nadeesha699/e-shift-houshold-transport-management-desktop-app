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
    public partial class AddContainerForm : Form
    {
        public AddContainerForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string containerNumber = txt_containernumber.Text.Trim();
            decimal capacity;

            if (string.IsNullOrWhiteSpace(containerNumber) ||
                string.IsNullOrWhiteSpace(txt_loadcapacity.Text.Trim()))
            {
                MessageHelper.ShowError("Please enter the container number and capacity.");
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
                        INSERT INTO Containers
                            (ContainerNumber, CapacityKg, Status)
                        VALUES
                            (@ContainerNumber, @Capacity, 'AVAILABLE')";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ContainerNumber", containerNumber);

                        cmd.Parameters.AddWithValue(
                            "@Capacity", capacity);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Container added successfully.");

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
                    MessageHelper.ShowError("Unable to add container: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to add container: " + ex.Message);
            }
        }

       

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_containernumber.Clear();
            txt_loadcapacity.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
