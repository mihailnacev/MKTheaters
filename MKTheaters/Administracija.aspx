<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administracija.aspx.cs" ClientIDMode="Static" Inherits="Administracija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetAdministracija.css" rel="stylesheet" />
    <style>

        .buttons1 {
    color: rgb(245,222,95);
    background-color: #BA252A;
    width: 150px;
    font-weight: bold;
    height: 30px;
    margin-left:89%;
   
    font-size: 15px;
}
        .buttons2 {
    color: rgb(245,222,95);
    background-color: #BA252A;
    width: 150px;
    font-weight: bold;
    height: 30px;
   margin-left:37%;
    font-size: 15px;
}
                .buttons3 {
    color: rgb(245,222,95);
    background-color: #BA252A;
    width: 150px;
    font-weight: bold;
    height: 30px;
   
    font-size: 15px;
}
        #tabela4 {


    background-color:white;
    padding:5px;
    text-align:left;
    border:10px solid #F0CB01;
    width:25%;
    border-top-right-radius:30px;
    border-top-left-radius:30px;
    margin-left:35%;


}

.labeli {
    color: #BA252A;
    font-weight: bold;
}

    </style>
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

    <asp:MultiView ID="mvPrvPanel" runat="server">

        <asp:View ID="View1" runat="server">

            <asp:Label runat="server" ID="lblAR" CssClass="info" Text="Репертоар"></asp:Label>


              <asp:GridView ID="gvAllPlays" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvAllPlays_PageIndexChanging" PageSize="7" OnRowCancelingEdit="gvAllPlays_RowCancelingEdit" OnRowEditing="gvAllPlays_RowEditing" OnRowUpdating="gvAllPlays_RowUpdating" OnRowDeleting="gvAllPlays_RowDeleting" Visible="True">
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

        
  <asp:Button ID="btnAddPlay" runat="server" Text="Додади претстава" CssClass="buttons1" OnClick="btnAddPlay_Click" />
          

        </asp:View>

        <asp:View ID="View2" runat="server">

            <table class="auto-style1" id="tabela4">
        <tr>
            <td>
            <asp:Label ID="lblIme" runat="server" Text="Име" CssClass="labeli"></asp:Label></td>
            <td><asp:TextBox ID="txtIme" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAvtor" runat="server" CssClass="labeli" Text="Автор"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAvtor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReziser" runat="server" CssClass="labeli" Text="Режисер"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReziser" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAkteri" runat="server" CssClass="labeli" Text="Актери"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAkteri" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTeatar" runat="server" CssClass="labeli" Text="Театар"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTeatar" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGrad" runat="server" CssClass="labeli" Text="Град"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtGrad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDatum" runat="server" CssClass="labeli" Text="Датум"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDatum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVreme" runat="server" CssClass="labeli" Text="Времетраење"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVreme" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

            <asp:Button ID="btnDodadi" runat="server" Text="Вметни" CssClass="buttons2" OnClick="btnDodadi_Click" />
            <asp:Button ID="btnNazad" runat="server" Text="<<" CssClass="buttons3" OnClick="btnNazad_Click" />

        </asp:View>




    </asp:MultiView>



    

 

</asp:Panel>

<asp:Panel ID="pnlPR" CssClass="pnlPR" runat="server">

<asp:Label runat="server" ID="lblOR" CssClass="info" Text="Остварени резервации" Visible="False"></asp:Label>
    <br />

<asp:GridView ID="gvSeeReservations" runat="server" >


</asp:GridView>

</asp:Panel>



    </asp:panel>

</asp:Content>

