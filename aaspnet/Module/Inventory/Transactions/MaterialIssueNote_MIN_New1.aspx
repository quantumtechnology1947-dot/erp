<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialIssueNote_MIN_New, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .redbox
        {}
        .style3
        {
            height: 28px;
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
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" ><b>&nbsp;Material Issue Note [MIN] - New</b></td>
        </tr>
        <tr>
        <td width="600px" class="style3">
        
            &nbsp;<asp:DropDownList ID="DrpField" runat="server" 
                onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True" 
                CssClass="box3">
               <%-- <asp:ListItem Value="Select">Select</asp:ListItem>--%>
               <asp:ListItem Value="0">Employee Name</asp:ListItem>
               <asp:ListItem Value="1">MRS No</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="TxtMrs" runat="server"  Visible="false"  Width="150px" CssClass="box3"></asp:TextBox>
            &nbsp;<asp:TextBox ID="TxtEmpName" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
                  
             <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
            &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" Height="20px" />
            
        
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" Width="100%" 
                    onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="15">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="btnSel" runat="server" Text="Select" CommandName="Sel"></asp:LinkButton>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' ></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FinYrsId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblfinyrsid" runat="server" Text='<%#Eval("FinYrsId") %>' ></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Fin Year">
                        <ItemTemplate>
                        <asp:Label ID="lblfinyrs" runat="server" Text='<%#Eval("FinYrs") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="MRS No">
                        <ItemTemplate>
                        <asp:Label ID="lblmrsno" runat="server" Text='<%#Eval("MRSNo") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="12%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Gen. By">
                        <ItemTemplate>
                        <asp:Label ID="lblgenby" runat="server" Text='<%#Eval("GenBy") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="45%" HorizontalAlign="Left" />
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
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

