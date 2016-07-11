using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Najaven"] != null)
        {
            User u = (User)Session["Najaven"];
            user.Text = u.Username;
            loggedUser.Visible = true;
            noLoggedUser.Visible = false;
        }
        else
        {
            loggedUser.Visible = false;
            noLoggedUser.Visible = true;
        }
    }

    protected void logIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Najava.aspx");
    }

    protected void register_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registracija.aspx");
    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["Najaven"] = null;
        loggedUser.Visible = false;
        noLoggedUser.Visible = true;
    }


    protected void Najava_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Najava.aspx");
    }
}
