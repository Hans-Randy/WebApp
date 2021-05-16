using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception exc)
            {
                label.Text = message;
                label.Visible = true;
                label.ForeColor = foreColor;
            }

            var username = usernameTextBox.Text;
            var password = passwordTextBox.Text;

            using (var db = )
            {
                var user = db.Users.FirstOrDefault(x => x.Username == username);
            }
        }
    }
}