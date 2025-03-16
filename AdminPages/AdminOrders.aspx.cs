using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PopMeals_WebApp.AdminPages
{
    public partial class AdminOrders : System.Web.UI.Page
    {
        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOrders.Rows[rowIndex];

                // Get DropDownList and new status
                DropDownList ddlOrderStatus = (DropDownList)row.FindControl("ddlOrderStatus");
                string newStatus = ddlOrderStatus.SelectedValue;

                // Get OrderID
                int orderId = Convert.ToInt32(gvOrders.DataKeys[rowIndex].Value);

                // Update Order Status in Database
                string connStr = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("UpdateOrderStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@OrderStatus", newStatus);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Reload Orders
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("GetOrdersByCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvOrders.DataSource = dt;
                gvOrders.DataBind();
            }
        }

    }


}