<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_WorkingDays, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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

<table cellpadding="0" cellspacing="0" width="35%" align="center" >
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
       
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Working Days</b></td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
               
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="17" 
                    onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
                    onrowdeleting="GridView1_RowDeleting" 
                    onrowcancelingedit="GridView1_RowCancelingEdit">
                    
                <FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:CommandField  ButtonType="Link" ValidationGroup="edit" 
                            ShowEditButton="True" >
                            <ItemStyle Width="3%" />
                        </asp:CommandField>
                        
                         <asp:CommandField ShowDeleteButton="True" ButtonType="Link" 
                            ValidationGroup="edit"   >
                             <ItemStyle Width="3%" />
                        </asp:CommandField>
                        
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>  <%# Container.DataItemIndex+1 %>  </ItemTemplate>
                           <FooterTemplate>
                            <asp:Button ID="btnInsert" runat="server" ValidationGroup="abc" 
                                OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" Text="Insert" Width ="42px" />
                            </FooterTemplate>                            
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>                      
                         
                        
                        <asp:TemplateField HeaderText="Fin Year">

                        <ItemTemplate>  
                        <asp:Label ID="lblFinYearId" runat="server" Text='<%#Eval("FinYear") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                       <%-- <EditItemTemplate>
                         <asp:Label ID="lblFinYearId1" Visible="false" runat="server" Text='<%#Eval("FinYearId") %>'>    </asp:Label>
                          <asp:DropDownList ID="DptYear1"  runat="server" CssClass="box3" 
                    DataSourceID="SqlDataSource2" DataTextField="FinYear" 
                    DataValueField="FinYearId">
                          </asp:DropDownList>   
                        </EditItemTemplate>--%>
                        
                        <FooterTemplate>                 
                          <asp:DropDownList ID="DptYear"  runat="server" CssClass="box3" 
                    DataSourceID="SqlDataSource2" DataTextField="FinYear" 
                    DataValueField="FinYearId">
                          </asp:DropDownList> 
                        </FooterTemplate>
                            <ItemStyle Width="10%"  HorizontalAlign="Center" />
                            <FooterStyle Width="10%"  HorizontalAlign="Center" />
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Month" SortExpression="Title">
                        <ItemTemplate>
                        <asp:Label ID="lblMonthId" runat="server" Text='<%#Eval("MonthId") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                      <%--  <EditItemTemplate>
                           <asp:DropDownList ID="ddlMonth1" runat="server" CssClass="box3" DataSourceID="SqlDataSource3"
                             DataTextField="Month" DataValueField="Id">
                            </asp:DropDownList>
                             <asp:Label ID="lblMonthId1" Visible="false" runat="server" Text='<%#Eval("MonthId") %>'>    </asp:Label>
                        </EditItemTemplate>
                        --%>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box3" ><%--DataSourceID="SqlDataSource3"
                             DataTextField="Month" DataValueField="Id"--%>
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemStyle Width="20%"  HorizontalAlign="Center" />
                        <FooterStyle Width="20%"  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="Days" SortExpression="Title">
                        <ItemTemplate>
                        <asp:Label ID="lblDays" runat="server" Text='<%#Eval("Days") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                         <asp:TextBox ID="txtDays1" CssClass="box3" Width="60%" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtDays1" runat="server" ControlToValidate="txtDays1"
                             ValidationGroup="edit" ErrorMessage="*">
                             </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegtxtDays1" runat="server" 
                                ControlToValidate="txtDays1" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit" >
                                </asp:RegularExpressionValidator>
                                
                                 <asp:Label ID="lblDays1" runat="server" Visible="false" Text='<%#Eval("Days") %>'>    </asp:Label>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtDays" CssClass="box3" Width="70%" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtDays" runat="server" ControlToValidate="txtDays"
                             ValidationGroup="abc" ErrorMessage="*">
                             </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegtxtDays" runat="server" 
                                ControlToValidate="txtDays" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="abc">
                                </asp:RegularExpressionValidator>
                        </FooterTemplate>
                         <ItemStyle Width="10%"  HorizontalAlign="Right" />
                         <FooterStyle Width="10%"  HorizontalAlign="Left" />
                         
                        </asp:TemplateField>                       
                        
                        
                    </Columns>
                    
                    
                    
                     <EmptyDataTemplate>
                <table  width="100%" border="1" style=" border-color:Gray">
                    <tr>
                    <td></td>
                     <td align="center" style="width:30%">
                        <asp:Label ID="lblFinYearId2" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Fin Year">
                        </asp:Label>
                        </td>
                        
                    <td align="center" style="width:30%" >
                        <asp:Label ID="lblMonthId2" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Month">
                        </asp:Label>
                        </td>
                        
                         <td align="center" style="width:20%" >
                        <asp:Label ID="lblDays2" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Days">
                        </asp:Label>
                        </td>
                    </tr>
                    <tr>
                 <td style="width:10%">
                <asp:Button ID="btnInsert" runat="server" ValidationGroup="pqr" CommandName="Add1"
                OnClientClick=" return confirmationAdd()"  CssClass="redbox" Text="Insert" />
                </td>
                
                   <td  align="center">
                &nbsp
                   <asp:DropDownList ID="DptYear2" DataSourceID="SqlDataSource2" DataTextField="FinYear" 
                    DataValueField="FinYearId" runat="server" CssClass="box3">
                          </asp:DropDownList> 
                </td>
                
                 <td  align="center">
                &nbsp
             <asp:DropDownList ID="ddlMonth2" runat="server" CssClass="box3" ><%--DataSourceID="SqlDataSource3"
            
              DataTextField="Month" DataValueField="Id"--%>
                         
                            </asp:DropDownList>
                        
                </td>
           <td>
                &nbsp
              <asp:TextBox ID="txtDays2" CssClass="box3" Width="60%" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtDays2" runat="server" ControlToValidate="txtDays2"
                             ValidationGroup="abc" ErrorMessage="*">
                             </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegtxtDays2" runat="server" 
                                ControlToValidate="txtDays2" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="pqr">
                                </asp:RegularExpressionValidator>
                        
                </td>
           </tr>
           </table>
        </EmptyDataTemplate>
                    
              </asp:GridView>
                
        
                
             
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [FinYear], [FinYearId] FROM [tblFinancial_master] WHERE ([CompId] = @CompId) ORDER BY [FinYearId] DESC">
                    <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                
                  <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Id],[Month] FROM [tblHR_Months]">
                  
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
    </table>
    
    
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

