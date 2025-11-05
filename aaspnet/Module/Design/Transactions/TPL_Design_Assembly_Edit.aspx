

<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_TPL_Design_Assembly_Edit, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .fontcss
        {
            width: 294px;
            margin-left: 12px;
        }
        .style17
        {
            height: 76px;
        }
        .style19
        {
            text-align: left;
        }
        .style24
        {
            width: 323px;
            height: 293px;
        }
        .style25
        {
            width: 326px;
            height: 293px;
        }
        .style26
        {
            height: 293px;
        }
        .style27
        {
            width: 58px;
            height: 22px;
        }
        .style28
        {
            height: 29px;
        }
        .style29
        {
            width: 93px;
            height: 32px;
            font-weight: bold;
        }
        .style30
        {
            height: 32px;
        }
        .style33
        {
            height: 19px;
        }
        .style34
        {
            width: 93px;
            height: 26px;
            font-weight: bold;
        }
        .style35
        {
            height: 26px;
        }
        .style36
        {
            text-align: left;
            width: 86px;
            font-weight: bold;
        }
    </style>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    <table cellpadding="2" class="style5" width="98%">
    <tr>
    <td colspan="3" style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21">&nbsp;<b>TPL 
        Item - Edit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WO No:&nbsp;<asp:Label runat="server" ID="lblWONo"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
        </td>
    </tr>
    <tr>
      <td>   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                                        ProviderName="System.Data.SqlClient" 
                                                        SelectCommand="SELECT [Id], [Symbol] FROM [vw_Unit_Master]">
                                                    </asp:SqlDataSource>
    
    
    </td>
    </tr>
        <tr>
            <td align="center" valign="top">
            
            
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                                OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="17" 
                                                Width="100%"  AllowPaging="True" 
                                            onrowcommand="GridView2_RowCommand"><Columns>
                                          <asp:TemplateField             HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    </asp:TemplateField>
                                                    
                                             <asp:TemplateField  >
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="BtnEdIt" runat="server" CommandName="Edt" >Edit</asp:LinkButton> <asp:LinkButton ID="BtnUpdate"  OnClientClick=" return confirmationUpdate()"  runat="server" Visible="false"  CommandName="Upd">Update</asp:LinkButton>
                                                            
                                                            <asp:LinkButton  ID="BtnCancel" runat="server"  Visible="false" CommandName="Can"  >Cancel</asp:LinkButton>
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="9%"  HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            
                                            
                                             <asp:TemplateField  >
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="BtnDelete"   runat="server"  OnClientClick=" return confirmationDelete()"   CommandName="Del" >Delete</asp:LinkButton> 
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="4%"  HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            
                                            
            
                                                    <asp:TemplateField HeaderText="ItemId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="6%" />
                                                </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amendment No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmdNo" runat="server" Text='<%# Bind("AmdNo") %>'></asp:Label>                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                                </asp:TemplateField>
                                                
                                                
                                                <asp:TemplateField HeaderText="Equipment No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEquipNo" runat="server" Text='<%# Bind("EquipmentNo") %>'></asp:Label>                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit No &nbsp; (Ex: xx)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitNo" runat="server" Text='<%# Bind("UnitNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   
                                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Part No/SN (Ex: xx)">
                                                     <ItemTemplate>
                                                        <asp:Label ID="lblPartNo" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                       
                                                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                                                      
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                            
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ManfDesc") %>'></asp:Label> <asp:TextBox ID="txtManfDescription" runat="server" CssClass="box3"  Visible="false"  Text='<%# Bind("ManfDesc") %>'                                                   TextMode="MultiLine" Width="300px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtManfDescription" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                      
                                                        
                                                        <ItemStyle Width="25%"  VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UOM">
                                                    <ItemTemplate>
                                                       <asp:Label ID="LblUom" Visible="false" runat="server" Text='<%# Bind("UOMBasic") %>'></asp:Label> 
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
           <asp:DropDownList ID="DDLUnitBasic" runat="server" CssClass="box3"  Visible="false" 
                                                       DataSourceId="SqlDataSource1" DataValueField="Id" DataTextField="Symbol"  >
                                                    </asp:DropDownList> 
          
                                                    </ItemTemplate>
                                                  
                                                   
                                                    <ItemStyle HorizontalAlign="Center"  VerticalAlign="Top" Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
      <asp:TextBox ID="txtQuntity" runat="server" CssClass="box3"   Visible="false"  Text='<%# Bind("Qty") %>' Width="50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtQuntity" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                        ControlToValidate="txtQuntity" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="assub"> </asp:RegularExpressionValidator>
      
                                                    </ItemTemplate>
                                                  
                                                    
                                                    <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="7%" />
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Drw/Image">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                                NavigateUrl='<%# Eval("ItemId", "~/Controls/DownloadFile.aspx?Id={0}&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType") %>' 
                                                                Text='<%# Eval("FileName") %>'> </asp:HyperLink>
                                                       <asp:ImageButton runat="server" ImageUrl="~/images/cross.gif" ID="ImageButton1" 
     CommandName="Del1" OnClientClick=" return confirmationDelete()"  Height="16px" style="height: 13px">
</asp:ImageButton>

                                                        
                                                    <asp:FileUpload ID="DrwUpload" runat="server"  Visible="false"  CssClass="box5"/>
                                                    </ItemTemplate>
                                                       
                                                        <ItemStyle HorizontalAlign="Left"  VerticalAlign="Top" Width="13%" />
                                                </asp:TemplateField>
                                                
                                                
                                                
                                                <asp:TemplateField HeaderText="Spec. Sheet">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("ItemId", "~/Controls/DownloadFile.aspx?Id={0}&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType") %>' 
                                                                Text='<%# Eval("AttName") %>'> </asp:HyperLink>
                                                      <asp:ImageButton runat="server" ImageUrl="~/images/cross.gif" ID="ImageButton2"  CommandName="Del2" Height="16px" OnClientClick=" return confirmationDelete()"  style="height: 13px">
</asp:ImageButton>
                                                    <asp:FileUpload ID="OtherUpload" runat="server"   Visible="false"  CssClass="box5" />
                                                    </ItemTemplate>
                                                    
                                                    <ItemStyle HorizontalAlign="Left"  VerticalAlign="Top" Width="20%" />
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
        
        <td align="center">
        
        
            <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                onclick="Button2_Click" Text="Cancel" />
        
        
        </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

