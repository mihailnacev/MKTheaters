using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string summary = (string)Request.QueryString["status"];
            lblSummary.Text = summary;
            User prenesen = (User)Session["Najaven"];
          //  if (prenesen != null) lblSummary.Text += " " + prenesen.Ime;
        }
    }
}