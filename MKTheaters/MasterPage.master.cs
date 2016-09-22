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
            if (u.Admin == "True")
            {
                //user.NavigateUrl = "~/Administracija.aspx";
                MojProfil.Text = "АДМИНИСТРАЦИЈА";
                MojProfil.Font.Name = "Malgun Gothic";
            }
        }
        else
        {
            loggedUser.Visible = false;
            noLoggedUser.Visible = true;
        }
    }

    protected void logIn_Click(object sender, EventArgs e)
    {
        string[]parts = Request.Url.ToString().Split('/');
        string url = parts[parts.Length - 1].Split('.')[0];
        Response.Redirect("~/Najava.aspx?ReturnUrl=" + url);
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
        string[] parts = Request.Url.ToString().Split('/');
        string url = parts[parts.Length - 1];
        Response.Redirect(url);
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
        User tekoven = (User)Session["Najaven"];
        if (tekoven != null)
        {
            if (tekoven.Admin == "False")
            {
                Response.Redirect("~/MyProfile.aspx");
            }
            else
            {
                Response.Redirect("~/Administracija.aspx");
            }
        }
        else
        {
            Response.Redirect("~/Najava.aspx");
        }
    }
}
