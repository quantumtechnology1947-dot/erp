<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass_CrystalReport.aspx.cs" Inherits="GatePass_CrystalReport" Title="ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

<asp:Table runat="server" ID="jj" Width="100%" Height="25">
<asp:TableRow  runat="server" ID="tr" Width="100%" BackColor="gray">
<asp:TableCell>
<asp:Label runat="server" ID="lls" Text="RETURNABLE GATE PASS" Width="100%" ForeColor="white" Font-Bold="true" Font-Size="Larger"></asp:Label>
</asp:TableCell>
</asp:TableRow>
</asp:Table>

<br />

<asp:Table runat="server" ID="fff" Width="20%">

<asp:TableRow>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/View.png" ID="uij"  Width="18" Height="18" OnClick="Image2" />
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/new.png.png" ID="ImageButton2" Width="15" Height="15" OnClick="Image1" />
</asp:TableCell>


<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/edit.png" ID="ImageButton1" Width="20" Height="20" OnClick="Image3" />
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/delete.jpg" ID="ImageButton3" Width="13" Height="13" OnClick="Image4" />
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server"   img src="../../../images/Print_PNG.jpg" ID="ImageButton4" Width="23px" Height="20" OnClick="Image5" />
</asp:TableCell>

</asp:TableRow>

<asp:TableRow>

<asp:TableCell HorizontalAlign="center">

<asp:Label ID="Label4" runat="server" Text="View"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">

<asp:Label ID="Label1" runat="server" Text="New"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:Label ID="Label3" runat="server" Text="Edit"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:Label ID="Label2" runat="server" Text="Delete"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:Label ID="Label19" runat="server" Text="Print"></asp:Label>
</asp:TableCell>

</asp:TableRow>
</asp:Table>





<br />
  
<asp:GridView ID="GridView1" 
                runat="server" 
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                DataSourceID="SqlDataSource1"
                EnableModelValidation="True"   Width="100%" BackColor="white" GridLines="Both" Height="100%">
   <Columns>
  <asp:TemplateField HeaderText="." HeaderStyle-Height="10"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
 <ItemTemplate>
           <asp:LinkButton ID="LinkButton1" runat="server" OnClick="GatepassReport_click" Text="View"></asp:LinkButton>
     </ItemTemplate>
  </asp:TemplateField>
   
   
 <asp:TemplateField HeaderText="SR NO." HeaderStyle-Height="10"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
 <ItemTemplate>
      <%# Container.DataItemIndex + 1%>
 </ItemTemplate>
 <ItemStyle HorizontalAlign="Center" />
  <FooterTemplate>
  </FooterTemplate>
 </asp:TemplateField>
 
  <asp:TemplateField HeaderText="CHALLAN NO."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
 <ItemTemplate>
      <%# Container.DataItemIndex + 1%>
 </ItemTemplate>
      
  <ItemStyle HorizontalAlign="Center" />
   </asp:TemplateField>
 
 <asp:TemplateField HeaderText="SELECT RETURNABLE GATEPASS"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
         <asp:DropDownList ID="TextBox3" runat="server" >
               <asp:ListItem Text="Returnable" Value="Returnable" ></asp:ListItem>
                    <asp:ListItem Text="Rejection" Value=" Rejection" ></asp:ListItem>
                        <asp:ListItem Text="Non-Returnable" Value="Non-Returnable" ></asp:ListItem>
         </asp:DropDownList>
 </ItemTemplate>
 </asp:TemplateField>
 
  <asp:TemplateField HeaderText="DATE"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl34" Text='<%# Bind("Date") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="WONO"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl5" Text='<%# Bind("WoNo") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
 <asp:TemplateField HeaderText="SUPPLIER/CUSTOMER"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl6" Text='<%# Bind("Des_Name") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
  
  
   <asp:TemplateField HeaderText="SUPPLIER/CUSTOMER NAME"  Visible="false"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl14" Text='<%# Bind("AthoriseBy") %>'></asp:Label>
   </ItemTemplate>
    </asp:TemplateField>
  
  
  
  
  <asp:TemplateField HeaderText="CODE NO."  Visible="false" HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" >
  <ItemTemplate>
   <asp:Label runat="server" ID="lbl7" Text='<%# Bind("CodeNo") %>'></asp:Label>
   </ItemTemplate>
  </asp:TemplateField>
    <asp:TemplateField HeaderText="DECRIPTION"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
  
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl8" Text='<%# Bind("Description") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="UNIT"  Visible="false"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl9" Text='<%# Bind("Unit") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
  
   <asp:TemplateField HeaderText="RETURNABLE_GATEPASS"   HeaderStyle-Font-Bold="true" Visible="false"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
  <ItemTemplate>
   <asp:Label runat="server" ID="lbl10" Text='<%# Bind("Gatepass") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="TOTAL QTY"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl11" Text='<%# Bind("Total_qty") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="CHECKBY"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl13" Text='<%# Bind("IssueTo") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
   
     <asp:TemplateField HeaderText="DATE OF RECEIPT"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl15" Text='<%# Bind("Rec_Date") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
  
     <asp:TemplateField HeaderText="QTY RECD."   Visible="false" HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl12" Text='<%# Bind("Qty_Recd") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="QTY. PENDING."  Visible="false"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl133" Text='<%# Bind("Qty_pend") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="RECD BY." Visible="false"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl1333" Text='<%# Bind("RecdBy") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
    
    <asp:TemplateField HeaderText="REMARK"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl183" Text='<%# Bind("Remark") %>'></asp:Label>
   </ItemTemplate>
   </asp:TemplateField>
   
  </Columns>
  
    </asp:GridView>
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
       ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>" 
       DeleteCommand="DELETE FROM [tbl_Gatepass] WHERE [Id] = @Id" 
       InsertCommand="INSERT INTO [tbl_Gatepass] ([Id,SrNO,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Qty,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark]) VALUES (@Id,@SrNO,@ChalanNo,@Date,@WoNo,@Des_Name,@CodeNo,@Description,@Unit,@Qty,@Total_qty,@IssueTo,@AthoriseBy,@Rec_Date,@Qty_Recd,@Qty_pend,@RecdBy,@Remark)" 
       SelectCommand="SELECT [Date],[WoNo],[Des_Name],[CodeNo],[Description],[Unit],[Gatepass],[Total_qty],[IssueTo],[AthoriseBy],[Rec_Date],[Qty_Recd],[Qty_pend],[RecdBy],[Remark],[Id] FROM [Returnable_GatePass]"
       UpdateCommand="UPDATE [Returnable_GatePass] SET [Date]=@Date,[WoNo]=@WoNo,[Des_Name]=@Des_Name,[CodeNo]=@CodeNo,[Description]=@Description,[Unit]=@Unit,[Qty]=@Qty,[Total_qty]=@Total_qty,[IssueTo]=@IssueTo,[AthoriseBy]=@AthoriseBy,[Rec_Date]=@Rec_Date,[Qty_Recd]=@Qty_Recd,[Qty_pend]=@Qty_pend,[RecdBy]=@RecdBy,[Remark]=@Remark WHERE [Id] = @Id">
                 
                    <DeleteParameters>
                      <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    
                     <UpdateParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                     </UpdateParameters>
                  
                   <InsertParameters>
                       <asp:Parameter Name="Activities" Type="String" />
                       <asp:Parameter Name="Id" Type="String" />
                   </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

