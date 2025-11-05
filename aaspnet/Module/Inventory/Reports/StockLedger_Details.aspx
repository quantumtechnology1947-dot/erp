<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_StockLedger_Details, newerp_deploy" title="ERP" theme="Default" culture="en-GB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
  
    <style type="text/css">
       
        .style2
        {
            width: 100%;
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            width: 97%;
        }
        .style6
        {
            width: 1011px;
        }
        .style7
        {
            width: 50px;
        }
        .style8
        {
            width: 144px;            
        }
        .style9
        {
            color: white;
        }
        .style10
        {
            color: #660066;
            font-weight: bold;
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


 <table style="width: 100%" cellpadding="0" cellspacing="0">
         <tr>
            <td align="left" valign="middle" 
                 style="background:url(../../../images/hdbg.JPG)" height="21" 
                 class="style2"><b>&nbsp;<span class="style9">Stock Ledger</span></b></td>
             </tr>
   
    
    <tr>
    <td>
        <table align="left" cellpadding="0" cellspacing="0" class="style5">
            <tr>
                <td height="22">
&nbsp; <b>Item Code</b>&nbsp; : <asp:Label ID="Lblitem" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Unit</b>:
        <asp:Label ID="LblUnit" runat="server"></asp:Label>
                &nbsp;&nbsp; <b>Image</b>:&nbsp;
                    <asp:LinkButton ID="btnlnkImg" runat="server" CommandName="downloadImg" 
                        Font-Bold="True" onclick="btnlnkImg_Click" Text='<%# Bind("FileName") %>' 
                        Visible="true"></asp:LinkButton>
&nbsp;&nbsp;&nbsp; <b>Spec. Sheet</b>:&nbsp;
                    <asp:LinkButton ID="btnlnkSpec" runat="server" CommandName="downloadSpec" 
                        Font-Bold="True" onclick="btnlnkSpec_Click" Text='<%# Bind("AttName") %>' 
                        Visible="true"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td height="22">
&nbsp; <b>Description</b>:&nbsp;<asp:Label ID="LblDesc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="22">
&nbsp; <b>From Date</b> :
        <asp:Label ID="LblFromDate" runat="server"></asp:Label>
        &nbsp;&nbsp; <b>To</b>:
        <asp:Label ID="LblToDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        </td>
    </tr>
    
    
    <tr>
    <td align="left" class="style5">
        <asp:Panel ID="Panel1" ScrollBars="Auto" Height="270px" runat="server">
       
   <asp:GridView ID="GridView1" runat="server"   
                OnPageIndexChanging="GridView1_PageIndexChanging" Width="99%"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                onrowcommand="GridView1_RowCommand" PageSize="14" >
      
                 <PagerSettings PageButtonCount="40" />
      
                 <Columns>
                  <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                                 
                  <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                        <asp:Label ID="LblDate" runat="server" Text='<%# Eval("SysDate") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time">
                        <ItemTemplate>
                        <asp:Label ID="LblTime" runat="server" Text='<%# Eval("SysTime") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Trans. by ">
                        <ItemTemplate>
                        <asp:Label ID="LblEName" runat="server" Text='<%# Eval("EName") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Proc. by ">
                        <ItemTemplate>
                        <asp:Label ID="LblEmp" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="BG Group">
                        <ItemTemplate>
                        <asp:Label ID="Dept" runat="server" Text='<%# Eval("Dept") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                      </asp:TemplateField>
                         <asp:TemplateField HeaderText="WONo">
                        <ItemTemplate>
                        <asp:Label ID="Wo" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                      <asp:TemplateField HeaderText="Trans. For">
                        <ItemTemplate>
                        <asp:Label ID="trnsfor" runat="server" Text='<%# Eval("for") %>'></asp:Label>
                        </ItemTemplate>                        
                          <ItemStyle Width="8%" />
                        </asp:TemplateField>
                        
                        
                          <asp:TemplateField HeaderText="Trans. Of">
                        <ItemTemplate>
                        <asp:Label ID="transof" runat="server" Text='<%# Eval("to") %>'></asp:Label>
                        </ItemTemplate>
                                 <ItemStyle Width="8%" />
                                 </asp:TemplateField>
                                 
                            <asp:TemplateField HeaderText="Sum" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="Sum" runat="server" Text='<%# Eval("Sum") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Rece. Qty">
                        <ItemTemplate>
                        <asp:Label ID="lblAcceptedQty" runat="server" Text='<%# Eval("AcceptedQty") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Issued Qty">
                        <ItemTemplate>
                        <asp:Label ID="lblIssueQty" runat="server" Text='<%# Eval("IssueQty") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Seconds" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblseconds" runat="server" Text='<%# Eval("seconds") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="SortDateTime" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblSortDateTime" runat="server" Text='<%# Eval("SortDateTime") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
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
                 
                 </asp:GridView>
    
     </asp:Panel>
        </td>
    </tr>
    
        
    
    <tr>
    <td align="center" class="style4">
                  &nbsp;</td>
    </tr>
    
        
    
    <tr>
    <td align="center" class="style4">
                  <table align="left" cellpadding="0" cellspacing="0" class="style5">
                      <tr>
                          <td class="style6" height="22">
                              &nbsp;</td>
                          <td align="left">
                  <asp:Label ID="lbl1" runat="server" Text="Opening Qty" 
                                  style="color: #336600; font-weight: 700" />
                          </td>
                          <td class="style7" align="right">
                              <asp:Label ID="lblopeningQty" runat="server" style="font-weight: 700"></asp:Label>
    
    
                          </td>
                      </tr>
                      <tr>
                          <td class="style6" height="22">
                              &nbsp;</td>
                          <td align="left" class="style10">
                              Total&nbsp;Recieved Qty</td>
                          <td class="style7" align="right">
                              <asp:Label ID="lblRqty" runat="server" Text="0" style="font-weight: 700"></asp:Label>
    
    
                          </td>
                      </tr>
                      <tr>
                          <td class="style6" height="22">
                              &nbsp;</td>
                          <td align="left" class="style10">
                              Total&nbsp;Issued Qty</td>
                          <td class="style7" align="right">
                  <asp:Label ID="lblIqty" runat="server" Text="0" style="font-weight: 700"></asp:Label>
                          </td>
                      </tr>
                      <tr>
                          <td class="style6" height="22">
                              &nbsp;</td>
                          <td class="style8" align="left">
                         <asp:Label ID="lbl2" runat="server" Text="Closing Qty" 
                                  style="color: #336600; font-weight: 700" />
    
    
                          </td>
                          <td class="style7" align="right">
                              <asp:Label ID="lblclosingQty" runat="server" style="font-weight: 700"></asp:Label>
    
    
                          </td>
                      </tr>
                  </table>
        </td>
    </tr>
    
        
    
    <tr>
    <td align="center" class="style4" height="25">
    <asp:Button ID="BtnPrint"  CssClass="redbox" runat="server" onclick="BtnPrint_Click" 
                      Text=" Print " />
                  &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Cancel" 
                      onclick="Button1_Click" />
                  
        </td>
    </tr>
    
        
    
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

