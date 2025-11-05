<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"   AutoEventWireup="true" CodeFile="pdt.aspx.cs" Inherits="Module_MaterialPlanning_Transactions_pdt" Title="ERP"    Theme="Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            height: 19px;
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

                 <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            colspan="2" ><strong>&nbsp;In-House Report New
                          </strong>&nbsp;&nbsp;&nbsp;<strong>WONo:</strong><asp:Label ID="lblWono" runat="server" Text=""></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp; <strong>Report No.</strong>
                       <asp:Label runat="server" ID="lblreport"></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;<strong>Report Date:</strong>
                       <asp:Label runat="server" ID="lblreportdate"></asp:Label>
                       
                        </td>
                    </tr>
                    
                    <tr>
                    <td rowspan="7" valign="top" width="65%">
                    
                        
                      <%-- <asp:Panel ID="pnlTree" Height="442px" HorizontalAlign="Center"  Width="98%"  ScrollBars="Auto" runat="server">    
                       --%>
                      <%-- <blockquote style="TEXT-ALIGN: center" >--%>
   <div id="grdWithScroll" style="OVERFLOW: auto; WIDTH:auto; HEIGHT: 440px" onscroll="SetDivPosition()">

                          <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="false" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="" RowStyle-HorizontalAlign ="Center"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    PageSize="20" OnRowCommand="SearchGridView1_RowCommand" 
                                >
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                  
                  
                  <asp:TemplateField  HeaderText="Select Items">
                  
                    <ItemTemplate>
                        <asp:CheckBox ID="chkitems"  runat="server"
        AutoPostBack="true" OnCheckedChanged="Selected_chk_Changed"  />
                    </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="Item Code">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblitemcode" Text='<%#Eval("ItemCode") %>'>'></asp:Label>
                    </ItemTemplate>
                  
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code"  Visible="false">
                <ItemTemplate>
                <asp:LinkButton ID="btnCode"   CommandName="Show"  Text='<%#Eval("ItemCode") %>'   
                        runat="server"></asp:LinkButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                </asp:TemplateField>            
                                  
                      
                    <asp:TemplateField HeaderText="Description" >
                <ItemTemplate>
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>         
                       
                      <asp:TemplateField HeaderText="UOM" >
                <ItemTemplate>
             <asp:Label ID="lbluombasic" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>               
                        
                        
                   <asp:TemplateField HeaderText="BOM Qty" >
                <ItemTemplate>
                <asp:Label ID="lblbomqty" runat="server" Text='<%#Eval("BOMQty") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>       
                        
                    <asp:TemplateField  HeaderText="Design" >
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtdesign" Visible="False"></asp:TextBox>
                       
                        <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender1" runat="server" 
                    Enabled="True" TargetControlID="txtdesign" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                       
                       
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                     <asp:TemplateField  HeaderText="Manufacturing" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtmanf" Visible="False"></asp:TextBox>
                         <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender2" runat="server" 
                    Enabled="True" TargetControlID="txtmanf" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                        
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    
                     <asp:TemplateField  HeaderText="BOP Date" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtbop" Visible="False"></asp:TextBox>
                        
                         <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtbop" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                        
                        
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                         <asp:TemplateField  HeaderText="Assemly" Visible="false" >
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtassemly" Visible="False">
                            </asp:TextBox>
                            
                           <asp:DropDownList runat="server" ID="drpassemly" Visible="False" >
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="10%" Value="1"></asp:ListItem>
                            <asp:ListItem Text="20%" Value="2"></asp:ListItem>
                            <asp:ListItem Text="30%" Value="3"></asp:ListItem>
                            <asp:ListItem Text="40%" Value="4"></asp:ListItem>
                            <asp:ListItem Text="50%" Value="5"></asp:ListItem>
                            <asp:ListItem Text="60%" Value="6"></asp:ListItem>
                            <asp:ListItem Text="70%" Value="7"></asp:ListItem>
                            <asp:ListItem Text="80%" Value="8"></asp:ListItem>
                            <asp:ListItem Text="90%" Value="9"></asp:ListItem>
                            <asp:ListItem Text="100%" Value="10"></asp:ListItem>
                            
                           </asp:DropDownList>
                            
                        </ItemTemplate>
                    </asp:TemplateField> 
                         
                         
                         <asp:TemplateField HeaderText="Hrs" Visible="false">
                            <ItemTemplate>
                               <asp:TextBox runat="server" ID="txthrs" Visible="false"></asp:TextBox>
                            </ItemTemplate>
                         
                         </asp:TemplateField>
                            
            </Columns>
               <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon">
                         </asp:Label></td></tr></table>
                    </EmptyDataTemplate>
                    
                    
            
        </asp:GridView>
        <br />
        <br />
        
                     
           </div>   
  <%-- </blockquote>--%>
            
            
      <%--  </asp:Panel> --%>
                        
                        
                       
                    
                    </td>
                   
</tr>
<tr>
    <td>
    
     <asp:Button ID="Button1" runat="server" Text="Add" CssClass ="redbox" 
                     onclick="Button1_Click"/> &nbsp;&nbsp;&nbsp;
                     <br />
    </td>
</tr>

       <tr>
        <td>
               <asp:Button ID="Button2" runat="server" Text="Submit" CssClass ="redbox" 
                     onclick="Button_Submit_Click"/>  &nbsp;&nbsp;&nbsp;
                     <asp:Button ID="Button3" runat="server" Text="Cancel" CssClass ="redbox" 
                     onclick="Button_Cancel_Click"/> 
        </td>
       </tr>     
 </table>
 
 
 
<%--</ContentTemplate>
</asp:UpdatePanel>
</div>--%>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

