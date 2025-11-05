<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_Schedule_Output_New, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
  
<table width="100%">
    <tr>
        <td align="left" valign="middle" 
            style="background:url(../../../images/hdbg.JPG)" height="21" 
            class="fontcsswhite" colspan="2"><b>&nbsp;Job-Sheduling Output-New</b></td>
    </tr>
<tr>
<td align="left" valign="bottom"  height="25" ><b>&nbsp;WONo :&nbsp;&nbsp;<asp:DropDownList 
        ID="DrpWONO" runat="server" 
        onselectedindexchanged="DrpWONO_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList> </b></td>
<td align="left" valign="bottom"  height="25" >&nbsp;<b>Customer Name</b> :<asp:Label 
        ID="lblCustomer" runat="server" style="font-weight: 700"></asp:Label>
    &nbsp;</td>
</tr>
<tr>
<td align="left" valign="middle"  height="10" colspan="2" >&nbsp;</td>
</tr>
</table>
    
    <table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td align="center"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme"  AllowPaging="True" 
                    Width="100%" onrowcommand="GridView2_RowCommand" ><FooterStyle Wrap="True"></FooterStyle><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %>
            </ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField 
            HeaderText="ItemId" Visible="False"><ItemTemplate><asp:Label ID="lblItemId" runat="Server" Text='<%#Eval("ItemId")%>'/>
            </ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="ItemCode"><ItemTemplate>           
                      
                <asp:LinkButton ID="btnMove"  Text='<%#Eval("ItemCode")%>' CommandName="move" runat="server"></asp:LinkButton>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="8%" /></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblDesc" runat="Server" Text='<%#Eval("ManfDesc")%>'/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="20%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOM" runat="Server" Text='<%#Eval("Symbol")%>'/></ItemTemplate><ItemStyle 
                HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText=" BOM Qty"><ItemTemplate><asp:Label ID="lblQty" runat="Server" Text='<%#Eval("Qty")%>'/></ItemTemplate><ItemStyle 
                HorizontalAlign="Center" Width="5%" /></asp:TemplateField>               
                
                
        </Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
        </EmptyDataTemplate></asp:GridView></td></tr>
        <tr>
            <td align="center" height="25" valign="middle">
                &nbsp;</td>
        </tr>
        </table>  


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

