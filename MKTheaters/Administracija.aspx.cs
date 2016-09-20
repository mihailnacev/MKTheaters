using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Administracija : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Najaven"] == null)
        {
            Response.Redirect("~/Najava.aspx");
        }
        pnlAR.Visible = true;
        mvPrvPanel.ActiveViewIndex = 0;
        mvVtorPanel.ActiveViewIndex = 0;
        pnlPR.Visible = false;
        if (Session["index"] == null)
        {
            gvAllPlays.PageIndex = 0;
            Session["index"] = 0;
        }
        else
        {
            gvAllPlays.PageIndex = (int)Session["index"];
        }
        if (!IsPostBack) IspolniMaster();
        if (!IsPostBack) IspolniRezervacii();

    }

    public void IspolniMaster()
    {

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {

            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
            gvAllPlays.DataSource = ds;
            gvAllPlays.DataBind();
            ViewState["datasetVS"] = ds;

        }
        catch (Exception err)
        {


        }
        finally
        {

            konekcija.Close();
        }


    }

    protected void btnAR_Click(object sender, EventArgs e)
    {
        pnlAR.Visible = true;
        pnlPR.Visible = false;
    }

    protected void btnPR_Click(object sender, EventArgs e)
    {
        pnlPR.Visible = true;
        pnlAR.Visible = false;
    }

    protected void gvAllPlays_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAllPlays.PageIndex = e.NewPageIndex;
        Session["index"] = e.NewPageIndex;
        gvAllPlays.SelectedIndex = -1;
        DataSet ds = (DataSet)ViewState["datasetVS"];
        gvAllPlays.DataSource = ds;
        gvAllPlays.DataBind();
    }

    protected void gvAllPlays_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetVS"];
        gvAllPlays.EditIndex = e.NewEditIndex;
        gvAllPlays.DataSource = ds;
        gvAllPlays.DataBind();
    }

    protected void gvAllPlays_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAllPlays.EditIndex = -1;
        DataSet ds = (DataSet)ViewState["datatsetVS"];
        gvAllPlays.DataSource = ds;
        gvAllPlays.DataBind();
        Response.Redirect("~/Administracija.aspx");
    }

    protected void gvAllPlays_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "UPDATE Repertoar SET" +
            " Avtor=@Avtor, Reziser=@Reziser, Akteri=@Akteri, Teatar=@Teatar, Grad=@Grad, Datum=@Datum, Vremetraenje=@Vremetraenje WHERE Ime=@Ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);



        TextBox tbAvtor = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[1].Controls[0];
        komanda.Parameters.AddWithValue("@Avtor", tbAvtor.Text);

        TextBox tbReziser = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[2].Controls[0];
        komanda.Parameters.AddWithValue("@Reziser", tbReziser.Text);

        TextBox tbAkteri = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@Akteri", tbAkteri.Text);

        TextBox tbTeatar = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@Teatar", tbTeatar.Text);

        TextBox tbGrad = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[5].Controls[0];
        komanda.Parameters.AddWithValue("@Grad", tbGrad.Text);

        TextBox tbDatum = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[6].Controls[0];
        komanda.Parameters.AddWithValue("@Datum", tbDatum.Text);

        TextBox tbVremetraenje = (TextBox)gvAllPlays.Rows[e.RowIndex].Cells[7].Controls[0];
        komanda.Parameters.AddWithValue("@Vremetraenje ", tbVremetraenje.Text);

        komanda.Parameters.AddWithValue("@Ime", gvAllPlays.Rows[e.RowIndex].Cells[0].Text);

        int efekt = 0;

        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();
        }
        catch
        {

        }
        finally
        {

            konekcija.Close();
            gvAllPlays.EditIndex = -1;

        }

        if (efekt != 0)
        {
            IspolniMaster();
        }
    }

    protected void gvAllPlays_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ime = gvAllPlays.Rows[e.RowIndex].Cells[0].Text;
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "DELETE FROM Repertoar WHERE Ime=@Ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@Ime", ime);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {

            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
            gvAllPlays.DataSource = ds;
            gvAllPlays.DataBind();
            ViewState["datasetVS"] = ds;

        }
        catch (Exception) { }
        finally
        {

            konekcija.Close();
            Response.Redirect("~/Administracija.aspx");
        }

    }

    protected void btnDodadi_Click(object sender, EventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string ime = txtIme.Text;
        string avtor = txtAvtor.Text;
        string akter = txtAkteri.Text;
        string reziser = txtReziser.Text;
        string teatar = txtTeatar.Text;
        string grad = txtGrad.Text;
        string datum = txtDatum.Text;
        string vreme = txtVreme.Text;
        string sqlString = "INSERT INTO Repertoar (Ime, Avtor, Reziser, Akteri, Teatar, Grad, Datum, Vremetraenje) VALUES (@ime, @avtor, @reziser, @akteri, @teatar, @grad, @datum, @vreme)";

        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", ime);
        komanda.Parameters.AddWithValue("@avtor", avtor);
        komanda.Parameters.AddWithValue("@reziser", reziser);
        komanda.Parameters.AddWithValue("@akteri", akter);
        komanda.Parameters.AddWithValue("@teatar", teatar);
        komanda.Parameters.AddWithValue("@grad", grad);
        komanda.Parameters.AddWithValue("@datum", datum);
        komanda.Parameters.AddWithValue("@vreme", vreme);

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {

            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
            gvAllPlays.DataSource = ds;
            gvAllPlays.DataBind();
            ViewState["datasetPR"] = ds;

        }
        catch (Exception) { }
        finally
        {

            konekcija.Close();
            Response.Redirect("~/Administracija.aspx");
        }
    }



    protected void btnAddPlay_Click(object sender, EventArgs e)
    {
        mvPrvPanel.ActiveViewIndex = 1;
    }

    protected void btnNazad_Click(object sender, EventArgs e)
    {
        mvPrvPanel.ActiveViewIndex = 0;
    }

    protected void IspolniRezervacii()
    {

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Rezervacii";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {

            konekcija.Open();
            adapter.Fill(ds, "Rezervacii");
            gvSeeReservations.DataSource = ds;
            gvSeeReservations.DataBind();
            ViewState["datasetRezervacii"] = ds;

        }
        catch (Exception err)
        {


        }
        finally
        {

            konekcija.Close();
        }


    }

    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        pnlAR.Visible = false;
        pnlPR.Visible = true;
        mvVtorPanel.ActiveViewIndex = 1;
        string korisnik = txtSearchUser.Text;
        lblSearchUser.Text = "Резервации од страна на " + korisnik;
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT Pretstava,Datum,Ocena FROM Rezervacii WHERE Username=@korisnik";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@korisnik", korisnik);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {

            konekcija.Open();
            adapter.Fill(ds, "ByUser");
            gvByUser.DataSource = ds;
            gvByUser.DataBind();
            ViewState["datasetByUser"] = ds;

        }
        catch (Exception err)
        {


        }
        finally
        {

            konekcija.Close();
        }

    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        pnlAR.Visible = false;
        pnlPR.Visible = true;
        mvVtorPanel.ActiveViewIndex = 0;
    }
}