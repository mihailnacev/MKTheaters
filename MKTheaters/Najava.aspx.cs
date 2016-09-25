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
            User najaven = (User)Session["Najaven"];
            if (najaven.Admin == "False")
            {
                Response.Redirect("~/MyProfile.aspx");
            }
            else
            {
                Response.Redirect("~/Administracija.aspx");
            }
        }
        if (!IsPostBack)
        {
            rfvPassword.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
            rfvUsername.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
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
            statusContainer.Visible = true;
        }
        else
        {
            if (tekoven.Password != txtLozinka.Text.GetHashCode().ToString())
            {
                LogInStatus.Text = "Погрешна лозинка!";
                statusContainer.Visible = true;
            }
            else
            {
                Session["Najaven"] = tekoven;
                if (Request.QueryString["ReturnUrl"] != null && Request.QueryString["ReturnUrl"] != "UspesnaRegistracija" && Request.QueryString["ReturnUrl"] != "Registracija")
                {
                    if (Request.QueryString["in"] == null)
                    {
                        Response.Redirect("~/" + Request.QueryString["ReturnUrl"] + ".aspx");
                    }
                    else
                    {
                        Response.Redirect("~/" + Request.QueryString["ReturnUrl"] + ".aspx" + "?in=" + Request.QueryString["in"]);
                    }
                }
                else if (tekoven.Admin == "False")
                {
                    Response.Redirect("~/MyProfile.aspx");
                }
                else
                {
                    Response.Redirect("~/Administracija.aspx");
                }
            }
        }
    }






}