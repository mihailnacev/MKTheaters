using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Pocetna : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindListView();
        }
    }

    private void BindListView()
    {
        string constr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Details";
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    lvPlays.DataSource = dt;
                    lvPlays.DataBind();
                }
            }
        }
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lvPlays.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.BindListView();
    }

    protected void getInformations(string play)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Ime=@ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", play);
        Play pretstava;
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            if (citac.Read())
            {
                string datum = citac["Datum"].ToString();
                string[] parts = datum.Split(';');
                List<string> datumi = new List<string>();
                for (int i = 0; i < parts.Length; i++)
                {
                    datumi.Add(parts[i]);
                }
                string ime = play;
                string avtori = citac["Avtor"].ToString();
                string reziser = citac["Reziser"].ToString();
                string akteri = citac["Akteri"].ToString();
                string teatar = citac["Teatar"].ToString();
                string grad = citac["Grad"].ToString();
                string vremetraenje = citac["Vremetraenje"].ToString();
                pretstava = new Play(ime, avtori, reziser, teatar, grad, datumi, vremetraenje, akteri);
                Session["imenaP"] = pretstava;
                Response.Redirect("~/PretstavaDetails.aspx");
            }
        }
        finally
        {
            konekcija.Close();
        }
    }

    protected void nasocuvac_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        //Session["imenaP"] = clickedButton.Text;
        getInformations(clickedButton.Text);
        Response.Redirect("~/PretstavaDetails.aspx");
    }
    protected void RepButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Repertoar.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if(Session["button1Clicked"]==null)
        Session["button1Clicked"] = 1;
        Response.Redirect("~/Repertoar.aspx");

    }
}