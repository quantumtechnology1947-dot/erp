<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PR_Details_Delete, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
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

<table width="100%"  align="center">
 <tr>
            <td valign="top" height="150" >
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="middle"  scope="col" height="21" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
        &nbsp;<b>PR - Delete </b></td>
                    </tr>
                    <tr>
                        <td align="center" >
                            <asp:Panel ID="Panel1" ScrollBars="Auto" Height="445px" runat="server">
                            
                        
<asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
        CssClass="yui-datatable-theme"  onpageindexchanging="GridView3_PageIndexChanging" 
        onrowcommand="GridView3_RowCommand" ShowFooter="false" Width="100%" AutoGenerateColumns="False" 
                                PageSize="17" >
        
                <FooterStyle Wrap="True"></FooterStyle>

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
    <Columns>
    
<asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>             
                <HeaderStyle Font-Size="10pt" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
</asp:TemplateField>
<asp:TemplateField >
        <ItemTemplate>
        <asp:LinkButton ID="Btndel" CommandName="del" runat="server" OnClientClick=" return confirmationDelete()" Text="Delete"></asp:LinkButton>
            <asp:Label ID="lblDel" runat="server" Text="PO" Visible="false"></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="PRNo">
        <ItemTemplate>
        <asp:Label ID="lblprno" runat="server" Text='<%#Eval("PRNo") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="8%"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WONo">
        <ItemTemplate>
        <asp:Label ID="lblwono" runat="server" Text='<%#Eval("WONo") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"  Width="6%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code">
        <ItemTemplate>
        <asp:Label ID="lblitemcode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="8%"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description">
        <ItemTemplate>
        <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
         </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="30%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM">
         <ItemTemplate>
        <asp:Label ID="lbluom" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
         </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="A/c Head">
        <ItemTemplate>
        <asp:Label ID="lblacchead" runat="server" Text='<%#Eval("AccHead") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Qty">
        <ItemTemplate>
        <asp:Label ID="lblqty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="6%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rate">
        <ItemTemplate>
        <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Right"  Width="6%" />
        </asp:TemplateField>
        
        
          <asp:TemplateField HeaderText="Discount">
        <ItemTemplate>
        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Right"  Width="6%" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate>
        <asp:Label ID="lblremarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="20%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Id" Visible="false">
        <ItemTemplate>
        <asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Panel>
       </td>
        </tr>
        <tr>
            <td align="center" height="25" >
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox"  onclick="btnCancel_Click" Text="Cancel" />
            </td>
        </tr>
    </table>
</td>
</tr>
</table>


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

