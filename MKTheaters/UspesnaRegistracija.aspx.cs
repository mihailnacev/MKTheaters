﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGoToNajava_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Najava.aspx");
    }
}