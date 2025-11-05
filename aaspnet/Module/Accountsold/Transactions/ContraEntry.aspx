<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContraEntry.aspx.cs" Inherits="Module_Accounts_Transactions_ContraEntry" Title="ERP" Theme="Default" %>

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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Contra</b></td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  DataKeyNames="Id"
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" PageSize="20" 
                    ShowFooter="True" Width="100%" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                    onrowcancelingedit="GridView1_RowCancelingEdit">
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                         <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" OnClientClick= "return confirmationUpdate()" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    
                            </EditItemTemplate>
                           
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server"  OnClientClick= "return confirmationDelete()" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nos">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="txtDate0" runat="server" CssClass="box3" Text='<%#Eval("Date")%>' Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDate0" ErrorMessage="*" ValidationGroup="E"></asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDate0" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <FooterTemplate>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="AB"></asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDate" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cr.">
                        <ItemTemplate>
                            <asp:Label ID="lblCr" runat="server" Text='<%#Eval("Cr")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>                            
                            <asp:DropDownList ID="DrpListCr0" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name"  DataValueField="Id" AutoPostBack="true" Width="150px" onselectedindexchanged="DrpListCrE_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ReqECr" runat="server" InitialValue="Select" 
                                ControlToValidate="DrpListCr0" ErrorMessage="*" ValidationGroup="E"></asp:RequiredFieldValidator> 
                            <asp:Label ID="lblCr0" Visible="false" runat="server" Text='<%#Eval("CrId")%>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                            
                            <asp:DropDownList ID="DrpListCr" CssClass="box3" runat="server"  AutoPostBack="true"
                                 
                                Width="150px" 
                    onselectedindexchanged="DrpListCrF_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Req4" runat="server" InitialValue="Select" 
                                ControlToValidate="DrpListCr" ErrorMessage="*" ValidationGroup="AB"></asp:RequiredFieldValidator> 
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dr.">
                        <ItemTemplate>
                            <asp:Label ID="lblDr" runat="server" Text='<%#Eval("Dr")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="DrpListDr0" CssClass="box3" runat="server"                                
                                Width="150px" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select" 
                                ControlToValidate="DrpListDr0" ErrorMessage="*" ValidationGroup="E"></asp:RequiredFieldValidator>                              
                            <asp:Label ID="lblDr0" Visible="false" runat="server" Text='<%#Eval("DrId")%>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            
                            <asp:DropDownList ID="DrpListDr" CssClass="box3" runat="server"                                
                                Width="150px">
                            </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="Select" 
                                ControlToValidate="DrpListDr" ErrorMessage="*" ValidationGroup="AB"></asp:RequiredFieldValidator>
                            
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amt")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtAmt0" Width="80px" Text='<%#Eval("Amt")%>' runat="server" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAmt0" ErrorMessage="*" ValidationGroup="E"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmt0" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="E" ErrorMessage="*"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtAmt" Width="80px" runat="server" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAmt" ErrorMessage="*" ValidationGroup="AB"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmt" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="AB" ErrorMessage="*"></asp:RegularExpressionValidator>
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Narration">
                        <ItemTemplate>
                            <asp:Label ID="lblNarr" runat="server" Text='<%#Eval("Narr")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtNarr0" Text='<%#Eval("Narr")%>' runat="server" CssClass="box3" TextMode="MultiLine" 
                                Width="300px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtNarr" runat="server" CssClass="box3" TextMode="MultiLine" 
                                Width="300px"></asp:TextBox>
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="370px" />
                        </asp:TemplateField>
                        <asp:TemplateField> 
                          <FooterTemplate>
                          <asp:Button ID="btnAdd" runat="server" CssClass="redbox" Text=" Add " 
                                CommandName="Add1" ValidationGroup="AB" />
                          </FooterTemplate>               
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" style="border-color:Grey" width="810">
                    <tr>
                        <th align="center">
                            <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Date"></asp:Label>
                        </th>
                        <th align="center">
                            <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Cr."></asp:Label>
                        </th>
                        <th align="center">
                            <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Dr."></asp:Label>
                        </th>
                        <th align="center">
                            <asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="Amount"></asp:Label>
                        </th>
                        <th align="center">
                            <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Narration"></asp:Label>
                        </th>
                        <th>
                            &nbsp;</th>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <asp:TextBox ID="txtDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDate" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="DrpListCr" runat="server"  AutoPostBack="true"
                                 
                                Width="100px" 
                    onselectedindexchanged="DrpListCr_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="Select" 
                                ControlToValidate="DrpListCr" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                           
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="DrpListDr" runat="server"                                 
                                Width="100px">
                            </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="Select" 
                                ControlToValidate="DrpListDr" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            
                        </td>
                        <td align="right" valign="top">
                            <asp:TextBox ID="txtAmt" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAmt" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="A" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtAmt" ></asp:RegularExpressionValidator>
&nbsp;</td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtNarr" runat="server" CssClass="box3" TextMode="MultiLine" 
                                Width="300px"></asp:TextBox>
                        </td>
                        <td valign="top" align="center">
                            <asp:Button ID="btnAdd" runat="server" CssClass="redbox" Text=" Add " 
                                CommandName="Add1" ValidationGroup="A" />
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
                                SelectCommand="SELECT * FROM [tblACC_Bank]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

