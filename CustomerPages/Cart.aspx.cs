using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace PopMeals_WebApp
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("~/CustomerPages/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }

            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()
        {
            // Retrieve the cart from the session
            DataTable cart = (DataTable)Session["Cart"];

            if (cart != null && cart.Rows.Count > 0)
            {
                // Check if the "Total" column exists before adding it
                if (!cart.Columns.Contains("Total"))
                {
                    cart.Columns.Add("Total", typeof(decimal), "Price * Quantity");
                }

                gvCart.DataSource = cart;
                gvCart.DataBind();

                // Calculate Grand Total
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


        protected void gvCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                // Get the MenuItemID to remove
                int menuItemID = Convert.ToInt32(e.CommandArgument);

                // Retrieve the cart from the session
                DataTable cart = (DataTable)Session["Cart"];
                if (cart != null)
                {
                    // Find the row to remove
                    DataRow row = cart.AsEnumerable()
                                      .FirstOrDefault(r => r.Field<int>("MenuItemID") == menuItemID);

                    if (row != null)
                    {
                        cart.Rows.Remove(row);
                        Session["Cart"] = cart;
                        BindCart(); // Rebind the updated cart
                    }
                }
            }
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            DataTable cart = (DataTable)Session["Cart"];

            if (cart != null)
            {
                foreach (GridViewRow row in gvCart.Rows)
                {
                    // Get the MenuItemID for the current row
                    int menuItemID = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value);

                    // Find the corresponding row in the cart
                    DataRow cartRow = cart.AsEnumerable()
                                          .FirstOrDefault(r => r.Field<int>("MenuItemID") == menuItemID);

                    if (cartRow != null)
                    {
                        // Update the quantity
                        TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                        int newQuantity = int.Parse(txtQuantity.Text);
                        cartRow["Quantity"] = newQuantity;
                    }
                }

                Session["Cart"] = cart;
                BindCart(); // Rebind to reflect updated quantities and totals
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Redirect to the Checkout Page
            Response.Redirect("Checkout.aspx");
        }
    }
}
