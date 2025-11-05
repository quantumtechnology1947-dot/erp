<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Acc_Capital_Particulars, newerp_deploy" theme="Default" title="ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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

<table width="100%">
    <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="3">
                <b>&nbsp;Capital(Goods)</b></td>
        </tr>
   <tr>
   <td align="Left">
    <asp:Panel ID="Panel1" ScrollBars="Auto"   Width="100%" Height="430px"  runat="server">
         <asp:GridView ID="GridView1" runat="server" Width="70%" GridLines="None" 
          AlternatingRowStyle-BackColor="AliceBlue" AutoGenerateColumns="False" 
          onrowcommand="GridView1_RowCommand" CssClass="yui-datatable-theme" 
             ShowFooter="True" onrowdatabound="GridView1_RowDataBound" EmptyDataText="No Records To Display" EmptyDataRowStyle-BackColor="Aqua" >
      
      <Columns>     
      <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Right" Width="5%"/>
                            </asp:TemplateField>
                                     
       <asp:TemplateField HeaderText="Particulars" >
       <ItemTemplate>       
        <asp:LinkButton ID="LinkButton1" CommandName="Sel" Text='<%#Eval("Particulars") %>'  runat="server"></asp:LinkButton>
       </ItemTemplate>
           <FooterTemplate>
       <asp:Label ID="TotLbl" Font-Bold="true" runat="server" Text="Total"></asp:Label>
       </FooterTemplate>
           <FooterStyle HorizontalAlign="Right" />
       <ItemStyle HorizontalAlign="left"/>
       </asp:TemplateField> 
       
       <asp:TemplateField HeaderText="Debit">   
       
       <ItemTemplate>       
           <asp:Label ID="lblDrAmt" runat="server" Text='<%#Eval("TotDrAmt") %>'></asp:Label>
       </ItemTemplate>
       <FooterTemplate>
       <asp:Label ID="TotDebit" runat="server" Text="0"></asp:Label>
       </FooterTemplate>
           <FooterStyle Width="20%" Font-Bold="true" HorizontalAlign="Right"/>
       <HeaderStyle HorizontalAlign="Center" />   
       <ItemStyle HorizontalAlign="Right" Width="20%"  />
       </asp:TemplateField>     
       
       <asp:TemplateField HeaderText="Credit">
       <ItemTemplate>       
           <asp:Label ID="lblCrAmt" runat="server" Text='<%#Eval("TotCrAmt") %>'></asp:Label>
       </ItemTemplate>
       <FooterTemplate>
       <asp:Label ID="TotCredit" runat="server" Text="0"></asp:Label>
       </FooterTemplate>
           <FooterStyle Width="20%" HorizontalAlign="Right" Font-Bold="true"/>
           <HeaderStyle HorizontalAlign="Center" />
       <ItemStyle HorizontalAlign="Right" Width="20%"  />
       </asp:TemplateField>
       
       <asp:TemplateField Visible="false">
       <ItemTemplate>       
           <asp:Label ID="lblId"  runat="server" Text='<%#Eval("Id") %>'></asp:Label>
       </ItemTemplate>
      
       </asp:TemplateField>       
       
     </Columns>
                                 
             <AlternatingRowStyle BackColor="AliceBlue" />
                                 
      </asp:GridView>
    </asp:Panel>
   </td>
   </tr>
   
   <tr>
   <td  align="center" style="height:25px; ">   
       <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Cancel" 
           onclick="btnCancel_Click" /></td>
   </tr>
   
   </table>   


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

