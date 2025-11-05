<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_TourVoucher_Delete, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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
            <td align="left" height="21" style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite">
                <b>&nbsp;Tour Voucher Delete </b></td>
               
        </tr>
        
        
         <tr>
             <td align="left" height="25" valign="middle">
        
            &nbsp;
        
            <asp:DropDownList ID="DrpField" runat="server" 
                onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True" 
                CssClass="box3">                
                <asp:ListItem Value="Select">Select</asp:ListItem> 
                 <asp:ListItem Value="5">TV No </asp:ListItem>            
                <asp:ListItem Value="0">TI No </asp:ListItem>
                <asp:ListItem Value="1">Employee Name</asp:ListItem>  
                <asp:ListItem Value="2">WO No </asp:ListItem>           
                <asp:ListItem Value="3">BG Group </asp:ListItem>  
                <asp:ListItem Value="4">Project Name </asp:ListItem>  
                               
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="TxtMrs" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
            &nbsp;<asp:TextBox ID="TxtEmpName" runat="server" Width="250px" CssClass="box3"></asp:TextBox>
                  &nbsp;<asp:DropDownList ID="drpGroup" runat="server" CssClass="box3"></asp:DropDownList>
       &nbsp;<cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
        
                  <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Search" 
                     CssClass="redbox" />  
            </td>   
        
        </tr>
        
        
        <tr>
            <td colspan="2">
    <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    AutoGenerateColumns="False" AllowPaging="True" Width="99%" DataKeyNames="Id" 
        onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
        <Columns>
            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> 
                        </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
                        </asp:TemplateField>   
                        
             <asp:TemplateField >
            <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="Del"  Text="Delete"></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>       
                  
            
            <asp:TemplateField HeaderText="Fin Year">
            <ItemTemplate>
            <asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField Visible="False">
            <ItemTemplate>
            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            
              <asp:TemplateField Visible="False">
            <ItemTemplate>
            <asp:Label ID="lblTIMId" runat="server" Text='<%# Eval("TIMId") %>'></asp:Label>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>           
            
            <asp:TemplateField  HeaderText="TV No">
            <ItemTemplate>
               <%-- <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="Sel"  Text='<%# Eval("TVNo") %>'></asp:LinkButton> --%> 
                <asp:Label ID="lblTVNo" runat="server" Text='<%# Eval("TVNo") %>'></asp:Label>
                
                       
            </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
            
            
             <asp:TemplateField  HeaderText="TI No">
            <ItemTemplate>
            <asp:Label ID="lblTINo" runat="server" Text='<%# Eval("TINo") %>'></asp:Label>
            </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
            
            <asp:TemplateField  HeaderText="Emp Name">
            <ItemTemplate>
            <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
            </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            
             <asp:TemplateField  HeaderText="WO No">
            <ItemTemplate>
            <asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
            </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
            
            <asp:TemplateField  HeaderText="BG Group">
            <ItemTemplate>
            <asp:Label ID="lblBGGroup" runat="server" Text='<%# Eval("BGGroup") %>'></asp:Label>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
            
             <asp:TemplateField  HeaderText="Project Name">
            <ItemTemplate>
            <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
            </ItemTemplate>
            
                 <ItemStyle Width="10%" />
            
            </asp:TemplateField>
            
            
             <asp:TemplateField  HeaderText="Place of Tour">
            <ItemTemplate>
            <asp:Label ID="lblPlaceOfTour" runat="server" Text='<%# Eval("PlaceOfTour") %>'></asp:Label>
            </ItemTemplate>
                 <ItemStyle Width="15%" />
            </asp:TemplateField>
            
             <asp:TemplateField  HeaderText="Tour Start Date">
            <ItemTemplate>
            <asp:Label ID="lblTourStartDate" runat="server" Text='<%# Eval("TourStartDate") %>'></asp:Label>
            </ItemTemplate> <ItemStyle HorizontalAlign="Center" Width="6%" />
            </asp:TemplateField>
             <asp:TemplateField  HeaderText="Tour End Date">
            <ItemTemplate>
            <asp:Label ID="lblTourEndDate" runat="server" Text='<%# Eval("TourEndDate") %>'></asp:Label>
            </ItemTemplate> <ItemStyle HorizontalAlign="Center" Width="6%" />
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

