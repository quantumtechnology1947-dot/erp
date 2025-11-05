<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Reports_WorkOrder_Issue, newerp_deploy" title="ERP" theme="Default" %>

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
    <table width="100%" align="center" cellpadding="0" cellspacing="0">
        <tr height="21">
            <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >
                <strong>&nbsp;Work Order Issue &amp; Shortage</strong></td>
        </tr>
        <tr>
            <td class="fontcsswhite" height="25" >
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Width="180px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                    <asp:ListItem Value="2">PO No</asp:ListItem>
                    <asp:ListItem Value="3">WO No</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:TextBox ID="txtEnqId" runat="server" CssClass="box3" Width="150px"></asp:TextBox>
                &nbsp;<asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>

                <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>
                
                <asp:Button ID="btnSearch" runat="server"  Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo" RowStyle-HorizontalAlign ="Center" PageSize="15"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    onrowcommand="SearchGridView1_RowCommand" >
                    <PagerSettings PageButtonCount="40" />
                    <RowStyle />
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1  %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                        
                         <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="BtnSelect"   Text="Select" CommandName="Sel" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField >
                        <ItemTemplate>
                        <asp:DropDownList  ID="DrpWorkOrderType" runat="server" CssClass="box3" Width="100%" >
                        <asp:ListItem Text="Issue" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Shortage" Value="1">
                        </asp:ListItem>
                        </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="8%" />
                         </asp:TemplateField> 
                           
                        <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Customer Name">
                         <ItemTemplate>
                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Width="28%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField  HeaderText="Code">
                        <ItemTemplate>
                       <asp:Label ID="lblCustId" runat="server" Text='<%#Eval("CustomerId") %>'></asp:Label>                        
                        </ItemTemplate>
                            <ItemStyle Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Enquiry No">
                        <ItemTemplate>
                        <asp:Label ID="lblEnqId" runat="server" Text='<%#Eval("EnqId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WO No">
                         <ItemTemplate>
                        <asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="PO No">
                         <ItemTemplate>
                        <asp:Label ID="lblPONo" runat="server" Text='<%#Eval("PONo") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Gen. By">
                         <ItemTemplate>
                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Width="28%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        
                       <%-- <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                        </asp:BoundField>--%>
                        
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

