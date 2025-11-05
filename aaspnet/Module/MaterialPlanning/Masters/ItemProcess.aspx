<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialPlanning_Masters_ItemProcess, newerp_deploy" title="ERP" theme="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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

<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" align="center" style="width: 40%">
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                            &nbsp;Material Process</b>
                        </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True" PageSize="15"
                ShowFooter="True"  DataKeyNames="Id"
                AutoGenerateColumns="False" 
                FooterStyle-Wrap="True" 
               OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" 
                    Width="100%" onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                    onrowupdating="GridView1_RowUpdating" 
                    onrowdatabound="GridView1_RowDataBound1" onrowdeleted="GridView1_RowDeleted" 
                    onrowupdated="GridView1_RowUpdated">
                    
            <FooterStyle Wrap="True"></FooterStyle>
            
            <Columns> 
                     
                    <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                     <FooterTemplate>
                    <asp:Button ID="btnInsert" runat="server" CommandName="Add"  CssClass="redbox" 
                     OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="SG" />                      
                    </FooterTemplate>
                    
                    <HeaderStyle Font-Size="10pt" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" />
                    </asp:TemplateField>
                    
                     <asp:CommandField ShowEditButton="True"  >
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1"  OnClientClick=" return confirmationDelete()" runat="server" CausesValidation="false" 
                                CommandName="Del" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                    
                    
                    <asp:TemplateField HeaderText="Name of Process">
                    <ItemTemplate>
                    <asp:Label ID="lblProcessName" runat="server" Text='<%# Eval("ProcessName") %>'></asp:Label>                    
                  </ItemTemplate>
                  <EditItemTemplate>
                  <asp:TextBox ID ="txtPName" runat ="server" Width="95%"   CssClass="box3" Text='<%# Eval("ProcessName") %>'
                     ValidationGroup="A" >
                    </asp:TextBox>
                     <asp:RequiredFieldValidator ID="ReqProcessName" runat="server" ValidationGroup="A" ControlToValidate="txtPName" 
                    ErrorMessage="*">
                    </asp:RequiredFieldValidator> 
                  
                  </EditItemTemplate>
                  
                   <FooterTemplate>
                    <asp:TextBox ID="txtProcessName1" Width="95%" CssClass="box3" runat="server" ValidationGroup="SG">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqProcessName1" runat="server" ValidationGroup="SG" ControlToValidate="txtProcessName1" 
                    ErrorMessage="*">
                    </asp:RequiredFieldValidator>                     
                    </FooterTemplate>
                    <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
                    </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Symbol">
                    <ItemTemplate>
                    <asp:Label ID="lblSymbol" runat="server" Text='<%# Eval("Symbol") %>'></asp:Label>
                    
                     </ItemTemplate>
                     <EditItemTemplate>
                     <asp:TextBox ID ="txtSymbol" CssClass="box3" Width="95%" runat ="server"  Text='<%# Eval("Symbol") %>'
                     ValidationGroup="A">
                    </asp:TextBox>
                     <asp:RequiredFieldValidator ID="ReqSymbol" ValidationGroup="A" runat="server" ControlToValidate="txtSymbol" 
                        ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                     
                     </EditItemTemplate>
                     
                      <FooterTemplate>
                        <asp:TextBox ID="txtSymbol1" Width="95%" CssClass="box3" runat="server" ValidationGroup="SG">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqSymbol" ValidationGroup="SG" runat="server" ControlToValidate="txtSymbol1" 
                        ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                        </FooterTemplate>
                    <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
                    </asp:TemplateField>                    
                    
                    <asp:TemplateField HeaderText="Id"   Visible="false">
                    <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </ItemTemplate>  
                    <ItemStyle VerticalAlign="Top" HorizontalAlign="Right" />
                    </asp:TemplateField>
                                        
                     
            
            </Columns>
            
            <EmptyDataTemplate>
            
            <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Name of Process"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Symbol"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="UOM Basic"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
            <asp:Button ID="btnInsert1" runat="server" CommandName="Add1"  CssClass="redbox" 
                     OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="SG1" />  
                     </td>
                     <td>
            <asp:TextBox ID="txtName" Width="95%" runat="server" CssClass="box3"></asp:TextBox>
             <asp:RequiredFieldValidator ID="ReqSymbol" ValidationGroup="SG1" runat="server" ControlToValidate="txtName" 
                        ErrorMessage="*">
                        </asp:RequiredFieldValidator>
            </td>
            <td>
            <asp:TextBox ID="txtSymbol"  Width="95%" runat="server"  CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SG1" runat="server" ControlToValidate="txtSymbol" 
                        ErrorMessage="*">
                        </asp:RequiredFieldValidator></td>
            <td>
            <asp:DropDownList ID="DDLBasic" runat="server" Width="95%" CssClass="box3" 
                    DataSourceID="SqlDataSource2" DataTextField="Symbol" DataValueField="Id">
                    </asp:DropDownList></td>                    
                    </table>
            </EmptyDataTemplate>
            
              </asp:GridView>
              
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="SELECT * FROM [Unit_Master]">
                </asp:SqlDataSource>

                <asp:Label ID="lblmsg" runat="server"></asp:Label>

            </td>
            </tr>  
       
    </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>