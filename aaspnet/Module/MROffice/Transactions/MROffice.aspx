<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MROffice_Transactions_MROffice, newerp_deploy" title="ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            width: 100%;
            float: left;
        }
    </style>
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
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server"><table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
    <table align="center" cellpadding="0" cellspacing="0"  class="fontcss" width="800px">
        <tr>
            <td align="center" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite">
                <b>&nbsp;MR Office&nbsp; - &nbsp;ISO </b>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Auto"> 
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    Width="100%"  ShowFooter="True" CssClass="yui-datatable-theme" 
                        AllowPaging="True" PageSize="20" 
                        onrowcommand="GridView2_RowCommand" 
                        onpageindexchanging="GridView2_PageIndexChanging" >
                        <Columns>
                            <asp:TemplateField HeaderText="SN">                            
                            <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="For">
                            <ItemTemplate>
                            <asp:Label ID="lblFor" runat="server" Text='<%#Eval("ForModule") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                            <asp:DropDownList ID="drpFor" Width="200px" runat="server" CssClass="box3" DataSourceID="SqlDataSource1" DataTextField="ModName" DataValueField="ModId"></asp:DropDownList>
                            </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Format/Document">
                            <ItemTemplate>
                            <asp:Label ID="lblFormat" runat="server" Text='<%#Eval("Format") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                            <asp:TextBox ID="txtFormat" Width="120px" runat="server" CssClass="box3"></asp:TextBox>
                            </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Attachment">
                             <ItemTemplate>
                                <asp:LinkButton ID="lblAtt" runat="server" CommandName="Download">View</asp:LinkButton> 
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:FileUpload ID="FileUploadAtt" runat="server" Width="200px" CssClass="box3"/>
                            </FooterTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>                          
                            <asp:TemplateField>
                            <ItemTemplate>                           
                            <asp:HiddenField Id="hidId" runat="server" Value='<%#Eval("Id") %>'/>
                            <asp:LinkButton ID="DelRec" runat="server" Text="Delete" CommandName="Delete"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                            <asp:Button ID="Add" CommandName="Add" Text="Add" runat="server" CssClass="redbox"/>
                            </FooterTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" class="style3">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:DropDownList ID="drpFor" Width="240px" runat="server" CssClass="box3" DataSourceID="SqlDataSource1" DataTextField="ModName" DataValueField="ModId"></asp:DropDownList></td>
                            <td>
                                <asp:TextBox ID="txtFormat" Width="150px" runat="server" CssClass="box3"></asp:TextBox></td>
                            <td>
                                <asp:FileUpload ID="FileUploadAtt" runat="server" Width="200px" CssClass="box3"/></td> 
                        <td>
                        <asp:Button ID="Add" CommandName="AddEmpty" Text="Add" runat="server" CssClass="redbox"/>
                        </td>
                        </tr>
                        
                    </table>
                        </EmptyDataTemplate>
                    </asp:GridView>                    
                    
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="SELECT [ModId], [ModName] FROM [tblModule_Master]">
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </td>
                        </tr>
                    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

