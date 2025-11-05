<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BudgetHrsFields.aspx.cs" Inherits="Module_MIS_Transaction_BudgetHrsFields" Title="ERP" Theme="Default"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
            height: 21px;
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
            <td>
     
         <table cellpadding="0" cellspacing="0" width="100%" align="center">
       
        <tr>
            <td align="Left" valign="top" width="45%"  class="style2" style="background:url(../../../images/hdbg.JPG)" >
                <b>&nbsp;Field Category</b></td>
            <td align="center" valign="top" width="0.1%">
                &nbsp;</td>
            <td align="Left" valign="top" width="55%"class="style2" style="background:url(../../../images/hdbg.JPG)" >
                <b>&nbsp;Field Sub-Category</b></td>
        </tr>
        <tr>
            <td align="center" valign="top" width="45%" height="440">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                DataSourceID="LocalSqlServer"
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                    Width="100%" PageSize="17" onrowupdating="GridView1_RowUpdating">

                    <Columns>

                      <%--  <asp:CommandField   ButtonType="Link" ShowDeleteButton="True" ShowEditButton="True" />--%>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btnInsert" runat="server" CommandName="Add" ValidationGroup="Ins" OnClientClick=" return confirmationAdd() " CssClass="redbox" 
                                    Text="Insert" />
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                      <asp:CommandField    ButtonType ="Link" ShowEditButton="True" 
                            ValidationGroup="up" >
                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                       <asp:CommandField    ButtonType ="Link" ShowDeleteButton="True"   >

                           <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:CommandField>

                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="95%" ID="txtCategory0" runat="server" Text='<%#Bind("Category") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqtxtCategory0" runat="server" ControlToValidate="txtCategory0" 
                        ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtCategory" Width="95%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtCategory" runat="server" ControlToValidate="txtCategory" 
                            ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                            <ItemStyle Width="60%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="95%" ID="txtSymbol0" runat="server" Text='<%#Bind("Symbol") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqtxtSymbol0" runat="server" ControlToValidate="txtSymbol0" 
                        ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtSymbol" Width="95%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtSymbol" runat="server" ControlToValidate="txtSymbol" 
                            ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                            <ItemStyle Width="60%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                    </Columns>

<FooterStyle Wrap="True"></FooterStyle>
             <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center" >
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="Category"></asp:Label></td>           
    
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                </td>
                
                <td>
                <asp:TextBox ID="txtCate" runat="server" Width="85%"></asp:TextBox>
                
                </td>              
 <td>
                <asp:TextBox ID="txtSymbol" runat="server" Width="85%"></asp:TextBox>
                
                </td>    
                </tr>
                </table>
                
            </EmptyDataTemplate>                    
            </asp:GridView>               
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>               
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblMIS_BudgetHrs_Field_Category] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblMIS_BudgetHrs_Field_Category] ([Category],[Symbol]) VALUES (@Category,@Symbol)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [tblMIS_BudgetHrs_Field_Category] where Id!=1 order by [Id] desc" 
                    UpdateCommand="UPDATE [tblMIS_BudgetHrs_Field_Category] SET [Category] = @Category, [Symbol]=@Symbol  WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Category" Type="String" /> 
                        <asp:Parameter Name="Symbol" Type="String" />                   
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Category" Type="String"/>
                        <asp:Parameter Name="Symbol" Type="String" />                   
                    </InsertParameters>
                </asp:SqlDataSource>
               </td>
            <td align="center" valign="top" width="0.1%">
                &nbsp;</td>
            <td align="center" valign="top" width="55%">
                <asp:GridView ID="GridView2" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView2_RowDeleted" 
                DataSourceID="SqlDataSource11"
                OnRowUpdated="GridView2_RowUpdated" 
                OnRowCommand="GridView2_RowCommand"
                CssClass="yui-datatable-theme" onrowdatabound="GridView2_RowDataBound" 
                    Width="100%" PageSize="17" onrowupdating="GridView2_RowUpdating">

                    <Columns>

                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btnInsert_sb" runat="server" CommandName="Add_sb" ValidationGroup="sb" 
                                OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                      <asp:CommandField    ButtonType ="Link" ShowEditButton="True" 
                            ValidationGroup="sbe" >
                          <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:CommandField>
                       <asp:CommandField    ButtonType ="Link" ShowDeleteButton="True"   >

                           <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:CommandField>

                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCategory_sb" runat="server" Text='<%#Eval("Category") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>                       
                        <asp:DropDownList ID="ddCategory_sbe" runat="server" DataSourceID="SqlDataSource2" 
                         SelectedValue='<%# Bind("MId") %>'  DataTextField="Category" DataValueField="Id">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddCategory_sbe" runat="server" ControlToValidate="ddCategory_sbe" 
                        ValidationGroup="sbe" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>                        
                        <asp:DropDownList ID="ddCategory_sb" runat="server" DataSourceID="SqlDataSource2"
                         DataTextField="Category" DataValueField="Id">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddCategory_sb" runat="server" ControlToValidate="ddCategory_sb" 
                        ValidationGroup="sb" ErrorMessage="*"></asp:RequiredFieldValidator>
              
                        </FooterTemplate>                        
                            <ItemStyle Width="6%" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Sub-Category" SortExpression="SubCategory">
                        <ItemTemplate>
                        <asp:Label ID="lblSubCategory_sb" runat="server" Text='<%#Eval("SubCategory") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="90%" ID="txtSubCategory_sb" runat="server" Text='<%#Bind("SubCategory") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqtxtSubCategory_sb" runat="server" ControlToValidate="txtSubCategory_sb" 
                        ValidationGroup="sbe" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtSubCategory_sb0" Width="95%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtSubCategory_sb0" runat="server" ControlToValidate="txtSubCategory_sb0" 
                            ValidationGroup="sb" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>                        
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="90%" ID="txtSymbol" runat="server" Text='<%#Bind("Symbol") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqtxtSymbol" runat="server" ControlToValidate="txtSymbol" 
                        ValidationGroup="sbe" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtSymbol0" Width="95%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtSymbol0" runat="server" ControlToValidate="txtSymbol0" 
                            ValidationGroup="sb" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>                        
                            <ItemStyle Width="25%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                    </Columns>

<FooterStyle Wrap="True"></FooterStyle>
             <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                     <td align="center" >
                        <asp:Label ID="Label4" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="Category"></asp:Label></td>
                      <td align="center" >
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="Sub-Category"></asp:Label></td>
                      
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnInsert_sb1" runat="server" CommandName="Add_sb1" OnClientClick=" return confirmationAdd() "
                 CssClass="redbox" Text="Insert" ValidationGroup="sb1" />
                </td>
                 <td>
                  <asp:DropDownList ID="ddCategory_sb1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Category" DataValueField="Id">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddCategory_sb1" runat="server" ControlToValidate="ddCategory_sb1" 
                        ValidationGroup="sb1" ErrorMessage="*"></asp:RequiredFieldValidator>
       
                </td>
                <td>
                <asp:TextBox ID="txtCate_sb1" runat="server" Width="85%" ValidationGroup="sb1"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqtxtCate_sb1" runat="server" ControlToValidate="txtCate_sb1" 
                        ValidationGroup="sb1" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
               <td>
                <asp:TextBox ID="txtSymbol1" runat="server" Width="85%" ValidationGroup="sb1"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqtxtSymbol" runat="server" ControlToValidate="txtSymbol1" 
                        ValidationGroup="sb1" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                </tr>
                </table>
                
            </EmptyDataTemplate>                    
            </asp:GridView>               
                <asp:Label ID="lblMessage1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>               
                <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblMIS_BudgetHrs_Field_SubCategory] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblMIS_BudgetHrs_Field_SubCategory] ([MId],[SubCategory],[Symbol]) VALUES (@MId,@SubCategory,@Symbol)" 
                    ProviderName="System.Data.SqlClient" 
                    
                    SelectCommand="SELECT tblMIS_BudgetHrs_Field_Category.Category, tblMIS_BudgetHrs_Field_SubCategory.SubCategory,tblMIS_BudgetHrs_Field_SubCategory.Symbol, tblMIS_BudgetHrs_Field_SubCategory.Id, tblMIS_BudgetHrs_Field_SubCategory.MId FROM tblMIS_BudgetHrs_Field_Category INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId order by tblMIS_BudgetHrs_Field_Category.Id,tblMIS_BudgetHrs_Field_SubCategory.Id ASC"
                    
                    UpdateCommand="UPDATE [tblMIS_BudgetHrs_Field_SubCategory] SET [MId] = @MId, [SubCategory] = @SubCategory, [Symbol] = @Symbol WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="MId" Type="Int32" />
                        <asp:Parameter Name="SubCategory" Type="String" />  
                        <asp:Parameter Name="Symbol" Type="String" />                 
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="MId" Type="Int32" />
                        <asp:Parameter Name="SubCategory" Type="String"/>
                        <asp:Parameter Name="Symbol" Type="String" />                     
                    </InsertParameters>
                </asp:SqlDataSource>             
               
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="select Id,Category from tblMIS_BudgetHrs_Field_Category">    
                </asp:SqlDataSource>
               </td>
        </tr>
        </table>
         
            </td>
        </tr>
        <tr>
            <td align="center" height="22">
     
                 <asp:Button runat="server" Text="Cancel" CssClass="redbox" Width="60px" ID="btnCancel1" OnClick="btnCancel1_Click"></asp:Button>

                        
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

