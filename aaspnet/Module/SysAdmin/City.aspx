<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysAdmin_City, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <table align="left" cellpadding="0" cellspacing="0" width="100%" >
        <tr>
            <td>
                 <table cellpadding="0" cellspacing="0" width="600px" align="center">
     <tr>
            <td align="left" valign="middle" style="background:url(../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;City</b></td>
        </tr>
    
        <tr>
            <td align="center" class="style2" height="25" valign="middle">
                <b>Country :
                  <asp:DropDownList ID="DrpCountry" runat="server"   Width="150px" 
                       AutoPostBack="True" 
                      onselectedindexchanged="DrpCountry_SelectedIndexChanged" CssClass="box3" ></asp:DropDownList>   
            &nbsp;&nbsp; State :</b>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="Drpstate" runat="server"  Width="150px" 
                    AutoPostBack="True" onselectedindexchanged="Drpstate_SelectedIndexChanged" 
                    CssClass="box3" >
                </asp:DropDownList>
            </td>
            </tr>       
             
                
              
        <tr>
            <td align="center" valign="top" colspan="1" width="100%" >
            <asp:GridView runat="server" AllowPaging="True"  Width="100%"
                            AutoGenerateColumns="False" ShowFooter="True" 
                            CssClass="yui-datatable-theme"  ID="GridView1" 
                    onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowdeleted="GridView1_RowDeleted" onrowdeleting="GridView1_RowDeleting" 
                    onrowupdated="GridView1_RowUpdated" PageSize="17"><Columns>
                                <asp:CommandField ShowEditButton="True" ValidationGroup="SG" ButtonType="Link" >
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:CommandField>
                                <asp:TemplateField><ItemTemplate>
 <asp:LinkButton runat="server" ID="btndel" OnClientClick="return confirmationDelete()"  CommandName="Del"  Text="Delete"  /> 
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
</asp:TemplateField>         
                                
                                <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id">
                        <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("CityId") %>'>    </asp:Label>
                        </ItemTemplate>                        
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>  
                                <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <FooterTemplate>                        
                                        </FooterTemplate>                                       
                                        <HeaderStyle HorizontalAlign="Center" />                                       
                                        <ItemStyle HorizontalAlign="Right" Width="4%" />
                                        <FooterStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                
                          <asp:TemplateField HeaderText="City Name" SortExpression="CityName">
                        <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("CityName") %>'>    
                        </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtName1" CssClass="box3" runat="server" Text='<%#Bind("CityName") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqName0" runat="server" ControlToValidate="txtName1" ValidationGroup="SG"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtName" runat="server"  CssClass="box3">
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqName" runat="server" ValidationGroup="A" ControlToValidate="txtName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                           <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="A" CommandName="Add" 
                        OnClientClick=" return confirmationAdd()"  CssClass="redbox" />
                        
                        </FooterTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                                
            </Columns>
            
            <EmptyDataTemplate>
            
            <table>
            <tr>
                        <td>           
            <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="B" CommandName="Add1" 
                        OnClientClick=" return confirmationAdd()"  CssClass="redbox" />
            </td>
            <td>           
            <asp:TextBox ID="txtName" runat="server"  CssClass="box3">
                        </asp:TextBox>                        
                         <asp:RequiredFieldValidator ID="ReqName1" runat="server" ValidationGroup="B" ControlToValidate="txtName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            </tr>
            
            </table>
                     
                           
        </EmptyDataTemplate> 
            
            </asp:GridView>
            
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

