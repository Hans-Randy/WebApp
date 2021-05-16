using System;
using System.Collections.Generic;
using System.Linq;
using System.Web
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ControlHelper
    {
        public static void ShowError(this Label label, string message)
        {
            Show(label, message, Color.IndianRed);
        }

        public static void ShowInformation(this Label label, string message)
        {
            Show(label, message, Color.ForestGreen);
        }

        public static void Show(this Label label, string message, Color foreColor)
        {
            label.Text = message;
            label.Visible = true;
            label.ForeColor = foreColor;
        }
    }
}
