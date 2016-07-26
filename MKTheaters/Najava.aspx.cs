using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Najava : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Najaven"] != null)
        {
            Response.Redirect("~/MyProfile.aspx");
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registracija.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        User tekoven = Connectivity.SignIn(username);
        if (tekoven == null)
        {
            LogInStatus.Text = "Не постои корисник со тоа корисничко име!";
            LogInStatus.Visible = true;
        }
        else
        {
            if (tekoven.Password != txtLozinka.Text.GetHashCode().ToString())
            {
                LogInStatus.Text = "Погрешна лозинка!";
                LogInStatus.Visible = true;
            }
            else
            {
                Session["Najaven"] = tekoven;
                Response.Redirect("~/MyProfile.aspx");
            }
        }
    }





  
}