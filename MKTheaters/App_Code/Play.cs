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
    //public DateTime Datum;
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
        //Datum = DateTime.ParseExact(datum, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        Datumi = datum;
        Vremetraenje = vremetraenje;
        Akteri = akteri;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        /*sb.Append(String.Format("<i><b>{0}</b></i><br/>Автор: ", Ime));
        for (int i = 0; i < Avtori.Count; i++)
        {
            sb.Append(Avtori[i]);
            if (i != Avtori.Count - 1)
            {
                sb.Append(", ");
            }
            else
            {
                sb.Append("<br/>Актери: ");
            }
        }
        for (int i = 0; i < Akteri.Count; i++)
        {
            sb.Append(Akteri[i]);
            if (i != Akteri.Count - 1)
            {
                sb.Append(", ");
            }
            else
            {
                sb.Append("<br/>");
            }
        }
        sb.Append(String.Format("Режисер: {0}&nbsp;&nbsp;&nbsp;&nbsp;Театар: {1}&nbsp;&nbsp;&nbsp;&nbsp;Град: {2}<br/>", Reziser, Teatar, Grad));
        sb.Append(String.Format("Датум: {0}&nbsp;&nbsp;&nbsp;&nbsp;Час: {1}", Datum.ToShortDateString(), Datum.ToShortTimeString()));*/
        //sb.Append(String.Format("{0} {1} {2}", Ime, Datum.ToShortDateString(), Datum.ToShortTimeString()));
        return sb.ToString();
    }
}