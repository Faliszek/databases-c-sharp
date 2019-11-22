using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // declare the SqlDataReader, which is used in
        // both the try block and the finally block
        SqlDataReader rdr = null;
        // create a connection object
        SqlConnection con = null;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["pawel2ConnectionString"].ConnectionString);
        // create a command object
        //SqlCommand cmd = new SqlCommand("select * from etaty", con);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "select * from etaty";


        String Id, Nazwa, Placa_Od, Placa_Do;
        try
        {
            // open the connection
            con.Open();
            // 1. get an instance of the SqlDataReader
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // get the results of each column
                Id = rdr["Id"].ToString();
                Nazwa = rdr["Nazwa"].ToString();
                Placa_Od = rdr["Placa_Od"].ToString();
                Placa_Do = rdr["Placa_Do"].ToString();
                TextBox1.Text += Id + " " + Nazwa + " " + Placa_Od + " " + Placa_Do + "\r\n";
            }
            rdr.Close();
            object o = cmd.ExecuteScalar();
            int a = 0;
            a++;
        }
        finally
        {
            // 3. close the reader
            if (rdr != null) { rdr.Close(); }
            // close the connection
            if (con != null) { con.Close(); }
        }

    }
}