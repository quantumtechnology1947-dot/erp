<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" theme="Default" inherits="Module_Machinery_Transactions_Schedule_Output_Edit, newerp_deploy" title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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
<table width="100%" align="center" cellpadding="0" cellspacing="0" class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" >
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" ><strong>&nbsp;Job Scheduling Output-Edit</strong>
                        </td>
                    </tr>

             <tr>
           <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DrpField" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                     <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">Job No</asp:ListItem>
                   <asp:ListItem Value="1">WO No</asp:ListItem>
                    <asp:ListItem Value="2">Item Code</asp:ListItem>
                </asp:DropDownList>  
                 <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>                     
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>

             <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    RowStyle-HorizontalAlign ="Center" DataKeyNames="Id"                   
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    ShowFooter="false" PageSize="17" onrowcommand="SearchGridView1_RowCommand" >
            
            <RowStyle />
            <Columns>
                           
                                  <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle  Width="5%" HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                
                
                
                                
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle Width="10%" />
                </asp:BoundField>
                
                  <asp:TemplateField HeaderText="WO No"  >
                <ItemTemplate>
            <asp:Label ID="lblWONo" runat="server"  Text='<%#Eval("WONo")%>'/>
                </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Job No"  >
                <ItemTemplate>
            <asp:Label ID="lbljobNo" runat="server"  Text='<%#Eval("JobNo")%>'/>
                </ItemTemplate>
                </asp:TemplateField>                
                 <asp:TemplateField HeaderText="Item Code"  >
                <ItemTemplate>
               <asp:LinkButton ID="btnSel" runat="server" CommandName="Sel" Text='<%# Bind("ItemCode") %>'></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                    
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" /> 
                                  <asp:TemplateField HeaderText="Gen. By">                                      
                                      <ItemTemplate>
                                          <asp:Label ID="lblGenBy" runat="server" Text='<%# Bind("GenBy") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Left" Width="30%" />
                                  </asp:TemplateField>                                 
                 
                 <asp:TemplateField HeaderText="Id"  Visible ="false" >
                <ItemTemplate>
            <asp:Label ID="lblId" runat="server"  Text='<%#Eval("Id")%>'/>
                </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="FinYearId"  Visible ="false" >
                <ItemTemplate>
            <asp:Label ID="lblFinYearId" runat="server"  Text='<%#Eval("FinYearId")%>'/>
                </ItemTemplate>
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

            </td>
             </tr>
              </table>
            </td>
        </tr>
        
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

