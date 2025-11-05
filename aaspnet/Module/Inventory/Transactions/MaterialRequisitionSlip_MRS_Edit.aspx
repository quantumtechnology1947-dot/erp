<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialRequisitionSlip_MRS_Edit, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    <table class="style2" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Requisition Slip [MRS] - Edit</b></td>
        </tr>
        
        <tr>
                    <td height="25">

                    &nbsp;
                    <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                    onselectedindexchanged="drpfield_SelectedIndexChanged" AutoPostBack="True">
                    <%--<asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">Employee Name</asp:ListItem>
                    <asp:ListItem Value="1">MRS No</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="txtEmpName" runat="server" CssClass="box3"  Width="350px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                    ServicePath="" TargetControlID="txtEmpName" UseContextKey="True"
                    CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" 
                    MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                    </cc1:AutoCompleteExtender>
                    &nbsp;<asp:TextBox ID="txtMrsNo" runat="server"  Visible="False" CssClass="box3"></asp:TextBox>
                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Search" />
                    </td>
                    </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="98%"  PageSize="20"
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcommand="GridView1_RowCommand" >
                    <PagerSettings PageButtonCount="40" />
                <Columns>                
                    
                    <asp:TemplateField HeaderText="SN"> 
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" Width="5%" />
                </asp:TemplateField>
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="btnlnk" runat="Server" CommandName="Sel" Text="Select" />
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                        
                <asp:TemplateField HeaderText="Id"  Visible="false" >
                <ItemTemplate>
                <asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' ></asp:Label>
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
                  <ItemStyle HorizontalAlign="Center" Width="10%" />
                  </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="MRS No" >
                 <ItemTemplate>
                 <asp:Label ID="lblMRSNo" runat="server" Text='<%# Eval("MRSNo") %>' ></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>               
                
                 <asp:TemplateField HeaderText="Date" >
                 <ItemTemplate>
                 <asp:Label ID="lblDate" runat="server" Text='<%# Eval("SysDate") %>' ></asp:Label>
                 </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Gen By" >
                 <ItemTemplate><asp:Label ID="lblGenBy" runat="server" Text='<%# Eval("GenBy") %>' ></asp:Label>
                 </ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" Width="45%" />
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
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
&nbsp;
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

