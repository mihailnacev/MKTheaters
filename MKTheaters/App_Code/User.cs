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

    public User(string username,string password,string ime,string prezime,string email)
    {
       Username=username;
       Password=password;
       Ime=ime;
       Prezime=prezime;
       Email = email;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}, {2} {3},{4}", Ime, Prezime, Username, Password,Email);
    }
}