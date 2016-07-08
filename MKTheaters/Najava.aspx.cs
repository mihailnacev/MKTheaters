using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Najava : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registracija.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        User tekoven = Connectivity.SignIn(username);
        if (tekoven == null) Response.Redirect("~/login.aspx?status=Не постои тaкoв Username!");
        else
        {
            if (tekoven.Password != txtLozinka.Text) Response.Redirect("~/login.aspx?status=Погрешна лозинка!");
            else
            {
                  Session["Najaven"] = tekoven;
                  Response.Redirect("~/login.aspx?status=Успешна најава!");
            }
        }
    }
}