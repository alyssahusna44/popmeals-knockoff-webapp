using System;
using System.Web.UI;

namespace PopMeals_WebApp
{
    public partial class CustomerMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateLoginStatus();
            }
        }

        private void UpdateLoginStatus()
        {
            if (Session["CustomerName"] != null)
            {
                lnkLogin.Text = "Hi, " + Session["CustomerName"].ToString();
                lnkLogin.Click += Logout_Click; // Attach logout functionality
            }
            else
            {
                lnkLogin.Text = "Sign In";
                lnkLogin.Click += Login_Click; // Attach login functionality
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerPages/Login.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Clear session and redirect to Menu page
            Session.Clear();
            Response.Redirect("~/CustomerPages/Menu.aspx");
        }
    }
}
