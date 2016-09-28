<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" ClientIDMode="Static" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/StyleSheetMyProfile.css" type="text/css" rel="stylesheet" />
    <link href="Styles/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="Styles/font-awesome-animation.min.css" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/ScriptMyProfile.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            margin: auto;
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
            width: 185px;
        }

        .auto-style10 {
            width: 157px;
            height: 26px;
        }

        .auto-style11 {
            width: 134px;
        }

        .auto-style12 {
            width: 160px;
            height: 26px;
        }

        .auto-style13 {
            text-align: center;
        }

        .auto-style13 {
            width: 19px;
        }

        .auto-style14 {
            height: 30px;
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="NavigationPanel" runat="server">
            <asp:Button ID="btnHome" runat="server" CssClass="options" Text="Мој профил" OnClick="btnHome_Click" />
            <br />
            <br />
            <asp:Button ID="btnReservations" runat="server" CssClass="options" Text="Остварени резервации" OnClick="btnReservations_Click" />
            <br />
            <br />
            <asp:Button ID="btnSuggestions" runat="server" CssClass="options" Text="Предложи" OnClick="btnSuggestions_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlMyProfile" CssClass="myProfilePanel" runat="server">
            <asp:Panel ID="Panel3" runat="server">
                <asp:Panel ID="pnlProfile1" CssClass="pnlProfile" runat="server">
                    <table class="auto-style1" id="tabela">
                        <tr>
                            <td colspan="2" class="auto-style13">
                                <asp:Label ID="lblInfo" runat="server" CssClass="info" Text="Информации"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
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
                            <td class="auto-style7">
                                <asp:Label ID="lblFirstName" runat="server" CssClass="labeli" Text="Име"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblFirstNameText" CssClass="Labels" runat="server"></asp:Label>
                                <asp:TextBox ID="txtFirstNameText" CssClass="TextBoxes" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lblLastName" runat="server" CssClass="labeli" Text="Презиме"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblLastNameText" CssClass="Labels" runat="server"></asp:Label>
                                <asp:TextBox ID="txtLastNameText" CssClass="TextBoxes" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lblEmail" runat="server" CssClass="labeli" Text="Е-mail"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblEmailText" CssClass="Labels" runat="server"></asp:Label>
                                <asp:TextBox ID="txtEmailText" CssClass="TextBoxes" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmailText" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#BA252A" ToolTip="Погрешен формат на email адреса" ErrorMessage="*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lblNovaLozinka" runat="server" CssClass="labeli PassTextBoxes" Text="Нова лозинка"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="txtNovaLozinka" CssClass="PassTextBoxes" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revPass" runat="server" ControlToValidate="txtNovaLozinka" ErrorMessage="*" ForeColor="#BA252A" ValidationExpression=".*[0-9]+.*" ToolTip="Лозинката треба да содржи барем една цифра"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lblPotvrdiNovaLozinka" runat="server" CssClass="labeli PassTextBoxes" Text="Потврди нова лозинка"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="txtPotvrdiNovaLozinka" CssClass="PassTextBoxes" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="cvLozinki" runat="server" ControlToCompare="txtNovaLozinka" ControlToValidate="txtPotvrdiNovaLozinka" ErrorMessage="*" ForeColor="#BA252A" ToolTip="Лозинките не се совпаѓаат"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lblTekovnaLozinka" runat="server" CssClass="labeli TextBoxes" Text="Тековна лозинка"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="txtTekovnaLozinka" CssClass="TextBoxes" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="auto-style13">
                                <asp:Label ID="lblError" runat="server" CssClass="labeli"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="auto-style13">
                                <asp:Button ID="btnPromeni" runat="server" CssClass="buttons faa-horizontal animated-hover" Text="Промени" OnClientClick="return false" />
                                <asp:Button ID="btnOtkazi" runat="server" CssClass="buttons faa-horizontal animated-hover" Text="Откажи" OnClientClick="return false" />
                                <asp:Button ID="btnZachuvaj" runat="server" CssClass="buttons faa-horizontal animated-hover" Text="Зачувај" OnClick="btnZachuvaj_Click" />
                                <asp:Button ID="btnPromeniLozinka" runat="server" CssClass="buttons faa-horizontal animated-hover" Text="Промени Лозинка" OnClientClick="return false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlProfile2" CssClass="pnlProfile" runat="server">
                    <table class="auto-style1" id="tabela2">
                        <tr>
                            <td colspan="2" class="auto-style13">
                                <asp:Label ID="Label1" runat="server" CssClass="info" Text="Како ви се допадна изгледаната претстава?"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="auto-style13">
                                <asp:Label ID="Label3" runat="server" CssClass="labeli" Text="Немате претстави за оценување."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPretstava" runat="server" CssClass="labeli" Text="Изберете претстава"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPretstavi" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label4" runat="server" CssClass="labeli" Text="Оценка"></asp:Label>
                            </td>
                            <td class="auto-style12">
                                <asp:Panel ID="rating" runat="server" CssClass="rating">
                                    <asp:Label ID="star10" runat="server" CssClass="star faa-tada animated-hover">☆</asp:Label>
                                    <asp:Label ID="star9" runat="server" CssClass="star faa-tada animated-hover">☆</asp:Label>
                                    <asp:Label ID="star8" runat="server" CssClass="star faa-tada animated-hover">☆</asp:Label>
                                    <asp:Label ID="star7" runat="server" CssClass="star faa-tada animated-hover">☆</asp:Label>
                                    <asp:Label ID="star6" runat="server" CssClass="star faa-tada animated-hover">☆</asp:Label>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7">&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Label ID="lblStatus" runat="server" CssClass="labeli" Text="Label" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11 auto-style13" colspan="2">
                                <asp:Button ID="btnOcena" runat="server" OnClick="btnOcena_Click" Visible="false" />
                                <asp:Button ID="btnOcenaClickable" runat="server" CssClass="buttons faa-horizontal animated-hover" Text="Поднеси" OnClientClick="return false" />
                                <asp:TextBox ID="ocenaHidden" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="imagesPanel1" runat="server">
                <asp:Panel ID="imagesPanel11" CssClass="imagesPanel" runat="server">
                    <asp:Image ID="img1" runat="server" ImageUrl="~/Images/VojdanChernodrinskiPrilep.png" CssClass="images" ToolTip="Театар: Војдан Чернодрински - Прилеп" />
                    <asp:Image ID="img2" runat="server" ImageUrl="~/Images/JordanHKXinotVeles.png" CssClass="images" ToolTip="Театар: Јордан Хаџи Константинов Џинот - Велес" />
                    <asp:Image ID="img3" runat="server" ImageUrl="~/Images/NarodenTeatarKumanovo.png" CssClass="images" ToolTip="Народен театар - Куманово" />
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="pnlReservations" runat="server" CssClass="pnlReservations" Visible="False">
            <asp:Panel ID="Panel2" runat="server">
                <asp:Label ID="lblList" runat="server" Text="Листа на остварени резервации" CssClass="infoList"></asp:Label>
                <br />
                <br />
                <asp:Panel ID="pnlOstvareniRezervaciiEmpty" runat="server">
                    <asp:Label ID="Label5" runat="server" Text="Немате резервирано претстави. Можете да го погледнете репертоарот и да ја резервирате посакуваната претстава."></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlOstvareniRezervacii" runat="server">
                    <table class="auto-style1">
                        <tr>
                            <td rowspan="3" class="auto-style13">
                                <asp:ListBox ID="lbRezervacii" runat="server" CssClass="listbox" Rows="3"></asp:ListBox>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="" CssClass="btnUp" OnClick="btnUp_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDown" runat="server" Text="" CssClass="btnDown" OnClick="btnDown_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnRemove" runat="server" CssClass="btnRemove" Text="" OnClick="btnRemove_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="imagesPanel2" runat="server">
                <asp:Panel ID="imagesPanel22" CssClass="imagesPanel" runat="server">
                    <asp:Image ID="img4" runat="server" ImageUrl="~/Images/TeatarDecaMladinciSkopje.png" CssClass="images" ToolTip="Театар за деца и млади Скопје" />
                    <asp:Image ID="img5" runat="server" ImageUrl="~/Images/mntSkopje.png" CssClass="images" ToolTip="Македонски народен театар - Скопје" />
                    <asp:Image ID="img6" runat="server" ImageUrl="~/Images/DramskiSkopje.png" CssClass="images" ToolTip="Драмски театар - Скопје" />
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="pnlSuggest" runat="server" CssClass="pnlSuggest" Visible="false">
            <asp:Panel ID="Panel4" runat="server">
                <asp:Label ID="lblSuggest" runat="server" CssClass="lblSuggest" Text="Сакате да уживате во театарска претстава што ја нема на репертоарот во посакуваниот град? Предложете ни, а ние ќе се потрудиме да ја задоволиме Вашата желба!" ClientIDMode="Static"></asp:Label>
                <table id="tabela3">
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="labeli" ID="lblTitle" Text="Театарска претстава"></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="labeli" ID="lblAuthorr" Text="Автор"></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAuthorr"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="labeli" ID="lblCity" Text="Град"></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCity"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style14"></td>
                        <td class="auto-style14">
                            <asp:Button runat="server" CssClass="buttons faa-horizontal animated-hover" ID="btnSubmit" Text="Поднеси"></asp:Button></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="imagesPanel3" runat="server">
                <asp:Panel ID="imagesPanel33" CssClass="imagesPanel" runat="server">
                    <asp:Image runat="server" ID="img7" ImageUrl="~/Images/AntonPanovStrumica.png" CssClass="images" ToolTip="Театар: Антон Панов - Струмица"></asp:Image>
                    <asp:Image runat="server" ID="img8" ImageUrl="~/Images/NarodenTeatarShtip.png" CssClass="images" ToolTip="Народен театар - Штип"></asp:Image>
                    <asp:Image runat="server" ID="img9" ImageUrl="~/Images/NarodenTeatarBitola.png" CssClass="images" ToolTip="Народен театар - Битола"></asp:Image>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

