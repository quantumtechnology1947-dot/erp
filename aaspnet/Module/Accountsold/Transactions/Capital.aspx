<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Capital.aspx.cs" Inherits="Module_Accounts_Transactions_Capital" Title="ERP"  Theme ="Default"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Capital</b></td>
        </tr>
        <tr>
        <td>

        <table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px">
            <tr>
                <td 
                    height="10" colspan="2" valign="middle" ><b>&nbsp;&nbsp;&nbsp; </b>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    </td>
                <td 
                    height="10" colspan="2" valign="middle" >&nbsp;&nbsp;&nbsp;&nbsp;
                </td></tr>
             
             <tr>
                <td class="fontcss" valign="top" width="49%"  align ="center">
                    <asp:Panel ID="Panel1" Height="449px" ScrollBars="Auto" runat="server"> 
                    
                                       
                <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                Width="98%" AllowPaging="True" PageSize="24" onrowcommand="GridView2_RowCommand" 
                            ShowFooter="True">
                
                    <PagerSettings PageButtonCount="40" />
                
                <Columns>
                                    
                    <asp:TemplateField HeaderText="SN">
                    <ItemTemplate><%#Container.DataItemIndex+1  %>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />                  
                    </asp:TemplateField>               
   
                
                <asp:TemplateField ShowHeader="False"  >
               


                     <ItemTemplate>
                     <asp:LinkButton ID="LinkBtnDel"  runat="server" CausesValidation="False" OnClientClick="return confirmationDelete();"
                     CommandName="Del" Text="Delete">
                    </asp:LinkButton>
                    </ItemTemplate>  

                    
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%" />

                    
                      <FooterTemplate >
                    <asp:Button ID="btnInsert" runat="server" CommandName="Add" ValidationGroup ="Insert"
                    OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                    </FooterTemplate>
                        
                         <FooterStyle HorizontalAlign="Center" />
                     </asp:TemplateField>          
                         
                    <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate>
                    
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="5%" />
                     </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="Particulars" >
                    <ItemTemplate>
                    
                     <asp:LinkButton ID="LinkBtnPerticulars"  runat="server" CausesValidation="False"
                      CommandName="HpPerticulars" Text='<%# Bind("Perticulars") %>'>
                    </asp:LinkButton>
                    
                    </ItemTemplate>
                    
                  <FooterTemplate >
                   
                <asp:TextBox CssClass="box3" Width="95%" ID="TextPerticulars2" runat="server" >
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTextPerticulars2" runat="server" 
                ControlToValidate="TextPerticulars2" 
                ValidationGroup="Insert" ErrorMessage="*"></asp:RequiredFieldValidator> 
                
                </FooterTemplate>
                        
                         <FooterStyle HorizontalAlign="Left" />
                        
                    <ItemStyle HorizontalAlign="Left" Width="80%" />
                    </asp:TemplateField>
                    
                        </Columns>
                        
                        
            <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                        <td align="center" style="width:70px" >
                     <asp:Label ID="LabelSN" Font-Bold="true" Font-Size="Medium"
                      Font-Names="Times New Roman" 
                        runat="server" Text="SN"></asp:Label>
                        </td>
                        
                    <td align="center" >
                        <asp:Label ID="LabelPerticulars" Font-Bold="true" Font-Size="Medium"
                         Font-Names="Times New Roman" 
                        runat="server" Text="Particulars"></asp:Label>
                        </td>
        
                    </tr>
                    <tr>
                    <td align="center">
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1"
                 OnClientClick=" return confirmationAdd() " ValidationGroup="empt"
                 CssClass="redbox" Text="Insert" />
                </td>
                
                 <td align="Left">                         

                <asp:TextBox CssClass="box3" Width="95%" ID="TextPerticulars1" runat="server" >
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTextPerticulars1" runat="server" 
                ControlToValidate="TextPerticulars1" 
                ValidationGroup="empt" ErrorMessage="*"></asp:RequiredFieldValidator>                      
                                 
                </td>
    
          
                </tr>
                </table>
                
            </EmptyDataTemplate> 
                        
                        <FooterStyle Font-Bold="False" HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="9pt" />
                        </asp:GridView>
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, Particulars from tblACC_Capital_Master">
                        </asp:SqlDataSource>
                        
                 </asp:Panel></td>
                <td class="fontcss" valign="top" width="20" colspan="2">
                    &nbsp; </td>
                <td class="fontcss" valign="top" width="49%">
                       
                    <asp:Panel ID="Panel2" Height="434px" ScrollBars="Auto" runat="server">                  
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" CssClass="box3" 
                            Height="20px" HorizontalAlign="Center" Visible="False">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" 
                                Text="No data found   !"></asp:Label>
                        </asp:Panel>
                              
                              <asp:GridView ID="GridView3" runat="server" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView3_PageIndexChanging" 
                Width="98%" AllowPaging="True" PageSize="22" onrowcommand="GridView3_RowCommand" 
                            ShowFooter="True">
                
                    <PagerSettings PageButtonCount="40" />
                
                <Columns>
                                    
                    <asp:TemplateField HeaderText="SN">
                    <ItemTemplate><%#Container.DataItemIndex+1  %>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />                  
                    </asp:TemplateField> 
                    
                    <asp:TemplateField ShowHeader="False"  >
              
                     <ItemTemplate>
                     <asp:LinkButton ID="LinkBtnDelp"  runat="server" CausesValidation="False" OnClientClick="return confirmationDelete();"
                      CommandName="Delp" Text="Delete">
                    </asp:LinkButton>
                    </ItemTemplate>  

                    
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="7%" />

                    
                      <FooterTemplate >
                    <asp:Button ID="btnInsertp" runat="server" CommandName="Addp" ValidationGroup ="Insertp"
                    OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                    </FooterTemplate>
                        
                         <FooterStyle HorizontalAlign="Center" />
                     </asp:TemplateField>          
                         
                    <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label
                     ID="lblIdp" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="5%" />
                     </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Particulars" >
                    <ItemTemplate>
                       <asp:Label ID="lblPerticulars" runat="server" Text='<%# Bind("Perticulars") %>'></asp:Label> 
                    </ItemTemplate>

                    <FooterTemplate >

                    <asp:TextBox CssClass="box3" Width="95%" ID="TextPerticularsp2" runat="server" >
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqTextPerticularsp2" runat="server" 
                    ControlToValidate="TextPerticularsp2" 
                    ValidationGroup="Insertp" ErrorMessage="*"></asp:RequiredFieldValidator> 

                    </FooterTemplate>

                     <FooterStyle HorizontalAlign="Left" />

                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Credit" >
                    <ItemTemplate>
                       <asp:Label ID="lblCreditAmt" runat="server" Text='<%# Bind("CreditAmt") %>'></asp:Label> 
                    </ItemTemplate>

                    <FooterTemplate >

                    <asp:TextBox CssClass="box3" Width="80%" ID="TextCreditAmtp2" runat="server" >
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqTextCreditAmtp2" runat="server" 
                    ControlToValidate="TextCreditAmtp2" 
                    ValidationGroup="Insertp" ErrorMessage="*"></asp:RequiredFieldValidator> 
                    
                     <asp:RegularExpressionValidator ID="RegTextCreditAmtp2" runat="server" 
                        ControlToValidate="TextCreditAmtp2" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Insertp">
                     </asp:RegularExpressionValidator>
                    </FooterTemplate>

                     <FooterStyle HorizontalAlign="Left" />

                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:TemplateField>           
                    
                    
                           <asp:TemplateField HeaderText="MId" Visible="False">
                           <ItemTemplate>
                           <asp:Label   ID="lblMIdp" runat="server" Text='<%# Bind("MId") %>'></asp:Label>
                           </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="5%" />
                     </asp:TemplateField>
                    
                        </Columns>
                        
                        
            <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                        <td align="center" style="width:70px" >
                     <asp:Label ID="LabelSNp" Font-Bold="true" Font-Size="Medium"
                      Font-Names="Times New Roman" 
                        runat="server" Text="SN"></asp:Label>
                        </td>
                        
                    <td align="center" >
                        <asp:Label ID="LabelPerticularsp" Font-Bold="true" Font-Size="Medium"
                         Font-Names="Times New Roman" 
                        runat="server" Text="Particulars"></asp:Label>
                        </td>
                       <td align="center" >
                        <asp:Label ID="LabelCredit" Font-Bold="true" Font-Size="Medium"
                         Font-Names="Times New Roman" 
                        runat="server" Text="Credit"></asp:Label>
                        </td>
        
        
                    </tr>
                    <tr>
                    <td align="center">
                <asp:Button ID="btnInsertp" runat="server" CommandName="Addp1"
                 OnClientClick=" return confirmationAdd() " ValidationGroup="emptp"
                 CssClass="redbox" Text="Insert" />
                </td>
                
                 <td align="Left">                         

                <asp:TextBox CssClass="box3" Width="95%" ID="TextPerticularsp1" runat="server" >
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTextPerticularsp1" runat="server" 
                ControlToValidate="TextPerticularsp1" 
                ValidationGroup="emptp" ErrorMessage="*"></asp:RequiredFieldValidator>                      
                                 
                </td>
                     <td align="Left"  style="width:120px">                         

                <asp:TextBox CssClass="box3" Width="80%" ID="TextCreditAmtp1" runat="server" Text="0" >
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTextCreditAmtp1" runat="server" 
                ControlToValidate="TextCreditAmtp1" 
                ValidationGroup="emptp" ErrorMessage="*"></asp:RequiredFieldValidator>                      
                   <asp:RegularExpressionValidator ID="RegTextCreditAmtp1" runat="server" 
                        ControlToValidate="TextCreditAmtp1" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="emptp">
                     </asp:RegularExpressionValidator>               
                </td>
          
                </tr>
                </table>
                
            </EmptyDataTemplate> 
                        
                        <FooterStyle Font-Bold="False" HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="9pt" />
                        </asp:GridView>
                       <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, Particulars from tblACC_Capital_Details">
                        </asp:SqlDataSource>
                        
                        
                    </asp:Panel>
                </td>
            </tr></table>
                  
        </td>
        </tr>
        </table>


 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

