<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UspesnaNajava.aspx.cs" Inherits="UspesnaNajava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="Styles/StyleSheetDefault.css" rel="stylesheet" />
       <script src="Scripts/jquery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
    <asp:Label ID="Label1" runat="server" CssClass="label" Text="Успешно се најавивте!"></asp:Label>
     <br />
    <asp:Button ID="btnGoToMyProfile" runat="server" CssClass="button" Text="Мој профил" OnClick="btnGoToMyProfile_Click" />
</asp:Content>

