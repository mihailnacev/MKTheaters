<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registracija.aspx.cs" ClientIDMode="Static" Inherits="Registracija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/StyleSheetRegistracija.css" rel="stylesheet" />
    <link href="Styles/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="Styles/font-awesome-animation.min.css" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/ScriptRegistracija.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 25px;
            text-align: right;
        }

        .auto-style3 {
            text-align: center;
            height: 23px;
        }

        .auto-style4 {
            color: darkred;
            background-color: #ce9393;
            border-radius: 8px;
            padding: 5px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPodnesi">
        <table class="auto-style1" id="tabela">
            <tr>
                <td colspan="2" class="auto-style3">
                    <asp:Label ID="lblRegistracija" CssClass="registracija" runat="server" Text="Регистрација"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblIme" CssClass="labeli" runat="server" Text="Име*"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" CssClass="textFields" runat="server" TabIndex="1" placeholder="Внесете име"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblPrezime" CssClass="labeli" runat="server" Text="Презиме*"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" CssClass="textFields" runat="server" TabIndex="2" placeholder="Внесете презиме"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblEmail" CssClass="labeli" runat="server" Text="E-mail*"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textFields" runat="server" TabIndex="3" placeholder="Внесете e-mail адреса"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" CssClass="validationText" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ToolTip="Неправилен формат на е-mail адреса"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblUsername" CssClass="labeli" runat="server" Text="Корисничко име*"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" CssClass="textFields" runat="server" TabIndex="4" placeholder="Внесете корисничко име"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revUsername" CssClass="validationText" runat="server" ControlToValidate="txtUsername" ErrorMessage="*" ValidationExpression="[A-Za-z]*" ToolTip="Корисничкото име треба да биде составено само од букви"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblPassword" CssClass="labeli" runat="server" Text="Лозинка*"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="textFields" runat="server" TextMode="Password" TabIndex="5" placeholder="Внесете лозинка"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPassword" CssClass="validationText" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ValidationExpression=".*[0-9]+.*" ToolTip="Лозинката треба да содржи барем еден број"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblConfirmPassword" CssClass="labeli" runat="server" Text="Потврди лозинка*"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="textFields" runat="server" TextMode="Password" TabIndex="6" placeholder="Потврдете ја лозинката"></asp:TextBox>
                    <asp:CompareValidator ID="cvConfirmPassword" CssClass="validationText" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="*" ToolTip="Лозинките не се совпаѓаат"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnPodnesi" runat="server" CssClass="buttons faa-vertical animated-hover" OnClick="btnPodnesi_Click" Text="Регистрирај се" TabIndex="7" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="statusContainer" runat="server" CssClass="auto-style4" Visible="false">
                        <asp:Image ID="errorImage" runat="server" ImageUrl="~/Images/error-icon-25266.png" Width="40px" Height="40px" />
                        <asp:Label ID="lblMsg" CssClass="validationText" runat="server" Text="Сите полиња се задолжителни"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblOr" CssClass="or" runat="server" Text="Веќе имате отворено сметка?"></asp:Label>
                    <asp:LinkButton ID="btnLogin" runat="server" Text="Најави се" OnClick="btnLogin_Click" TabIndex="8" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

