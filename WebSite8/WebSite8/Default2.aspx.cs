using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   

    }

    static string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    // Verify a hash against a string.
    static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(md5Hash, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        
        String login = TextBox1.Text;
        String password = TextBox2.Text;

        SqlDataReader rdr = null;
        // create a connection object
        SqlConnection con = null;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["pawel2ConnectionString"].ConnectionString);
        // create a command object
        //SqlCommand cmd = new SqlCommand("select * from etaty", con);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "Zaloguj";

        SqlParameter param = new SqlParameter("@login", TextBox1.Text);
        cmd.Parameters.Add(param);
        param = new SqlParameter("@haslo", TextBox2.Text);
        cmd.Parameters.Add(param);
       



        String Login, Haslo;
        try
        {
            // open the connection
            con.Open();
            // 1. get an instance of the SqlDataReader
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // get the results of each column
                Login = rdr["login"].ToString();
                Haslo = rdr["haslo"].ToString();

                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, Haslo);


                    Console.WriteLine("The MD5 hash of " + Haslo + " is: " + hash + ".");

                    Console.WriteLine("Verifying the hash...");

                    if (VerifyMd5Hash(md5Hash, Haslo, hash))
                    {
          
                        Session["Logged"] = "true";
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Console.WriteLine("The hashes are not same.");
                        Session["Logged"] = "false";

                    }
                }


              

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

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    
    }
}