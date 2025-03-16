using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PopMeals_WebApp.AdminPages
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script>console.log('AdminLogin: Page_Load called');</script>");

            if (!IsPostBack)
            {
                if (Session["AdminEmail"] != null)
                {
                    Response.Write("<script>console.log('AdminLogin: Redirecting to AdminDashboard.aspx');</script>");
                    Response.Redirect("~/AdminPages/AdminDashboard.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            Response.Write("<script>console.log('AdminLogin: Login button clicked');</script>");

            string connStr = ConfigurationManager.ConnectionStrings["PopMealsDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connStr))
            {
                lblMessage.Text = "Database connection error.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM Admin WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        Session["AdminEmail"] = email;
                        Response.Write("<script>console.log('AdminLogin: Successful login, redirecting to AdminDashboard.aspx');</script>");
                        Response.Redirect("~/AdminPages/AdminDashboard.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid email or password.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred. Please try again.";
                    Response.Write("<script>console.log('AdminLogin: Exception - " + ex.Message + "');</script>");
                }
            }
        }
    }
}
