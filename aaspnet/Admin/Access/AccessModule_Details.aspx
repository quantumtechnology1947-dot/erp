<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_Access_AccessModule_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        
.box3 {
border: 1px solid #C5C5C5;

}
        
        .style3
        {
            font-weight: bold;
            font-size:16px;
        }
        .style4
        {
            height: 20px;
        }
    </style>
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
<td align="center">

    <table width="65%" >
        <tr>
            <td align="left" >
                <span class="style3">Company Name :</span>
                <asp:Label ID="lblCompName" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td align="left" >
                <span class="style3">Financial Year :</span>
                <asp:Label ID="lblFinYear" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <span class="style3">Employee Name :</span>
                <asp:Label ID="lblEmpName" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td align="left">
                <span class="style3">Module Name :
                </span>
                <asp:Label ID="lblModuleName" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Auto">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="yui-datatable-theme" PageSize="20">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1  %>
                                </ItemTemplate>
                                <HeaderStyle 
                            Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SubModId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="Server" Text='<%#Eval("SubModId")%>'/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MTR"  >
                                <ItemTemplate>
                                    <asp:Label ID="lblMTR" runat="Server" Text='<%#Eval("MTR")%>'/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SubModule Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubModName" runat="Server" Text='<%#Eval("SubModName")%>'/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="Cknew" Visible="false" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="CkEdit" Visible="false" runat="server"  />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="CkDelete"  Visible="false" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Print" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="CkPrint" Visible="false" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table width="100%" class="fontcss">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" class="style4">
                <asp:Button ID="BtnSave" runat="server" CssClass="redbox" Text=" Save " 
                    onclick="BtnSave_Click" onclientclick="return confirmation();" />
                &nbsp; <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                    Text="Cancel" onclick="BtnCancel_Click" />
            &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2" class="style4">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </td>

</tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

