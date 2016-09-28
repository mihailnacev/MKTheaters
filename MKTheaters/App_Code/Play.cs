using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;

/// <summary>
/// Class which represents single play of theater
/// </summary>
[Serializable]
public class Play
{
    public string Ime;
    public string Avtori;
    public string Reziser;
    public string Teatar;
    public string Grad;
    public List<string> Datumi;
    public string Vremetraenje;
    public string Akteri;

    public Play()
    {
        Ime = null;
        Avtori = null;
        Reziser = null;
        Teatar = null;
        Grad = null;
        Datumi = null;
        Vremetraenje = null;
        Akteri = null;
    }

    public Play(string ime, string avtori, string reziser, string teatar, string grad, List<string> datum, string vremetraenje, string akteri)
    {
        Ime = ime;
        Avtori = avtori;
        Reziser = reziser;
        Teatar = teatar;
        Grad = grad;
        Datumi = datum;
        Vremetraenje = vremetraenje;
        Akteri = akteri;
    }
}