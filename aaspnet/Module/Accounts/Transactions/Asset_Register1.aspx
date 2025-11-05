<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Asset_Register1, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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
<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Asset Register</b></td>
        </tr>
        <tr>
        <td>

        <table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px"><tr>
                <td 
                    height="10" colspan="2" valign="middle" ><b>&nbsp;&nbsp;&nbsp; </b>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    </td>
                <td 
                    height="10" colspan="2" valign="middle" >&nbsp;&nbsp;&nbsp;&nbsp;
                </td></tr><tr>
                <td class="fontcss" valign="top" width="49%"  align ="center">
                    <asp:Panel ID="Panel1" Height="449px" ScrollBars="Auto" runat="server">                    
                <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                Width="98%" AllowPaging="True" PageSize="24" onrowcommand="GridView2_RowCommand" 
                            ShowFooter="True">
                
                    <PagerSettings PageButtonCount="40" />
                
                <Columns>
                                    
                    <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                    <asp:LinkButton ID="LinkBtnDel"  runat="server" CausesValidation="False" CommandName="Del" Text="Delete">
                    </asp:LinkButton>
                    </ItemTemplate>  
                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="7%" />                  
                    </asp:TemplateField>               
                
                
                <asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %>
                    </ItemTemplate>
                    

                    <HeaderStyle Font-Size="10pt" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" />
                    </asp:TemplateField>
                    
                  
                    <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label
                     ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="5%" />
                     </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="Fin Year" >
                    <ItemTemplate>
                    <asp:Label ID="lblFinYear" runat="server" Text='<%# Bind("FinYear") %>'></asp:Label>
                    </ItemTemplate>
                    
                  <FooterTemplate >
                    <asp:Button ID="btnInsert" runat="server" CommandName="Add" 
                    OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                </FooterTemplate>
                        
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Asset" >
                    <ItemTemplate>
                    <asp:Label ID="lblAsset" runat="server" Text='<%# Bind("Asset") %>'></asp:Label>                 

                    
                    </ItemTemplate>
                    
                         <FooterTemplate>
                            <asp:DropDownList ID="ddlAsset" runat="server" DataSourceID="SqlDataSource2" Width="70%"
                     DataTextField="Asset" DataValueField="Id" CssClass="box3" AutoPostBack="true"
                      onselectedindexchanged="ddlAsset_SelectedIndexChanged">
                    </asp:DropDownList>                   
                        </FooterTemplate>
                    
                    
                    
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>                
                    
                      <asp:TemplateField HeaderText="BG Group" >
                    <ItemTemplate>
                    <asp:Label ID="lblBGGroup" runat="server" Text='<%# Bind("BGGroup") %>'></asp:Label>                       
                  
                    
                    </ItemTemplate>
                       <FooterTemplate>
                              
                    <asp:DropDownList ID="ddlBGGroup" runat="server" DataSourceID="SqlDataSource1" Width="70%"
                     DataTextField="BGGroup" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>         
                        </FooterTemplate>
                    
                    
                    
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Asset No." >
                    <ItemTemplate>
                    <asp:Label ID="lblAssetNo" runat="server" Text='<%# Bind("AssetNo") %>'></asp:Label>
                    </ItemTemplate>
                    
                    <FooterTemplate>
                      <asp:Label ID="lblAssetNumber" runat="server"  Text='<%# Bind("AssetNo") %>'></asp:Label>
                    </FooterTemplate>
                    
                        <FooterStyle Font-Bold="True" HorizontalAlign="Left" />
                    
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:TemplateField>
                    
                        </Columns>
                        
                        
            <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                        <td align="center" >
                        <asp:Label ID="LabelSN" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="SN"></asp:Label>
                        </td>
                        
                    <td align="center" >
                        <asp:Label ID="LabelFinYear" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="Fin Year"></asp:Label>
                        </td>
                        
                        <td align="center">
                         <asp:Label ID="LabelAsset" runat="server" Font-Size="Medium" Font-Names="Times New Roman" 
                          Font-Bold="true" Text="Asset"></asp:Label>
                          </td>
                          
                         <td align="center">
                         <asp:Label ID="LabelBGGroup" runat="server" Font-Size="Medium" Font-Names="Times New Roman" 
                          Font-Bold="true" Text="BG Group"></asp:Label>
                          </td>
                          
                          <td align="center">
                         <asp:Label ID="LabelAssetNo" runat="server" Font-Size="Medium" Font-Names="Times New Roman" 
                          Font-Bold="true" Text="Asset No."></asp:Label>
                          </td>
                    </tr>
                    <tr>
                    <td align="center">
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd() "
                 CssClass="redbox" Text="Insert" />
                </td>
                
                 <td align="center">
               <asp:Label ID="LabelFinYear1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="Fin Year"></asp:Label>                
                </td>
    
             <td align="center">               
                
              <asp:DropDownList ID="ddlAsset1" runat="server" DataSourceID="SqlDataSource2" Width="70%"
                     DataTextField="Asset" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>                 
                </td>
                 <td align="center">
               <asp:DropDownList ID="ddlBGGroup1" runat="server" DataSourceID="SqlDataSource1" Width="70%"
                     DataTextField="BGGroup" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>                   
                </td>
                
                <td align="center">
               <asp:Label ID="LabelAssetNo1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="0001"></asp:Label>                
                </td>
                </tr>
                </table>
                
            </EmptyDataTemplate> 
                        
                        <FooterStyle Font-Bold="False" HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="9pt" />
                        </asp:GridView>
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, Symbol as BGGroup from BusinessGroup">
                        </asp:SqlDataSource>
                        
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, Abbrivation as Asset from tblACC_Asset">
                        </asp:SqlDataSource>
                        
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select FinYearId,FinYear from tblFinancial_master Order By FinYearId Desc">
                        </asp:SqlDataSource>                        
                        
                        
                        
                 </asp:Panel></td>
                <td class="fontcss" valign="top" width="20" colspan="2">
                    &nbsp; </td>
                <td class="fontcss" valign="top" width="49%">
                                        <b>
               
                          <asp:DropDownList ID="ddlSearch" runat="server" CssClass="box3" 
                                AutoPostBack="True" onselectedindexchanged="ddlSearch_SelectedIndexChanged">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Fin Year</asp:ListItem>
                                <asp:ListItem Value="2">Asset</asp:ListItem>                                
                                <asp:ListItem Value="3">BG Group</asp:ListItem>
                            </asp:DropDownList>
                            
                     <asp:DropDownList ID="ddlFinYear" runat="server" DataSourceID="SqlDataSource3" Width="90px"
                     DataTextField="FinYear" DataValueField="FinYearId" CssClass="box3" 
                            Visible="False">
                    </asp:DropDownList>                            
                            
                     <asp:DropDownList ID="ddlAsset2" runat="server" DataSourceID="SqlDataSource2" Width="90px"
                     DataTextField="Asset" DataValueField="Id" CssClass="box3" Visible="False">
                    </asp:DropDownList> 
                            
                     <asp:DropDownList ID="ddlBGGroup2" runat="server" DataSourceID="SqlDataSource1" Width="90px"
                     DataTextField="BGGroup" DataValueField="Id" CssClass="box3" Visible="False">
                    </asp:DropDownList>    
                        

                        <b>
                        <asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                            onclick="btnSearch_Click" Text="Search" />
                        </b>
                        <asp:Button ID="btnExportToExcel" runat="server" CssClass="redbox" Text="Export To Excel" 
                                            onclick="btnExportToExcel_Click" />
                        </b>
                        
                    <asp:Panel ID="Panel2" Height="434px" ScrollBars="Auto" runat="server">                  
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" CssClass="box3" 
                            Height="20px" HorizontalAlign="Center" Visible="False">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" 
                                Text="No data found   !"></asp:Label>
                        </asp:Panel>
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme"  PageSize="23" Width="100%">
                            <Columns>
                      
                                  
                    <asp:TemplateField HeaderText="SN" ><ItemTemplate><asp:Label
                     ID="lblSN" runat="server" Text='<%# Bind("SN") %>'></asp:Label></ItemTemplate>
                       <ItemStyle HorizontalAlign="Right" Width="5%" />
                     </asp:TemplateField>
                     
                                <asp:TemplateField HeaderText="FinYear">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFinYearSearch" runat="server" 
                                            Text='<%# Bind("FinYear") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asset" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetSearch" runat="server" Text='<%# Bind("Asset") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BG Group">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBGGroupSearch" runat="server" 
                                            Text='<%# Bind("BGGroup") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asset No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetNoSearch" runat="server" 
                                            Text='<%# Bind("AssetNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
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
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr></table>
            
           
                
                
                
        </td>
        </tr>
        </table>


 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

