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
    public partial class ViewCustomerForm : Form
    {


        public ViewCustomerForm(
            string customerId,
            string name,
            string email,
            string phone,
            string address)
        {
            InitializeComponent();

            txt_id.Text = customerId;
            txt_name.Text = name;
            txt_email.Text = email;
            txt_phonenumber.Text = phone;
            txt_address.Text = address;
        }


       

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }
    }
}
