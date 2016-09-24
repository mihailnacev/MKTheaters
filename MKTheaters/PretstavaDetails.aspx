<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PretstavaDetails.aspx.cs" ClientIDMode="Static" Inherits="PretstavaDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/StyleSheetPretstavaDetails.css" rel="stylesheet"/>
    <link rel="stylesheet" href="Styles/font-awesome-animation.min.css" />
    <link href="Styles/jquery-ui.css" type="text/css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="Scripts/ScriptPretstavaDetails.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 67%;
        }
        .auto-style12 {
            height: 50px;
        }
        .auto-style13 {
            width: 30%;
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
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="uspeshnaRez" runat="server" Visible="false">Ви благодариме за резервацијата. Претставата е успешно резервирана. Дојдете најмалку 15 минути пред почетокот на претставата за да ги подигнете билетите.</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Label ID="lblIme" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label5" runat="server" Text="Автор:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblAvtor" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label6" runat="server" Text="Режисер:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblReziser" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label7" runat="server" Text="Актери:" CssClass="labeli"></asp:Label>
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
                <asp:Label ID="Label9" runat="server" Text="Времетраење:" CssClass="labeli"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblVremetraenje" runat="server" CssClass="results" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label10" runat="server" CssClass="labeli" Text="Датум и време:"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlDatumi" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label11" runat="server" CssClass="labeli" Text="Просечна оценка:"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="lblProsechnaOcenka" CssClass="results faa-parent animated-hover" Text="" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style12">
                <asp:Button ID="btnShowModal" runat="server" CssClass="auto-style14 faa-flash animated-hover faa-slow" Height="45px" Width="247px" Text="Резервирај билет" OnClientClick="return false" />
                <asp:Button ID="btnRezerviraj" runat="server" CssClass="auto-style14 faa-flash animated-hover faa-slow" Height="45px" OnClick="btnRezerviraj_Click" Text="Резервирај" Width="247px" />   
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="modal" title="Резервираj претстава" runat="server">
        <asp:Label ID="ime" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lbltermin" runat="server" Text="Термин: "></asp:Label>
        <asp:TextBox ID="termin" runat="server" Enabled="false"></asp:TextBox>    
    </asp:Panel>
</asp:Content>

