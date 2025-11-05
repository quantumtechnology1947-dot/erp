<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_schedule_Output_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
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
 
 <tr><td align="left" valign="middle" colspan="2"
         style="background:url(../../../images/hdbg.JPG)" height="21" 
         class="fontcsswhite"><b>&nbsp;Job-Sheduling Output-Edit</b></td></tr>
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
                    Width="100%" PageSize="15"  DataKeyNames="outputId"
                 onpageindexchanging="GridView1_PageIndexChanging" 
                 onrowcancelingedit="GridView1_RowCancelingEdit" 
                 onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                 onrowdatabound="GridView1_RowDataBound" 
                 onrowcommand="GridView1_RowCommand" ><FooterStyle Wrap="True"></FooterStyle>
                    <Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="linkRelease" CommandName="Release" Text="Release" runat="server"></asp:LinkButton>
                                     <asp:LinkButton ID="linkUnRelease" CommandName="Unrelease" Visible="false" Text="Unrelease" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="A" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    <asp:LinkButton ID="linkRelease" CommandName="Release" Visible="false" Text="Release" runat="server"></asp:LinkButton>
                                     <asp:LinkButton ID="linkUnRelease" CommandName="Unrelease" Visible="false" Text="Unrelease" runat="server"></asp:LinkButton>
                            </EditItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                                     
              <asp:TemplateField HeaderText="Machine Name"><ItemTemplate>
                  <asp:Label ID="lblMachine" runat="server" Text='<%#Eval("MachineName") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="MId" SortExpression="MId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblMID" runat="server" Text='<%#Eval("MId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="OutPutId" SortExpression="outputId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lbloutputId" runat="server" Text='<%#Eval("outputId") %>'></asp:Label>
                            </ItemTemplate>                            
                            
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
            <asp:TemplateField HeaderText="Process"><ItemTemplate> <asp:Label ID="lblprocess" runat="server" Text='<%#Eval("Process") %>'></asp:Label></ItemTemplate><ItemStyle 
                Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type"><ItemTemplate>
             <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="3%" HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField  HeaderText="Shift">  
                                  <ItemTemplate>
                                  <asp:Label ID="lblShift" runat="server" Text='<%#Eval("Shift") %>'></asp:Label>
                                  </ItemTemplate>  
                                  <ItemStyle  HorizontalAlign="center"
                Width="3%" />                                
                                  </asp:TemplateField>
              <asp:TemplateField HeaderText="Batch No">
              <ItemTemplate>
                   <asp:Label ID="lblBatchNo" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>                  
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="3%"  />             
              
              </asp:TemplateField><asp:TemplateField HeaderText="Batch Qty"><ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>               
              </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="4%" /></asp:TemplateField>
                            
                            
                            
                            <asp:TemplateField HeaderText="From Date"><ItemTemplate><asp:Label ID="lblFrDate" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label> 
        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="4%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date"><ItemTemplate><asp:Label ID="lblToDate" runat="server" Text='<%#Eval("ToDate") %>'></asp:Label> 
        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="4%"  /></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText=" From Time">
                            
                            <ItemTemplate>
                            <asp:Label ID="lblFromTime" runat="server" Text='<%#Eval("FromTime") %>'></asp:Label> 
                            </ItemTemplate>
                            <ItemStyle Width="4%"  HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText=" To Time">
                        <ItemTemplate>
                        <asp:Label ID="lblToTime" runat="server" Text='<%#Eval("ToTime") %>'></asp:Label>
                         </ItemTemplate>
                            <ItemStyle Width="4%" HorizontalAlign="Center" />
                        </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Operator" >
                            <ItemTemplate><asp:Label ID="lblOperator" runat="server" Text='<%#Eval("Operator") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="8%" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="O/p Qty"><ItemTemplate>
                                <asp:Label ID="lblOutPutQty" runat="server" Text='<%#Eval("OutPutQty") %>'></asp:Label>                            
                            </ItemTemplate>                            
                            <EditItemTemplate>
                            <asp:TextBox ID="TxtoutputQty" runat="server" Width="70%" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqOutPutQty"  ControlToValidate="TxtoutputQty" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegQty" runat="server" ValidationExpression="^[0-9]\d*(\.\d+)?$" ControlToValidate="TxtoutputQty" ValidationGroup="A" ErrorMessage="*"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center"   Width="4%" /></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="UOM" >
                        <ItemTemplate>
                            <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>                     
                                 </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />                            
                            <EditItemTemplate>                           
                            <asp:DropDownList ID="DrpUnit" Width="90%"  runat="server">
                            </asp:DropDownList> 
                            <asp:RequiredFieldValidator ID="requom" Visible="true" ControlToValidate="DrpUnit" InitialValue="Select" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator>
                                                        
                            </EditItemTemplate>
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

