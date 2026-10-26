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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            chkIsActive.Checked = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string productName = txt_productname.Text.Trim();
            string description = txt_description.Text.Trim();

            if (string.IsNullOrWhiteSpace(productName))
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
                        INSERT INTO Products
                            (ProductName, Description,
                             IsActive)
                        VALUES
                            (@ProductName, @Description,
                             @IsActive)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add(
                            "@ProductName", MySqlDbType.VarChar)
                            .Value = productName;

                        cmd.Parameters.Add(
                            "@Description", MySqlDbType.VarChar)
                            .Value = string.IsNullOrWhiteSpace(description)
                                ? (object)DBNull.Value
                                : description;


                        cmd.Parameters.Add(
                            "@IsActive", MySqlDbType.Bit)
                            .Value = chkIsActive.Checked;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageHelper.ShowSuccess("Product added successfully.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Unable to add product: " + ex.Message);
            }
        }

       

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_productname.Clear();
            txt_description.Clear();
            IsAccessible = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
