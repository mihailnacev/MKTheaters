using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for theatersService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class theatersService : System.Web.Services.WebService
{
    public theatersService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "Vraka objekt od klasata Play za soodvetnoto ime na pretstava")]
    public Play getPlayInformation(string name)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Ime=@ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", name);
        Play pretstava = null;
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            if (citac.Read())
            {
                string datum = citac["Datum"].ToString();
                string[] parts = datum.Split(';');
                List<string> datumi = new List<string>();
                for (int i = 0; i < parts.Length; i++)
                {
                    datumi.Add(parts[i]);
                }
                string ime = name;
                string avtori = citac["Avtor"].ToString();
                string reziser = citac["Reziser"].ToString();
                string akteri = citac["Akteri"].ToString();
                string teatar = citac["Teatar"].ToString();
                string grad = citac["Grad"].ToString();
                string vremetraenje = citac["Vremetraenje"].ToString();
                pretstava = new Play(ime, avtori, reziser, teatar, grad, datumi, vremetraenje, akteri);
            }
        }
        finally
        {
            konekcija.Close();
        }
        return pretstava;
    }

    [WebMethod(Description = "Vraka lista od datumi za odredena pretstava")]
    public string[] findDates(string name)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT Datum FROM Repertoar WHERE Ime=@ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", name);
        string datumi = null;
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                datumi = citac["Datum"].ToString();
            }
            citac.Close();
        }
        finally
        {
            konekcija.Close();
        }
        return datumi.Split(';');
    }

    [WebMethod(Description = "Vraka DataSet od site pretstavi koi se na repertoarot")]
    public DataSet findAll()
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
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi koi se na repertoar vo gradot koj e vlezen argument")]
    public DataSet findByCity(string City)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Grad=@city";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@city", City);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi chij reziser e reziserot koj e daden kako vlezen argument")]
    public DataSet findByDirector(string Director)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Reziser=@director";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@director", Director);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi chij avtor e avtorot koj e daden kako vlezen argument")]
    public DataSet findByAuthor(string Author)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Avtor LIKE N'%" + Author + "%'";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi vo koi igra akterot koj e daden kako vlezen argument")]
    public DataSet findByActor(string Actor)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Akteri LIKE N'%" + Actor + "%'";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi koi se na repertoar na datumot koj e daden kako vlezen argument")]
    public DataSet findByDate(string Date)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Datum LIKE '%" + Date + "%'";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi koi se na repertoar vo teatarot koj e daden kako vlezen argument")]
    public DataSet findByTheater(string Theater)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Teatar=@theater";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@theater", Theater);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }

    [WebMethod(Description = "Vraka DataSet od imeto na pretstavata koja e zadadena kako vlezen argument")]
    public DataSet findByName(string Ime)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        string sqlString = "SELECT * FROM Repertoar WHERE Ime=@ime";
        SqlCommand komanda = new SqlCommand(sqlString, konekcija);
        komanda.Parameters.AddWithValue("@ime", Ime);
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Repertoar");
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }
}
