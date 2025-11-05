<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialPlanning_Transactions_Planning_Delete, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
                    <tr >                   
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >&nbsp;<strong>Material Planning - Delete</strong>
                       
                        </td>
                    </tr>   
              </table>
                
                <table width="100%" align="center" cellpadding="0" cellspacing="0" class="box3">
                    <tr>
        <td align="left" height="25" >
        
          
            <asp:DropDownList ID="DrpField" runat="server" 
                 AutoPostBack="True" 
                CssClass="box3" onselectedindexchanged="DrpField_SelectedIndexChanged">
               <%-- <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                <asp:ListItem Value="1">WO No</asp:ListItem>
                <asp:ListItem Value="0">Customer Name</asp:ListItem>              
               <asp:ListItem Value="2">PO No</asp:ListItem>
               <asp:ListItem Value="3">Enq Id</asp:ListItem>
            </asp:DropDownList>
         
            <asp:TextBox ID="Txtsearch" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
              <asp:TextBox ID="txtCustName" runat="server"   Visible="false" Width="350px"></asp:TextBox>
            
              <cc1:AutoCompleteExtender ID="txtCustName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtCustName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
           
           
        
              &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
            
        
        
              &nbsp;<asp:Label ID="lblmsg" runat="server" 
                style="color: #CC0000; font-weight: 700"></asp:Label>
            
        
        
              </td>
        </tr>

             <tr>
            <td>                     
  
                     <asp:GridView ID="GridView1"  runat="server" PageSize="17" 
                    AllowPaging="True"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="WONo" RowStyle-HorizontalAlign ="Center"
     
                     Width="100%" onpageindexchanging="GridView1_PageIndexChanging" >
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
            <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
 <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CustomerName" 
                    HeaderText="Customer Name" >
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" >
                                      <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" >
                                      <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:BoundField>
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" >
                                      <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                                  <asp:HyperLinkField DataNavigateUrlFields="WONo" 
                    HeaderText="WO No" 
                    DataNavigateUrlFormatString="~/Module/MaterialPlanning/Transactions/Planning_Delete_Plan.aspx?WONo={0}&amp;ModId=4&amp;SubModId=33" 
                    DataTextField="WONo" >
                                      <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" >
                                      <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            
                                      <ItemStyle HorizontalAlign="Left" Width="32%" />
                </asp:BoundField>
                            
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

