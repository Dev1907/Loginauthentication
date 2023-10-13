using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace LoginAuthentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-5V2FSSI\\SQLEXPRESS;Database=CRM;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("Select * from Users where username=@username and password=@password", con);
            cmd.Parameters.AddWithValue("@username", TxtUsername.Text);
            cmd.Parameters.AddWithValue ("@password", TxtPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");

            if (ds.Tables["Users"].Rows.Count > 0 )
            {
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Write("Invalid User!!!");
            }


        }
    }
}