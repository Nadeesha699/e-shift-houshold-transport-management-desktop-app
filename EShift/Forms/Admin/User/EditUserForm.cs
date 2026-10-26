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
    public partial class EditUserForm : Form
    {
        private int userId;

        public EditUserForm(int id)
        {
            InitializeComponent();

            userId = id;

            LoadUser();
        }

        private void LoadUser()
        {
            using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string sql = @"
                    SELECT FullName, Email, IsActive
                    FROM Users
                    WHERE UserID = @id";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", userId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_name.Text =
                                reader["FullName"].ToString();

                            txt_email.Text =
                                reader["Email"].ToString();

                            chkIsActive.Checked =
                                Convert.ToBoolean(reader["IsActive"]);
                        }
                        else
                        {
                            MessageHelper.ShowError("User not found.");
                            DialogResult = DialogResult.Cancel;
                            Close();
                        }
                    }
                }
            }
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text))
            {
                MessageHelper.ShowError("Please complete all required fields.");
                return;
            }

            try
            {
                using (MySqlConnection connection =
                   DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        UPDATE Users
                        SET FullName = @name,
                            Email = @email,
                            IsActive = @active
                        WHERE UserID = @id";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@name", txt_name.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@email", txt_email.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@active", chkIsActive.Checked);

                        cmd.Parameters.AddWithValue("@id", userId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("User updated successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageHelper.ShowError("This email address is already in use.");
                }
                else
                {
                    MessageHelper.ShowError("Database error: " + ex.Message);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
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
