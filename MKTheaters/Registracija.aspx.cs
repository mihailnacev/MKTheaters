using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registracija : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
    }

    protected void btnPodnesi_Click(object sender, EventArgs e)
    {
        string ime = txtFirstName.Text;
        string prezime = txtLastName.Text;
        string email = txtEmail.Text;
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string confirm = txtConfirmPassword.Text;
        if (ime == "" || prezime == "" || email == "" || username == "" || password == "" || confirm == "") 
        {
            lblMsg.Text = "Сите полиња се задолжителни";   
        }
        else
        {
           User user = new User(ime, prezime,username,password,email, "False");
           Connectivity.SignUp(user);
           Response.Redirect("~/UspesnaRegistracija.aspx");
        }
    }
}