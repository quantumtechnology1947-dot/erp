<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsQualityNote_GQN_Print, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 24px;
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite">
                <b>&nbsp;Goods Quality Note [GQN] - Print</b></td>
        </tr>
        <tr>
            <td height="28">
                 <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                   <%--  <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                     <asp:ListItem Value="0">Supplier Name</asp:ListItem>
                     <asp:ListItem Value="1">GQN No</asp:ListItem>
                     <asp:ListItem Value="2">GRR No</asp:ListItem>
                          <asp:ListItem Value="3">PO No</asp:ListItem>
                       
                </asp:DropDownList>
                <asp:TextBox ID="txtSupplier" runat="server" Width="291px" CssClass="box3"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplier" UseContextKey="True"  CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                           <asp:TextBox ID="Txtfield" runat="server" CssClass="box3"></asp:TextBox>  
                &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" AllowPaging="True" 
                    Width="100%" onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1  %>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="10pt" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnlnk" runat="Server" CommandName="Sel" Text="Select" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fin Year Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFinId" runat="Server" Text='<%#Eval("FinYearId")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fin Year">
                            <ItemTemplate>
                                <asp:Label ID="lblFin" runat="Server" Text='<%#Eval("FinYear")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GQN No">
                        <ItemTemplate>
                        <asp:Label ID="lblgqnno" runat="server" Text='<%#Eval("GQNNo") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GINId No" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblginid" runat="server" Text='<%#Eval("GINId") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lbldate" runat="Server" Text='<%#Eval("SysDate")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GRR No">
                            <ItemTemplate>
                                <asp:Label ID="lblGrrNo" runat="Server" Text='<%#Eval("GRRNo")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GIN No">
                            <ItemTemplate>
                                <asp:Label ID="lblGin" runat="Server" Text='<%#Eval("GINNo")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PONo">
                            <ItemTemplate>
                                <asp:Label ID="lblpo" runat="Server" Text='<%#Eval("PONo")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name of Supplier">
                            <ItemTemplate>
                                <asp:Label ID="lblsupp" runat="Server" Text='<%#Eval("Supplier")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Justify" Width="30%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sup Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblsupId" runat="Server" Text='<%#Eval("SupId")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
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
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                    
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

