<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_HolidayMaster, newerp_deploy" title="ERP" theme="Default" %>
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

<table cellpadding="0" cellspacing="0" width="50%" align="center" >
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
       
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Holiday Master</b></td>
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
                DataSourceID="SqlDataSource1"
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="17" 
                    onrowupdating="GridView1_RowUpdating">
                    
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
                        
                         
 
                        
                        <asp:TemplateField HeaderText="Date">

                        <ItemTemplate>  
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("HDate") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="TxtDate" Width="85%" CssClass="box3" runat="server" Text='<%#Bind("HDate") %>'>
                        </asp:TextBox>  
                         <cc1:CalendarExtender ID="TxtDate_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDate" CssClass="cal_Theme2" PopupPosition="BottomLeft">
                        </cc1:CalendarExtender>
                                              
                         <asp:RegularExpressionValidator ID="RegTxtDate" runat="server" ControlToValidate="TxtDate"
                         ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  
                         ValidationGroup="edit"  ErrorMessage="*">
                        </asp:RegularExpressionValidator>
                        
                        <asp:RequiredFieldValidator ID="ReqTxtDate" runat="server" ControlToValidate="TxtDate"
                         ValidationGroup="edit" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>                 
                         <asp:TextBox ID="TxtDate0" runat="server" Width="85%"  CssClass="box3"></asp:TextBox>
                         
                        <cc1:CalendarExtender ID="TxtDate0_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDate0" CssClass="cal_Theme2" PopupPosition="BottomLeft">
                        </cc1:CalendarExtender>
                        
                        <asp:RegularExpressionValidator ID="RegTxtDate0" runat="server" ControlToValidate="TxtDate0"
                         ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  
                         ValidationGroup="abc"  ErrorMessage="*">
                        </asp:RegularExpressionValidator>   
                        
                         <asp:RequiredFieldValidator ID="ReqTxtDate0" runat="server" ControlToValidate="TxtDate0"
                         ValidationGroup="abc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                             
                        </FooterTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>                   
                        

                        <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="TxtTitle" Width="95%" CssClass="box3" runat="server" Text='<%#Bind("Title") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqTxtTitle" runat="server" ControlToValidate="TxtTitle" 
                        ValidationGroup="edit" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtTitle0" CssClass="box3" Width="95%" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtTitle0" runat="server" ControlToValidate="txtTitle0"
                             ValidationGroup="abc" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                        </FooterTemplate>
                         <ItemStyle Width="80%" />
                        </asp:TemplateField>
                        
                    </Columns>
                    
                    
                    
                     <EmptyDataTemplate>
                <table  width="100%" border="1" style=" border-color:Gray">
                    <tr>
                    <td></td>
                     <td align="center" style="width:17%">
                        <asp:Label ID="lblDate1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Date">
                        </asp:Label>
                        </td>
                    <td align="center" style="width:70%" >
                        <asp:Label ID="lblTitle1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Title">
                        </asp:Label>
                        </td>
                    </tr>
                    <tr>
                 <td style="width:2%">
                <asp:Button ID="btnInsert" runat="server" ValidationGroup="pqr" CommandName="Add1"
                OnClientClick=" return confirmationAdd()"  CssClass="redbox" Text="Insert" />
                </td>
                
                   <td>
                &nbsp
                <asp:TextBox ID="TxtDate1" CssClass="box3" runat="server" Width="80px"></asp:TextBox>
                 <cc1:CalendarExtender ID="TxtDate1_CalendarExtender" runat="server"  CssClass="cal_Theme2" 
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDate1" PopupPosition="BottomLeft">
                        </cc1:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegTxtDate1" runat="server" ControlToValidate="TxtDate1"
                         ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  
                         ValidationGroup="pqr"  ErrorMessage="*">
                        </asp:RegularExpressionValidator>
                          <asp:RequiredFieldValidator ID="RequTxtDate1" runat="server" ControlToValidate="TxtDate1" 
                          ValidationGroup="pqr"
                 ErrorMessage="*">
                 </asp:RequiredFieldValidator>
                        
                </td>
                
                 <td>
                &nbsp
                <asp:TextBox ID="TxtTitle1" CssClass="box3" runat="server" Width="95%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTxtTitle1" runat="server" ControlToValidate="TxtTitle1" ValidationGroup="pqr"
                 ErrorMessage="*">
                 </asp:RequiredFieldValidator>
                        
                </td>
         
           </tr>
           </table>
        </EmptyDataTemplate>
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblHR_Holiday_Master] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblHR_Holiday_Master] ([Title], [HDate],[SysDate],[SysTime],[SessionId],[CompId] ,[FinYearId]) VALUES (@Title, @HDate,@SysDate,@SysTime,@SessionId,@CompId,@FinYearId )" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT Id,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( [tblHR_Holiday_Master].HDate , CHARINDEX('-',[tblHR_Holiday_Master].HDate ) + 1, 2) + '-' + LEFT([tblHR_Holiday_Master].HDate,CHARINDEX('-',[tblHR_Holiday_Master].HDate) - 1) + '-' + RIGHT([tblHR_Holiday_Master].HDate, CHARINDEX('-', REVERSE([tblHR_Holiday_Master].HDate)) - 1)), 103), '/', '-') AS  HDate,SysTime,SessionId,CompId,FinYearId,HDate,Title FROM [tblHR_Holiday_Master] WHERE [CompId]=@CompId AND [FinYearId]=@FinYearId ORDER BY [Id] DESC" 
                    UpdateCommand="UPDATE [tblHR_Holiday_Master] SET [Title] = @Title,[HDate] = @HDate,[SysDate]=@SysDate,[SysTime]=@SysTime,[SessionId]=@SessionId,[CompId]=@CompId ,[FinYearId]=@FinYearId WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Title" Type="String" />
                         <asp:Parameter Name="Id" Type="Int32" />
                          <asp:Parameter Name="HDate" Type="String"/>
                          <asp:Parameter Name="SysDate" Type="String"/>
                          <asp:Parameter Name="SysTime" Type="String"/>
                          
                         <asp:SessionParameter Name="CompId" DbType="Int32" SessionField="compid" />
                        <asp:SessionParameter Name="SessionId" DbType="String" SessionField="username" />
                         <asp:SessionParameter Name="FinYearId" DbType="Int32" SessionField="finyear" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Title" Type="String"/>
                        <asp:Parameter Name="HDate" Type="String"/>
                         <asp:Parameter Name="SysDate" Type="String"/>
                        <asp:Parameter Name="SysTime" Type="String"/>
                        <asp:Parameter Name="Id" Type="Int32" />                        
                        <asp:SessionParameter Name="CompId" DbType="Int32" SessionField="compid" />
                        <asp:SessionParameter Name="SessionId" DbType="String" SessionField="username" />
                         <asp:SessionParameter Name="FinYearId" DbType="Int32" SessionField="finyear" />
                        
                    </InsertParameters>
                    
                    <SelectParameters>
                    <asp:SessionParameter Name="CompId" DbType="Int32" SessionField="compid" />                      
                    <asp:SessionParameter Name="FinYearId" DbType="Int32" SessionField="finyear" />
                    </SelectParameters>
                    
                </asp:SqlDataSource>
                
             
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
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

