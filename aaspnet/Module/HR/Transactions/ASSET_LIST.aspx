<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ASSET_LIST.aspx.cs" Inherits="Module_HR_Transactions_ASSET_LIST" %>

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

<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>ASSET LIST</b></td>
        </tr>
<tr>
    <td></td>
</tr>
<tr>
    <td></td>
</tr>
<tr>
    <td></td>
</tr>
<tr></tr>
<tr>

   
</tr>


<tr>
<td>
   <%-- <asp:DropDownList ID="drp1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DRP_SELECTED">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="DESKTOP" Value="1"></asp:ListItem>
    </asp:DropDownList>--%>
</td>

</tr><tr></tr>
</table>
<br />
<br />
<table style="text-align:center">
<tr></tr>
<tr>


 <td align=center>
    SELECT ITEM
        <asp:DropDownList ID="drp1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DRP_SELECTED">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="DESKTOP" Value="1"></asp:ListItem>
    <asp:ListItem Text="LAPTOP" Value="2"></asp:ListItem>
    <asp:ListItem Text="PRINTER" Value="3"></asp:ListItem>
    <asp:ListItem Text="SWITCHES" Value="4"></asp:ListItem>
    <asp:ListItem Text="ROUTER" Value="5"></asp:ListItem>
    <asp:ListItem Text="PROJECTOR" Value="6"></asp:ListItem>
    <asp:ListItem Text="PUNCHING MACHINE" Value="7"></asp:ListItem>
    <asp:ListItem Text="CAMERA" Value="8"></asp:ListItem>
    <asp:ListItem Text="SAPLNAS" Value="9"></asp:ListItem>

    
    </asp:DropDownList>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
             SelectCommand="SELECT DEPT FROM tblHR_ASSET_MAIN_CATEGORY ORDER BY Id" >
               
         </asp:SqlDataSource>
    </td>
    </tr></table>
<br />
<br /> <asp:Panel ID="Panel1" runat="server" Visible="True">
     <asp:GridView ID="GridView1"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource2" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="IP Address"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("IP_add") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                
                   <asp:TemplateField HeaderText="PCNO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("PCNO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
               
                 <asp:TemplateField HeaderText="User Name"   HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                <asp:Label ID="lblpono1" runat="server" Text='<%# Bind("UserName") %>' Font-Size="Larger"></asp:Label> 
                
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />

            
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="MODEL" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lblpress1"  Text='<%# Bind("MODEL") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Processor" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblsft1"  Text='<%# Bind("Processor") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Mother Board" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lbl2D1"  Text='<%# Bind("MotherBoard") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="HDD" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lbl3D1"  Text='<%# Bind("HDD") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="RAM" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblbend1"  Text='<%# Bind("RAM") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="CD/DVD" >
                    <ItemTemplate>
                        <asp:Label Id="lblfab1"  Text='<%# Bind("CD_DVD") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    
                    
                    
                      <asp:TemplateField HeaderText="MOUSE" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblmchn1"  Text='<%# Bind("MOUSE") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="KEYBOARD" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblshr1"  Text='<%# Bind("KEYBOARD") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="MONITOR" >
                    <ItemTemplate>
                        <asp:Label Id="lblcDate"  Text='<%# Bind("MONITOR") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                
                <asp:TemplateField HeaderText="CABINET" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblremark"  Text='<%# Bind("CABINET") %>' runat="server"  ></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                
                   <asp:TemplateField HeaderText="GRAPHIC CARD" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblbend12"  Text='<%# Bind("GRAPHIC_CARD") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT, IP_add,PCNO,UserName,MODEL,Processor,MotherBoard,HDD,RAM,CD_DVD,MOUSE,KEYBOARD,MONITOR,CABINET,GRAPHIC_CARD FROM tblHR_ASSET_DESKTOP" >
               
         </asp:SqlDataSource>
         
         
         
         <asp:GridView ID="GridView2"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource3" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                
                   <asp:TemplateField HeaderText="IP Address"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("IP_ADD") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
               
                 <asp:TemplateField HeaderText="PCNO"   HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                <asp:Label ID="lblpono1" runat="server" Text='<%# Bind("PCNO") %>' Font-Size="Larger"></asp:Label> 
                
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />

            
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="USER NAME" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lblpress1"  Text='<%# Bind("USER_NAME") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="MODEL" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblsft1"  Text='<%# Bind("MODEL") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="PROCESSOR" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lbl2D1"  Text='<%# Bind("PROCESSOR") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="MOTHER BOARD" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lbl3D1"  Text='<%# Bind("MOTHER_BOARD") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="HDD" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblbend1"  Text='<%# Bind("HDD") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
    
    
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT, ASSET_NO,IP_ADD,PCNO,USER_NAME,MODEL,PROCESSOR,MOTHER_BOARD,HDD FROM tblHR_ASSET_LAPTOP" >
               
         </asp:SqlDataSource>
         
         
         
          <asp:GridView ID="GridView3"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource4" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="PRINTER NAME"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("PRINTER_NAME") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                
                   <asp:TemplateField HeaderText=" ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
               
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,PRINTER_NAME, ASSET_NO FROM tblHR_ASSET_PRINTER" >
               
         </asp:SqlDataSource>
         
           <asp:GridView ID="GridView4"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource5" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                   <asp:TemplateField HeaderText=" ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="ROUTER NAME"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("ROUTER") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,ROUTER, ASSET_NO FROM tblHR_ASSET_ROUTER" >
               
         </asp:SqlDataSource>
         
    <asp:GridView ID="GridView5"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource6" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                   <asp:TemplateField HeaderText=" ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="PROJECTOR NAME"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("PROJECTOR") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,PROJECTOR, ASSET_NO FROM tblHR_ASSET_PROJECTOR" >
               
         </asp:SqlDataSource>
         
    
    <asp:GridView ID="GridView6"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource7" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                   <asp:TemplateField HeaderText=" ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="SWITCH NAME"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("SWITCHES") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,SWITCHES, ASSET_NO FROM tblHR_ASSET_SWITCHES" >
               
         </asp:SqlDataSource>
         
         
          <asp:GridView ID="GridView7"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource8" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                   <asp:TemplateField HeaderText=" ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="PUNCHING MACHINE "  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("PUNCHING_MACHINE") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,PUNCHING_MACHINE, ASSET_NO FROM tblHR_ASSET_PUNCHING" >
               
         </asp:SqlDataSource>
         
           
          <asp:GridView ID="GridView8"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource9" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                   <asp:TemplateField HeaderText=" LOCATION"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("LOCATION") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="CAMERA NO  "  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("CAMERA_NUM") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
   
    
     <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,LOCATION,CAMERA_NUM FROM tblHR_ASSET_CAMERA" >
               
         </asp:SqlDataSource>
         
         
         <asp:GridView ID="GridView9"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource10" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  Visible="false" >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DEPT" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("DEPT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                
                   <asp:TemplateField HeaderText=" ASSET NO"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("ASSET_NO") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="STORAGE  "  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("STORAGE") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                    
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
  
    
     <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT DEPT,ASSET_NO,STORAGE FROM tblHR_ASSET_SAPLNAS" >
               
         </asp:SqlDataSource>
         
    </asp:Panel>


</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

