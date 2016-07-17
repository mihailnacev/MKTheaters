using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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


    protected void gvPretstavi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            LinkButton1.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void gvPretstavi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Popup" && e.CommandArgument != null)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)gvPretstavi.Rows[rowIndex].FindControl("ModalPopupExtender1");
            modalPopupExtender1.Show();

            //Perform any specific processing.
            //Label1.Text = string.Format("Row # {0}", rowIndex);
        }
    }
}