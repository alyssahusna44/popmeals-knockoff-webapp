using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PopMeals_WebApp
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("~/CustomerPages/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
            }

            // Load data only on the first page load
            if (!IsPostBack)
            {
                try
                {
                    BindOrders(); // Load orders from the database
                }
                catch (Exception ex)
                {
                    // Log the exception (example: writing to a log file)
                    System.IO.File.AppendAllText(Server.MapPath("~/Logs/ErrorLog.txt"),
                        DateTime.Now + " - " + ex.Message + Environment.NewLine);

                    // Display a user-friendly error message
                    Response.Write("<script>alert('An error occurred while loading orders. Please try again later.');</script>");
                }
            }

        }

        private void BindOrders()
        {
            string connString = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GetOrdersByCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", Session["CustomerID"]);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind data to GridView
                gvOrders.DataSource = dt;
                gvOrders.DataBind();
            }
        }

        protected void gvOrders_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            // Handle the "ViewDetails" button click
            if (e.CommandName == "ViewDetails")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"OrderDetails.aspx?OrderID={orderId}");
            }
        }
    }
}
