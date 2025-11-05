<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Budget_Dist_Dept_Details.aspx.cs" Inherits="Module_MIS_Transactions_Budget_Dist_Dept_Details" Title="ERP" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <table align="center" 
        border="0" cellspacing="0" width="50%" class="fontcss" __designer:mapid="480" >
        <tr __designer:mapid="49a">
            <td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21" __designer:mapid="49b">&nbsp;<b __designer:mapid="49c"> Budget</b></td></tr>
        <tr __designer:mapid="49d"><td align="left" __designer:mapid="49e" height="25px">&nbsp;<asp:Label ID="Label5" runat="server" Text="Bussiness Group"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbldept" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label></td></tr>
        <tr __designer:mapid="4a3"><td align="right" __designer:mapid="4a4">
        
<asp:Panel ID="Panel1" runat="server"  Height="415px" ScrollBars="Vertical">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id"  Width="100%" CssClass="yui-datatable-theme" 
                    onrowcommand="GridView2_RowCommand" 
    onrowupdating="GridView2_RowUpdating" 
        onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="20">
        <PagerSettings PageButtonCount="40" />
        <Columns>
            <asp:TemplateField HeaderText="SN" SortExpression="Id">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CK">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" OnCheckedChanged="CheckBox1_CheckedChanged" 
                AutoPostBack="true"  runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id" SortExpression="Id" 
            Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" 
            SortExpression="Date">
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" 
                    Text='<%#Eval("SysDate") %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Time" 
            SortExpression="Time">
                <ItemTemplate>
                    <asp:Label ID="lblTime" runat="server" 
                    Text='<%#Eval("SysTime") %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" 
            SortExpression="Amount">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" 
                    Text='<%#Eval("Amount")%>' > </asp:Label>
                    <asp:TextBox 
                    ID="TxtAmount" runat="server" Text='<%#Eval("Amount")%>' Visible="false"  
                    ValidationGroup="A" >
                    </asp:TextBox>
                    <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" ValidationGroup="A"  
                    ErrorMessage="*" ControlToValidate="TxtAmount" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" 
                    ControlToValidate="TxtAmount" ValidationExpression="^[1-9]\d*(\.\d+)?$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
     </asp:Panel>
                
                
            </td>
        </tr>
        <tr __designer:mapid="4a6">
        <td __designer:mapid="4a7" align="center">
           <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox" ValidationGroup="A"   OnClientClick=" return confirmationUpdate()"
                Text="Update" onclick="BtnUpdate_Click"  />
                   <asp:Button ID="BtnDelete" runat="server" CssClass="redbox"   OnClientClick=" return confirmationDelete()" 
                Text="Delete" onclick="BtnDelete_Click"  />
   <asp:Button ID="btnCancel"  CssClass="redbox" runat="server" Text="Cancel" onclick="btnCancel_Click"  
                           />
        </td>
        </tr>
       
        <tr __designer:mapid="4ab">
            <td align="center" class="style3" __designer:mapid="4ac">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
                   
            </td>
        </tr>
        
       
        </table>
     </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

