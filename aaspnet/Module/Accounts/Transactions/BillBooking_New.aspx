<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillBooking_New.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_New" Title="ERP" Theme="Default" %>
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
                <b>&nbsp;Bill Booking - New</b></td>
        </tr>
         <tr>
            <td class="style3">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                   <%--  <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                        <asp:ListItem Value="0">Supplier Name</asp:ListItem>
                       
                </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
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
                    Width="800px" onrowcommand="GridView2_RowCommand"  PageSize="17"
                    onpageindexchanging="GridView2_PageIndexChanging">
                    <PagerSettings PageButtonCount="40" />
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
                        
                        <asp:TemplateField HeaderText="Name of Supplier">
                            <ItemTemplate>
                                <asp:Label ID="lblsupp" runat="Server" Text='<%#Eval("Supplier")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Justify" Width="40%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code">
                            <ItemTemplate>
                                <asp:Label ID="lblsupId" runat="Server" Text='<%#Eval("SupId")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>                        
                     
                        <asp:TemplateField HeaderText="Freight">
                        <ItemTemplate>
                        <asp:TextBox ID="txtFreight" runat="server" Text="0" Width="70" CssClass="box3"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" 
                        ControlToValidate="txtFreight" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator
                        ID="ReqFreight" runat="server" ErrorMessage="*" ValidationGroup="A" ControlToValidate="txtFreight">
                        </asp:RequiredFieldValidator>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField> 
                                               
                        <asp:TemplateField >
                        <ItemTemplate>
                        <asp:DropDownList ID="ddlMhOms" runat="server" onselectedindexchanged="ddlMhOms_SelectedIndexChanged" >
                          <asp:ListItem Value="Select">Select</asp:ListItem>
                          <asp:ListItem Value="0">MH</asp:ListItem>
                          <asp:ListItem Value="1">OMS</asp:ListItem>
                            </asp:DropDownList> 
                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>


                        <asp:TemplateField >
                        <ItemTemplate>
                        <asp:LinkButton ID="lnkButton" Text="Select" runat="server" CommandName="Sel" ValidationGroup="A" >
                        </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
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

