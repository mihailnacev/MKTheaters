﻿using AjaxControlToolkit;
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
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            ModalPopupExtender modalPopupExtender1 = (ModalPopupExtender)gvPretstavi.Rows[rowIndex].FindControl("ModalPopupExtender1");
            LinkButton lb=(LinkButton)gvPretstavi.Rows[rowIndex].Cells[0].Controls[0];
            DropDownList datumi = (DropDownList)gvPretstavi.Rows[rowIndex].Cells[7].Controls[1];
            Session["Ime"] = lb.Text;
            Session["Datum"] = datumi.SelectedItem.Text;
            modalPopupExtender1.Show();

            //Perform any specific processing.
            //Label1.Text = string.Format("Row # {0}", rowIndex);
        }
    }

    protected void OK_Click(object sender, EventArgs e)
    {
        User najaven = (User)Session["Najaven"];
        string selektirano = (string)Session["Ime"];
        string datum = (string)Session["Datum"];
        if (najaven != null)
        {
            funkcija(najaven, selektirano,datum);
            string message = "Успешна резервација!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
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
        }
        
    }

    public void funkcija(User user,string ime,string datum)
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
                SqlCommand commandInsert = new SqlCommand("INSERT INTO Rezervacii(Username,Pretstava,Datum) VALUES(@username,@pretstava,@datum)", connection);
                commandInsert.Parameters.AddWithValue("@username", user.Username);
                commandInsert.Parameters.AddWithValue("@pretstava", ime);
                commandInsert.Parameters.AddWithValue("@datum", datum);
                
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

    protected void Cancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnPrebaraj_Click(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value = Convert.ToInt32(DropDownList1.SelectedValue);
        switch (value)
        {
            case 1: lbl1.Visible = true;
                break;
            case 2: lbl2.Visible = true;
                break;
            case 3: lbl3.Visible = true;
                break;
            case 4: lbl4.Visible = true;
                break;
            case 5: lbl5.Visible = true;
                break;
            case 6: lbl6.Visible = true;
                break;
        }
    }

    protected void gvPretstavi_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["imenaP"] = gvPretstavi.DataKeys[gvPretstavi.SelectedIndex].Value.ToString();
        Response.Redirect("~/PretstavaDetails.aspx");
    }

    protected void gvPretstavi_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }
}