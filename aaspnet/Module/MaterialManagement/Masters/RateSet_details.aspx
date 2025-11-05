<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Masters_RateSet_details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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

 <script language="javascript" type="text/javascript">
function SelectSingleRadiobutton(rdbtnid) {
var rdBtn = document.getElementById(rdbtnid);
var rdBtnList = document.getElementsByTagName("input");
for (i = 0; i < rdBtnList.length; i++) {
if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id)
{
rdBtnList[i].checked = false;
}
}
}
</script>


<table cellpadding="0" cellspacing="0" width="100%">
<tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>&nbsp;Rate Register </b></td>
             </tr>

<tr> <td valign="middle" style="height:28px">

         <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Supllier Name"></asp:Label> 
          <asp:TextBox runat="server" CssClass="box3" Width="336px" 
                ID="txtSearchSupplier" ></asp:TextBox>
         <cc1:AutoCompleteExtender runat="server"  MinimumPrefixLength="1"  CompletionInterval="100" 
         CompletionSetCount="1" ServiceMethod="sql" ServicePath="" UseContextKey="True" DelimiterCharacters="" 
         FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True" Enabled="True" 
         TargetControlID="txtSearchSupplier" ID="txtSearchSupplier_AutoCompleteExtender" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
         </cc1:AutoCompleteExtender>
         &#160;
         <asp:Button runat="server" Text="View" CssClass="redbox" ID="btnSearch" OnClick="btnSearch_Click">
         </asp:Button>
         
          &nbsp;&nbsp;&nbsp;
         
          <asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="Btncancel" OnClick="Btncancel_Click">
         </asp:Button>
         &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
         </td></tr>
         <tr>
         <td>
                  <asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                         Width="100%" 
                    PageSize="20" >
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                      
                    
                                
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle 
                            HorizontalAlign="Right" Width="3%"></ItemStyle>
                            </asp:TemplateField>                           
                         <asp:BoundField DataField="FinYear" HeaderText="FinYear">
                           
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            
                              <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ItemId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="ItemCode" HeaderText="Item Code">
                           
                                <ItemStyle  HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           
                           
                           
                            <asp:BoundField DataField="ManfDesc" HeaderText="Desc" >
                           
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           <asp:BoundField DataField="UOMBasic" HeaderText="UOM">
                           
                                <ItemStyle Width="6%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           
                         
                            
                            <asp:BoundField DataField="PONo" HeaderText="PONo ">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" >
                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            
                               <asp:TemplateField HeaderText="set Min">
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButton1" GroupName="radbtn" runat="server"   OnClick="javascript:SelectSingleRadiobutton(this.id)"  OnCheckedChanged="RadioButton1_CheckedChanged" />
                                </ItemTemplate>
                                <ItemStyle 
                            HorizontalAlign="center" Width="5%"></ItemStyle>
                            </asp:TemplateField>    
                           
                            <asp:BoundField DataField="Rate" HeaderText="Rate">
                           
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="Discount" HeaderText="Disc" 
                               >
                           
                                <ItemStyle Width="3%" HorizontalAlign="Right" />
                            </asp:BoundField>  
                                                     
                             <asp:BoundField DataField="Amount" HeaderText="Amount">
                           
                                <ItemStyle Width="8%" HorizontalAlign="Right" />
                            </asp:BoundField>
                                                    
                            <asp:BoundField DataField="Excise" HeaderText="Excise">                            
                                <ItemStyle Width="7%" HorizontalAlign="Center"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IndirectCost" HeaderText="IndirectCost"  Visible="false" >                           
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>                           
                          
                            <asp:BoundField DataField="DirectCost" HeaderText="DirectCost"  Visible="false">                           
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>   
                           
                            <asp:BoundField DataField="VAT" HeaderText="VAT" >                            
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                             <asp:BoundField DataField="PF" HeaderText="PF" >                            
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            
                             <asp:TemplateField HeaderText="Flag" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblFlag" runat="server" Text='<%#Eval("Flag") %>'> </asp:Label>
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
         <tr>
         <td align="center" width="30 px">
         <asp:Button runat="server" Text="Submit" CssClass="redbox" ID="BtnSubmit" 
                 onclick="BtnSubmit_Click" >
         </asp:Button>
         </td>
         </tr>
         </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

