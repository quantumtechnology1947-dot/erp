<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillBooking_ItemGrid.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_ItemGrid" Theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>   
    <style type="text/css">
        .yui-datatable-theme
        {
            margin-bottom: 11px;
        }
        .style1
        {
            width: 100%;
            float: left;
        }
        </style>
     <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
</head>
<body style="margin: 0px 0px 0px 0px;">

    <form id="form1" runat="server">
    <div>     
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="370px" 
            onactivetabchanged="TabContainer1_ActiveTabChanged" ActiveTabIndex="0">
    
       <%----------------------------------------GQN------------------------------------%> 
       
    <cc1:TabPanel runat="server"  ID="TabPanel1">
    <HeaderTemplate> 

 
&nbsp;GQN 
         
        
        </HeaderTemplate>                        
        
    
<ContentTemplate>
                  
                       <table align="left" cellpadding="0" cellspacing="0" class="style1">
                           <tr>
                               <td height="25">
                                   <span lang="en-us">&nbsp;</span><asp:DropDownList ID="DropSearchBy" 
                                       runat="server" AutoPostBack="True" 
                                       onselectedindexchanged="DropSearchBy_SelectedIndexChanged">
                                       <asp:ListItem Value="0">Search By</asp:ListItem>
                                       <asp:ListItem Value="1">DC No</asp:ListItem>
                                       <asp:ListItem Value="2">GQN No</asp:ListItem>
                                       <asp:ListItem Value="3">PO No</asp:ListItem>
                                       <asp:ListItem Value="4">Item Code</asp:ListItem>
                                       <asp:ListItem Value="5">Description</asp:ListItem>
                                       <asp:ListItem Value="6">AC Head</asp:ListItem>
                                   </asp:DropDownList>
                                   <span lang="en-us">&nbsp;</span><asp:TextBox ID="txtSearchValue" runat="server" 
                                       CssClass="box3" Visible="False"></asp:TextBox>
                                   <asp:DropDownList ID="DropACHeadGqn" runat="server" Visible="False">
                                   </asp:DropDownList>
                                   <span lang="en-us">&nbsp;</span><asp:Button ID="btnGQNSearch" runat="server" 
                                       CssClass="redbox" Text="Search" onclick="btnGQNSearch_Click" />
                               </td>
                           </tr>
                           <tr>
                               <td>
                                <asp:Panel ID="Panel1" runat="server" Height="330px" ScrollBars="Auto">
                                   <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                       CssClass="yui-datatable-theme" OnRowCommand="GridView2_RowCommand" 
                                        Width="100%" 
                                        onpageindexchanging="GridView2_PageIndexChanging">
                                       <Columns>
                                           <asp:TemplateField HeaderText="SN">
                                               <ItemTemplate>
                                                   <%#Container.DataItemIndex+1%>
                                               </ItemTemplate>
                                               <HeaderStyle Font-Size="10pt" />
                                               <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                           </asp:TemplateField>
                                           <asp:TemplateField>
                                               <ItemTemplate>
                                                   <asp:LinkButton ID="lnkButton" runat="server" CommandName="sel" Text="Select">
                                                   </asp:LinkButton>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="4%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Fin Year">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYrs") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="6%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="PO No">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Date">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="5%" />
                                           </asp:TemplateField>
                                           
                                  <asp:TemplateField HeaderText="A/C Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblACHead" runat="server" Text='<%# Eval("ACHead") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                                           
                                           <asp:TemplateField HeaderText="GQN No">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblgqnno" runat="server" Text='<%# Eval("GQNNo") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="4%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="DC No">
                                               <ItemTemplate>
                                                   <asp:Label ID="lbldcno" runat="server" Text='<%# Eval("ChallanNo") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="4%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="DC Date">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblDCDate" runat="server" Text='<%# Eval("ChallanDate") %>'></asp:Label>
                                                </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="5%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Item Code">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Left" Width="7%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Description">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblPurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle Width="20%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="UOM">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblUOMPurch" runat="server" Text='<%# Eval("UOMPurch") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Center" Width="3%" />
                                           </asp:TemplateField>
                                         
                                           <asp:TemplateField HeaderText="Qty">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblpoqty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" Width="5%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Rate">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblporate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" Width="6%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Dis.%">
                                               <ItemTemplate>
                                                   <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" Width="4%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Amt.">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblpoamt" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" Width="7%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Acpt. Qty">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblAcptQty" runat="server" Text='<%# Eval("AcceptedQty") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" Width="5%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="GQN Amt.">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblGQNAmt" runat="server" Text='<%# Eval("GQNAmt") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" Width="7%" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="GQNId" Visible="False">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblgqnId" runat="server" Text='<%# Eval("GQNId") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" />
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Id" Visible="False">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblPoId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right" />
                                           </asp:TemplateField>
                                           
                                            
                              <asp:TemplateField HeaderText="ACId" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblACId" runat="server" Text='<%# Eval("ACId") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            
                                       </Columns>
                                       <EmptyDataTemplate>
                                           <table class="fontcss" width="100%">
                                               <tr>
                                                   <td align="center">
                                                       <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                           Text="No data to display !"> </asp:Label>
                                                   </td>
                                               </tr>
                                           </table>
                                       </EmptyDataTemplate>
                                       <FooterStyle Wrap="True" />
                                       <PagerSettings PageButtonCount="40" />
                                   </asp:GridView>
                                   </asp:Panel>
                               </td>
                           </tr>                          
                           <tr>
                               <td align="right">
                                   <asp:Label ID="lblTotal" runat="server"  Text="Total GQN Amount : " 
                      style="font-weight: 700"></asp:Label><asp:Label ID="lblGqnTotal" runat="server" style="font-weight: 700"></asp:Label></td>
                           </tr>
                       </table>
        
        </ContentTemplate>                        
        
    
</cc1:TabPanel>  
        
        
        
      <%----------------------------------------GSN------------------------------------%>       
        
        
    <cc1:TabPanel runat="server" ID="TabPanel2">
    <HeaderTemplate> 
 GSN  
        </HeaderTemplate>                        
    
<ContentTemplate>
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="25">
            <span lang="en-us">&nbsp;</span><asp:DropDownList ID="DropSearchByGSN" 
                    runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropSearchByGSN_SelectedIndexChanged">
                                       <asp:ListItem Value="0">Search By</asp:ListItem>
                                       <asp:ListItem Value="1">DC No</asp:ListItem>
                                       <asp:ListItem Value="2">GSN No</asp:ListItem>
                                       <asp:ListItem Value="3">PO No</asp:ListItem>
                                       <asp:ListItem Value="4">Item Code</asp:ListItem>
                                       <asp:ListItem Value="5">Description</asp:ListItem>
                                       <asp:ListItem Value="6">AC Head</asp:ListItem>
                                   </asp:DropDownList>
                                   <span lang="en-us">&nbsp;</span><asp:TextBox ID="txtSearchValueGSN" runat="server" 
                                       CssClass="box3" Visible="False"></asp:TextBox>
                                      <asp:DropDownList ID="DropACHeadGsn" runat="server" Visible="False">
                                   </asp:DropDownList>
                                    <span lang="en-us">&nbsp;</span><asp:Button ID="btnGQNSearchGSN" runat="server" 
                                       CssClass="redbox" Text="Search" onclick="btnGSNSearch_Click" />   
                
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="330px" ScrollBars="Auto">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CssClass="yui-datatable-theme" OnRowCommand="GridView1_RowCommand" 
                        Width="100%" 
                        onpageindexchanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>  
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" /> 
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkButton0" runat="server" CommandName="sel" Text="Select">
                                    </asp:LinkButton> 
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fin Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblFinYear1" runat="server" Text='<%# Eval("FinYrs1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPONo1" runat="server" Text='<%# Eval("PONo1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate1" runat="server" Text='<%# Eval("Date1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:TemplateField>
                            
                               <asp:TemplateField HeaderText="A/C Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblACHead0" runat="server" Text='<%# Eval("ACHead1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="GSN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblgsnno" runat="server" Text='<%# Eval("GSNNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DC No">
                                <ItemTemplate>
                                    <asp:Label ID="lbldcno0" runat="server" Text='<%# Eval("ChallanNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DC Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDCDate0" runat="server" Text='<%# Eval("ChallanDate") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemCode0" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchDesc0" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" /> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM">
                                <ItemTemplate>
                                    <asp:Label ID="lblUOMPurch0" runat="server" Text='<%# Eval("UOMPurch") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="PO Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblpoqty0" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblporate0" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dis.%">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiscount0" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="4%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Amt.">
                                <ItemTemplate>
                                    <asp:Label ID="lblpoamt0" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acpt. Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblAcptQty0" runat="server" Text='<%# Eval("ReceivedQty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSN Amt.">
                                <ItemTemplate>
                                    <asp:Label ID="lblGSNAmt" runat="server" Text='<%# Eval("GSNAmt") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GSNId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblgsnId" runat="server" Text='<%# Eval("GSNId") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="ACId1" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblACId1" runat="server" Text='<%# Eval("ACId1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="fontcss" width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                            Text="No data to display !"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <FooterStyle Wrap="True" />
                        <PagerSettings PageButtonCount="40" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td align="right" height="25" valign="middle"><b>
                <span class="style2" lang="en-us">Total GSN Amount: </span>
                <asp:Label ID="lblGSNTotal" runat="server"></asp:Label>
                </b>
            </td>
        </tr>
    </table>
    
        
        </ContentTemplate>                        
    
</cc1:TabPanel>
        
    </cc1:TabContainer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    
       
    </form>
</body>
</html>
