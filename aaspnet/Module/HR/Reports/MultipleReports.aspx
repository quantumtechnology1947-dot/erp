<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Reports_MultipleReports, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table width="120%">
      
  
    <tr>
            <td class="fontcsswhite" height="25" valign="middle" >
            
                <asp:DropDownList ID="DrpCriteria" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCriteria_SelectedIndexChanged" Height="21px" 
                    CssClass="box3">
                    
                     <asp:ListItem Value="Select" >Select</asp:ListItem>
                     
                     <asp:ListItem Value="tblHR_Departments.DeptName">Department</asp:ListItem>
                      <asp:ListItem Value="BusinessGroup.BGGroup">BusinessGroup</asp:ListItem>
                      <asp:ListItem Value="tblHR_Designation.Designation">Designation</asp:ListItem>
                       <asp:ListItem Value="tblHR_Grade.Symbol">Grade</asp:ListItem>
                    
                </asp:DropDownList> 
                
                 &nbsp;<asp:DropDownList ID="DrpSubCriteria" runat="server" Width="200px" 
                    Height="21px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSubCriteria_SelectedIndexChanged">
                    
                </asp:DropDownList>
            
                &nbsp;&nbsp;<asp:DropDownList ID="DrpSearch" runat="server" Height="21px" 
                    Width="200px" CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearch_SelectedIndexChanged">
                  <asp:ListItem Value="Select" >Select</asp:ListItem>
                     <asp:ListItem Value="0">EmpId</asp:ListItem>
                     <asp:ListItem Value="1">EmployeeName</asp:ListItem>
                       <asp:ListItem Value="2">Gender</asp:ListItem>
                       <asp:ListItem Value="3">MobileNo</asp:ListItem>
                     <asp:ListItem Value="4">SwapCardNo</asp:ListItem>
                     <asp:ListItem Value="5">Resigned</asp:ListItem>
                    
                </asp:DropDownList>
<asp:TextBox ID="txtEmpName" runat="server" CssClass="box3" Visible="False" Width="250px"></asp:TextBox>
                             
                            <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtEmpName" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
            
                <asp:TextBox ID="txtSearch" runat="server" Width="207px" 
                    CssClass="box3" Height="18px"></asp:TextBox>
                
        &nbsp;&nbsp;&nbsp;&nbsp;
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>
  
  
 <tr>
 
 
 <td>
  
 <asp:GridView ID="GridView2" runat="server" AllowPaging="True"  OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
         Width="100%" onrowcommand="GridView2_RowCommand" PageSize="20">
                 <PagerSettings PageButtonCount="40" />
                 <Columns>
                                                 
                            <%--<asp:HyperLinkField DataNavigateUrlFields="EmpId"  DataNavigateUrlFormatString="~/Module/HR/Transactions/OfficeStaff_Print_Details.aspx?EmpId={0}&ModId=12&SubModId="  Text="Select" />--%>
                           <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> 
                        </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" Text="select" CommandName="sel" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fin Year">
                            <ItemTemplate>
                            <asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>                          
                        <asp:TemplateField HeaderText="Emp Id">
                            <ItemTemplate>
                            <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        
                        <%--<asp:BoundField DataField="EmpId" HeaderText="EmpId" />--%>
                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                        <asp:BoundField DataField="DeptName" HeaderText="Dept" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        <asp:BoundField DataField="BGGroup" HeaderText="BG Group" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                        <asp:BoundField DataField="Grade" HeaderText="Grade" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="Gender" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        <asp:BoundField DataField="EmailId1" HeaderText="ERP Mail" />
                        <asp:BoundField DataField="EmailId2" HeaderText="Email Id" />                 
                        <asp:BoundField DataField="SwapCardNo" HeaderText="SwapCard No" />
                        <asp:TemplateField HeaderText="Joining Date  " SortExpression="  JoiningDate  ">
                    <ItemTemplate>
                        <asp:Label ID="lblJoinDate" runat="server" Text='<%# Bind("JoiningDate") %>'></asp:Label>
                    </ItemTemplate>                   
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>                
                            <asp:TemplateField HeaderText="Resign Date" SortExpression="ResignationDate">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ResignationDate") %>'></asp:Label>
                                </ItemTemplate>
                               
                                <ItemStyle HorizontalAlign="Center" />
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

