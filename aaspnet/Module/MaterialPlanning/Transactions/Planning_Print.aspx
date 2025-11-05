<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialPlanning_Transactions_Planning_Print, newerp_deploy" title="ERP" theme="Default" %>

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
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >&nbsp;<strong>BOM Material Planning - Print</strong></td>
                    </tr>   
              </table>
                
                <table width="100%" align="center" cellpadding="0" cellspacing="0" class="box3">
                    <tr>
        <td align="justify" height="25" >
        
          
            <asp:DropDownList ID="DrpField" runat="server" 
                 AutoPostBack="True" 
                CssClass="box3" onselectedindexchanged="DrpField_SelectedIndexChanged">
              <%--  <asp:ListItem Value="0">Select</asp:ListItem>--%>
                <asp:ListItem Value="0">WONo</asp:ListItem>
               <asp:ListItem Value="1">PL No</asp:ListItem>
             
            </asp:DropDownList>
         
            <asp:TextBox ID="Txtsearch" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
           
        
              &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
            
        
        
              </td>
        </tr>

             <tr>
            <td width="100%" align="left">                     
  
                     <asp:GridView ID="GridView1"  runat="server" 
                    AllowPaging="True"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="PLNo" RowStyle-HorizontalAlign ="Center"
     
                     Width="100%" 
                    ShowFooter="false" onpageindexchanged="GridView1_PageIndexChanged" 
                         onrowcommand="GridView1_RowCommand" 
                         onpageindexchanging="GridView1_PageIndexChanging" PageSize="15" >
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
              <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">                           <ItemTemplate>
              <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
              </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField >
                         <ItemTemplate>
                     <asp:LinkButton  runat="server"   CommandName="Sel" Text="Select" ID="btnSel"  />
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                                    
              <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="FinYearId" Visible="false">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYearId" runat="server" Text='<%#Eval("FinYearId") %>'></asp:Label>
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PL No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPLNo" runat="server" Text='<%# Eval("PLNo") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>            
                        
                           <asp:TemplateField HeaderText="Plan Date"  >
                                    <ItemTemplate>
                                    <asp:Label ID="lblplnDate"   runat="server" Text='<%# Eval("PlanDate") %>'></asp:Label>         
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />                              
                                    
                                    </asp:TemplateField> 
                                      
                        <asp:TemplateField HeaderText="WO No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>   
                                    
                                    <asp:TemplateField HeaderText="Project Tittle">
                                    <ItemTemplate>
                                    <asp:Label ID="lblProjectTitle" runat="server" Text='<%# Eval("ProjectTitle") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="20%" HorizontalAlign="left" />
                                    </asp:TemplateField>            
                        
                        
                        
                       
                       <asp:TemplateField HeaderText="Gen.By">
                                    <ItemTemplate>
                                    <asp:Label ID="lblgenBy" runat="server" Text='<%# Eval("GenBy") %>'></asp:Label> 
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                                  
                                    
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

