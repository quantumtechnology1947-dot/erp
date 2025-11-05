<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Delete, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />  
     <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

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
    <table  width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Quality Note [MRQN] - Delete</b></td>
        </tr>
        <tr>
                    <td height="25">

                   &nbsp;
                    <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                     AutoPostBack="True" onselectedindexchanged="drpfield_SelectedIndexChanged">
                     <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">MRQN No</asp:ListItem>
                    <asp:ListItem Value="1">MRN No</asp:ListItem>
                    <asp:ListItem Value="2">Employee Name</asp:ListItem>
                    
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="txtEmpName" runat="server" CssClass="box3" Visible="False" Width="250px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                    ServicePath="" TargetControlID="txtEmpName" UseContextKey="True"
                    CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" 
                    MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True"  CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                    </cc1:AutoCompleteExtender>
                    &nbsp;<asp:TextBox ID="txtMqnNo" runat="server" CssClass="box3"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="redbox"  Text="Search" 
                            onclick="Button1_Click" />                        
                    </td>
                    </tr>
        <tr>
            <td align="Left">
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="99%" 
                    onrowcommand="GridView1_RowCommand" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="20" >
                    <PagerSettings PageButtonCount="40" />
                <Columns>
                <asp:TemplateField HeaderText="SN"> <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                  
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" CommandName="Sel"  runat="server" Text="Select" ></asp:LinkButton>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Id"  Visible="false" ><ItemTemplate><asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' ></asp:Label></ItemTemplate></asp:TemplateField>
                
                
                 <asp:TemplateField HeaderText="FinYear Id"  Visible="false" ><ItemTemplate><asp:Label ID="lblFyId" runat="server" Text='<%# Eval("FinYearId") %>' ></asp:Label></ItemTemplate></asp:TemplateField>
                 <asp:TemplateField HeaderText="FinYear" ><ItemTemplate><asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYear") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                
              <asp:TemplateField HeaderText="MRQN No" ><ItemTemplate><asp:Label ID="lblMRQNNo" runat="server" Text='<%# Eval("MRQNNo") %>' ></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                 <asp:TemplateField HeaderText="Date" ><ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Eval("SysDate") %>' ></asp:Label></ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                  
                 <asp:TemplateField HeaderText="MRN No" ><ItemTemplate><asp:Label ID="lblMRNNo" runat="server" Text='<%# Eval("MRNNo") %>' ></asp:Label></ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
               
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
              
                             </asp:GridView>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

