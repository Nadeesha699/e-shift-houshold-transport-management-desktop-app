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
    public partial class DeclineJobForm : Form
    {
        public string DeclineReason { get; private set; } = "";
        public DeclineJobForm()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string reason = txtReason.Text.Trim();

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageHelper.ShowError("Please enter a decline reason.");
                txtReason.Focus();
                return;
            }

            if (reason.Length > 500)
            {
                MessageHelper.ShowError("The reason cannot exceed 500 characters.");
                return;
            }

            DeclineReason = reason;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_closes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
