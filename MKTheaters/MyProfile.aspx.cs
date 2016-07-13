using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlMyProfile.Visible = true;

    }

    protected void btnReservations_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlReservations.Visible = true;
    }

    protected void btnSuggestions_Click(object sender, EventArgs e)
    {
        pnlMyProfile.Visible = false;
        pnlReservations.Visible = false;
        pnlSuggest.Visible = false;
        pnlSuggest.Visible = true;
    }
}