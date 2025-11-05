<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankReconciliation_New.aspx.cs" Inherits="Module_Accounts_Transactions_BankReconciliation_New" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    

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
  <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="3">
                <b>&nbsp;Bank Reconciliation - New</b></td>
        </tr>
  
         <tr>
            <td height="30px" valign="middle" colspan="3">
                <asp:Panel ID="Panel2" runat="server" BorderColor="#666699" Height="125px" 
                    ScrollBars="Auto"  Width="99%" BorderStyle="Double">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Id"  CssClass="yui-datatable-theme" Width="100%">
                        <Columns>                                                     
                           
                            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="1%" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Id" Visible="False" >
                                <ItemStyle Width="2%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText=" " >
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Trans") %>'></asp:Label>
                                </ItemTemplate>                               
                                <ItemStyle HorizontalAlign="left" Width="15%" Font-Bold="true" />
                            </asp:TemplateField>                                                       
                            <asp:TemplateField HeaderText="Opening Amount" SortExpression="OpAmt">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("OpAmt") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Closing Amount" SortExpression="ClAmt">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ClAmt") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
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
                    <FooterStyle Wrap="True">
                    </FooterStyle>
                    </asp:GridView>
                </asp:Panel>
             </td>            
        </tr>

 <tr>
 <td>
  <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true">
                    
 <cc1:TabPanel runat="server" HeaderText="Payment" Width="100%" ID="Add">  
                    
                  

<ContentTemplate><table width="100%"><tr><td  valign="middle"  width="100%">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:CheckBox ID="chkCheckAll" runat="server" Text="Check All" 
                    Font-Bold="True" AutoPostBack="True" 
                    oncheckedchanged="chkCheckAll_CheckedChanged" />&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:CheckBox ID="chkShowAll" runat="server" Text="Show All" Font-Bold="True" 
                    AutoPostBack="True" oncheckedchanged="chkShowAll_CheckedChanged" />&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:Label ID="Label4" runat="server" Text="From Date : " Font-Bold="True"></asp:Label><asp:TextBox ID="txtFromDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender 
                                    ID="txtFromDate_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtFromDate"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegtxtFromDate" runat="server" 
                                    ControlToValidate="txtFromDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="B"></asp:RegularExpressionValidator>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:Label ID="lblToDate" runat="server" Text="To Date : " Font-Bold="True"></asp:Label>&#160;<asp:TextBox ID="txtToDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender 
                                    ID="txtToDate_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtToDate"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegtxtToDate" runat="server" 
                                    ControlToValidate="txtToDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="B"></asp:RegularExpressionValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" Text="Search" 
                    onclick="btnSearch_Click" ValidationGroup="B" /></td></tr><tr><td  ><asp:Panel ID="Panel1" runat="server" Height="240px" ScrollBars="Auto"  
                    Width="100%" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" 
                    Width="100%"   ><Columns><asp:TemplateField HeaderText="SN"><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="BVP No"><ItemTemplate><asp:Label ID="lblBVPNo" runat="Server" Text='<%#Eval("BVPNo")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label ID="lblParticulars" runat="Server" Text='<%#Eval("Particulars")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="17%" /></asp:TemplateField><asp:TemplateField HeaderText="Vch Type"><ItemTemplate><asp:Label ID="lblVchType" runat="Server" Text='<%#Eval("VchType")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Trans. Type"><ItemTemplate><asp:Label ID="lblTransactionType" runat="Server" 
                                    Text='<%#Eval("TransactionType")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Inst. No"><ItemTemplate><asp:Label ID="lblInstrumentNo" runat="Server" 
                                    Text='<%#Eval("InstrumentNo")%>' /></ItemTemplate><ItemStyle 
                    HorizontalAlign="Left" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Inst. Date"><ItemTemplate><asp:Label ID="lblInstrumentDate" runat="Server" 
                                    Text='<%#Eval("InstrumentDate")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Bank Name">
                                    <ItemTemplate>
                                    <asp:Label ID="lblBankName" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle 
                    HorizontalAlign="Left" Width="5%" />
                </asp:TemplateField><asp:TemplateField HeaderText="Debit" Visible="False"><ItemTemplate><asp:Label ID="lblDebit" runat="Server" Text='<%#Eval("Debit")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Credit"><ItemTemplate><asp:Label ID="lblCredit" runat="Server" Text='<%#Eval("Credit")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField ><ItemTemplate><asp:CheckBox ID="chk" runat="server" /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="Bank Date"><ItemTemplate><asp:Label ID="Labeldate" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtBankDate" runat="server" Text="" Width="80%" CssClass="box3"> </asp:TextBox><cc1:CalendarExtender 
                                    ID="txtBankDate_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtBankDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqtxtBankDate" runat="server" 
                                    ControlToValidate="txtBankDate" ErrorMessage="*" ValidationGroup="A"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegtxtBankDate" runat="server" 
                                    ControlToValidate="txtBankDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"> </asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Add. Charges"><ItemTemplate><asp:Label ID="LabelAddCharg" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtAddCharg" runat="server" Text="0" Width="80%" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqtxtAddCharg" runat="server" 
                                    ControlToValidate="txtAddCharg" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegtxtAddCharg" runat="server" 
                                    ControlToValidate="txtAddCharg" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"> </asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:TemplateField HeaderText="Remarks"><ItemTemplate><asp:Label ID="LabelRemarks" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtRemarks" runat="server" Text="-" Width="80%" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqtxtRemarks" runat="server" 
                                    ControlToValidate="txtRemarks" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle>
                    
                </asp:GridView></asp:Panel></td></tr><tr ><td align="center"  ><asp:Button ID="btnSubmit"  CssClass="redbox" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />&#160;&#160;&#160;&#160;&#160;&#160; <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Total :  "></asp:Label><asp:Label ID="lblTotal" runat="server" Font-Bold="True" Text="0"></asp:Label></td></tr></table>
   
      </ContentTemplate></cc1:TabPanel>
    
    
    
    
    
    
    
    
    
    
    
    
    
 
    <cc1:TabPanel   HeaderText="Receipt" ID="TabPanel1" runat="server">
    <ContentTemplate><table width="100%"><tr><td  valign="middle"  width="100%" height="27px">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:CheckBox ID="chkCheckAll_rec" runat="server" Text="Check All" 
                    Font-Bold="True" AutoPostBack="True" 
                    oncheckedchanged="chkCheckAll_rec_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="chkshowAll_rec" runat="server" Text="Show All" Font-Bold="True" 
                    AutoPostBack="True" oncheckedchanged="chkshowAll_rec_CheckedChanged" />&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:Label ID="Label5" runat="server" Text="From Date : " Font-Bold="True"></asp:Label><asp:TextBox ID="txtFromDate_rec" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender 
                                    ID="CalendarExtender1" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtFromDate_rec"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtFromDate_rec" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="B"></asp:RegularExpressionValidator>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <asp:Label ID="Label6" runat="server" Text="To Date : " Font-Bold="True"></asp:Label>&#160;<asp:TextBox ID="txtToDate_rec" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender 
                                    ID="CalendarExtender2" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtToDate_rec"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtToDate_rec" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="B"></asp:RegularExpressionValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch_rec" runat="server" CssClass="redbox" Text="Search" 
                    onclick="btnSearch_rec_Click" ValidationGroup="B" /></td></tr><tr><td  ><asp:Panel ID="Panel3" runat="server" Height="240px" ScrollBars="Auto"  
                    Width="100%" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" 
                    Width="100%"   ><Columns><asp:TemplateField HeaderText="SN"><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId_Rec" runat="Server" Text='<%#Eval("Id")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="BVR No"><ItemTemplate><asp:Label ID="lblBVRNo_Rec" runat="Server" Text='<%#Eval("BVRNo")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label ID="lblParticulars_Rec" runat="Server" Text='<%#Eval("Particulars")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="17%" /></asp:TemplateField><asp:TemplateField HeaderText="Vch Type"><ItemTemplate><asp:Label ID="lblVchType_Rec" runat="Server" Text='<%#Eval("VchType")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Trans. Type"><ItemTemplate><asp:Label ID="lblTransactionType_Rec" runat="Server" 
                                    Text='<%#Eval("TransactionType")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Inst. No"><ItemTemplate><asp:Label ID="lblInstrumentNo_Rec" runat="Server" 
                                    Text='<%#Eval("InstrumentNo")%>' /></ItemTemplate><ItemStyle 
                        HorizontalAlign="Left" /></asp:TemplateField><asp:TemplateField HeaderText="Inst. Date"><ItemTemplate><asp:Label ID="lblInstrumentDate_Rec" runat="Server" 
                                    Text='<%#Eval("InstrumentDate")%>' /></ItemTemplate><ItemStyle 
                        HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Bank Name"><ItemTemplate><asp:Label runat="server" ID="lblBnkName" Text='<%#Eval("BankName")%>'></asp:Label>                   
                    </ItemTemplate>
      <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:TemplateField><asp:TemplateField HeaderText="Debit" ><ItemTemplate><asp:Label ID="lblDebit_Rec" runat="Server" Text='<%#Eval("Debit")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Credit"  Visible="False"><ItemTemplate><asp:Label ID="lblCredit_Rec" runat="Server" Text='<%#Eval("Credit")%>' /></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField ><ItemTemplate><asp:CheckBox ID="chk_Rec" runat="server" /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="Bank Date"><ItemTemplate><asp:Label ID="Labeldate_Rec" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtBankDate_Rec" runat="server" Text="" Width="80%" CssClass="box3"> </asp:TextBox><cc1:CalendarExtender 
                                    ID="txtBankDate_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="txtBankDate_Rec"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqtxtBankDate_Rec" runat="server" 
                                    ControlToValidate="txtBankDate_Rec" ErrorMessage="*" ValidationGroup="A"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegtxtBankDate_Rec" runat="server" 
                                    ControlToValidate="txtBankDate_Rec" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"> </asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Add. Charges"><ItemTemplate><asp:Label ID="LabelAddCharg_Rec" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtAddCharg_Rec" runat="server" Text="0" Width="80%" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqtxtAddCharg" runat="server" 
                                    ControlToValidate="txtAddCharg_Rec" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegtxtAddCharg" runat="server" 
                                    ControlToValidate="txtAddCharg_Rec" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"> </asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Remarks"><ItemTemplate><asp:Label ID="LabelRemarks_Rec" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtRemarks_Rec" runat="server" Text="-" Width="80%" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqtxtRemarks" runat="server" 
                                    ControlToValidate="txtRemarks_Rec" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle>
                    
                </asp:GridView></asp:Panel></td></tr><tr ><td align="center"  ><asp:Button ID="btnSubmitRec"  CssClass="redbox" runat="server" Text="Submit" 
                onclick="btnSubmitRec_Click" />&#160;&#160;&#160;&#160;&#160;&#160; <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Total :  "></asp:Label><asp:Label ID="LabelREc" runat="server" Font-Bold="True" Text="0"></asp:Label></td></tr></table>
    
    
      </ContentTemplate>
    </cc1:TabPanel>
    </cc1:TabContainer> 
    </td>
 </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

