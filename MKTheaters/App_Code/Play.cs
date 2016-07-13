using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Class which represents single play of theater
/// </summary>
[Serializable]
public class Play
{
    public string Ime;
    public string Avtor;
    public string Reziser;
    public string Teatar;
    public string Grad;
    public DateTime Date;
    public int Duration;
    public List<string> Akteri;

	public Play()
	{
        Ime = null;
        Avtor = null;
        Reziser = null;
        Teatar = null;
        Grad = null;
        Date = DateTime.MinValue;
        Duration = 0;
        Akteri = null;
	}

    public Play(string ime, string avtor, string reziser, string teatar, string grad, string date, string duration, string akteri)
    {
        Ime = ime;
        Avtor = avtor;
        Reziser = reziser;
        Teatar = teatar;
        Grad = grad;
        Date = DateTime.Parse(date);
        Duration = Convert.ToInt32(duration);
        Akteri = new List<string>();
        string []parts=akteri.Split(';');
        foreach (string s in parts)
        {
            Akteri.Add(s);
        }
    }
}