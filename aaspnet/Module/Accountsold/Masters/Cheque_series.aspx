<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cheque_series.aspx.cs" Inherits="Module_Accounts_Masters_Cheque_series" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

   
   
    <table align="center" style="width: 100%">
    
        <tr align="center">
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp; Cheque Series </b></td>
        </tr>
        <tr align="center">
            <td align="center" valign="top">
               <asp:GridView ID="GridView1"  Width="60%"
                runat="server" 
                AllowPaging="True"
                ShowFooter="True"
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
               
              OnRowUpdated="GridView1_RowUpdated" 
              OnRowCommand="GridView1_RowCommand"
              CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                    onrowupdating="GridView1_RowUpdating" 
                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                    onrowcancelingedit="GridView1_RowCancelingEdit">
                    
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Link"  ShowEditButton="True" ValidationGroup="C"/>
                        <asp:CommandField   ButtonType="Link" ShowDeleteButton="True"  />
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id" >
                        <ItemTemplate>
                       <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert"  ValidationGroup="A"
                         OnClientClick="return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Bank Name" >
                        <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                                        <asp:Label ID="lblBankId" Visible="false"  runat="server" Text='<%#Eval("BankId") %>'>    </asp:Label>
                      <asp:DropDownList ID="DrpBank" Width="100%"  AutoPostBack="True"   runat="server"     DataSourceID="SqlDataSource2" DataValueField="Id" DataTextField="Name" ></asp:DropDownList> 
                       
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:DropDownList ID="DrpBank1" Width="100%"  AutoPostBack="True"   runat="server"     DataSourceID="SqlDataSource2" DataValueField="Id" DataTextField="Name" ></asp:DropDownList> 
                        </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Start No">
                        <ItemTemplate>
                        <asp:Label ID="lblStartNo" runat="server" Text='<%#Eval("StartNo") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtStartNo" Width="60%" runat="server" Text='<%#Bind("StartNo") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqValue" ValidationGroup="C" ControlToValidate="txtStartNo"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>                         

                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtStartNo1" runat="server" Width="88%">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqValue1" ValidationGroup="A" ControlToValidate="txtStartNo1"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                                                    
				            
            				
                        </FooterTemplate>
                           
                            <ItemStyle Width="15%" />
                           
                        </asp:TemplateField>
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                              <asp:TemplateField HeaderText="End No">
                        <ItemTemplate>
                        <asp:Label ID="lblEndNo" runat="server" Text='<%#Eval("EndNo") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtEndNo" Width="60%" runat="server" Text='<%#Bind("EndNo") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqValu2" ValidationGroup="C" ControlToValidate="txtEndNo"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>                         

                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtEndNo1" runat="server" Width="88%">
                        </asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="ReqValue3" ValidationGroup="A" ControlToValidate="txtEndNo1"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                                                    
				            
            				
                        </FooterTemplate>
                           
                            <ItemStyle Width="15%" />
                           
                        </asp:TemplateField>
                        
                        
                    </Columns>
                    <EmptyDataTemplate>
                    <table>
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Bank Name"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Start No"></asp:Label></td>
                 
                        <td align="center">
                         <asp:Label ID="Label3" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="End No"></asp:Label></td>
                 
               </tr>
               <tr>
                    <td>
                   <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="B" OnClientClick="return confirmationAdd()" CommandName="Add1" CssClass="redbox" /></td>
                <td>
                   
                          <asp:DropDownList ID="DrpBank2" Width="100%"  AutoPostBack="True"   runat="server"     DataSourceID="SqlDataSource2" DataValueField="Id" DataTextField="Name" ></asp:DropDownList> 
                   
                 </td>
                   <td>
                   <asp:TextBox ID="txtStartNo3" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="Reqvalue11" ValidationGroup="B" ControlToValidate="txtStartNo3" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                    
                     </td>
                     
                      <td>
                   <asp:TextBox ID="txtEndNo3" runat="server" Width="80%" />
                     <asp:RequiredFieldValidator ID="Reqvalue12" ValidationGroup="B" ControlToValidate="txtEndNo3" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>
                               	         
                    
                     </td>
                     </tr>
                     </table>
                   </EmptyDataTemplate>
              </asp:GridView>
                            
              <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_ChequeNo] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblACC_ChequeNo] ([BankId], [StartNo],[EndNo]) VALUES (@BankId,@StartNo, @EndNo)" 
                    SelectCommand="SELECT * FROM [tblACC_ChequeNo] order by [Id] desc" 
                    UpdateCommand="UPDATE [tblACC_ChequeNo] SET [Terms] = @Terms, [Value] = @Value WHERE [Id] = @Id" 
                    ProviderName="System.Data.SqlClient">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="BankId" Type="Int32" />
                        <asp:Parameter Name="StartNo" Type="Int32" />
                        <asp:Parameter Name="EndNo" Type="Int32" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                      <asp:Parameter Name="BankId" Type="Int32" />
                        <asp:Parameter Name="StartNo" Type="Int32" />
                        <asp:Parameter Name="EndNo" Type="Int32" />
                    </InsertParameters>
                </asp:SqlDataSource>--%>
                </td>
        </tr>
   <tr>
            <td align="center">
                
    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT * FROM [tblACC_Bank]"   ></asp:SqlDataSource>
            </td>
            </td>
        </tr>
    </table>
<br />    
            
              

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

