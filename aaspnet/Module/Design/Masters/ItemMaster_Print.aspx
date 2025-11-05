<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_ItemMaster_Print, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

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
  
    <table width="100%" cellpadding="0" cellspacing="0">
               <tr>
                        <td   align="left" valign="middle"  scope="col" class="fontcsswhite" 
                            style="background:url(../../../images/hdbg.JPG)" height="21">
                    &nbsp;<b>Item Master- Print&nbsp;</b></td>
                    </tr>
  
  
                    <%--<tr>
            <td  height="25" valign="middle" >
            
                <asp:DropDownList ID="DrpCategory" runat="server" 
                    AutoPostBack="True" 
                    
                    CssClass="box3">
                    
                </asp:DropDownList> 
                
                 &nbsp;&nbsp;
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="  View  " CssClass="redbox" onclick="btnSearch_Click"  />
                        &nbsp;</td>
             </tr>--%>
             
              <tr>
            <td class="fontcsswhite" height="25" valign="middle" >
            
             &nbsp;
            
            <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem Value="Category">Category</asp:ListItem>
                     <asp:ListItem Value="WOItems">WO Items</asp:ListItem>                    
                </asp:DropDownList>
               <%-- &nbsp;<asp:RequiredFieldValidator ID="ReqDrpType" runat="server" 
                    ControlToValidate="DrpType" ErrorMessage="*" InitialValue="Select" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>--%>
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
                     <asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem>
                </asp:DropDownList>
                
                <asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px" 
                    onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="box3">
                            </asp:DropDownList>

            
                <asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>
                
                &nbsp;<asp:Button ID="btnSearch" runat="server" 
            Text="View" CssClass="redbox" onclick="btnSearch_Click" ValidationGroup="A"  />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
             </tr>
  
  
 <tr>
 
 
 <td>
                    <iframe id="Iframe1"  runat ="server" width="100%" height="440px" 
                        frameborder="0" scrolling="auto" ></iframe>
 
             </td>   
             </tr>
         </table>        
                
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

