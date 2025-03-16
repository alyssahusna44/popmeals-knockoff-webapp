using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web.UI;

namespace PopMeals_WebApp
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("~/CustomerPages/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }

            if (!IsPostBack)
            {
                LoadCustomerDetails(); // Prefill checkout details
            }
        }

        private void LoadCustomerDetails()
        {
            string connString = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", Session["CustomerID"]);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    ddlPaymentMethod.SelectedValue = reader["PaymentMethod"].ToString();
                }
            }
        }



        private void BindCart()
        {
            // Retrieve the cart from the session
            DataTable cart = (DataTable)Session["Cart"];

            if (cart != null && cart.Rows.Count > 0)
            {
                cart.Columns.Add("Total", typeof(decimal), "Price * Quantity");
                gvCart.DataSource = cart;
                gvCart.DataBind();

                lblGrandTotal.Text = cart.AsEnumerable()
                                         .Sum(row => row.Field<decimal>("Total"))
                                         .ToString("N2");
            }
            else
            {
                gvCart.DataSource = null;
                gvCart.DataBind();
                lblGrandTotal.Text = "0.00";
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string paymentMethod = ddlPaymentMethod.SelectedValue;

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(address))
            {
                Response.Write("<script>alert('Please fill in all the required fields.');</script>");
                return;
            }

            DataTable cart = (DataTable)Session["Cart"];
            if (cart == null || cart.Rows.Count == 0)
            {
                Response.Write("<script>alert('Your cart is empty.');</script>");
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
            int orderId = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("InsertOrder", conn, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", Session["CustomerID"]);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OrderTime", DateTime.Now.TimeOfDay);
                    cmd.Parameters.AddWithValue("@OrderStatus", "Pending");
                    cmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(lblGrandTotal.Text));
                    orderId = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (DataRow row in cart.Rows)
                    {
                        SqlCommand itemCmd = new SqlCommand("InsertOrderItem", conn, transaction);
                        itemCmd.CommandType = CommandType.StoredProcedure;
                        itemCmd.Parameters.AddWithValue("@OrderID", orderId);
                        itemCmd.Parameters.AddWithValue("@MenuItemID", row["MenuItemID"]);
                        itemCmd.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        itemCmd.Parameters.AddWithValue("@Price", row["Price"]);
                        itemCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    // Show Thank You Modal
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "document.getElementById('thankYouModal').style.display = 'flex';", true);
                }
                catch
                {
                    transaction.Rollback();
                    Response.Write("<script>alert('Something went wrong. Please try again.');</script>");
                }
            }
        }

        protected void btnGoToOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyOrders.aspx");
        }
    }
}
