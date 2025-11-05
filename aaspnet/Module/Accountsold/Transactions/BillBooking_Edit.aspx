<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillBooking_Edit.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_Edit" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 25px;
        }
    </style>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
  <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite">
                <b>&nbsp;Bill Booking - Edit</b></td>
        </tr>
         <tr>
            <td class="style3">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <%-- <asp:ListItem Value="0">Select</asp:ListItem>--%>
                        <asp:ListItem Value="1">Supplier Name</asp:ListItem>
                          <asp:ListItem Value="2">PVEVNo</asp:ListItem>
                          <asp:ListItem Value="3"> PO No  </asp:ListItem>
                       
                </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
                 <asp:TextBox ID="Txtfield" runat="server" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />
                           
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplier" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                           
            </td>            
        </tr>
  
        <tr>       
            <td align="left">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" AllowPaging="True" 
                    Width="900px" onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1  %>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="10pt" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                        </asp:TemplateField>
                
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fin Year Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFinId" runat="Server" Text='<%#Eval("FinYearId")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fin Year">
                            <ItemTemplate>
                                <asp:Label ID="lblFin" runat="Server" Text='<%#Eval("FinYear")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>                     
                    
                        
                          <asp:HyperLinkField HeaderText="PEVE No" DataNavigateUrlFields="Id" 
                            DataNavigateUrlFormatString="~/Module/Accounts/Transactions/BillBooking_Edit_Details.aspx?Id={0}&ModId=11&SubModId=62" 
                            DataTextField="PVEVNo" >                        
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:HyperLinkField>
                        
                          <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblpvevdate" runat="Server" Text='<%#Eval("PVEVDate")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>                      
                      
                       <asp:TemplateField HeaderText="Bill No">
                            <ItemTemplate>
                                <asp:Label ID="lblBillNo" runat="Server" Text='<%#Eval("BillNo")%>' />
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bill Date">
                        <ItemTemplate>
                                <asp:Label ID="lblBillDate" runat="Server" Text='<%#Eval("BillDate")%>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                      
                        
                        <asp:TemplateField HeaderText="Name of Supplier">
                            <ItemTemplate>
                                <asp:Label ID="lblsupp" runat="Server" Text='<%#Eval("Supplier")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Justify" Width="40%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sup Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblsupId" runat="Server" Text='<%#Eval("SupId")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>                        
                      
<%--                         
                        <asp:TemplateField >
                        <ItemTemplate>
                        <asp:LinkButton ID="lnkButton" Text="Select" runat="server" CommandName="Sel" ValidationGroup="A" >
                        </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                    
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

