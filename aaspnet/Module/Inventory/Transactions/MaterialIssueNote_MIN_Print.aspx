<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialIssueNote_MIN_Print, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            width: 1200px;
            height: 31px;
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

<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" ><b>&nbsp;Material Issue Note [MIN] - Print</b></td>
        </tr>
            <tr>
        <td align="left" class="style2">
        
            &nbsp;
        
            <asp:DropDownList ID="DrpField" runat="server" 
                onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True">
               <asp:ListItem Value="Select">Select</asp:ListItem>
               <asp:ListItem Value="0">MRS No</asp:ListItem>
               <asp:ListItem Value="1">MIN No</asp:ListItem>
              <asp:ListItem Value="2">Employee Name</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TxtMrs" runat="server" CssClass="box3" Width="150px"></asp:TextBox>
            <asp:TextBox ID="TxtEmpName" runat="server" CssClass="box3" Width="250px"></asp:TextBox>
          
              
       <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
            &nbsp;
        
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Search" CssClass="redbox" />
                </td>
        </tr>
        
        
        <tr>
            <td align="Left">
            
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    onrowcommand="GridView1_RowCommand" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="20" >
                    <PagerSettings PageButtonCount="40" />
                <Columns>
                <asp:TemplateField HeaderText="SN"> 
                <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                  
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Sel"  runat="server" Text="Select" ></asp:LinkButton>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Id"  Visible="false" >
                <ItemTemplate>
                <asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' ></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
                
                 <asp:TemplateField HeaderText="FinYear Id"  Visible="false" >
                 <ItemTemplate>
                 <asp:Label ID="lblFyId" runat="server" Text='<%# Eval("FinYearId") %>' ></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="FinYear" >
                 <ItemTemplate>
                 <asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYear") %>' ></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="MIN No" >
                 <ItemTemplate>
                 <asp:Label ID="lblMINNo" runat="server" Text='<%# Eval("MINNo") %>' ></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Date" >
                 <ItemTemplate>
                 <asp:Label ID="lblDate" runat="server" Text='<%# Eval("SysDate") %>' ></asp:Label>
                 </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                  
                 <asp:TemplateField HeaderText="MRS No" >
                 <ItemTemplate>
                 <asp:Label ID="lblMRSNo" runat="server" Text='<%# Eval("MRSNo") %>' ></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
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
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

