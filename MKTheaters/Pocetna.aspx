<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pocetna.aspx.cs" ClientIDMode="Static" Inherits="Pocetna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/StyleSheetPocetna.css" type="text/css" rel="stylesheet" />
    <link href="Styles/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/ScriptPocetna.js" type="text/javascript"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
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
</asp:Content>

