using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
[Serializable]
public class User
{
    public string Username;
    public string Password;
    public string Ime;
    public string Prezime;
    public string Email;
    public string Admin;

    public User()
    {
        Username = null;
        Password = null;
        Ime = null;
        Prezime = null;
        Email = null;
        Admin = "False";
    }

    public User(string ime, string prezime, string username, string password, string email, string admin)
    {
        Ime = ime;
        Prezime = prezime;
        Username = username;
        Password = password;
        Email = email;
        Admin = admin;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}, {2} {3},{4}", Ime, Prezime, Username, Password, Email);
    }
}