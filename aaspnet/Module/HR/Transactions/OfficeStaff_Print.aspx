<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_OfficeStaff_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
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

        <table align="left" cellpadding="0" cellspacing="0" class="style2">
            <tr>
                <td align="left" valign="middle" 
                    style="background:url(../../../images/hdbg.JPG)" height="21" 
                    class="fontcsswhite"><b>&nbsp;Staff - Print</b></td>
            </tr>
            <tr>
             <td align="left">
        
            <asp:DropDownList ID="DrpField" runat="server" 
                onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True" 
                CssClass="box3">
                 <%--<asp:ListItem Value="Select">Select</asp:ListItem>--%>
               <asp:ListItem Value="0">Employee Name</asp:ListItem>
               <asp:ListItem Value="1">Dept Name</asp:ListItem>
               <asp:ListItem Value="2">BG Group </asp:ListItem>
                               
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="TxtMrs" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
            &nbsp;<asp:TextBox ID="TxtEmpName" runat="server" Width="250px" CssClass="box3"></asp:TextBox>
                  
       <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                             <asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Search" />
                           
            &nbsp;<asp:Button ID="btnExportToExcel" runat="server" CssClass="redbox" 
                     onclick="btnExportToExcel_Click" Text="Export" />
                           
            </td>
        
        </tr>
            
            
            <tr>
                <td>

        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CssClass="yui-datatable-theme"  Width="100%" 
                        onrowcommand="GridView2_RowCommand" 
                        onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
            <PagerSettings PageButtonCount="40" />
            <Columns>
               
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> 
                        </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle>
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
                <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="UserID" Visible="False" />
               <asp:TemplateField HeaderText="EmpId">
                            <ItemTemplate>
                            <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                <asp:TemplateField HeaderText="Emp Name" SortExpression="EmployeeName">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpNm" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept Name" SortExpression="DeptName">
                    <ItemTemplate>
                        <asp:Label ID="lblDeptNm" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BG Group" SortExpression="BGgroup">
                    <ItemTemplate>
                        <asp:Label ID="lblBG" runat="server" Text='<%# Bind("BGgroup") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblDesign" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile No" SortExpression="MobileNo">
                    <ItemTemplate>
                        <asp:Label ID="lblMobNo" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Joining Date  " SortExpression="  JoiningDate  ">
                    <ItemTemplate>
                        <asp:Label ID="lblJoinDate" runat="server" Text='<%# Bind("JoiningDate") %>'></asp:Label>
                    </ItemTemplate>                   
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>                
                <asp:BoundField DataField="ResignationDate" HeaderText="Resignation Date" 
              SortExpression="ResignationDate" >
              <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
            </Columns>
             <FooterStyle Wrap="True"></FooterStyle>
                
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

