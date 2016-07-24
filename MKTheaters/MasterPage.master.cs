using System;
using System.Collections.Generic;
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
        Response.Redirect("~/Najava.aspx");
    }

    protected void Pocetna_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pocetna.aspx");
    }

    protected void Repertoar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Repertoar.aspx");
    }

    protected void ZaNas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/About.aspx");
    }

    protected void MojProfil_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyProfile.aspx");
    }
}
