<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Stock_Month.aspx.cs" Inherits="Stock_Month" Title="Stock_Month" %>
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

    <asp:GridView ID="GridView1" 
                runat="server" 
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                DataSourceID="SqlDataSource1"
                Width="100%" 
                EnableModelValidation="True"  AllowSorting="False"  BackColor="#FAFAFA" GridLines="Both" Height="421px"  >        
               
               <FooterStyle Wrap="True">
              </FooterStyle>
                
                 <Columns>
              <asp:CommandField ButtonType="Link"  HeaderStyle-BackColor="#607D8B"  ShowEditButton="True" ValidationGroup="Shree"  />
               <asp:CommandField   ButtonType="Link" ShowDeleteButton="True" HeaderStyle-BackColor="#607D8B"  />
   
               <asp:TemplateField HeaderText="SR.NO" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="#607D8B" HeaderStyle-Height="40px" HeaderStyle-ForeColor="white">
               
                <ItemTemplate>
                  <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
               <ItemStyle HorizontalAlign="Right" />
            
                    <FooterTemplate>
                     <asp:Button runat="server" ID="btn" Text="Insert"  BackColor="red"  OnClick="Insert_click" Visible="false" />
                       </FooterTemplate>
               
                </asp:TemplateField>
                
                
                <asp:TemplateField HeaderText="ITEM CODE" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"   HeaderStyle-BackColor="#607D8B" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-ForeColor="white" HeaderStyle-Height="45">
                 
                  <ItemTemplate>
                    <asp:Label ID="lb11" runat="server" Text='<%# Bind("Item_code") %>' Height="30px" Font-Size="Larger"></asp:Label>
                 </ItemTemplate>
              
                 <ItemStyle HorizontalAlign="Left" />
                <FooterTemplate>
                 <asp:TextBox runat="server" ID="Text1" Visible="false"></asp:TextBox>
                 </FooterTemplate>
                 
                 <EditItemTemplate>
                    <asp:TextBox ID="edit1" Width="50%"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Item_code") %>'>
                   </asp:TextBox>
                </EditItemTemplate>
                    
                </asp:TemplateField>
            
                 <asp:TemplateField HeaderText="Group" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B" HeaderStyle-ForeColor="white" >
                 <ItemTemplate>
                  <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Group") %>' Font-Size="Larger"></asp:Label>
                 </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                 <HeaderStyle  HorizontalAlign="Center" />
                 <FooterTemplate>
                 <asp:textBox runat="server" ID="Text2" Visible="false"></asp:textBox>
                 </FooterTemplate> 
                 
                 <EditItemTemplate>
                     <asp:TextBox ID="edit2" Width="50%"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Group") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="DESCRIPTION" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B"  HeaderStyle-ForeColor="white" HeaderStyle-HorizontalAlign="Center">
                 <ItemTemplate>
                   <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Description") %>' Font-Size="Larger"></asp:Label> 
                 </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                  <FooterTemplate>
                   <asp:TextBox runat="server" ID="Text3" Visible="false"></asp:TextBox>
                   </FooterTemplate>
                   
                    <EditItemTemplate>s
                     <asp:TextBox ID="edit3" Width="80%"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Description") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
                   
                 </asp:TemplateField>
              
                  <asp:TemplateField HeaderText="UNIT" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B" HeaderStyle-Width="70px"  HeaderStyle-ForeColor="white">
                 <ItemTemplate>
                      <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Unit") %>' Font-Size="Larger"></asp:Label> 
                 </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                 <FooterTemplate>
                  <asp:TextBox runat="server" ID="Text4" Visible="false"></asp:TextBox>
                  </FooterTemplate>
                  
                   <EditItemTemplate>
                     <asp:TextBox ID="edit4" Width="60px"  runat="server" CssClass="bx3"  ValidationGroup="Shree" Text='<%#Bind("Unit") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
          </asp:TemplateField>
          
    
                 <asp:TemplateField HeaderText="MIN. REQ. QTY. PER MONTH" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B" HeaderStyle-ForeColor="white" >
                 <ItemTemplate>
                       <asp:Label ID="lbl5" runat="server" Text='<%# Bind("Qty_month") %>' Font-Size="Larger"></asp:Label> 
                 </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                 <FooterTemplate>
                  <asp:TextBox runat="server" ID="Text5" Visible="false"></asp:TextBox>
                  </FooterTemplate>
                  
                   <EditItemTemplate>
                     <asp:TextBox ID="edit5" Width="40%"  runat="server" CssClass="bb"  ValidationGroup="Shree" Text='<%#Bind("Qty_month") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
           
             </asp:TemplateField>
                 
              <asp:TemplateField HeaderText="MIN STOCK QTY.-REORDER" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B" HeaderStyle-ForeColor="white">
                 
                 <ItemTemplate>
                      <asp:Label ID="lbl6" runat="server" Text='<%# Bind("ReOrder") %>' Font-Size="Larger"></asp:Label> 
                 </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                 <FooterTemplate>
                  <asp:TextBox runat="server" ID="Text6" Visible="false"></asp:TextBox>
                  </FooterTemplate>
                  <HeaderStyle HorizontalAlign="Center" />
                  
                   <EditItemTemplate>
                     <asp:TextBox ID="edit6" Width="40%"  runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("ReOrder") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
             </asp:TemplateField>
                 
             <asp:TemplateField HeaderText="MIN ORDER QTY - SPR" HeaderStyle-Font-Size="Larger"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B" HeaderStyle-ForeColor="white" >
                 <ItemTemplate>
                     <asp:Label ID="lbl4444" runat="server" Text='<%# Bind("Min_order") %>' Font-Size="Larger"></asp:Label> 
                 </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <FooterTemplate>
                    <asp:TextBox runat="server" ID="Text7" Visible="false"></asp:TextBox>
                    </FooterTemplate>
                    
                     <EditItemTemplate>
                     <asp:TextBox ID="edit7" Width="40%" runat="server" CssClasss="box3"  ValidationGroup="Shree" Text='<%#Bind("Min_order") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
         
            </asp:TemplateField>
                 
             <asp:TemplateField HeaderText="Procurement / lead Time in Days" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#607D8B" HeaderStyle-ForeColor="white">
                 <ItemTemplate>
                     <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Day") %>' Font-Size="Larger"></asp:Label> 
                 </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <FooterTemplate >
                    <asp:TextBox runat="server" ID="Text8" Visible="false"></asp:TextBox>
                    </FooterTemplate>
                    
                     <EditItemTemplate>
                     <asp:TextBox ID="edit8" Width="100" runat="server" CssClass="bx3"  ValidationGroup="Shree" Text='<%#Bind("Day") %>'>
                      </asp:TextBox>
                </EditItemTemplate>
                
             </asp:TemplateField>
             
             <asp:TemplateField HeaderText="Actual Stock" HeaderStyle-Font-Size="Larger"  HeaderStyle-Font-Bold="true" Visible="false"  HeaderStyle-BackColor="#607D8B" HeaderStyle-ForeColor="white">
                  <ItemTemplate>
                  </ItemTemplate>
             </asp:TemplateField>
        </Columns>
     </asp:GridView>
           
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>" 
           DeleteCommand="DELETE FROM [tbl_Stock_Month] WHERE [Id] = @Id" 
           InsertCommand="INSERT INTO [tbl_Stock_Month] ([Id,SrNo.,Item_code,Group,Description,Unit,Qty_month,ReOrder,Day,Min_order]) VALUES (@Id,@SrNo.,@Item_code,@Group,@Description,@Unit,@Qty_month,@ReOrder,@Day,@Min_order)" 
           SelectCommand="SELECT [Item_code],[Group],[Description],[Unit],[Qty_month],[ReOrder],[Day],[Min_order],[Id] FROM [tbl_Stock_Month]"
           UpdateCommand="UPDATE [tbl_Stock_Month] SET [Item_code] = @Item_code ,[Group]=@Group,[Description]=@Description,[Unit]=@Unit,[Qty_month]=@Qty_month,[ReOrder]=@ReOrder,[Day]=@Day,[Min_order]=@Min_order  WHERE [Id] = @Id">
                
          <InsertParameters>
             <asp:Parameter Name="Activity" Type="String" />
             <asp:Parameter Name="Id" Type="String" />
           </InsertParameters >
    </asp:SqlDataSource>
<asp:TextBox runat="server" ID="text22" Visible="false"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

