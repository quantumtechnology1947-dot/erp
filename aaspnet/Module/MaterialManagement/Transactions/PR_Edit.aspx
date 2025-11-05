<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PR_Edit, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
 <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
                    <tr>
                        <td align="left" valign="middle"  scope="col" height="21" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
        &nbsp;<b>PR -Edit  </b></td>
                    </tr>
                    <tr>
                        <td height="25">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                onselectedindexchanged="drpfield_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0">Employee Name</asp:ListItem>
                                <asp:ListItem Value="1">PR No</asp:ListItem>
                            </asp:DropDownList>
&nbsp;
                    <asp:TextBox ID="txtEmpName" runat="server" CssClass="box3"  Width="350px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtprNo" runat="server" Visible="False" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Search" />
                        </td>
                    </tr>
                    
                    <tr >
                        <td > 
                            <asp:GridView ID="GridView2" runat="server" DataKeyNames="Id" 
                                PageSize="20" Width="100%" 
                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                onpageindexchanging="GridView2_PageIndexChanging" AllowPaging="True" >
                                <PagerSettings PageButtonCount="40" />
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Fin Year">
                                    <ItemTemplate>
                                    <asp:Label ID="lblfinyrs" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="PRNo,wono,Id" 
                        DataNavigateUrlFormatString="~/Module/MaterialManagement/Transactions/PR_Edit_Details.aspx?PRNo={0}&amp;WONo={1}&amp;ModId=6&amp;SubModId=34&amp;Id={2}" 
                        NavigateUrl="~/Module/MaterialManagement/Transactions/PR_Edit_Details.aspx" 
                        Text="Select" >
                    
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    
                    <asp:BoundField DataField="PRNo" HeaderText="PRNo" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="wono" HeaderText="WONo" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SysDate" HeaderText="Date" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Time" HeaderText="Time" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EmpName" HeaderText="Gen By" >
                        <ItemStyle Width="30%" />
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
                    <FooterStyle Wrap="True">
                    </FooterStyle>
                
                            </asp:GridView>
                          
                        </td>
                    </tr>
                    
                    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

