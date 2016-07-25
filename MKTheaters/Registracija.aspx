<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registracija.aspx.cs" ClientIDMode="Static" Inherits="Registracija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="Styles/StyleSheetRegistracija.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
      <style type="text/css">
          .auto-style1 {
              width: 100%;
          }
          .auto-style2 {
              width: 216px;
          }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="Panel1" runat="server" DefaultButton="btnPodnesi">
    <table class="auto-style1" id="tabela">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblRegistracija"  CssClass="registracija" runat="server" Text="Регистрација"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblIme" CssClass="labeli"  runat="server" Text="Име*"></asp:Label>
            </td>
            <td>
&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtFirstName" CssClass="textFields" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblPrezime" CssClass="labeli" runat="server" Text="Презиме*"></asp:Label>
            </td>
            <td>
&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtLastName" CssClass="textFields" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblEmail" CssClass="labeli" runat="server" Text="E-mail адреса*"></asp:Label>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtEmail" CssClass="textFields" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revEmail" CssClass="validationText" runat="server" ControlToValidate="txtEmail" ErrorMessage="Неправилен формат на е-mail адреса" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblUsername" CssClass="labeli" runat="server" Text="Корисничко име*"></asp:Label>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtUsername" CssClass="textFields" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revUsername" CssClass="validationText" runat="server" ControlToValidate="txtUsername" ErrorMessage="Корисничкото име треба да биде составено само од букви" ValidationExpression="[A-Za-z]*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblPassword" CssClass="labeli" runat="server" Text="Лозинка*"></asp:Label>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtPassword" CssClass="textFields" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revPassword" CssClass="validationText" runat="server" ControlToValidate="txtPassword" ErrorMessage="Лозинката треба да содржи барем еден број" ValidationExpression=".*[0-9]+.*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblConfirmPassword" CssClass="labeli" runat="server" Text="Потврди лозинка*"></asp:Label>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="txtConfirmPassword" CssClass="textFields" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="cvConfirmPassword" CssClass="validationText" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Лозинките не се совпаѓаат"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Label ID="lblMsg" CssClass="validationText" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnPodnesi" runat="server" CssClass="buttons" OnClick="btnPodnesi_Click" Text="Поднеси" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>

