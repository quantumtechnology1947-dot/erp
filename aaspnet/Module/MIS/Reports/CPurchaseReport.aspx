<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CPurchaseReport.aspx.cs" Inherits="Module_MIS_Reports_CPurchaseReport" Title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style5
        {
            height: 25px;
        }
        .style6
        {
            height: 26px;
        }
        </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
<table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" class="fontcsswhite" height="20" scope="col" 
                style="background: url(../../../images/hdbg.JPG)" valign="middle" colspan="2">&nbsp;<b>Purchase Report  </b></td>
        </tr>
        
           <tr>
       <td align="center" colspan="2" height="25px">
       
              
                             <asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" 
                               AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                
                                <asp:ListItem Value="1">Supplier Name</asp:ListItem>
                               <asp:ListItem Value="2">PO No</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtSupplier" runat="server"   Width="250px" CssClass="box3"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplier" UseContextKey="True"   CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                            
                            
                            <asp:TextBox ID="txtpoNo" runat="server" CssClass="box3"  Visible="False"  ></asp:TextBox>
                                <asp:Button 
                                    ID="Button1" runat="server" CssClass="redbox" Text="Search" 
                                    onclick="Button1_Click" /></td>
        </tr>
        
           <tr>
       <td align="center" rowspan="4">
           <asp:Panel ID="Panel1"  ScrollBars="Auto"  Height="650px" runat="server" 
               Width="550px">
         
              
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            CssClass="yui-datatable-theme" Width="100%" 
                                    onpageindexchanging="GridView1_PageIndexChanging" >
                                            <PagerSettings PageButtonCount="40" />
                                            <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                  
                                   
                                     <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                                   
                                   
                                    <asp:TemplateField HeaderText="SupplierName">
                                    <ItemTemplate>
                                    <asp:Label ID="lblsupl" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="35%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("SysDate") %>'></asp:Label>
                                                </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                               <asp:TemplateField HeaderText="Basic Amt.">
                                    <ItemTemplate>
                                             <asp:Label ID="lblBAmt" runat="server" Text='<%# Eval("BAmount") %>'></asp:Label>
                                     </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                               </asp:TemplateField>
                                    
                            <asp:TemplateField HeaderText="Tax. Amt.">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                               </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                              </asp:TemplateField>
                                    
                                     <asp:TemplateField  Visible="False"   HeaderText="POMonth">
                                    <ItemTemplate>
                                         <asp:Label ID="lblPOMonth" runat="server" Text='<%#Eval("POMonth") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField> 
                             
                             
                                         
                         <asp:TemplateField Visible="false" HeaderText="SupplierId">
                        <ItemTemplate>
                       <asp:Label ID="lblSupplierId" runat="server" Text='<%#Eval("SupplierId") %>'></asp:Label>
                        
                        </ItemTemplate>
                        </asp:TemplateField>
                                    
                                    </Columns>
                                    <EmptyDataTemplate>
                                    <table width="100%"><tr><td align="center">
                                    <asp:Label ID="Label1" runat="server"  Text="No Data to Display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                            </asp:GridView>
                              </asp:Panel>
              
       </td>
       <td align="center">
       
             <asp:Chart ID="Chart2" runat="server" Width="650px">
                    <series>
                        <asp:Series Name="Series1" Font="Microsoft Sans Serif, 8pt">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea2" BackColor="224, 224, 224" BorderColor="Silver" 
                            ShadowColor="DimGray">
                            <Position Height="100" Width="100" />
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart> </td>
        </tr>
         <tr>
        <td align="center" height="25px" 
                 style="border-bottom-style: solid; border-color: #008080">
        <asp:Label  ID="lblturn" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </td>
        </tr>
        
        
        <tr>
            <td align="center" class="style6">
                <asp:Chart ID="Chart1" runat="server" Width="650px">
                    <series>
                        <asp:Series Font="Microsoft Sans Serif, 8pt" Name="Series1">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea  Name="ChartArea1" BackColor="224, 224, 224" BorderColor="Silver"  
                            ShadowColor="DimGray">
                            <Position Height="100" Width="100" />
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td align="center" height="25px">
                <asp:Label ID="lblTaxturn" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        
        
        <tr>
           
                            <td align="center"class="style5" colspan="2">&#160;&nbsp; <b></b>&nbsp;
                                &#160;</td></tr>
                                    </table>
 
 </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

