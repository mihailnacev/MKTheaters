using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Try : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack) IspolniMaster();
    }

    public void IspolniMaster()
    {

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Primer";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {

            konekcija.Open();
            adapter.Fill(ds, "Primer");
            gvProben.DataSource = ds;
            gvProben.DataBind();
            ViewState["datasetPR"] = ds;

        }
        catch (Exception err)
        {


        }
        finally
        {

            konekcija.Close();
        }


    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "INSERT INTO Primer (Ime, Avtor) VALUES ('Brachna igra', 'Toni Mihajlovski')";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {

            konekcija.Open();
            adapter.Fill(ds, "Primer");
            gvProben.DataSource = ds;
            gvProben.DataBind();
            ViewState["datasetPR"] = ds;

        }
        catch (Exception) { }
        finally
        {

            konekcija.Close();
            Response.Redirect("~/Try.aspx");
        }

    }
}