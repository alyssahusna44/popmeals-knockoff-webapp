using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Linq;

namespace PopMeals_WebApp
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuItems("All"); // Load all menu items initially
            }
        }

        private void BindMenuItems(string category)
        {
            string connString = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd;

                if (category != "All")
                {
                    cmd = new SqlCommand("SELECT * FROM MenuItems WHERE Category = @Category", conn);
                    cmd.Parameters.AddWithValue("@Category", category);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM MenuItems", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMenu.DataSource = dt;  // Bind to GridView instead of Repeater
                gvMenu.DataBind();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = ddlCategory.SelectedValue;
            BindMenuItems(selectedCategory);
        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int menuItemID = Convert.ToInt32(e.CommandArgument);
                AddToCart(menuItemID);
            }
        }

        private void AddToCart(int menuItemID)
        {
            DataTable cart = (DataTable)Session["Cart"] ?? new DataTable();

            if (cart.Columns.Count == 0)
            {
                cart.Columns.Add("MenuItemID", typeof(int));
                cart.Columns.Add("Name", typeof(string));
                cart.Columns.Add("Price", typeof(decimal));
                cart.Columns.Add("Quantity", typeof(int));
            }

            DataRow existingRow = cart.Select($"MenuItemID = {menuItemID}").FirstOrDefault();
            if (existingRow != null)
            {
                existingRow["Quantity"] = Convert.ToInt32(existingRow["Quantity"]) + 1;
            }
            else
            {
                string connString = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT MenuItemID, Name, Price FROM MenuItems WHERE MenuItemID = @MenuItemID", conn);
                    cmd.Parameters.AddWithValue("@MenuItemID", menuItemID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DataRow newRow = cart.NewRow();
                        newRow["MenuItemID"] = menuItemID;
                        newRow["Name"] = reader["Name"].ToString();
                        newRow["Price"] = Convert.ToDecimal(reader["Price"]);
                        newRow["Quantity"] = 1;
                        cart.Rows.Add(newRow);
                    }
                }
            }

            Session["Cart"] = cart;
        }
    }
}

