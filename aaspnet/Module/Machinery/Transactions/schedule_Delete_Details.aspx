<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_schedule_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
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
<table align="left" cellpadding="0" cellspacing="0"  style="height:auto" width="100%" >
 <tr><td align="left" colspan="2" valign="middle" 
         style="background:url(../../../images/hdbg.JPG)" height="21" 
         class="fontcsswhite"><b>&nbsp;Job-Sheduling Input- Delete</b></td></tr>
 <tr>
 <td height="25" valign="middle" width="50%"> 
     &nbsp; 
     Item Code : <asp:Label ID="lblItemCode" runat="server" style="font-weight: 700"></asp:Label> 
     </td>
 
 <td height="25" valign="middle">
 
     &nbsp;UOM : <asp:Label ID="lblunit" runat="server" style="font-weight: 700"></asp:Label>
 
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BOM Qty : <asp:Label ID="lblBomqty" runat="server" style="font-weight: 700"></asp:Label>
 
     </td>
 
 </tr>
 
 <tr>
 <td height="25" valign="middle" width="50%">
 
     &nbsp; Description :&nbsp;<asp:Label ID="lblDesc" runat="server" style="font-weight: 700"></asp:Label>
 
     </td>
 
 <td height="25" valign="middle">
 
     &nbsp;WoNo : <asp:Label ID="lblWoNo" runat="server" style="font-weight: 700"></asp:Label>
 
     </td>
 
 </tr>
 
 <tr>
         <td align="left" colspan="2">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme"  AllowPaging="True" 
                    Width="100%" PageSize="15"  DataKeyNames="Id"
                 onpageindexchanging="GridView1_PageIndexChanging" 
                 onrowcommand="GridView1_RowCommand" >
                 <FooterStyle Wrap="True"></FooterStyle>
                    <Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField>
                        <asp:TemplateField HeaderText="">              
              <ItemTemplate>
                  <asp:LinkButton ID="LinkButton1" CommandName="Del" Text="Delete" OnClientClick="return confirmationDelete()" runat="server"></asp:LinkButton> 
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="3%" />
            </asp:TemplateField>
                        <%-- <asp:CommandField ButtonType="Link"  s ShowEditButton="True"  ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center" ValidationGroup="A"/>--%>
              <asp:TemplateField HeaderText="Machine Name">
              
              <ItemTemplate>
                  <asp:Label ID="lblMachine" runat="server" Text='<%#Eval("MachineName")%>'></asp:Label>         
            </ItemTemplate>             
            <ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="Process">
            
            <ItemTemplate>
            <asp:Label ID="lblProcess" runat="server" Text='<%#Eval("Process")%>'></asp:Label>     
            </ItemTemplate>
            <ItemStyle Width="6%" HorizontalAlign="Center" />  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
            <ItemTemplate>
            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type")%>'></asp:Label>     
            </ItemTemplate>
            <ItemStyle Width="5%" HorizontalAlign="Center" /> 
            </asp:TemplateField>
              <asp:TemplateField  HeaderText="Shift">  
                                  <ItemTemplate>
                                      <asp:Label ID="lblShift" runat="server" Text='<%#Eval("Shift")%>'></asp:Label>
                                  </ItemTemplate>  
            <ItemStyle  HorizontalAlign="Center" Width="4%" />              
                                       
                                  </asp:TemplateField>
             
              <asp:TemplateField HeaderText="Batch No">
              <ItemTemplate>
            <asp:Label ID="lblBatchNo" runat="server" Text='<%#Eval("BatchNo")%>'></asp:Label>                  
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="4%"  />
              
              
              </asp:TemplateField>
              
              <asp:TemplateField HeaderText="Batch Qty">
              <ItemTemplate> 
               <asp:Label ID="lblBatchQty" runat="server" Text='<%#Eval("Qty")%>'></asp:Label>   
              </ItemTemplate>                            
               <ItemStyle HorizontalAlign="Center"  Width="4%" />
                             
               </asp:TemplateField> 
                <asp:TemplateField HeaderText="From Date">
                
                <ItemTemplate>               
                 <asp:Label ID="lblfromDate" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label>   
                 </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="6%"  />                            
                           
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                            <ItemTemplate>
                            <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="6%"  />                            
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText=" From Time">                            
                            <ItemTemplate>
                             <asp:Label ID="lblFromTime" runat="server" Text='<%#Eval("FromTime")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="7%"  HorizontalAlign="Center"/>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" To Time">
                        <ItemTemplate>
                          <asp:Label ID="lblToTime" runat="server" Text='<%#Eval("ToTime")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Center" />                            
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Incharge" >
                        <ItemTemplate>
                         <asp:Label ID="lblIncharge" runat="server" Text='<%#Eval("Incharge")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="9%" />                          
                            
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Operator" >
                            <ItemTemplate>
                             <asp:Label ID="lblOperator" runat="server" Text='<%#Eval("Operator")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="9%" />                            
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Id" Visible="false">
              <ItemTemplate> 
               <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id")%>'></asp:Label>   
              </ItemTemplate>                            
               <ItemStyle HorizontalAlign="Center"  Width="4%" />                          
               </asp:TemplateField> 
                       
                 </Columns>
                 
                 
                 <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>
                 
                 
                 </td></tr> 
                 <tr>
                 <td colspan="2"> &nbsp;</td>
                 </tr>
                                             
                            <tr>
                            <td height="25" valign="middle" align="center" colspan="2">
                            &nbsp;&nbsp;
                                <asp:Button ID="Btncancel" runat="server" CssClass="redbox" 
                                    onclick="Btncancel_Click" Text="Cancel" />
                            </td>
                            
                            
                            </tr>
                            </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

