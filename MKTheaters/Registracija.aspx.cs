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
        statusContainer.Visible = false;
        if (!IsPostBack)
        {
            revEmail.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
            revPassword.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
            revUsername.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
            cvConfirmPassword.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
        }
    }

    protected bool uniqueUsername(string userName)
    {
        HashSet<string> set = Connectivity.getUsernames();
        if (set.Contains(userName))
        {
            return false;
        }
        return true;
    }

    protected void btnPodnesi_Click(object sender, EventArgs e)
    {
        string ime = txtFirstName.Text;
        string prezime = txtLastName.Text;
        string email = txtEmail.Text;
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string confirm = txtConfirmPassword.Text;
        if (!uniqueUsername(username) && username != "")
        {
            lblMsg.Text = "Веќе постои корисник со тоа корисничко име. Корисничките имиња се единствени.";
            statusContainer.Visible = true;
        }
        else if (ime == "" || prezime == "" || email == "" || username == "" || password == "" || confirm == "")
        {
            lblMsg.Text = "Сите полиња се задолжителни.";
            statusContainer.Visible = true;
        }
        else
        {
            User user = new User(ime, prezime, username, password, email, "False");
            Connectivity.SignUp(user);
            Response.Redirect("~/UspesnaRegistracija.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Najava.aspx");
    }
}