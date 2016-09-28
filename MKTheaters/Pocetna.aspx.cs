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
        theatersService servis = new theatersService();
        Play pretstava = servis.getPlayInformation(play);
        Session["imenaP"] = pretstava;
        Response.Redirect("~/PretstavaDetails.aspx");
    }

    protected void nasocuvac_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        getInformations(clickedButton.Text);
        Response.Redirect("~/PretstavaDetails.aspx");
    }

    protected void RepButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Repertoar.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Repertoar.aspx?search=true");
    }

    protected void skrienoKopche_Click(object sender, EventArgs e)
    {
        getInformations(skrienTextBox.Text);
        Response.Redirect("~/PretstavaDetails.aspx");
    }
}