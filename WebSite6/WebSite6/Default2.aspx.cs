using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Pracownik"] != null)
            {
                if (Session["Pracownik"] is Pracownik)
                {
                    Pracownik p = (Pracownik)Session["Pracownik"];
                    ArrayList listaPracownikow = null;
                    if (Session["ListaPracownikow"] == null)
                        listaPracownikow = new ArrayList();
                    else
                        listaPracownikow = (ArrayList)Session["ListaPracownikow"];

                    listaPracownikow.Add(p);

                    for(int a =0; a <listaPracownikow.Count; a++)
                    {
                        p = (Pracownik)listaPracownikow[a];
                        TextBox1.Text += p.Imie + " " + p.Nazwisko + "\r\n";
                    }

                    Session["ListaPracownikow"] = listaPracownikow;
                    //TextBox1.Text += p.Imie + "\r\n" + p.Nazwisko;
                }
            }
            else
            {
                Response.Redirect("Default.aspx", true);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", true);
    }
}