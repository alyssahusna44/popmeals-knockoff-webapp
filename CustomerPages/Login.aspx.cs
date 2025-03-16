using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace PopMeals_WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/AdminLogin.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string emailPhone = txtEmailPhone.Text.Trim();
            string verificationCode = txtVerificationCode.Text.Trim();

            // Hardcoded verification code for now
            if (verificationCode != "123456")
            {
                Response.Write("<script>alert('Invalid verification code. Please try again.');</script>");
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["PopMealsDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Check if the user exists in the database
                SqlCommand checkCmd = new SqlCommand("SELECT CustomerID, Name FROM Customers WHERE Email = @EmailPhone OR PhoneNumber = @EmailPhone", conn);
                checkCmd.Parameters.AddWithValue("@EmailPhone", emailPhone);

                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read()) // User exists
                {
                    Session["CustomerID"] = reader["CustomerID"];
                    Session["CustomerName"] = reader["Name"];
                    reader.Close();
                }
                else // User does not exist, insert new user
                {
                    reader.Close();
                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO Customers (Email, PhoneNumber) OUTPUT INSERTED.CustomerID VALUES (@Email, @PhoneNumber)", conn);

                    insertCmd.Parameters.AddWithValue("@Email", emailPhone.Contains("@") ? emailPhone : (object)DBNull.Value);
                    insertCmd.Parameters.AddWithValue("@PhoneNumber", emailPhone.All(char.IsDigit) ? emailPhone : (object)DBNull.Value);

                    int newCustomerID = (int)insertCmd.ExecuteScalar();

                    Session["CustomerID"] = newCustomerID;
                    Session["CustomerName"] = emailPhone;
                }

                // Redirect to the requested page or homepage
                string returnUrl = Request.QueryString["ReturnUrl"];
                Response.Redirect(string.IsNullOrEmpty(returnUrl) ? "~/CustomerPages/Menu.aspx" : returnUrl);
            }
        }
    }
}
