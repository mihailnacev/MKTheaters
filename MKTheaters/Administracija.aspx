<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administracija.aspx.cs" Inherits="Administracija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetAdministracija.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/ScriptMyProfile.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:panel ID="Panel2" runat="server">

<asp:Panel ID="NavigationButtons" runat="server">

<asp:Button runat="server" ID="btnAR" Text="Ажурирај репертоар" CssClass="options" OnClick="btnAR_Click" ></asp:Button>

<asp:Button runat="server" ID="btnPR" Text="Погледни резервации" CssClass="options" OnClick="btnPR_Click"  ></asp:Button>

</asp:Panel>

<asp:Panel ID="pnlAR" CssClass="pnlAR" runat="server" Visible="False">

<asp:Label runat="server" ID="lblAR" CssClass="info" Text="Репертоар"></asp:Label>

    

    <asp:GridView ID="gvAllPlays" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvAllPlays_PageIndexChanging" PageSize="7" OnRowCancelingEdit="gvAllPlays_RowCancelingEdit" OnRowEditing="gvAllPlays_RowEditing" OnRowUpdating="gvAllPlays_RowUpdating" OnRowDeleting="gvAllPlays_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Ime" HeaderText="Претстава" ReadOnly="True" />
            <asp:BoundField DataField="Avtor" HeaderText="Автор" />
            <asp:BoundField DataField="Reziser" HeaderText="Режисер" />
            <asp:BoundField DataField="Akteri" HeaderText="Актери" />
            <asp:BoundField DataField="Teatar" HeaderText="Театар" />
            <asp:BoundField DataField="Grad" HeaderText="Град" />
            <asp:BoundField HeaderText="Датум" DataField="Datum" />
            <asp:BoundField DataField="Vremetraenje" HeaderText="Времетраење" />
            <asp:CommandField />
            <asp:CommandField CancelText="Откажи" EditText="Уреди" ShowEditButton="True" UpdateText="Измени" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

</asp:Panel>

<asp:Panel ID="pnlPR" CssClass="pnlPR" runat="server">

<asp:Label runat="server" ID="lblOR" CssClass="info" Text="Остварени резервации" Visible="False"></asp:Label>
    <br />

<asp:GridView ID="gvSeeReservations" runat="server"></asp:GridView>

</asp:Panel>



    </asp:panel>

</asp:Content>

