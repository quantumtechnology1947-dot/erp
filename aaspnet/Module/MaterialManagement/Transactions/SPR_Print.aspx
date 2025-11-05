<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_SPR_Print, newerp_deploy" title="ERP" theme="Default" %>
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
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" align="left">
                    <tr>
                        <td align="left" valign="middle"  scope="col" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21">
        &nbsp;<b>SPR - Print</b></td>
                    </tr>
                     <tr>
                        <td height="25" align="left">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                onselectedindexchanged="drpfield_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0">Employee Name</asp:ListItem>
                                <asp:ListItem Value="1">SPR No</asp:ListItem>
                            </asp:DropDownList>
&nbsp;
                <asp:TextBox ID="txtEmpName" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                             
                            <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtEmpName" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                             
                            <asp:TextBox ID="txtSprNo" runat="server" Visible="False" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox"  Text="Search" 
                                onclick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:GridView ID="GridView2" runat="server" DataKeyNames="Id" 
                                PageSize="20" Width="90%" 
                                AutoGenerateColumns="False" AllowPaging="False" 
                                CssClass="yui-datatable-theme" 
                                onpageindexchanging="GridView2_PageIndexChanging" 
                                onrowcommand="GridView2_RowCommand">
                                <PagerSettings PageButtonCount="40" />
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="3%" />
                    </asp:TemplateField>
                    

                    
                       <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Sel" Text="Select" ></asp:LinkButton> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="SPRNo">
                        <ItemTemplate>
                            <asp:Label ID="lblSPRNo" runat="server" Text='<%# Bind("SPRNo") %>'></asp:Label>
                        </ItemTemplate>                       
                         <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:TemplateField>
                    
             
                    
                     <asp:TemplateField HeaderText="Fin Year">
                                    <ItemTemplate>
                                    <asp:Label ID="lblfinyrs" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                                    </ItemTemplate>  <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    
                                    </asp:TemplateField>
                    <asp:BoundField DataField="SysDate" HeaderText="Date" >
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Time" HeaderText="Time" >
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EmpName" HeaderText="Gen By" >
                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:BoundField>
                    
                    <asp:TemplateField Visible="false"> 
                    <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>                       
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
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
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

