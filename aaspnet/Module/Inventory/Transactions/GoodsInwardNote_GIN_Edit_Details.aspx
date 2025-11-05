<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsInwardNote_GIN_Edit_Details, newerp_deploy" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
      
      
        <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
        <table class="fontcss" width="100%" cellpadding="0" cellspacing="0">
             <tr>
       <td   align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" 
                height="21" class="fontcsswhite"><b>&nbsp;Goods Inward Note [GIN] - Edit</b></td>
           </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td class="style10" height="30px">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="GIN No"></asp:Label>
                            &nbsp;: <asp:Label ID="Lblgnno" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Challan Date"></asp:Label>
                                :
                    <asp:Label ID="LblChallanDate" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
                            </td>
                            <td height="30px" colspan="4">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Challan No "></asp:Label>
                                :
                    <asp:Label ID="lblChallanNo" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
                            </td>
                            <td height="30px">
                                <asp:Label ID="LblWODept" runat="server"></asp:Label>
&nbsp;:
                                <asp:Label ID="LblWONo" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="30px">
                    Gate Entry No:                     
&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TxtGateentryNo" runat="server" CssClass="box3"></asp:TextBox>
                                </td>
                            <td>
                    Date : <asp:TextBox ID="TxtGDate" runat="server" CssClass="box3" Width="75px"></asp:TextBox> 
                     <cc1:CalendarExtender ID="TxtChallanDate_CalendarExtender" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtGDate" CssClass="cal_Theme2" PopupPosition="BottomRight">
    </cc1:CalendarExtender>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorChallanDate" runat="server" ControlToValidate="TxtGDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>
                            
&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtGDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp; </td>
                            <td>
                                Time&nbsp; :</td>
                            <td align="left">
                    <MKB:TimeSelector ID="TimeSelector1" runat="server" AmPm="AM" 
                                MinuteIncrement="1">
                            </MKB:TimeSelector>
                                </td>
                            <td align="left">
                                Mode of Transport :
                    <asp:TextBox ID="TxtModeoftransport" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtModeoftransport" ErrorMessage="*" 
                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                            <td>
                                &nbsp;Vehicle No :&nbsp;
                    <asp:TextBox ID="TxtVehicleNo" runat="server" CssClass="box3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtVehicleNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:GridView ID="GridView1"  runat="server" 
                    AutoGenerateColumns="False"  Width="100%" DataKeyNames="Id" 
                    CssClass="yui-datatable-theme" 
                    AllowPaging="True" 
                         onrowcancelingedit="GridView1_RowCancelingEdit" 
                         onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                         onpageindexchanging="GridView1_PageIndexChanging1" 
                         onrowcommand="GridView1_RowCommand" PageSize="15" 
                        >
                
                         <PagerSettings PageButtonCount="40" />
                
                <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                       <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                                               
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    <asp:Label ID="lblgrr" runat="server" Text="GRR" Visible="false"></asp:Label>&nbsp;<asp:Label ID="lblgsn" runat="server" Text="GSN" Visible="false"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" ValidationGroup="A"
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    
                                    <asp:Label ID="lblgrr" runat="server" Text="GRR" Visible="false"></asp:Label>&nbsp;<asp:Label ID="lblgsn" runat="server" Text="GSN" Visible="false"></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                                               
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                        </ItemTemplate>           
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ItemId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'>    </asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Image" >
                        <ItemTemplate>
                       
                            <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Spec. Sheet" >
                        <ItemTemplate>
                         <asp:LinkButton ID="btnlnkSpec" CommandName="downloadSpec" Visible="true"  Text='<%# Bind("AttName") %>'  runat="server"></asp:LinkButton>
                         
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center"  Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'>
                        </asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>   
<asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                        <asp:Label ID="lblPurChaseDesc" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>     
                             <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                        <ItemTemplate>
                        <asp:Label ID="lblUOMPurchase" runat="server" Text='<%#Eval("UOM") %>' >    </asp:Label>               
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                                                 
                        
                        <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>' Visible="true">    </asp:Label>
                          
                                    
                        </ItemTemplate>                  
                        <EditItemTemplate>                                                 
                           
                               <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("Category") %>' Visible="true">    </asp:Label>    
                              <asp:DropDownList ID="ddCategory" runat="server" DataSourceID="SqlDataSource2" 
                          DataTextField="Category" DataValueField="Id" AutoPostBack="true"   ValidationGroup="A"
                     onselectedindexchanged="ddCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddCategory" runat="server" ControlToValidate="ddCategory" 
                        ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>   
                            </EditItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="Sub-Cate" SortExpression="SubCategory">
                        <ItemTemplate>
                        <asp:Label ID="lblSubCategory" runat="server" Text='<%#Eval("SubCategory") %>' Visible="true">    </asp:Label>
                                         
                        </ItemTemplate>
                         <EditItemTemplate> 
                           <asp:Label ID="lblSubCategory1" runat="server" Text='<%#Eval("SubCategory") %>' Visible="true">    </asp:Label>
                        <asp:DropDownList ID="ddSubCategory" runat="server"    ValidationGroup="A" >
                         <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddSubCategory" runat="server" ControlToValidate="ddSubCategory" 
                        ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>      
                         </EditItemTemplate>
                         
                         
                         
                            <ItemStyle  HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        
<%--                        <asp:TemplateField HeaderText="Asset No" SortExpression="AssetNo" >
                        <ItemTemplate>
                        <asp:Label ID="lblAssetNo" runat="server" Text='<%#Eval("AssetNo") %>'>    </asp:Label> 
                         </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField> --%>      
                        
                        
                        <asp:TemplateField HeaderText="PO Qty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblPOQty" runat="server" Text='<%#Eval("poqty") %>' > </asp:Label>
                                     
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" />
                                     
                                     </asp:TemplateField>
                                     
                                       <asp:TemplateField HeaderText=" Tot Recd Qty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblTotRecdQty" runat="server" Text='<%#Eval("TotRecdQty") %>' > </asp:Label>
                             </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Right" Width="7%" /> 
                           
                                     </asp:TemplateField>  
                                   <asp:TemplateField HeaderText="Challan Qty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblChallanQty" runat="server" Text='<%#Eval("ChallanQty") %>' > </asp:Label>
                                     </ItemTemplate>
                                       <EditItemTemplate>
                                           <asp:TextBox Width="60" class="box3" ID="TxtChallanQty" runat="Server" Text='<%#Eval("ChallanQty") %>'></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegChQty" runat="server" ErrorMessage="*" ControlToValidate="TxtChallanQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator
                                        ID="ReqChNo" runat="server" ErrorMessage="*" ValidationGroup="A" ControlToValidate="TxtChallanQty"></asp:RequiredFieldValidator></ItemTemplate>
                                       </EditItemTemplate>
                                       <ItemStyle HorizontalAlign="Right" Width="7%" />
                                     </asp:TemplateField>
                                     <asp:TemplateField Visible="false">
                                     <ItemTemplate>
                                     <asp:Label ID="lblChnQty" runat="server" Text='<%#Eval("ChallanQty") %>'  > </asp:Label>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="6%" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Recd Qty ">
                                     <ItemTemplate>
                                     <asp:Label ID="lblReceivedQty" runat="server" Text='<%#Eval("RecedQty") %>'  > </asp:Label>  
                                     </ItemTemplate>
                                    
                                     <EditItemTemplate>
                                     <asp:TextBox ID="TxtRecedQty" Width="60" class="box3" runat="Server" Text='<%#Eval("RecedQty") %>'  ></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegRecQty" runat="server" ErrorMessage="*" ControlToValidate="TxtRecedQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator
                                        ID="ReqRecQty" runat="server" ErrorMessage="*" ValidationGroup="A" ControlToValidate="TxtRecedQty"></asp:RequiredFieldValidator>
                                     </EditItemTemplate>                                   
                                      <ItemStyle HorizontalAlign="Right" Width="7%" />
                                     </asp:TemplateField> 
                                      <asp:TemplateField Visible="false">
                                     <ItemTemplate>
                                     <asp:Label ID="lblRecQty" runat="server" Text='<%#Eval("RecedQty") %>'  > </asp:Label>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" />
                                     </asp:TemplateField> 
                                                             
                            <asp:TemplateField HeaderText="POId" Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="lblPOId" runat="server" Text='<%#Eval("POId") %>' > </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                            </asp:TemplateField>  
    
    
                            <asp:TemplateField HeaderText="CategoyId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblCategoyId" runat="server" Text='<%#Eval("CategoryId") %>'>    </asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
    
                         <asp:TemplateField HeaderText="SubCategoryId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblSubCategoryId" runat="server" Text='<%#Eval("SubCategoryId") %>'>    </asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
    
    
                                  
                          <asp:TemplateField HeaderText="AHId" SortExpression="AHId" Visible="false" >
                        <ItemTemplate>
                        <asp:Label ID="lblAHId" runat="server" Text='<%#Eval("AHId") %>'>    </asp:Label> 
                         </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="2%"/>
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
                </asp:GridView></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                        onclick="btnCancel_Click" Text="Cancel" />
                        
                          <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="select Id,Abbrivation AS Category from tblACC_Asset_Category"> 
                       
                </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
