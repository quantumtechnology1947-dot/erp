<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Credit_Note, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Credit Note</b></td>
        </tr>
        <tr>

            <td align="left">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  DataKeyNames="Id"
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" PageSize="20" 
                    ShowFooter="True" Width="100%"  
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                         <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" OnClientClick="return " runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton3" ValidationGroup ="A"  OnClientClick=" return confirmationAdd()"
                                 runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp; <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                 OnClientClick=" return confirmationDelete()"
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField  Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>                         
                            
                              <asp:TextBox    ID="txtDate1" runat="server" CssClass="box3"  Text='<%#Eval("Date")%>' Width="80%" ></asp:TextBox>
                                <cc1:CalendarExtender  ID="txtDate1_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtDate1">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="ReqtexttxtDate1" runat="server" ValidationGroup="A"
                                    ControlToValidate="txtDate1" ErrorMessage="*" >
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtexttxtDate1" runat="server" ValidationGroup="A"
                                    ControlToValidate="txtDate1" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"   >
                                    </asp:RegularExpressionValidator>
                            
                            
                            
                            
                            </EditItemTemplate>
                            <FooterTemplate>                   
                            
                              <asp:TextBox    ID="txtDate2" runat="server" CssClass="box3"  Width="80%"></asp:TextBox>
                                <cc1:CalendarExtender  ID="txtDate2_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtDate2">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="ReqtexttxtDate2" runat="server" ValidationGroup="B"
                                    ControlToValidate="txtDate2" ErrorMessage="*" >
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtexttxtDate2" runat="server" ValidationGroup="B"
                                    ControlToValidate="txtDate2" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"   >
                                    </asp:RegularExpressionValidator> 
                            
                            </FooterTemplate>                            
                            <ItemStyle HorizontalAlign="Center"  Width="8%"  />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Credit No">
                        <ItemTemplate>
                            <asp:Label ID="lblDebitno" runat="server" Text='<%#Eval("CreditNo")%>'></asp:Label>
                            </ItemTemplate> 
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("Types")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:DropDownList ID="DrpList1" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource1" 
                        DataTextField="Description" DataValueField="Id" onselectedindexchanged="DrpList1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lblType1" Visible="false" runat="server" Text='<%#Eval("typ")%>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:DropDownList ID="DrpList2" runat="server"  AutoPostBack="true" DataSourceID="SqlDataSource1"
                        DataTextField="Description" DataValueField="Id"  onselectedindexchanged="DrpList2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%"  />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="Credit To">
                        <ItemTemplate>
                            <asp:Label ID="lblDebitto" runat="server" Text='<%#Eval("SCE")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtDebitto1" Text='<%#Eval("SCE")%>' runat="server" CssClass="box3" Width="94%" ></asp:TextBox> 
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" 
                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                            MinimumPrefixLength="1" ServiceMethod="sql2" ServicePath="" 
                            ShowOnlyCurrentWordInCompletionListItem="True" 
                            TargetControlID="txtDebitto1" UseContextKey="True" CompletionListItemCssClass="bg" 
                            CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender> 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="txtDebitto1" ErrorMessage="*" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator>
                            
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtDebitto2" runat="server" CssClass="box3" Width="94%" ></asp:TextBox>    
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" 
                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                            ShowOnlyCurrentWordInCompletionListItem="True" 
                            TargetControlID="txtDebitto2" UseContextKey="True" CompletionListItemCssClass="bg" 
                            CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="txtDebitto2" ErrorMessage="*" 
                                    ValidationGroup="B"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Reference">
                        <ItemTemplate>
                            <asp:Label ID="lblReference" runat="server" Text='<%#Eval("Refrence")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtReference1" Text='<%#Eval("Refrence")%>' runat="server" CssClass="box3"  Width="94%" Height="30Px"
                        TextMode="MultiLine" >  </asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtReference2" runat="server" CssClass="box3"  Width="94%"  Height="30Px" TextMode="MultiLine" >
                        </asp:TextBox>
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Particulars">
                        <ItemTemplate>
                            <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtParticulars1" Text='<%#Eval("Particulars")%>' runat="server" CssClass="box3"  Width="94%" Height="30Px"
                          TextMode="MultiLine" ></asp:TextBox>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtParticulars2" runat="server" CssClass="box3"  Width="94%" Height="30Px"
                         TextMode="MultiLine"></asp:TextBox>
                        </FooterTemplate>                        
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>                       
                        
                        
                        <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtAmt1"  Width="85%"  Text='<%#Eval("Amount")%>' runat="server" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAmt1" ValidationGroup="A" ErrorMessage="*" ></asp:RequiredFieldValidator>
                                
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmt1"                                         ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A" ErrorMessage="*">
                            </asp:RegularExpressionValidator>
                            
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtAmt2"  Width="85%"  runat="server" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAmt2" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtAmt2" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B" ErrorMessage="*">
                                </asp:RegularExpressionValidator>
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right"  Width="10%"/>
                        </asp:TemplateField>
                       
                        <asp:TemplateField> 
                          <FooterTemplate>
                          <asp:Button ID="btnAdd" runat="server" CssClass="redbox" Text=" Add "   OnClientClick=" return confirmationAdd()"
                                CommandName="Add" ValidationGroup="B" />
                          </FooterTemplate>               
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                    </Columns>
                    
                    
                    
                    <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center">
                            <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Date"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Type"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Credit To"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="Refrence"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Particulars"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Amount"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <asp:TextBox ID="txtDate3" runat="server" CssClass="box3" Width="90px"></asp:TextBox>
                      
                             <cc1:CalendarExtender  ID="txtDate1_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtDate3">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="ReqtexttxtDate1" runat="server" ValidationGroup="C"
                                    ControlToValidate="txtDate3" ErrorMessage="*" >
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtexttxtDate1" runat="server" ValidationGroup="C"
                                    ControlToValidate="txtDate3" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"   >
                                    </asp:RegularExpressionValidator>
                            
                        </td>
                        <td align="center" valign="top">
                            <asp:DropDownList ID="DrpList3" runat="server" AutoPostBack="true"
                                DataSourceID="SqlDataSource1" DataTextField="Description" DataValueField="Id"                                onselectedindexchanged="DrpList3_SelectedIndexChanged">
                            </asp:DropDownList>
                           
                        </td>
                        <td align="left" valign="top">
                          <asp:TextBox ID="TxtSCE" runat="server" CssClass="box3" Width="300px"></asp:TextBox> 
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" 
                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                            ShowOnlyCurrentWordInCompletionListItem="True" 
                            TargetControlID="TxtSCE" UseContextKey="True" CompletionListItemCssClass="bg" 
                            CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="TxtSCE" ErrorMessage="*" 
                                    ValidationGroup="C"></asp:RequiredFieldValidator> 
                          
                        </td>
                        
                         <td align="center" valign="top">
                          <asp:TextBox ID="TxtRefrence" runat="server" CssClass="box3" TextMode="MultiLine" Height="30Px" Width="170px">
                          </asp:TextBox> 
                        </td>
                         <td align="center" valign="top">
                          <asp:TextBox ID="TxtParticulars" runat="server" CssClass="box3" TextMode="MultiLine" Height="30Px" Width="170px">
                          </asp:TextBox> 
                        </td>
                        <td align="center" valign="top">
                            <asp:TextBox ID="txtAmt3" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                            
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAmt3" ValidationGroup="C" ErrorMessage="*" ></asp:RequiredFieldValidator>
                                
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmt3"                                         ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="C" ErrorMessage="*">
                            </asp:RegularExpressionValidator>
                            
                        &nbsp;
                        </td>
                      
                        <td valign="top">
                            <asp:Button ID="btnAdd3" runat="server" CssClass="redbox" Text=" Add "  OnClientClick=" return confirmationAdd()"
                                CommandName="Add1" ValidationGroup="C" />
                        </td>
                    </tr>
                </table>
                    </EmptyDataTemplate>
                    
                    
                </asp:GridView>
                
            </td>
        </tr>
    </table>
   
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT * FROM [tblACC_DebitType]"></asp:SqlDataSource>
                          
   
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

