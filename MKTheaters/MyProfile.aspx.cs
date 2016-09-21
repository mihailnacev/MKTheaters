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
                revEmail.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
                revPass.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
                cvLozinki.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
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
                pretstavi1.Add(citac[0].ToString() + " - " + citac[2].ToString());
                pretstavi2.Add(citac[0].ToString());
            }
            lbRezervacii.DataSource = pretstavi1;
            lbRezervacii.DataBind();
            ddlPretstavi.DataSource = pretstavi2;
            ddlPretstavi.DataBind();
            citac.Close();
            if (pretstavi1.Count == 0)
            {
                pnlOstvareniRezervacii.Visible = false;
                pnlOstvareniRezervaciiEmpty.Visible = true;
            }
            else
            {
                pnlOstvareniRezervaciiEmpty.Visible = false;
                pnlOstvareniRezervacii.Visible = true;
            }
            if (pretstavi2.Count == 0)
            {
                Label3.Visible = true;
                lblPretstava.Visible = false;
                ddlPretstavi.Visible = false;
                Label4.Visible = false;
                rblOceni.Visible = false;
                btnOcena.Visible = false;
                rating.Visible = false;
            }
            else
            {
                Label3.Visible = false;
                lblPretstava.Visible = true;
                ddlPretstavi.Visible = true;
                Label4.Visible = true;
                rblOceni.Visible = true;
                btnOcena.Visible = true;
                rating.Visible = true;
            }
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


    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lbRezervacii.SelectedItem != null)
        {
            User tekoven = (User)Session["Najaven"];
            string selected = lbRezervacii.SelectedItem.Text;
            char[] whitespace = new char[] { ';' };
            string[] parts = selected.Split(whitespace);
            string pretstava = parts[0];
            string datum = parts[1];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string sqlString = "DELETE FROM Rezervacii WHERE Username='" + tekoven.Username + "' AND Pretstava=@pretstava AND Datum=@datum";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@pretstava", pretstava);
            komanda.Parameters.AddWithValue("@datum", datum);
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();

            }
            catch (Exception) { }
            finally
            {
                konekcija.Close();
            }
            IspolniLista();
        }
    }

    public void updatePretstavaDetails(string username, string pretstava, string ocena)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        string commandString = "UPDATE Rezervacii SET Ocena=@ocena WHERE Username=@username AND Pretstava=@pretstava";
        SqlCommand command = new SqlCommand(commandString, connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@pretstava", pretstava);
        command.Parameters.AddWithValue("@ocena", ocena);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }
    protected void btnOcena_Click(object sender, EventArgs e)
    {
        User najaven = (User)Session["Najaven"];
        string username = najaven.Username;
        string pretstava = ddlPretstavi.SelectedItem.Text;
        //string ocena = rblOceni.SelectedItem.Text;
        string ocena = ocenaHidden.Text;
        updatePretstavaDetails(username, pretstava, ocena);
        lblStatus.Text = "Успешно ја оценивте претставата!";
        lblStatus.Visible = true;
    }
}