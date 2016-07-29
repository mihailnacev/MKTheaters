using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Najaven"] == null)
        {
            Response.Redirect("~/Najava.aspx");
        }
        else
        {
            User tekoven = (User)Session["Najaven"];
            lblFirstNameText.Text = tekoven.Ime;
            lblLastNameText.Text = tekoven.Prezime;
            lblEmailText.Text = tekoven.Email;
            lblUsernameText.Text = tekoven.Username;
            if (!IsPostBack)
            {
                IspolniLista();
                txtFirstNameText.Text = tekoven.Ime;
                txtLastNameText.Text = tekoven.Prezime;
                txtEmailText.Text = tekoven.Email;
            }
        }
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlMyProfile.Visible = true;
        lblError.Text = "";
    }

    protected void btnReservations_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlReservations.Visible = true;
        lblError.Text = "";
    }

    protected void btnSuggestions_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlSuggest.Visible = true;
        lblError.Text = "";
    }

    protected void IspolniLista()
    {
        User tekoven = (User)Session["Najaven"];
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Rezervacii WHERE Username='" + tekoven.Username + "'";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            List<string> pretstavi1 = new List<string>();
            List<string> pretstavi2 = new List<string>();
            while (citac.Read())
            {
                //ListItem li = new ListItem(citac[0].ToString() + " " + citac[2].ToString(), citac[0].ToString());
                //lbRezervacii.Items.Add(li);
                pretstavi1.Add(citac[0].ToString() + " " + citac[2].ToString());
                pretstavi2.Add(citac[0].ToString());
            }
            lbRezervacii.DataSource = pretstavi1;
            lbRezervacii.DataBind();
            ddlPretstavi.DataSource = pretstavi2;
            ddlPretstavi.DataBind();
            citac.Close();

        }
        catch (Exception) { }
        finally
        {
            konekcija.Close();
        }
    }

    public void MoveUp()
    {
        MoveItem(-1);
    }

    public void MoveDown()
    {
        MoveItem(1);
    }

    public void MoveItem(int direction)
    {
        // Checking selected item
        if (lbRezervacii.SelectedItem == null || lbRezervacii.SelectedIndex < 0)
            return; // No selected item - nothing to do

        // Calculate new index using move direction
        int newIndex = lbRezervacii.SelectedIndex + direction;

        // Checking bounds of the range
        if (newIndex < 0 || newIndex >= lbRezervacii.Items.Count)
            return; // Index out of range - nothing to do

        ListItem selected = lbRezervacii.SelectedItem;

        // Removing removable element
        lbRezervacii.Items.Remove(selected);
        // Insert it in new position
        lbRezervacii.Items.Insert(newIndex, selected);
        // Restore selection
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        MoveUp();
    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        MoveDown();
    }

    protected void btnZachuvaj_Click(object sender, EventArgs e)
    {
        string ime = txtFirstNameText.Text;
        string prezime = txtLastNameText.Text;
        string email = txtEmailText.Text;
        string newPass = txtNovaLozinka.Text;
        string pass = txtTekovnaLozinka.Text/*.GetHashCode().ToString()*/;
        User tekoven = (User)Session["Najaven"];
        if (pass.GetHashCode().ToString() != tekoven.Password)
        {
            lblError.Text = "Погрешна лозинка";
        }
        else
        {
            if (ime == "")
            {
                ime = tekoven.Ime;
            }
            if (prezime == "")
            {
                prezime = tekoven.Prezime;
            }
            if (email == "")
            {
                email = tekoven.Email;
            }
            if (newPass != "")
            {
                pass = newPass;
            }
            User newUser = new User(ime, prezime, tekoven.Username, pass.GetHashCode().ToString(), email, tekoven.Admin);
            Connectivity.updateUserInformation(newUser);
            Session["Najaven"] = newUser;
            lblFirstNameText.Text = newUser.Ime;
            lblLastNameText.Text = newUser.Prezime;
            lblEmailText.Text = newUser.Email;
            lblError.Text = "Информациите се успешно ажурирани";
        }
    }
}