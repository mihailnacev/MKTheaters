<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Najava.aspx.cs" ClientIDMode="Static" Inherits="Najava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/StyleSheetNajava.css" rel="stylesheet" />
    <link href="Styles/jquery-ui.css" type="text/css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/ScriptNajava.js" type="text/javascript"></script>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        /*width: 213px;*/
    }
    .auto-style3 {
        height: 25px;
        text-align: right;
    }
    .auto-style4 {
        color: darkred;
        background-color: #ce9393;
        border-radius: 8px;
        padding: 5px;
        text-align: center;
    }
    .auto-style5 {
        height: 23px;
        text-align: center;
    }
    .auto-style6 {
        height: 23px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
<asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
    <table class="auto-style1" id="tabela"  >
    <tr>
        <td class="auto-style5" colspan="2">
            <asp:Label ID="lblNajava" runat="server" CssClass="najava" Text="Најава"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2" colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="lblUsername" runat="server" CssClass="labeli" Text="Корисничко име*"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="textFields"   ValidationGroup="najava" TabIndex="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" CssClass="validationText" ControlToValidate="txtUsername" ErrorMessage="*" ValidationGroup="najava" TabIndex="1" ToolTip="Внесете го вашето корисничко име"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="lblLozinka" runat="server" CssClass="labeli" Text="Лозинка*"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLozinka" runat="server" CssClass="textFields"  ValidationGroup="najava" TextMode="Password" TabIndex="2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" CssClass="validationText" runat="server" ControlToValidate="txtLozinka" ErrorMessage="*" ValidationGroup="najava" TabIndex="2" ToolTip="Внесете ја вашата лозинка"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style2">
            <asp:Button ID="btnLogin" runat="server" Text="Најави се" CssClass="buttons" ValidationGroup="najava" OnClick="btnLogin_Click" TabIndex="3" />
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="statusContainer" runat="server" CssClass="auto-style4" Visible="false">
                <asp:Image ID="errorImage" runat="server" ImageUrl="~/Images/error-icon-25266.png" Width="40px" Height="40px"/>
                <asp:Label ID="LogInStatus" runat="server" ForeColor="#BA252A" Text="LogInStatus"></asp:Label> &nbsp;
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2" colspan="2">
            <asp:Label ID="lblOr" CssClass="or"  runat="server" Text="Немате отворено сметка?" TabIndex="4"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2" colspan="2">
            <asp:Button ID="btnRegister" runat="server" CssClass="buttons" Text="Регистрирај се" OnClick="btnRegister_Click" TabIndex="5" />
        </td>
    </tr>
    </table>
</asp:Panel>
</asp:Content>

