using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracija : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAR_Click(object sender, EventArgs e)
    {
        pnlAR.Visible = true;
        pnlPR.Visible = false;
    }

    protected void btnPR_Click(object sender, EventArgs e)
    {
        pnlPR.Visible = true;
        pnlAR.Visible = false;
    }
}