<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsInwardNote_GIN_New, newerp_deploy" title="ERP" debug="true" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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

   <table width ="100%" cellpadding=0 cellspacing=0 class="fontcss">
        <tr>
       <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Inward Note [GIN] - New</b></td>
           </tr>
        <tr>
       <td   align="justify"  valign="middle" class="style2"> 
                &nbsp;&nbsp;<b></b>&nbsp; 
                     <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                   <%-- <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">Supplier Name</asp:ListItem>                   
                     <asp:ListItem Value="1">PO No</asp:ListItem>
                       
                </asp:DropDownList>
            
                <asp:TextBox ID="txtEnqId" runat="server" CssClass="box3" Width="150px"></asp:TextBox>                  
                <asp:TextBox ID="txtSupplier" 
                    runat="server" Width="332px" style="margin-left: 0px" CssClass="box3" ></asp:TextBox>
                               <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1"  
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplier" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                &nbsp;&nbsp;<asp:Button 
                                    ID="Button1" runat="server"  Text="Search" 
                                    onclick="Button1_Click" CssClass="redbox" />&nbsp;</td>
           </tr>
        <tr>
            <td>
           <%-- <iframe src="" id="myframe"  runat="server"  width="99%" height="430" frameborder="0" >        
        </iframe>--%>
         
        <%--<asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
        <ContentTemplate >--%>
       
     <asp:GridView ID="GridView2" DataKeyNames="Id" runat="server" AutoGenerateColumns="False" 
                                            CssClass="yui-datatable-theme" 
            Width="100%" ShowFooter="false" 
                                            AllowPaging="True" 
            onrowcommand="GridView2_RowCommand" 
            onpageindexchanging="GridView2_PageIndexChanging" PageSize="15" 
           >
                                            <PagerSettings PageButtonCount="40" />
                                            <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Id " Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
      
                                                <asp:TemplateField HeaderText="Fin Year Id" Visible="false">
                                                <ItemTemplate>
                                    <asp:Label ID="lblFinYearId" runat="server" Text='<%# Eval("FinYearId") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Fin Year">
                                                <ItemTemplate>
                                    <asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
      
                                               <asp:TemplateField HeaderText="PO No ">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                                    
                                                   
                                    <asp:TemplateField HeaderText="PO Date ">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPODate" runat="server" Text='<%# Eval("PODate") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of Supplier">
                        <ItemTemplate>
                        <asp:Label ID="lblsupp" runat="Server" Text='<%#Eval("Supplier")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Justify" Width="40%" />
                        </asp:TemplateField>   
                                    <asp:TemplateField HeaderText="Challan No">
                                    <ItemTemplate>
                                   
                                    <asp:TextBox ID="txtChallanNo" runat="server" Text="0" Width="85%" CssClass="box3"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator
                                        ID="ReqChNo" runat="server" ErrorMessage="*" ValidationGroup="A" ControlToValidate="txtChallanNo"></asp:RequiredFieldValidator></ItemTemplate>
                                    
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="Challan Date">
                                    <ItemTemplate>
                                    
                                    <asp:TextBox ID="TxtChallanDate" runat="server" Width="70"  CssClass="box3"></asp:TextBox>
    <cc1:CalendarExtender ID="TxtChallanDate_CalendarExtender" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtChallanDate" CssClass="cal_Theme2" PopupPosition="BottomRight">
    </cc1:CalendarExtender>
                           <%--  <asp:RequiredFieldValidator
                                        ID="ReqChDate" runat="server" ErrorMessage="*" ValidationGroup="A" ControlToValidate="TxtChallanDate"></asp:RequiredFieldValidator>  --%>
                                        
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorChallanDate" runat="server" ControlToValidate="TxtChallanDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>
                            
                             
                          
                           </ItemTemplate>
                                   
                                     <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                   <asp:TemplateField >
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkButton" Text="Select" runat="server" CommandName="Sel" ValidationGroup="A" >
                            </asp:LinkButton>
                        </ItemTemplate>
                       
                            <ItemStyle HorizontalAlign="Center" />
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
                                    
                                    
                                    
                                    
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                            </asp:GridView> 
                            
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
        
         </td>
        </tr>
    </table>
&nbsp;
  

</asp:Content>
<asp:Content ID="Content8"  ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

