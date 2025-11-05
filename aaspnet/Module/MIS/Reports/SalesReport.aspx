<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MIS_Reports_SalesReport, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
 <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style5
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

 <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" class="fontcsswhite" height="20" scope="col" 
                style="background: url(../../../images/hdbg.JPG)" valign="middle" colspan="2">&nbsp;<b>Sales Report</b></td>
        </tr>
     
        
     
       <tr>
       
       <td align="center" colspan="2" height="25px">
       
       <asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                 <%--<asp:ListItem Value="Select">Select</asp:ListItem>--%>
                                <asp:ListItem Value="0">Customer Name</asp:ListItem>
                               <asp:ListItem Value="1">Invoice No</asp:ListItem>
                            </asp:DropDownList>
                <asp:TextBox ID="txtCustName" runat="server" CssClass="box3"  Width="250px"></asp:TextBox>
         
         <cc1:AutoCompleteExtender ID="txtCustName_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtCustName" UseContextKey="True"  CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
        
                            
                            <asp:TextBox ID="txtpoNo" runat="server" Visible="False" CssClass="box3"></asp:TextBox>
           <asp:Button ID="btnSearch" runat="server" CssClass="redbox"  Text="Search" 
                                onclick="btnSearch_Click" />
        
       
       </td>
       
        </tr>
     
        
     
       <tr>
       
       <td align="right" rowspan="4">
       
           <asp:Panel ID="Panel1" ScrollBars="Auto"  Height="650px" runat="server" 
               Width="550px">
           
          <asp:GridView ID="GridView1" runat="server"  DataKeyNames="Id"
                    AutoGenerateColumns="False" Width="100%" 
               CssClass="yui-datatable-theme" onpageindexchanging="GridView1_PageIndexChanging" 
                   >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
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
                             <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Customer Name">
                         <ItemTemplate>
                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle Width="35%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="InVoice No">
                         <ItemTemplate>
                        <asp:Label ID="lblInVoiceNo" runat="server" Text='<%#Eval("InVoiceNo") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                          <%--   Text='<%#Eval("Amount") %>'--%>
                          
                                    <asp:TemplateField HeaderText="Basic Amt.">
                                    <ItemTemplate>
                                    <asp:Label ID="lblBAmt" runat="server" Text='<%# Eval("BAmount") %>'></asp:Label>
                                     </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="12%" />
                                    </asp:TemplateField>
                          
                          
                          
                             <asp:TemplateField HeaderText="Tax Amt.">
                         <ItemTemplate>
                        <asp:Label ID="lblAmt"  Text='<%#Eval("Amount") %>'   runat="server" ></asp:Label>
                        </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Right" Width="12%" />
                        </asp:TemplateField> 
                        
                         
                              <asp:TemplateField  Visible="false"   HeaderText="MISMonth">
                        <ItemTemplate>
                       <asp:Label ID="lblMISMonth" runat="server" Text='<%#Eval("MISMonth") %>'></asp:Label>
                        
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                             
                             
                                         
                         <asp:TemplateField Visible="false" HeaderText="CustomerId">
                        <ItemTemplate>
                       <asp:Label ID="lblCustId" runat="server" Text='<%#Eval("CustomerId") %>'></asp:Label>
                        
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
       
       </asp:Panel>     
       
       
       </td>
       
       <td align="Right">
       
              <asp:Chart ID="Chart2" runat="server" Width="650px">
                    <series>
                        <asp:Series Name="Series1" Font="Microsoft Sans Serif, 8pt">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1" BackColor="224, 224, 224" BorderColor="Silver" 
                            ShadowColor="DimGray">
                            <Position Height="100" Width="100" />
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
                </td>
        </tr>
           <tr>
        <td align="center" style="border-bottom-style: solid; border-color: #008080">
        <asp:Label  ID="lblturn" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </td>
        </tr>
           <tr>
        <td align="center">
       
              <asp:Chart ID="Chart1" runat="server" Width="650px">
                    <series>
                        <asp:Series Name="Series1" Font="Microsoft Sans Serif, 8pt">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1" BackColor="224, 224, 224" BorderColor="Silver" 
                            ShadowColor="DimGray">
                            <Position Height="100" Width="100" />
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
        </td>
        </tr>
           <tr>
        <td align="center">
        <asp:Label  ID="lblTaxturn" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </td>
        </tr>
           <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        </tr>
          </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

