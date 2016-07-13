using System;
using System.Collections.Generic;
using System.Configuration;
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
    public theatersService () 
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() 
    {
        return "Hello World";
    }

    [WebMethod]
    public List<Play> findByCity(string City)
    {
        List<Play> pretstavi = new List<Play>();

        return pretstavi;
    }

    [WebMethod]
    public List<Play> findByDirector(string Director)
    {
        List<Play> pretstavi = new List<Play>();

        return pretstavi;
    }

    [WebMethod]
    public List<Play> findByAuthor(string Author)
    {
        List<Play> pretstavi = new List<Play>();

        return pretstavi;
    }

    [WebMethod]
    public List<Play> findByActor(string Actor)
    {
        List<Play> pretstavi = new List<Play>();

        return pretstavi;
    }

    [WebMethod]
    public List<Play> findByDate(DateTime date)
    {
        List<Play> pretstavi = new List<Play>();

        return pretstavi;
    }

    [WebMethod]
    public List<Play> findByTheater(string Theater)
    {
        List<Play> pretstavi = new List<Play>();

        return pretstavi;
    }
}
