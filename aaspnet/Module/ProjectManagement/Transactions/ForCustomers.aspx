<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ForCustomers, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            height: 13px;
        }
        .style4
        {
            height: 13px;
            width: 119px;
        }
        .style5
        {
            height: 12px;
            width: 119px;
        }
        .style6
        {
            width: 119px;
        }
        .style7
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
        }
        .style8
        {
            height: 13px;
            width: 27px;
        }
        .style9
        {
            height: 12px;
            width: 27px;
        }
        .style10
        {
        }
        .style11
        {
            font-weight: bold;
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
    <table width="100%" align="center" cellpadding="0" cellspacing="0">
        <tr height="21">
            <td style="background:url(../../../images/hdbg.JPG)" class="style7" colspan="3">
                &nbsp;<strong> For Customer</strong></td>
        </tr>
        <tr height="21">
            <td  height="25" class="style8">
                            &nbsp;</td>
            <td  height="25" class="style4">
                            &nbsp;
                            
                            <asp:Label ID="Label2" runat="server" Text="Customer Name" CssClass="style11"></asp:Label>
                &nbsp;</td>
            <td  height="25" class="style3">
                            :
                <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                &nbsp;<asp:Button ID="Search" runat="server" onclick="Search_Click" Text="Search" 
                                CssClass="redbox" />
            </td>
        </tr>
        <tr height="21">
            <td  height="25" class="style9">
                            &nbsp;</td>
            <td  height="25" class="style5">
                            &nbsp;
                            
                            <asp:Label ID="Label3" runat="server" Text="Select User" CssClass="style11"></asp:Label>
            </td>
            <td  height="25" style="height: 12px">
                            : <asp:TextBox ID="TxtEmpName" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
                  
        <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
        
                            <asp:Label ID="lblUser" runat="server"></asp:Label>
        
            </td>
        </tr>
        <tr height="21">
            <td  height="25" class="style9">
                            &nbsp;</td>
            <td  height="25" class="style5">
                            &nbsp;
                            
                            <asp:Label ID="Label4" runat="server" Text="Title" CssClass="style11"></asp:Label>
            </td>
            <td  height="25" style="height: 12px">
                            :
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="box3" Width="370px"></asp:TextBox>
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style6">
                &nbsp;
                            
                            <asp:Label ID="Label5" runat="server" Text="Upload Details" 
                    CssClass="style11"></asp:Label>
            </td>
            <td>
                :</td>
        </tr>
        <tr>
            <td class="style10" colspan="3">
                
                    <asp:GridView ID="GridView3" runat="server"  
                        ShowFooter="True" 
                        AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                        OnRowCommand="GridView3_RowCommand" PageSize="17" Width="100%" 
                        AllowPaging="True" onpageindexchanging="GridView3_PageIndexChanging"><Columns>
                            <asp:TemplateField 
                                HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %>
                                    </ItemTemplate><HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>  </asp:Label>
                                    </ItemTemplate><ItemStyle Width="2%" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DId" Visible="false">
                                <ItemTemplate>
                                        <asp:Label ID="lblDId" runat="server" Text='<%#Eval("DId") %>'>  </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField><asp:TemplateField><ItemTemplate>
                                <asp:LinkButton ID="linkBtn" runat="server" CommandName="del" 
                                        OnClientClick=" return confirmationDelete()" Text="Delete"> </asp:LinkButton>
                                    </ItemTemplate><HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblPLNDate" runat="server" Text='<%# Bind("PLNDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lbltime" Text='<%#Eval("Time") %>'></asp:Label>
                                </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Top" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="File" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  
                            Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:FileUpload ID="FileUpload1"  runat="server" />
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Left" Width="250px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Mail To">
                                <ItemTemplate>                                
                                <asp:Label runat="server" ID="lblmailTo" Text='<%#Eval("MailTo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtmailto" CssClass="box3" Width="90%"></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegmailTo" runat="server" ValidationGroup="A"
                ControlToValidate="txtmailto" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                
                                </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="12%" VerticalAlign="Top" />
                            </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Message">
                                <ItemTemplate>                                
                                <asp:Label runat="server" ID="lblmsg" Text='<%#Eval("msg") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtmsg" CssClass="box3" Width="99%"></asp:TextBox>
                                </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" VerticalAlign="Top" />
                              </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>                                
                                <asp:Label runat="server" ID="lblrks" Text='<%#Eval("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtRemarks" CssClass="box3" Width="99%"></asp:TextBox>
                                </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" VerticalAlign="Top" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="" >
                                    <FooterTemplate>
                                        <asp:Button ID="btnFAdd" ValidationGroup="A"  runat="server" Text="Add" CssClass="redbox" 
                            CommandName="Add" OnClientClick=" return confirmationAdd()" />
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Center" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table border="1pt" style="border-color:GrayText" width="100%">
                                    <tr>
                                        <th>
                                            SN
                                             </th><th >File </th><th>Mail To</th><th>Message</th><th>Remarks</th><th></th></tr><tr>
                                    <td 
                                        align="center"><asp:Label ID="lblSN" runat="server"  Text="1"></asp:Label></td>
                                    <td width="10%" >
                                        <asp:FileUpload  
                                                ID="FileUpload2"   runat="server" />
                                        </td>
                                        <td>
                                         <asp:TextBox runat="server" ID="txtmailTo" CssClass="box3" Width="96%"></asp:TextBox>
                                         
                                        <asp:RegularExpressionValidator ID="RegmailToE" runat="server" ValidationGroup="B"
                ControlToValidate="txtmailTo" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                
                                        </td>
                                        <td>
                                         <asp:TextBox runat="server" ID="txtmsg" CssClass="box3" Width="100%"></asp:TextBox>
                                        </td>
                                         <td >
                                        <asp:TextBox runat="server" ID="txtRemarks" CssClass="box3" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnFAdd1" ValidationGroup="B"  runat="server" Text="Add" CssClass="redbox"  
                                          OnClientClick=" return confirmationAdd()" CommandName="Add1" />
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

