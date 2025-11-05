<%@ page language="C#" autoeventwireup="true" inherits="Others_Security_GatePass, newerp_deploy" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../Javascript/JScript.js" type="text/javascript"></script>
    <script src="../Javascript/MaxLength.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="fontcss">    
        <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
            onpageindexchanging="GridView1_PageIndexChanging" AllowPaging="true" PageSize="7" 
            AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="SN">
                <ItemTemplate> <%# Container.DataItemIndex + 1%></ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-VerticalAlign="Top">  
                <ItemTemplate>            
                             <asp:Image  ID="Image1" Height="120px" Width="110px" runat="server" 
                    ImageUrl = '<%# Eval("ImageUrl") %>' /> 
                </ItemTemplate>  
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GP No">
                <ItemTemplate>
                    <asp:Label ID="lblGPNo" runat="server" Text='<%# Eval("GPNo") %>'></asp:Label><br />
                                        
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" >
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Name of Employee" >    
                <ItemTemplate>
                    <asp:Label ID="lblSelfEId" runat="server" Text='<%# Eval("SelfEId") %>'></asp:Label><br />
                    [<asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>]
                </ItemTemplate> 
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>               
                <asp:TemplateField HeaderText="From Time" >
                <ItemTemplate>
                    <asp:Label ID="lblFromTime" runat="server" Text='<%# Eval("FromTime") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="To Time">
                <ItemTemplate>
                    <asp:Label ID="lblToTime" runat="server" Text='<%# Eval("ToTime") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type" >
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type For" >
                <ItemTemplate>
                    <asp:Label ID="lblTypeFor" runat="server" Text='<%# Eval("TypeFor") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason" >
                <ItemTemplate>
                    <asp:Label ID="lblReason" runat="server" Text='<%# Eval("Reason") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Place">
                <ItemTemplate>
                    <asp:Label ID="lblPlace" runat="server" Text='<%# Eval("Place") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Person" >
                 <ItemTemplate>
                    <asp:Label ID="lblContactPerson" runat="server" Text='<%# Eval("ContactPerson") %>'></asp:Label><br />
                    <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact No" Visible="false">
                <ItemTemplate>
                    
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Auth. By" >
                 <ItemTemplate>
                    <asp:Label ID="lblAuthBy" runat="server" Text='<%# Eval("AuthorizedBy") %>'></asp:Label><br />
                    <asp:Label ID="lblAuthDate" runat="server" Text='<%# Eval("AuthorizeDate") %>'></asp:Label><br />
                    <asp:Label ID="lblAuthTime" runat="server" Text='<%# Eval("AuthorizeTime") %>'></asp:Label>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" Visible="false" >
                <ItemTemplate>
                    
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time" Visible="false">
                <ItemTemplate>
                    
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
       
                  
                    
    </div>
    </form>
</body>
</html>