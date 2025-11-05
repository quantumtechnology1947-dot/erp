<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_MobileBills_Delete, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 44px;
        }
        .style3
        {
            width: 613px;
        }
        .style8
        {
            width: 224px;
            height: 30px;
        }
        .style9
        {
            width: 613px;
            height: 30px;
        }
        .style10
        {
            height: 30px;
        }
    </style>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" /> 
    

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <table width="100%" >
         <tr>
           
            <td align="left" valign="middle" colspan="3"  style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Mobile Bill - Delete</b></td>
           
        </tr>
        <tr>
            <td align="left" colspan="3">
                &nbsp;&nbsp;&nbsp;&nbsp;<b>Month Of Bill&nbsp; </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    CssClass="box3" Width="100px">
                  
                </asp:DropDownList>  
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        </td>
           
        </tr>
        <tr>
            <td align="center" colspan="3">
               <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="UserID" 
                FooterStyle-Wrap="True"               
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="100%"                      
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="20"  
                   >
                   
                <FooterStyle Wrap="True"></FooterStyle>


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
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                     
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                     
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UserID" SortExpression="UserID" Visible="False">
                            
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="CK">
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"  runat="server"/>
        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Emp Id" SortExpression="EmpId">
                        <ItemTemplate>
                        <asp:Label ID="lblEmpId" runat="server" Text='<%#Eval("EmpId") %>'>    </asp:Label>
                        </ItemTemplate>
                    
                            <ItemStyle HorizontalAlign="Center" />
                    
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Emp Name" SortExpression="EmployeeName">
                       <ItemTemplate>
                        <asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("EmployeeName") %>'>    </asp:Label>
                        </ItemTemplate>
                     
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Mobile No" SortExpression="MobileNo">
                       <ItemTemplate>
                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>'>    </asp:Label>
                        </ItemTemplate>
                       
                            <ItemStyle HorizontalAlign="Center" />
                       
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="Limit Amt" SortExpression="LimitAmt">
                       <ItemTemplate>
                        <asp:Label ID="lblLimitAmt" runat="server" Text='<%#Eval("LimitAmt") %>' >    </asp:Label>
                        </ItemTemplate>
                    
                            <ItemStyle HorizontalAlign="Right" />
                    
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Bill Amt" SortExpression="BillAmt">
                        <ItemTemplate>
                        <asp:Label ID="lblBillAmt" runat="server" Visible="false"> </asp:Label>
                        <asp:TextBox ID="TxtBillAmt" runat="server"  Visible="false">
                       
                        </asp:TextBox>
                        </ItemTemplate>
                    
                       
                         <FooterTemplate> 
                  <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox"  Text="Delete" OnClientClick=" return confirmationDelete()" CommandName="Del" />
                  </FooterTemplate>
                        
                       
                             <ItemStyle HorizontalAlign="Right" />
                        
                       
                          </asp:TemplateField>

                         
                         <asp:TemplateField HeaderText="Taxes" SortExpression="Taxes">
                        <ItemTemplate>
                        <asp:Label ID="lblTaxes" runat="server" >  </asp:Label>
                        <asp:DropDownList ID="DDLTaxes" runat="server" DataSourceID="SqlDataSource1" Visible="false"
                        DataTextField="Value"  DataValueField="Id"> 
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT [Id], [Value] FROM [tblExciseser_Master]">
                  </asp:SqlDataSource>
                        </ItemTemplate>
                        
                             <ItemStyle HorizontalAlign="Right" />
                        
                         </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Excess Amount" SortExpression="ExcessAmount">
                        <ItemTemplate>
                        <asp:Label ID="lblExcessAmount" runat="server" Visible="false" >    </asp:Label>
                        </ItemTemplate>
                        
                             <ItemStyle HorizontalAlign="Right" />
                        
                         </asp:TemplateField>
                        
                        
                    </Columns>
     
              </asp:GridView>
          
             
             </td>
           
        </tr>
        <tr>
            <td align="center" colspan="3">
              
                
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                
                
            </td>
           
        </tr>
        <tr>
            <td>
                &nbsp;</td>
           
            <td class="style3">
                &nbsp;</td>
           
            <td>
                &nbsp;</td>
           
        </tr>
       
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

