using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public string Username;
    public string Password;
    public string Ime;
    public string Prezime;

    public User(string username,string password,string ime,string prezime)
    {
       Username=username;
       Password=password;
       Ime=ime;
       Prezime=prezime;

    }

    override
    public String ToString()
    {
        return Ime + " " + Prezime;
    }
}