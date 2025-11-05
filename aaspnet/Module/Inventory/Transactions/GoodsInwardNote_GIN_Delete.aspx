<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsInwardNote_GIN_Delete, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            height: 34px;
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
<table width ="100%" cellpadding="0" cellspacing="0" >
        <tr>
       <td   align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Inward Note [GIN] - Delete</b></td>
           </tr>
        <tr>
       <td   align="justify"  valign="middle" class="style2"> 
                &nbsp;&nbsp;
                     <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <%-- <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">Supplier Name</asp:ListItem>                   
                     <asp:ListItem Value="1">PO No</asp:ListItem>
                       <asp:ListItem Value="2">GIN No</asp:ListItem>
                </asp:DropDownList>
            
                <asp:TextBox ID="txtEnqId" runat="server" CssClass="box3" Width="150px"></asp:TextBox>    
                <asp:TextBox ID="txtSupplier" runat="server" Width="332px" 
                    style="margin-left: 0px" CssClass="box3" ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplier" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>                       
        
                &nbsp;<asp:Button 
                                    ID="Button1" runat="server"  Text="Search" 
                                    onclick="Button1_Click" CssClass="redbox" />&nbsp;<asp:Button 
                    ID="btnCancel" runat="server" CssClass="redbox" onclick="btnCancel_Click" 
                    Text="Cancel" />
            </td>
           </tr>
        <tr>
            <td>
            <%--<iframe src="" id="myframe"  runat="server"  width="99%" height="430Px" frameborder="0" >        
        </iframe> --%>
            
             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" AllowPaging="True" 
                    Width="100%" onrowcommand="GridView2_RowCommand" 
                                onpageindexchanging="GridView2_PageIndexChanging" 
                                PageSize="20">
                                <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="btnlnk" runat="Server" CommandName="sel" Text="Select" />
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fin Year">
                        <ItemTemplate>
                        <asp:Label ID="lblFin" runat="Server" Text='<%#Eval("FinYear")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PONo">
                        <ItemTemplate>
                        <asp:Label ID="lblpo" runat="Server" Text='<%#Eval("PONo")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="GIN No">
                         <ItemTemplate>
                        <asp:Label ID="lblGin" runat="Server" Text='<%#Eval("GINNo")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                        <asp:Label ID="lbldate" runat="Server" Text='<%#Eval("SysDate")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name of Supplier">
                        <ItemTemplate>
                        <asp:Label ID="lblsupp" runat="Server" Text='<%#Eval("Supplier")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Justify" Width="30%" />
                        </asp:TemplateField>                        
                         <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>'/>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Challan No">
                        <ItemTemplate>
                        <asp:Label ID="lblchno" runat="Server" Text='<%#Eval("ChNO")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Challan Date">
                        <ItemTemplate>
                        <asp:Label ID="lblchdt" runat="Server" Text='<%#Eval("ChDT")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
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
                    
                </asp:GridView>
            
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

