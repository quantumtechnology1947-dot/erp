<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_WorkOrder_Print, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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


<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>           
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" ><strong>&nbsp;Work 
                            Order - Print </strong>
                        </td>
                    </tr>

             <tr>
            <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <%--<asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                     <asp:ListItem Value="2">PO No</asp:ListItem>
                         <asp:ListItem Value="3">WO No</asp:ListItem>
                </asp:DropDownList>
           
              
              
                <asp:TextBox ID="txtEnqId" runat="server" CssClass="box3" 
                    Width="150px"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                      <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                    
                   <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>

             <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="Id" RowStyle-HorizontalAlign ="Center" PageSize="100"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    onrowcommand="SearchGridView1_RowCommand" >
            
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                    <%#Container.DataItemIndex+1  %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:TemplateField>
                               
                    <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:BoundField>
                    
                    <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                    </asp:BoundField>
                                
                                    
                                    
                     <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                    <asp:Label ID="lblCustomerId" Text='<%# Eval("CustomerId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  Width="8%"  />
                    </asp:TemplateField>
                    
                           
                     <asp:TemplateField  HeaderText="Enquiry No.">
                    <ItemTemplate>
                     <asp:Label ID="lblEnqId" Text='<%# Eval("EnqId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>   
                    
                    <asp:TemplateField  HeaderText="PONo">
                    <ItemTemplate>
                     <asp:Label ID="lblPONo" Text='<%# Eval("PONo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left"   Width="15%"/>
                    </asp:TemplateField> 
                    
                    
                     <asp:TemplateField  HeaderText="PO Id" Visible="false">
                    <ItemTemplate>
                     <asp:Label ID="lblPOId" Text='<%# Eval("POId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center"  />
                    </asp:TemplateField> 
                    

                    <asp:TemplateField HeaderText="Id" Visible="False">
                    <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                    </asp:TemplateField>
                                                                
                     <asp:TemplateField HeaderText="WO No">
                    <ItemTemplate>
                    <asp:LinkButton ID ="lnkButton"  Text='<%# Eval("WONo") %>' runat ="server" CommandName="sel">
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  Width="8%"/>
                    </asp:TemplateField>
                                    
                              
                
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" >
                                  <ItemStyle HorizontalAlign="Center" Width="8%" />
                                  </asp:BoundField  >   
                                  
                            <asp:TemplateField HeaderText="Status" >
                            <ItemTemplate>
                            <asp:Label ID="LblStatus" runat="server"  Text='<%#Eval("CloseOpen") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                           <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:BoundField  >     
                            
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

            </td>
             </tr>
              </table>
            </td>
        </tr>
        
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

