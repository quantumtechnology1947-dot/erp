<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PR_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    
        .style3
        {
            height: 37px;
        }
    
        .style4
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

    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PR -Edit &nbsp;&nbsp;&nbsp;&nbsp; PR No: 
            <asp:Label ID="lblwo" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="lbltype" runat="server"></asp:Label></b></td>
        </tr>
        <tr>
            <td align="left" class="style3" valign="top">
               
                            <table align="left" cellpadding="0" cellspacing="0" class="style4">
                               
                                <tr>
                                    <td valign="top"  >
                                        <asp:Panel ID="Panel1" ScrollBars="Auto" Height="452px" runat="server">
                                       
                                      
                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                                OnPageIndexChanging="GridView2_PageIndexChanging"
                                                OnRowCommand="GridView2_RowCommand" style="position:static" Width="100%" 
                                                onrowupdating="GridView2_RowUpdating" onselectedindexchanged="GridView2_SelectedIndexChanged" 
                                              >
                                                
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SN">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false"
                                                OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                 <asp:Label ID="lblEdit" runat="server" Text="PO" Visible="false"></asp:Label>
                                                        </ItemTemplate>                                                         
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Item Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblit" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("PurchDesc") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="20%" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="UOM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbluom" runat="server" Text='<%# Eval("Symbol") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tot Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltotqty" runat="server" Text='<%# Eval("TotQty") %>'  > </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PR Qty">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprqty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Right" Width="6%" />
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="MIN Qty">
                                                        <ItemTemplate>
                                                       <asp:Label ID="lblminqty" runat="server" Text='<%# Eval("MINQty") %>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                
                                                    <asp:TemplateField HeaderText="Supplier">
                                                   
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtSupplier" runat="server" ControlStyle-CssClass="box3" 
                                                                EnableViewState="true" Width="92%" Text='<%# Eval("Supplier") %>'> </asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                                                CompletionInterval="100" CompletionSetCount="2" EnableCaching="true" 
                                                                Enabled="True" FirstRowSelected="True" MinimumPrefixLength="1" 
                                                                ServiceMethod="GetCompletionList" ServicePath="" 
                                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtSupplier" 
                                                                UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                                                            </cc1:AutoCompleteExtender>
                                                            <asp:RequiredFieldValidator ID="ReqSuppler"  Visible="true" runat="server" 
                                            ControlToValidate="TxtSupplier" ErrorMessage="*" ValidationGroup="A">
                                            </asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                        
                                                        <ItemStyle VerticalAlign="Top" Width="12%" />
                                                    </asp:TemplateField>
                                                    
                                                    
                                                    

                                            <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>                                                        
                                            <asp:TextBox ID="TxtRate" runat="server" Text='<%#Eval("Rate") %>' CssClass="box3"  Width="62%"> 
                                            </asp:TextBox>
                                            
                                              <asp:ImageButton ID="ImageButton1"  runat="server" CommandName="rate"
                                               OnClientClick="aspnetForm.target='_blank';"
                                            ValidationGroup="B" ImageUrl="~/images/Rupee.JPG" />      
                                            
                                            <asp:RequiredFieldValidator ID="ReqRate" Visible="true" runat="server" 
                                            ControlToValidate="TxtRate" ErrorMessage="*" ValidationGroup="A">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularRate" runat="server" 
                                            ControlToValidate="TxtRate" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                                            </asp:RegularExpressionValidator>
                                           
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" Width="8%" />
                                            </asp:TemplateField>
                                                    
                                                   
                                                   
                                             <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>                                                        
                                            <asp:TextBox ID="TxtDiscount" runat="server" Text='<%#Eval("Discount") %>' CssClass="box3"  Width="62%"> 
                                            </asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="ReqDisc" Visible="true" runat="server" 
                                            ControlToValidate="TxtDiscount" ErrorMessage="*" ValidationGroup="A">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularDisce" runat="server" 
                                            ControlToValidate="TxtDiscount" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                                            </asp:RegularExpressionValidator>
                                           
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" Width="8%" />
                                            </asp:TemplateField>        
                                                   
                                                   
                                                    
                                                    
                                                    <asp:TemplateField HeaderText="A/c Head">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAhId" runat="server" Text=<%#Eval("AccHead") %>></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Del. Date">
                                                        <ItemTemplate>
                                                     
                                                            <asp:TextBox ID="TxtDelDate" runat="server" CssClass="box3" Width="70px" Text='<%# Eval("DelDate") %>'> </asp:TextBox>
                               
                                <asp:RequiredFieldValidator ID="ReqDelDate" Visible="true" runat="server" 
                                    ControlToValidate="TxtDelDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="TxtDelDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        
                                                          <cc1:CalendarExtender ID="DelDate_CalendarExtender" runat="server" 
                                                                Enabled="True" Format="dd-MM-yyyy" PopupPosition="BottomRight"
                                                                TargetControlID="TxtDelDate">
                                                            </cc1:CalendarExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="7%"  />
                                                        
                                                        
                                                        
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                          
     <asp:TextBox ID="TxtRmk" runat="server" Text='<%#Eval("Remarks") %>' CssClass="box3" Width="99%"> </asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  Visible="False">
                                                        <ItemTemplate><asp:Label ID="LblId" runat ="server" Text='<%#Eval("Id") %>' ></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Item Id" Visible="false">
                                                    <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblitemid" Text='<%# Eval("ItemId") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Type") %>'  > </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="PId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpid" runat="server" Text='<%# Eval("PId") %>'  > </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="CId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcid" runat="server" Text='<%# Eval("CId") %>'  > </asp:Label>
                                                        </ItemTemplate>                                                     
                                                        
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
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
                                                <FooterStyle Font-Bold="False" />
                                                <HeaderStyle Font-Size="9pt" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                <td align="center" valign="bottom">
                                
                                                        
                                                        <asp:Button ID="Btnupdate" runat="server" ValidationGroup="A"  
                                                        OnClientClick="aspnetForm.target='_Self';return confirmationUpdate();" 
                                                          CssClass="redbox"  Text="Update" onclick="Btnupdate_Click"  /> 
                                                         
                                                    &nbsp;<asp:Button ID="btnCancel"  runat="server" Text="Cancel" CssClass="redbox" 
                                                    onclick="btnCancel_Click" OnClientClick=" aspnetForm.target='_Self';" ></asp:Button>
                                </td>
                                </tr>
                            </table>
                      
                   </td>
        </tr>
        
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

