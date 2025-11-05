<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass_Edit.aspx.cs" Inherits="GatePass_Edit" Title="ERP" %>
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
  <asp:Table runat="server" ID="Table1" Width="100%">
  <asp:TableRow ID="TableRow4" runat="server">
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
   
 <asp:CommandField ButtonType="Link"   ShowEditButton="true"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" />
 <asp:CommandField   ButtonType="Link" Visible="false" ShowDeleteButton="True"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" />
  
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
 
   <asp:TemplateField HeaderText="DATE"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl34" Text='<%# Bind("Date") %>'></asp:Label>
   </ItemTemplate>
    <ItemStyle HorizontalAlign="center" />
  </asp:TemplateField>
   
    <asp:TemplateField HeaderText="WoNo"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl5" Text='<%# Bind("WoNo") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
    <EditItemTemplate>
    <asp:TextBox ID="edit3"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("WoNo") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="edit3" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
                             
   </EditItemTemplate>
   
</asp:TemplateField>
   
    <asp:TemplateField HeaderText="SUPPLIER/CUSTOMER"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl6" Text='<%# Bind("Des_Name") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   
    <EditItemTemplate>
   
              <asp:DropDownList ID="TextBox3" runat="server" SelectedValue='<%# Bind("Des_Name") %>' >
                           <asp:ListItem Text="Select" Value="" />
                         <asp:ListItem Text="Supplier" Value="Supplier"  ></asp:ListItem>
                           <asp:ListItem Text="customer" Value="customer" ></asp:ListItem>
                             
                       </asp:DropDownList>                    
             <asp:RequiredFieldValidator ID="RequiredFieldVa1" runat="server"  ControlToValidate="TextBox3" ErrorMessage="*">
                                </asp:RequiredFieldValidator>                        
                                
                                   
   </EditItemTemplate>
   
   
   </asp:TemplateField>
   
   
   <asp:TemplateField HeaderText="SUPPLIER/CUSTOMER NAME"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl14" Text='<%# Bind("AthoriseBy") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit11"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("AthoriseBy") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  ControlToValidate="edit11" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
     
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   </asp:TemplateField>
   
   
    <asp:TemplateField HeaderText="CODE NO."  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center" >
  
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl7" Text='<%# Bind("CodeNo") %>'></asp:Label>
   </ItemTemplate>
    
     <EditItemTemplate>
    <asp:TextBox ID="edit5"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("CodeNo") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ControlToValidate="edit5" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
     
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
  
   <HeaderStyle HorizontalAlign="Center" />
  
   </asp:TemplateField>
   
    <asp:TemplateField HeaderText="DECRIPTION"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
  
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl8" Text='<%# Bind("Description") %>'></asp:Label>
   </ItemTemplate>
     
      <EditItemTemplate>
    <asp:TextBox ID="edit6"   runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Description") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server"  ControlToValidate="edit6" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
     
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
  </asp:TemplateField>
   
    <asp:TemplateField HeaderText="UNIT"   HeaderStyle-Width="50" HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl9" Text='<%# Bind("Unit") %>'></asp:Label>
   </ItemTemplate>
   
   <EditItemTemplate>
  
      <asp:DropDownList ID="Textbox6" runat="server"  SelectedValue='<%# Bind("Unit") %>' >
                           <asp:ListItem Text="Select" Value="" />
                         <asp:ListItem Text="NOS" Value="NOS"  ></asp:ListItem>
                           <asp:ListItem Text="KG" Value="KG" ></asp:ListItem>
                            <asp:ListItem Text="LIT" Value="LIT"  ></asp:ListItem>
                           <asp:ListItem Text="LOOSE" Value="LOOSE" ></asp:ListItem>
                            <asp:ListItem Text="MTR" Value="MTR"  ></asp:ListItem>
              </asp:DropDownList>  
     
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  ControlToValidate="Textbox6" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
                             
</EditItemTemplate>
    <ItemStyle HorizontalAlign="center" />
   </asp:TemplateField>
  
   <asp:TemplateField HeaderText="RETURNABLE_GATEPASS"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
    <ItemTemplate>
          <asp:Label runat="server" ID="lbl10" Text='<%# Bind("Gatepass") %>'></asp:Label>
      </ItemTemplate>
  
       <EditItemTemplate>
         
         <asp:DropDownList ID="Textbox7" runat="server"  SelectedValue='<%# Bind("Gatepass") %>'>
                           <asp:ListItem Text="Select" Value="" />
                         <asp:ListItem Text="Returnable" Value="Returnable"  ></asp:ListItem>
                           <asp:ListItem Text="Non Returnable " Value="Non Returnable" ></asp:ListItem>
                            <asp:ListItem Text="Rejection" Value="Rejection"  ></asp:ListItem>
                             
                       </asp:DropDownList> 
         
     
         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  ControlToValidate="Textbox7" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
    
      </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
  
   </asp:TemplateField>
   
   
   
    <asp:TemplateField HeaderText="TOTAL QTY"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl11" Text='<%# Bind("Total_qty") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit9"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Total_qty") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  ControlToValidate="edit9" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
   </EditItemTemplate>
   
      <ItemStyle HorizontalAlign="center" />
  </asp:TemplateField>
   
    <asp:TemplateField HeaderText="CHECKBY"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl13" Text='<%# Bind("IssueTo") %>'></asp:Label>
   </ItemTemplate>
   <EditItemTemplate>
    <asp:TextBox ID="edit10"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("IssueTo") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  ControlToValidate="edit10" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
   </EditItemTemplate>
  
 </asp:TemplateField>
   
 
     <asp:TemplateField HeaderText="DATE OF RECEIPT"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
       <ItemTemplate>
           <asp:Label runat="server" ID="lbl15" Text='<%# Bind("Rec_Date") %>'></asp:Label>
       </ItemTemplate>
   
    <EditItemTemplate>
    <asp:TextBox ID="edit12"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Rec_Date") %>'>
     </asp:TextBox>

     <cc1:CalendarExtender ID="rr3" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="edit12">
                        </cc1:CalendarExtender>  
                        
       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  ControlToValidate="edit12" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
                        
   </EditItemTemplate>
   <ItemStyle HorizontalAlign="center" />
  </asp:TemplateField>

     <asp:TemplateField HeaderText="QTY RECD."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl12" Text='<%# Bind("Qty_Recd") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   
   <EditItemTemplate>
    <asp:TextBox ID="edit13"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Qty_Recd") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  ControlToValidate="edit13" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            

   </EditItemTemplate>
  
   </asp:TemplateField>
    
   <asp:TemplateField HeaderText="QTY. PENDING."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl133" Text='<%# Bind("Qty_pend") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <EditItemTemplate>
    <asp:TextBox ID="edit14"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Qty_pend") %>'>
     </asp:TextBox>
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  ControlToValidate="edit14" ErrorMessage="*">
        </asp:RequiredFieldValidator>
   </EditItemTemplate>
  </asp:TemplateField>
   
    <asp:TemplateField HeaderText="RECD. BY."   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl1333" Text='<%# Bind("RecdBy") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <EditItemTemplate>
    <asp:TextBox ID="edit15"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("RecdBy") %>'>
     </asp:TextBox>
     
   <cc1:CalendarExtender ID="rrrr" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="edit15">
                        </cc1:CalendarExtender>  
     
     <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"  ControlToValidate="edit15" ErrorMessage="*">
                                </asp:RequiredFieldValidator>            
   
   </EditItemTemplate>
   </asp:TemplateField>
    
    <asp:TemplateField HeaderText="REMARK"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
   <ItemTemplate>
   <asp:Label runat="server" ID="lbl183" Text='<%# Bind("Remark") %>'></asp:Label>
   </ItemTemplate>
   <ItemStyle HorizontalAlign="center" />
   <EditItemTemplate>
    <asp:TextBox ID="edit16"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Remark") %>'>
     </asp:TextBox>
     
       <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"  ControlToValidate="edit16" ErrorMessage="*">
         </asp:RequiredFieldValidator>
                   
   </EditItemTemplate>
   </asp:TemplateField>
   
  </Columns>
  
    </asp:GridView>
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
       ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>" 
       DeleteCommand="DELETE FROM [tbl_Gatepass] WHERE [Id] = @Id" 
       InsertCommand="INSERT INTO [tbl_Gatepass] ([Id,SrNO,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Cust_Name,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark]) VALUES (@Id,@SrNO,@ChalanNo,@Date,@WoNo,@Des_Name,@CodeNo,@Description,@Unit,@Qty,@Total_qty,@IssueTo,@AthoriseBy,@Rec_Date,@Qty_Recd,@Qty_pend,@RecdBy,@Remark)" 
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
    
<asp:Table ID="Gantt" runat="server" Width="100%" Visible="false" GridLines="Both" Height="92px" >
    <asp:TableRow ID="TableRow1" runat="server">
    <asp:TableCell ></asp:TableCell>
          <asp:TableCell Text="DATE"></asp:TableCell>
          <asp:TableCell Text="WoNo" Height="3"></asp:TableCell>
          <asp:TableCell Text="DESTINATION NAME / ADDRESS"></asp:TableCell>
          <asp:TableCell Text="CODE NO."></asp:TableCell>
          <asp:TableCell Text="DECRIPTION"></asp:TableCell>
          <asp:TableCell Text="UNIT"></asp:TableCell>
          <asp:TableCell Text="QTY"></asp:TableCell>
          <asp:TableCell Text="TOTAL QTY"></asp:TableCell>
          <asp:TableCell Text="ISSUED TO"></asp:TableCell>
          <asp:TableCell Text="AUTHORISED BY"></asp:TableCell>
          <asp:TableCell Text="DATE OF RECEIPT"></asp:TableCell>
          <asp:TableCell Text="QTY RECD."></asp:TableCell>
          <asp:TableCell Text="QTY. PENDING."></asp:TableCell>
          <asp:TableCell Text="RECD. BY."></asp:TableCell>
          
          <asp:TableCell Text="REMARK"></asp:TableCell>
          </asp:TableRow>
            
           <asp:TableRow ID="TableRow2" runat="server" ForeColor="BLACK"  HorizontalAlign="Center">
             
             <asp:TableCell Height="">
             <asp:Button runat="server" ID="btn" Text="Add" OnClick="Add" BackColor="red" />
             </asp:TableCell>
             
              <asp:TableCell>
               <asp:TextBox ID="Textbox1" runat="server"></asp:TextBox>
               
                <cc1:CalendarExtender ID="r1r" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="Textbox1">
                        </cc1:CalendarExtender>  
               
                    </asp:TableCell>
                    
               <asp:TableCell>
                <asp:DropDownList ID="Textbox2" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource"
    DataTextField="WONo" DataValueField="WONo" AppendDataBoundItems="true" Width="120px" >
    <asp:ListItem Text="All WONo" Value="" />
</asp:DropDownList>
<asp:SqlDataSource ID="DropDownDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [WONo] FROM [SD_Cust_WorkOrder_Master]"></asp:SqlDataSource>
                     </asp:TableCell>
             
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:TextBox ID="Textbox3" runat="server"></asp:TextBox>
                 </asp:TableCell>
               
               <asp:TableCell ID="TableCell4" runat="server">
                  <asp:TextBox ID="Textbox4" runat="server"></asp:TextBox>
              </asp:TableCell>
              
                <asp:TableCell ID="TableCell5" runat="server" Text="">
                  <asp:TextBox ID="Textbox5" runat="server"></asp:TextBox>
              </asp:TableCell>
                
                 <asp:TableCell ID="TableCell1" runat="server" Text="">
                  <asp:DropDownList ID="Textbox6" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource11"
    DataTextField="Symbol" DataValueField="Symbol" AppendDataBoundItems="true" Width="80px">
    <asp:ListItem Text="All UNIT" Value="" />
    </asp:DropDownList>
        <asp:SqlDataSource ID="DropDownDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [Symbol] FROM [Unit_Master]"></asp:SqlDataSource>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell3" runat="server" Text="">
                  <asp:TextBox ID="Textbox7" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell6" runat="server" Text="">
                  <asp:TextBox ID="Textbox8" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell7" runat="server" Text="">
                  <asp:TextBox ID="Textbox9" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell8" runat="server" Text="">
                  <asp:DropDownList ID="Textbox10" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource112"
           DataTextField="EmployeeName" DataValueField="EmployeeName" AppendDataBoundItems="true" Width="95%" >
          <asp:ListItem Text="EmployeeName" Value="" />
       </asp:DropDownList>
         <asp:SqlDataSource ID="DropDownDataSource112" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
              SelectCommand="SELECT [EmployeeName] FROM [tblHR_OfficeStaff]"></asp:SqlDataSource>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell9" runat="server" Text="">
                  <asp:TextBox ID="Textbox11" runat="server"></asp:TextBox>
                   <cc1:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="Textbox11">
                        </cc1:CalendarExtender>  
                  
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell10" runat="server" Text="">
                  <asp:TextBox ID="Textbox12" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell11" runat="server" Text="">
                  <asp:TextBox ID="Textbox13" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell12" runat="server" Text="">
                  <asp:TextBox ID="Textbox14" runat="server"></asp:TextBox>
              </asp:TableCell>
              
               <asp:TableCell ID="TableCell13" runat="server" Text="">
                  <asp:TextBox ID="Textbox15" runat="server"></asp:TextBox>
              </asp:TableCell>
              
              </asp:TableRow>
            </asp:Table>
     </asp:TableCell>
  </asp:TableRow>
  
  </asp:Table>

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

