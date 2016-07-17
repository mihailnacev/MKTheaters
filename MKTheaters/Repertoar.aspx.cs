using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Repertoar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) IspolniMaster();
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
            gvPretstavi.DataSource = ds;
            gvPretstavi.DataBind();
            ViewState["dataset"] = ds;
        }
        catch(Exception err){ }
        finally
        {
            konekcija.Close();
        }
    }

    protected void gvPretstavi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPretstavi.PageIndex = e.NewPageIndex;
        gvPretstavi.SelectedIndex = -1;
        DataSet ds = (DataSet)ViewState["dataset"];
        gvPretstavi.DataSource = ds;
        gvPretstavi.DataBind();
    }

    protected void gvPretstavi_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}