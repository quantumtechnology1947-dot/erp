<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PO_Print.aspx.cs" Inherits="Module_MaterialManagement_Transactions_PO_Print" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            height: 23px;
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
    <table align="center" cellpadding="0" cellspacing="0"
        width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" align="left">
                    <tr>
                        <td align="left" valign="middle"  scope="col" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21">
        &nbsp;<b>PO - Print</b></td>
                    </tr>
                     <tr>
                        <td height="25">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                onselectedindexchanged="drpfield_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0">Employee Name</asp:ListItem>
                                <asp:ListItem Value="1">PO No</asp:ListItem>
                            </asp:DropDownList>
&nbsp;
                <asp:TextBox ID="txtEmpName" runat="server" CssClass="box3"  Width="350px"></asp:TextBox>
                             
                            <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtEmpName" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                             
                            &nbsp;<asp:TextBox ID="txtpoNo" runat="server"  Visible="False" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox"  Text="Search" 
                                onclick="btnSearch_Click" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                                onclick="btnCancel_Click" Text="Cancel" />
                        </td>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView2" runat="server"
                                PageSize="20" Width="900px" 
                                AutoGenerateColumns="False" AllowPaging="True" 
                                CssClass="yui-datatable-theme" onrowcommand="GridView2_RowCommand" 
                                onpageindexchanging="GridView2_PageIndexChanging1">
                                <FooterStyle Wrap="True"></FooterStyle>
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
                                <PagerSettings PageButtonCount="40" />
                <Columns>
               <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>             
                <HeaderStyle Font-Size="10pt" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                 </asp:TemplateField>
                  <asp:TemplateField>
                           <ItemTemplate>
                           <asp:LinkButton ID ="Old" Text="Old" runat ="server" CommandName="old" >
                           </asp:LinkButton>
                           </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" />
                           </asp:TemplateField>
                           <asp:TemplateField>
                           <ItemTemplate>
                           <asp:LinkButton ID ="lnkButton" Text="Select" runat ="server" CommandName="sel">
                           </asp:LinkButton>
                           </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" />
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Id" Visible="false">
                          <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                         </asp:TemplateField>
                           <asp:TemplateField HeaderText="Fin Year Id" Visible="false">
                          <ItemTemplate>
                        <asp:Label ID="lblFinYearId" Text='<%# Eval("FinYearId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Fin Year">
                          <ItemTemplate>
                        <asp:Label ID="lblFinYear" Text='<%# Eval("FinYear") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="PO No">
                        <ItemTemplate>
                        <asp:Label ID="lblpono" Text='<%# Eval("PONo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Date">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                             
                        <asp:TemplateField HeaderText="Amd No">
                        <ItemTemplate>
                       <%-- <asp:Label ID="lblTime" Text='<%# Eval("AmdNo") %>' runat="server"></asp:Label>--%>
                        
                            <asp:DropDownList  ID="AmdDropDown" CssClass="box3" Width="50px" runat="server"></asp:DropDownList>
                            
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gen. By">
                        <ItemTemplate>
                        <asp:Label ID="lblGenBy" Text='<%# Eval("GenBy") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="35%" />
                        </asp:TemplateField>
                        
                    <asp:TemplateField HeaderText="Download">
                    
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkBtnDownload" runat="server" CommandName="Download" Text='<%# Eval("FileName") %>' >
                        </asp:LinkButton>
                        <%--<asp:Label ID="lblFileName" Text='<%# Eval("FileName") %>' runat="server"></asp:Label>--%>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
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
            </td>
        </tr>
    </table>
      
  
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
