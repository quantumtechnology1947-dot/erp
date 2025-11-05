<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ProjectPlanning, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Project Planning</b></td>
        </tr>
        <tr>
        <td>

        <table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px"><tr>
                <td 
                    height="25" colspan="3" valign="middle" ><b>&nbsp;&nbsp; WONo: </b>
                    <asp:TextBox ID="txtWono" runat="server" CssClass="box3"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp; 
                <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                        onclick="btnSearch_Click" Text="Search" />
                        <asp:Label ID="lblWNo" runat="server" Visible="false" Text=""></asp:Label>
                </td></tr><tr>
                <td class="fontcss" valign="top" width="49%">
                    <asp:Panel ID="Panel1" Height="447px" ScrollBars="Auto" runat="server">                    
                <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                Width="100%" AllowPaging="True" PageSize="20" onrowcommand="GridView2_RowCommand">
                
                    <PagerSettings PageButtonCount="40" />
                
                <Columns><asp:TemplateField 
                        HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %>
                    </ItemTemplate>
                    <HeaderStyle Font-Size="10pt" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                    </asp:TemplateField>
                    
                  
                    <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label
                     ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" />
                     </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="Fin Year" >
                    <ItemTemplate>
                    <asp:Label ID="lblFinYear" runat="server" Text='<%# Bind("FinYear") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="WONo" >
                    <ItemTemplate>
                    <%--<asp:Label ID="lblWONo" runat="server" Text='<%# Bind("WONo") %>'></asp:Label>--%>
                        <asp:LinkButton ID="lbtnWONo" CommandName="Abc" runat="server" Text='<%# Bind("WONo") %>'>WONo</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>                
                    
                      <asp:TemplateField HeaderText="Date" >
                    <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Project Tittle" >
                    <ItemTemplate>
                    <asp:Label ID="lblProjectTittle" runat="server" Text='<%# Bind("ProjectTittle") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75%" />
                    </asp:TemplateField>
                    
                        </Columns>
                        <EmptyDataTemplate>
                        
                        <table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                        </EmptyDataTemplate>
                        <FooterStyle Font-Bold="False" />
                        <HeaderStyle Font-Size="9pt" />
                        </asp:GridView>
                 </asp:Panel></td>
                <td class="fontcss" valign="top" width="20">
                    &nbsp; </td>
                <td class="fontcss" valign="top" width="49%">
                
                    <asp:Panel ID="Panel2" Height="447px" ScrollBars="Auto" runat="server" 
                        Visible="False">
                   
                    <asp:GridView ID="GridView3" runat="server"  ShowFooter="true" AllowPaging="True" 
                        AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                        OnPageIndexChanging="GridView3_PageIndexChanging" 
                        OnRowCommand="GridView3_RowCommand" PageSize="23" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1  %>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkBtn" runat="server" CommandName="del" 
                                        OnClientClick=" return confirmationDelete()" Text="Delete"> </asp:LinkButton>
                                </ItemTemplate>
                                
                                
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" />
                            </asp:TemplateField>
                            
                      <asp:TemplateField HeaderText="Date" >
                    <ItemTemplate>
                    <asp:Label ID="lblPLNDate" runat="server" Text='<%# Bind("PLNDate") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="WONo"  Visible ="true">
                    <ItemTemplate>
                   
                        <asp:Label ID="lblWONo" runat="server" Text='<%# Bind("WONo") %>'></asp:Label>
                    </ItemTemplate>
                    
                    <FooterTemplate>
                        <asp:Label ID="lblWONo2" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="7%" />
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                    
                    
                      <asp:TemplateField HeaderText="File" >
                    <ItemTemplate>
                        <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                    </ItemTemplate>
                    
                    <FooterTemplate>
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="" >
                    <FooterTemplate>
                        <asp:Button ID="btnFAdd"  runat="server" Text="Add" CssClass="redbox" CommandName="Add" OnClientClick=" return confirmationAdd()" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                    
                        </Columns>
                        
                        <EmptyDataTemplate>                          
                            
                            <table border="1pt" style="border-color:GrayText" width="100%"><tr>
                             
                             <th>
                                SN
                             </th>
                             <th>
                                 WONo
                             </th>
                             <th >
                                 File
                             </th>
                             
                             <th>
                             </th>
                             </tr>
                             <tr>
                             <td  align="center">
                                        <asp:Label ID="lblSN" runat="server" Text="1"></asp:Label>
                                 </td>
                           
                                 <td  align="center">
                                        <asp:Label ID="lblWONo1" runat="server" Text=""></asp:Label>
                                 </td>
                                 <td >
                                     <asp:FileUpload ID="FileUpload2"  runat="server" />
                                 </td>
                                 <td align="center">
                                      <asp:Button ID="btnFAdd1"  runat="server" Text="Add" CssClass="redbox"  OnClientClick=" return confirmationAdd()" CommandName="Add1" />
                                 </td>
                                 
                             </tr>
                             </table>                            
                            
                        </EmptyDataTemplate>
                    </asp:GridView> 
                    </asp:Panel>
                </td>
            </tr></table>
            
           
                
                
                
        </td>
        </tr>
        </table>


 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

