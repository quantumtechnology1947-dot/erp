<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_MaterialForecasting, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" /> 
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
                style="background:url(../../../images/hdbg.JPG)" colspan="2">&nbsp;<b>Material Forecasting</b></td>
                    </tr>                    
                    <tr>
                        <td height="25">
                       &nbsp; <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>&nbsp; <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" ID="DropDownList_Trans">
                                <asp:ListItem Text="Open Transaction" Value="1" ></asp:ListItem>
                                <asp:ListItem Text="Close Transaction" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Both Transaction" Value="3"></asp:ListItem>
                                </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList2"  runat="server"><asp:ListItem Text="Bought Out Items"  Value="1"/><asp:ListItem Text="Manufacturing Items"  Value="2"/></asp:DropDownList>&nbsp;<asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                AutoPostBack="True" onselectedindexchanged="drpfield_SelectedIndexChanged">
                                <asp:ListItem Value="0">Customer</asp:ListItem>
                                <asp:ListItem Value="1">WO No</asp:ListItem>
                                <asp:ListItem Value="2">Project Title</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" CssClass="box3"  Width="250px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                            &nbsp;<asp:TextBox ID="txtPONo" runat="server" Visible="False" CssClass="box3" 
                                Width="250px"></asp:TextBox>
                        &nbsp;<asp:CheckBox ID="SelectAll" runat="server" Text="Select All Work Order"  AutoPostBack="True" 
                                oncheckedchanged="SelectAll_CheckedChanged" />&nbsp;
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" onclick="Button1_Click" />  &nbsp;                   </td>
                     
                    </tr>
                    
                    <tr>
                        <td colspan="2">                       
                            <asp:Panel ID="Panel1" runat="server" Height="422px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server"  
                                    AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="WOId"  Width="98%">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN" >
                            <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WOId" SortExpression="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblWOId" runat="server" Text='<%#Eval("WOId") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WO No"  >
                            <ItemTemplate>
                                <asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>

                    
                    
                        <asp:TemplateField HeaderText="Project Title" >
                            <ItemTemplate>
                                <asp:Label ID="lblProjectTitle" runat="server" Text='<%#Eval("ProjectTitle") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
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
                
                
               </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
            <td align="center" height="25px" valign="middle">
                <asp:Button ID="btnPrint" runat="server" CssClass="redbox" Text="Proceed" 
                    onclick="btnPrint_Click" />
              </td>
        </tr>
    </table> 
                
  
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

