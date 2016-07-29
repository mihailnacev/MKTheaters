﻿using System;
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

        if (!IsPostBack) {
            IspolniMaster();
        }

    }

    public void IspolniMaster() {

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
        finally {

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
        DataSet ds = (DataSet)ViewState["datatsetVS"];
        gvAllPlays.EditIndex = -1;
        gvAllPlays.DataSource = ds;
        gvAllPlays.DataBind();
    }

    protected void gvAllPlays_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString= ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "UPDATE Repertoar set" +
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
        finally {

            konekcija.Close();
            gvAllPlays.EditIndex = -1;

        }

        if (efekt != 0) {
            IspolniMaster();
        }
    }
}