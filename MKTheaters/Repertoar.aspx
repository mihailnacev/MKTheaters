<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Repertoar.aspx.cs" ClientIDMode="Static" Inherits="Repertoar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/StyleSheetRepertoar.css" rel="stylesheet"/>
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
                
        .auto-style5 {
            color: rgb(245,222,95);
            font-weight: bold;
            font-size: 15px;
            /*margin-left: 62px;*/
            background-color: #BA252A;
        }
                
        .auto-style7 {
            width: 276px;
            height: 46px;
        }

        #tabela 
{
    background-color:white;
    padding:30px;
    margin:auto;
    margin-top:10px;
    margin-bottom:10px;
    width:40%;
    border-radius:20px;
    border:20px solid #F0CB01;
}

.labeli 
{
    color:#BA252A;
    font-weight:bold;
    font-size:larger;
}

.buttons 
{
    color:rgb(245,222,95);
    background-color:#BA252A;
    width:150px;
    font-weight:bold;
    height:30px;
    margin-left:20px;
    font-size:15px;
}

#Panel2 
{
    margin-right: 5%;
    margin-bottom: 10px;
    float: right;
    width: 90%;
    text-align: right;
}

#dvPretstavi{
     background-color:white;
    padding:30px;
    margin:auto;
    margin-top:10px;
    width:40%;
    border-radius:20px;
    border:20px solid #F0CB01;
}
        .auto-style9 {
            color: rgb(245,222,95);
            font-weight: bold;
            font-size: 15px;
            margin-left: 0px;
            background-color: #BA252A;
        }
        .auto-style10 {
            width: 276px;
            height: 59px;
        }
        .auto-style11 {
            height: 59px;
        }
        .auto-style12 {
            width: 276px;
            height: 55px;
        }
        .auto-style13 {
            height: 55px;
        }
        .auto-style14 {
            height: 46px;
        }
        .auto-style15 {
            height: 54px;
        }
        .auto-style16 {
            color: rgb(245,222,95);
            font-weight: bold;
            font-size: 15px;
            margin-left: 44px;
            background-color: #BA252A;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
 
    
    <asp:Panel ID="pnlSearch" runat="server">
   <asp:MultiView ID="mvSearch" runat="server">
       <asp:View ID="View1" runat="server">
            <asp:Panel runat="server" ID="Panel2">
                <asp:Button ID="btnPrebarajPretstava" runat="server" CssClass="auto-style5" OnClick="btnPrebarajPretstava_Click" Text="Пребарај претстава ..." Width="223px" Height="38px" />
            </asp:Panel>
       </asp:View>
       <asp:View ID="View2" runat="server">
           <asp:Panel ID="pnlView2" runat="server">
           <table id="tabela">
               <tr>
                   <td colspan="2" class="auto-style15">
                       <asp:Label ID="Label8" runat="server" CssClass="labeli">Изберете критериум за пребарување</asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style7">
                       <asp:DropDownList ID="ddlKriterium" runat="server" Height="35px" Width="278px" OnSelectedIndexChanged="ddlKriterium_SelectedIndexChanged">
                           <asp:ListItem>- Default -</asp:ListItem>
                           <asp:ListItem>Град</asp:ListItem>
                           <asp:ListItem>Режисер</asp:ListItem>
                           <asp:ListItem>Автор</asp:ListItem>
                           <asp:ListItem>Актер</asp:ListItem>
                           <asp:ListItem>Театар</asp:ListItem>
                           <asp:ListItem>Датум</asp:ListItem>
                       </asp:DropDownList>
                   </td>
                   <td class="auto-style14"></td>
               </tr>
               <tr>
                   <td class="auto-style12">
                       <asp:TextBox ID="tbKluc" runat="server" Width="272px" Height="35px"></asp:TextBox>
                   </td>
                   <td class="auto-style13">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbKluc" ErrorMessage="* Полето е задолжително!" Font-Bold="True" ForeColor="#BA252A"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style10">
                       <asp:Button ID="btnNazad" runat="server" CssClass="auto-style9" OnClick="btnNazad_Click" Text="&lt;&lt;&lt;" Width="268px" Height="50px" CausesValidation="False" />
                   </td>
                   <td class="auto-style11">
                       <asp:Button ID="btnPreb" runat="server" CssClass="auto-style16" Text="Пребарај" Width="268px" OnClick="btnPreb_Click" Height="51px" />
                   </td>
               </tr>
           </table>
               </asp:Panel>
       </asp:View>
       <asp:View ID="View3" runat="server">
           <asp:DetailsView ID="dvPretstavi" runat="server" Height="50px" Width="40%" AllowPaging="True" OnPageIndexChanging="dvPretstavi_PageIndexChanging" BorderColor="#F0CB01" BorderStyle="Solid" BorderWidth="5px" CellPadding="6" AutoGenerateRows="False" CellSpacing="2" DataKeyNames="Ime" OnItemCommand="dvPretstavi_ItemCommand">
               <EmptyDataRowStyle BackColor="Red" BorderColor="#FFCC00" BorderWidth="5px" />
               <Fields>
                   <asp:ButtonField CommandName="select" DataTextField="Ime" HeaderText="Претстава" Text="Button">
                   <ControlStyle Font-Size="Large" />
                   <ItemStyle Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                   </asp:ButtonField>
                   <asp:BoundField DataField="Avtor" HeaderText="Автор" />
                   <asp:BoundField DataField="Reziser" HeaderText="Режисер" />
                   <asp:BoundField DataField="Akteri" HeaderText="Актери" />
                   <asp:BoundField DataField="Teatar" HeaderText="Театар" />
                   <asp:BoundField DataField="Grad" HeaderText="Град" />
                   <asp:BoundField DataField="Vremetraenje" HeaderText="Времетраење" />
               </Fields>
               <PagerStyle BackColor="Orange" Font-Bold="True" ForeColor="Maroon" HorizontalAlign="Center" VerticalAlign="Middle" />
               <RowStyle BackColor="#BA252A" Font-Bold="True" ForeColor="#F0CB01" HorizontalAlign="Left" VerticalAlign="Middle" />
           </asp:DetailsView>
       </asp:View>
   </asp:MultiView>
    </asp:Panel> 
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
        <RowStyle BackColor="#BA252A" ForeColor="#F0CB01" HorizontalAlign="Center" 
                    VerticalAlign="Middle" 
                    Font-Names="'Franklin Gothic Medium','Arial Narrow',Arial,sans-serif" 
                    Font-Size="Large" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    </ContentTemplate> 
    </asp:UpdatePanel>  
 
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style2" Height="148px" Width="305px">
       
         <asp:Label ID="Label4" runat="server" Text="Дали сакате да ја резервирате избраната претстава?"></asp:Label>
         <br />
         <br />
         <br />
         <br />
         &nbsp;
         <asp:Button ID="OK" runat="server" OnClick="OK_Click" Text="Да" Width="98px" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Cancel" runat="server" CssClass="auto-style1" Text="Не" Width="98px" />
         <br />
         &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>

</asp:Content>