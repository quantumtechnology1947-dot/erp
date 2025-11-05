<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass_Delete.aspx.cs" Inherits="GatePass_Delete" Title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
     <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular.min.js"></script>
      <script type="text/javascript" src="../fusioncharts/fusioncharts.js"></script>

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
  <asp:Table runat="server" ID="kkkk" Width="100%">
  <asp:TableRow ID="TableRow3" runat="server">
  <asp:TableCell>
 
<asp:GridView ID="GridView1" 
                runat="server" 
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                DataSourceID="SqlDataSource1"
                EnableModelValidation="True"   Width="100%" BackColor="white" GridLines="Both" Height="100%"  >        
   <Columns>
   
 <asp:CommandField ButtonType="Link" Visible="false"  ShowEditButton="true" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" />
 <asp:CommandField   ButtonType="Link"  ShowDeleteButton="True" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" />
  
 <asp:TemplateField HeaderText="SR NO." HeaderStyle-Height="10"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
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
   
   <FooterTemplate>
    <asp:Button ID="Butt" runat="server" Text="Add"   OnClick="Insert" BackColor="Red" Width="50"  Visible="false" />
   </FooterTemplate>
   </asp:TemplateField>
 
   <asp:TemplateField HeaderText="DATE"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl34" Text='<%# Bind("Date") %>'></asp:Label>
   </ItemTemplate>
    <ItemStyle HorizontalAlign="center" />
    <EditItemTemplate>
    <asp:TextBox ID="edit2" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Date") %>'>
     </asp:TextBox>
     
     <cc1:CalendarExtender ID="r1r" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="edit2">
                        </cc1:CalendarExtender>
   </EditItemTemplate>
   
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text2" Width="100" Visible="false" ></asp:TextBox>
   
    <cc1:CalendarExtender ID="rr" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="Text2">
                        </cc1:CalendarExtender>  
   </FooterTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="WONO"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD" HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl5" Text='<%# Bind("WoNo") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
    <EditItemTemplate>
    <asp:TextBox ID="edit3" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("WoNo") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   
    <FooterTemplate>
    <asp:DropDownList ID="Text3" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource"
    DataTextField="WONo" DataValueField="WONo" AppendDataBoundItems="true" Width="120px" Visible="false">
    <asp:ListItem Text="All WONo" Value="" />
</asp:DropDownList>
<asp:SqlDataSource ID="DropDownDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [WONo] FROM [SD_Cust_WorkOrder_Master]"></asp:SqlDataSource>
   </FooterTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="SUPPLIER/CUSTOMER"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl6" Text='<%# Bind("Des_Name") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   
    <EditItemTemplate>
    <asp:TextBox ID="edit4" Width="100" runat="server" CssClass="box3"    ValidationGroup="Shree" Text='<%#Bind("Des_Name") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   
   <FooterTemplate>
   <asp:TextBox runat="server"  ID="Text4" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   </asp:TemplateField>
   
   
   
    <asp:TemplateField HeaderText="SUPPLIER/CUSTOMER NAME"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl14" Text='<%# Bind("AthoriseBy") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit11" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("AthoriseBy") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <FooterTemplate>
       <asp:DropDownList ID="Text11" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource112"
           DataTextField="EmployeeName" DataValueField="EmployeeName" AppendDataBoundItems="true" Width="95%" Visible="false">
          <asp:ListItem Text="EmployeeName" Value="" />
       </asp:DropDownList>
         <asp:SqlDataSource ID="DropDownDataSource112" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
              SelectCommand="SELECT [EmployeeName] FROM [tblHR_OfficeStaff]"></asp:SqlDataSource>
           </FooterTemplate>
    </asp:TemplateField>
   
   
   
   
   
    <asp:TemplateField HeaderText="CODE NO."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" >
  
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl7" Text='<%# Bind("CodeNo") %>'></asp:Label>
   </ItemTemplate>
    
     <EditItemTemplate>
    <asp:TextBox ID="edit5" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("CodeNo") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
    
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text5" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   <HeaderStyle HorizontalAlign="Center" />
  
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="DECRIPTION"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
  
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl8" Text='<%# Bind("Description") %>'></asp:Label>
   </ItemTemplate>
     
      <EditItemTemplate>
    <asp:TextBox ID="edit6" Width="100" TextMode="MultiLine" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Description") %>'>
     </asp:TextBox>
   </EditItemTemplate>
  
   <ItemStyle HorizontalAlign="center" />
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text6" TextMode="MultiLine" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="UNIT"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl9" Text='<%# Bind("Unit") %>'></asp:Label>
   </ItemTemplate>
   
   <EditItemTemplate>
    <asp:TextBox ID="edit7" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Unit") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   
    <ItemStyle HorizontalAlign="center" />
   <FooterTemplate>
    <asp:DropDownList ID="Text7" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource11"
    DataTextField="Symbol" DataValueField="Symbol" AppendDataBoundItems="true" Width="80px" Visible="false">
    <asp:ListItem Text="All UNIT" Value="" />
    </asp:DropDownList>
        <asp:SqlDataSource ID="DropDownDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [Symbol] FROM [Unit_Master]"></asp:SqlDataSource>
   </FooterTemplate>
  
   </asp:TemplateField>
  
   <asp:TemplateField HeaderText="RETURNABLE_GATEPASS"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
 
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl10" Text='<%# Bind("Gatepass") %>'></asp:Label>
   </ItemTemplate>
  
   <EditItemTemplate>
    <asp:TextBox ID="edit8" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Gatepass") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
  
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text8" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
  
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="TOTAL QTY"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl11" Text='<%# Bind("Total_qty") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit9" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Total_qty") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text9" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
  <ItemStyle HorizontalAlign="center" />
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="CHECKBY"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl13" Text='<%# Bind("IssueTo") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit10" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("IssueTo") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text10" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   </asp:TemplateField>
   
   
     <asp:TemplateField HeaderText="DATE OF RECEIPT"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl15" Text='<%# Bind("Rec_Date") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit12" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Rec_Date") %>'>
     </asp:TextBox>
     
     <cc1:CalendarExtender ID="rr3" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="edit12">
                        </cc1:CalendarExtender>  
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text12" Width="100" Visible="false"></asp:TextBox>
   
   <cc1:CalendarExtender ID="rr4" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                  Enabled="True" Format="dd-MM-yyyy" TargetControlID="Text12">
      </cc1:CalendarExtender>  
   
   </FooterTemplate>
   </asp:TemplateField>
  
     <asp:TemplateField HeaderText="QTY RECD."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl12" Text='<%# Bind("Qty_Recd") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   
   <EditItemTemplate>
    <asp:TextBox ID="edit13" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Qty_Recd") %>'>
     </asp:TextBox>
   </EditItemTemplate>
  
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text13" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   </asp:TemplateField>
    
    <asp:TemplateField HeaderText="QTY. PENDING."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl133" Text='<%# Bind("Qty_pend") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <EditItemTemplate>
    <asp:TextBox ID="edit14" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Qty_pend") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text14" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   </asp:TemplateField>
   
     <asp:TemplateField HeaderText="RECD. BY."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl1333" Text='<%# Bind("RecdBy") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <EditItemTemplate>
    <asp:TextBox ID="edit15" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("RecdBy") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text15" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   </asp:TemplateField>
    
    <asp:TemplateField HeaderText="REMARK"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl183" Text='<%# Bind("Remark") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <EditItemTemplate>
    <asp:TextBox ID="edit16" Width="100" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Remark") %>'>
     </asp:TextBox>
   </EditItemTemplate>
   <FooterTemplate>
   <asp:TextBox runat="server" ID="Text16" Width="100" Visible="false"></asp:TextBox>
   </FooterTemplate>
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="Status" Visible="false" HeaderStyle-BackColor="#E0E0E0">
        <ItemTemplate >
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
   
   
   
  </Columns>
  
  <PagerStyle HorizontalAlign="Center" />
   <HeaderStyle  HorizontalAlign="Center" />
  
    </asp:GridView>
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
       ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>" 
       DeleteCommand="DELETE FROM [Returnable_GatePass] WHERE [Id] = @Id" 
       InsertCommand="INSERT INTO [tbl_Gatepass] ([Id,SrNO,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Qty,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark]) VALUES (@Id,@SrNO,@ChalanNo,@Date,@WoNo,@Des_Name,@CodeNo,@Description,@Unit,@Qty,@Total_qty,@IssueTo,@AthoriseBy,@Rec_Date,@Qty_Recd,@Qty_pend,@RecdBy,@Remark)" 
       SelectCommand="SELECT [Date],[WoNo],[Des_Name],[CodeNo],[Description],[Unit],[Gatepass],[Total_qty],[IssueTo],[AthoriseBy],[Rec_Date],[Qty_Recd],[Qty_pend],[RecdBy],[Remark],[Id] FROM [Returnable_GatePass]"
       UpdateCommand="UPDATE [Returnable_GatePass] SET [Date]=@Date,[WoNo]=@WoNo,[Des_Name]=@Des_Name,[CodeNo]=@CodeNo,[Description]=@Description,[Unit]=@Unit,[Gatepass]=@Gatepass,[Total_qty]=@Total_qty,[IssueTo]=@IssueTo,[AthoriseBy]=@AthoriseBy,[Rec_Date]=@Rec_Date,[Qty_Recd]=@Qty_Recd,[Qty_pend]=@Qty_pend,[RecdBy]=@RecdBy,[Remark]=@Remark WHERE [Id] = @Id">
                 
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

 </asp:TableCell>
  </asp:TableRow> 
  </asp:Table>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

