<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_Dist_WONo_Time.aspx.cs" Inherits="Module_Accounts_Transactions_Budgtet_Dist_WONo_Time" Theme ="Default"  %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ERP</title>    
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>    
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
    <div>
<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" >
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" ><strong>&nbsp;Work Order</strong>
                        </td>
                    </tr>           
             
                 <tr>
            <td  height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3"                     
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged2" 
                     >
                   <%-- <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1"  Enabled="false">Enquiry No</asp:ListItem>
                     <asp:ListItem Value="2" Enabled="false">PO No</asp:ListItem>
                         <asp:ListItem Value="3">WO No</asp:ListItem>
                </asp:DropDownList>
            
                 <asp:TextBox ID="txtSearchCustomer" runat="server"   Visible="false" Width="100px" 
                    CssClass="box3"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchValue" runat="server" 
                    CssClass="box3" Width="350px"></asp:TextBox>
                      <cc1:autocompleteextender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:autocompleteextender> 
                       <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        &nbsp;<asp:Button ID="btnExport" runat="server" CssClass="redbox" 
                    onclick="btnExport_Click" Text="Export" />
              &nbsp;<input id="Button1" type="button" value="Cancel"  class="redbox" onclick="javascript:parent.location='Menu.aspx?ModId=14&SubModId='" />
           
                </td>
                        
             </tr>

             <tr>
            <td>
            <asp:Panel ID="Panel1" runat="server" Height="360px" ScrollBars="Auto" CssClass="fontcss">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataKeyNames="WONo" RowStyle-HorizontalAlign ="Center"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    PageSize="17" CssClass="yui-datatable-theme" >
            
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
                </asp:TemplateField>
                                <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                <ItemStyle HorizontalAlign="center" Width="7%" />
                                </asp:BoundField>
                                  <asp:BoundField HeaderText="Customer Name" DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" >
                                  <ItemStyle HorizontalAlign="center" Width="6%" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No"  Visible="false">
                                 <ItemStyle HorizontalAlign="center" Width="8%" />
                                  </asp:BoundField>
                                  
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" >
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                  </asp:BoundField>
                                                                  
                                  <asp:HyperLinkField DataNavigateUrlFields="WONo" 
                    HeaderText="WO No" 
                    DataNavigateUrlFormatString="~/Module/MIS/Transactions/Budget_WONo_Time.aspx?WONo={0}&amp;ModId=14" 
                    DataTextField="WONo"  >
                                      <ItemStyle Width="8%" />
                </asp:HyperLinkField>
                
                 <asp:BoundField DataField="TaskProjectTitle" HeaderText="Project Title"  >
                            
                                      <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" >
                                 <ItemStyle HorizontalAlign="center" Width="8%" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By"  Visible="false">
                            
                                      <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                            
            </Columns>
        </asp:GridView>

                 <asp:HiddenField ID="hfSort" runat="server" Value=" " />                     
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <asp:HiddenField ID="hfSearchText" runat="server" />
              </asp:Panel>
            </td>
             </tr>
              </table>
            </td>
        </tr>
        
        </table>    
    </div>
    </form>
</body>
</html>

