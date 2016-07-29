<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Try.aspx.cs" Inherits="Try" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="gvProben" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Ime" HeaderText="Name" />
            <asp:BoundField DataField="Avtor" HeaderText="Author" />
        </Columns>
    </asp:GridView>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />




</asp:Content>

