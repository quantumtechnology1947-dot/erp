<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_RateLockUnLock, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
  
  <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Rate Lock-Unlock </b></td>
             </tr>
    <tr>
            <td class="fontcsswhite" height="25" valign="middle" >
            
                 &nbsp;&nbsp;<asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem Value="Category">Category</asp:ListItem>
                     <asp:ListItem Value="WOItems">WO Items</asp:ListItem>                    
                </asp:DropDownList>
                <asp:DropDownList ID="DrpCategory1" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory1_SelectedIndexChanged" Height="21px" 
                    CssClass="box3">
                    
                </asp:DropDownList> 
                
                 <asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged">
                     <asp:ListItem Value="Select">Select</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>                    
                   
                </asp:DropDownList>            
                <asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>
                
                &nbsp;<asp:Button ID="btnSearch0" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                
                &nbsp;</td>
             </tr> 
  
 <tr>
 
 
 <td align="left">
  
     <asp:GridView 
                 ID="GridView2" runat="server" AllowPaging="True"  OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
         Width="100%" onrowcommand="GridView2_RowCommand" PageSize="20">
         <PagerSettings PageButtonCount="40" />
         <Columns>
             <asp:TemplateField HeaderText="SN" 
                            ItemStyle-HorizontalAlign="Center" ><ItemTemplate><%# Container.DataItemIndex + 1%>
                         </ItemTemplate>
                 <ItemStyle 
                            HorizontalAlign="Right" Width="3%" ></ItemStyle>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Id" Visible="False">
                 <ItemTemplate>
                     <asp:Label ID="lblId" 
                                    runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                 <asp:Label ID="itemcode" 
                                    runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                         </ItemTemplate><ItemStyle HorizontalAlign="center" Width="10%" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Description">
                         <ItemTemplate>
                             <asp:Label ID="manfdesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Left" Width="54%" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="UOM">
                         <ItemTemplate>
                             <asp:Label ID="uomBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="5%" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Unlock For">
                         <ItemTemplate>
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal">
                                 <asp:ListItem Value="0">PR</asp:ListItem>
                                 <asp:ListItem Value="1">SPR</asp:ListItem>
                                 <asp:ListItem Value="2">PO</asp:ListItem>
                             </asp:RadioButtonList>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="12%" />
                     </asp:TemplateField>
                     <asp:TemplateField >
                         <ItemTemplate>
                             <asp:LinkButton ID="btnsel" Text="Unlock" CommandName="Sel" runat="server" 
                             OnClientClick=" return confirmationUnLock()">
                               </asp:LinkButton>
                               
                             <asp:LinkButton ID="LinkButton1" Text="Lock" CommandName="Sel1" runat="server" 
                               OnClientClick=" return confirmationLock()" Visible="false">
                                </asp:LinkButton>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="4%" />
                     </asp:TemplateField>

                    <asp:TemplateField HeaderText="LockUnlock" Visible="False">
                    <ItemTemplate>
                    <asp:Label ID="lblLockUnlock" 
                    runat="server" Text='<%# Eval("LockUnlock") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                 </Columns>
                 <EmptyDataTemplate>
                     <table width="100%" class="fontcss">
                         <tr>
                             <td align="center">
                                 <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon">  </asp:Label></td></tr></table>
                 </EmptyDataTemplate>
             </asp:GridView>
                
             </td>   
             </tr>
         </table>        
               

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

