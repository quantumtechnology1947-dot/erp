<%@ page language="C#" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustEnquiry_Convert, newerp_deploy" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link id="Link1" href="~/Css/StyleSheet.css" rel="stylesheet" type="text/css" runat="server" />
    <link type="text/css" href="../../../css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
    <form id="form1" runat="server">
   
    <table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
     
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" class="box3">
                    <tr>
                        <td style="background:url(../../../images/hdbg.JPG); height:21px" class="fontcsswhite" >&nbsp;<b>Enquiry Convert to Customer</b>
                        </td>
                    </tr>
                    <tr>
           <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                </asp:DropDownList>
            
               <asp:TextBox ID="txtEnqId" runat="server"      CssClass="box3"
                    Width="150px"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                      <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                       
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>                    

             <tr>
            <td>
            
        <asp:GridView ID="SearchGridView1"  runat="server" PageSize="17" AutoGenerateColumns="False" 
                    DataKeyNames="EnqId" Width="100%"  OnPageIndexChanging="SearchGridView1_PageIndexChanging"
            AllowSorting="True"  
                    CssClass="yui-datatable-theme" 
                    onrowdatabound="SearchGridView1_RowDataBound" >
            <Columns>
            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>            
                <asp:TemplateField HeaderText="CK">
                <ItemTemplate>
                <asp:CheckBox ID="chkStatus" runat="server"   
                    AutoPostBack="true" OnCheckedChanged="chkStatus_OnCheckedChanged"
                    Checked='<%# Convert.ToBoolean(Eval("Flag")) %>'
                    Text='<%# Eval("Flag").ToString().Equals("True") ? "" : "" %>' />
                </ItemTemplate>
                    <ItemStyle Width="1px" HorizontalAlign="Center" />
                </asp:TemplateField>
               
                <asp:BoundField DataField="EnqId" HeaderText="Enq No" >                   
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name"  />
                <asp:BoundField DataField="SysDate" HeaderText="Gen Date" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EmployeeName" HeaderText="Gen By" >
                    <ItemStyle Width="30%" />
                </asp:BoundField>
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
    <HeaderStyle Height="20" />
          
</asp:GridView>
            
            </td>
             </tr>

             <tr>
            <td>
            
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
            
            </td>
             </tr>
                           </table>
            </td>
        </tr>
        
</table>
    
    </form>
</body>
</html>
