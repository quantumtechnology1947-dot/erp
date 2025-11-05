<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectSummary_ProjectSummary_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    </style>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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

<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="710px" >    
    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Graphical View" >
    
        <HeaderTemplate>
            Graphical View
        </HeaderTemplate>
    
        <ContentTemplate>
                        <table align="left" cellpadding="0" cellspacing="0" class="style2">
                            <tr>
                                <td>
                                    <strong>&nbsp;Project Summary for WO No: </strong>&nbsp;<asp:Label ID="lblWo" runat="server"></asp:Label>
                                    <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" Text="Cancel" 
                                        onclick="BtnCancel_Click" />
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    
                        <asp:Chart ID="Chart1" runat="server" Height="700px" Palette="EarthTones" 
                            Width="1300px">
                            <Legends>
                                <asp:Legend BackColor="255, 255, 192" Name="Legend1" Title="Project Status">
                                    <Position Auto="False" Height="7" Width="10" X="3.71929" Y="90" />
                                </asp:Legend>
                            </Legends>
                            <Series>
                                <asp:Series ChartArea="ChartArea1" ChartType="Bar" 
                                    CustomProperties="DrawingStyle=Cylinder, PointWidth=0.1" 
                                    Font="Microsoft Sans Serif, 8pt, style=Bold" IsValueShownAsLabel="True" 
                                    LabelBorderDashStyle="NotSet" LabelBorderWidth="0" Legend="Legend1" 
                                    MarkerSize="2" Name="Progress" YValuesPerPoint="2">
                                    <EmptyPointStyle CustomProperties="DrawingStyle=Default" />
                                    <SmartLabelStyle CalloutLineDashStyle="Dot" IsMarkerOverlappingAllowed="True" />
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea BackColor="White" BorderColor="Gray" Name="ChartArea1" 
                                    ShadowColor="Transparent">
                                    <AxisX IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap" Title="Assembly No" 
                                       >
                                        <MajorGrid LineColor="Gainsboro" />
                                    </AxisX>
                                    <AxisY Interval="5" IsLabelAutoFit="False" Maximum="100" Minimum="0" 
                                        Title=" Work Progress in(%)">
                                        <MajorGrid LineColor="Gainsboro" />
                                        <LabelStyle Font="Microsoft Sans Serif, 8pt, style=Bold" />
                                    </AxisY>
                                    <Position Auto="False" Height="85" Width="100" />
                                    <InnerPlotPosition Auto="False" Height="100" Width="80" X="13" />
                                    <Area3DStyle Enable3D="True" Inclination="40" PointDepth="50" Rotation="15" 
                                        WallWidth="10" />
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        </td>
                            </tr>
            </table>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText=" Detail View">
    <ContentTemplate>
        <asp:GridView ID="GridView1" Width="100%" CssClass="yui-datatable-theme" runat="server" 
            AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand" 
            PageSize="20">
            <Columns>
             <asp:TemplateField HeaderText="SN">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ItemId" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblItemId" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="WONo" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PId" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPId" runat="server" Text='<%# Eval("PId") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CId" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblCId" runat="server" Text='<%# Eval("CId") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Code">
                <ItemTemplate>
                   <%-- <asp:Label ID="lblItemcode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("ItemCode") %>' CommandName="sel"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UOM">
                <ItemTemplate>
                    <asp:Label ID="lblUOM" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Unit Qty"  Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblUnitQty" runat="server" Text='<%# Eval("UnitQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BOM Qty">
                <ItemTemplate>
                    <asp:Label ID="lblBOMQty" runat="server" Text='<%# Eval("BOMQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Weld" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblWeld" runat="server" Text='<%# Eval("Weld") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock Qty" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblStockQty" runat="server" Text='<%# Eval("StockQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tot.WIS Qty" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblTotWISQty" runat="server" Text='<%# Eval("TotWISQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dry Run Qty" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblDryRunQty" runat="server" Text='<%# Eval("DryRunQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bal.BOM Qty">
                <ItemTemplate>
                    <asp:Label ID="lblBalanceBOMQty" runat="server" Text='<%# Eval("BalanceBOMQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="After Stock Qty" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblAfterStockQty" runat="server" Text='<%# Eval("AfterStockQty") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>             
                 <asp:TemplateField HeaderText="Progress in(%)">
                <ItemTemplate>
                    <asp:Label ID="lblprogerss" runat="server" Text='<%# Eval("Progress") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>  
                
            </Columns>
            <EmptyDataTemplate>
            <table width="100%">
            <tr>
            <td align="center">
                <asp:Label ID="Label1" ForeColor="Maroon" runat="server" Text="No Data to display"></asp:Label>
            </td>
            </tr>
            </table>
            
            </EmptyDataTemplate>
            
            
            
        </asp:GridView>
   
    
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

