using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        String connectionString;
        SqlConnection cnn;

        connectionString = "Data Source=LAPTOP-0H095MNE\\SQLEXPRESS;Initial Catalog=Database1;Integrated Security=True";
        cnn = new SqlConnection(connectionString);
        cnn.Open();


        SqlCommand cmd = new SqlCommand("SELECT password FROM dbo.Table1 WHERE username='ajmal'", cnn);
        //SqlCommand cmd = new SqlCommand("SELECT password FROM dbo.Table1 WHERE username=@username", cnn);
        //cmd.Parameters.AddWithValue("@username", TextBox1.Text);


        SqlDataReader da = cmd.ExecuteReader();
        String pass = "none";
        while (da.Read())
        {
            pass = da.GetValue(0).ToString();
            Label1.Text = pass;
        }

        cnn.Close();

        if (TextBox1.Text == pass)
        {
            Response.Redirect("Default2.aspx");
        }
        else
        {
            //Label1.Text = "Incorrect password!";
        }
    }


  }