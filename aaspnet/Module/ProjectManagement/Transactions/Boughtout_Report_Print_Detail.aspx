<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Boughtout_Report_Print_Detail.aspx.cs" Inherits="Challanreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> ERP</title>
    <style> 
        form
        {
        	border: 1px solid black;
            height: 520px;
        }
        .style4
        {
            height: 107px;
            width: 290px;
        }
        .style6
        {
            width: 84px;
            height: 107px;
        }
        .style7
        {
            width: 97px;
            height: 107px;
        }
        .style8
        {
            width: 8px;
            height: 107px;
        }
        .style9
        {
            height: 107px;
        }
        </style> 
<%-- <style type="text/css" media="print">
@page {
      
    margin: 0;  /* this affects the margin in the printer settings */
}
</style>--%>
</head>
<body>
    <form id="form1" runat="server" style="font-weight: normal">
    <%--<div>--%>
    <%--<div id="img1" style="width: 178px; height: 94px;" >--%>
       <table style="width: 934px">
        <tr>
            <td class="style7">
                 <asp:Image ID="Image1"  Height="77px" Width="123px" 
        ImageUrl="~/images/logo.jpg" runat="server" style="margin-top:1%"/>
            </td>
            <td class="style8"></td>
             <td class="style4">
            &nbsp;<small><b style="font-family:Times New Roman; font-style:normal">SYNERGYTECH AUTOMATION PVT.LTD.</b></small><br />
    &nbsp;<small>Gat No.205,Kasurdi (Khed Shivapur),</small> &nbsp;&nbsp;<br />
                <small>&nbsp;Off Pune Satara Road , Tal.Bhor , Dist. Pune -412205</small>&nbsp;<br />
&nbsp;<small>Tel No. - 9881147037</small><br />
&nbsp;<small>Email -&quot;sales@synergytechs.com&quot;</small><br />
    &nbsp;<small>GST No - 27AAHCS9857M1ZD</small>&nbsp;
            </td>
            <td class="style6"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</td>
            <td align="right" class="style9">
           <table >
            <tr align="right">
            <td >
            &nbsp; </td>
                <td align="lEFT">
                
                    &nbsp;</td>
               
            </tr>
           </table>
            </td>
        </tr>
       </table>
    <center> 
            <hr />
        <asp:Label runat="server" ID="dclabel" Text="Design Report" 
            Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label> </center> 
   <br />

        
    </div>
            &nbsp;
    <asp:Label ID="Label3" runat="server" Text="Report No." Font-Bold="True" 
        Font-Size="Large"></asp:Label>
&nbsp;:&nbsp;<asp:Label ID="Labeldc" runat="server" Text="Label" Font-Bold="True" 
        Font-Size="Large"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="Date" Font-Bold="True" 
        Font-Size="Large"></asp:Label>
    :  <asp:Label ID="Labeldate" runat="server"  Font-Bold="True" 
        Font-Size="Large" Visible="True"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;
            <hr />
<%--            <div class = "vertical">
--%>&nbsp;
    <asp:Label ID="lblwonor0" runat="server" Font-Bold="True" 
        Font-Size="Large">WONO</asp:Label>
    &nbsp; :&nbsp;&nbsp; <asp:Label ID="lblwonor" runat="server" Font-Bold="True" 
        Font-Size="Large"></asp:Label>
    <br />
<hr />

 
    <asp:GridView ID="GridView2" runat="server" Width = "100%" AutoGenerateColumns="False" 
     style="margin-top: 0px" >
    <RowStyle HorizontalAlign="Center" />
        <Columns>
        <asp:TemplateField HeaderText="Sr No">
        <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
        </ItemTemplate>
    </asp:TemplateField>
    
   
                  
                  
                  <asp:TemplateField  Visible="False">
        <ItemTemplate><asp:Label ID="LblId" runat ="server" Text='<%#Eval("Id") %>' ></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
                
                
             <asp:TemplateField HeaderText="Item Code">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblitemcode" Text='<%#Eval("ItemCode") %>'>'></asp:Label>
                    </ItemTemplate>
                  
                  </asp:TemplateField>
                           
                                  
                      
                    <asp:TemplateField HeaderText="Description" >
                <ItemTemplate>
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>         
                       
                      <asp:TemplateField HeaderText="UOM" >
                <ItemTemplate>
             <asp:Label ID="lbluombasic" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>        
                        
                        
                   <asp:TemplateField HeaderText="BOM Qty" >
                <ItemTemplate>
                <asp:Label ID="lblbomqty" runat="server" Text='<%#Eval("BOMQ") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>          
                
                
                
                  <asp:TemplateField HeaderText="Design" >
                    <ItemTemplate>
                        <asp:Label runat="server" ID="txtdesign" Visible="True" Text='<%#Eval("Design") %>'>'></asp:Label>
                    </ItemTemplate>
                  
                  </asp:TemplateField>
                         
        </Columns>
    </asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
    SelectCommand="SELECT [Id],[ItemCode],[Description],[UOM],[BOMQ],[WONo] ,[Design] FROM [tblPM_Project_Hardware_Master_Detail] WHERE ([PRJCTNO] = @PRJCTNO)">
    <SelectParameters>
        <asp:QueryStringParameter Name="PRJCTNO" QueryStringField="PRJCTNO" 
            Type="String" />
    </SelectParameters>
</asp:SqlDataSource>

<hr />
  
           <asp:Label ID="Label1" runat="server" Text="Label" Visible=false></asp:Label>
           
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <br />
   
   
   <br />
   <br />
   <br />
   
   
    <asp:Button ID="Button1" Visible="False" runat="server" BackColor="Red" ForeColor="White" Text="Update" OnClick="Button1_Click" />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
  <asp:Button runat="server" ID="btncancel" Visible="false" OnClick="Button_Cancel_Click" Text="Cancel" BackColor="Red" ForeColor="White" /> 
    </form>
</body>
</html>
