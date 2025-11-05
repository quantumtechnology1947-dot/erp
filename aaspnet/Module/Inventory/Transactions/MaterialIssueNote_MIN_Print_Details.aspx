<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialIssueNote_MIN_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            height: 29px;
        }
        .style3
        {
            height: 32px;
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
    <table class="style2" width="100%" cellpadding="0" cellspacing="0">
         <tr>
                <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite" ><b>&nbsp;Material Issue Note [MIN] - Print</b></td>
           </tr>
        <tr>
            <td align="center" >
                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="445" ScrollBars="Auto">
                
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" EnableDatabaseLogonPrompt="False"  HasCrystalLogo="False"
                    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="Module\Inventory\Transactions\Reports\MIN_Print.rpt">
                    </Report>
                </CR:CrystalReportSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" class="style3">
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                        CssClass="redbox" onclick="BtnCancel_Click" />
                </td>
        </tr>
    </table>



<%--
<table class="style2" width="100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" >
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme"  ShowFooter="true" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="90%" 
                    onrowcommand="GridView1_RowCommand" >
                <Columns>
                <asp:TemplateField HeaderText="SN"> <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 <asp:TemplateField >
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" CommandName="Del" Text="Delete" runat="server"></asp:LinkButton>
                      </ItemTemplate>
                 </asp:TemplateField>                
                
                    
                <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
              
                      
                 
                <asp:TemplateField HeaderText="Item Code" ><ItemTemplate><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Description" ><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("PurchDesc") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                   <asp:TemplateField HeaderText="UOM" ><ItemTemplate><asp:Label ID="lblUOMPurchase" runat="server" Text='<%# Eval("UOM") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                 
                 
                <asp:TemplateField HeaderText="Dept" ><ItemTemplate><asp:Label ID="lblDept" runat="server" Text='<%# Eval("Symbol") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 <asp:TemplateField HeaderText="WO No" ><ItemTemplate><asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 <asp:TemplateField HeaderText="Req Qty" ><ItemTemplate><asp:Label ID="lblReqQty" runat="server" Text='<%# Eval("ReqQty") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Issue Qty" ><ItemTemplate><asp:Label ID="lblIssueQty" runat="server" Text='<%# Eval("IssueQty") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Remarks" ><ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label></ItemTemplate>
                 
                      
                 
                 </asp:TemplateField>
               
                
              </Columns>
    
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                    onclick="BtnCancel_Click" />
            </td>
        </tr>
    </table>--%>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

