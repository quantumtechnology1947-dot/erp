<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysSupport_SystemCredentials, newerp_deploy" title="ERP" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/styles.css" rel="stylesheet" type="text/css" />

    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

    <table width ="100%" cellpadding=0 cellspacing=0 >
        <tr>
       <td  align="left" valign="middle" style="background:url(../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;System Credentials - New</b></td>
        </tr>
       <tr>
       <td>
       
<cc1:TabContainer ID="TabContainer1" runat="server" Height="434px" ActiveTabIndex="0" 
               AutoPostBack="true" Width="100%" 
               onactivetabchanged="TabContainer1_ActiveTabChanged" >
<cc1:TabPanel runat="server" HeaderText="New" ID="TabPanel1"> 
    
<ContentTemplate>

<table width="100%">
<tr>
<td height="29" valign="middle">
<b>Employee Name:</b> <asp:TextBox ID="txtName" Width="300px" runat="server" 
        CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>                                 
                                 &nbsp;
                                 <asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
        onclick="Button1_Click" Text="Search" />
</td>
</tr>
<tr>

<td width="60%" valign="top">
    <asp:GridView ID="GridView1" Width="100%" CssClass="yui-datatable-theme" 
            PageSize="15"  runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="UserID" 
        DataSourceID="SqlDataSource1" onrowcommand="GridView1_RowCommand"><Columns>
        
        <asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" /></asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="UserID" Visible="False" InsertVisible="False" 
                SortExpression="UserID"><ItemTemplate><asp:Label ID="lblUID" runat="server" Text='<%# Bind("UserID") %>'></asp:Label></ItemTemplate><ItemStyle Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="EmpId" SortExpression="EmpId"><ItemTemplate><asp:LinkButton ID="lnkId" CommandName="sel" runat="server" Text='<%# Bind("EmpId") %>'></asp:LinkButton></ItemTemplate>
            <ItemStyle Width="10%" HorizontalAlign="Center" /></asp:TemplateField><asp:BoundField DataField="Employee" HeaderText="Employee Name" ReadOnly="True" 
                SortExpression="Employee" ><ItemStyle Width="30%" /></asp:BoundField><asp:BoundField DataField="CompanyEmail" HeaderText="Email Id" 
                SortExpression="CompanyEmail" ><ItemStyle Width="20%" /></asp:BoundField><asp:BoundField DataField="Department" HeaderText="Department" 
                SortExpression="Department" ><ItemStyle Width="14%" 
                HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="Designation" HeaderText="Designation" 
                SortExpression="Designation" >
            <ItemStyle Width="16px" 
                    HorizontalAlign="Center" /></asp:BoundField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate>
    </asp:GridView><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT tblHR_OfficeStaff.UserID, tblHR_OfficeStaff.EmpId, tblHR_OfficeStaff.Title + '.' + tblHR_OfficeStaff.EmployeeName AS Employee, tblHR_OfficeStaff.CompanyEmail, tblHR_Departments.Symbol AS Department, tblHR_Designation.Type AS Designation FROM tblHR_OfficeStaff INNER JOIN tblHR_Designation ON tblHR_OfficeStaff.Designation = tblHR_Designation.Id INNER JOIN tblHR_Departments ON tblHR_OfficeStaff.Department = tblHR_Departments.Id WHERE (tblHR_OfficeStaff.ResignationDate = '') AND (tblHR_OfficeStaff.UserID NOT IN(Select MId from tblSystemCredentials)) order By EmpId Desc" FilterExpression="EmpId = '{0}'"><FilterParameters><asp:Parameter Name="EmpId" Type="String" /></FilterParameters></asp:SqlDataSource></td>
 
 <td Width="40%" valign="Top">
     <asp:Panel ID="Panel1" runat="server" 
         BackColor="#CCFFFF" BorderStyle="Solid" 
                        BorderWidth="1px" Height="310px" >
             <table width="100%">             
            <tr>
            <td  colspan="2" height="20px">
            </td>
            </tr> 
             <tr>
            <td colspan="2">&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Name :"></asp:Label>
                <asp:Label ID="lblempId" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            </tr> 
                 <tr>
                
                     <td colspan="2"> &nbsp;&nbsp;
                         <asp:Label ID="lblDate" runat="server" style="font-weight: 700" Text="Date :"></asp:Label>
                         <asp:Label ID="lbl_Date" runat="server" style="font-weight: 700"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2" height="3px">
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         <table bgcolor="#99FFCC" border="1" frame="box" style="width:100%;"><tr><td align="center" colspan="2"><b>
                             System Login</b></td></tr><tr><td class="style4"><asp:Label ID="sysUserName" 
                                     runat="server" Font-Bold="True" Text="User Id"></asp:Label></td><td class="style4">
                                     <asp:Label ID="txtSysName" runat="server" Font-Bold="True" ForeColor="#9900CC" 
                                         style="font-weight: 700" Width="135px"></asp:Label>
                                 </td></tr><tr><td><asp:Label ID="SysPass" runat="server" Font-Bold="True" 
                                     Text="PassWord"></asp:Label></td><td><asp:TextBox ID="txtSysPassword" 
                                         runat="server" Width="140px" CssClass="box3" Height="15px" 
                                         ForeColor="#9900CC"></asp:TextBox><asp:RequiredFieldValidator ID="ReqSysPass" runat="server" 
                                         ControlToValidate="txtSysPassword" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td colspan="2">
                                 &nbsp;</td></tr></table></td>
                     <td><table bgcolor="#99FF99" border="1" frame="box" style="width:100%;"><tr>
                         <td align="center" colspan="2" height="22px"><b>
                         ERP</b><b> Login</b></td></tr><tr><td><asp:Label ID="erpUserName" runat="server" 
                                 Font-Bold="True" Text="User Id"></asp:Label></td><td>
                                 <asp:Label ID="txterpName" runat="server" ForeColor="#9900CC" 
                                     style="font-weight: 700" Width="140px"></asp:Label>
                             </td></tr><tr><td><asp:Label ID="erpPass" runat="server" Font-Bold="True" 
                                 Text="PassWord"></asp:Label></td><td>
                                 <asp:Label ID="txterpPassword" runat="server" ForeColor="#9900CC" 
                                     style="font-weight: 700" Width="140px"></asp:Label>
                             </td></tr><tr><td colspan="2">
                             &nbsp;</td></tr></table></td>
                 </tr>
                 <tr>
                     <td colspan="2" height="3px">
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2" align="center">
                         <table bgcolor="#FFFFCC" border="1" frame="box" width="65%">
                             <tr>
                                 <td align="center"  colspan="2">
                                     <b> Email</b><b> Login</b></td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     <asp:Label ID="erpUserName0" runat="server" Font-Bold="True" Text="User Id"></asp:Label>
                                 </td>
                                 <td align="left">
                                          <asp:TextBox ID="txtemailName" runat="server"  Width="275px" ForeColor="#9900CC"
                                         CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqemailName" runat="server" 
                                         ControlToValidate="txtemailName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                              ControlToValidate="txtemailName" ErrorMessage="*" 
                                              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                              ValidationGroup="A"></asp:RegularExpressionValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     <asp:Label ID="erpPass0" runat="server" Font-Bold="True" Text="PassWord"></asp:Label>
                                 </td>
                                 <td align="left">
                                     <asp:Label ID="txtemailPassword" runat="server" ForeColor="#9900CC" 
                                         style="font-weight: 700" Width="300px"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="2">
                                     &nbsp;</td>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr>
                     <td align="center" colspan="2" height="27px">
                         <asp:Button ID="btn_Save" runat="server" CssClass="redbox" 
                             OnClick="btn_Save_Click" Text="Save" ValidationGroup="A" Width="56px" />
                     </td>
                 </tr>
             </table>           
                        
                        
                        
                        
                        
                        </asp:Panel></td></tr></table>
 

    </ContentTemplate>
                    
</cc1:TabPanel>
<cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="View">                        
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td height="29" valign="middle">
<b>Employee Name:</b> <asp:TextBox ID="txtName1" Width="300px" runat="server" 
        CssClass="box3"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="TxtEmpName1_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtName1" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
    <asp:Button ID="btnSearch1" runat="server" CssClass="redbox" 
        onclick="btnSearch1_Click" Text="Search" />
    <asp:Button ID="btnExport" runat="server" CssClass="redbox" Text="Export" 
        OnClick="btnPrint_Click" />
</td>
</tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView2" 
                runat="server" 
                AllowPaging="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"
                OnRowDeleted="GridView2_RowDeleted" 
                DataSourceID="LocalSqlServer"
                OnRowUpdated="GridView2_RowUpdated" 
                CssClass="yui-datatable-theme" onrowdatabound="GridView2_RowDataBound" 
                    Width="100%" PageSize="15" onrowupdating="GridView2_RowUpdating" 
                    onrowcommand="GridView2_RowCommand">

                    <Columns>

                        <asp:TemplateField HeaderText="SN">
                  
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton5" OnClientClick="return confirmationUpdate();" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update">
                                </asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>


                        <asp:TemplateField ShowHeader="False">
                          <ItemTemplate>
                              <asp:LinkButton ID="LinkButton2" OnClientClick="return confirmationDelete();" CommandName="Delete" Text="Delete" 
                                  runat="server" CausesValidation="False"></asp:LinkButton>            
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="print" 
                                    Text="Print"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False" >
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Date" SortExpression="SysDate" >
                            <ItemTemplate>
                                <asp:Label ID="lblSysDate" runat="server" Text='<%#Eval("SysDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                        
                                              
                         <asp:TemplateField HeaderText="EmpId" SortExpression="EmpId" >
                            <ItemTemplate>
                                <asp:Label ID="lblEmpId" runat="server" Text='<%#Eval("EmpId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        
                        
                                              
                        <asp:TemplateField HeaderText="Employee Name" SortExpression="Employee">
                                           
                        <ItemTemplate>
                        <asp:Label ID="lblEmployee" runat="server" Text='<%#Eval("Employee") %>'></asp:Label>
                        </ItemTemplate>
                                           
                            <ItemStyle HorizontalAlign="Left" />
                                           
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Sys Passwd" SortExpression="SysPwd">
                           
                        <ItemTemplate>
                        <asp:Label ID="lblSysPwd" runat="server" Text='<%#Eval("SysPwd") %>'>    </asp:Label>
                        </ItemTemplate>
                           
                        <EditItemTemplate>
                        <asp:TextBox ID="lblSysPwd0" Width="85%" CssClass="box3" runat="server" 
                                Text='<%#Bind("SysPwd") %>'> </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqSysPwd" runat="server" 
                                ControlToValidate="lblSysPwd0" ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="ERP Passwd" SortExpression="ERPPwd">
                          
                          
                        <ItemTemplate>
                        <asp:Label ID="lblERPPwd" runat="server" Text='<%#Eval("ERPPwd") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblERPPwd0" Width="85%" CssClass="box3" runat="server" 
                                Text='<%#Bind("ERPPwd") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqERPPwd" runat="server" 
                                ControlToValidate="lblERPPwd0" ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                         
                         
                        </EditItemTemplate>
                          
                          
                             <ItemStyle HorizontalAlign="Center" Width="8%" />
                          
                          
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Email Id" SortExpression="EmailId">
                           
                        <ItemTemplate>
                        <asp:Label ID="lblEmailId" runat="server" Text='<%#Eval("EmailId") %>'>    </asp:Label>
                        </ItemTemplate>
                           
                        <EditItemTemplate>
                        <asp:TextBox ID="lblEmailId0" Width="85%" CssClass="box3" runat="server" 
                                Text='<%#Bind("EmailId") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqEmailId" runat="server" 
                                ControlToValidate="lblEmailId0" ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="Reg1" runat="server" 
                                ControlToValidate="lblEmailId0" ErrorMessage="*" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="up"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                           
                             <ItemStyle Width="18%" />
                           
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Email Passwd" SortExpression="EmailPwd">
                            <ItemTemplate>
                                <asp:Label ID="lblEmailPwd" runat="server" Text='<%#Eval("EmailPwd") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="lblEmailPwd0" runat="server" CssClass="box3" 
                                    Text='<%#Bind("EmailPwd") %>' Width="85%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqEmailPwd" runat="server" 
                                    ControlToValidate="lblEmailPwd0" ErrorMessage="*" ValidationGroup="up"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
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

<FooterStyle Wrap="True"></FooterStyle>
                </asp:GridView>               
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>               
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblSystemCredentials] WHERE [Id] = @Id" 
                   
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT  ROW_NUMBER() Over (Order by Id) As SN, tblSystemCredentials.Id,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblSystemCredentials.SysDate , CHARINDEX('-',tblSystemCredentials.SysDate ) + 1, 2) + '-' + LEFT(tblSystemCredentials.SysDate,CHARINDEX('-',tblSystemCredentials.SysDate) - 1) + '-' + RIGHT(tblSystemCredentials.SysDate, CHARINDEX('-', REVERSE(tblSystemCredentials.SysDate)) - 1)), 103), '/', '-') AS  SysDate,tblHR_OfficeStaff.Title+'. '+tblHR_OfficeStaff.EmployeeName AS Employee,tblHR_OfficeStaff.EmpId,tblSystemCredentials.SysPwd, tblSystemCredentials.ERPPwd, tblSystemCredentials.EmailId, tblSystemCredentials.EmailPwd FROM tblSystemCredentials INNER JOIN tblHR_OfficeStaff ON tblSystemCredentials.MId = tblHR_OfficeStaff.UserID  ORDER BY tblSystemCredentials.Id Desc" FilterExpression="EmpId='{0}'"
                    UpdateCommand="UPDATE [tblSystemCredentials] SET [SysPwd] = @SysPwd, [ERPPwd] = @ERPPwd,[EmailId]=@EmailId,[EmailPwd]=@EmailPwd WHERE [Id] = @Id">
      
                    <FilterParameters>
                    <asp:Parameter Name="EmpId" Type="String" />
                    </FilterParameters>
      
                    <DeleteParameters>
                    
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
      
                    <UpdateParameters>
                        <asp:Parameter Name="SysPwd" Type="String" />
                        <asp:Parameter Name="ERPPwd" Type="String" />
                        <asp:Parameter Name="EmailId" Type="String" /> 
                        <asp:Parameter Name="EmailPwd" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
               </td>
        </tr>
    </table>
    </ContentTemplate>
                    
</cc1:TabPanel>

<cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Print">                        
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>     
                   
 <iframe id="Iframe1"  runat ="server" width="100%" height="420px" frameborder="0" 
                   scrolling="auto" ></iframe>
</td>
</tr>
<tr>
<td valign="top" align="center"  >
     <asp:Button ID="BtnCancel1"  runat="server"  CssClass="redbox" 
                            onclick="BtnCancel1_Click"  Text="Cancel"   /></td></tr> 
    </table>
    </ContentTemplate>
                    
</cc1:TabPanel>
                    
</cc1:TabContainer>
       
       </td>      
       
       </tr>
     
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

