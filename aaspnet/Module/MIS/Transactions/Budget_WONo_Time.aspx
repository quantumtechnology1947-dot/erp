<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_WONo_Time.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_WONo_Time" Theme ="Default"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
        <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css"/>

<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>

    <style type="text/css">
        .style1
        {
            width: 540px;
        }
    </style>

    </head>
<body style="margin-bottom:0px;  margin-left:0px; margin-right:0px; margin-top:0px;">
    <form id="form1" runat="server">
   <%-- <div> --%>    
  <table   width="100%" cellpadding="0" cellspacing="1" class="fontcss"><tr ><td align="left" valign="middle"  scope="col"   
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">&#160;<b><span lang="en-us">Hrs </span>Budget<span 
          lang="en-us"> For Work Order No: </span>
      <asp:Label ID="lblWoNo" runat="server"></asp:Label>
      </b></td></tr>
                       <tr>
                       <td align="left">
                           <table align="left" cellpadding="0" cellspacing="0">
                               <tr align="center">
                                   <td align="left" height="20">
                        <asp:Label ID="Label1" runat="server" CssClass="style2" Text="Equip. No [ Desc ]" 
                            style="font-weight: bold"></asp:Label>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" CssClass="style2" Text="Category" 
                            style="font-weight: bold"></asp:Label>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" CssClass="style2" Text="Sub Category" 
                            style="font-weight: bold"></asp:Label>
                    </td>
                    <td align="justify">&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" CssClass="style2" Text="Hrs" 
                            style="font-weight: bold"></asp:Label>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DropDownList ID="drpEqNo" runat="server" 
                            onselectedindexchanged="drpEqNo_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="drpEqNo" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                        <asp:DropDownList ID="drpCat" runat="server" 
                            onselectedindexchanged="drpCat_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="drpCat" ErrorMessage="*" InitialValue="1" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                        <asp:DropDownList ID="drpSubCat" runat="server" Enable="False">
                        </asp:DropDownList>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                        <asp:TextBox ID="txtHrs" runat="server" CssClass="box3" Width="70px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtHrs" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:CompareValidator 
                ID="CompareValidator1" runat="server" ControlToValidate="txtHrs" 
                ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ValidationGroup="A"></asp:CompareValidator>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                        <asp:Button ID="btnAdd" runat="server" CssClass="redbox" Text=" Add " 
                            onclick="btnAdd_Click" ValidationGroup="A" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                           </table>
                       </td>
                       </tr>
                       <td>
                       
                           <asp:Panel ID="Panel1" runat="server" Height ="330px" ScrollBars="Vertical">
                          
                           
                            <asp:GridView ID="GridView1"  runat="server" 
                    AutoGenerateColumns="False"
                    CssClass="yui-datatable-theme" onrowcommand="GridView1_RowCommand"  
                                   Width="1000px">
                                <PagerSettings PageButtonCount="40" />
                                <Columns>
                    
                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                    
                    
                    <asp:TemplateField><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Text="Select"/>
                        </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="CK"><ItemTemplate><asp:CheckBox ID="CheckBox1"  OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" runat="server"/>
                        </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="2%" /></asp:TemplateField>
                                    <asp:TemplateField 
                            HeaderText="Equip. No">
                        <ItemStyle HorizontalAlign="Center" Width="9%" />
                        <ItemTemplate>
                            <asp:Label ID="lblEquipNo" runat="server" Text='<%#Eval("Equipment No") %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                    
                    <asp:TemplateField HeaderText="Description">
                        <ItemStyle HorizontalAlign="Left" Width="35%" />
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                    
                    <asp:TemplateField HeaderText="Category">                                                
                        <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'> </asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                                        
                                        
                                        
                        <asp:TemplateField HeaderText="Sub Cate.">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                            <asp:Label ID="lblSubCategory" runat="server" Text='<%#Eval("Sub Category") %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="Budget Hrs" SortExpression="Hour" >
                        <ItemTemplate>
                        <asp:Label ID="lblHour" runat="server"  Text='<%#Eval("Budget Hrs") %>'> </asp:Label>                                      
                            <asp:TextBox ID="TxtHour" runat="server" ValidationGroup="A" Visible="false" 
                                Width="80%">
                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TxtHour" ErrorMessage="*" 
                            ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A">
                        </asp:RegularExpressionValidator>
                    </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Right" />
                    </asp:TemplateField>
                                    
                <asp:TemplateField HeaderText="Utilized Hrs">
                <ItemTemplate>
                <asp:Label ID="LblUsedHour" runat="server" Text='<%#Eval("Utilized Hrs") %>' > </asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" />
                    </asp:TemplateField> 
                                      
                    <asp:TemplateField HeaderText="Bal Hrs" >
                    <ItemTemplate>
                    <asp:Label ID="LblBalHour" runat="server"  Text='<%#Eval("Bal Hrs") %>'> </asp:Label>&nbsp;                                      
                    </ItemTemplate>
                        <ItemStyle Width="7%" HorizontalAlign="Right" />
                    </asp:TemplateField>
                                     
                                     
                    <asp:TemplateField HeaderText="EquipId" Visible="False">
                    <ItemTemplate>
                    <asp:Label ID="lblEquipId" runat="server"  Text='<%#Eval("EquipId") %>'> </asp:Label>&nbsp;                                      
                    </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Right" />
                    </asp:TemplateField>
                                     
                                     
                    <asp:TemplateField HeaderText="CatId" Visible="False">
                                     
                    <ItemTemplate>
                    <asp:Label ID="lblCatId" runat="server"  Text='<%#Eval("CatId") %>'> </asp:Label>&nbsp;                                      
                    </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Right" />
                    </asp:TemplateField>
                                     
                <asp:TemplateField HeaderText="SubCatId" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblSubCatId" runat="server"  Text='<%#Eval("SubCatId") %>'> </asp:Label>&nbsp;                                      
                    </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Right" />
                                    
                </asp:TemplateField>                                     
                                     
                    <asp:TemplateField HeaderText="Finish(%)">
                    <ItemTemplate>
                    <asp:Label ID="lblFinish" runat="server"  Text='<%#Eval("Finish") %>'> </asp:Label>&nbsp;                                      
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                                     
                                     </Columns>
                    </asp:GridView> </asp:Panel></td></tr>
                
                    <tr>
                        <td align="center" height="20px" valign="baseline">
                        <asp:Button ID="BtnInsert" runat="server" CssClass="redbox"  
                                     Text="Update" onclick="BtnInsert_Click" />
                                     &nbsp;<asp:Button ID="BtnExport" runat="server" CssClass="redbox" 
                                     Text="Export" onclick="BtnExport_Click" Visible="False" />
                            &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                        onclick="btnCancel_Click" Text="Cancel" />
                              
                                        
                        </td>
                </tr>
                    
                    </table>           
     
      <%--  </div>--%>
    </form>
</body>
</html>
