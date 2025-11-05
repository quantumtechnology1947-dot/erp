<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Edit, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />  
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 27px;
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
    <table align="left" cellpadding="0" cellspacing="0"  width ="100%">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>&nbsp;Goods Received Receipt [GRR] - Edit</b></td>
        </tr>
        <tr>
            <td class="style2">
&nbsp;<asp:Label ID="Label2" runat="server" Text="Supplier :"></asp:Label>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" Width="320px" CssClass="box3"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1"
                    DelimiterCharacters="" Enabled="True" FirstRowSelected="True"
                    MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                    ShowOnlyCurrentWordInCompletionListItem="True" 
                    TargetControlID="txtSupplier" UseContextKey="true" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>                           
            &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />
                           
            </td>
        </tr>       
        <tr>
            <td align="left">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" AllowPaging="True" 
                    Width="100%" onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
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
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GRR No">
                        <ItemTemplate>
                        <asp:Label ID="lblGrrNo" runat="Server" Text='<%#Eval("GRRNo")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                        <asp:Label ID="lbldate" runat="Server" Text='<%#Eval("SysDate")%>'/>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GIN Id" Visible="false">
                         <ItemTemplate>
                        <asp:Label ID="lblGinId" runat="Server" Text='<%#Eval("GINId")%>'/>
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
                            <ItemStyle HorizontalAlign="Left" Width="35%" />
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
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
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
                                            <%--<HeaderStyle  Wrap="false" />--%>
                    
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

