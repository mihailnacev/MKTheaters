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
        string ime = (string)Session["imenaP"];
        lblIme.Text = ime;
        selektirajPretstava(ime);
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
                lblAvtor.Text = citac[1].ToString().Replace(';', ',');
                lblReziser.Text = citac[2].ToString();
                lblAkteri.Text = citac[3].ToString().Replace(';', ',');
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
        string ime = (string)Session["imenaP"];
        if (najaven != null)
        {
            funkcija(najaven, ime,ddlDatumi.SelectedItem.Text);
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
}