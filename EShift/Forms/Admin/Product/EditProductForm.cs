using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EShift.Helpers;

namespace EShift.Forms.Admin
{
    public partial class EditProductForm : Form
    {
        private  int productId;

        public EditProductForm(int id)
        {
            InitializeComponent();

            productId = id;

            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        SELECT ProductName, Description,
                               IsActive
                        FROM Products
                        WHERE ProductID = @ProductID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ProductID", productId);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_productname.Text =
                                    reader["ProductName"].ToString();

                                txt_description.Text =
                                    reader["Description"] == DBNull.Value
                                    ? ""
                                    : reader["Description"].ToString();


                                chkIsActive.Checked =
                                    Convert.ToBoolean(reader["IsActive"]);
                            }
                            else
                            {
                                MessageHelper.ShowError("Product not found.");

                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to load product: " + ex.Message);

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
        

            if (string.IsNullOrWhiteSpace(txt_productname.Text))
            {
                MessageHelper.ShowError("Please enter a product name.");

                txt_productname.Focus();
                return;
            }


            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        UPDATE Products
                        SET ProductName = @ProductName,
                            Description = @Description,
                            IsActive = @IsActive
                        WHERE ProductID = @ProductID";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add(
                            "@ProductName", MySqlDbType.VarChar)
                            .Value = txt_productname.Text;

                        cmd.Parameters.Add(
                            "@Description", MySqlDbType.VarChar)
                            .Value = string.IsNullOrWhiteSpace(txt_description.Text)
                                ? (object)DBNull.Value
                                : txt_description.Text;

                        cmd.Parameters.Add(
                            "@IsActive", MySqlDbType.Bit)
                            .Value = chkIsActive.Checked;

                        cmd.Parameters.Add(
                            "@ProductID", MySqlDbType.Int32)
                            .Value = productId;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Product updated successfully.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError( "Unable to update product: " + ex.Message);
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
