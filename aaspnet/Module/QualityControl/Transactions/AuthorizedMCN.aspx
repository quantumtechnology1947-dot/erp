<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_AuthorizedMCN, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
   <style type="text/css">
        .style2
        {
            width: 100%;
            height: 335px;
        }
    </style>
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
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">&nbsp;<b>Authorize [MCN]</b></td>
                    </tr>
                    
                    <tr>
                        <td height="25">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                AutoPostBack="True" onselectedindexchanged="drpfield_SelectedIndexChanged">
                                <asp:ListItem Value="1">WO No</asp:ListItem>
                                <asp:ListItem Value="0">Customer</asp:ListItem>                                
                                <asp:ListItem Value="2">Project Title</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" CssClass="box3" Visible="False"   Width="250px"></asp:TextBox>

                            <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>

                            &nbsp;<asp:TextBox ID="txtPONo" runat="server" CssClass="box3" 
                                Width="100px"></asp:TextBox>
                            &nbsp; 
                                                <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" onclick="Button1_Click" />
                        </td>
                     
                    </tr>
                    
                    <tr>
                        <td colspan="2">                       
                         
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="WOId"  Width="100%" AllowPaging="True" 
                                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="23" 
                                onrowcommand="GridView1_RowCommand">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN" >
                            <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="WOId" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblWOId" runat="server" Text='<%#Eval("WOId") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WO No"  >
                            <ItemTemplate>                            
                                <asp:LinkButton ID="lbtnWONo" runat="server" CommandName="sel" Text ='<%#Eval("WONo") %>'></asp:LinkButton>                              
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Date"  >
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                  
                        <asp:TemplateField HeaderText="Project Title" >
                            <ItemTemplate>
                                <asp:Label ID="lblProjectTitle" runat="server" Text='<%#Eval("ProjectTitle") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Customer Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Code" >
                            <ItemTemplate>
                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
      
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="fontcss" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Names="Calibri" 
                                        ForeColor="red" Text="No  data found to display"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <FooterStyle Wrap="True" />
                </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
          </table> 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

