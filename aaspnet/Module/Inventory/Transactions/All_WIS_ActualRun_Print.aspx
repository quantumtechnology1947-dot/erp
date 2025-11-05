<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_WIS_ActualRun_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;WIS Print</b></td>
        </tr><tr>
        <td>
      
       <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True">
                    <cc1:TabPanel runat="server" Visible="false" HeaderText=" Search by WO No " ID="TabPanel1">
                        <HeaderTemplate>
&nbsp;&nbsp; Search by WO No &nbsp;        </HeaderTemplate>
                        
<ContentTemplate>
      
        <table width="100%">
        <tr>
        <td>
        
        
            <asp:DropDownList ID="DrpWOType" runat="server" AutoPostBack="True" 
                CssClass="box3" onselectedindexchanged="DrpWOType_SelectedIndexChanged">
            </asp:DropDownList>
            WONo
            <asp:TextBox ID="TxtWO" runat="server" CssClass="box3"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
        
        
        </td>
        </tr>        
        <tr>
        <td>       
        
      
                <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="15">
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>                        
                           <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Button ID="btnRun" runat="server" CommandName="add" CssClass="redbox" 
                                Text="Dry Run" />
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                       
                        <asp:TemplateField>
                          <ItemTemplate>
                              <asp:DropDownList ID="drpIssueShortage" runat="server">
                                  <asp:ListItem Selected="True" Text="Transaction wise Issue" Value="0"></asp:ListItem>
                                  <asp:ListItem Text="Issue List" Value="1"></asp:ListItem>
                                  <asp:ListItem Text="Shortage List" Value="2"></asp:ListItem>
                              </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />                        
                        </asp:TemplateField> 
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:Button  ID="btnView" CommandName="view" runat="server"  Text="View" CssClass="redbox" />
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WO No">
                            <ItemTemplate>
                            <asp:Label ID="lblwono" runat="server" Text='<%#Eval("WONo") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("SysDate") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Title">
                            <ItemTemplate>
                            <asp:Label ID="lblprjtitle" runat="server" Text='<%#Eval("PrjTitle") %>'  />
                            </ItemTemplate>
                            <ItemStyle Width="70%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        
                    </Columns>
                    <EmptyDataTemplate>
                                    <table width="100%" class="fontcss"><tr><td align="center" >
                                    <asp:Label ID="Label1" runat="server"  Text="No  data found to display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                    <PagerSettings PageButtonCount="40" />
                </asp:GridView> 
                
                             
             </td>       
        </tr>        
        </table>   
            
        </ContentTemplate>
        </cc1:TabPanel>
        
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Custom Search">
                        <HeaderTemplate>
&nbsp;&nbsp;WIP&nbsp;&nbsp;
                        
                        
                    </HeaderTemplate>
                        
<ContentTemplate>
        
          <table width="100%" cellpadding="0" cellspacing="0">
        
        <tr>
        <td valign="bottom">
                 From Date: <asp:TextBox ID="txtFromDate" CssClass="box3" runat="server" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                 Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                        </cc1:CalendarExtender>
                To Date:
                <asp:TextBox ID="txtToDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtToDate">
                </cc1:CalendarExtender>
               
                <asp:TextBox ID="txtWONo" runat="server" Visible="false" CssClass="box3" Width="100px"></asp:TextBox>

                 Over heads:
                <asp:TextBox ID="txtOverheads" runat="server" CssClass="box3" Width="30px">75</asp:TextBox>&nbsp;%
<asp:RegularExpressionValidator ID="RegtxtOverheads" runat="server" ErrorMessage="*"
 ControlToValidate="txtOverheads" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
 </asp:RegularExpressionValidator>
  
<asp:RequiredFieldValidator ID="ReqtxtOverheads" runat="server" ErrorMessage="*" 
 ControlToValidate="txtOverheads" ValidationGroup="A" >
 </asp:RequiredFieldValidator>
                <asp:Button ID="BtnSearch" runat="server" CssClass="redbox" ValidationGroup="A"
                    OnClick="BtnSearch_Click" Text="Search" />
        </td>
        </tr>
        
        
        
         <tr>  
           <td>
             <iframe id="Iframe1"  runat ="server" width="100%" height="410px" frameborder="0" 
                   scrolling="auto" ></iframe>
           </td> 
        </tr>      
        
        
        
                    
        </table>
        
        </ContentTemplate></cc1:TabPanel>
        
        
         </cc1:TabContainer>
           </td>
        </tr>
    </table>   
     
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

