<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListBox ID="ListBox1" runat="server" Height="65px" Width="308px"></asp:ListBox>
    <br />
    <asp:Label ID="lblRegistracija" runat="server" Text="Успешно се регистриравте!"></asp:Label>
</asp:Content>

