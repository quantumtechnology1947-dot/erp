<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysAdmin_State, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
 <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />    
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    
   
           
    <table align="left" cellpadding="0" cellspacing="0"  width="100%">
        <tr>
            <td>
                 <table cellpadding="0" cellspacing="0" width="600px" align="center">        
        <tr>
            <td align="left" valign="middle" style="background:url(../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp; State</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="SId" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                
              OnRowUpdated="GridView1_RowUpdated" 
              OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                    onrowdeleting="GridView1_RowDeleting" PageSize="16">
                    
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                         <asp:CommandField  ButtonType="Link" ShowEditButton="True"  ValidationGroup ="SG" >
                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                        </asp:CommandField>
                        <asp:TemplateField><ItemTemplate>
 <asp:LinkButton runat="server" ID="btndel" OnClientClick="return confirmationDelete()"  CommandName="Del"  Text="Delete"  /> 
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
</asp:TemplateField>         
                        <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id">
                        <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("SId") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" 
                         OnClientClick=" return confirmationAdd()"  ValidationGroup="A" CssClass="redbox" />
                                         </FooterTemplate>                                     
                                        <HeaderStyle HorizontalAlign="Center" />                                       
                                        <ItemStyle HorizontalAlign="Right" Width="4%" />
                                        <FooterStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Country Name" SortExpression="CountryName">
                        <ItemTemplate>
                        <asp:DropDownList ID="DrpCountry" Width="100%" runat="server" DataSourceID="SqlDataSource1" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList>                   
                        </ItemTemplate>
                        <ItemStyle  Width="12%"/>
                        <EditItemTemplate>
                           <asp:DropDownList ID="DrpCountry1" runat="server" DataSourceID="SqlDataSource1" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList>                     
                        </EditItemTemplate>
                        
                         <FooterTemplate>
                         <asp:DropDownList ID="DrpCountry2" Width="100%" runat="server" DataSourceID="SqlDataSource1" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList> 
                        </EditItemTemplate>
                        </FooterTemplate>
                           <FooterStyle Width="12%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="State Name" SortExpression="StateName">
                        <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("StateName") %>'>    
                        </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblName0" runat="server" CssClass="box3"  Text='<%#Bind("StateName") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqName0" runat="server" ControlToValidate="lblName0" ValidationGroup="SG"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtName" runat="server" CssClass="box3">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqName" runat="server" ValidationGroup="A" ControlToValidate="txtName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        </FooterTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        
                       
                    </Columns>
                    
                     <EmptyDataTemplate>
                     <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add1" 
                         OnClientClick=" return confirmationAdd()"  ValidationGroup="B" CssClass="redbox" />
                         <asp:DropDownList ID="DrpCountry2" Width="100%" runat="server" DataSourceID="SqlDataSource1" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList> 
                         <asp:TextBox ID="txtName" runat="server" CssClass="box3">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqName" runat="server" ValidationGroup="B" ControlToValidate="txtName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
        </EmptyDataTemplate>     
                    
              </asp:GridView>
                
                <%--<asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    DeleteCommand="DELETE FROM [tblState] WHERE [SId] = @SId" 
                    InsertCommand="INSERT INTO [tblState] ([StateName],[CId]) VALUES (@StateName,@CId)" 
                    SelectCommand="SELECT * FROM [tblState]" 
                    
                    UpdateCommand="UPDATE [tblState] SET [StateName] = @StateName,[CId] =@CId WHERE [SId] = @SId">
                    <DeleteParameters>
                        <asp:Parameter Name="SId" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="StateName" Type="String" />
                        <asp:Parameter Name="CId" Type="Int32" />
                        <asp:Parameter Name="SId" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="StateName" Type="String"/>
                          <asp:Parameter Name="CId" Type="Int32" />
                    </InsertParameters>
                </asp:SqlDataSource>--%>
                
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT * FROM [tblCountry]"   ></asp:SqlDataSource>
             
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
    </table></td>
        </tr>
    </table>
    
   
           
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

