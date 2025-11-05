<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report_Info.aspx.cs" Inherits="ChallanInfo" Title="ERP" %>

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
 <table align="center" cellpadding="0" cellspacing="0" width="100%" >
    <tr height="21">
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Report Info</b></td>
    </tr></table>
    <br />
                                
<asp:GridView ID="GridView1" runat="server" DataKeyNames="PRJCTNO" AllowPaging="True" PageSize="10000" 
         AutoGenerateColumns="False" RowStyle-HorizontalAlign ="Center"   Width = "100%" Visible="false" DataSourceID="SqlDataSource1" 
        onrowcommand="GridView1_RowCommand1">
            <Columns>
            
            <asp:TemplateField HeaderText="SrNO." ItemStyle-HorizontalAlign="Right"   HeaderStyle-Font-Bold="true"  HeaderStyle-BackColor="#BDBDBD"  HeaderStyle-ForeColor="black" >
 <ItemTemplate>
      <%# Container.DataItemIndex + 1%>
 </ItemTemplate>
  
   </asp:TemplateField>
            
            
         <asp:BoundField DataField="PRJCTNO" HeaderText="Report NO" SortExpression="DCNo" 
                    HeaderStyle-BackColor = "#BDBDBD">
<HeaderStyle BackColor="#BDBDBD"></HeaderStyle>
                </asp:BoundField>
         <asp:TemplateField HeaderText="Link" HeaderStyle-Font-Bold="true"   HeaderStyle-BackColor="red"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
  <EditItemTemplate>
  <asp:Label runat="server" ID="lbl14" Text='<%# Eval("PRJCTNO") %>'></asp:Label>
  </EditItemTemplate>
   <ItemTemplate>
       <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument='<%# Bind("PRJCTNO") %>'>View</asp:LinkButton>
   </ItemTemplate>
            <HeaderStyle BackColor="#BDBDBD" Font-Bold="True" ForeColor="black" />
   <ItemStyle HorizontalAlign="Center"  ForeColor="Black" />
  </asp:TemplateField>
  
   <asp:BoundField DataField="SysDate" HeaderText="Gen Date" SortExpression="SysDate" HeaderStyle-BackColor = "#BDBDBD"/>
         <asp:BoundField DataField="SessionId" HeaderText="Gen By" SortExpression="SessionId" HeaderStyle-BackColor = "#BDBDBD"/>
         
          <asp:BoundField DataField="PRJCTNO" HeaderText="Report No. " Visible="false" SortExpression="PRJCTNO" HeaderStyle-BackColor = "#BDBDBD" />
         <asp:BoundField DataField="WONo" HeaderText="WONo" SortExpression="WONo" HeaderStyle-BackColor = "#BDBDBD"/>
  
  
           </Columns>
             </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>"
        SelectCommand="SELECT distinct PRJCTNO,SysDate,SessionId,WONo FROM tblPM_Project_Site_MasterD order by PRJCTNO asc" >
         </asp:SqlDataSource>
         
 
   
   <asp:GridView ID="GridView2" runat="server" DataKeyNames="Id" 
                                 Width="100%" 
                                AutoGenerateColumns="False" AllowPaging="False" 
                                CssClass="yui-datatable-theme" 
                                 OnRowCommand="GridView2_RowCommand"
                               >
                               
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Fin Year">
                                    <ItemTemplate>
                                    <asp:Label ID="lblfinyrs" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
 <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument='<%# Bind("PRJCTNO") %>'>View</asp:LinkButton>                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Report No.">
                        <ItemTemplate>
                            <asp:Label ID="lblPRNo" runat="server" Text='<%# Bind("PRJCTNO") %>'></asp:Label>
                        </ItemTemplate>                       
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField Visible="True" HeaderText="WONo"> 
                    <ItemTemplate>
                            <asp:Label ID="lblId1" runat="server" Text='<%# Bind("WONo") %>'></asp:Label>
                        </ItemTemplate>                       
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="SysDate" HeaderText="Date" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Time" HeaderText="Time" Visible="false" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EmpName" HeaderText="Gen By" >
                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:BoundField>
                    <asp:TemplateField Visible="false"> 
                    <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>                       
                        <ItemStyle HorizontalAlign="Right" />
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
   
   
   
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

