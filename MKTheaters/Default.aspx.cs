﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        readUsers();
    }

   public void readUsers()
    {
        List<User> users = SqlConnection.getUsers();
        foreach(User u in users)
        {
            ListBox1.Items.Add(u.ToString());
        }
    }
    
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}