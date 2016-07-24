<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PretstavaDetails.aspx.cs" Inherits="PretstavaDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/StyleSheetPretstavaDetails.css" rel="stylesheet"/>
    <style type="text/css">
        .auto-style1 {
            width: 67%;
        }
        .auto-style12 {
            height: 50px;
        }
        .auto-style13 {
            width: 605px;
            height: 50px;
        }
        .auto-style14 {
            color: rgb(245,222,95);
            background-color: #BA252A;
            font-weight: bold;
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="main" runat="server">
        
    <table class="auto-style1" id="tabela">
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label4" runat="server" Text="Име на претставата:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblIme" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label5" runat="server" Text="Автор на претставата:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblAvtor" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label6" runat="server" Text="Режисер на претставата:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblReziser" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label7" runat="server" Text="Актери кои учествуваат во претставата:" CssClass="labeli"></asp:Label>
                <br/>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblAkteri" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label8" runat="server" Text="Театар и град:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblTeatarGrad" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label9" runat="server" Text="Времетраење на претставата:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblVremetraenje" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13"></td>
            <td class="auto-style12">
                <asp:Button ID="btnRezerviraj" runat="server" Text="Резервирај билет" Width="247px" Height="45px" CssClass="auto-style14" OnClick="btnRezerviraj_Click" />
            </td>
        </tr>
    </table>
        </asp:Panel>
</asp:Content>

