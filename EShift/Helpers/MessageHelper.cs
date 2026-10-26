using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShift.Helpers
{
    internal class MessageHelper
    {
        public static void ShowError(string message)
        {
            var dialog = new Guna2MessageDialog();
            dialog.Text = message;
            dialog.Buttons = MessageDialogButtons.OK;
            dialog.Icon = MessageDialogIcon.Error;
            dialog.Style = MessageDialogStyle.Light;

            dialog.Show();
        }

        public static void ShowSuccess(string message)
        {
            var dialog = new Guna2MessageDialog();
            dialog.Text = message;
            dialog.Buttons = MessageDialogButtons.OK;
            dialog.Icon = MessageDialogIcon.Information;
            dialog.Style = MessageDialogStyle.Light;

            dialog.Show();
        }
    }
}
