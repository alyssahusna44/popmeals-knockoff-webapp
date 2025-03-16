using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PopMeals_WebApp.AdminPages
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the admin is logged in
            if (Session["AdminEmail"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                lblWelcome.Text = "Welcome, " + Session["AdminEmail"].ToString();
                if (!IsPostBack)
                {
                    LoadNotifications(); // Load notifications when the page is first loaded
                }
            }
        }

        // Redirect to AdminSales
        protected void btnSales_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSales.aspx");
        }

        // Redirect to AdminOrders
        protected void btnOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOrders.aspx");
        }

        // Logout and clear session
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("AdminLogin.aspx");
        }

        // Load new order notifications
        private void LoadNotifications()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Query to fetch new orders (status 'Pending')
                string query = "SELECT TOP 5 OrderID, CustomerName, OrderStatus FROM Orders WHERE OrderStatus = 'Pending' ORDER BY OrderDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    rptNotifications.DataSource = dt;
                    rptNotifications.DataBind();
                }
                else
                {
                    // If no notifications, display a default message
                    rptNotifications.DataSource = null;
                    rptNotifications.DataBind();
                    lblNoNotifications.Text = "No new orders.";
                }
            }
        }
    }
}
