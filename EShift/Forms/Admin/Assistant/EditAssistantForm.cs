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
    public partial class EditAssistantForm : Form
    {
        private int assistantId;
        public EditAssistantForm(int id)
        {
            InitializeComponent();
            assistantId = id;
            LoadAssistantDetails();
        }

        private void LoadAssistantDetails()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT FullName, Phone, Status
                        FROM Assistants
                        WHERE AssistantID = @AssistantID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@AssistantID", assistantId);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status =
                                    Convert.ToString(reader["Status"]);

                                if (status == "ASSIGNED" ||
                                    status == "ON DUTY")
                                {
                                    MessageHelper.ShowError("You cannot edit an assistant who is assigned to a job or on duty.");

                                    this.DialogResult =
                                        DialogResult.Cancel;
                                    this.Close();
                                    return;
                                }

                                txt_name.Text =
                                    Convert.ToString(reader["FullName"]);

                                txt_phonenumber.Text =
                                    Convert.ToString(reader["Phone"]);
                            }
                            else
                            {
                                MessageHelper.ShowError("Assistant not found.");

                                this.DialogResult =
                                    DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load assistant details: " + ex.Message);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
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
                        UPDATE Assistants
                        SET FullName = @FullName,
                            Phone = @Phone
                        WHERE AssistantID = @AssistantID
                          AND Status NOT IN ('ASSIGNED', 'ON DUTY')";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FullName", fullName);

                        cmd.Parameters.AddWithValue(
                            "@Phone", phone);

                        cmd.Parameters.AddWithValue(
                            "@AssistantID", assistantId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageHelper.ShowError("Assistant details were not updated. The assistant may be assigned to a job.");
                            return;
                        }
                    }
                }

                MessageHelper.ShowSuccess("Assistant details updated successfully.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to update assistant: " + ex.Message);
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
