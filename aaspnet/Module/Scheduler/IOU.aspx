<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Scheduler_IOU, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
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
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td align="left" valign="middle" style="background:url(../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;IOU</b></td>
        </tr>
 
 
 <td>
  
  <asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" DataKeyNames="Id" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" 
         Width="100%" PageSize="20" ShowFooter="True" 
         onrowcancelingedit="GridView2_RowCancelingEdit" 
         onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" 
         onrowcommand="GridView2_RowCommand" onrowdeleting="GridView2_RowDeleting">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                            
                            
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirmationUpdate();"  
                                    runat="server" CausesValidation="True" ValidationGroup="B"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp; <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirmationUpdate();" runat="server" 
                                    CausesValidation="False" 
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                
                            </asp:TemplateField>
                            
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationDelete();"  runat="server" 
                                    CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                            
                            
                            <asp:TemplateField HeaderText="SN">
                            
                                <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id") %>'></asp:Label>                           
                                </EditItemTemplate> 
                                
                                <ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle> 
                                <FooterStyle HorizontalAlign="right" />
                            
                            </asp:TemplateField>                            
                            
                                            
                             <asp:TemplateField HeaderText="Sanctioned">
                                
                                <ItemTemplate>
                                    <asp:Label ID="lblx" Text='<%# Bind("Sanctioned") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="4%" />                               
                                
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Date" Visible="false">
                                
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" Text='<%# Eval("SysDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="4%" />                               
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" Visible="false">
                                
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" Text='<%# Eval("SysTime") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="4%" />                               
                                
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Employee Name">
                                
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" Text='<%# Eval("EmpName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                               
                                <EditItemTemplate>
                                    
                                    
                                    <asp:TextBox ID="TextBox1" Width="95%" Text='<%# Eval("EmpName") %>' CssClass="box3"  runat="server"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="Txt_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" 
                                Enabled="True" ServiceMethod="GetCompletionList"  EnableViewState="true"
                                ServicePath="" TargetControlID="TextBox1" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator ID="ReqEmpEdit" runat="server" 
                                                ControlToValidate="TextBox1" ErrorMessage="*" ValidationGroup="B">
                                                
                                                </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate><asp:TextBox ID="TxtEmp1" runat="server" CssClass="box3" ValidationGroup="D" 
                                                Width="96%"></asp:TextBox>
                                                
                                                <cc1:AutoCompleteExtender ID="TxtEmp1_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" 
                                Enabled="True" ServiceMethod="GetCompletionList"  EnableViewState="true"
                                ServicePath="" TargetControlID="TxtEmp1" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator ID="Req15" runat="server" 
                                                ControlToValidate="TxtEmp1" ErrorMessage="*" ValidationGroup="D">
                                                
                                                </asp:RequiredFieldValidator></FooterTemplate>
                                 <ItemStyle HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            
                            
                            
                            
                            
                            
                               
                            
                                    <asp:TemplateField HeaderText="Date">
                                <EditItemTemplate>
                                <asp:TextBox ID="txtDate" CssClass="box3" Text='<%# Eval("Date") %>' Width="80%" runat="server">
                                </asp:TextBox>
                                                   
                <cc1:CalendarExtender ID="textDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomRight"
                 Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtDate">
                 </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqtxtDate" runat="server"
                                ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="B">
                                </asp:RequiredFieldValidator>
                                
                               <asp:RegularExpressionValidator ID="RegtxtDate" ValidationGroup="B" runat="server" 
                  ControlToValidate="txtDate" ErrorMessage="*"
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$">
                  </asp:RegularExpressionValidator>                  
                                
                                </EditItemTemplate>

                                <ItemTemplate>
                                <asp:Label ID="lblDate1" Text='<%# Eval("Date") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                                               
                                 <FooterTemplate>
                                <asp:TextBox ID="txtDate2" runat="server" CssClass="box3" ValidationGroup="D" Width="80%">
                                </asp:TextBox>
                                   
                <cc1:CalendarExtender ID="textDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                 Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtDate2">
                 </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqtxtDate2" runat="server" 
                                ControlToValidate="txtDate2" ErrorMessage="*" ValidationGroup="D">
                                </asp:RequiredFieldValidator>
                                
                                 
                               <asp:RegularExpressionValidator ID="RegtxtDate2" ValidationGroup="D" runat="server" 
                  ControlToValidate="txtDate2" ErrorMessage="*"
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$">
                  </asp:RegularExpressionValidator>

                                </FooterTemplate>
                                </asp:TemplateField>                                
                            
                            
                            
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" CssClass="box3" Text='<%# Eval("Amount") %>'  Width="85%" runat="server">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAmt2" runat="server" 
                                                ControlToValidate="TextBox2" ErrorMessage="*" ValidationGroup="B">
                                                
                                                </asp:RequiredFieldValidator>
                                                
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ValidationGroup="B" ControlToValidate="TextBox2" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
                                                         </asp:RegularExpressionValidator>
                                                
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" Text='<%# Eval("Amount") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                               
                                 <FooterTemplate><asp:TextBox ID="TxtAmt" runat="server" CssClass="box3" ValidationGroup="D" 
                                                Width="80%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqAmt" runat="server" 
                                                ControlToValidate="TxtAmt" ErrorMessage="*" ValidationGroup="D">
                                                
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="Reg1" runat="server"  ValidationGroup="D" ControlToValidate="TxtAmt" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
                                                         </asp:RegularExpressionValidator>
                                                
                                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason">
                                <EditItemTemplate>
                                                    <asp:Label ID="lblReason2" Visible="false" Text='<%# Eval("ReasonId") %>' runat="server"></asp:Label>                                 
                                                <asp:DropDownList ID="DrpReason2" DataValueField="Id" DataTextField="Terms" DataSourceID="SqlDataSource1"   CssClass="box3" Width="92%" runat="server">
                                    </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqReason2" runat="server" 
                                                ControlToValidate="DrpReason2" InitialValue="Select" ErrorMessage="*" ValidationGroup="B">
                                                
                                                </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblReason" Text='<%# Eval("reason") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                
                                <FooterTemplate>
                                    <asp:DropDownList ID="DrpReason" CssClass="box3" DataValueField="Id" DataTextField="Terms" DataSourceID="SqlDataSource1" Width="92%" runat="server">
                                    </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqReason" runat="server" 
                                                ControlToValidate="DrpReason" InitialValue="Select" ErrorMessage="*" ValidationGroup="D">
                                                
                                                </asp:RequiredFieldValidator></FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Narration">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" Width="100%" CssClass="box3" Text='<%# Eval("Narration") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNarration" Text='<%# Eval("Narration") %>'  runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="15%" />
                                
                                 <FooterTemplate><asp:TextBox ID="TxtNarrat" runat="server" CssClass="box3" ValidationGroup="D" 
                                                Width="100%"></asp:TextBox>
                                                </FooterTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" ">
                                
                            
                            <FooterTemplate>
                                                        
                                <asp:Button ID="Button1" runat="server" OnClientClick="return confirmationAdd();" CommandName="Add" ValidationGroup="D" CssClass="redbox" Text="Add" />
                            </FooterTemplate>
                            
                            <FooterStyle HorizontalAlign="right" Width="2%" />
                                     <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            
                            
                                    </Columns>
                                    <EmptyDataTemplate>
                    <table width="100%" border="1" style="border-color:Gray"  class="fontcss">
                    <tr>
                    <th>Employee Name</th>
                     <th>Date</th>
                    <th>Amount</th>
                    <th>Reason</th>
                    <th>Narration</th>
                     <th> </th>
                    </tr> 
                     
                     <tr>                  
                    <td >
                    <asp:TextBox ID="TxtEmp" runat="server" CssClass="box3" ValidationGroup="D" 
                                                Width="90%"></asp:TextBox>
                                                
                                                <cc1:AutoCompleteExtender ID="TxtEmp_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" 
                                Enabled="True" ServiceMethod="GetCompletionList"  EnableViewState="true"
                                ServicePath="" TargetControlID="TxtEmp" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator ID="ReqEmp" runat="server" 
                                                ControlToValidate="TxtEmp" ErrorMessage="*" ValidationGroup="A">
                                                
                                                </asp:RequiredFieldValidator>
                    </td>
                    
                     <td style="width:9%" >
                                   
                <asp:TextBox ID="textDate" runat="server"  CssClass="box3" Width="75%">
                 </asp:TextBox>                
                
                <cc1:CalendarExtender ID="textDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                 Enabled="True" Format="dd-MM-yyyy" TargetControlID="textDate">
                 </cc1:CalendarExtender>
                 <asp:RequiredFieldValidator ID="ReqDate" runat="server" 
                 ControlToValidate="textDate" ErrorMessage="*" ValidationGroup="A"> 
                 </asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegDate" ValidationGroup="A" runat="server" 
                  ControlToValidate="textDate" ErrorMessage="*"
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$">
                  </asp:RegularExpressionValidator>
                  
                    </td>
                    
                    <td style="width:12%" >
                    <asp:TextBox ID="TxtAmt1" runat="server" CssClass="box3" Width="80%">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqAmt1" runat="server" 
                    ControlToValidate="TxtAmt1" ErrorMessage="*" ValidationGroup="A">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegAmt" runat="server"  ValidationGroup="A" 
                    ControlToValidate="TxtAmt1" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
                    </asp:RegularExpressionValidator>
                    </td>
                    
                    <td >
                    
                    <asp:DropDownList ID="DrpReason1" DataValueField="Id" DataTextField="Terms" DataSourceID="SqlDataSource1" Width="96%" runat="server">
                                    </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqReason1" runat="server" 
                                                ControlToValidate="DrpReason1" InitialValue="Select" ErrorMessage="*" ValidationGroup="A">
                                                
                                                </asp:RequiredFieldValidator>
                    
                    </td>
                    
                    <td>
                    
                    <asp:TextBox ID="TxtNarrat1" runat="server" CssClass="box3" ValidationGroup="A" 
                                                Width="98%"></asp:TextBox>
                                                
                    
                    </td> 
                    <td align="center" >
                        <asp:Button ID="BtnAdd" runat="server" CommandName="Add1" OnClientClick="return confirmationAdd();" ValidationGroup="A" CssClass="redbox"   Text="Add" />
                    </td>                  
                                        
                    </tr>
                   
                    </table>
                    </EmptyDataTemplate>
                              </asp:GridView>
                
             </td>   
          
  
 <tr>
 
 
 <td>
  
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
         ProviderName="System.Data.SqlClient" 
         SelectCommand="SELECT * FROM [tblACC_IOU_Reasons]"></asp:SqlDataSource>
                
             </td>   
             </tr>
         </table>   

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

