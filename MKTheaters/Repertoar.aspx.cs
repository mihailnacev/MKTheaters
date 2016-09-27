using AjaxControlToolkit;
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
        if (!IsPostBack)
        {
            RequiredFieldValidator1.ErrorMessage = "<img id='error' src='Images/error-icon-25257-16x16.ico' alt='*'>";
            IspolniMaster();
        }
        main.Visible = true;
        mvSearch.ActiveViewIndex = 0;
        if (Request.QueryString["in"] != null)
        {
            int index = Convert.ToInt32(Request.QueryString["in"]);
            GridViewPageEventArgs ev = new GridViewPageEventArgs(index);
            gvPretstavi.PageIndex = ev.NewPageIndex;
            DataSet ds = (DataSet)ViewState["dataset"];
            gvPretstavi.DataSource = ds;
            gvPretstavi.DataBind();
        }


       if (Session["button1Clicked"]!=null) {

            mvSearch.ActiveViewIndex = 1;
            gvPretstavi.Visible = false;
            Panel1.Visible = false;
            calendarSearch.Visible = false;
            imCalendar.Visible = false;
            Session["button1Clicked"] = null;

        }

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
        catch (Exception err) { }
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
            DropDownList ddlDatumi = (DropDownList)e.Row.FindControl("ddlDatumi");
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            LinkButton lb = (LinkButton)e.Row.Cells[0].Controls[0];
            string ime = lb.Text;
            string sqlString = "SELECT Datum FROM Repertoar WHERE Ime=@ime";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@ime", ime);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    string datumi = citac["Datum"].ToString();
                    string[] parts = datumi.Split(';');
                    foreach (string part in parts)
                    {
                        ListItem li = new ListItem(part);
                        ddlDatumi.Items.Add(li);
                    }
                    citac.Close();
                }
            }
            catch (Exception) { }
            finally
            {
                konekcija.Close();
            }
        }


    }

    protected void gvPretstavi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Popup" && e.CommandArgument != null)
        {
            /*User najaven = (User)Session["Najaven"];
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (najaven == null)
            {
                string[] parts = Request.Url.ToString().Split('/');
                string url = parts[parts.Length - 1].Split('.')[0];
                Response.Redirect("~/Najava.aspx?ReturnUrl=" + url + "&in=" + gvPretstavi.PageIndex);
            }
            ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)gvPretstavi.Rows[rowIndex].FindControl("ModalPopupExtender1");
            LinkButton lb = (LinkButton)gvPretstavi.Rows[rowIndex].Cells[0].Controls[0];
            DropDownList datumi = (DropDownList)gvPretstavi.Rows[rowIndex].Cells[7].Controls[1];
            Session["Ime"] = lb.Text;
            Session["Datum"] = datumi.SelectedItem.Text;
            modalPopupExtender1.Show();*/

            //Perform any specific processing.
            //Label1.Text = string.Format("Row # {0}", rowIndex);
        }
    }

    protected void OK_Click(object sender, EventArgs e)
    {
        User najaven = (User)Session["Najaven"];
        string selektirano = (string)Session["Ime"];
        string datum = (string)Session["Datum"];
        //if (najaven != null)
        //{
            funkcija(najaven, selektirano, datum);
            string message = "Успешна резервација!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        /*}
        else
        {
            string message = "Најавете се прво!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }*/

    }

    public void funkcija(User user, string ime, string datum)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                /// <summary>
                /// SqlCommand object contains SqlConnection object and queryString (INSERT command with parameters) 
                /// </summary>
                SqlCommand commandInsert = new SqlCommand("INSERT INTO Rezervacii(Username,Pretstava,Datum,Ocena) VALUES(@username,@pretstava,@datum,@ocena)", connection);
                commandInsert.Parameters.AddWithValue("@username", user.Username);
                commandInsert.Parameters.AddWithValue("@pretstava", ime);
                commandInsert.Parameters.AddWithValue("@datum", datum);
                commandInsert.Parameters.AddWithValue("@ocena", "0");
                commandInsert.ExecuteNonQuery();
                commandInsert.Parameters.Clear();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
        }
    }

    protected void gvPretstavi_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ime = gvPretstavi.DataKeys[gvPretstavi.SelectedIndex].Value.ToString();
        string avtori = gvPretstavi.SelectedRow.Cells[1].Text;
        string reziser = gvPretstavi.SelectedRow.Cells[2].Text;
        string akteri = gvPretstavi.SelectedRow.Cells[3].Text;
        string teatar = gvPretstavi.SelectedRow.Cells[4].Text;
        string grad = gvPretstavi.SelectedRow.Cells[5].Text;
        string vremetraenje = gvPretstavi.SelectedRow.Cells[6].Text;
        DropDownList datum = (DropDownList)gvPretstavi.SelectedRow.Cells[7].FindControl("ddlDatumi");
        List<string> datumi = new List<string>();
        for (int i = 0; i < datum.Items.Count; i++)
        {
            datumi.Add(datum.Items[i].ToString());
        }
        Play pretstava = new Play(ime, avtori, reziser, teatar, grad, datumi, vremetraenje, akteri);
        Session["imenaP"] = pretstava;
        //Session["imenaP"] = gvPretstavi.DataKeys[gvPretstavi.SelectedIndex].Value.ToString();
        Response.Redirect("~/PretstavaDetails.aspx");
        
    }

    protected void gvPretstavi_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }


    protected void btnPrebarajPretstava_Click(object sender, EventArgs e)
    {
        mvSearch.ActiveViewIndex = 1;
        main.Visible = false;
        Panel1.Visible = false;
        uspeshnaRez.Visible = false;
        imCalendar.Visible = false;
        calendarSearch.Visible = false;
    }

    protected void btnNazad_Click(object sender, EventArgs e)
    {
        main.Visible = true;
        Panel1.Visible = true;
        pnlSearch.Visible = true;
        //
        gvPretstavi.Visible = true;
        mvSearch.ActiveViewIndex = 0;
        ViewState["set"] = null;
        ViewState["set1"] = null;
        ViewState["set2"] = null;
        ViewState["set3"] = null;
        ViewState["set4"] = null;
        ViewState["set5"] = null;
        ViewState["set6"] = null;
        lbStat.Visible = false;
    }

    protected void btnPreb_Click(object sender, EventArgs e)
    {


        if (ddlKriterium.SelectedItem.Text == "Град")
        {
            theatersService servis = new theatersService();
            DataSet result = servis.findByCity(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }

        else if (ddlKriterium.SelectedItem.Text == "Режисер")
        {
            theatersService servis = new theatersService();
            DataSet result = servis.findByDirector(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set1"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }

        else if (ddlKriterium.SelectedItem.Text == "Автор")
        {
            theatersService servis = new theatersService();
            DataSet result = servis.findByAuthor(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set2"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }

        else if (ddlKriterium.SelectedItem.Text == "Актер")
        {
            theatersService servis = new theatersService();
            DataSet result = servis.findByActor(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set3"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }

        else if (ddlKriterium.SelectedItem.Text == "Датум")
        {


            theatersService servis = new theatersService();
            DataSet result = servis.findByDate(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set4"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }

        else if (ddlKriterium.SelectedItem.Text == "Театар")
        {
            theatersService servis = new theatersService();
            DataSet result = servis.findByTheater(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set5"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }
        else if (ddlKriterium.SelectedItem.Text == "Име")
        {
            theatersService servis = new theatersService();
            DataSet result = servis.findByName(tbKluc.Text);
            dvPretstavi.DataSource = result;
            dvPretstavi.DataBind();
            ViewState["set6"] = result;
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
            if (result.Tables["Repertoar"].Rows.Count == 0) lbStat.Visible = true;
        }
        else
        {
            mvSearch.ActiveViewIndex = 0;
            main.Visible = true;
            Panel1.Visible = true;
        }
    }

    protected void dvPretstavi_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        dvPretstavi.PageIndex = e.NewPageIndex;
        if (ddlKriterium.SelectedItem.Text == "Град")
        {
            DataSet ds = (DataSet)ViewState["set"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }

        if (ddlKriterium.SelectedItem.Text == "Режисер")
        {
            DataSet ds = (DataSet)ViewState["set1"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }

        if (ddlKriterium.SelectedItem.Text == "Автор")
        {
            DataSet ds = (DataSet)ViewState["set2"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }

        if (ddlKriterium.SelectedItem.Text == "Актер")
        {
            DataSet ds = (DataSet)ViewState["set3"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }

        if (ddlKriterium.SelectedItem.Text == "Датум")
        {
            DataSet ds = (DataSet)ViewState["set4"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }

        if (ddlKriterium.SelectedItem.Text == "Театар")
        {
            DataSet ds = (DataSet)ViewState["set5"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }

        if (ddlKriterium.SelectedItem.Text == "Име")
        {
            DataSet ds = (DataSet)ViewState["set6"];
            dvPretstavi.DataSource = ds;
            dvPretstavi.DataBind();
            mvSearch.ActiveViewIndex = 2;
            main.Visible = false;
            Panel1.Visible = false;
        }
    }



    protected void dvPretstavi_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "select")
        {
            string ime = dvPretstavi.DataKey[0].ToString();
            int rowIndex = -1;
            gvPretstavi.AllowPaging = false;
            gvPretstavi.DataSource = ViewState["dataset"] as DataSet;
            gvPretstavi.DataBind();
            for (int i = 0; i < gvPretstavi.Rows.Count; i++)
            {
                string x = gvPretstavi.DataKeys[i].Value.ToString();
                //string x = gvPretstavi.Rows[i].Cells[0].Text;
                if (x == ime)
                {
                    rowIndex = i;
                    break;
                }
            }
            gvPretstavi.SelectedIndex = rowIndex;
            gvPretstavi_SelectedIndexChanged(sender, e);
        }

    }



    protected void ddlKriterium_SelectedIndexChanged(object sender, EventArgs e)
    {
        tbKluc.Text = "";
        if (ddlKriterium.SelectedItem.Text != " -Default -")
        {
            tbKluc.Enabled = true;
        }

        if (ddlKriterium.SelectedItem.Text == "Датум")
        {

            imCalendar.Visible = true;
            mvSearch.ActiveViewIndex = 1;
            main.Visible = false;

        }
        else
        {

            imCalendar.Visible = false;
            calendarSearch.Visible = false;
            mvSearch.ActiveViewIndex = 1;
            main.Visible = false;
        }
    }



    protected void imCalendar_Click(object sender, ImageClickEventArgs e)
    {

        mvSearch.ActiveViewIndex = 1;
        main.Visible = false;
        calendarSearch.Visible = !calendarSearch.Visible;

    }

    protected void calendarSearch_SelectionChanged(object sender, EventArgs e)
    {
        string help = calendarSearch.SelectedDate.ToShortDateString();

        string[] tokens = help.Split('.');
        string day = "";
        string month = "";
        string year = "";
        if (tokens.Length > 1)

        {
            month = tokens[1];
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            day = tokens[0];
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            year = tokens[2];

        }
        else {
            tokens = help.Split('/');
            month = tokens[0];
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            day = tokens[1];
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            year = tokens[2];
        
        }
        string argument = day + "." + month + "." + year;
        tbKluc.Text = argument;
        calendarSearch.Visible = false;
        mvSearch.ActiveViewIndex = 1;
        main.Visible = false;

    }

    protected void calendarSearch_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        calendarSearch.Visible = true;
        mvSearch.ActiveViewIndex = 1;
        main.Visible = false;
    }

    protected void btnBackView3_Click(object sender, EventArgs e)
    {
        mvSearch.ActiveViewIndex = 1;
        main.Visible = false;
        tbKluc.Text = "";
        lbStat.Visible = false;
    }

    protected void btnRezerviraj_Click(object sender, EventArgs e)
    {
        User najaven = (User)Session["Najaven"];
        if (najaven != null)
        {
            uspeshnaRez.Visible = true;
            string name = imeSkrieno.Text;
            string date = terminSkrieno.Text;
            funkcija(najaven, name, date);
        }
        else
        {
            string[] parts = Request.Url.ToString().Split('/');
            string url = parts[parts.Length - 1].Split('.')[0];
            Response.Redirect("~/Najava.aspx?ReturnUrl=" + url + "&in=" + gvPretstavi.PageIndex);
        }
    }
}