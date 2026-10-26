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
    public partial class AddAssistantForm : Form
    {
        public AddAssistantForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string fullName = txt_name.Text.Trim();
            string phone = txt_phonenumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phone))
            {
                MessageHelper.ShowError("Please enter the assistant's full name and phone number.");
                return;
            }

            if (fullName.Length > 100 || phone.Length > 20)
            {
                MessageHelper.ShowError("The name or phone number is too long.");
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        INSERT INTO assistants
                            (FullName, Phone)
                        VALUES
                            (@FullName, @Phone)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FullName", fullName);

                        cmd.Parameters.AddWithValue(
                            "@Phone", phone);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowError("Assistant added successfully.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to add assistant: " + ex.Message);
            }
        }

       

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_phonenumber.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
