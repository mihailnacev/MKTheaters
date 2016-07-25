<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Repertoar.aspx.cs" ClientIDMode="Static" Inherits="Repertoar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Styles/StyleSheetRepertoar.css" rel="stylesheet" />
    <style type="text/css">
.modalBackground{
    background-color:black;
    filter:alpha(opacity=90);
    opacity:0.5;
}
.modalPopUp{
    background-color:#FFFFFF;
    border-width: 3px;
    border-style:solid;
    border-bottom-color:black;
    padding-top:10px;
    padding-left:10px;
    width:300px;
    height:120px;
}
        .auto-style1 {
            margin-left: 0px;
        }
        .auto-style2 {
            border-bottom: 3px solid black;
            background-color: #FFFFFF;
            padding-top: 10px;
            padding-left: 10px;
            border-left-style: solid;
            border-left-width: 3px;
            border-right-style: solid;
            border-right-width: 3px;
            border-top-style: solid;
            border-top-width: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- 
    <asp:Label ID="Label5" runat="server" Text="Изберете критериум за пребарување"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="0">Изберете критериум</asp:ListItem>
        <asp:ListItem Value="1">Град</asp:ListItem>
        <asp:ListItem Value="2">Режисер</asp:ListItem>
        <asp:ListItem Value="3">Автор</asp:ListItem>
        <asp:ListItem Value="4">Актер</asp:ListItem>
        <asp:ListItem Value="5">Датум</asp:ListItem>
        <asp:ListItem Value="6">Театар</asp:ListItem>
   </asp:DropDownList>
    <br />
    <asp:Label ID="lbl1" runat="server" Text="Изберете град" Visible="false"></asp:Label>
    <asp:Label ID="lbl2" runat="server" Text="Изберете режисер" Visible="false"></asp:Label>
    <asp:Label ID="lbl3" runat="server" Text="Изберете автор" Visible="false"></asp:Label>
    <asp:Label ID="lbl4" runat="server" Text="Изберете актер" Visible="false"></asp:Label>
    <asp:Label ID="lbl5" runat="server" Text="Изберете датум" Visible="false"></asp:Label>
    <asp:Label ID="lbl6" runat="server" Text="Изберете театар" Visible="false"></asp:Label>
    <br />
    <asp:Button runat="server" ID="btnPrebaraj" OnClick="btnPrebaraj_Click" Text="Пребарај" />
    -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
 
    
 
    <asp:UpdatePanel ID="main" runat="server"> 
        <ContentTemplate>
            <asp:GridView ID="gvPretstavi" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#F0CB01" BorderStyle="Solid" BorderWidth="5px" CellPadding="4"  Font-Bold="False" Width="95%" AllowPaging="True" OnPageIndexChanging="gvPretstavi_PageIndexChanging" OnRowDataBound="gvPretstavi_RowDataBound" OnRowCommand="gvPretstavi_RowCommand" DataKeyNames="Ime" OnSelectedIndexChanged="gvPretstavi_SelectedIndexChanged" ForeColor="Red" OnRowCreated="gvPretstavi_RowCreated">

            <Columns>
                <asp:ButtonField CommandName="select" DataTextField="Ime" Text="Button" HeaderText="Претстава" />
            <asp:BoundField DataField="Avtor" HeaderText="Автор" />
            <asp:BoundField DataField="Reziser" HeaderText="Режисер" />
            <asp:BoundField DataField="Akteri" HeaderText="Актери" />
            <asp:BoundField DataField="Teatar" HeaderText="Театар" />
            <asp:BoundField DataField="Grad" HeaderText="Град" />
            <asp:BoundField DataField="Vremetraenje" HeaderText="Времетраење" />
            
            <asp:TemplateField HeaderText="Датум">
                 <ItemTemplate>
                <asp:DropDownList ID="ddlDatumi" runat="server">
                </asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField>
            <ItemTemplate>
            <asp:Button ID="Button1" runat="server" style="Display:none;" Text="Button" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" runat="server" />
            <asp:LinkButton ID="LinkButton1" CommandName="Popup" runat="server">Резервирај</asp:LinkButton>
            </ItemTemplate>
                <ControlStyle ForeColor="White" />
            </asp:TemplateField>
                
        </Columns>
        <EditRowStyle Font-Bold="False" Font-Names="Agency FB" Font-Size="X-Large" BorderStyle="None" CssClass="Redica" ForeColor="#FF5050" />
        <FooterStyle BackColor="#BA252A" ForeColor="#BA252A" />
        <HeaderStyle BackColor="#BA252A" Font-Bold="True" ForeColor="#FFFFCC" HorizontalAlign="Center" VerticalAlign="Middle" />
        <PagerStyle BackColor="Orange" Font-Bold="True" ForeColor="Maroon" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
        <RowStyle BackColor="#BA252A" ForeColor="#F0CB01" HorizontalAlign="Center" VerticalAlign="Middle" Font-Names="'Franklin Gothic Medium','Arial Narrow',Arial,sans-serif" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    </ContentTemplate> 
    </asp:UpdatePanel>  
    <br />
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <br /> 
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style2" Height="148px" Width="305px">
       
         <asp:Label ID="Label4" runat="server" Text="Дали сакате да ја резервирате избраната претстава?"></asp:Label>
         <br />
         <br />
         <br />
         <br />
         <br />
         &nbsp;&nbsp;&nbsp;
         <asp:Button ID="OK" runat="server" OnClick="OK_Click" Text="Да" Width="98px" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Cancel" runat="server" CssClass="auto-style1" OnClick="Cancel_Click" Text="Не" Width="98px" />
    </asp:Panel>

</asp:Content>