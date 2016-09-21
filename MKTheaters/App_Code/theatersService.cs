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

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(Description = "Vraka DataSet od pretstavi koi se na repertoar vo gradot koj e vlezen argument")]
    public DataSet findByCity(string City)
    {
        // List<Play> pretstavi = new List<Play>();
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
            /*SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string listOfDates = citac[6].ToString();
                string[] dates = listOfDates.Split(';');
                foreach (string s in dates)
                {
                    Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                        citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                    pretstavi.Add(tmp);
                }
            }*/
            //citac.Close();
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
        //List<Play> pretstavi = new List<Play>();
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
            /*SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string listOfDates = citac[6].ToString();
                string[] dates = listOfDates.Split(';');
                foreach (string s in dates)
                {
                    Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                        citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                    pretstavi.Add(tmp);
                }
            }
            citac.Close();*/
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
        //List<Play> pretstavi = new List<Play>();
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
            /*SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string listOfDates = citac[6].ToString();
                string[] dates = listOfDates.Split(';');
                foreach (string s in dates)
                {
                    Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                        citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                    pretstavi.Add(tmp);
                }
            }
            citac.Close();*/
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
        // List<Play> pretstavi = new List<Play>();
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
            /*SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string listOfDates = citac[6].ToString();
                string[] dates = listOfDates.Split(';');
                foreach (string s in dates)
                {
                    Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                        citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                    pretstavi.Add(tmp);
                }
            }
            citac.Close();*/
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
        // List<Play> pretstavi = new List<Play>();
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
            /* SqlDataReader citac = komanda.ExecuteReader();
             while (citac.Read())
             {
                 string listOfDates = citac[6].ToString();
                 string[] dates = listOfDates.Split(';');
                 foreach (string s in dates)
                 {
                     if (s.IndexOf(Date) != -1)
                     {
                         Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                             citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                         pretstavi.Add(tmp);
                     }
                 }
             }
             citac.Close();*/
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
        // List<Play> pretstavi = new List<Play>();
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
            /*SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string listOfDates = citac[6].ToString();
                string[] dates = listOfDates.Split(';');
                foreach (string s in dates)
                {
                    Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                        citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                    pretstavi.Add(tmp);
                }
            }
            citac.Close();*/
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
        //List<Play> pretstavi = new List<Play>();
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
            /*SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string listOfDates = citac[6].ToString();
                string[] dates = listOfDates.Split(';');
                foreach (string s in dates)
                {
                    Play tmp = new Play(citac[0].ToString(), citac[1].ToString(), citac[2].ToString(), citac[4].ToString(),
                        citac[5].ToString(), s, citac[7].ToString(), citac[3].ToString());
                    pretstavi.Add(tmp);
                }
            }
            citac.Close();*/
        }
        finally
        {
            konekcija.Close();
        }
        return ds;
    }
}
