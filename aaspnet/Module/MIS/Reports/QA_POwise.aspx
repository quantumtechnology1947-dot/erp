<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MIS_Reports_QA_POwise, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="455px"  Width="100%" >
        <cc1:TabPanel runat="server" HeaderText="QA Report" ID="TabPanel1">            
        <ContentTemplate>
 <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>QA-PO Wise Report</b>
            </td>
        </tr>
        <tr>
            <td align="Left">
                <asp:Panel ID="Panel1" runat="server" Height="438px" ScrollBars="Auto" 
                    Width="100%">
                    <CR:CrystalReportSource ID="CrystalReportSource1"   runat="server">
        <Report FileName="Module\MIS\Reports\QA_POWise_Print.rpt">
        </Report>
    </CR:CrystalReportSource>
<CR:CrystalReportViewer ID="CrystalReportViewer1" DisplayGroupTree="False" 
                        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"  
                        ReportSourceID="CrystalReportSource1" runat="server" HasCrystalLogo="False"
    AutoDataBind="True" />
                </asp:Panel>
                    
                    </td>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
       
    </table>  
  </ContentTemplate>
  </cc1:TabPanel>  
  
  <cc1:TabPanel runat="server" Width="100%" HeaderText="QA Graph" ID="TabPanel2">            
  <ContentTemplate>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
      <fieldset style="width: 98%" align="left">
   
   <legend>UOM Wise QA Chart Of Supplier</legend>
   
   
   <div> 
       <asp:Label ID="lblSup" runat="server" Font-Bold="True" Text="Supplier Name:"></asp:Label> 
       <asp:TextBox ID="txtSupplier" Width="350px" runat="server"></asp:TextBox>
       <asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
           onclick="btnSearch_Click" Text="Search" />
       <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList2" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
       
        </div>
    <div align="center" >   
    <asp:Chart ID="Chart1" Height="400px" Width="800px"    runat="server" 
            TextAntiAliasingQuality="Normal" >
        <Series>
            <asp:series Name="Series1" Font="Microsoft Sans Serif, 8pt" Color="Red" 
                ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder, PointWidth=0.2" 
                IsValueShownAsLabel="True"   LabelBackColor="255, 192, 192" Legend="Legend1" 
                LegendText="PO Qty"></asp:series>	
            <asp:series Name="Series2" Font="Microsoft Sans Serif, 8pt" Color="Green" 
                ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder, PointWidth=0.2" 
                IsValueShownAsLabel="True" LabelBackColor="192, 255, 192" Legend="Legend1" 
                LegendText="GQN Qty"></asp:series>	
             <asp:series Name="Series3" Font="Microsoft Sans Serif, 8pt" Color="Blue" 
                ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder, PointWidth=0.2" 
                IsValueShownAsLabel="True" LabelBackColor="192, 192, 255" Legend="Legend1" 
                LegendText="GSN Qty"></asp:series>
              <asp:series Name="Series4" Font="Microsoft Sans Serif, 8pt" 
                Color="DarkMagenta" ChartArea="ChartArea1" 
                CustomProperties="DrawingStyle=Cylinder, PointWidth=0.2" 
                IsValueShownAsLabel="True" LabelBackColor="255, 128, 255" Legend="Legend1" 
                LegendText="PVEV Qty"></asp:series>		
        </Series>
        
        <ChartAreas>
        
            <asp:ChartArea Name="ChartArea1" BackColor="224, 224, 224" BorderColor="Silver" 
                            ShadowColor="DimGray"> 
                                     
            
             <Position Height="100" Width="100" Auto="False" />
                <AxisX IsLabelAutoFit="False">
                    <LabelStyle Angle="-90" />
                </AxisX>
                <Area3DStyle LightStyle="Realistic" Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Name="QA Report" Alignment="TopCenter" 
                Font="Microsoft Sans Serif, 12pt, style=Bold" Text="QA Report">
            </asp:Title>
        </Titles>
    </asp:Chart>
    
    
   </div>   
  
   </fieldset>  
      
      </ContentTemplate>
      </asp:UpdatePanel>
  
   
  </ContentTemplate>
  </cc1:TabPanel>  
  </cc1:TabContainer>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    
</asp:Content>

