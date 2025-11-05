<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_Schedule_New_Items_BySplit, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        </style>
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
<tr><td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Job-Sheduling Input-New</b></td></tr>
<tr>
<td align="left" valign="middle"  height="21" ><b>&nbsp;WONo :&nbsp;&nbsp;<asp:Label ID="lblWoNo" runat="server" Text=""></asp:Label> </b></td>
</tr>
</table>
    
    <table align="left" cellpadding="0" cellspacing="0" class="style2"><tr><td align="center"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme"  AllowPaging="True" 
                    Width="100%" onrowcommand="GridView2_RowCommand" ><FooterStyle Wrap="True"></FooterStyle><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %>
            </ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField 
            HeaderText="ItemId" Visible="False"><ItemTemplate><asp:Label ID="lblItemId" runat="Server" Text='<%#Eval("ItemId")%>'/>
            </ItemTemplate></asp:TemplateField>
            <asp:TemplateField 
            HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>'/>
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
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                    onclick="btnCancel_Click" Text="Cancel" />
            </td>
        </tr>
        </table>  
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

