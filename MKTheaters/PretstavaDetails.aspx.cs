using System;
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
        //lblProsechnaOcenka.Text = pretstava.Ocena.ToString();
        lblAvtor.Text = pretstava.Avtori.Replace(";", ", ");
        lblAkteri.Text=pretstava.Akteri.Replace(";", ", ");
        ddlDatumi.DataSource = pretstava.Datumi;
        ddlDatumi.DataBind();
        //Session["imenaP"] = null;
        //string ime = (string)Session["imenaP"];
        //lblIme.Text = ime;
        //selektirajPretstava(ime);
        //double grade = prosechnaOcena(ime);

        /*SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Ime=@ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", ime);
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            if (citac.Read() != false)
            {
                lblIme.Text= citac[0].ToString();
                lblAvtor.Text= citac[1].ToString().Replace(';', ',');
                lblReziser.Text= citac[2].ToString();
                lblAkteri.Text= citac[3].ToString().Replace(';',',');
                lblTeatarGrad.Text= citac[4].ToString() + " " + citac[5].ToString();
                lblVremetraenje.Text= citac[7].ToString()+" минути";
                citac.Close();
            }
        }
        catch (Exception) { }
        finally { konekcija.Close(); }*/
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

    protected void selektirajPretstava(string ime)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Ime=@ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", ime);
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            if (citac.Read() != false)
            {
                lblIme.Text = citac[0].ToString();
                lblAvtor.Text = citac[1].ToString().Replace(";", ", ");
                lblReziser.Text = citac[2].ToString();
                lblAkteri.Text = citac[3].ToString().Replace(";", ", ");
                lblTeatarGrad.Text = citac[4].ToString() + " " + citac[5].ToString();
                string datumi = citac[6].ToString();
                string[] parts = datumi.Split(';');
                foreach(string part in parts)
                {
                    ddlDatumi.Items.Add(new ListItem(part));
                }
                lblVremetraenje.Text = citac[7].ToString() + " минути";
                citac.Close();
            }
        }
        catch (Exception) { }
        finally { konekcija.Close(); }
    }

    protected void btnRezerviraj_Click(object sender, EventArgs e)
    {
        User najaven = (User)Session["Najaven"];
        //string ime = (string)Session["imenaP"];
        if (najaven != null)
        {
            uspeshnaRez.Visible = true;
            btnShowModal.Visible = false;
            funkcija(najaven, lblIme.Text,ddlDatumi.SelectedItem.Text);
            /*string message = "Успешна резервација!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());*/
        }
        else
        {
            /*string message = "Најавете се прво!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());*/
            string[] parts = Request.Url.ToString().Split('/');
            string url = parts[parts.Length - 1].Split('.')[0];
            Response.Redirect("~/Najava.aspx?ReturnUrl=" + url);
        }
    }

    protected void funkcija(User user, string ime,string datum)
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
}