<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsQualityNote_GQN_New_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style8
        {  
        	text-align: left;
        }
        .style10
        {
            text-align: center;
            height: 31px;
        }
        .style12
        {
            width: 71px;
            height: 23px;
        }
        .style13
        {
            width: 31px;
            height: 23px;
        }
        .style15
        {
            width: 141px;
            height: 23px;
        }
        .style16
        {
            height: 23px;
        }
        .style17
        {
            text-align: left;
            height: 22px;
        }
        .style18
        {
            width: 61px;
            height: 23px;
        }
        .style19
        {
            width: 109px;
            height: 23px;
        }
        .style20
        {
            width: 66px;
            height: 23px;
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


    <%--<script type="text/javascript">
var prm = Sys.WebForms.PageRequestManager.getInstance();
//Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
prm.add_beginRequest(BeginRequestHandler);
// Raised after an asynchronous postback is finished and control has been returned to the browser.
prm.add_endRequest(EndRequestHandler);
function BeginRequestHandler(sender, args) {
//Shows the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.show();
}
}

function EndRequestHandler(sender, args) {
//Hide the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.hide();
}
}
</script>--%>
    
<div>   
<%--    <asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
<asp:Image ID="Image1" ImageUrl="~/images/spinner-big.gif" AlternateText="Processing" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>
<cc1:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
<asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
<ContentTemplate>  --%>



    <table align="center" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Quality Note [GQN] - New</b></td>
        </tr>

        <tr>
            <td align="center" style="text-align: left">
                <table align="center" cellpadding="0" cellspacing="0" class="style2" 
                    ><tr><td class="style8" 
                            ><table cellpadding="0" cellspacing="0" 
                            class="style2" ><tr >
                                <td class="style20" >&nbsp; GRR No</td>
                                <td class="style19" >
                                    :
                                    <asp:Label ID="lblGrr" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style18" >&nbsp; GIN No</td>
                                <td  class="style15">: <asp:Label runat="server" Font-Bold="True" ID="lblGIn"></asp:Label>
</td><td class="style12" >Challan No</td><td  class="style16">: <asp:Label runat="server" Font-Bold="True" ID="lblChNo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</td><td class="style13" >Date</td><td  class="style16">:&nbsp; <asp:Label runat="server" Font-Bold="True" ID="lblDate"></asp:Label>
&nbsp;</td></tr></table></td></tr><tr ><td class="style17" >&nbsp; Supplier :&nbsp;&nbsp; &nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblSupplier"></asp:Label>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                            ProviderName="System.Data.SqlClient" 
                            SelectCommand="SELECT * FROM [tblQc_Rejection_Reason]"></asp:SqlDataSource>
</td></tr><tr ><td class="style17" ><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A : Total Received Quantity,&nbsp;&nbsp; B : Normal Accepted Quantity,&nbsp;&nbsp; C : 
                        Deviated Quantity,&nbsp;&nbsp; D : Segregated Quantity,&nbsp;&nbsp; E : Rejected Quantity.</b></td></tr><tr><td class="style10" align="left" >
                        <asp:GridView runat="server" 
                            AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" Width="100%" ID="GridView2" 
                            OnPageIndexChanging="GridView2_PageIndexChanging" 
                            OnRowCommand="GridView2_RowCommand" ShowFooter="True" PageSize="20" 
                            >
                            <PagerSettings PageButtonCount="40" />
                            <Columns>
<asp:TemplateField HeaderText="SN"><ItemTemplate>
<%#Container.DataItemIndex+1  %>
                                                    
</ItemTemplate>

<HeaderStyle Font-Size="10pt"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField Visible="false"><ItemTemplate>
 <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField>

<%--<HeaderTemplate >

    <asp:CheckBox runat="server" ID="chkall" OnCheckedChanged="Chkchanged_All" AutoPostBack="true" />
    
</HeaderTemplate>--%>

<ItemTemplate>
<asp:CheckBox ID="ck" runat="server" Checked="true" AutoPostBack="true" oncheckedchanged="ck_CheckedChanged"  />
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="ItemId" Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" ></ItemStyle>
</asp:TemplateField>


<asp:TemplateField HeaderText="Image" >
                        <ItemTemplate>
                       
                            <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Spec. Sheet" >
                        <ItemTemplate>
                         <asp:LinkButton ID="btnlnkSpec" CommandName="downloadSpec" Visible="true"  Text='<%# Bind("AttName") %>'  runat="server"></asp:LinkButton>
                         
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center"  Width="5%"/>
                        </asp:TemplateField>


<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="center" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText=" Description "><ItemTemplate>
                                                        <asp:Label ID="lblpurchDesc" runat="server" Text='<%#Eval("Description") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="14%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
                                                        <asp:Label ID="lbluompurch" runat="server" Text='<%#Eval("UOM") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="WO/Dept">
                        <ItemTemplate>
                        <asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
<asp:TemplateField HeaderText="PO Qty">
<ItemTemplate>
<asp:Label ID="lblpoqty" runat="server" Text='<%#Eval("POQty") %>' />
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inward Qty">
<ItemTemplate>
  <asp:Label ID="lblInwrdqty" runat="server" Text='<%#Eval("InvQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="A">
<ItemTemplate>
  <asp:Label ID="lblRecedqty" runat="server" Text='<%#Eval("RecedQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="ACCQty" Visible="false">
    <ItemTemplate>
        <asp:Label ID="lblaccpQty" runat="server" Visible="true" Text='<%#Eval("AcceptedQty") %>'></asp:Label>
        <asp:TextBox ID="txtaccpQty" runat="server" CssClass="box3"              
            Visible="True" AutoPostBack="true" Width="75%" />
        <%--<asp:RequiredFieldValidator ID="ReqAcQty" ValidationGroup="A" Visible="false" ControlToValidate="txtaccpQty" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Visible="false"
            ControlToValidate="txtaccpQty" ErrorMessage="*" ValidationGroup="A"
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>--%>
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="8%" />
 </asp:TemplateField>

<asp:TemplateField HeaderText="B">
    <ItemTemplate>
        <asp:Label ID="lblNormalAccQty" runat="server" Visible="true" Text='<%#Eval("NormalAccQty") %>'></asp:Label>
     <asp:TextBox  AutoPostBack="True" ID="txtNormalAccQty" runat="server" CssClass="box3"     Text='<%#Eval("RecedQty") %>'          
            Visible="True" Width="100%" />
        <asp:RequiredFieldValidator ID="ReqNormalQty" ValidationGroup="A" Visible="false" ControlToValidate="txtNormalAccQty" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegNormalQty" runat="server" Visible="false"
            ControlToValidate="txtNormalAccQty" ErrorMessage="*" ValidationGroup="A"
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="12%" />
 </asp:TemplateField>





<asp:TemplateField HeaderText="C">
    <ItemTemplate>
        <asp:Label ID="lblDeviatedQty" runat="server" Visible="true" Text='<%#Eval("DeviatedQty") %>'></asp:Label>
        <asp:TextBox ID="txtDeviatedQty" Text="0"  runat="server" CssClass="box3"              
            Visible="True" Width="75%" />
        <asp:RequiredFieldValidator ID="ReqDeviatedQty" ValidationGroup="A" Visible="false" ControlToValidate="txtDeviatedQty" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Visible="false"
            ControlToValidate="txtDeviatedQty" ErrorMessage="*" ValidationGroup="A"
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="8%" />
</asp:TemplateField>


<asp:TemplateField HeaderText="D">
    <ItemTemplate>
        <asp:Label ID="lblSegregatedQty" runat="server" Visible="true" Text='<%#Eval("SegregatedQty") %>'></asp:Label>
        <asp:TextBox ID="txtSegregatedQty" Text="0" runat="server" CssClass="box3"              
            Visible="True" Width="75%" />
        <asp:RequiredFieldValidator ID="ReqSegregatedQty" ValidationGroup="A" Visible="false" ControlToValidate="txtSegregatedQty" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Visible="false"
            ControlToValidate="txtSegregatedQty" ErrorMessage="*" ValidationGroup="A"
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="8%" />
</asp:TemplateField>


                                <asp:TemplateField HeaderText="E" SortExpression="RejectedQty">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RejectedQty") %>'></asp:Label>
                                    </ItemTemplate>                                    
                                    <ItemStyle HorizontalAlign="Right" Width="7%" />
                                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rej Reason">
                        <ItemTemplate>
                          <asp:DropDownList ID="drprejreason" runat="server" CssClass="box3" DataSourceID="SqlDataSource1" DataTextField="Symbol" DataValueField="Id" Visible="True" >
                          </asp:DropDownList>
                          <asp:Label ID="lblrejreason" runat="server" Text='<%#Eval("RejReason") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="12%"></ItemStyle>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="S/N" >
                        <ItemTemplate>
                        <asp:TextBox ID="txtSN" runat="server" CssClass="box3" Width="80%" 
            ValidationGroup="A" Visible="false"
></asp:TextBox> 
<asp:RequiredFieldValidator ID="ReqSn" ValidationGroup="A" Visible="false" ControlToValidate="txtSN" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                        <asp:Label ID="lblsn" runat="server" Text='<%#Eval("SN") %>'></asp:Label>    
                        </ItemTemplate>
                        <ItemStyle Width="8%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="P/N">
                        <ItemTemplate>
                        <asp:TextBox ID="txtPN" runat="server" CssClass="box3" Width="80%" 
            ValidationGroup="A" Visible="false"
></asp:TextBox> 
<asp:RequiredFieldValidator ID="ReqPn" ValidationGroup="A" Visible="false" ControlToValidate="txtPN" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                      
                        <asp:Label ID="lblpn" runat="server" Text='<%#Eval("PN") %>'></asp:Label>          
                        </ItemTemplate>
                         <ItemStyle Width="8%" />
                          <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" CommandName="Ins" CssClass="redbox" OnClientClick=" return confirmationAdd()" 
                            Text=" Add " ValidationGroup="A" />
                            
                        </FooterTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                         <asp:TextBox ID="txtRemarks" runat="server" CssClass="box3"  Visible="True" ></asp:TextBox><asp:Label ID="lblremarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                         
                        </ItemTemplate>
                          <ItemStyle Width="10%" />
                        <FooterTemplate>                        
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" CssClass="redbox" 
                            Text="Cancel"/>
                        </FooterTemplate>
                           
                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="AHId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblahid" runat="server" Text='<%#Eval("AHId") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                   
                   
                    <asp:TemplateField HeaderText="CatId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblCatId" runat="server" Text='<%#Eval("CatId") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="SubCatId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblSubCatId" runat="server" Text='<%#Eval("SubCatId") %>'></asp:Label>
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
                        </asp:GridView></td></tr></table>
            </td>
        </tr>
        </table>
     
     </ContentTemplate>
</asp:UpdatePanel>
</div>
 </asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

