<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialPlanning_Transactions_Planning_Delete_Plan, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            font-size: 14px;
            font-weight: bold;
        }
    </style>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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

 <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr >                   
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >&nbsp;<strong> Material Planning - Delete&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style2">WONo : </span>
            <asp:Label ID="lblWono" runat="server" style="font-size: 14px"></asp:Label>
                            </strong></td>
                    </tr>   
              </table>
              
              </td>
              
             </tr>
             
             <tr>
                <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" class="box3">
                    <tr>
        <td align="justify" height="25" >
        
          
            &nbsp;<span class="style2"> </span>
&nbsp;&nbsp; <b style="font-size: small">PL No:</b>
        
          
            
         
            <asp:TextBox ID="Txtsearch" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
           
        
              &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
            
        
        
              &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                onclick="btnCancel_Click" Text="Cancel" />
            
        
        
              </td>
        </tr>

             <tr>
            <td width="48%" align="left" valign="top">                     
  
                     <asp:GridView ID="GridView1"  runat="server" 
                    AllowPaging="True"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="Id" RowStyle-HorizontalAlign ="Center"
     
                     Width="96%" 
                    ShowFooter="false" onpageindexchanged="GridView1_PageIndexChanged" 
                         onrowcommand="GridView1_RowCommand" 
                         onpageindexchanging="GridView1_PageIndexChanging" PageSize="20" >
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
              <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" Width="5%" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">                           <ItemTemplate>
              <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
              </ItemTemplate>
              
                                    </asp:TemplateField>                                       
                                    
              <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="FinYearId" Visible="false">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYearId" runat="server" Text='<%#Eval("FinYearId") %>'></asp:Label>
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PL No">
                                    <ItemTemplate>
                                 <%-- <asp:Label ID="lblPLNo" Visible="false"  runat="server" Text='<%# Eval("PLNo") %>'></asp:Label>--%>
                                    <asp:LinkButton  runat="server"    CommandName="Sel" Text='<%# Eval("PLNo") %>' ID="btnSel"  />
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>            
                        
                           <asp:TemplateField HeaderText="Plan Date"  >
                                    <ItemTemplate>
                                    <asp:Label ID="lblplnDate"   runat="server" Text='<%# Eval("PlanDate") %>'></asp:Label>         
                                                </ItemTemplate>
                                                 <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />                              
                                    
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
                    
                    <td width="52%" valign="top">
                    
                   <%-- <asp:Label ID="lblPLNo" Visible="false"  runat="server" Text='<%# Eval("PLNo") %>'></asp:Label>--%>
<asp:Panel ID="Up" runat="server">
                       
                     <asp:GridView ID="GridView2"  runat="server" 
                    AllowPaging="True"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="Id" RowStyle-HorizontalAlign ="Center"     
                     Width="100%" 
                    ShowFooter="false" onpageindexchanged="GridView2_PageIndexChanged" 
                         onrowcommand="GridView2_RowCommand" 
                         onpageindexchanging="GridView2_PageIndexChanging" PageSize="20" >
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
              <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" Width="5%" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">                           <ItemTemplate>
              <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
              </ItemTemplate>
              
                                    </asp:TemplateField> 
                                    
                                    <asp:TemplateField HeaderText=" "  >
                                   <ItemTemplate>
                                   <asp:LinkButton ID="btndelete" Text="Delete" OnClientClick="return confirmationDelete();" CommandName="Del" runat="server"></asp:LinkButton>
             
              </ItemTemplate>
               <ItemStyle HorizontalAlign="center" Width="4%" VerticalAlign="Top" />
                                    </asp:TemplateField>                                       
                                    
              <asp:TemplateField HeaderText="Item Code">
                         <ItemTemplate>
                        <asp:Label ID="lblitemcode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>                       
                        
                        
                        <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                 <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                    
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="20%" HorizontalAlign="left" />
                                    </asp:TemplateField>            
                        
                           <asp:TemplateField HeaderText="UOM"  >
                                    <ItemTemplate>
                                    <asp:Label ID="lbluom"   runat="server" Text='<%# Eval("Symbol") %>'></asp:Label>         
                                                </ItemTemplate>
                                                 <ItemStyle Width="8%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />                              
                                    
                                    </asp:TemplateField>                        
                       
                       <asp:TemplateField HeaderText="BOM Qty">
                                    <ItemTemplate>
                                    <asp:Label ID="lblbomQty" runat="server" Text='<%# Eval("BOMQty") %>'></asp:Label> 
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="right" />
                                  
                                    
                                    </asp:TemplateField>    
                                    
                                    <asp:TemplateField HeaderText="Plan Type">
                                    <ItemTemplate>
                                    <asp:Label ID="lblplantype" runat="server" Text='<%# Eval("TypeOfPlan") %>'></asp:Label> 
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                  
                                    
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Item Code After Plan">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItemAfter" runat="server" Text='<%# Eval("ItemCode1") %>'></asp:Label> 
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                  
                                    
                                    </asp:TemplateField>    
                                    
                                    <asp:TemplateField HeaderText="MId" SortExpression="MId" Visible="False">                           <ItemTemplate>
              <asp:Label ID="lblMId" runat="server" Text='<%#Eval("MId") %>'> </asp:Label>
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
                    <%--</fieldset>
                    
                    </ContentTemplate>
                    
                    </asp:UpdatePanel>--%>
                     </asp:Panel>
                    
                    </td>
             </tr>
              </table>
            </td>
        </tr>
        
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

