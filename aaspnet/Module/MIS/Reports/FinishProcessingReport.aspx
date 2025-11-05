<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MIS_Reports_FinishProcessingReport, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

 <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    </style>
  <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
  
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />


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
            <td align="left" class="fontcsswhite" height="20" scope="col" style="background: url(../../../images/hdbg.JPG)" valign="middle">&nbsp;<b>Finish Processsing Report</b></td>
        </tr>
      <tr>
      <td>
          &nbsp;</td>
      </tr>
      <tr>
      <td>
      <asp:GridView ID="GridView1"  runat="server" AllowPaging="True"  DataKeyNames="Id"
                    AutoGenerateColumns="False" Width="100%" 
              CssClass="yui-datatable-theme" PageSize="20" >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                   <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                        </asp:TemplateField>
                         <asp:TemplateField  HeaderText="Id" Visible="false">
                        <ItemTemplate>
                      <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>                        
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PO No">
                         <ItemTemplate>
                        <asp:Label ID="lblPONo" runat="server" Text='<%#Eval("PONo") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="PO  Date">
                         <ItemTemplate>
                        <asp:Label ID="lblPODate" runat="server" Text='<%#Eval("SysDate1") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Item Code">
                         <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Desc">
                         <ItemTemplate>
                        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Qty">
                         <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Qty">
                         <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="MRS NO">
                         <ItemTemplate>
                        <asp:Label ID="lblMRSNo" runat="server" Text='<%#Eval("MRSNo") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="MRS Date">
                         <ItemTemplate>
                        <asp:Label ID="lblMRSDate" runat="server" Text='<%#Eval("SysDate2") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MIN  No">
                         <ItemTemplate>
                        <asp:Label ID="lblMINNo" runat="server" Text='<%#Eval("MINNo") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MIN  Date">
                         <ItemTemplate>
                        <asp:Label ID="lblMINDate" runat="server" Text='<%#Eval("SysDate3") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                    </Columns>  
                      <EmptyDataTemplate>
                                    <table width="100%" ><tr><td align="center" >
                                    <asp:Label ID="Label1" runat="server"  Text="No  data found to display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                    
                    
                           
                    </asp:GridView>
      
      
      </td>
      </tr>
      <tr>
      <td>
          &nbsp;</td>
      </tr>
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

