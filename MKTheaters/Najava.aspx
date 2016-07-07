<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Najava.aspx.cs" Inherits="Najava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetNajava.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 213px;
    }
    .auto-style3 {
        width: 213px;
        height: 25px;
    }
    .auto-style4 {
        height: 25px;
    }
    .auto-style5 {
        width: 213px;
        height: 23px;
    }
    .auto-style6 {
        height: 23px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

    <table class="auto-style1" id="tabela"  >
    <tr>
        <td class="auto-style5">
            <asp:Label ID="lblNajava" runat="server" CssClass="najava" Text="Најава"></asp:Label>
        </td>
        <td class="auto-style6"></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="lblUsername" runat="server" CssClass="labeli" Text="Корисничко име*"></asp:Label>
        </td>
        <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="textFields"   ValidationGroup="najava"></asp:TextBox>
        </td>
        <td class="auto-style4">
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" CssClass="validationText" ControlToValidate="txtUsername" ErrorMessage="Полето е задолжително " ValidationGroup="najava"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="lblLozinka" runat="server" CssClass="labeli" Text="Лозинка*"></asp:Label>
        </td>
        <td class="auto-style6">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:TextBox ID="txtLozinka" runat="server" CssClass="textFields"  ValidationGroup="najava" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvPassword" CssClass="validationText" runat="server" ControlToValidate="txtLozinka" ErrorMessage="Полето е задолжително " ValidationGroup="najava"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btnLogin" runat="server" Text="Најави се" CssClass="buttons" ValidationGroup="najava" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
        </td>
        <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lblOr" CssClass="or"  runat="server" Text="Немате отворено сметка?"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btnRegister" runat="server" CssClass="buttons" Text="Регистрирај се" OnClick="btnRegister_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
   

</asp:Content>

