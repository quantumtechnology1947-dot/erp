<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Budget_Dist_Time.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_Dist_Time" Title="ERP" Theme ="Default"  %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    
.redbox 
{
	font-family: Verdana, Arial, Helvetica, sans-serif; 
    color: #FFFFFF;
	font-size: 11px; background-color:#FF0000;
	border: 1px solid #FD80FA;
	height: 19px;
}

        </style>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
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
            <td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">
                            &nbsp;<b>Assign Budget</b></td>
        </tr>
        <tr>
            <td>
                <%--<asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>--%>
            
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="434px"
        AutoPostBack="True" onactivetabchanged="TabContainer1_ActiveTabChanged" Width="100%" >
        <cc1:TabPanel runat="server" HeaderText="Bussiness Group" ID="TabPanel1" Visible="false" >
            <HeaderTemplate>
                Bussiness Group           
            
        </HeaderTemplate>
        
<ContentTemplate>
<table align="left" cellpadding="0" cellspacing="0" class="style2"><tr><td width="40%" colspan="2"><asp:Panel ID="Panel2" runat="server" Height="420px" ScrollBars="Auto"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" DataSourceID="LocalSqlServer" 
                            OnRowCommand="GridView2_RowCommand" PageSize="20" Width="95%"><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex + 1%></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="3%" />
</asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="LinkButton1" runat="server" CommandName="Sel" Text="Select"></asp:LinkButton>

                                    
        </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" />
</asp:TemplateField><asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                    
        </ItemTemplate><ItemStyle Width="3%" />
</asp:TemplateField><asp:TemplateField HeaderText="Description" SortExpression="Description"><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Name") %>'> </asp:Label>
                                    
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="20%" />
</asp:TemplateField><asp:TemplateField HeaderText="Symbol" SortExpression="Symbol"><ItemTemplate><asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                                    
        </ItemTemplate><FooterTemplate>
                                    
        </FooterTemplate><ItemStyle HorizontalAlign="Center" Width="8%" />
</asp:TemplateField>
    </Columns>
    </asp:GridView>

                    </asp:Panel></td><td width="60%" ><asp:Button ID="btnCancel1" runat="server" CssClass="redbox"
                        OnClick="btnCancel1_Click" Text="Cancel" Width="60px" /><asp:Label ID="lblBG" runat="server" Text="Bussiness Group : " Visible="False" 
                        ForeColor="#0033CC" style="font-weight: 700"></asp:Label><asp:Label ID="lblBGGroup" runat="server" Visible="False" ForeColor="#0033CC" 
                        style="font-weight: 700"></asp:Label><asp:Label ID="HField" runat="server" Visible="False"></asp:Label><asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Auto"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme"  PageSize="20" 
                            Width="100%"><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex + 1%></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="3%" />
</asp:TemplateField><asp:TemplateField><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Text="Select" />
                                    
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%" />
</asp:TemplateField>
<asp:TemplateField HeaderText="CK">
    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                            OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="2%" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>  </asp:Label>
                                    
                </ItemTemplate><ItemStyle Width="3%" />
</asp:TemplateField><asp:TemplateField HeaderText="Symbol" SortExpression="Symbol"><ItemTemplate><asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                                    
                </ItemTemplate><FooterTemplate>
                                    
                </FooterTemplate><ItemStyle HorizontalAlign="Center" Width="8%" />
</asp:TemplateField><asp:TemplateField HeaderText="Budget Code" ><ItemTemplate><asp:Label ID="LblBudgetCode" runat="server"  > </asp:Label>                                      
                                       
                </ItemTemplate><ItemStyle Width="10%" />
</asp:TemplateField><asp:TemplateField HeaderText="Budget Hour"><ItemTemplate><asp:Label ID="lblHour" runat="server"> </asp:Label><asp:TextBox ID="TxtHour" runat="server" ValidationGroup="A" Width="80%"
                                        Visible="false"> </asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="TxtHour" ErrorMessage="*" 
                                            ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    
                </ItemTemplate><FooterTemplate>
                                    
                </FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="10%" />
</asp:TemplateField><asp:TemplateField HeaderText="Used Hour" ><ItemTemplate><asp:Label ID="LblUsedHour" runat="server"  > </asp:Label>                                      
                                       
                </ItemTemplate><ItemStyle Width="10%" />
</asp:TemplateField><asp:TemplateField HeaderText="Bal Hour" ><ItemTemplate><asp:Label ID="LblBalHour" runat="server"  > </asp:Label>                                      
                                       
                </ItemTemplate><ItemStyle Width="10%" />
</asp:TemplateField>
            </Columns>
            </asp:GridView>

                    </asp:Panel></td></tr><tr><td style="width: 0%" width="40%"><asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT Id, Name,  Symbol FROM BusinessGroup Where Id not in ('1') "></asp:SqlDataSource></td><td style="width: 20%" width="40%"><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT Id,Description AS Name,Symbol FROM tblHR_Grade where Id!=1 "></asp:SqlDataSource></td><td width="60%" align="center"><asp:Button ID="BtnInsert" runat="server" CssClass="redbox" Visible="False"
                        OnClick="BtnInsert_Click" Text="Insert" ValidationGroup="A" />&nbsp; <asp:Button ID="BtnExport" runat="server" CssClass="redbox" Visible="False"
                        OnClick="BtnExport_Click" Text="Export" />&nbsp; <asp:Button ID="btnCancel" runat="server" CssClass="redbox" Visible="False"
                        OnClick="btnCancel_Click" Text="Cancel" Width="60px" /></td></tr></table>
        
        </ContentTemplate>
        
</cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Work Order ">
        <ContentTemplate> 
             
        
 
             
        <iframe src="Budget_Dist_WONo_Time.aspx"  width="100%" height="435Px" 
                frameborder="0" style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;"></iframe>
            
        
            
        
        </ContentTemplate>
        
        
</cc1:TabPanel>
    </cc1:TabContainer>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

