<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Repertoar.aspx.cs" Inherits="Repertoar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetRepertoar.css" rel="stylesheet" />
    <style type="text/css">
.modalBackground{
    background-color:black;
    filter:alpha(opacity=90);
    opacity:0.8;
}
.modalPopUp{
    background-color:#FFFFFF;
    border-width: 3px;
    border-style:solid;
    border-bottom-color:black;
    padding-top:10px;
    padding-left:10px;
    width:300px;
    height:140px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
 
    <asp:UpdatePanel ID="main" runat="server"> 
        <ContentTemplate>
            <asp:GridView ID="gvPretstavi" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0CB01" BorderStyle="Solid" BorderWidth="5px" CellPadding="4"  Font-Bold="False" Width="95%" AllowPaging="True" OnPageIndexChanging="gvPretstavi_PageIndexChanging" OnRowDataBound="gvPretstavi_RowDataBound" OnRowCommand="gvPretstavi_RowCommand">
            <Columns>
            <asp:BoundField DataField="Ime" HeaderText="Претстава" />
            <asp:BoundField DataField="Avtor" HeaderText="Автор" />
            <asp:BoundField DataField="Reziser" HeaderText="Режисер" />
            <asp:BoundField DataField="Akteri" HeaderText="Актери" />
            <asp:BoundField DataField="Teatar" HeaderText="Театар" />
            <asp:BoundField DataField="Grad" HeaderText="Град" />
            <asp:BoundField DataField="Vremetraenje" HeaderText="Времетраење" />
            <asp:TemplateField>
            <ItemTemplate>
            <asp:Button ID="Button1" runat="server" style="Display:none;" Text="Button" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" runat="server" />
            <asp:LinkButton ID="LinkButton1" CommandName="Popup" runat="server">Резервирај</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <EditRowStyle Font-Bold="False" Font-Names="Agency FB" Font-Size="Large" />
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#BA252A" Font-Bold="True" ForeColor="#FFFFCC" HorizontalAlign="Center" VerticalAlign="Middle" />
        <PagerStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="#330099" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
        <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    </ContentTemplate> 
    </asp:UpdatePanel>  
     <asp:Panel ID="Panel1" runat="server" CssClass="modalPopUp">
        Welcome!!!
        <br />
        <br />
     <asp:Button ID="OK" runat="server" Text="Button" />
    </asp:Panel>

</asp:Content>