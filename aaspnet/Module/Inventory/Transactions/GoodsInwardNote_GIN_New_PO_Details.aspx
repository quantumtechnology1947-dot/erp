<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" inherits="Module_Inventory_GoodsInwardNote_GIN_New_PO_Details, newerp_deploy" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />    
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            height: 26px;
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
 <table class="fontcss" cellpadding="0" cellspacing="0" width="100%">
 
 <tr>
       

            <tr>
                <td colspan="4" align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Inward Note [GIN] - New</b></td>
            </tr>
    

            <tr>
                <td colspan="4" height="30px">
                    <asp:Label ID="Label1" runat="server" Text="PONo"></asp:Label>
                    :
                    <asp:Label ID="LblPONo" runat="server" Text="" style="font-weight: 700"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Challan No "></asp:Label>
                    :
                    <asp:Label ID="lblChallanNo" runat="server" Text="" 
                        style="font-weight: 700"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Challan Date"></asp:Label>
                    :
                    <asp:Label ID="LblChallanDate" runat="server" Text="" 
                        style="font-weight: 700"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mode of Transport 
                    :
                    <asp:TextBox ID="TxtModeoftransport" Text="-" runat="server" ValidationGroup="A" 
                        CssClass="box3"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtModeoftransport" ErrorMessage="*" 
                        ValidationGroup="A"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    Vehicle No :
                    <asp:TextBox ID="TxtVehicleNo" runat="server" Text="-" CssClass="box3"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtVehicleNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="30px" width="33%">
                    Gate Entry No:                     <asp:TextBox ID="TxtGateentryNo" 
                        runat="server" CssClass="box3"></asp:TextBox>
&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TxtGateentryNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</td>
                <td class="style2" width="33%">
                    Date :
                    <asp:TextBox ID="TxtGDate" runat="server" CssClass="box3"></asp:TextBox> 
                     <cc1:CalendarExtender ID="TxtChallanDate_CalendarExtender" CssClass="cal_Theme2" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtGDate" PopupPosition="BottomRight">
    </cc1:CalendarExtender>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorChallanDate" runat="server" ControlToValidate="TxtGDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>
                            
&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtGDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;</td>
                <td class="style2" align="right">
                    &nbsp; Time&nbsp; :</td>
                <td class="style2">
                    <MKB:TimeSelector ID="TimeSelector1" runat="server" AmPm="AM" 
                                MinuteIncrement="1">
                            </MKB:TimeSelector>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                
                 <asp:Panel ID="Panel1" ScrollBars="Auto" Height="390px" runat="server">
                    
                     <asp:GridView ID="GridView1"  runat="server"
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" DataKeyNames="Id" 
                    CssClass="yui-datatable-theme" onrowcommand="GridView1_RowCommand"  
                        
                         ondatabound="GridView1_DataBound" >
                
                         <PagerSettings PageButtonCount="40" />
                
                <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                       <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                                               
             
                                               
                       <asp:TemplateField >
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                       
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
        </asp:TemplateField>
                                               
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label> 
                            </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="AHId" SortExpression="AHId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblAHId" runat="server" Text='<%#Eval("AHId") %>'>    </asp:Label> 
                         </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="ItemId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'>    </asp:Label>                                  </ItemTemplate>
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
                        
                        
                        
                        
                        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
                        <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        
                        </asp:TemplateField>
                        
                       
                                               
                         <asp:TemplateField HeaderText="Description" SortExpression="Description">
                        <ItemTemplate>
                        <asp:Label ID="lblPurChaseDesc" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>
                                            
                             <ItemStyle HorizontalAlign="Left" Width="20%" />
                             
                                            
                        </asp:TemplateField>
                        
                        
                       
                        
                        <asp:TemplateField HeaderText="UOM" SortExpression="UOMBasic">
                            
                        <ItemTemplate>
                        <asp:Label ID="lblUOMPurchase" runat="server" Text='<%#Eval("UOM") %>' >    </asp:Label>
                        
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                                            
                        </asp:TemplateField>
                        
                        
                          <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text="NA" Visible="false">    </asp:Label>
                          
                 <asp:DropDownList ID="ddCategory" runat="server" DataSourceID="SqlDataSource1" 
                          DataTextField="Expr1" DataValueField="Id" AutoPostBack="true" Visible="false" ValidationGroup="A"
                     onselectedindexchanged="ddCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddCategory" runat="server" ControlToValidate="ddCategory" 
                        ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>                        
                        </ItemTemplate>                  
                        
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="Sub-Cate" SortExpression="SubCategory">
                        <ItemTemplate>
                        <asp:Label ID="lblSubCategory" runat="server" Text="NA" Visible="false">    </asp:Label>
                        <asp:DropDownList ID="ddSubCategory" runat="server" Visible="false"  ValidationGroup="A" >
                         <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="ReqddSubCategory" runat="server" ControlToValidate="ddSubCategory" 
                        ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>                           
                        </ItemTemplate>
                         
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                        
                
                                   <asp:TemplateField HeaderText="PO Qty" SortExpression ="Qty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblPOQty" runat="server" Text='<%#Eval("Qty") %>' > </asp:Label>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Tot GQN Qty" SortExpression ="TotRecQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblTotRecdQty" runat="server" Text='<%#Eval("TotRecdQty") %>' > </asp:Label>
                                     </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" Width="8%" />
                                     </asp:TemplateField> 
                                     
                                     <asp:TemplateField HeaderText="Tot GSN Qty" SortExpression ="TotGSNQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblTotGSNQty" runat="server" Text='<%#Eval("TotGSNQty") %>' > </asp:Label>
                                     </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" Width="8%" />
                                     </asp:TemplateField> 
                                     
                                     
                                     <asp:TemplateField HeaderText="Tot GIN Qty" SortExpression ="TotGINQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblTotGINQty" runat="server" Text='<%#Eval("TotGINQty") %>' > </asp:Label>
                                     </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" Width="8%" />
                                     </asp:TemplateField>   
                                     
                                     <asp:TemplateField HeaderText="Tot Rej Qty" SortExpression ="TotRejQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblTotRejQty" runat="server" Text='<%#Eval("TotRejQty") %>' > </asp:Label>
                                     </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" Width="8%" />
                                     </asp:TemplateField>       
                                   
             <asp:TemplateField HeaderText="Challan Qty" SortExpression ="ChallanQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblChallanQty" runat="server"  > </asp:Label>
                                     <asp:TextBox ID="TxtChallanQty" EnableViewState="true" runat="server" Visible="false" Width="70%" CssClass="box3"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ControlToValidate="TxtChallanQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator> 
                                         <asp:RequiredFieldValidator ID="Req1" runat="server" ErrorMessage="*"  ControlToValidate="TxtChallanQty" ValidationGroup="A" ></asp:RequiredFieldValidator>
                                     
                                      <asp:HiddenField ID="HiddenField1" runat="server" />
                                     </ItemTemplate><ItemStyle HorizontalAlign="left" Width="8%" />
                                      
                                     
                                     </asp:TemplateField>  
                                     
                                       <asp:TemplateField HeaderText="Recd Qty" SortExpression ="ReceivedQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblReceivedQty" runat="server" > </asp:Label>
                                     <asp:TextBox ID="TxtReceivedQty" runat="server" Text='<%#Eval("TotRemainQty") %>' EnableViewState="true"  Visible="false" Width="75%" CssClass="box3"></asp:TextBox>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="TxtReceivedQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator> 
        <asp:RequiredFieldValidator ID="Req2" runat="server" ErrorMessage="*"  ControlToValidate="TxtReceivedQty" ValidationGroup="A" ></asp:RequiredFieldValidator>
         <asp:HiddenField ID="HiddenField2" runat="server" />
        
                                     </ItemTemplate><ItemStyle HorizontalAlign="left" Width="12%" />
                                     <FooterTemplate>
                                
                                
                                     
                                     
                            </FooterTemplate> <FooterStyle HorizontalAlign="center" />
                                     </asp:TemplateField>  
                        
                     
                        
                        
                </Columns>
                
                <EmptyDataTemplate>
                                    <table width="100%" class="fontcss"><tr><td align="center" >
                                    <asp:Label ID="Label1" runat="server"  Text="No  data found to display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                    
                </asp:GridView>
                
                </asp:Panel>
                
                </td>
               
            </tr>
            <tr>
             <td style="height:22px" align="center" colspan="4">
             
             <asp:Button ID="BtnInsert" runat="server" Width="45px" ValidationGroup="A" 
                     OnClientClick="return confirmationAdd()"  CssClass="redbox" Text="Insert" 
                     onclick="BtnInsert_Click"  />
             
             <asp:Button ID="BtnCancel" runat="server" Width="50px" Text="Cancel" onclick="BtnCancel_Click" CssClass="redbox" />
            
 
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="select Id,Abbrivation AS Expr1 from tblACC_Asset_Category">    
                </asp:SqlDataSource>
                               
             
             </td>
            </tr>
            </table>
</asp:Content>
<asp:Content ID="Content8"  ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
