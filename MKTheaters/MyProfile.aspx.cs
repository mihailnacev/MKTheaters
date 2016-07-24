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
            if (!IsPostBack) IspolniLista();
        }
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlMyProfile.Visible = true;

    }

    protected void btnReservations_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlReservations.Visible = true;
    }

    protected void btnSuggestions_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlSuggest.Visible = true;
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
            while (citac.Read())
            {
                ListItem li = new ListItem(citac[0].ToString() +" " +citac[2].ToString());
                lbRezervacii.Items.Add(li);
            }
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

    
}