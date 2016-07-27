<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administracija.aspx.cs" Inherits="Administracija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetAdministracija.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/ScriptMyProfile.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:panel ID="Panel2" runat="server">

<asp:Panel ID="NavigationButtons" runat="server">

<asp:Button runat="server" ID="btnAR" Text="Ажурирај репертоар" CssClass="options" OnClick="btnAR_Click" ></asp:Button>
    <br />
<asp:Button runat="server" ID="btnPR" Text="Погледни резервации" CssClass="options" OnClick="btnPR_Click"  ></asp:Button>

</asp:Panel>

<asp:Panel ID="pnlAR" CssClass="pnlAR" runat="server" Visible="False">

<asp:Label runat="server" ID="lblAR" CssClass="info" Text="Репертоар"></asp:Label>

    <asp:GridView ID="gvAllPlays" runat="server"></asp:GridView>

</asp:Panel>

<asp:Panel ID="pnlPR" CssClass="pnlPR" runat="server">

<asp:Label runat="server" ID="lblOR" CssClass="info" Text="Остварени резервации"></asp:Label>
    <br />

<asp:GridView ID="gvSeeReservations" runat="server"></asp:GridView>

</asp:Panel>



    </asp:panel>

</asp:Content>

