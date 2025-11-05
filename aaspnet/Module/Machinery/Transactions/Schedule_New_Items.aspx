<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_Schedule_New_Items, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
            height: 21px;
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

 <table align="left" cellpadding="0" cellspacing="0"  style="height:auto" width="100%" >
 <tr><td align="left" valign="middle" 
         style="background:url(../../../images/hdbg.JPG)" 
         class="style2" colspan="2"><b>&nbsp;Job-Sheduling Input-New</b></td></tr>
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
                    Width="100%" PageSize="8" onrowcommand="GridView1_RowCommand" ><FooterStyle Wrap="True"></FooterStyle>
                    <Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField>
              <asp:TemplateField HeaderText="Machine Name"><ItemTemplate><asp:DropDownList ID="DrpMachine" Width="93%" AutoPostBack="true"  runat="server" 
        onselectedindexchanged="DrpMachine_SelectedIndexChanged"></asp:DropDownList>
         <asp:RequiredFieldValidator ID="reqMachineName" ControlToValidate="DrpMachine" runat="server" ErrorMessage="*" ValidationGroup="A"  InitialValue="Select"> </asp:RequiredFieldValidator>
          
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="Process"><ItemTemplate><asp:DropDownList ID="DrpProcess" Width="95%" runat="server"></asp:DropDownList></ItemTemplate><ItemStyle 
                Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type"><ItemTemplate><asp:DropDownList ID="DrpType" Width="90%" runat="server"><asp:ListItem Value="Select"> Select </asp:ListItem><asp:ListItem Value="0"> Fresh </asp:ListItem><asp:ListItem Value="1"> Rework </asp:ListItem></asp:DropDownList>            
            <asp:RequiredFieldValidator ID="reqType" ControlToValidate="DrpType" runat="server" ErrorMessage="*" ValidationGroup="A"  InitialValue="Select"/>
            </ItemTemplate><ItemStyle 
                Width="5%" />
            </asp:TemplateField>
              <asp:TemplateField  HeaderText="Shift">  
                                  <ItemTemplate>
                                  <asp:DropDownList ID="DrpShift"  runat="server" >
                     <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">Day</asp:ListItem>
                     <asp:ListItem Value="1">Night</asp:ListItem>
                                  
                                  </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="reqShift" ControlToValidate="DrpShift" runat="server" ErrorMessage="*" ValidationGroup="A"  InitialValue="Select"/>
                                  </ItemTemplate>  
                                  <ItemStyle  HorizontalAlign="Left"
                Width="3%" />                                
                                  </asp:TemplateField>
              <asp:TemplateField HeaderText="Batch No">
              <ItemTemplate>
                  <asp:DropDownList ID="DrpBatchNO" runat="server">
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="reqBatchNO" ControlToValidate="DrpBatchNO" InitialValue="Select" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator>
                  
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="3%"  />
              
              
              </asp:TemplateField><asp:TemplateField HeaderText="Batch Qty"><ItemTemplate><asp:TextBox ID="TxtBatchQty" runat="server" Width="80%" ></asp:TextBox>
              <asp:RequiredFieldValidator ID="reqBatchQty" ControlToValidate="TxtBatchQty" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator>
              
              </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="4%" /></asp:TemplateField>                         
                           
                            
                            
                            <asp:TemplateField HeaderText="From Date"><ItemTemplate><asp:TextBox ID="TxtFdate" runat="server" Width="80%" ></asp:TextBox><cc1:CalendarExtender ID="TxtFdate_CalendarExtender" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFdate" PopupPosition="BottomLeft"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegularExpressionValidatorFDate" runat="server" ControlToValidate="TxtFdate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="reqFDate" ControlToValidate="TxtFdate" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator>
        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="6%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date"><ItemTemplate><asp:TextBox ID="TxtTdate" runat="server" Width="80%" ></asp:TextBox><cc1:CalendarExtender ID="TxtTdate_CalendarExtender" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtTdate" PopupPosition="BottomRight"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegularExpressionValidatorTDate" runat="server" ControlToValidate="TxtTdate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="reqTDate" ControlToValidate="TxtTdate" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator>
        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="6%"  /></asp:TemplateField>
                            <asp:TemplateField HeaderText=" From Time">
                            <ItemTemplate><MKB:TimeSelector ID="Fdate" runat="server" AmPm="AM" MinuteIncrement="1"></MKB:TimeSelector>
                            
                               </ItemTemplate>
                            <ItemStyle Width="7%"  HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" To Time">
                        <ItemTemplate><MKB:TimeSelector ID="Tdate" runat="server" AmPm="AM" MinuteIncrement="1"></MKB:TimeSelector>
                        
                        </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Incharge" ><ItemTemplate><asp:TextBox ID="TxtIncharge" runat="server" Width="90%" CssClass="box3"  > </asp:TextBox>
                        
                        <cc1:AutoCompleteExtender ID="TxtIncharge_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtIncharge" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                 <asp:RequiredFieldValidator ID="reqIncharge" ControlToValidate="TxtIncharge" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="9%" /></asp:TemplateField><asp:TemplateField HeaderText="Operator" ><ItemTemplate><asp:TextBox ID="TxtOperator" runat="server"  Width="90%" CssClass="box3" > </asp:TextBox><cc1:AutoCompleteExtender ID="TxtOperator_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtOperator" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                 <asp:RequiredFieldValidator ID="reqoperator" ControlToValidate="TxtOperator" runat="server" ErrorMessage="*" ValidationGroup="A" > </asp:RequiredFieldValidator></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="9%" /></asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkBtnAdd" Text="Add" ValidationGroup="A"  OnClientClick="return confirmationAdd()" CommandName="Add" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="2%" />
                        </asp:TemplateField>
                 </Columns>
                 
                 
                 <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>
                 
                 
                 </td></tr> 
                 <tr>
                 <td colspan="2"> &nbsp;</td>
                 </tr>
                                             
                            <tr>
                            <td colspan="2">
                             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme"  AllowPaging="True" 
                    Width="100%" onrowcommand="GridView2_RowCommand" 
                                    onpageindexchanging="GridView2_PageIndexChanging" ><FooterStyle Wrap="True"></FooterStyle>
                    <Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField>
              <asp:TemplateField HeaderText="Machine Name">
              <ItemTemplate> 
                  <asp:Label ID="lblMachinName" runat="server" Text='<%#Eval("MachineName") %>'></asp:Label> 
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Process">
            <ItemTemplate>
                <asp:Label ID="lblProcess" runat="server" Text='<%#Eval("Process") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="5%" HorizontalAlign="Center" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Type">
            <ItemTemplate>
             <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
            </ItemTemplate>
            
            <ItemStyle 
                Width="3%" HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField  HeaderText="Shift">  
                                  <ItemTemplate>
                                   <asp:Label ID="lblShift" runat="server" Text='<%#Eval("Shift") %>'></asp:Label>
                                  </ItemTemplate>  
                                  <ItemStyle  HorizontalAlign="Center"
                Width="3%" />                                
                                  </asp:TemplateField>
              <asp:TemplateField HeaderText="Batch No">
              <ItemTemplate>
               <asp:Label ID="lblBatchNo" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="3%"  />  
              </asp:TemplateField>
              
              <asp:TemplateField HeaderText="Batch Qty">
              
              <ItemTemplate>
             <asp:Label ID="lblFinishQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center"  Width="4%" />
              </asp:TemplateField>
              
             <asp:TemplateField HeaderText="From Date">
             <ItemTemplate>
              <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label>
             </ItemTemplate>
             <ItemStyle HorizontalAlign="Center"  Width="4%"  />
             </asp:TemplateField>             
             
             <asp:TemplateField HeaderText="To Date">
             <ItemTemplate>
              <asp:Label ID="lblTodate" runat="server" Text='<%#Eval("TODate") %>'></asp:Label>
             </ItemTemplate>
        <ItemStyle HorizontalAlign="Center"  Width="4%"  />
        </asp:TemplateField>
        <asp:TemplateField HeaderText=" From Time">
        <ItemTemplate>
         <asp:Label ID="lblFromTime" runat="server" Text='<%#Eval("FromTime") %>'></asp:Label>
        </ItemTemplate>
       <ItemStyle Width="4%" HorizontalAlign="Center" />
       </asp:TemplateField>
       
       <asp:TemplateField HeaderText=" To Time">
       <ItemTemplate>
        <asp:Label ID="lblToTime" runat="server" Text='<%#Eval("ToTime") %>'></asp:Label>
       </ItemTemplate>
      <ItemStyle Width="4%" HorizontalAlign="Center" />
     </asp:TemplateField>
     <asp:TemplateField HeaderText="Incharge" >
     <ItemTemplate>
      <asp:Label ID="lblIncharge" runat="server" Text='<%#Eval("Incharge") %>'></asp:Label>
     </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="8%" />
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Operator" >
    <ItemTemplate>
     <asp:Label ID="lblOperator" runat="server" Text='<%#Eval("Operator") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="8%" />
    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
    <asp:LinkButton ID="LinkBtnAdd" Text="Delete"  OnClientClick="return confirmationAdd()" CommandName="Del" runat="server"></asp:LinkButton>
</ItemTemplate>
<ItemStyle HorizontalAlign="center" Width="2%" />
</asp:TemplateField>
<asp:TemplateField HeaderText=""  Visible="false" >
    <ItemTemplate>
     <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="9%" />
    </asp:TemplateField>

                 </Columns>              
                 
                 <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>
                            </td>                            
                            </tr>
                            
                            <tr>
                            <td height="25" valign="middle" align="center" colspan="2">
                                <asp:Button ID="btnSubmit" runat="server"  CssClass="redbox" Text="Submit" 
                                    onclick="btnSubmit_Click" OnClientClick="return confirmationAdd()" />
                            &nbsp;&nbsp;
                                <asp:Button ID="Btncancel" runat="server" CssClass="redbox" 
                                    onclick="Btncancel_Click" Text="Cancel" />
                            </td>
                            
                            
                            </tr>
                            </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

