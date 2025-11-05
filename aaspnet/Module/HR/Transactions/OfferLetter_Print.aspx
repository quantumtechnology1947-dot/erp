<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_OfferLetter_Print, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style> 
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
    <table class="style2" cellpadding="0" cellspacing="0">
       <tr>
            <td align="left" valign="middle"  
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>
                &nbsp;Offer Letter - Print</b></td>
        </tr>
        <tr>
            <td align="left" height="25">
                <b>&nbsp;</b>Employee Name&nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="box3" Width="350px"></asp:TextBox>

 <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TextBox1" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" 
                    onclick="Button1_Click" />
                
                
            &nbsp;<asp:Button ID="btnViewAll" runat="server" CssClass="redbox" 
                    Text="View All" onclick="btnViewAll_Click" />
                
                
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="Id" 
                     CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView2_RowDataBound" PageSize="17" 
                    onpageindexchanging="GridView2_PageIndexChanging" onrowcommand="GridView2_RowCommand" 
                    >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="sel"
                                   Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="2%" />                                      
                                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Offer Id" InsertVisible="False" 
                           >
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type Of">
                        <ItemTemplate>
                            <asp:Label ID="lblTypeOf" runat="server" Text='<%#Eval("TypeOf")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="StaffType">
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Increment">
                        <ItemTemplate>                        
                            <asp:DropDownList  ID="IncrementDropDown" CssClass="box3" Width="50px" runat="server"></asp:DropDownList>       
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>                      
                                                
                        <asp:TemplateField HeaderText="Employee Name" SortExpression="EmployeeName">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation">
                         <ItemTemplate>
                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duty Hrs">
                        <ItemTemplate>
                                <asp:Label ID="lblDutyHrs" runat="server" Text='<%# Bind("DutyHrs") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Interviewed by">
                        <ItemTemplate>
                                <asp:Label ID="lblInvBy" runat="server" Text='<%# Bind("InvBy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact No">
                        <ItemTemplate>
                                <asp:Label ID="lblContNo" runat="server" Text='<%# Bind("ContNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gross Salary">
                         <ItemTemplate>
                                <asp:Label ID="lblGrossSal" runat="server" Text='<%# Bind("GrossSal") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="6%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                         <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
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
                <asp:SqlDataSource ID="SqlDataSource1"  
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"  
                    runat="server" 
                    DeleteCommand="DELETE FROM tblHR_Offer_Master WHERE (OfferId = @OfferId)" 
                    InsertCommand="INSERT INTO [tblHR_Offer_Master] ([EmployeeName], [StaffType]) VALUES (@EmployeeName, @StaffType)" 
                    SelectCommand="SELECT tblHR_Offer_Master.OfferId ,tblHR_Offer_Master.EmployeeName ,tblHR_Offer_Master.StaffType from tblHR_Offer_Master where tblHR_Offer_Master.OfferId not in (SELECT tblHR_OfficeStaff.OfferId from tblHR_OfficeStaff)" 
                    
                    UpdateCommand="UPDATE [tblHR_Offer_Master] SET [EmployeeName] = @EmployeeName, [StaffType] = @StaffType WHERE [OfferId] = @OfferId">
                    <DeleteParameters>
                        <asp:Parameter Name="OfferId" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="EmployeeName" Type="String" />
                        <asp:Parameter Name="StaffType" Type="Int32" />
                        <asp:Parameter Name="OfferId" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="EmployeeName" Type="String" />
                        <asp:Parameter Name="StaffType" Type="Int32" />
                    </InsertParameters>
                </asp:SqlDataSource>
                
                
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

