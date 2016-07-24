<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetMyProfile.css" type="text/css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/ScriptMyProfile.js" type="text/javascript"></script>
     <style type="text/css">
         .auto-style1 {
             width: 100%;
         }
         .auto-style2 {
             width: 187px;
         }
         .auto-style3 {
             width: 187px;
             height: 26px;
         }
         .auto-style7 {
             width: 173px;
         }
         .auto-style8 {
             width: 173px;
             height: 26px;
         }
         .auto-style9 {
             width: 157px;
         }
         .auto-style10 {
             width: 157px;
             height: 26px;
         }
         .auto-style11 {
             width: 134px;
         }
         .auto-style12 {
             width: 134px;
             height: 26px;
         }
     /*    .auto-style13 {
             background-color: blue;
             margin-top: -200px;
             margin-left: 500px;
             border-radius: 30px;
         } */
         .auto-style13 {
             width: 19px;
         }
     </style>
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
  <br />
    <br />
    <asp:Button ID="btnHome" runat="server" CssClass="options" Text="Мој профил" OnClick="btnHome_Click" />
  <br />
     <br />
     
   

    <asp:Button ID="btnReservations" runat="server" CssClass="options"  Text="Остварени резервации" OnClick="btnReservations_Click" />
       <br />
     <br />
    
     
        <asp:Button ID="btnSuggestions" runat="server" CssClass="options"  Text="Предложи" OnClick="btnSuggestions_Click" />
        
    
    <asp:Panel ID="pnlMyProfile" CssClass="myProfilePanel" runat="server">
        <table class="auto-style1" id="tabela">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblInfo" runat="server" CssClass="info" Text="Информации"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblFirstName" runat="server" CssClass="labeli" Text="Име"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblFirstNameText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblLastName" runat="server" CssClass="labeli" Text="Презиме"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblLastNameText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblEmail" runat="server" CssClass="labeli" Text="Е-mail"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblEmailText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblUsername" runat="server" CssClass="labeli" Text="Корисничко име"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblUsernameText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
        </table>

         <table class="auto-style1" id="tabela2">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" CssClass="info" Text="Како ви се допадна изгледаната претстава?"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblName" runat="server" CssClass="labeli" Text="Име на претставата"></asp:Label>
                    &nbsp;</td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblAuthor" runat="server" CssClass="labeli" Text="Автор"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblDate" runat="server" CssClass="labeli" Text="Одиграна на"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblPlace" runat="server" CssClass="labeli" Text="Театар"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" CssClass="labeli" Text="Оценка"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:RadioButtonList ID="rblOceni" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem Selected="True">5</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Button ID="Button1" runat="server" CssClass="buttons" Text="Поднеси" />
                </td>
            </tr>
        </table>

       
        <asp:Image ID="img1" runat="server" ImageUrl="~/Images/VojdanChernodrinskiPrilep.png"  CssClass="images" ToolTip="Театар: Војдан Чернодрински - Прилеп"/>
      
        <asp:Image ID="img2" runat="server" ImageUrl="~/Images/JordanHKXinotVeles.png" CssClass="images" ToolTip="Театар: Јордан Хаџи Константинов Џинот - Велес" />
        
        <asp:Image ID="img3" runat="server" ImageUrl="~/Images/NarodenTeatarKumanovo.png" CssClass="images" ToolTip="Народен театар - Куманово" />
      
    </asp:Panel>

    <asp:Panel ID="pnlReservations" runat="server" CssClass="pnlReservations" Visible="False">

        <asp:Label ID="lblList" runat="server" Text="Листа на остварени резервации" CssClass="infoList" ></asp:Label>
        <br />
        <br />
        <table class="auto-style1">
        <tr>
            <td rowspan="3" class="auto-style13"> <asp:ListBox ID="lbRezervacii" runat="server" CssClass="listbox" Rows="3"></asp:ListBox></td>
            <td>  <asp:Button ID="Button2" runat="server" Text="" CssClass="btnUp" OnClick="btnUp_Click" /></td>
            
        </tr>
        <tr>
            <td> <asp:Button ID="btnDown" runat="server" Text="" CssClass="btnDown" OnClick="btnDown_Click" /></td>
        </tr>
        <tr>
            <td>  <asp:Button ID="Button3" runat="server" CssClass="btnRemove" Text="" /></td>
        </tr>
    </table>
    
        <br />
        <br />
        
        <asp:Image ID="img4" runat="server" ImageUrl="~/Images/TeatarDecaMladinciSkopje.png" CssClass="images4" ToolTip="Театар за деца и млади Скопје" />
        <asp:Image ID="img5" runat="server" ImageUrl="~/Images/mntSkopje.png" CssClass="images5" ToolTip="Македонски народен театар - Скопје" />
        <asp:Image ID="img6" runat="server" ImageUrl="~/Images/DramskiSkopje.png" CssClass="images6"  ToolTip="Драмски театар - Скопје" />
    
    </asp:Panel>

    <asp:Panel ID="pnlSuggest" runat="server" CssClass="pnlSuggest" Visible="false"  >
    </asp:Panel>

    

    </asp:Content>

