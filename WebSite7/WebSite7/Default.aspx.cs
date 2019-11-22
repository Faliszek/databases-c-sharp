using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["pawel2ConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        // This will specify that we are passing the stored procedures name
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO ETATY (Nazwa, Placa_od, Placa_do)" +
            "VALUES ('" + TextBox1.Text + "',"
          + TextBox2.Text + ","
          + TextBox3.Text + ")";

        /*    SqlParameter param = new SqlParameter("@Nazwa", "nazwa etatu");
           cmd.Parameters.Add(param);
           param = new SqlParameter("@PlacaOd", "100");
           cmd.Parameters.Add(param);
           param = new SqlParameter("@PlacaDo", "1200");
           cmd.Parameters.Add(param);

            */
        cmd.ExecuteNonQuery();
        con.Close();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["pawel2ConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        // This will specify that we are passing the stored procedures name

        SqlParameter param = new SqlParameter("@Nazwa", TextBox1.Text);
        cmd.Parameters.Add(param);
        param = new SqlParameter("@Placa_od", TextBox2.Text);
        cmd.Parameters.Add(param);
        param = new SqlParameter("@Placa_do", TextBox3.Text);
        cmd.Parameters.Add(param);


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO ETATY (Nazwa, Placa_od, Placa_do)" +
            "VALUES (@Nazwa, @Placa_od, @Placa_do)";

        cmd.ExecuteNonQuery();
        con.Close();

    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            SqlConnection con = null;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["pawel2ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            // This will specify that we are passing the stored procedures name
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Dodaj"; // This will be the stored procedures name
            SqlParameter param = new SqlParameter("@Nazwa", TextBox1.Text);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@placaOd", TextBox2.Text);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@placaDo", TextBox3.Text);
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}