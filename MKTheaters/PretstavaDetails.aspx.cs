﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PretstavaDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["imenaP"] == null)
        {
            Response.Redirect("~/Repertoar.aspx");
        }
        Play pretstava = (Play)Session["imenaP"];
        lblIme.Text = pretstava.Ime;
        ime.Text = pretstava.Ime;
        lblVremetraenje.Text = pretstava.Vremetraenje + " минути";
        lblTeatarGrad.Text = pretstava.Teatar + " " + pretstava.Grad;
        lblReziser.Text = pretstava.Reziser;
        double ocena = prosechnaOcena(pretstava.Ime);
        int ocenaInt = (int)ocena;
        double ocenaDouble = ocena - ocenaInt;
        lblProsechnaOcenka.Text = "";
        int i = 5;
        for (i = 5; i < ocenaInt; i++)
        {
            lblProsechnaOcenka.Text += "<i class='fa fa-star faa-pulse faa-slow' aria-hidden='true' style='font-size:1.2em;color:#BA252A'></i>";
        }
        if (ocenaDouble >= 0.5)
        {
            lblProsechnaOcenka.Text += "<i class='fa fa-star-half-o faa-pulse faa-slow' aria-hidden='true' style='font-size:1.2em;color:#BA252A'></i>";
            i++;
        }
        while (i < 10)
        {
            lblProsechnaOcenka.Text += "<i class='fa fa-star-o faa-pulse faa-slow' aria-hidden='true' style='font-size:1.2em;color:#BA252A'></i>";
            i++;
        }
        lblAvtor.Text = pretstava.Avtori.Replace(";", ", ");
        lblAkteri.Text = pretstava.Akteri.Replace(";", ", ");
        ddlDatumi.DataSource = pretstava.Datumi;
        ddlDatumi.DataBind();
    }

    public double prosechnaOcena(string pretstava)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        string commandString = "SELECT Ocena FROM Rezervacii WHERE Pretstava=@pretstava";
        SqlCommand command = new SqlCommand(commandString, connection);
        command.Parameters.AddWithValue("@pretstava", pretstava);
        int oceni = 0;
        int count = 0;
        try
        {
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int o = Convert.ToInt32(dataReader[0]);
                if (o != 0)
                {
                    oceni += Convert.ToInt32(dataReader[0]);
                    count++;
                }
            }
            dataReader.Close();
            if (oceni <= 0)
            {
                oceni = 5;
                count = 1;
            }
        }
        finally
        {
            connection.Close();
        }
        return oceni * 1.0 / count;
    }

    protected void btnRezerviraj_Click(object sender, EventArgs e)
    {
        User najaven = (User)Session["Najaven"];
        if (najaven != null)
        {
            uspeshnaRez.Visible = true;
            btnShowModal.Visible = false;
            funkcija(najaven, lblIme.Text, ddlDatumi.SelectedItem.Text);
        }
        else
        {
            string[] parts = Request.Url.ToString().Split('/');
            string url = parts[parts.Length - 1].Split('.')[0];
            Response.Redirect("~/Najava.aspx?ReturnUrl=" + url);
        }
    }

    protected void funkcija(User user, string ime, string datum)
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
            finally
            {
                connection.Close();
            }
        }
    }
}