using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String logged = (String)Session["Logged"];
            if (Session["Logged"] == null ||  logged == "false")
            {
                Response.Redirect("Default2.aspx", true);
            }
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataKey dk = GridView1.SelectedDataKey;
        int a = 0;
        FormView1.PageIndex = 0;
        FormView1.DataBind();
        while (FormView1.DataKey.Value.ToString() != dk.Value.ToString() && a < FormView1.PageCount)
        {
            if (a + 1 < FormView1.PageCount)
            {
                FormView1.PageIndex++;
                FormView1.DataBind();
            }
        }

    }
}