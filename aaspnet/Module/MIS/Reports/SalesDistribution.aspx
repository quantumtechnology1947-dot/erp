<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MIS_Reports_SalesDistribution, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 620px;
        }
       
        .style3
        {
            font-size: 11pt;
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

    <asp:UpdatePanel ID="UpdatePanel1"  UpdateMode="Conditional" runat="server">
    <ContentTemplate>
    <table align="center" cellpadding="0" cellspacing="0" class="fontcss" width="98%">
    <tr>
    <td colspan="2" align="left" class="fontcsswhite" height="20" scope="col" style="background: url(../../../images/hdbg.JPG)" valign="middle">&nbsp;<b>Sales Distribution</b></td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    </tr>
        <tr>
            <td class="style2" align="left" valign="top" rowspan="2">
               
               
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CssClass="yui-datatable-theme" Width="100%" AllowPaging="True" GridLines="Both"
                        
                        
                        PageSize="15" onpageindexchanging="GridView1_PageIndexChanging"
     >
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                            <asp:TemplateField 
                            HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Fin Year" DataField="FinYear"/>
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" >
                                <ItemStyle HorizontalAlign="Left" Width="45%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Code" DataField="CustomerId" />
                            <asp:BoundField HeaderText="Enq No" DataField="EnqId" >
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                             <asp:BoundField HeaderText="Gen Date" DataField="SysDate" />
                            <asp:BoundField HeaderText="Gen By" DataField="EmployeeName" />
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
                          <HeaderStyle CssClass="header" />
                    </asp:GridView>
                
                
                    
            </td>
            <td align="center" valign="middle" class="style3">
                Enquiry Chart</td>
        </tr>
        <tr>
            <td align="center" valign="top">
              <asp:Chart ID="Chart1" runat="server" Height="307px" Width="379px">
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
            <td class="style2" valign="top">
                     
                &nbsp;</td>
            <td align="center" valign="middle" class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" rowspan="2" valign="top">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    GridLines="Both" CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataKeyNames="PONo" RowStyle-HorizontalAlign ="Center"
                    
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" PageSize="15" 
                               >
           
                    <PagerSettings PageButtonCount="40" />
           
            <RowStyle />
                                <Columns>
                                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName">
                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                                    <asp:HyperLinkField 
                                        
                                        DataTextField="PONo" HeaderText="PO No">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="EnqId" HeaderText="Enq No" >
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SysDate" HeaderText="Gen Date" />
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Gen By" >
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
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
        </asp:GridView>

            </td>
            <td align="center" valign="top" class="style3">
                Customer PO Chart</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                 <asp:Chart ID="Chart2" runat="server" Height="307px" Width="379px">
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
        <tr><td>
            &nbsp;</td>
        <td>
            &nbsp;</td></tr>
        <tr><td rowspan="2" valign="top">
            
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" GridLines="Both"
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo" RowStyle-HorizontalAlign ="Center"                  
                    onpageindexchanging="GridView2_PageIndexChanging" Width="100%" 
                PageSize="15" >
            
                <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle HorizontalAlign="Left" Width="8%" />
                </asp:BoundField>
                                  <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" />
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" />
                                  <asp:HyperLinkField 
                    HeaderText="WO No" 
                    DataTextField="WONo" 
                     />
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
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
        </asp:GridView>
            
            </td>
        <td align="center" valign="middle" class="style3">
            Work Order Chart</td></tr>
        <tr>
        <td valign="top" align="center">
             <asp:Chart ID="Chart3" runat="server" Height="307px" Width="379px">
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
            </td></tr>
        <tr><td valign="top">
            &nbsp;</td>
        <td>
            &nbsp;</td></tr>
        <tr><td valign="top" rowspan="2">
<asp:GridView ID="GridView3" runat="server" CssClass="yui-datatable-theme"
        Width="100%" AllowPaging="True" AutoGenerateColumns="False" 
                onpageindexchanging="GridView3_PageIndexChanging" PageSize="15">

    <PagerSettings PageButtonCount="40" />

    <Columns>
        <asp:TemplateField HeaderText="SN">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
            <ItemStyle Width="5%" />
        </asp:TemplateField>
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
            <ItemStyle Width="45%" />
        </asp:BoundField>
        <asp:BoundField DataField="CustomerId" HeaderText="Code" />
        <asp:BoundField DataField="WONo" HeaderText="WoNo" />
        <asp:BoundField DataField="SysDate" HeaderText="Date of Dispatch" >
            <ItemStyle Width="10%" />
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
   
</asp:GridView>
            </td>
        <td align="center" class="style3" valign="middle">
            Work Order Dispatch Chart</td></tr>
        <tr>
        <td align="center" valign="top">
             <asp:Chart ID="Chart4"  runat="server" Height="307px" Width="379px">
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
            </td></tr>
        <tr><td valign="top">
            &nbsp;</td>
        <td>
            &nbsp;</td></tr>
        <tr><td valign="top">
            &nbsp;</td>
        <td>
            &nbsp;</td></tr>
        </table>
     
     </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

