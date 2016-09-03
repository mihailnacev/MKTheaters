<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pocetna.aspx.cs" ClientIDMode="Static" Inherits="Pocetna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/StyleSheetPocetna.css" type="text/css" rel="stylesheet" />
    <link href="Styles/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/ScriptPocetna.js" type="text/javascript"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
   <style type="text/css">
      #lvP
      {
        background-color:white;
    padding:30px;
    margin:auto;
    margin-top:10px;
    width:40%;
    border-radius:20px;
    border:20px solid #F0CB01;  
      }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Main" runat="server">
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                <li data-target="#carousel-example-generic" data-slide-to="4"></li>
            </ol>
            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="Images/1.png" alt="..." class="img-responsive"/>
                    <div class="carousel-caption">
      	                <h3>Caption Text</h3>
                    </div>
                </div>
                <div class="item">
                    <img src="Images/2.jpg" alt="..." class="img-responsive"/>
                    <div class="carousel-caption">
      	                <h3>Caption Text</h3>
                    </div>
                </div>
                <div class="item">
                    <img src="Images/3.jpg" alt="..." class="img-responsive"/>
                    <div class="carousel-caption">
      	                <h3>Caption Text</h3>
                    </div>
                </div>
                <div class="item">
                    <img src="Images/4.jpg" alt="..." class="img-responsive"/>
                    <div class="carousel-caption">
      	                <h3>Caption Text</h3>
                    </div>
                </div>
                <div class="item">
                    <img src="Images/5.jpg" alt="..." class="img-responsive"/>
                    <div class="carousel-caption">
      	                <h3>Caption Text</h3>
                    </div>
                </div>
            </div>
            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left arrows"><</span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right arrows">></span>
            </a>
        </div> 
    </asp:Panel>
    
    <asp:ListView ID="lvPlays" runat="server" GroupPlaceholderID="groupPlaceHolder1"
   ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
<LayoutTemplate>
    <table ID="lvP" cellpadding="0" cellspacing="0">
        <tr>
            <th>
                Претстава &nbsp;
            </th>
            <th>
                Автор &nbsp;
            </th>
            <th>
                Режисер &nbsp;
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <tr>
            <td colspan = "3">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvPlays" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
    </tr>
</GroupTemplate>
<ItemTemplate>
    <td>
        <%# Eval("Ime") %> &nbsp;
    </td>
    <td>
        <%# Eval("Avtor") %> &nbsp;
    </td>
    <td>
        <%# Eval("Reziser") %> &nbsp;
    </td>
</ItemTemplate>
</asp:ListView>

</asp:Content>

